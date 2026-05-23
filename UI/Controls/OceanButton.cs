using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace oceangate_r.UI.Controls
{
    
    public class OceanButton : Button
    {
        private Color _normalColor;
        private Color _hoverColor;
        private Color _pressColor;
        private Color _currentColor;
        private bool _isHovered;

        public int CornerRadius { get; set; } = 6;

        public OceanButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize    = 0;
            FlatAppearance.MouseOverBackColor   = Color.Transparent;
            FlatAppearance.MouseDownBackColor   = Color.Transparent;
            Font      = AppTheme.BodyBold;
            ForeColor = AppTheme.TextLight;
            Cursor    = Cursors.Hand;
            SetColors(AppTheme.Accent, AppTheme.AccentHover, AppTheme.AccentDark);
            _currentColor = _normalColor;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        public void SetColors(Color normal, Color hover, Color press)
        {
            _normalColor  = normal;
            _hoverColor   = hover;
            _pressColor   = press;
            _currentColor = normal;
            Invalidate();
        }

        public void SetDanger()  => SetColors(AppTheme.Danger,  Color.FromArgb(220, 38, 38),  Color.FromArgb(185, 28, 28));
        public void SetSuccess() => SetColors(AppTheme.Success, Color.FromArgb(16, 185, 129 + 20), Color.FromArgb(5, 150, 105));
        public void SetMuted()   => SetColors(AppTheme.BgCard,  AppTheme.BgCardHov,            AppTheme.BgMedium);

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered    = true;
            _currentColor = _hoverColor;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered    = false;
            _currentColor = _normalColor;
            Invalidate();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Cursor = Enabled ? Cursors.Hand : Cursors.Default;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _currentColor = _pressColor;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _currentColor = _isHovered ? _hoverColor : _normalColor;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color parentColor = (Parent != null && Parent.BackColor != Color.Transparent) 
                                ? Parent.BackColor : Color.FromArgb(15, 23, 42); 
            g.Clear(parentColor);

            using (var path = RoundedRect(ClientRectangle, CornerRadius))
            {
                Color bg = Enabled ? _currentColor : Color.FromArgb(100, _normalColor.R, _normalColor.G, _normalColor.B);
                using (var brush = new SolidBrush(bg))
                {
                    g.FillPath(brush, path);
                }
            }

            
            var sf = new StringFormat
            {
                Alignment     = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };
            Color fg = Enabled ? ForeColor : Color.FromArgb(120, 255, 255, 255);
            using (var textBrush = new SolidBrush(fg))
                g.DrawString(Text, Font, textBrush, ClientRectangle, sf);
        }

        private static GraphicsPath RoundedRect(Rectangle rect, int radius)
        {
            int d    = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
