using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using AngloTest.Models;
using AngloTest.RulesEngine.Classes;
using AngloTest.RulesEngine.Interfaces;
using LumenWorks.Framework.IO.Csv;

namespace AngloTest.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data-clean.csv"); //substitute the file for data-dirty for testing
            
            IAngloDataReader dataReader = new CsvAngloDataReader();
            var angloDatas = dataReader.GetAngloData(filePath);
            
            IRulesEngine rulesEngine = new RuleEngine();
            var result = rulesEngine.IsValid(angloDatas);
            
            System.Console.WriteLine($"The result for passing validation is {result}");
        }
    }
}
