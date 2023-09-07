namespace ComPDFKit.pojo.comPdfKit
{
    public class CPDFTenantAssetItem
    {
        public string AssetTypeName { get; set; }
        public int WithholdingAsset { get; set; }
        public int Asset { get; set; }

        public override string ToString()
        {
            return "CPDFTenantAssetItem{" +
                   "AssetTypeName='" + AssetTypeName + '\'' +
                   ", WithholdingAsset=" + WithholdingAsset +
                   ", Asset=" + Asset +
                   '}';
        }
    }
}