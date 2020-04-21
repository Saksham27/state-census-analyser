using NUnit.Framework;
using CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MatchNumberOfRecords()
        {
            int expected = 27;
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.csv");
            int actual = stateCensusAnalyser.ReadRecords();
            Assert.AreEqual(expected, actual);
        }
    }
}