using System;
using System.Collections.Generic;
using ComPDFKit.constant;
using Newtonsoft.Json;

namespace ComPDFKit.pojo
{
    public class CPDFResultMap<T>
    {
        private string Code { get; set; }
        private string Msg { get; set; }
        private T Result { get; set; }

        public CPDFResultMap()
        {
            Code = CPDFConstant.SUCCESS_CODE;
            Msg = CPDFConstant.RESULT_SUCCESS;
        }

        public CPDFResultMap(string code, string msg)
        {
            Code = code;
            Msg = msg;
        }

        public CPDFResultMap(string code, string msg, T result) : this(code, msg)
        {
            Result = result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;

            CPDFResultMap<T> resultMap = (CPDFResultMap<T>)obj;

            return Code == resultMap.Code &&
                   Msg == resultMap.Msg &&
                   EqualityComparer<T>.Default.Equals(Result, resultMap.Result);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Code, Msg, Result).GetHashCode();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        [JsonIgnore]
        public bool IsSuccess => Code == CPDFConstant.SUCCESS_CODE;
    }
}