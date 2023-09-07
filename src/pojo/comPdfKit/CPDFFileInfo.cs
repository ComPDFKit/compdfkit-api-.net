using Newtonsoft.Json;

namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFFileInfo
    {
        /**
         * file unique identifier
         */
        [JsonProperty ("fileKey")]
        public string FileKey { get; set; }

        /**
         * taskId
         */
        [JsonProperty ("taskId")]
        public string TaskId { get; set; }

        /**
         * fileName
         */
        [JsonProperty ("fileName")]
        public string FileName { get; set; }

        /**
         * fileUrl
         */
        [JsonProperty ("fileUrl")]
        public string FileUrl { get; set; }

        /**
         * downloadUrl
         */
        [JsonProperty ("downloadUrl")]
        public string DownloadUrl { get; set; }

        /**
         * sourceType
         */
        [JsonProperty ("sourceType")]
        public string SourceType { get; set; }

        /**
         * targetType
         */
        [JsonProperty ("targetType")]
        public string TargetType { get; set; }

        /**
         * fileSize
         */
        [JsonProperty ("fileSize")]
        public string FileSize { get; set; }

        /**
         * convertSize
         */
        [JsonProperty ("convertSize")]
        public string ConvertSize { get; set; }

        /**
         * convertTime
         */
        [JsonProperty ("convertTime")]
        public string ConvertTime { get; set; }

        /**
         * status
         */
        [JsonProperty ("status")]
        public string Status { get; set; }

        /**
         * failureCode
         */
        [JsonProperty ("failureCode")]
        public string FailureCode { get; set; }

        /**
         * failureReason
         */
        [JsonProperty ("failureReason")]
        public string FailureReason { get; set; }

        /**
         * downFileName
         */
        [JsonProperty ("downFileName")]
        public string DownFileName { get; set; }

        /**
         * fileParameter
         */
        [JsonProperty ("fileParameter")]
        public string FileParameter { get; set; }
        
        public override string ToString() {
            return "CPDFFileInfo{" +
                "FileKey='" + FileKey + '\'' +
                ", TaskId='" + TaskId + '\'' +
                ", FileName='" + FileName + '\'' +
                ", FileUrl='" + FileUrl + '\'' +
                ", DownloadUrl='" + DownloadUrl + '\'' +
                ", SourceType='" + SourceType + '\'' +
                ", TargetType='" + TargetType + '\'' +
                ", FileSize='" + FileSize + '\'' +
                ", ConvertSize='" + ConvertSize + '\'' +
                ", ConvertTime='" + ConvertTime + '\'' +
                ", Status='" + Status + '\'' +
                ", FailureCode='" + FailureCode + '\'' +
                ", FailureReason='" + FailureReason + '\'' +
                ", DownFileName='" + DownFileName + '\'' +
                ", FileParameter='" + FileParameter + '\'' +
                '}';
        }
    }
}
