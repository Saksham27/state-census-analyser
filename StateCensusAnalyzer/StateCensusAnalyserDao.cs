using LumenWorks.Framework.IO.Csv;
using CensusAnalyser;
using System;
using System.Dynamic;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CensusAnalyser
{ 
    public class StateCensusAnalyserDao : ICSVBuilder
    {
        public static string stateCensusPath = @"C:\Users\Saksham\source\repos\StateCensusAnalyzer\StateCensusData.csv";
        // variables declaration
        public string stateCensusFilePath { get; set; }
        public char delimeter { get; set; }
        public string[] header { get; set; }
        public string givenPath { get; set; }

        //end: static void Main(string[] args)

        // Default Constructor
        public StateCensusAnalyserDao()
        {
        }

        // CsvStates parameterised constructor  
        public StateCensusAnalyserDao(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        // Delegate is a reference type variable that hold the refenence to a method
        public delegate object CsvStateCensusDataDao(string[] header, char delimeter, string givenPath);

        /// <CsvStateCodeReadRecord>
        /// Creating object of class 'CensusReadRecord' as 'stateCodePathObject,
        /// return object is returnrd to test case.
        /// </CsvStateCodeReadRecord>
        /// <returns></returnObject>
        public static object CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath)
        {
            CsvStateCensusReadRecord stateCensusPathObject = new CsvStateCensusReadRecord(stateCensusPath);
            var returnObject = stateCensusPathObject.ReadRecords(header, delimeter, givenPath);
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
    }//End of class StateCensusAnalyser           
}//end:namespace CensusAnalysis

