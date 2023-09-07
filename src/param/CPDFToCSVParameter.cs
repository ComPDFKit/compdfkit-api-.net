namespace ComPDFKit.param
{
    /// <summary>
    /// PDF to CSV parameter
    /// </summary>
    public class CPDFToCSVParameter : CPDFFileParameter
    {
        public static readonly string IS_CSV_MERGE = "1";
        public static readonly string NOT_IS_CSV_MERGE = "0";

        /// <summary>
        /// Whether to merge CSV (1: Yes, 0: No)
        /// </summary>
        public string IsCsvMerge { get; set; }
    }
}