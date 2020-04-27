namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using LumenWorks.Framework.IO.Csv;
    using StateCensusAnalyzer;

    public class StateCodeAnalyser
    {
        // read only path variable
        readonly string filepath;
        // variable to count numberof variables
        int recordsCount;

        public StateCodeAnalyser(string path = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCode.csv")
        {
            this.filepath = path;
        }

        /// <summary>
        /// Method to read the records in the file
        /// </summary>
        public void ReadRecords()
        {
            try
            {
                using (CsvReader State_code_reader = new CsvReader(new StreamReader(filepath)))
                {
                    // loop and count the number of records in the file
                    while (State_code_reader.ReadNextRecord()) recordsCount++;
                }
            }
            catch (ExceptionFileNotFound exceptionMessage)
            {
                Console.WriteLine(exceptionMessage.Message);
            }
            catch (Exception exceptionMessage)
            {
                Console.WriteLine(exceptionMessage.Message);
            }
        }
        /// <summary>
        /// Method to return total number of records in the given file
        /// </summary>
        /// <returns></returns>
        public int NumberOfRecords()
        {
            return recordsCount;
        }
    }
}
