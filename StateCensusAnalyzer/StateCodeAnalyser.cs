namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using CensusAnalyser;

    public class StateCodeAnalyser
    {
        // read only path variable
        public string FilePath { get; set; }

        // variable to count numberof variables
        public int numberOfRecords;

        // variable for delimeter character
        public char delimeter;

        // string array to store csv headers
        internal string[] headers;

        public StateCodeAnalyser(string file)
        {
            FilePath = file;
        }
        /// <summary>
        /// Method to read csv Records
        /// </summary>
        public void ReadRecords(string[] inputHeaders = null, char inputDelimeter = ',')
        {
            try
            {
                if (inputHeaders is null)
                {
                    inputHeaders = headers;
                }
                // if the given file is not csv file rise exception
                if (!FilePath.EndsWith(".csv"))
                {
                    throw new ExceptionWrongFile(StateCensusException.wrongFile, "file type is incorrect");
                }
                CsvDataReader csvData = new CsvDataReader(FilePath);
                numberOfRecords = csvData.NumberOfRecords;
                delimeter = csvData.delimeter;
                headers = csvData.headers;
                // if delimeter of file is different raise Exception
                if (!inputDelimeter.Equals(delimeter))
                {
                    throw new ExceptionWrongDelimeter(StateCensusException.wrongDelimeter, "File has Different Delimeter");
                }
                if (!CheckIfHeaderSame(headers, inputHeaders))
                {
                    throw new ExceptionInvalidHeaders(StateCensusException.invalidHeaders, "Headers of file are not valid");
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }//end:public void ReadRecords()
 
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
        public bool CheckIfHeaderSame(string[] header1, string[] header2)
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
    }//end : public class StateCodeAnalyser
}//end : namespace CensusAnalysis