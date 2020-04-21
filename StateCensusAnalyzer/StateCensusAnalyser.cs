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
        readonly string file;

        /// <summary>
        /// constructor with string parameter
        /// </summary>
        /// <param name="file"> path of file </param>
        public StateCensusAnalyser(string file)
        {
            try
            {
                if (file[file.Length - 4] != '.')
                    throw new CensusAnalyserException(CensusAnalyserException.CensusExceptionType.incorrectDelimeter, "delimter is wrong for file type in path");

                if (!file.EndsWith(".csv"))
                    throw new CensusAnalyserException(CensusAnalyserException.CensusExceptionType.incorrectType, "file type is incorrect");
                this.file = file;
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }       
        }

        public int GetNoOfRecords()
        {
            return numberOfRecords;
        }

        public void ReadRecords()
        {
            try
            {
                using CsvReader records = new CsvReader(new StreamReader(this.file));
                while (records.ReadNextRecord())
                {
                    this.numberOfRecords++;
                }
            }
            catch (IOException)
            {
                throw new CensusAnalyserException(CensusAnalyserException.CensusExceptionType.fileNotFound, "Wrong file path or file missing");
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
