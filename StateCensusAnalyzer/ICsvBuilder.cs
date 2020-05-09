using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    interface ICsvBuilder
    {
        public dynamic ReadData(string filePath, bool jsonForm = false, bool sorting = false, int sortColoumnNum = 0);
    } //// end : interface ICensusAnalysisCsv
}
