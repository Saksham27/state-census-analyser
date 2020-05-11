using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public interface ICSVBuilder
    {
        object CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath);
        object CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath);
    } //// end : interface ICsvBuilder
}
