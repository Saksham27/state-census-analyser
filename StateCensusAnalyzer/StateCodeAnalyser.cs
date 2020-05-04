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
        public string filePath;

        // variable to count numberof variables
        public int numberOfRecords;

        // variable for delimeter character
        public char delimeter;

        public StateCodeAnalyser(string file = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCode.csv")
        {
            filePath = file;
        }

        /// <summary>
        /// Method to read csv Records
        /// </summary>
        public void ReadRecords(string[] inputHeaders = null, char inputDelimeter = ',')
        {
            try
            {
                // if the given file is not csv file rise exception
                if (!filePath.EndsWith(".csv"))
                {
                    throw new ExceptionWrongFile(StateCensusException.wrongFile, "file type is incorrect");
                }
                CsvDataBuilder csvData = new CsvDataBuilder();
                var records = csvData.ReadData(filePath);
                try
                {
                    if (records.Equals("FileNotFound", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new ExceptionFileNotFound(StateCensusException.fileNotFound, "File not found ");
                    }
                }
                catch (ExceptionFileNotFound exception)
                {
                    Console.WriteLine(exception.Message);
                    throw new ExceptionFileNotFound(StateCensusException.fileNotFound, exception.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Ignored {exception.Message} because result as we expected");
                }
                string[] header = records.Item1;
                numberOfRecords = records.Item2;
                delimeter = records.Item3;
                // if delimeter of file is different raise Exception
                if (!inputDelimeter.Equals(delimeter))
                {
                    throw new ExceptionWrongDelimeter(StateCensusException.wrongDelimeter, "File has different delimeter than given");
                }
                if (!CheckIfHeaderSame(inputHeaders, header) && inputHeaders != null)
                {
                    throw new ExceptionInvalidHeaders(StateCensusException.invalidHeaders, "Headers of file are not valid");
                }
            }
            catch (ExceptionFileNotFound exception)
            {
                throw new ExceptionFileNotFound(StateCensusException.fileNotFound, exception.Message);
            }
            catch (ExceptionWrongFile exception)
            {
                throw new ExceptionWrongFile(StateCensusException.wrongFile, exception.Message);
            }
            catch (ExceptionWrongDelimeter exception)
            {
                throw new ExceptionWrongDelimeter(StateCensusException.wrongDelimeter, exception.Message);
            }
            catch (ExceptionInvalidHeaders exception)
            {
                throw new ExceptionInvalidHeaders(StateCensusException.invalidHeaders, exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }//end:public void ReadRecords()

        public int RecordsCount()
        {
            ReadRecords();
            return numberOfRecords;
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
        public bool CheckIfHeaderSame(string[] header1, string[] header2)
        {
            // if length os the strings different return false
            if (header1.Length != header2.Length) return false;
            // loop and check each and every value of 2 strings
            for (int i = 0; i < header1.Length; i++)
            {
                if (header1[i].Trim().ToLower().CompareTo(header2[i].ToLower()) != 0) return false;
            }
            return true;
        }
    }//end : public class StateCodeAnalyser
}//end : namespace CensusAnalysis