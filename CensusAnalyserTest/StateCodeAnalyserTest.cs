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
        /// creating object for StateCodeAnalyser
        /// </summary>
        readonly StateCodeAnalyser stateCodeAnalyser = new StateCodeAnalyser();
        /// <summary>
        /// Setup method
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // setting filePath property
            stateCodeAnalyser.FilePath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCode.csv";
            // setting NumberOfRecords property
            stateCodeAnalyser.NumberOfRecords = 0;
        }

        /// <summary>
        /// Test Case 2.1 : Test to check number of records
        /// </summary>
        [Test]
        public void TestNumberOfRecords()
        {
            // call read records method to load and read file
            stateCodeAnalyser.ReadRecords();
            // call numberof records method to get total records number
            int records = stateCodeAnalyser.NumberOfRecords;
            Assert.AreEqual(37, records);
        }//// end : public void TestNumberOfRecords()

        /// <summary>
        /// Test Case 2.2 : given wrong .csv file path , read records should throw exception
        /// </summary>
        [Test]
        public void GivenCsvFilePAth_WhenImproper_ShouldThrowException()
        {
            string expected = "Wrong file path or file missing";
            stateCodeAnalyser.FilePath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateData.csv";
            ExceptionFileNotFound actual = Assert.Throws<ExceptionFileNotFound>(() => stateCodeAnalyser.ReadRecords());
            Assert.AreEqual(expected, actual.Message);
        }

        /// <summary>
        /// Test Case 2.3 : given wrong csv file type , read records should throw exception
        /// </summary>
        [Test]
        public void GivenCsvFilePath_WhenTypeImproper_ShouldThrowException()
        {
            string expected = "file type is incorrect";
            stateCodeAnalyser.FilePath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCode.txt";
            ExceptionWrongFile actual = Assert.Throws<ExceptionWrongFile>(() => stateCodeAnalyser.ReadRecords());
            Assert.AreEqual(expected, actual.Message);
        }

        /// <summary>
        /// Test Case 2.4 : given wrong csv file type delimeter , read records should throw exception
        /// </summary>
        [Test]
        public void GivenCsvFilePath_WhenTypeDelimeterImproper_ShouldThrowException()
        {
            string expected = "File has different delimeter than given";
            ExceptionWrongDelimeter actual = Assert.Throws<ExceptionWrongDelimeter>(() => stateCodeAnalyser.ReadRecords(null, '.'));
            Assert.AreEqual(expected, actual.Message);
        }

        /// <summary>
        /// Test Case 1.5 : given wrong csv file headers, read records should throw exception
        /// </summary>
        [Test]
        public void GivenCsvHeaders_WhenImproper_ShouldThrowException()
        {
            string expected = "Headers of file are not valid";
            string[] header = { "SrNo", "State", "Name", "TIN", "Statecode" };
            ExceptionInvalidHeaders actual = Assert.Throws<ExceptionInvalidHeaders>(() => stateCodeAnalyser.ReadRecords(header, ','));
            Assert.AreEqual(expected, actual.Message);
        }
    }//// end : class StateCodeAnalyserTest
}//// end : namespace CensusAnalyserTest
