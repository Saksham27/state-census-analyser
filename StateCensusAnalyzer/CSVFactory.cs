﻿using System;
using System.Collections.Generic;
using System.Text;
using static CensusAnalyser.CSVStatesDao;
using static CensusAnalyser.StateCensusAnalyserDao;

namespace CensusAnalyser
{
    public class CSVFactory
    {
        // Method to creating instance of StateCensusAnalyser
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