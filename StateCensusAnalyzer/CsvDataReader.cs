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

                    // declare a string array to store the records
                    string[,] filedata = new string[numberOfRecords, csvRecords.FieldCount];
                    // read the records into string array an index iterator
                    int index = 0,
                        fieldIterater = 0;
                    while (csvRecords.ReadNextRecord())
                    {
                        string[] record = new string[csvRecords.FieldCount];
                        csvRecords.CopyCurrentRecordTo(record);
                        fieldIterater = 0;
                        foreach (string value in record)
                        {
                            filedata[index, fieldIterater] = value;
                            fieldIterater++;
                        }
                        index++;
                    }
                    return (headers, numberOfRecords, delimeter, filedata);
                }
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
