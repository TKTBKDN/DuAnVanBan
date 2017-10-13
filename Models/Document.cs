
using INV.Elearning.Core.Model;
using System.Collections.Generic;
using System.Windows.Media;

namespace INV.Elearning.Text.Models
{
    /// <summary>
    /// Lớp đối tượng tài liệu
    /// </summary>
    public class Document : TextElementBase
    {
        /// <summary>
        /// Kiểu căn lề văn bản theo chiều ngang
        /// </summary>
        public HorizontalAlign HorizontalAlign { get; set; }
        /// <summary>
        /// Kiểu căn lề văn bản theo chiều dọc
        /// </summary>
        public VerticalAlign VerticalAlign { get; set; }
        /// <summary>
        /// Số cột trong văn bản
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// Khoảng cách nội dung so với các cạnh
        /// </summary>
        public EThickness Padding { get; set; }

        /// <summary>
        /// Khung chứa nội dung
        /// </summary>
        public TextContainer Container { get; set; }

        /// <summary>
        /// Chiều dài tối đa
        /// </summary>
        public double MaxWidth 
        {
            get
            {
                return (Container.ActualWidth - Padding.Left - Padding.Right);
            }
        }

        /// <summary>
        /// Giá trị tọa độ X hiện tại,
        /// Chỉ dùng cho việc Render, không lưu trữ
        /// </summary>
        internal double CurrentX { get; set; }

        /// <summary>
        /// Giá trị tọa độ Y hiện tại,
        /// Chỉ dùng cho việc Render, không lưu trữ
        /// </summary>
        internal double CurrentY { get; set; }

        /// <summary>
        /// Chiều rộng tối đa
        /// </summary>
        public double MaxHeigt
        {
            get
            {
                return (Container.Height - Padding.Top - Padding.Bottom);
            }
        }

        private List<BlockBase> _blocks;
        /// <summary>
        /// Danh sách các đoạn
        /// </summary>
        public List<BlockBase> Blocks
        {
            get { return _blocks ?? (_blocks = new List<BlockBase>()); }
        }

        /// <summary>
        /// Tỷ lệ ....
        /// </summary>
        public const double DIP = 72.0 / 96.0;

        public override void GetRenderElement(List<WordBase> words)
        {
            foreach (var item in Blocks)
            {
                item.GetRenderElement(words);
            }
        }
    }
}
