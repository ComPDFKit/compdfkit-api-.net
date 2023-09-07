using System;

namespace ComPDFKit.exception
{
    public class CPDFException : System.Exception
    {
        private string code;

        public CPDFException() : base()
        {
        }

        public CPDFException(string message) : base(message)
        {
        }

        public CPDFException(string code, string message) : base(message)
        {
            this.code = code;
        }

        public CPDFException(string message, Exception cause) : base(message, cause)
        {
        }

        public CPDFException(Exception cause) : base(cause.Message, cause)
        {
        }

        public string GetCode()
        {
            return code;
        }

        public void SetCode(string code)
        {
            this.code = code;
        }
    }
}
