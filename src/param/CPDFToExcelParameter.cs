namespace ComPDFKit.param
{
 /// <summary>
 /// PDF to Excel parameter
 /// </summary>
    public class CPDFToExcelParameter : CPDFFileParameter
    {
        public static readonly string IS_CONTAIN_ANNOT = "1";
        public static readonly string NOT_IS_CONTAIN_ANNOT = "0";
        public static readonly string IS_CONTAIN_IMG = "1";
        public static readonly string NOT_IS_CONTAIN_IMG = "0";

        /// <summary>
        /// extractContentOptions (1: OnlyText, 2: OnlyTable, 3: AllContent)
        /// </summary>
        public string ContentOptions { get; set; }

        /// <summary>
        /// createWorksheetOptions (1: ForEachTable, 2: ForEachPage, 3: ForTheDocument)
        /// </summary>
        public string WorksheetOptions { get; set; }

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