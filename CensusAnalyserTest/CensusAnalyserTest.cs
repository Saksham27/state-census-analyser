namespace CensusAnalyserTest
{
    using System;
    using CensusAnalyser;
    using NUnit.Framework;
    using static CensusAnalyser.StateCensusAnalyserDao;
    using static CensusAnalyser.CSVStatesDao;



    /// <summary>
    /// class that contains all the unit test methods
    /// </summary>
    public class StateCensusAnalyserTest
    {
        //with NameSpace Assembly reference 
        // DeligateMethod -------Object-------Reference to delegate method
        readonly CsvStateCensusDataDao stateCensus = CSVFactory.DelegateOfStateCensusAnalyser();
        readonly CsvStateCodeDataDao stateCode = CSVFactory.DelegateOfCsvStates();

        public string stateCensusDataPath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.csv";
        public string stateCensusDataPathIncorrectName = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusDataIncorrect.csv";
        public string stateCensusDataPathIncorrectExtension = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.txt";
        public string[] headerStateCensus = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
        public string[] headerStateCensusInvalid = { "State", "InvalidHeader", "AreaInSqKm", "DensityPerSqKm" };

        public string stateCodePath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCode.csv";
        public string stateCodePathIncorrectName = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCodeIncorrect.csv";
        public string stateCodePathIncorrectExtension = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.txt";
        public string[] headerStateCode = { "SrNo", "State", "TIN", "StateCode" };
        public string[] headerStateCodeInvalid = { "SrNo", "StateInvalid", "PIN", "StateCode" };

        // Correct and Incorrect Delimeter
        char delimeter = ',';
        char IncorrectDelimeter = ';';

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
            var numberOfRecords = stateCensus(headerStateCensus, delimeter, stateCensusDataPath);
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
            object exceptionMessage = stateCensus(headerStateCensus, delimeter, stateCensusDataPathIncorrectName);
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
            object exceptionMessage = stateCensus(headerStateCensus, delimeter, stateCensusDataPathIncorrectExtension);
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
            object exceptionMessage = stateCensus(headerStateCensus, IncorrectDelimeter, stateCensusDataPath);
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
            object exceptionMessage = stateCensus(headerStateCensusInvalid, delimeter, stateCensusDataPath);
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
            var numberOfRecords = stateCode(headerStateCode, delimeter, stateCodePath);
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
            object exceptionMessage = stateCode(headerStateCode, delimeter, stateCodePathIncorrectName);
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
            object exceptionMessage = stateCode(headerStateCode, delimeter, stateCodePathIncorrectExtension);
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
            object exceptionMessage = stateCode(headerStateCode, IncorrectDelimeter, stateCodePath);
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
            object exceptionMessage = stateCode(headerStateCodeInvalid, delimeter, stateCodePath);
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