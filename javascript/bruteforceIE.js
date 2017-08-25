
; var bruteforceIE = (function() {
    var module = {};

	module.getAllRules = function(){
        // TODO
    }

	module.getRuleOperator = function(rule){
        // TODO
    }

	module.getRuleConditions = function(rule) {
        // TODO
    }

	module.getRuleConsequences = function(rule) {
        // TODO
    }

	module.getConditionExpression = function(condition) {
        // TODO
    }

	module.getConsequenceExpression = function(consequence) {
        // TODO
    }

    	/**
	 * The returned parameter can be a fact object, or a String.
	 * 
	 * @param consequence
	 * @return
	 */
	module.getConsequenceParameter = function(consequence) {
        // TODO
    }

	module.getConditionParameter = function(condition) {
        // TODO
    }

    /**
	 * Completely clean runtime storage.
	 */
	module.clearRuntimeFactStorage = function() {
        // TODO
    }

	module.getAllFactsInRuntimeStorage = function() {
        // TODO
    }

	/**
	 * Put new fact to runtime storage.
	 * 
	 * @param fact
	 */
	module.assertFact = function(fact) {
        // TODO
    }

	module.getFactProperties = function(fact) {
        // TODO
    }

	module.getFactName = function(fact) {
        // TODO
    }

	module.propertyRequiresInputFromUser = function(property) {
        // TODO
    }

	/**
	 * This method MUST return a valid fully qualified java class name!
	 * 
	 * @param property
	 * @return
	 */
	module.getFactPropertyType = function(property) {
        // TODO
    }

	module.setFactPropertyValue = function(property, value) {
        // TODO
    }

	module.getFactPropertyName = function(property) {
        // TODO
    }

	module.setConditionParameter = function(condition, parameter) {
        // TODO
    }

	module.getAllFacts = function() {
        // TODO
    }

	module.getNrOfFactProperties = function(fact) {
        // TODO
    }

	module.getFactPropertyOnPosition = function(fact, position) {
        // TODO
    }

	module.isFactPropertyMandatory = function(property) {
        // TODO
    }

	module.getFactPropertyValue = function(property) {
        // TODO
    }

    return module;
});