using NUnit.Framework;
using CensusAnalyser;
using System.Runtime.CompilerServices;
using System;

namespace CensusAnalyserTest
{
    public class Tests
    {
        const string filePath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.csv";
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test Case 1.1 : Check to ensure no of records matches
        /// </summary>
        [Test]
        public void MatchNumberOfRecords()
        {
            int expected = 29;
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(filePath);
            stateCensusAnalyser.ReadRecords();
            int actual = stateCensusAnalyser.GetNoOfRecords();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenCsvFilePAth_WhenImproper_ShouldThrowException()
        {
            string expected = "Wrong file path or file missing";
            try
            {
                StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateData.csv");
                stateCensusAnalyser.ReadRecords();
            }
            catch (Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}