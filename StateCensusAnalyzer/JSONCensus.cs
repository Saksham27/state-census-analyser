using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using LumenWorks.Framework.IO.Csv;
using System.Text;
using ChoETL;
using System.IO;

namespace CensusAnalyser
{
    public class JSONCensus
    {
        /// <summary>
        /// Method to write the First state data using json
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonFilepath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string SortCsvFileWriteInJsonAndReturnFirstData(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var reader = ChoCSVReader.LoadText(readFile)
                                       .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(reader);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CsvStateCensusReadRecord.SortingJsonBasedOnKey(jsonFilepath, key);
            //serialize JSON to a string and then write string to a file
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CsvStateCensusReadRecord.RetriveFirstDataOnKey(jsonFilepath, key);
        }
        /// <summary>
        /// Method to write the last state data using json
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonFilepath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string SortCsvFileWriteInJsonAndReturnLastData(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var reader = ChoCSVReader.LoadText(readFile)
                                       .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(reader);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CsvStateCensusReadRecord.SortingJsonBasedOnKey(jsonFilepath, key);
            // serialize JSON to a string and then write string to a file
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CsvStateCensusReadRecord.RetriveLastDataOnKey(jsonFilepath, key);
        }
    }
}
