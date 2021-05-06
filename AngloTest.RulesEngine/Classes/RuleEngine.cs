using System;
using System.Collections.Generic;
using System.Linq;
using AngloTest.Models;
using AngloTest.RulesEngine.Interfaces;

namespace AngloTest.RulesEngine.Classes
{
    public class RuleEngine : IRulesEngine
    {
        private IEnumerable<IValidationRule> rules;
        public RuleEngine()
        {
            var validationRule = typeof(IValidationRule);
            
           rules = this.GetType().Assembly.GetTypes()
                .Where(x => validationRule.IsAssignableFrom(x) && !x.IsInterface)
                .Select(y => Activator.CreateInstance(y) as IValidationRule);
        }
        
        public bool IsValid(IList<AngloData> angloDatas)
        {
            foreach (var rule in rules)
            {
                if (rule.IsValid(angloDatas) == false)
                    return false;
            }

            return true;
        }
    }
}