using System;
using System.Collections.Generic;
using AngloTest.Models;
using AngloTest.RulesEngine.Interfaces;

namespace AngloTest.RulesEngine.Classes
{
    public class AccountTypeValidationRule : IValidationRule
    {
        // Check that account type is not empty.
        public bool IsValid(IList<AngloData> angloDatas)
        {
            foreach (var angloData in angloDatas)
            {
                if (String.IsNullOrEmpty(angloData.AccountType))
                    return false;
            }

            return true;
        }
    }
}