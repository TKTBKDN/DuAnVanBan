using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.Elearning.Text.Models
{
    /// <summary>
    /// Đối tượng phần tử thuộc danh sách
    /// </summary>
    public class DocumentListItem : TextElementBase
    {
        /// <summary>
        /// Giá trị chỉ số của phần tử
        /// </summary>
        public int Index { get; set; }

        private List<BlockBase> _blocks;
        /// <summary>
        /// Danh sách các đoạn
        /// </summary>
        public List<BlockBase> Blocks
        {
            get { return _blocks ?? (_blocks = new List<BlockBase>()); }
        }



        public override void GetRenderElement(List<WordBase> words)
        {
            foreach (var item in Blocks)
            {
                item.GetRenderElement(words); 
            }
        }
    }
}
