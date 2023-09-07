namespace ComPDFKit.param
{
    /// <summary>
    /// PDF to PPT parameter
    /// </summary>
    public class CPDFToWordParameter : CPDFFileParameter
    {
        public static readonly string IS_CONTAIN_ANNOT = "1";
        public static readonly string NOT_IS_CONTAIN_ANNOT = "0";
        public static readonly string IS_CONTAIN_IMG = "1";
        public static readonly string NOT_IS_CONTAIN_IMG = "0";
        public static readonly string IS_FLOW_LAYOUT = "1";
        public static readonly string NOT_IS_FLOW_LAYOUT = "0";

        /// <summary>
        /// Whether to include annotations (1: yes, 0: no)
        /// </summary>
        public string IsContainAnnot {get; set;}

        /// <summary>
        /// Whether to include pictures (1: yes, 0: no)
        /// </summary>
        public string IsContainImg {get; set;}

        /// <summary>
        /// Whether to include comments (1: Yes, 0: No)
        /// </summary>
        public string IsFlowLayout {get; set;}
        
    }
}