namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFTool {
        private string sourceTypeName;
        private string targetTypeName;
        private string executeTypeUrl;

        public string GetSourceTypeName() {
            return sourceTypeName;
        }

        public void SetSourceTypeName(string sourceTypeName) {
            this.sourceTypeName = sourceTypeName;
        }

        public string GetTargetTypeName() {
            return targetTypeName;
        }

        public void SetTargetTypeName(string targetTypeName) {
            this.targetTypeName = targetTypeName;
        }

        public string GetExecuteTypeUrl() {
            return executeTypeUrl;
        }

        public void SetExecuteTypeUrl(string executeTypeUrl) {
            this.executeTypeUrl = executeTypeUrl;
        }
        
        public override string ToString() {
            return "Tool{" +
                   "sourceTypeName='" + sourceTypeName + '\'' +
                   ", targetTypeName='" + targetTypeName + '\'' +
                   ", executeTypeUrl='" + executeTypeUrl + '\'' +
                   '}';
        }
    }
}