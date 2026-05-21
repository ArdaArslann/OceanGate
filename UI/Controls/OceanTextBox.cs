using System;
using System.Drawing;
using System.Windows.Forms;

namespace oceangate_r.UI.Controls
{
    /// <summary>
    /// Placeholder ve alt-çizgi efekti ile özel TextBox kontrolü.
    /// Placeholder etiketi TextBox'ın üzerinde şeffaf olarak oturur;
    /// tıklandığında veya textbox focus alınca otomatik gizlenir.
    /// </summary>
    public class OceanTextBox : UserControl
    {
        private readonly TextBox _tb;
        private readonly Label   _placeholder;
        private string _placeholderText;
        private bool   _isFocused;

        public string PlaceholderText
        {
            get => _placeholderText;
            set
            {
                _placeholderText = value;
                if (_placeholder != null) _placeholder.Text = value;
            }
        }

        public new string Text
        {
            get => _tb.Text;
            set
            {
                _tb.Text = value;
                if (_placeholder != null)
                    _placeholder.Visible = (value == null || value.Length == 0) && !_isFocused;
            }
        }

        public bool UseSystemPasswordChar
        {
            get => _tb.UseSystemPasswordChar;
            set
            {
                _tb.UseSystemPasswordChar = value;
                // Şifre alanında placeholder simgesel gösterim
                if (value && _placeholder != null)
                    _placeholder.Text = _placeholderText; // Düz metin kalsın
            }
        }

        public new event EventHandler TextChanged
        {
            add    => _tb.TextChanged += value;
            remove => _tb.TextChanged -= value;
        }

        public OceanTextBox()
        {
            // ÖNEMLİ: _tb ve _placeholder, BackColor set edilmeden ÖNCE oluşturulmalı.
            _tb = new TextBox
            {
                BorderStyle           = BorderStyle.None,
                BackColor             = AppTheme.BgMedium,
                ForeColor             = AppTheme.TextLight,
                Font                  = AppTheme.BodyFont,
                Dock                  = DockStyle.None,
                Height                = 22,
            };

            _placeholder = new Label
            {
                Font      = AppTheme.BodyFont,
                ForeColor = AppTheme.TextMuted,
                BackColor = Color.Transparent,
                AutoSize  = false,
                Cursor    = Cursors.IBeam,   // Kullanıcıya "buraya yazılır" sinyali
            };

            Height         = 44;
            BackColor      = Color.Transparent;
            DoubleBuffered = true;

            Controls.Add(_tb);
            Controls.Add(_placeholder);

            // Placeholder tıklanınca TextBox'a focus ver
            _placeholder.Click += (s, e) => _tb.Focus();

            _tb.GotFocus  += (s, e) =>
            {
                _isFocused = true;
                _placeholder.Visible = false;          // Focus alınca gizle
                Invalidate();
            };
            _tb.LostFocus += (s, e) =>
            {
                _isFocused = false;
                _placeholder.Visible = _tb.Text.Length == 0;  // Boşsa tekrar göster
                Invalidate();
            };
            _tb.TextChanged += (s, e) =>
            {
                _placeholder.Visible = _tb.Text.Length == 0 && !_isFocused;
            };

            Resize += (s, e) => DoLayout();
            DoLayout();
        }

        private void DoLayout()
        {
            _tb.Location          = new Point(4, (Height - _tb.Height) / 2 + 2);
            _tb.Width             = Width - 8;
            _placeholder.Location = new Point(6, (Height - _placeholder.PreferredHeight) / 2 + 1);
            _placeholder.Size     = new Size(Width - 12, _placeholder.PreferredHeight + 4);

            // Placeholder ETİKETİ üstte; tıklanınca focus devredilir
            _placeholder.BringToFront();
            // NOT: _tb.BringToFront() ÇAĞIRILMAZ — placeholder görünür kalsın
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color lineColor = _isFocused ? AppTheme.Accent : AppTheme.Border;
            using (var pen = new Pen(lineColor, 2))
                e.Graphics.DrawLine(pen, 0, Height - 2, Width, Height - 2);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            if (_tb == null) return;
            _tb.BackColor = BackColor == Color.Transparent ? AppTheme.BgMedium : BackColor;
        }
    }
}
