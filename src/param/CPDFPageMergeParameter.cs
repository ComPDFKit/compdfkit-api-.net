using System.Collections.Generic;

namespace ComPDFKit.param
{
    /// <summary>
    /// Merge the page range of the document
    /// </summary>
    public class CPDFPageMergeParameter : CPDFFileParameter
    {
        /// <summary>
        /// Merge the page range of the document, the page number starts from 1.
        /// For example: 1,2,4,6,9-11 (if you do not enter all pages by default, the page number entered cannot exceed the maximum page number of the document)
        /// </summary>
        public List<string> PageOptions { get; set; }
    }
}