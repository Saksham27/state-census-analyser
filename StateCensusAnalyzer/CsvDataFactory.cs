using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    /// <summary> Class Structure </summary>
    /// <InhetitedClass>CsvDataBuilder</InhetitedClass>
    /// <Constructors> Default constructor only</Constructors>
    /// <InheritedMethods>
    /// 1.public dynamic ReadData(string filePath,bool sorting=false,int sortColoumnNum=1) : 
    ///     -> returns a tuple(string[],int,char,ArrayList/JSON):(fileHeader,numberOfRecords,fileDelimeter,fileData)
    /// </InheritedMethods>
    /// <classMethods>
    /// 1.public dynamic DataInJsonForm(string filePath)
    /// 2.public dynamic DataInArrayListForm(string filePath) 
    /// 3.public dynamic GetHeader(string filePath) 
    /// 4.public dynamic GetDelimeter(string filePath)   
    /// 5.public int getNumberofRecords(string filePath)  
    /// 6.public bool CheckHeaders(string filePath, dynamic inputHeader)
    /// 7.public void ShowRecords(string filePath)
    /// </classMethods>
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
    }//end:class CsvDataFactory
}