using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace INV.Elearning.Text.Models
{
    public abstract class WordBase
    {
        public TextElementBase Parent { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Top { get; set; }
        public double Left { get; set; }
        public double MaxHeight { set; get; }

        /// <summary>
        /// Render ra các nội dung
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="maxTop"></param>
        public abstract void DrawText(DrawingContext dc, double maxTop);
    }
}
