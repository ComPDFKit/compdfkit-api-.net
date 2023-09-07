using System.Collections.Generic;

namespace ComPDFKit.param
{
    /// <summary>
    /// Rotate the page range of the document
    /// </summary>
    public class CPDFPageRotationParameter : CPDFFileParameter
    {
        /// <summary>
        /// Rotate the page range of the document, and the page number starts from 1.
        /// For example: 1,2,5-10 (required, the page number entered must be greater than 0 and cannot exceed the maximum page number of the document)
        /// </summary>
        public List<string> PageOptions { get; set; }

        /// <summary>
        /// The rotation angle (0, 90, 180, 270) rotates clockwise
        /// </summary>
        public string Rotation { get; set; }
    }
}