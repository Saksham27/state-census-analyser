using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusPrototype
    {
        public string _State { get; set; }
        public string _Population { get; set; }
        public string _AreaInSqKm { get; set; }
        public string _DensityPerSqKm { get; set; }

        // Indexer to access fields by using index
        public string this[int index]
        {
            get
            {
                if (index == 0) return _State;
                if (index == 1) return _Population;
                if (index == 2) return _AreaInSqKm;
                if (index == 3) return _DensityPerSqKm;
                return default;
            }
            set
            {
                if (index == 0) _State = value;
                if (index == 1) _Population = value;
                if (index == 2) _AreaInSqKm = value;
                if (index == 3) _DensityPerSqKm = value;
            }
        }
        /// <summary> Constructor to intilize fields</summary>
        /// <param name="data"></param>
        public StateCensusPrototype(string[] data)
        {
            this._State = data[0];
            this._Population = data[1];
            this._AreaInSqKm = data[2];
            this._DensityPerSqKm = data[3];
        }
    }

}
