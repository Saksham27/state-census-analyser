namespace CensusAnalyser
{
    using System;

    public class ExceptionFileNotFound : Exception
    {
        public StateCensusException FileFoundException;

        /// <summary>
        /// Constructor to initlize wrong file exception
        /// </summary>
        /// <param name="exception"> exception type </param>
        /// <param name="exceptionMessage"> message that passed to base Exception class </param>
        public ExceptionFileNotFound(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.FileFoundException = exception;
        } ////end : public ExceptionFileNotFound(string exception, string exceptionMessage) : base(exceptionMessage)
    } ////end : public class ExceptionFileNotFound : Exception

    public class ExceptionWrongFile : Exception
    {
        public StateCensusException WrongFileException;       
        
        /// <summary>
        /// Constructor to initilize wrong_file_excep
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="exceptionMessage"> message that passed to base Exception class </param>
        public ExceptionWrongFile(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.WrongFileException = exception;
        } ////end : public ExceptionWrongFile(string exception, string exceptionMessage) : base(exceptionMessage)
    } ////end : public class ExceptionWrongFile : Exception

    public class ExceptionWrongDelimeter : Exception
    {
        public StateCensusException WrongDelimeter;  
        /// <summary>
        /// Constructor to initlize wrong_delimeter variable
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="exceptionMessage"></param>
        public ExceptionWrongDelimeter(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.WrongDelimeter = exception;
        } ////end : public ExceptionWrongDelimeter(string exception, string exceptionMessage) : base(exceptionMessage)
    } ////end : public class ExceptionWrongDelimeter : Exception

    public class ExceptionInvalidHeaders : Exception
    {
        public StateCensusException InvalidHeaders;
        /// <summary>
        /// Constructor to initlize invalid headers variable
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="exceptionMessage"></param>
        public ExceptionInvalidHeaders(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.InvalidHeaders = exception;
        }
    }
} ////end : namespace StateCensusAnalyzer
