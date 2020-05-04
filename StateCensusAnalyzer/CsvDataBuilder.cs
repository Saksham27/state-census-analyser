using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LumenWorks.Framework.IO.Csv;

namespace CensusAnalyser
{
    public class CsvDataBuilder : ICsvBuilder
    {
        /// <summary>
        /// Method to read csv Records
        /// </summary>
        public dynamic ReadData(string filePath)
        {
            try
            {
                var records = new StreamReader(filePath);
                using (CsvReader csvRecords = new CsvReader(records))
                {
                    int numberOfRecords = 0;
                    // count number of records
                    while (csvRecords.ReadNextRecord())
                    {
                        numberOfRecords++;
                    }
                    // get delimeter 
                    char delimeter = csvRecords.Delimiter;
                    // get header details
                    string[] headers = csvRecords.GetFieldHeaders();

                    // Declare a List to store the records 
                    List<string[]> fileData = new List<string[]>();
                    // read the records into List      
                    while (csvRecords.ReadNextRecord())
                    {
                        string[] record = new string[csvRecords.FieldCount];
                        csvRecords.CopyCurrentRecordTo(record);
                        fileData.Add(record);
                    }
                    return (headers, numberOfRecords, delimeter, fileData);
                }
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
                return default;

            }
            catch (FileNotFoundException)
            {
                throw new ExceptionFileNotFound(StateCensusException.fileNotFound, "Wrong file path or file missing");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }//end:public void ReadRecords()
    }
}
