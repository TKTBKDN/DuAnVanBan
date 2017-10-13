using INV.Elearning.Core.Model;
using System.Collections.Generic;
using System.Windows.Media;

namespace INV.Elearning.Text.Models
{
    /// <summary>
    /// Lớp trừu tượng chung cho các phần tử text cơ bản
    /// </summary>
    public abstract class TextElementBase
    {
        /// <summary>
        /// Giá trị phông chữ
        /// </summary>
        public string Fontfamily { get; set; }
        /// <summary>
        /// Giá trị kích cỡ chữ
        /// </summary>
        public double FontSize { get; set; }
        /// <summary>
        /// Kiểu chữ in nghiêng
        /// </summary>
        public FontStyle FontStyle { get; set; }
        /// <summary>
        /// Kiểu chữ in đậm
        /// </summary>
        public FontWeight FontWeight { get; set; }
        /// <summary>
        /// Giá trị màu chữ
        /// </summary>
        public SolidColor Foreground { set; get; }
        /// <summary>
        /// Giá trị màu nền chữ
        /// </summary>
        public SolidColor TextHighLight { set; get; }

        /// <summary>
        /// Đối tượng chứa của phần tử
        /// </summary>
        public TextElementBase Parent { get; set; }

        /// <summary>
        /// Lấy danh sách các phần tử dùng để render nội dung
        /// </summary>
        /// <param name="words"></param>
        public abstract void GetRenderElement(List<WordBase> words);
    }
}
