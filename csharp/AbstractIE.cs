using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inference_algorithm
{
    public abstract class AbstractIE
    {
        protected void checkRules()
        {
            List<Object> rules = getAllRules();
            foreach (Object rule in rules)
            {
                if (checkRuleConditions(getRuleOperator(rule), getRuleConditions(rule)))
                {
                    executeConsequences(getRuleConsequences(rule));
                }
            }
        }

        protected abstract List<Object> getAllRules();

        protected abstract RuleOperator getRuleOperator(Object rule);

        protected abstract List<Object> getRuleConditions(Object rule);

        protected abstract List<Object> getRuleConsequences(Object rule);

        protected abstract String getConditionExpression(Object condition);

        protected abstract String getConsequenceExpression(Object consequence);

        /**
         * The returned parameter can be a fact object, or a String.
         * 
         * @param consequence
         * @return
         */
        protected abstract Object getConsequenceParameter(Object consequence);

        protected abstract Object getConditionParameter(Object condition);

        private void executeConsequences(List<Object> consequences)
        {
            clearRuntimeFactStorage();
            foreach (Object consequence in consequences)
            {
                if (getConsequenceExpression(consequence) == (ClauseOperators.print.ToString()))
                {
                    Console.WriteLine(getConsequenceParameter(consequence));
                }
                else if (getConsequenceExpression(consequence) == (ClauseOperators.assertFact.ToString()))
                {
                    Object fact = (Object)getConsequenceParameter(consequence);
                    evaluateSlots(fact);
                    assertFact(fact);
                }
            }
        }

        /**
         * Completely clean runtime storage.
         */
        protected abstract void clearRuntimeFactStorage();

        protected abstract List<Object> getAllFactsInRuntimeStorage();

        /**
         * Put new fact to runtime storage.
         * 
         * @param fact
         */
        protected abstract void assertFact(Object fact);

        private void evaluateSlots(Object fact)
        {
            foreach (Object property in getFactProperties(fact))
            {
                if (propertyRequiresInputFromUser(property))
                {
                    try
                    {
                        Console.WriteLine("Please enter " + getFactPropertyName(property) + ": ");
                        String s = Console.ReadLine();
                        Type type = Type.GetType(getFactPropertyType(property), true);
                        var instance = Activator.CreateInstance(type, s);
                        setFactPropertyValue(property, instance);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex);
                    }

                }
            }
        }

        protected abstract List<Object> getFactProperties(Object fact);

        protected abstract String getFactName(Object fact);

        protected abstract bool propertyRequiresInputFromUser(Object property);

        /**
         * This method MUST return a valid fully qualified java class name!
         * 
         * @param property
         * @return
         */
        protected abstract String getFactPropertyType(Object property);

        protected abstract void setFactPropertyValue(Object property, Object value);

        protected abstract String getFactPropertyName(Object property);

        protected abstract void setConditionParameter(Object condition, Object parameter);

        private bool checkRuleConditions(RuleOperator ruleOp, List<Object> conditions)
        {
            bool conditionMet = true;
            IList<Object> retreivedFacts = new List<Object>();
            foreach (Object clause in conditions)
            {
                conditionMet = conditionMet & evaluateClause(clause, retreivedFacts);
            }
            return conditionMet;
        }

        private bool evaluateClause(Object clause, IList<Object> retreivedFacts)
        {
            if (getConditionExpression(clause) == (ClauseOperators.exists.ToString()))
            {
                if (getConditionParameter(clause) == null)
                {
                    setConditionParameter(clause, retreivedFacts[0]);
                }
                return exists(getConditionParameter(clause));
            }
            else if (getConditionExpression(clause) == (ClauseOperators.take.ToString()))
            {
                Object fact = getFirstFact(getAllFactsInRuntimeStorage(), getConditionParameter(clause).ToString());
                if (fact != null)
                {
                    retreivedFacts.Add(fact);
                    return true;
                }
            }

            return false;
        }

        private Object getFirstFact(List<Object> inferredFacts, String factName)
        {
            Object fact = null;
            int i = 0;
            while (fact == null && i < inferredFacts.Count)
            {
                if (getFactName(inferredFacts[i]) == (factName))
                {
                    fact = inferredFacts[i];
                }
                i++;
            }
            return fact;
        }

        protected abstract List<Object> getAllFacts();

        protected abstract int getNrOfFactProperties(Object fact);

        protected abstract Object getFactPropertyOnPosition(Object fact, int position);

        protected abstract bool isFactPropertyMandatory(Object property);

        protected abstract Object getFactPropertyValue(Object property);

        private bool exists(Object factToCheck)
        {
            List<Object> facts = getAllFacts();
            foreach (Object fact in facts)
            {
                bool factExists = true;

                factExists = factExists && getFactName(fact) == (getFactName(factToCheck));
                factExists = factExists && (getNrOfFactProperties(fact) == getNrOfFactProperties(factToCheck));

                for (int i = 0; i < getNrOfFactProperties(fact); i++)
                {
                    Object slot = getFactPropertyOnPosition(fact, i);
                    if (isFactPropertyMandatory(slot))
                    {
                        Object slotToCheck = getFactPropertyOnPosition(factToCheck, i);

                        factExists = factExists && getFactPropertyName(slot) == (getFactPropertyName(slotToCheck));
                        factExists = factExists && getFactPropertyType(slot) == (getFactPropertyType(slotToCheck));
                        factExists = factExists && getFactPropertyValue(slot) == (getFactPropertyValue(slotToCheck));
                    }
                }

                if (factExists)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
