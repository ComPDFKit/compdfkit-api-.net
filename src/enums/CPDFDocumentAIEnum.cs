using System;

namespace ComPDFKit.enums
{
    public enum CPDFDocumentAIEnum
    {
        OCR,
        MAGICCOLOR,
        TABLEREC,
        LAYOUTANALYSIS,
        DEWARP,
        DETECTIONSTAMP
    }

    public class CPDFDocumentAIEnumExtensions
    {
        public static string GetValue(CPDFDocumentAIEnum value)
        {
            switch (value)
            {
                case CPDFDocumentAIEnum.OCR:
                    return "documentAI/ocr";
                case CPDFDocumentAIEnum.MAGICCOLOR:
                    return "documentAI/magicColor";
                case CPDFDocumentAIEnum.TABLEREC:
                    return "documentAI/tableRec";
                case CPDFDocumentAIEnum.LAYOUTANALYSIS:
                    return "documentAI/layoutAnalysis";
                case CPDFDocumentAIEnum.DEWARP:
                    return "documentAI/dewarp";
                case CPDFDocumentAIEnum.DETECTIONSTAMP:
                    return "documentAI/detectionStamp";
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Invalid CPDFDocumentAIEnum value");
            }
        }

    }
}
