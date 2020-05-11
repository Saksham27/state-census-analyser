﻿using System;

namespace CensusAnalyser
{
    public class CSVStatesDao : ICSVBuilder
    {
        public static string stateCodePath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCode.csv";
        // variables declaration
        public string stateCensusFilePath;
        public char delimeter;
        public string[] header;
        public string givenPath;

        // Default Constructor
        public CSVStatesDao()
        {
        }

        // CsvStates parameterised constructor
        public CSVStatesDao(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        // Delegate is a reference type variable that hold the refenence to a method
        public delegate object CsvStateCodeDataDao(string[] header, char delimeter, string givenPath);

        /// <CsvStateCodeReadRecord>
        /// Creating object of class 'StateCensusAnalyser' as 'stateCodePathObject,
        /// return object is returnrd to test case.
        /// </CsvStateCodeReadRecord>
        /// <returns></returnObject>
        public static object CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath)
        {
            CsvStateCensusReadRecord stateCodePathObject = new CsvStateCensusReadRecord(stateCodePath);
            var returnObject = stateCodePathObject.ReadRecords(header, delimeter, givenPath);
            return returnObject;
        }

        object ICSVBuilder.CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }

        object ICSVBuilder.CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }

        object ICSVBuilder.CsvUSCensusDataReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }
    }//End of class CsvStates    
}// End of namespace CensusAnalyserProblem