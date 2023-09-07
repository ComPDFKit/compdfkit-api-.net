namespace ComPDFKit.param
{
    /// <summary>
    /// PDF to HTML parameter
    /// </summary>
    public class CPDFToHtmlParameter : CPDFFileParameter
    {
        public static readonly string IS_CONTAIN_ANNOT = "1";
        public static readonly string NOT_IS_CONTAIN_ANNOT = "0";
        public static readonly string IS_CONTAIN_IMG = "1";
        public static readonly string NOT_IS_CONTAIN_IMG = "0";

        public static readonly string SinglePage = "1";
        public static readonly string SinglePageNavigationByBookmarks = "2";
        public static readonly string MultiplePages = "3";
        public static readonly string MultiplePagesSplitByBookmarks = "4";

        /// <summary>
        /// pageOptions 1: SinglePage, 2: SinglePageNavigationByBookmarks, 3: MultiplePages, 4: MultiplePagesSplitByBookmarks
        /// </summary>
        public string PageOptions { get; set; }

        /// <summary>
        /// Whether to include annotations (1: yes, 0: no) Default no
        /// </summary>
        public string IsContainAnnot { get; set; }

        /// <summary>
        /// Whether to include pictures (1: yes, 0: no) Default no
        /// </summary>
        public string IsContainImg { get; set; }
    }
}