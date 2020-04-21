using System;
using System.Collections.Generic;
using System.Text;

namespace StateCensusAnalyzer
{
    /// <summary>
    /// 
    /// </summary>
    class CensusAnalyserException : Exception
    {
        public enum CensusExceptionType
        {
            fileNotFound, incorrectType, incorrectDelimeter
        }

        //variables
        CensusExceptionType exceptionType;

        /// <summary>
        /// exception method
        /// </summary>
        /// <param name="exceptionType"> exception type </param>
        /// <param name="exceptionMessage"> exception message </param>
        public CensusAnalyserException(CensusExceptionType exceptionType, string exceptionMessage) : base(exceptionMessage)
        {
            this.exceptionType = exceptionType;
        }

    }
}
