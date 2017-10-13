using INV.Elearning.Core.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace INV.Elearning.Text.Models
{
    public class TextContainer : FrameworkElement
    {
        private Document _document;

        public Document Document
        {
            get { return _document ?? (_document = CreateDataDemo()); }
            set { _document = value; }
        }
        

        private List<WordBase> _words;
        /// <summary>
        /// Danh sách các từ dùng để render
        /// </summary>
        internal List<WordBase> Words
        {
            get { return _words ?? (_words = new List<WordBase>()); }
        }

        ///// <summary>
        ///// Nhân bản một đối tượng
        ///// </summary>
        ///// <returns></returns>
        //public override IElearningElement Clone()
        //{
        //    throw new NotImplementedException();
        //}

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Words.Clear();
            this.Document.GetRenderElement(this.Words);

            double _maxHeight = this.Words[0].Height;
            double _maxY = 0;
            var _currentIndex = 0;
            for (int i = 0; i < this.Words.Count; i++)
            {
                if (i == this.Words.Count - 1)
                {
                    for (int j = _currentIndex; j < i; j++)
                    {
                        this.Words[j].Top = this.Document.CurrentY + _maxHeight;
                        this.Words[j].DrawText(drawingContext, _maxY);
                    }
                    break;
                }

                if (this.Words[i].Left == 0 && i != 0) //Xuống dòng
                {
                    _maxY =_maxY+ _maxHeight+20;
                    for (int j = _currentIndex; j < i; j++)
                    {
                        this.Words[j].Top = _maxY;
                        this.Words[j].DrawText(drawingContext, this.Words[j].Top);

                    }
                    _maxHeight = this.Words[i].Height;
                  //  this.Document.CurrentY += _maxHeight;

                    _currentIndex = i;
                }
                else
                {
                    if (this.Words[i].Height > _maxHeight) //Lấy giá trị lớn nhất
                    {
                        _maxHeight = this.Words[i].Height;
                    }
                }
            }
         
        }

        private Document CreateDataDemo()
        {
            Document _result = new Document();
            _result.Padding = new EThickness();

            for (int i = 0; i < 2; i++)
            {
                Paragraph _para = new Paragraph();
                for (int j = 0; j < 7; j++)
                {
                    Run _run = new Run();
                    _run.Fontfamily = "Arial";
                    _run.FontSize = 14 + j * 3;
                    _run.Text = string.Format("SốaabfsdsSDSSSSSSSSSSSSSSSSSSS23456789 {0} ", j);
                    _run.Parent = _para;
                    _run.Foreground = new SolidColor() { Color = "Black" };
                    _para.Inlines.Add(_run);
                }
                _para.Parent = _result;
                _result.Blocks.Add(_para);
            }
            _result.Container = this;

            return _result;
        }

        public TextContainer()
        {
            SizeChanged += TextContainer_SizeChanged;
        }

        void TextContainer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.InvalidateVisual();
        }
    }
}
