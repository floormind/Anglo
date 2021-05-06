using System.Collections.Generic;
using AngloTest.Models;

namespace AngloTest.RulesEngine.Interfaces
{
    public interface IValidationRule
    {
        bool IsValid(IList<AngloData> angloDatas);
    }
}