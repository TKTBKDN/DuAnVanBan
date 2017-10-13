
namespace INV.Elearning.Text.Models
{
    /// <summary>
    /// Lớp trừu tượng cho các phần thử thuộc đoạn
    /// </summary>
    public abstract class InlineBase : TextElementBase
    {
        /// <summary>
        /// Kiểu gạch chân
        /// </summary>
        public Underline Underline { get; set; }
        /// <summary>
        /// Kiểu gạch xuyên thân
        /// </summary>
        public StrikeThrough StrikeThrough { get; set; }
        /// <summary>
        /// Kiểu đổ bóng
        /// </summary>
        public TextShadow TextShadow { get; set; }
        /// <summary>
        /// Kiểu vị trí chữ
        /// </summary>
        public TextInlineAlign TextInlineAlign { get; set; }
        /// <summary>
        /// Giá trị vị trí nếu chữ là chỉ số
        /// </summary>
        public int ScriptOffset { get; set; }
        /// <summary>
        /// Kiểu in hoa chữ
        /// </summary>
        public CapType CapType { get; set; }
        /// <summary>
        /// Giá trị giãn ký tự
        /// </summary>
        public double CharSpacing { set; get; }
        /// <summary>
        /// Kiểu giãn nở, thu hẹp ký tự
        /// </summary>
        public CharacterSpacing CharSpacingType { get; set; }
        
        /*public InlineBase Parent { get; set; }*/
    }
}
