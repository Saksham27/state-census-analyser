using LumenWorks.Framework.IO.Csv;
using StateCensusAnalyzer;
using System;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {

        int numberOfRecords = default;
        string file;

        /// <summary>
        /// constructor with string parameter
        /// </summary>
        /// <param name="file"> path of file </param>
        public StateCensusAnalyser(string file)
        {   
            this.file = file;
        }

        public int ReadRecords()
        {
            try
            {
                using CsvReader records = new CsvReader(new StreamReader(this.file));
                while (records.ReadNextRecord())
                {
                    this.numberOfRecords++;
                }
                return numberOfRecords;
            }
            catch(FileNotFoundException)
            {
                throw new CensusAnalyserException(CensusAnalyserException.CensusExceptionType.file_not_found, "Wrong file path or file missing");
            }
        }

        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

        }

    }
}
