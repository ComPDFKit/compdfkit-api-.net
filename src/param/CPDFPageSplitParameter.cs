using System.Collections.Generic;

namespace ComPDFKit.param
{
    /// <summary>
    /// Page split parameter
    /// </summary>
    public class CPDFPageSplitParameter : CPDFFileParameter
    {
        /// <summary>
        /// Page number collection, page number starts from 1, for example: 2-4 1,2,3 1-3,5 (this example is divided into 3 files, separated by spaces)
        /// </summary>
        public List<string> PageOptions { get; set; }
    }
}