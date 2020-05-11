using System;
using System.Collections.Generic;
using System.Text;
using static CensusAnalyser.CSVStates;
using static CensusAnalyser.StateCensusAnalyser;

namespace CensusAnalyser
{
    public class CSVFactory
    {
        // Method to creating instance of StateCensusAnalyser
        public static CsvStateCensusData DelegateOfStateCensusAnalyser()
        {
            StateCensusAnalyser csvStateCensus = InstanceOfStateCensusAnalyser();
            CsvStateCensusData getStateCensus = new CsvStateCensusData(StateCensusAnalyser.CsvStateCensusReadRecord);
            return getStateCensus;
        }

        // Method to creating instance of CsvStates
        public static CsvStateCodeData DelegateOfCsvStates()
        {
            CSVStates csvStateData = InstanceOfCsvStates();
            CsvStateCodeData getStateData = new CsvStateCodeData(CSVStates.CsvStateCodeReadRecord);
            return getStateData;
        }

        private static CSVStates InstanceOfCsvStates()
        {
            return new CSVStates();
        }

        private static StateCensusAnalyser InstanceOfStateCensusAnalyser()
        {
            return new StateCensusAnalyser();
        }
    }
}