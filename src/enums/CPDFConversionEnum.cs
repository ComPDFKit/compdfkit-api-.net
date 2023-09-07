using System;

namespace ComPDFKit.enums
{
    public enum CPDFConversionEnum
    {
        DOC_TO_PDF,
        DOCX_TO_PDF,
        XLSX_TO_PDF,
        XLS_TO_PDF,
        PPT_TO_PDF,
        PPTX_TO_PDF,
        TXT_TO_PDF,
        PNG_TO_PDF,
        HTML_TO_PDF,
        CSV_TO_PDF,
        RTF_TO_PDF,
        PDF_TO_WORD,
        PDF_TO_EXCEL,
        PDF_TO_PPT,
        PDF_TO_TXT,
        PDF_TO_PNG,
        PDF_TO_JPG,
        PDF_TO_HTML,
        PDF_TO_RTF,
        PDF_TO_CSV
    }

    public class CPDFConversionEnumExtensions
    {
        public static string GetValue(CPDFConversionEnum value)
        {
            switch (value)
            {
                case CPDFConversionEnum.DOC_TO_PDF:
                    return "doc/pdf";
                case CPDFConversionEnum.DOCX_TO_PDF:
                    return "docx/pdf";
                case CPDFConversionEnum.XLSX_TO_PDF:
                    return "xlsx/pdf";
                case CPDFConversionEnum.XLS_TO_PDF:
                    return "xls/pdf";
                case CPDFConversionEnum.PPT_TO_PDF:
                    return "ppt/pdf";
                case CPDFConversionEnum.PPTX_TO_PDF:
                    return "pptx/pdf";
                case CPDFConversionEnum.TXT_TO_PDF:
                    return "txt/pdf";
                case CPDFConversionEnum.PNG_TO_PDF:
                    return "png/pdf";
                case CPDFConversionEnum.HTML_TO_PDF:
                    return "html/pdf";
                case CPDFConversionEnum.CSV_TO_PDF:
                    return "csv/pdf";
                case CPDFConversionEnum.RTF_TO_PDF:
                    return "rtf/pdf";
                case CPDFConversionEnum.PDF_TO_WORD:
                    return "pdf/docx";
                case CPDFConversionEnum.PDF_TO_EXCEL:
                    return "pdf/xlsx";
                case CPDFConversionEnum.PDF_TO_PPT:
                    return "pdf/pptx";
                case CPDFConversionEnum.PDF_TO_TXT:
                    return "pdf/txt";
                case CPDFConversionEnum.PDF_TO_PNG:
                    return "pdf/png";
                case CPDFConversionEnum.PDF_TO_JPG:
                    return "pdf/jpg";
                case CPDFConversionEnum.PDF_TO_HTML:
                    return "pdf/html";
                case CPDFConversionEnum.PDF_TO_RTF:
                    return "pdf/rtf";
                case CPDFConversionEnum.PDF_TO_CSV:
                    return "pdf/csv";
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Invalid CPDFConversionEnum value");
            }
        }


    }
}
