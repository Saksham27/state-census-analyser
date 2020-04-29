namespace CensusAnalyserTest
{
    using CensusAnalyser;
    using NUnit.Framework;
    using StateCensusAnalyzer;

    /// <summary>
    /// class that contains all the unit test methods
    /// </summary>
    public class StateCensusAnalyserTest
    {
        readonly StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
        /// <summary>
        /// Setup method
        /// </summary>
        [SetUp]
        public void Setup()
        {
            stateCensusAnalyser.FilePath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.csv";
            stateCensusAnalyser.NumberOfRecords = 0;
        }
        
        /// <summary>
        /// Test Case 1.1 : Check to ensure no of records matches
        /// </summary>
        [Test]
        public void MatchNumberOfRecords()
        {
            int expected = 29;
            stateCensusAnalyser.ReadRecords();
            int actual = stateCensusAnalyser.GetNumberOfRecords();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Case 1.2 : given wrong .csv file path , read records should throw exception
        /// </summary>
        [Test]
        public void GivenCsvFilePAth_WhenImproper_ShouldThrowException()
        {
            string expected = "Wrong file path or file missing";
            stateCensusAnalyser.FilePath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateData.csv";
            ExceptionFileNotFound actual = Assert.Throws<ExceptionFileNotFound>(() => stateCensusAnalyser.ReadRecords());
            Assert.AreEqual(expected, actual.Message);
        }

        /// <summary>
        /// Test Case 1.3 : given wrong csv file type , read records should throw exception
        /// </summary>
        [Test]
        public void GivenCsvFilePath_WhenTypeImproper_ShouldThrowException()
        {
            string expected = "file type is incorrect";
            stateCensusAnalyser.FilePath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.txt";
            ExceptionWrongFile actual = Assert.Throws<ExceptionWrongFile>(() => stateCensusAnalyser.ReadRecords());
            Assert.AreEqual(expected, actual.Message);
        }

        /// <summary>
        /// Test Case 1.4 : given wrong csv file type delimeter , read records should throw exception
        /// </summary>
        [Test]
        public void GivenCsvFilePath_WhenTypeDelimeterImproper_ShouldThrowException()
        {
            string expected = "File has different delimeter than given";
            ExceptionWrongDelimeter actual = Assert.Throws<ExceptionWrongDelimeter>(() => stateCensusAnalyser.ReadRecords(null,'.'));
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
            ExceptionInvalidHeaders actual = Assert.Throws<ExceptionInvalidHeaders>(() => stateCensusAnalyser.ReadRecords(header,','));
            Assert.AreEqual(expected, actual.Message);
        }
    } ////end : public class StateCensusAnalyserTest
} ////end : namespace CensusAnalyserTest