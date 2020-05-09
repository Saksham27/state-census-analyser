using System;
using System.Collections;
using NUnit.Framework;
using Newtonsoft.Json;
using CensusAnalyser;

namespace CensusAnalyserTest
{
    [TestFixture]
    class TestCsvDataBuilder
    {
        readonly CsvDataFactory csvDataFactory = new CsvDataFactory();
        readonly string stateCensusDataPath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.csv";

        //readonly string stateCodeDataPath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.csv";
        readonly string[] userHeaderStateCensus = { "State", "Population", "AreaInSqKm", "DensityPerSq" }; //  DensityPerSqKm->DensityPerSq

        [Test]
        public void GivenStateCensusData_WhenCountTheNumberOfRecords_ShouldReturnTotalRecordsNumber()
        {
            int count = csvDataFactory.getNumberofRecords(stateCensusDataPath);
            Assert.AreEqual(29, count);
        }

        [Test]
        public void GivenCensusData_WhenReadDelimeter_ShouldReturnDelimeterOfFile()
        {
            char delimeter = csvDataFactory.GetDelimeter(stateCensusDataPath);
            Assert.AreEqual(',', delimeter);
        }

        [Test]
        public void GivenCesusDataAndHeader_WhenCompareHeaders_ReturnBoolienValue()
        {
            string[] userHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqkm" };
            var result = csvDataFactory.CheckHeaders(stateCensusDataPath, userHeader);
            Assert.IsTrue(result);
        }

        [Test]
        public void GivenCensusData_WhenReadAndSort_ReturnSortedJsonFile_CheckFirstState()
        {
            dynamic sortedJsonFile = csvDataFactory.DataInJsonForm(stateCensusDataPath);
            dynamic sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            var firstRecord = sortedList[1];
            string firstState = firstRecord[0];
            Assert.AreEqual("andhra pradesh", firstState.ToLower());
        }

        [Test]
        public void GivenCensusData_WhenReadAndSort_ReturnSortedJsonFile_CheckLastState()
        {
            dynamic sortedJsonFile = csvDataFactory.DataInJsonForm(stateCensusDataPath);
            dynamic sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            var lastRecord = sortedList.Last;
            string lastState = lastRecord[0];
            Assert.AreEqual("west bengal", lastState.ToLower());
        }

        [Test]
        public void GiveCensusData_WhenReadRecords_PrintData()
        {
            csvDataFactory.ShowRecords(stateCensusDataPath);
        }

        [Test]
        public void GiveCensusHeader_WhenCompare_ReturnBoolvalue()
        {
            Assert.IsFalse(csvDataFactory.CheckHeaders(stateCensusDataPath, userHeaderStateCensus));
        }
    }//end:class TestCsvDataBuilder
}//end:namespace TestCensusAnalysis