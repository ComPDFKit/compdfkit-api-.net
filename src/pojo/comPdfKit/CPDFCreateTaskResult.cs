namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFCreateTaskResult
    {
        public string TaskId { get; set; }

        public override string ToString()
        {
            return "CreateTaskResult{" +
                   "TaskId='" + TaskId + '\'' +
                   '}';
        }
    }
}