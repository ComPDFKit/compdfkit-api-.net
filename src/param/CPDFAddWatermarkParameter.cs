namespace ComPDFKit.param
{
    /// <summary>
    /// Form recognition parameter
    /// </summary>
    public class CPDFAddWatermarkParameter : CPDFFileParameter
    {
        public const string TYPE_TEXT = "text";
        public const string TYPE_IMAGE = "image";

        public const string VERTALIGN_TOP = "top";
        public const string VERTALIGN_CENTER = "center";
        public const string VERTALIGN_BOTTOM = "bottom";

        public const string HORIZALIGN_LEFT = "left";
        public const string HORIZALIGN_CENTER = "center";
        public const string HORIZALIGN_RIGHT = "right";
        
        /// <summary>
        /// Watermark type (text: text type watermark, image: image type watermark)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Zoom (image type attribute)
        /// </summary>
        public string Scale { get; set; }

        /// <summary>
        /// Transparency 0~1
        /// </summary>
        public string Opacity { get; set; }

        /// <summary>
        /// Rotation angle, a positive number means counterclockwise rotation
        /// </summary>
        public string Rotation { get; set; }

        /// <summary>
        /// Page number, page number from start, for example: 1,2,4,6
        /// </summary>
        public string TargetPages { get; set; }

        /// <summary>
        /// Vertical alignment: top, center, bottom
        /// </summary>
        public string VertAlign { get; set; }

        /// <summary>
        /// Horizontal alignment: left, center, right
        /// </summary>
        public string HorizAlign { get; set; }

        /// <summary>
        /// Horizontal offset
        /// </summary>
        public string XOffset { get; set; }

        /// <summary>
        /// Vertical offset
        /// </summary>
        public string YOffset { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Text color, e.g., #FFFFFF
        /// </summary>
        public string TextColor { get; set; }

        /// <summary>
        /// Is it at the front
        /// </summary>
        public string Front { get; set; }

        /// <summary>
        /// Whether to fill the entire page
        /// </summary>
        public string FullScreen { get; set; }

        /// <summary>
        /// Horizontal spacing
        /// </summary>
        public string HorizontalSpace { get; set; }

        /// <summary>
        /// Vertical spacing
        /// </summary>
        public string VerticalSpace { get; set; }

        /// <summary>
        /// Extended information, base 64 encoding
        /// </summary>
        public string Extension { get; set; }
    }
}