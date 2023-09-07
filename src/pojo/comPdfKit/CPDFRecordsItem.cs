namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFRecordsItem
    {
        public string Server { get; set; }
        public object UpdatedBy { get; set; }
        public string CreationTime { get; set; }
        public int AssetTypeId { get; set; }
        public int TaskFailNum { get; set; }
        public string UpdateTime { get; set; }
        public string TargetType { get; set; }
        public int UseToolId { get; set; }
        public int TaskCost { get; set; }
        public object CreatedBy { get; set; }
        public string TaskUrl { get; set; }
        public string SourceType { get; set; }
        public int TaskFileNum { get; set; }
        public int TaskSuccessNum { get; set; }
        public int TenantId { get; set; }
        public string TaskFinishTime { get; set; }
        public string CallbackUrl { get; set; }
        public long Id { get; set; }
        public string TaskLoadUrl { get; set; }
        public int ProjectId { get; set; }
        public string TaskId { get; set; }
        public string TaskStatus { get; set; }
        public int TaskTime { get; set; }

        public override string ToString()
        {
            return "CPDFRecordsItem{" +
                   "Server='" + Server + '\'' +
                   ", UpdatedBy=" + UpdatedBy +
                   ", CreationTime='" + CreationTime + '\'' +
                   ", AssetTypeId=" + AssetTypeId +
                   ", TaskFailNum=" + TaskFailNum +
                   ", UpdateTime='" + UpdateTime + '\'' +
                   ", TargetType='" + TargetType + '\'' +
                   ", UseToolId=" + UseToolId +
                   ", TaskCost=" + TaskCost +
                   ", CreatedBy=" + CreatedBy +
                   ", TaskUrl='" + TaskUrl + '\'' +
                   ", SourceType='" + SourceType + '\'' +
                   ", TaskFileNum=" + TaskFileNum +
                   ", TaskSuccessNum=" + TaskSuccessNum +
                   ", TenantId=" + TenantId +
                   ", TaskFinishTime='" + TaskFinishTime + '\'' +
                   ", CallbackUrl='" + CallbackUrl + '\'' +
                   ", Id=" + Id +
                   ", TaskLoadUrl='" + TaskLoadUrl + '\'' +
                   ", ProjectId=" + ProjectId +
                   ", TaskId='" + TaskId + '\'' +
                   ", TaskStatus='" + TaskStatus + '\'' +
                   ", TaskTime=" + TaskTime +
                   '}';
        }
    }
}