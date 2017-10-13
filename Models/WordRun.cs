using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace INV.Elearning.Text.Models
{
    public class WordRun : WordBase
    {
        public string Text { get; set; }

        public override void DrawText(System.Windows.Media.DrawingContext dc, double maxTop)
        {
            Typeface typeface = new Typeface((this.Parent as Run).Fontfamily);
            var _fontSize = (this.Parent as Run).ScriptOffset != 0 ? (this.Parent as Run).FontSize * Document.DIP : (this.Parent as Run).FontSize;
            Point origin = new Point(this.Left, maxTop);
            GlyphRun run = CreateGlyphRun(typeface, this.Text, _fontSize, origin);
            dc.DrawGlyphRun((Brush)(new BrushConverter().ConvertFromString((this.Parent as Run).Foreground.Color)), run);
        }

        public static GlyphRun CreateGlyphRun(Typeface typeface, string text, double size, Point origin)
        {
            if (text.Length == 0)
                return null;
            GlyphTypeface glyphTypeface;

            typeface.TryGetGlyphTypeface(out glyphTypeface);

            var glyphIndexes = new ushort[text.Length];
            var advanceWidths = new double[text.Length];
            for (int n = 0; n < text.Length; n++)
            {
                if (text[n] == '\n')
                    continue;
                var glyphIndex = glyphTypeface.CharacterToGlyphMap[text[n]];
                glyphIndexes[n] = glyphIndex;
                advanceWidths[n] = glyphTypeface.AdvanceWidths[glyphIndex] * size * 1;
            }
            var glyphRun = new GlyphRun(glyphTypeface, 0, false, size, glyphIndexes, origin, advanceWidths, null, null,
                                        null, null, null, null);
            return glyphRun;
        }
    }

}
