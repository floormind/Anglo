using System.Collections.Generic;
using AngloTest.Models;

namespace AngloTest.Console
{
    public interface IAngloDataReader
    {
        IList<AngloData> GetAngloData(string path);
    }
}