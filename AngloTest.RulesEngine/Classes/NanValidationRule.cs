using System.Collections.Generic;
using AngloTest.Models;
using AngloTest.RulesEngine.Interfaces;

namespace AngloTest.RulesEngine.Classes
{
    public class NanValidationRule : IValidationRule
    {
        public bool IsValid(IList<AngloData> angloDatas)
        {
            foreach (var angloData in angloDatas)
            {
                var age = 0;
                var parsed = int.TryParse(angloData.Age, out age);
                if (!parsed)
                    return false;
            }

            return true;
        }
    }
}