
; var abstractIE = (function(bruteforceIE, clauseOperators) {

	function checkRules() {
		var rules = bruteforceIE.getAllRules();
		$.eacht(rules, function(idx, rule){
            if (bruteforceIE.checkRuleConditions(bruteforceIE.getRuleOperator(rule), bruteforceIE.getRuleConditions(rule))) {
				bruteforceIE.executeConsequences(bruteforceIE.getRuleConsequences(rule));
			}
        });
	}

	function executeConsequences(consequences) {
		bruteforceIE.clearRuntimeFactStorage();
        $.each(consequences, function(idx, consequence) {
			if (bruteforceIE.getConsequenceExpression(consequence) === clauseOperators.print.name) {
				console.log(bruteforceIE.getConsequenceParameter(consequence));
			} else if (bruteforceIE.getConsequenceExpression(consequence) === clauseOperators.assertFact.name) {
				var fact = bruteforceIEgetConsequenceParameter(consequence);
				evaluateSlots(fact);
				bruteforceIE.assertFact(fact);
			}
        });
	}

	function evaluateSlots(fact) {
		$.each(bruteforceIE.getFactProperties(fact), function(idx, property) {
			if (bruteforceIE.propertyRequiresInputFromUser(property)) {
                var s = prompt("Please enter " + getFactPropertyName(property) + ": ");
                bruteforceIE.setFactPropertyValue(property, s);
			}
        });
	}

	function checkRuleConditions(operator, conditions) {
		var conditionMet = true;
        var retreivedFacts = [];
		$.eacht(conditions, function(idx, clause) {
			conditionMet = conditionMet & evaluateClause(clause, retreivedFacts);
        });
		return conditionMet;
	}

	function evaluateClause(clause, retreivedFacts) {
		if (bruteforceIE.getConditionExpression(clause) === clauseOperators.exists.name) {
			if (bruteforceIE.getConditionParameter(clause) == null) {
				bruteforceIE.setConditionParameter(clause, retreivedFacts[0]);
			}
			return exists(bruteforceIE.getConditionParameter(clause));
		} else if (bruteforceIE.getConditionExpression(clause) === clauseOperators.take.name) {
			var fact = getFirstFact(bruteforceIE.getAllFactsInRuntimeStorage(), bruteforceIE.getConditionParameter(clause));
			if (fact != null) {
				retreivedFacts.push(fact);
				return true;
			}
		}

		return false;
	}

	function getFirstFact(inferredFacts, factName) {
		var fact = null;
		var i = 0;
		while (fact == null && i < inferredFacts.size()) {
			if (bruteforceIE.getFactName(inferredFacts[i]).equals(factName)) {
				fact = inferredFacts[i];
			}
			i++;
		}
		return fact;
	}

	function exists(factToCheck) {
		var facts = bruteforceIE.getAllFacts();
		$.each(facts, function(idx, fact) {
			var factExists = true;

			factExists = factExists && bruteforceIE.getFactName(fact) === bruteforceIE.getFactName(factToCheck);
			factExists = factExists && (bruteforceIE.getNrOfFactProperties(fact) == bruteforceIE.getNrOfFactProperties(factToCheck));

			for (var i = 0; i < bruteforceIE.getNrOfFactProperties(fact); i++) {
				var slot = bruteforceIE.getFactPropertyOnPosition(fact, i);
				if (bruteforceIE.isFactPropertyMandatory(slot)) {
					var slotToCheck = bruteforceIE.getFactPropertyOnPosition(factToCheck, i);

					factExists = factExists && bruteforceIE.getFactPropertyName(slot) === bruteforceIE.getFactPropertyName(slotToCheck);
					factExists = factExists && bruteforceIE.getFactPropertyType(slot) === bruteforceIE.getFactPropertyType(slotToCheck);
					factExists = factExists && bruteforceIE.getFactPropertyValue(slot) === bruteforceIE.getFactPropertyValue(slotToCheck);
				}
			}

			if (factExists) {
				return true;
			}
        });

		return false;
	}

})(bruteforceIE, clauseOperators);