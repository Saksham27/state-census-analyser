using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class StateCodePrototype
    {
        public string SrNo { get; set; }
        public string State { get; set; }
        public int Name { get; set; }
        public string TIN { get; set; }
        public string _SrNo { get; set; }
        public string _State { get; set; }
        public string _Name { get; set; }
        public string _TIN { get; set; }

        // Indexer to access fields by using index
        public string this[int index]
        {
            get
            {
                if (index == 0) return _SrNo;
                if (index == 1) return _State;
                if (index == 2) return _Name;
                if (index == 3) return _TIN;
                return default;
            }
            set
            {
                if (index == 0) _SrNo = value;
                if (index == 1) _State = value;
                if (index == 2) _Name = value;
                if (index == 3) _TIN = value;
            }
        }

        /// <summary> Constructor to initlize fields</summary>
        /// <param name="data"></param>
        public StateCodePrototype(string[] data)
        {
            this._SrNo = data[0];
            this._State = data[1];
            this._Name = data[2];
            this._TIN = data[3];
        }
    }
}
