using System.Collections.Generic;
using Newtonsoft.Json;

namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFTaskInfoResult
    {
        /**
         * taskId
         */
        public string TaskId { get; set; }

        /**
         * taskFileNum
         */
        public int TaskFileNum { get; set; }

        /**
         * taskSuccessNum
         */
        public string TaskSuccessNum { get; set; }

        /**
         * taskFailNum
         */
        public string TaskFailNum { get; set; }

        /**
         * taskStatus
         */
        public string TaskStatus { get; set; }

        /**
         * assetTypeId
         */
        public string AssetTypeId { get; set; }

        /**
         * taskCost
         */
        public string TaskCost { get; set; }

        /**
         * taskTime
         */
        public long TaskTime { get; set; }

        /**
         * sourceType
         */
        public string SourceType { get; set; }

        /**
         * targetType
         */
        public string TargetType { get; set; }

        /**
         * callbackUrl
         */
        public string CallbackUrl { get; set; }

        /**
         * fileInfoDTOList
         */
        [JsonProperty("fileInfoDTOList")]
        public List<CPDFFileInfo> CPDFFileInfoList { get; set; }

        public override string ToString()
        {
            return "QueryTaskInfoResult{" +
                "taskId='" + TaskId + '\'' +
                ", taskFileNum=" + TaskFileNum +
                ", taskSuccessNum='" + TaskSuccessNum + '\'' +
                ", taskFailNum='" + TaskFailNum + '\'' +
                ", taskStatus='" + TaskStatus + '\'' +
                ", assetTypeId='" + AssetTypeId + '\'' +
                ", taskCost='" + TaskCost + '\'' +
                ", taskTime=" + TaskTime +
                ", sourceType='" + SourceType + '\'' +
                ", targetType='" + TargetType + '\'' +
                ", callbackUrl='" + CallbackUrl + '\'' +
                ", fileInfoList=" + (CPDFFileInfoList != null ? CPDFFileInfoList.ToString() : "null") +
                '}';
        }
    }
}