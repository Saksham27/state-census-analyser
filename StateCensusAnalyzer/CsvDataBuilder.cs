using System;
using System.Collections;
using System.IO;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyser
{

    public class CsvDataBuilder : ICsvBuilder
    {
        // read only path variable
        public string filePath;

        // variable to count numberof variables
        public int numberOfRecords;

        // variable for delimeter character
        public char delimeter;

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
            //sort the list by using bubble sort
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
                        value1 = value2;
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

        /// <summary>Method to Read file data POCO concept </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonForm">if its true return data in json form</param>
        /// <param name="sorting">if its true return data in sorted order</param>
        /// <param name="sortColoumnNum"> sort by menas of this column</param>
        /// <returns></returns>
        public dynamic ReadFileData(string filePath, string className, bool jsonForm = false, bool sorting = false, int sortColoumnNum = 1)
        {

            // since index of column is -1 of number of column
            sortColoumnNum--;
            try
            {
                var records = new StreamReader(filePath);
                CsvReader csv_rocords = new CsvReader(records);
                // variable
                int numberOfRecords = 0;
                // get delimeter 
                char fileDelimeter = csv_rocords.Delimiter;
                if (className == "StateCensusPrototype")
                {
                    List<StateCensusPrototype> census = new List<StateCensusPrototype>();
                    // get header details
                    census.Add(new StateCensusPrototype(csv_rocords.GetFieldHeaders()));

                    while (csv_rocords.ReadNextRecord())
                    {
                        numberOfRecords++;
                        string[] record = new string[csv_rocords.FieldCount];
                        csv_rocords.CopyCurrentRecordTo(record);
                        census.Add(new StateCensusPrototype(record));
                    }
                    // if sorting is true call SortList method
                    if (sorting)
                    {
                        census = census.OrderBy(data => data[sortColoumnNum]).ToList();
                    }
                    if (jsonForm)
                    {
                        //Convert sorted data into 
                        var dataInJson = JsonSerializer.Serialize(census);
                        return (csv_rocords.GetFieldHeaders(), numberOfRecords, fileDelimeter, dataInJson);
                    }
                    return (csv_rocords.GetFieldHeaders(), numberOfRecords, fileDelimeter, census);
                }

                if (className == "StateCodePrototype")
                {
                    List<StateCodePrototype> census = new List<StateCodePrototype>();
                    // get header details
                    census.Add(new StateCodePrototype(csv_rocords.GetFieldHeaders()));

                    while (csv_rocords.ReadNextRecord())
                    {
                        numberOfRecords++;
                        string[] record = new string[csv_rocords.FieldCount];
                        csv_rocords.CopyCurrentRecordTo(record);
                        census.Add(new StateCodePrototype(record));
                    }
                    // if sorting is true call SortList method
                    if (sorting)
                    {
                        census = census.OrderBy(data => data[sortColoumnNum]).ToList();
                    }
                    if (jsonForm)
                    {
                        //Convert sorted data into 
                        var dataInJson = JsonSerializer.Serialize(census);
                        return (csv_rocords.GetFieldHeaders(), numberOfRecords, fileDelimeter, dataInJson);
                    }
                    return (csv_rocords.GetFieldHeaders(), numberOfRecords, fileDelimeter, census);
                }
                return default;

            }
            catch (FileNotFoundException fileNotFound)
            {
                Console.WriteLine(fileNotFound.Message);
                return "FileNotFound";
            }
            catch (Exception excep)
            {
                Console.WriteLine(excep.Message);
                return default;
            }
        }//end: public dynamic ReadFileData(string filePath, bool jsonForm = false, bool sorting = false, int sortColoumnNum = 1)

    }
}