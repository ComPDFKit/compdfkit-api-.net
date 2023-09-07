namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFToolResultItem
    {
        public string SourceTypeName { get; set; }
        public string ExecuteTypeUrl { get; set; }
        public string TargetTypeName { get; set; }

        public override string ToString()
        {
            return $"QueryToolResultItem{{sourceTypeName='{SourceTypeName}', executeTypeUrl='{ExecuteTypeUrl}', targetTypeName='{TargetTypeName}'}}";
        }
    }
}