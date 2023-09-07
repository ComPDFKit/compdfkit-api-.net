namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFOauthResult
    {
        public string ExpiresIn { get; set; }
        public string Scope { get; set; }
        public string TenantId { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string ProjectName { get; set; }
        public string ProjectId { get; set; }
        public string RefreshToken { get; set; }

        public override string ToString()
        {
            return "CPDFOauthResult{" +
                   "ExpiresIn='" + ExpiresIn + '\'' +
                   ", Scope='" + Scope + '\'' +
                   ", TenantId='" + TenantId + '\'' +
                   ", AccessToken='" + AccessToken + '\'' +
                   ", TokenType='" + TokenType + '\'' +
                   ", ProjectName='" + ProjectName + '\'' +
                   ", ProjectId='" + ProjectId + '\'' +
                   ", RefreshToken='" + RefreshToken + '\'' +
                   '}';
        }
    }
}