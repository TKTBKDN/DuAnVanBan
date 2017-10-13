using System.Collections.Generic;

namespace INV.Elearning.Text.Models
{
    /// <summary>
    /// Lớp đối tượng đoạn văn
    /// </summary>
    public class Paragraph : BlockBase
    {
        private List<InlineBase> _inlines;
        /// <summary>
        /// Danh sách các đoạn định dạng trong đoạn văn
        /// </summary>
        public List<InlineBase> Inlines
        {
            get { return _inlines ?? (_inlines = new List<InlineBase>()); }
        }


        

        public override void GetRenderElement(List<WordBase> words)
        {
            
            foreach (var item in Inlines)
            {
                item.GetRenderElement(words);
            }
        }
    }
}
