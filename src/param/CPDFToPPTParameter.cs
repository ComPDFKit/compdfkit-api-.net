namespace ComPDFKit.param
{
    /// <summary>
    /// PDF to PPT parameter
    /// </summary>
    public class CPDFToPPTParameter : CPDFFileParameter
    {
        public static readonly string IS_CONTAIN_ANNOT = "1";
        public static readonly string NOT_IS_CONTAIN_ANNOT = "0";
        public static readonly string IS_CONTAIN_IMG = "1";
        public static readonly string NOT_IS_CONTAIN_IMG = "0";

        /// <summary>
        /// Whether to include annotations (1: yes, 0: no) Default no
        /// </summary>
        public string IsContainAnnot {get;set;}

        /// <summary>
        /// Whether to include pictures (1: yes, 0: no) Default no
        /// </summary>
        public string IsContainImg {get;set;}
    }
}