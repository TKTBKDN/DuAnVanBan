
namespace INV.Elearning.Text
{
    /// <summary>
    /// Kiểu chữ đậm
    /// </summary>
    public enum FontWeight
    { 
        Normal,
        Bold
    }

    /// <summary>
    /// Kiểu chữ in nghiêng
    /// </summary>
    public enum FontStyle
    {
        Normal,
        Italic
    }

    /// <summary>
    /// Kiểu chữ gạch chân
    /// </summary>
    public enum UnderlineStyle
    {
        None,
        Single,
        Double
    }

    /// <summary>
    /// Kiểu chữ gạch xuyên thân
    /// </summary>
    public enum StrikeThrough
    {
        None,
        Single,
        Double
    }

    /// <summary>
    /// Kiểu căn lề ngang
    /// </summary>
    public enum HorizontalAlign
    {
        Left,
        Center,
        Right, 
        Justify
    }

    /// <summary>
    /// Kiểu căn lề dọc
    /// </summary>
    public enum VerticalAlign
    {
        Top,
        Middle,
        Bottom
    }

    /// <summary>
    /// Kiểu đánh dấu cho danh sách
    /// </summary>
    public enum ListType
    {
        /// <summary>
        /// Kiểu số 1,2,3...
        /// </summary>
        Decimal,
        /// <summary>
        /// Kiểu chữ a,b,c...
        /// </summary>
        LowerLatin,
        /// <summary>
        /// Kiểu chữ i,ii,iii...
        /// </summary>
        LowerRoman,
        /// <summary>
        /// Kiểu chữ A,B,C...
        /// </summary>
        UpperLatin,
        /// <summary>
        /// Kiểu chữ I,II,III...
        /// </summary>
        UpperRoman,
        /// <summary>
        /// Kiểu không đánh dấu
        /// </summary>
        Bullet
    }

    /// <summary>
    /// Kiểu chữ đổ bóng
    /// </summary>
    public enum TextShadow
    {
        /// <summary>
        /// Không đổ bóng
        /// </summary>
        None,
        /// <summary>
        /// Đổ bóng bình thường
        /// </summary>
        NormalShadow
    }

    /// <summary>
    /// Kiểu chỉ số
    /// </summary>
    public enum TextInlineAlign
    {
        /// <summary>
        /// Bình thường
        /// </summary>
        BaseLine,
        /// <summary>
        /// Chỉ số dưới
        /// </summary>
        Subscript,
        /// <summary>
        /// Chỉ số trên
        /// </summary>
        Superscript
    }

    /// <summary>
    /// Kiểu chữ in hoa
    /// </summary>
    public enum CapType
    {
        /// <summary>
        /// Kiểu bình thường
        /// </summary>
        Normal,
        /// <summary>
        /// In hoa với kích thước nhỏ
        /// </summary>
        SmallCap,
        /// <summary>
        /// In hoa tất cả với cỡ chữ mặc định
        /// </summary>
        AllCap
    }

    /// <summary>
    /// Kiểu giãn ký tự
    /// </summary>
    public enum CharacterSpacing
    {
        /// <summary>
        /// Kiểu bình thường
        /// </summary>
        Normal,
        /// <summary>
        /// Kiểu giãn nở
        /// </summary>
        Expended,
        /// <summary>
        /// Kiểu thu hẹp
        /// </summary>
        Condensed
    }
}
