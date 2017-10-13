using INV.Elearning.Core.Model;
using System.Collections.Generic;

namespace INV.Elearning.Text.Models
{
    public class DocumentList : BlockBase
    {
        /// <summary>
        /// Kiểu danh sách
        /// </summary>
        public ListType ListType { get; set; }
        /// <summary>
        /// Giá trị phần trăm kích thước chỉ số so với kích thước gốc của danh sách
        /// </summary>
        public int IndexFontSize { get; set; }
        /// <summary>
        /// Giá trị màu của chỉ số
        /// </summary>
        public SolidColor IndexColor { get; set; }
        /// <summary>
        /// Giá trị bắt đầu của danh sách, chỉ dùng cho danh sách có sắp xếp
        /// </summary>
        public int StartIndex { get; set; }
        /// <summary>
        /// Ký tự của chỉ số
        /// </summary>
        public char IndexChar { get; set; }

        private List<DocumentListItem> _items;
        /// <summary>
        /// Danh sách các phần tử thuộc danh sách
        /// </summary>
        public List<DocumentListItem> Items
        {
            get { return _items ?? (_items = new List<DocumentListItem>()); }
        }


       
        public override void GetRenderElement(List<WordBase> words)
        {
            foreach (var item in Items)
            {
                item.GetRenderElement(words);
            }
        }
    }
}
