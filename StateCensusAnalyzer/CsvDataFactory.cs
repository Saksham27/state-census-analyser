using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CensusAnalyser
{
    /// <summary>
    /// csv data factory
    /// </summary>
    public class CsvDataFactory : CsvDataBuilder
    {
        /// <summary>1)Method to Read data from file </summary>
        /// <param name="filePath"></param>
        /// <returns>Data in Json format</returns>
        public dynamic DataInJsonForm(string filePath, bool sorting = true, int sortColumnNum = 1)
        {
            // call Read Data Method, it return a touple (fileHeader, numberOfRecords, fileDelimeter, fileData);
            var result = ReadData(filePath, true, sorting, sortColumnNum);
            return result.Item4;
        }//end:public dynamic DataInJsonForm(string filepath)

        /// <summary>2)Method to Get file data in Array List form </summary>
        /// <param name="filePath"></param>
        /// <returns> file Data in the form of ArrayList</returns>
        public dynamic DataInArrayListForm(string filePath)
        {
            // call Read Data Method, it return a touple (fileHeader, numberOfRecords, fileDelimeter, fileData);
            var result = ReadData(filePath);
            return result.Item4;
        }//end:public dynamic DataInArrayListForm(string filepath)

        /// <summary> 3)Method to Return Header Details of the file </summary>
        /// <param name="filePath"></param>
        /// <returns>Header of given file</returns>
        public dynamic GetHeader(string filePath)
        {
            // call Read Data Method, it return a touple (fileHeader, numberOfRecords, fileDelimeter, fileData);
            var result = ReadData(filePath);
            return result.Item1;
        }//end:public dynamic GetHeader(string filepath)

        /// <summary>4)Method to return Delimeter of the given file</summary>
        /// <param name="filePath"></param>
        /// <returns>Delimeter of file</returns>
        public dynamic GetDelimeter(string filePath)
        {
            // call Read Data Method, it return a touple (fileHeader, numberOfRecords, fileDelimeter, fileData);
            var result = ReadData(filePath);
            return result.Item3;
        }//end:public dynamic GetDelimeter(string filePath)

        /// <summary> 5)Method to Get and Return numberOfRecords</summary>
        /// <param name="filePath"></param>
        /// <returns>number of records in the file</returns>
        public int getNumberofRecords(string filePath)
        {
            // call Read Data Method, it return a touple (fileHeader, numberOfRecords, fileDelimeter, fileData);
            var result = ReadData(filePath);
            return result.Item2;
        }//end:public int getNumberofRecords(string filePath)

        /// <summary> 6)Method to call IsHeaderSame method in StateCensusData  </summary>
        /// <param name="filePath"></param>
        /// <param name="inputHeader">Header given by the user</param>
        /// <returns></returns>
        public bool CheckHeaders(string filePath, string[] inputHeader)
        {
            var fileHeader = GetHeader(filePath);
            StateCensusAnalyser obj_stateCensusAnalysis = new StateCensusAnalyser();
            if (obj_stateCensusAnalysis.CheckIfHeaderSame(fileHeader, inputHeader))
            {
                return true;
            }
            return false;
        }

        /// <summary>7) Method to show data in the ArrayList </summary>
        /// <param name="dataList"></param>
        public void ShowRecords(string filePath)
        {
            var dataList = ReadData(filePath, false);
            foreach (dynamic record in dataList.Item4)
            {
                foreach (var data in record)
                {
                    Console.Write(data + " ");
                }
                Console.WriteLine();
            }
        }

        public dynamic SortBySecondaryList(string firstFilePath1, int dependentColNumFile1, string secondFilePath, int dependentColNumFile2, int secondFileSortColNum = 0)
        {
             // decrease column number by 1 convert to index
             dependentColNumFile1--;
            dependentColNumFile2--;
            // if column number < 0  => initialize to 0
            if (dependentColNumFile1 < 0) dependentColNumFile1 = 0;
            if (dependentColNumFile2 < 0) dependentColNumFile2 = 0;
            // get data in List form
            var result1 = ReadFileData(firstFilePath1, "StateCensusPrototype");
            var result2 = ReadFileData(secondFilePath, "StateCodeModelClass", false, true, secondFileSortColNum);
            List<StateCensusPrototype> list1 = result1.Item4;
            List<StateCodePrototype> list2 = result2.Item4;
            // sort the first file list by using second file list   
            List<StateCensusPrototype> sortedList = new List<StateCensusPrototype>();
            sortedList.Add(new StateCensusPrototype(result1.Item1));
            foreach (dynamic list2Emlement in list2)
            {
                foreach (dynamic list1Element in list1)
                {
                    if (list1Element[dependentColNumFile1].CompareTo(list2Emlement[dependentColNumFile2]) == 0)
                    {
                        sortedList.Add(list1Element);
                        break;
                    }
                }
            }
            //Convert sorted data into 
            var sortedListInJson = JsonSerializer.Serialize(sortedList);
            return sortedListInJson;
        }
    }//end:class CsvDataFactory
}