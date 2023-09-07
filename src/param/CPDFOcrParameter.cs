namespace ComPDFKit.param
{
    /// <summary>
    /// Form recognition parameter
    /// </summary>
    public class CPDFOcrParameter : CPDFFileParameter
    {
        public const string LANG_AUTO = "auto";
        public const string LANG_ENGLISH = "english";
        public const string LANG_CHINESE = "chinese";
        public const string LANG_CHINESE_TRA = "chinese_tra";
        public const string LANG_KOREAN = "korean";
        public const string LANG_JAPANESE = "japanese";
        public const string LANG_LATIN = "latin";
        public const string LANG_DEVANAGARI = "devanagari";

        /// <summary>
        /// language: Supported types and definitions.
        /// auto - automatic classification language.
        /// english - English.
        /// chinese - Simplified Chinese.
        /// chinese_tra - Traditional Chinese.
        /// korean - Korean.
        /// japanese - Japanese.
        /// latin - Latin.
        /// devanagari - Sanskrit alphabet.
        /// </summary>
        public string Lang { get; set; } = LANG_AUTO;
    }
}