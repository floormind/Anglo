using System.Collections.Generic;
using AngloTest.Models;

namespace AngloTest.RulesEngine.Interfaces
{
    public interface IRulesEngine
    {
        bool IsValid(IList<AngloData> angloDatas);
    }
}