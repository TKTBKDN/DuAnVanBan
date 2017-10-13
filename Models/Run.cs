
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
namespace INV.Elearning.Text.Models
{
    /// <summary>
    /// Lớp đối tượng thể hiện một phần tử định dạng chữ viết trong đoạn
    /// </summary>
    public class Run : InlineBase
    {
        /// <summary>
        /// Giá trị nội dung của đoạn định dạng
        /// </summary>
        public string Text { get; set; }

        public override void GetRenderElement(List<WordBase> words)
        {

            var _words = this.Text.Split(' ');
            var _maxRowWidth = ((this.Parent as Paragraph).Parent as Document).MaxWidth;
            var _currentX = ((this.Parent as Paragraph).Parent as Document).CurrentX;
            var _currentY = ((this.Parent as Paragraph).Parent as Document).CurrentY;

            var _fontSize = this.ScriptOffset != 0 ? this.FontSize * Document.DIP : this.FontSize;
            var _typeface = new Typeface(this.Fontfamily);
            var _spaceText = new FormattedText(" ", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _typeface, _fontSize, Brushes.Black);
            for (int i = 0; i < _words.Length; i++)
            {
                if (string.IsNullOrEmpty(_words[i])) //Kiểm tra ký tự có phải khoảng trắng
                {
                    var _wordRun = new WordRun();
                    _wordRun.Width = _spaceText.WidthIncludingTrailingWhitespace;
                    _wordRun.Height = _spaceText.Baseline;
                    _wordRun.Left = _currentX;
                    _wordRun.Top = _currentY + _spaceText.Baseline;
                    _wordRun.Parent = this;
                    _wordRun.Text = "";
                    //if( _spaceText.Baseline>_wordRun.MaxHeight)
                    //{
                    //    _wordRun.MaxHeight=_spaceText.Baseline;
                    //}
                   
                    words.Add(_wordRun);
                    _currentX += _wordRun.Width;
                }
                else// Kiểm tra ký tự không là khoảng trắng
                {
                    var _textFormatted = new FormattedText(_words[i], CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _typeface, _fontSize, Brushes.Black);

                    if (_currentX + _textFormatted.WidthIncludingTrailingWhitespace < _maxRowWidth)
                    {
                        var _wordRun = new WordRun();
                        _wordRun.Width = _textFormatted.WidthIncludingTrailingWhitespace;
                        _wordRun.Height = _textFormatted.Baseline;
                        _wordRun.Left = _currentX;

                     //   if (_currentY == 0)
                            //_currentY = _textFormatted.Baseline + 3;

                        _wordRun.Top = _currentY + _textFormatted.Baseline + 3;
                        _wordRun.Parent = this;

                        if (i == (_words.Length - 1))//Các từ khác cuối cùng được cộng thêm một khoảng trắng
                        {
                            _wordRun.Text = _words[i];
                            _currentX += _wordRun.Width;

                        }
                        else
                        {
                            _wordRun.Text = _words[i] + " ";
                            _currentX += (_wordRun.Width + _spaceText.WidthIncludingTrailingWhitespace);
                        }

                        words.Add(_wordRun);
                    }
                    else
                    {
                        if (_textFormatted.WidthIncludingTrailingWhitespace < _maxRowWidth) //Trường hợp độ dài từ bé hơn độ dài khung
                        {
                            var _wordRun = new WordRun();
                            _wordRun.Width = _textFormatted.WidthIncludingTrailingWhitespace;
                            _wordRun.Height = _textFormatted.Baseline;
                            _currentX = 0;
                            _wordRun.Left = 0;
                            _wordRun.Top = _currentY + _textFormatted.Baseline;
                            _wordRun.Parent = this;

                            if (i == (_words.Length - 1))//Các từ khác cuối cùng được cộng thêm một khoảng trắng
                            {
                                _wordRun.Text = _words[i];
                                _currentX += _wordRun.Width;

                            }
                            else
                            {
                                _wordRun.Text = _words[i] + " ";
                                _currentX += (_wordRun.Width + _spaceText.WidthIncludingTrailingWhitespace);
                            }

                            words.Add(_wordRun);
                        }
                        else
                        {
                            double _x = 0;
                            int _startIndex = 0;
                            int j = 0;
                            for (; j < _words[i].Length; j++)
                            {
                                var _char = new FormattedText(_words[i][j].ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, _typeface, _fontSize, Brushes.Black);
                                if (_x + _char.WidthIncludingTrailingWhitespace > _maxRowWidth)
                                {
                                    _currentX = 0;
                                    var _wordRun = new WordRun();
                                    _wordRun.Text = _words[i].Substring(_startIndex, j - _startIndex);
                                    var _charSubstring = new FormattedText(_wordRun.Text.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, _typeface, _fontSize, Brushes.Black);
                                    _wordRun.Width = _charSubstring.WidthIncludingTrailingWhitespace;
                                    _wordRun.Height = _charSubstring.Baseline;
                                    _wordRun.Left = _currentX;
                                    _currentY = +_charSubstring.Baseline + 3;
                                    _wordRun.Top = _currentY;
                                    _wordRun.Parent = this;        
                                    _startIndex = j;
                                     //Còn cộng thêm cái LineHeight     
                                    words.Add(_wordRun);
                                    _x = _char.WidthIncludingTrailingWhitespace;
                                }else                             
                                _x += _char.WidthIncludingTrailingWhitespace;
                            }
                            if (_startIndex < j && j == _words[i].Length)
                            {
                                var _wordRun = new WordRun();
                                _wordRun.Text = _words[i].Substring(_startIndex, j - _startIndex);
                                var _char = new FormattedText(_wordRun.Text.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, _typeface, _fontSize, Brushes.Black);
                                _wordRun.Width = _char.WidthIncludingTrailingWhitespace;
                                _wordRun.Height = _char.Baseline;
                                _wordRun.Left = _currentX;
                                //_currentY = _char.Baseline + 3;
                                _wordRun.Top = _currentY+_char.Baseline + 3;
                                _wordRun.Parent = this;

                                _startIndex = j;
                                //Còn cộng thêm cái LineHeight
                                _currentX = _char.WidthIncludingTrailingWhitespace;
                                words.Add(_wordRun);
                                //_x = 0;

                            }
                        }
                    }
                }
            }
            ((this.Parent as Paragraph).Parent as Document).CurrentX = _currentX;
            ((this.Parent as Paragraph).Parent as Document).CurrentY = _currentY;
        }
        public List<TemplateFormattedText> ListWord(string inputString)
        {
            List<TemplateFormattedText> result = new List<TemplateFormattedText>();
            if (inputString[0] == ' ')
            {
                result.Add(new TemplateFormattedText() { Text = "", Space = Text.Substring(0, GetFirstIndex(Text, 0)) });
            }
            var words = Text.Split(' ');//Lấy danh sách các từ trong chuỗi
            string sumSpace = "";
            var _lastIndex = GetLastIndex(words);//Vị trí cuối cùng khác khoảng trắng
            //Thêm vào list từ
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    sumSpace = "";
                    int j = i + 1;
                    for (j = i + 1; j < words.Length; j++)
                    {
                        if (string.IsNullOrEmpty(words[j]))
                        {
                            sumSpace += " ";
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (i < _lastIndex)
                    {
                        sumSpace += " ";
                    }
                    result.Add(new TemplateFormattedText() { Text = words[i], Space = sumSpace });
                    i = j - 1;
                }
            }
            return result;
        }

        /// <summary>
        /// Lấy vị trí cuối cùng khác khoảng trắng
        /// </summary>
        /// <param name="words">Danh sách các từ thuộc chuỗi</param>
        /// <returns></returns>
        public int GetLastIndex(string[] words)
        {
            int result = 0;
            for (int i = words.Length - 1; i >= 0; i--)
            {
                if (words[i] != "")
                {
                    return i;
                }
            }
            return result;
        }

        /// <summary>
        /// Lấy vị trí đầu tiên khác khoảng trắng, kể từ vị trí Index
        /// </summary>
        /// <param name="s">Chuỗi nhập vào</param>
        /// <param name="index">Vị trí bắt đầu</param>
        /// <returns></returns>
        public int GetFirstIndex(string s, int index)
        {
            for (int j = index; j < s.Length; j++)
            {
                if (s[j] != ' ') return j;
            }
            return 0;
        }

    }
    public class TemplateFormattedText
    {
        public string Text { get; set; }
        public string Space { get; set; }

    }

}
