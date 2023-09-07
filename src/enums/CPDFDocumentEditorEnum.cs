using System;

namespace ComPDFKit.enums
{
    public enum CPDFDocumentEditorEnum
    {
        SPLIT,
        MERGE,
        COMPRESS,
        DELETE,
        EXTRACT,
        ROTATION,
        INSERT,
        ADD_WATERMARK,
        DEL_WATERMARK
    }

    public class CPDFDocumentEditorEnumExtensions
    {
        public static string GetValue(CPDFDocumentEditorEnum value)
        {
            switch (value)
            {
                case CPDFDocumentEditorEnum.SPLIT:
                    return "pdf/split";
                case CPDFDocumentEditorEnum.MERGE:
                    return "pdf/merge";
                case CPDFDocumentEditorEnum.COMPRESS:
                    return "pdf/compress";
                case CPDFDocumentEditorEnum.DELETE:
                    return "pdf/delete";
                case CPDFDocumentEditorEnum.EXTRACT:
                    return "pdf/extract";
                case CPDFDocumentEditorEnum.ROTATION:
                    return "pdf/rotation";
                case CPDFDocumentEditorEnum.INSERT:
                    return "pdf/insert";
                case CPDFDocumentEditorEnum.ADD_WATERMARK:
                    return "pdf/addWatermark";
                case CPDFDocumentEditorEnum.DEL_WATERMARK:
                    return "pdf/delWatermark";
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Invalid CPDFDocumentEditorEnum value");
            }
        }

    }
}
