using System.Collections.Generic;
using AngloTest.Models;
using AngloTest.RulesEngine.Interfaces;

namespace AngloTest.RulesEngine.Classes
{
    public class DuplicationValidationRule : IValidationRule
    {
        // Check that all the properties on the AngloData object are unique per role.
        // This is with the assumption that uniqueness is based on each property and not just the guid value.
        // If the guid (Id) is all that we care about then that is an easier check for equality on the guid value.
        public bool IsValid(IList<AngloData> angloDatas)
        {
            for(var i = 0; i < angloDatas.Count; i++)
            {
                for (var j = i; i < angloDatas.Count; i++)
                {
                    if (i != j)
                    {
                        if (angloDatas[i].Id.Equals(angloDatas[j].Id)
                            && angloDatas[i].Age.Equals(angloDatas[j].Age)
                            && angloDatas[i].BirthDay.Equals(angloDatas[j].BirthDay)
                            && angloDatas[i].SignupDate.Equals(angloDatas[j].SignupDate)
                            && angloDatas[i].AccountType.Equals(angloDatas[j].AccountType))
                            return false;
                    }
                }
            }
            return true;
        }
    }
}