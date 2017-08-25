using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inference_algorithm
{
    public class BruteForceIE : AbstractIE
    {
        protected override void assertFact(object fact)
        {
            throw new NotImplementedException();
        }

        protected override void clearRuntimeFactStorage()
        {
            throw new NotImplementedException();
        }

        protected override List<object> getAllFacts()
        {
            throw new NotImplementedException();
        }

        protected override List<object> getAllFactsInRuntimeStorage()
        {
            throw new NotImplementedException();
        }

        protected override List<object> getAllRules()
        {
            throw new NotImplementedException();
        }

        protected override string getConditionExpression(object condition)
        {
            throw new NotImplementedException();
        }

        protected override object getConditionParameter(object condition)
        {
            throw new NotImplementedException();
        }

        protected override string getConsequenceExpression(object consequence)
        {
            throw new NotImplementedException();
        }

        protected override object getConsequenceParameter(object consequence)
        {
            throw new NotImplementedException();
        }

        protected override string getFactName(object fact)
        {
            throw new NotImplementedException();
        }

        protected override List<object> getFactProperties(object fact)
        {
            throw new NotImplementedException();
        }

        protected override string getFactPropertyName(object property)
        {
            throw new NotImplementedException();
        }

        protected override object getFactPropertyOnPosition(object fact, int position)
        {
            throw new NotImplementedException();
        }

        protected override string getFactPropertyType(object property)
        {
            throw new NotImplementedException();
        }

        protected override object getFactPropertyValue(object property)
        {
            throw new NotImplementedException();
        }

        protected override int getNrOfFactProperties(object fact)
        {
            throw new NotImplementedException();
        }

        protected override List<object> getRuleConditions(object rule)
        {
            throw new NotImplementedException();
        }

        protected override List<object> getRuleConsequences(object rule)
        {
            throw new NotImplementedException();
        }

        protected override RuleOperator getRuleOperator(object rule)
        {
            throw new NotImplementedException();
        }

        protected override bool isFactPropertyMandatory(object property)
        {
            throw new NotImplementedException();
        }

        protected override bool propertyRequiresInputFromUser(object property)
        {
            throw new NotImplementedException();
        }

        protected override void setConditionParameter(object condition, object parameter)
        {
            throw new NotImplementedException();
        }

        protected override void setFactPropertyValue(object property, object value)
        {
            throw new NotImplementedException();
        }
    }
}
