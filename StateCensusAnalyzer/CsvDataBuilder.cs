using System;
using System.Collections;
using System.IO;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using System.Collections.Generic;

namespace CensusAnalyser
{

    public class CsvDataBuilder : ICsvBuilder
    {
        /// <summary>
        /// Method to read csv Records
        /// </summary>
        public dynamic ReadData(string filePath, bool json = false, bool sort = false, int sortColumn = 1)
        {
            // since index of column is -1 of number of column
            sortColumn--;
            try
            {
                var records = new StreamReader(filePath);
                using (CsvReader csvRecords = new CsvReader(records))
                {
                    int numberOfRecords = 0;
                    // count number of records
                    string[] data = new string[numberOfRecords];
                    // get delimeter 
                    char delimeter = csvRecords.Delimiter;
                    // get header details
                    string[] headers = csvRecords.GetFieldHeaders();

                    // Declare a List to store the records 
                    ArrayList fileData = new ArrayList();
                    fileData.Add(headers);
                    // read the records into List      
                    while (csvRecords.ReadNextRecord())
                    {
                        numberOfRecords++;
                        string[] record = new string[csvRecords.FieldCount];
                        csvRecords.CopyCurrentRecordTo(record);
                        fileData.Add(record);
                    }
                    if (sort)
                    {
                        // if sort is true call SortData method
                        fileData = SortData(fileData, sortColumn);
                    }
                    if (json)
                    {
                        // convert to json
                        var jsonData = JsonSerializer.Serialize(fileData);
                        return (headers, numberOfRecords, delimeter, jsonData);
                    }
                    return (headers, numberOfRecords, delimeter, fileData);
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

        /// <summary>2) Sort method to sort the Array List  </summary>
        /// <param name="dataList">ArrayList with data in form of string[]</param>
        /// <param name="sortingColoumnNum"></param>
        /// <returns>sorted ArrayList</returns>
        ArrayList SortData(ArrayList dataList, int sortingColoumnNum = 0)
        {
            int index = 0;
            ArrayList sortedList = new ArrayList();
            sortedList.Add(dataList[0]);
            int count = dataList.Count;
            //sort the list by using bobble sort
            while (count > 0)
            {
                dynamic record1 = dataList[0];
                string value1 = record1[sortingColoumnNum];
                for (int j = 1; j < count; j++)
                {
                    dynamic record2 = dataList[j];
                    string value2 = String.Copy(record2[sortingColoumnNum]);
                    if (value1.CompareTo(value2) > 0)
                    {
                        value1 = String.Copy(value2);
                        index = j;
                    }
                }
                sortedList.Add(dataList[index]);
                dataList.RemoveAt(index);
                index = 0;
                count = dataList.Count;
            }
            return sortedList;
        }//end:ArrayList SortList(ArrayList dataList,int sortingColoumnNum)
    }
}