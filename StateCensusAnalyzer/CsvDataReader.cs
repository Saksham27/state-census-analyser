using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LumenWorks.Framework.IO.Csv;

namespace CensusAnalyser
{
    class CsvDataReader
    {
        // variables
        internal int NumberOfRecords { get; set; }
        private string FilePath { get; set; }
        internal char delimeter;
        internal string[] headers = null;

        /// <summary>
        /// constructor with file path as input to set file path 
        /// </summary>
        /// <param name="file"> path of file as string </param>
        public CsvDataReader(string file)
        {
            FilePath = file;
        }

        /// <summary>
        /// Method to read csv Records
        /// </summary>
        public void ReadData()
        {
            try
            {
                var records = new StreamReader(FilePath);
                using (CsvReader csvRecords = new CsvReader(records))
                {
                    // count number of records
                    while (csvRecords.ReadNextRecord()) NumberOfRecords++;
                    // get delimeter 
                    delimeter = csvRecords.Delimiter;
                    // get header details
                    string[] headers = csvRecords.GetFieldHeaders();
                }
            }
            catch (FileNotFoundException)
            {
                throw new ExceptionFileNotFound(StateCensusException.fileNotFound, "Wrong file path or file missing");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }//end:public void ReadRecords()
    }
}
