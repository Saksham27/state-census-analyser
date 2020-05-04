using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    interface ICsvBuilder
    {
        public dynamic ReadData(string filePath);
    } //// end : interface ICensusAnalysisCsv
}
