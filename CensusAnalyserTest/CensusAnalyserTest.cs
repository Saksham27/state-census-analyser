namespace CensusAnalyserTest
{
    using System;
    using CensusAnalyser;
    using NUnit.Framework;
    using static CensusAnalyser.StateCensusAnalyser;
    using static CensusAnalyser.CSVStates;



    /// <summary>
    /// class that contains all the unit test methods
    /// </summary>
    public class StateCensusAnalyserTest
    {
        //with NameSpace Assembly reference 
        // DeligateMethod -------Object-------Reference to delegate method
        readonly CsvStateCensusData stateCensus = CSVFactory.DelegateOfStateCensusAnalyser();
        readonly CsvStateCodeData stateCode = CSVFactory.DelegateOfCsvStates();

        public string stateCensusDataPath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.csv";
        public string stateCodePath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCode.csv";
        public string jsonPathstateCensus = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.json";
        public string jsonPathstateCode = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCode.json";
        [SetUp]
        public void Setup()
        {
        }

        /// <Test1 :CheckNumberOfRecordsMatches>
        /// #Creating object as a 'censusPath' of class 'StateCensusAnalyser'
        /// and getting path of 'StateCensusData.csv' file.
        /// #calling 'NumberOfRecords' method and getting numberOfRecords
        /// #matching expected records with numberOfRecords.
        /// </Test1 :CheckNumberOfRecordsMatches>
        [Test]
        public void CheckNumberOfRecordsMatches()
        {
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string path = stateCensusDataPath;
            var numberOfRecords = stateCensus(header, delimeter, path);
            Assert.AreEqual(29, numberOfRecords);
        }

        /// <Test2 :CheckIncorrectCSVFile>
        ///#Sent Incorrect CSV file name : 'StateCensusDataIncorrect.csv'
        ///#CSV File if incorrect Returns a custom Exception as "Invalid file"
        ///test case passes
        /// </Test2 :CheckIncorrectCSVFile>
        [Test]
        public void CheckIncorrectCSVFile()
        {
            string incorrectPath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusDataIncorrect.csv";
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            object exceptionMessage = stateCensus(header, delimeter, incorrectPath);
            Assert.AreEqual("Invalid file", exceptionMessage);
        }

        /// <Test3 :CheckCorrectDotExtensionFile>
        ///#Sent Incorrect Extension of file : '.txt'
        ///#CSV File if incorrect Returns a custom Exception as "Invalid Extension of file"
        ///test case passes
        /// </Test3 :CheckCorrectDotExtensionFile>
        [Test]
        public void CheckCorrectDotExtensionFile()
        {
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string inCorrectExtensionPath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.txt";
            object exceptionMessage = stateCensus(header, delimeter, inCorrectExtensionPath);
            Assert.AreEqual("Invalid Extension of file", exceptionMessage);
        }

        /// <Test4 :CheckInCorrectDelimeter>
        ///#Sent user delimeter : ';'
        ///#CSV File if incorrect Returns a custom Exception as "Incorrect Delimeter"
        ///test case passes
        /// </Test4 :CheckInCorrectDelimeter>
        [Test]
        public void CheckInCorrectDelimeter()
        {
            char userDelimeter = ';';
            string path = stateCensusDataPath;
            object exceptionMessage = stateCensus(null, userDelimeter, path);
            Assert.AreEqual("Incorrect Delimeter", exceptionMessage);
        }

        /// <Test5 :CheckInvalidHeader>
        ///#Sending inValid header[] 
        ///#Comparing with actual header of csv file and returning exception message
        ///message is same then, test case passes
        /// </Test5 :CheckInvalidHeader>
        [Test]
        public void CheckInvalidHeader()
        {
            string[] header = { "State", "InvalidHeader", "AreaInSqKm", "DensityPerSqKm" };
            char userDelimeter = ',';
            string path = stateCensusDataPath;
            object exceptionMessage = stateCensus(header, userDelimeter, path);
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }


        /// <Test6 :CheckNumberOfRecordsMatchesStateCode>
        /// #Creating object as a 'stateCodePath' of class 'CsvStates'
        /// and getting path of 'StateCode.csv' file.
        /// #calling 'NumberOfRecords' method and getting numberOfRecords
        /// #matching expected records with numberOfRecords.
        /// </Test6 :CheckNumberOfRecordsMatchesStateCode>
        [Test]
        public void CheckNumberOfRecordsMatchesStateCode()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "State", "TIN", "StateCode" };
            string path = stateCodePath;
            var numberOfRecords = stateCode(header, delimeter, path);
            Assert.AreEqual(37, numberOfRecords);
        }

        /// <Test7 :CheckIncorrectCSVFileStateCode>
        ///#Sent Incorrect CSV file name : 'StateCode.csv'
        ///#CSV File if incorrect Returns a custom Exception as "Invalid file"
        ///test case passes
        /// </Test7 :CheckIncorrectCSVFileStateCode>
        [Test]
        public void CheckIncorrectCSVFileStateCode()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "State", "PIN", "StateCode" };
            string path = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCodeIncorrect.csv";
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Invalid file", exceptionMessage);
        }

        /// <Test8 :CheckCorrectDotExtensionFileStateCode>
        ///#Sent Incorrect Extension of file : '.txt'
        ///#CSV File if incorrect Returns a custom Exception as "Invalid Extension of file"
        ///test case passes
        /// </Test8 :CheckCorrectDotExtensionFileStateCode>
        [Test]
        public void CheckCorrectDotExtensionFileStateCode()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "State", "PIN", "StateCode" };
            string path = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCode.txt";
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Invalid Extension of file", exceptionMessage);
        }

        /// <Test9 :CheckInCorrectDelimeterStateCode>
        ///#Sent user delimeter : ';'
        ///#CSV File if incorrect Returns a custom Exception as "Incorrect Delimeter"
        ///test case passes
        /// </Test9 :CheckInCorrectDelimeterStateCode>
        [Test]
        public void CheckInCorrectDelimeterStateCode()
        {
            char delimeter = ';';
            string[] header = { "SrNo", "State", "PIN", "StateCode" };
            string path = stateCodePath;
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Incorrect Delimeter", exceptionMessage);
        }

        /// <Test10 :CheckInvalidHeaderStateCode>
        ///#Sending inValid header[] 
        ///#Comparing with actual header of csv file and returning exception message
        ///message is same then, test case passes
        /// </Test10 :CheckInvalidHeaderStateCode>
        [Test]
        public void CheckInvalidHeaderStateCode()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "InvalidState", "PIN", "StateCode" };
            string path = stateCodePath;
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }

        /// <Test 11>
        ///  Test for StateCensuscsv and json path to add into json after sorting return return first state.
        /// </Test 11>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting_ReturnFirstState()
        {
            string expected = "Andhra Pradesh";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCensusPath, jsonPathstateCensus, "State");
            Assert.AreEqual(expected, lastValue);
        }
        /// <Test 12>
        /// Test for StateCensuscsv and json path to add into json after sorting return return last state.
        /// </Test 12>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting__ReturnLastState()
        {
            string expected = "West Bengal";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCensusPath, jsonPathstateCensus, "State");
            Assert.AreEqual(expected, lastValue);
        }

        /// <Test 13>
        ///  Test for StateCodeCsv and json path to add into json after sorting return return first stateCode.
        /// </Test 13>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting_ReturnFirstStateCode()
        {
            string expected = "AD";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCodePath, jsonPathstateCensus, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }

        /// <Test 14>
        ///  Test for StateCodeCsv and json path to add into json after sorting return return last stateCode.
        /// </Test 14>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting_ReturnLatStateCode()
        {
            string expected = "WB";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCodePath, jsonPathstateCensus, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }
    } ////end : public class StateCensusAnalyserTest
} ////end : namespace CensusAnalyserTest