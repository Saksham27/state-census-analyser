using LumenWorks.Framework.IO.Csv;
using StateCensusAnalyzer;
using System;
using System.Dynamic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        // variables
        public int NumberOfRecords { get; set; }
        public string FilePath { get; set; }
        char delimeter;
        readonly string[] headers = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };

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
        public void ReadRecords( string[] inputHeaders = null, char inputDelimeter = ',')
        {
            try
            {
                if(inputHeaders is null)
                {
                    inputHeaders = headers;
                }
                // if the given file is not csv file rise exception
                if (!FilePath.EndsWith(".csv"))
                {
                    throw new ExceptionWrongFile(StateCensusException.wrongFile, "file type is incorrect");
                }                    
                var records = new StreamReader(FilePath);
                using (CsvReader csvRecords = new CsvReader(records))
                {

                    // count number of records
                    while (csvRecords.ReadNextRecord()) NumberOfRecords++;
                    // get delimeter 
                    delimeter = csvRecords.Delimiter;
                    // get header details
                    string[] fileHeaders = csvRecords.GetFieldHeaders();
                    // if delimeter of file is different raise Exception
                    if (!inputDelimeter.Equals(delimeter))
                    {
                        throw new ExceptionWrongDelimeter(StateCensusException.wrongDelimeter, "File has Different Delimeter");
                    }
                    if(!IsHeaderSame(fileHeaders, inputHeaders))
                    {
                        throw new ExceptionInvalidHeaders(StateCensusException.invalidHeaders, "Headers of file are not valid");
                    }
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
            catch (ExceptionInvalidHeaders)
            {
                throw new ExceptionInvalidHeaders(StateCensusException.invalidHeaders, "Headers of file are not valid");
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
            return NumberOfRecords;
        }//end:public int NumberOfRecords()

        public dynamic Delimeter()
        {
            return delimeter;
        }//end:public dynamic Delimeter()

        /// <summary>
        /// Method to compare string arrays
        /// </summary>
        /// <param name="header1"></param>
        /// <param name="header2"></param>
        /// <returns>return true if both string are equal else return false</returns>
        public bool IsHeaderSame(string[] header1, string[] header2)
        {
            // if length os the strings different return false
            if (header1.Length != header2.Length) return false;
            // loop and check each and every value of 2 strings
            for (int i = 0; i < header1.Length; i++)
            {
                if (header1[i].ToLower().CompareTo(header2[i].ToLower()) != 0) return false;
            }
            return true;
        }
    }//end:CensusAnalysisClass
}//end:namespace CensusAnalysis

