using LumenWorks.Framework.IO.Csv;
using StateCensusAnalyzer;
using System;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        // variables
        int numberOfRecords = 0;
        string filePath;
        dynamic delimeter;

        public StateCensusAnalyser(string path = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.csv")
        {
            this.filePath = path;
        }
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

        }////end:static void Main(string[] args)
        /// <summary>
        /// Method to read csv Records
        /// </summary>
        public void ReadRecords(char inputDelimeter = ',')
        {
            try
            {
                // if the given file is not csv file rise exception
                if (!filePath.EndsWith(".csv"))
                {
                    throw new ExceptionWrongFile(StateCensusException.wrongFile, "file type is incorrect");
                }                    
                var records = new StreamReader(filePath);
                using (CsvReader csvRecords = new CsvReader(records))
                {

                    // count number of records
                    while (csvRecords.ReadNextRecord()) numberOfRecords++;
                    // get delimeter 
                    delimeter = csvRecords.Delimiter;
                    // if delimeter of file is different raise Exception
                    if (!inputDelimeter.Equals(delimeter))
                        throw new ExceptionWrongDelimeter(StateCensusException.wrongDelimeter, "File has Different Delimeter");
                }
            }
            catch (ExceptionWrongFile)
            {
                throw new ExceptionWrongFile(StateCensusException.wrongFile, "file type is incorrect");
            }
            catch (ExceptionWrongDelimeter)
            {
                throw new ExceptionWrongDelimeter(StateCensusException.wrongDelimeter, "File has different delimeter than given");
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

        /// <summary>
        /// Method to return number of records in the file
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfRecords()
        {
            return numberOfRecords;
        }//end:public int NumberOfRecords()

        public dynamic Delimeter()
        {
            return delimeter;
        }//end:public dynamic Delimeter()


    }//end:CensusAnalysisClass
}//end:namespace CensusAnalysis

