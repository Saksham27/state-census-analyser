using System;
using System.Collections.Generic;
using System.Text;
using CensusAnalyser;
using NUnit.Framework;
using StateCensusAnalyzer;

namespace CensusAnalyserTest
{
    [TestFixture]
    class StateCodeAnalyserTest
    {
        /// <summary>
        /// Test Case 2.1 : Test to check number of records
        /// </summary>
        [Test]
        public void TestNumberOfRecords()
        {
            // create object to StateCodeAnalysis 
            StateCodeAnalyser stateCodeAnalyser = new StateCodeAnalyser();
            // call read records method to load and read file
            stateCodeAnalyser.ReadRecords();
            // call numberof records method to get total records number
            var records = stateCodeAnalyser.NumberOfRecords();
            Assert.AreEqual(37, records);
        }//// end : public void TestNumberOfRecords()

        /// <summary>
        /// Test Case 2.2 : given wrong .csv file path , read records should throw exception
        /// </summary>
        [Test]
        public void GivenCsvFilePAth_WhenImproper_ShouldThrowException()
        {
            string expected = "Wrong file path or file missing";
            StateCodeAnalyser stateCodeAnalyser = new StateCodeAnalyser(@"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateData.csv");
            ExceptionFileNotFound actual = Assert.Throws<ExceptionFileNotFound>(() => stateCodeAnalyser.ReadRecords());
            Assert.AreEqual(expected, actual.Message);
        }
    }//// end : class StateCodeAnalyserTest
}//// end : namespace CensusAnalyserTest
