using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Basic
{
    public class ScreenSaver : Form
    {
        private DateTime _dateTime;
        private float _fontSize;
        private Pen _pen;
        private FontFamily _fontFamily;
        private Font _font;
        private StringFormat _stringFormat;
        private StringFormat _stringFormatForAuthor;
        private Timer _timer;
        private string _oldData;
        private Font _fontForAuthor;
        private FontFamily _fontFamilyForAuthor;
        public ScreenSaver()
        {
            _dateTime = DateTime.Now;
            _fontSize = 256;
            _fontFamily = new FontFamily("Unica One");
            _font = new Font(_fontFamily, _fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            _stringFormat = new StringFormat();
            _stringFormat.Alignment = StringAlignment.Center;
            _stringFormat.LineAlignment = StringAlignment.Center;
            _pen = new Pen(Color.Beige);
            BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Start();
            _timer.Tick += TimerTick;
            Cursor.Hide();
            _stringFormatForAuthor = new StringFormat();
            _stringFormatForAuthor.Alignment = StringAlignment.Center;
            _stringFormatForAuthor.LineAlignment = StringAlignment.Far;
            _fontFamilyForAuthor = new FontFamily("Lobster");
            _fontForAuthor = new Font(_fontFamilyForAuthor, 32, FontStyle.Italic, GraphicsUnit.Pixel);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            base.OnPaint(e);
            e.Graphics.DrawString(_dateTime.ToShortTimeString(), _font, _pen.Brush, e.ClipRectangle,_stringFormat);
            e.Graphics.DrawString("by Mücahit Bayraktar",_fontForAuthor,_pen.Brush,e.ClipRectangle,_stringFormatForAuthor);
            _oldData = _dateTime.ToShortTimeString();
        }
        private void TimerTick(object sender,EventArgs e)
        {
            _dateTime = DateTime.Now;
            if(_dateTime.ToShortTimeString() != _oldData)
            {
                OnPaint(new PaintEventArgs(CreateGraphics(), ClientRectangle));
            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Close();
        }
    }
}
