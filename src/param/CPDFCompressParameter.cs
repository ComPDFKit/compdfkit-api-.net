namespace ComPDFKit.param
{
    /// <summary>
    /// Compress PDF file
    /// </summary>
    public class CPDFCompressParameter : CPDFFileParameter
    {
        /// <summary>
        /// Compressed document quality in the range 0-100, e.g. 50
        /// </summary>
        public string Quality { get; set; }
    }
}