using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusObject
    {
        public string State { get; set; }
        public string Population { get; set; }
        public string AreaInSqKm { get; set; }
        public string DensityPerSqKm { get; set; }
    }

    public class StateCensusObjectRoot
    {
        public List<StateCensusObject> resultList { get; set; }
        public int resultSize { get; set; }
        public string pageIndex { get; set; }
    }
}
