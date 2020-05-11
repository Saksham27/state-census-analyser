using System;
using System.Collections.Generic;
using System.Text;
using static CensusAnalyser.CSVStatesDao;
using static CensusAnalyser.StateCensusAnalyserDao;
using static CensusAnalyser.USCensusDataDao;

namespace CensusAnalyser
{
    public class CSVFactory
    {
        /// <summary>
        /// Method to creating instance of StateCensusAnalyser
        /// Delegate is referance type variable that holds thr referance to the method.
        /// </summary>
        /// <returns></returns>

        public static CsvStateCensusDataDao DelegateOfStateCensusAnalyser()
        {
            StateCensusAnalyserDao csvStateCensus = InstanceOfStateCensusAnalyser();
            CsvStateCensusDataDao getStateCensus = new CsvStateCensusDataDao(StateCensusAnalyserDao.CsvStateCensusReadRecord);
            return getStateCensus;
        }

        
        // Method to creating instance of CsvStates
        public static CsvStateCodeDataDao DelegateOfCsvStates()
        {
            CSVStatesDao csvStateData = InstanceOfCsvStates();
            CsvStateCodeDataDao getStateData = new CsvStateCodeDataDao(CSVStatesDao.CsvStateCodeReadRecord);
            return getStateData;
        }

        // Method to creating instance of USCensusData
        public static CsvUSCensusDataDao DelegateOfUSCensusData()
        {
            USCensusDataDao csvUSData = InstanceOfUSCensusData();
            CsvUSCensusDataDao getUSData = new CsvUSCensusDataDao(USCensusDataDao.CsvUSCensusDataReadRecord);
            return getUSData;
        }   

        private static USCensusDataDao InstanceOfUSCensusData()
        {
            return new USCensusDataDao();
        }

        private static CSVStatesDao InstanceOfCsvStates()
        {
            return new CSVStatesDao();
        }

        private static StateCensusAnalyserDao InstanceOfStateCensusAnalyser()
        {
            return new StateCensusAnalyserDao();
        }
    }
}