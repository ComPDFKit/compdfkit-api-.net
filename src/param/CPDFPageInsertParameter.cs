namespace ComPDFKit.param
{
    /// <summary>
    /// Form recognition parameter
    /// </summary>
    public class CPDFPageInsertParameter : CPDFFileParameter
    {
        /// <summary>
        /// Page number
        /// </summary>
        public string TargetPage { get; set; }

        /// <summary>
        /// Page width (default 595)
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// Page height (842)
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Number of pages to insert (default 1)
        /// </summary>
        public string Number { get; set; }
    }
}