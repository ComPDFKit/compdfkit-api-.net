namespace ComPDFKit.param
{
    /// <summary>
    /// PDF to PPT parameter
    /// </summary>
    public class CPDFToPngParameter : CPDFFileParameter
    {
        /// <summary>
        /// Value range 72-1500 (default 300)
        /// </summary>
        public string ImgDpi { get; set; }
    }
}