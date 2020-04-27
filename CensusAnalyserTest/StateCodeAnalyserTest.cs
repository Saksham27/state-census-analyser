using System;
using System.Collections.Generic;
using System.Text;
using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    [TestFixture]
    class StateCodeAnalyserTest
    {
        /// <summary>
        /// Test to check number of records
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
    }//// end : class StateCodeAnalyserTest
}//// end : namespace CensusAnalyserTest
