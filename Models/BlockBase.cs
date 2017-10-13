using INV.Elearning.Core.Model;

namespace INV.Elearning.Text.Models
{
    /// <summary>
    /// Lớp trừu tượng cho các phần tử đoạn thuộc tài liệu
    /// </summary>
    public abstract class BlockBase : TextElementBase
    {
        /// <summary>
        /// Kiểu căn lề cho đoạn
        /// </summary>
        public HorizontalAlign TextAlign { get; set; }
        /// <summary>
        /// Giá trị khoảng cách đến các lề
        /// </summary>
        public EThickness Margin { get; set; }
        /// <summary>
        /// Giá trị khoảng cách đến các đường bao của nội dung
        /// </summary>
        public EThickness Padding { get; set; }
        /// <summary>
        /// Giá trị căn lề trái của dòng đầu tiên
        /// </summary>
        public double TextIndent { get; set; }
        /// <summary>
        /// Giá trị độ cao của từng dòng trong đoạn
        /// </summary>
        public double LineHeight { get; set; }
    }
}
