using System.Collections.Generic;

namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFTaskRecordsResult
    {
        public int Total { get; set; }
        public int Current { get; set; }
        public int Pages { get; set; }
        public int Size { get; set; }
        public bool OptimizeCountSql { get; set; }
        public List<CPDFRecordsItem> Records { get; set; }
        public object MaxLimit { get; set; }
        public bool SearchCount { get; set; }
        public List<object> Orders { get; set; }
        public object CountId { get; set; }

        public override string ToString()
        {
            return "CPDFTaskRecordsResult{" +
                   "Total=" + Total +
                   ", Current=" + Current +
                   ", Pages=" + Pages +
                   ", Size=" + Size +
                   ", OptimizeCountSql=" + OptimizeCountSql +
                   ", Records=" + Records +
                   ", MaxLimit=" + MaxLimit +
                   ", SearchCount=" + SearchCount +
                   ", Orders=" + Orders +
                   ", CountId=" + CountId +
                   '}';
        }
    }
}