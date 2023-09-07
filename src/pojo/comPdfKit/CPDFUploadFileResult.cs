namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFUploadFileResult
    {
        public string FileKey { get; set; }
        public string FileUrl { get; set; }

        public override string ToString()
        {
            return "UploadFileResult{" +
                   "FileKey='" + FileKey + '\'' +
                   ", FileUrl='" + FileUrl + '\'' +
                   '}';
        }
    }
}