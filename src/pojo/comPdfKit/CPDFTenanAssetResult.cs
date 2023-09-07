using System.Collections.Generic;

namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFTenanAssetResult
    {
        public List<CPDFTenantAssetItem> TenantAsset { get; set; }

        public override string ToString()
        {
            return "CPDFTenantAssetResult{" +
                   "TenantAsset=" + TenantAsset +
                   '}';
        }
    }
}