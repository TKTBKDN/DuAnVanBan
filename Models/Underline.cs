using INV.Elearning.Core.Model;

namespace INV.Elearning.Text.Models
{
    /// <summary>
    /// Lớp đối tượng gạch chân
    /// </summary>
    public class Underline
    {
        /// <summary>
        /// Màu sắc đường gạch chân
        /// </summary>
        public SolidColor Color { get; set; }

        /// <summary>
        /// Kiểu đường gạch chân
        /// </summary>
        public UnderlineStyle Style { get; set; }
    }
}
