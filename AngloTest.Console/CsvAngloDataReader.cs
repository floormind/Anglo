using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using AngloTest.Models;
using LumenWorks.Framework.IO.Csv;

namespace AngloTest.Console
{
    public class CsvAngloDataReader: IAngloDataReader
    {
        public IList<AngloData> GetAngloData(string filePath)
        {
            var csvTable = new DataTable();
            var angloDatas = new List<AngloData>();
            using (var csvReader = new CsvReader(new StreamReader(File.OpenRead(filePath)), true))
            {
                csvTable.Load(csvReader);
                for (int i = 0; i < csvTable.Rows.Count; i++)
                {
                    angloDatas.Add(new AngloData()
                    {
                        Id = Guid.Parse(csvTable.Rows[i][0].ToString()),
                        Age = csvTable.Rows[i][1].ToString(), // for the sake of implementing a validation on this field i have made the property on this class string. This is to defer the validation to the NanValidation class.
                        BirthDay = DateTime.Parse(csvTable.Rows[i][2].ToString()),
                        SignupDate = DateTime.Parse(csvTable.Rows[i][3].ToString()),
                        AccountType = csvTable.Rows[i][4].ToString()
                    });
                }
            }

            return angloDatas;
        }
    }
}