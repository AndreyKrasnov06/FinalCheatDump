using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace System
{
	// Token: 0x02000012 RID: 18
	[DefaultEvent("Click")]
	[DesignerCategory("Code")]
	public sealed class CommandButton : Control, IButtonControl
	{
		// Token: 0x06000072 RID: 114 RVA: 0x00006828 File Offset: 0x00004A28
		public CommandButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.Selectable, false);
			base.TabStop = false;
			this.Cursor = Cursors.Hand;
			this.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point);
			this.ForeColor = Color.WhiteSmoke;
			base.Size = new Size(170, 36);
			this.BackColor = Color.Transparent;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00002ED5 File Offset: 0x000010D5
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00002EDD File Offset: 0x000010DD
		[Category("Appearance")]
		[DefaultValue(1)]
		public int BorderThickness
		{
			get
			{
				return this._borderThickness;
			}
			set
			{
				this._borderThickness = Math.Max(0, value);
				base.Invalidate();
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00002EF2 File Offset: 0x000010F2
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00002EFA File Offset: 0x000010FA
		[Category("Appearance")]
		[DefaultValue(4)]
		public int CornerRadius
		{
			get
			{
				return this._cornerRadius;
			}
			set
			{
				this._cornerRadius = Math.Max(0, value);
				base.Invalidate();
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002F0F File Offset: 0x0000110F
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00002F17 File Offset: 0x00001117
		[Category("Layout")]
		[DefaultValue(12)]
		public int HorizontalPadding
		{
			get
			{
				return this._horizontalPadding;
			}
			set
			{
				this._horizontalPadding = Math.Max(0, value);
				base.Invalidate();
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00002F2C File Offset: 0x0000112C
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00002F34 File Offset: 0x00001134
		[Category("Appearance")]
		[DefaultValue(typeof(ContentAlignment), "MiddleLeft")]
		public ContentAlignment TextAlign
		{
			get
			{
				return this._textAlign;
			}
			set
			{
				this._textAlign = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00002F43 File Offset: 0x00001143
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00002F4B File Offset: 0x0000114B
		[Category("Appearance")]
		public Color BackColorNormal
		{
			get
			{
				return this._backNormal;
			}
			set
			{
				this._backNormal = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00002F5A File Offset: 0x0000115A
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00002F62 File Offset: 0x00001162
		[Category("Appearance")]
		public Color BackColorHover
		{
			get
			{
				return this._backHover;
			}
			set
			{
				this._backHover = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00002F71 File Offset: 0x00001171
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00002F79 File Offset: 0x00001179
		[Category("Appearance")]
		public Color BackColorPressed
		{
			get
			{
				return this._backPressed;
			}
			set
			{
				this._backPressed = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00002F88 File Offset: 0x00001188
		// (set) Token: 0x06000082 RID: 130 RVA: 0x00002F90 File Offset: 0x00001190
		[Category("Appearance")]
		public Color BorderColorNormal
		{
			get
			{
				return this._borderNormal;
			}
			set
			{
				this._borderNormal = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00002F9F File Offset: 0x0000119F
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00002FA7 File Offset: 0x000011A7
		[Category("Appearance")]
		public Color BorderColorHover
		{
			get
			{
				return this._borderHover;
			}
			set
			{
				this._borderHover = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00002FB6 File Offset: 0x000011B6
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00002FBE File Offset: 0x000011BE
		[Category("Appearance")]
		public Color BorderColorPressed
		{
			get
			{
				return this._borderPressed;
			}
			set
			{
				this._borderPressed = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00002FCD File Offset: 0x000011CD
		// (set) Token: 0x06000088 RID: 136 RVA: 0x00002FD5 File Offset: 0x000011D5
		[Category("Behavior")]
		[DefaultValue(typeof(DialogResult), "None")]
		public DialogResult DialogResult
		{
			get
			{
				return this._dialogResult;
			}
			set
			{
				this._dialogResult = value;
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000694C File Offset: 0x00004B4C
		protected override void OnPaint(PaintEventArgs paintEventArgs_0)
		{
			base.OnPaint(paintEventArgs_0);
			Graphics graphics = paintEventArgs_0.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.PixelOffsetMode = PixelOffsetMode.Half;
			Rectangle clientRectangle = base.ClientRectangle;
			if (clientRectangle.Width > 0 && clientRectangle.Height > 0)
			{
				bool enabled = base.Enabled;
				Color color = this._backNormal;
				Color color2 = this._borderNormal;
				Color color3 = (enabled ? this.ForeColor : this._foreDisabled);
				if (enabled)
				{
					if (this._pressed)
					{
						color = this._backPressed;
						color2 = this._borderPressed;
					}
					else if (this._hovered)
					{
						color = this._backHover;
						color2 = this._borderHover;
					}
				}
				using (GraphicsPath graphicsPath = CommandButton.CreateRoundRectPath(clientRectangle, this._cornerRadius))
				{
					using (SolidBrush solidBrush = new SolidBrush(color))
					{
						graphics.FillPath(solidBrush, graphicsPath);
					}
					if (this._borderThickness > 0)
					{
						using (GraphicsPath graphicsPath2 = CommandButton.CreateRoundRectPath(Rectangle.Inflate(clientRectangle, -this._borderThickness / 2, -this._borderThickness / 2), Math.Max(0, this._cornerRadius - 1)))
						{
							using (Pen pen = new Pen(color2, (float)this._borderThickness))
							{
								graphics.DrawPath(pen, graphicsPath2);
							}
						}
					}
				}
				TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix | CommandButton.ToTextFormatFlags(this._textAlign);
				Rectangle rectangle = Rectangle.Inflate(clientRectangle, -this._horizontalPadding, 0);
				TextRenderer.DrawText(graphics, this.Text, this.Font, rectangle, color3, textFormatFlags);
				if (this.Focused && this.ShowFocusCues && enabled)
				{
					Rectangle rectangle2 = Rectangle.Inflate(clientRectangle, -4, -4);
					ControlPaint.DrawFocusRectangle(paintEventArgs_0.Graphics, rectangle2);
				}
				return;
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00006B40 File Offset: 0x00004D40
		private static TextFormatFlags ToTextFormatFlags(ContentAlignment align)
		{
			if (align <= ContentAlignment.MiddleCenter)
			{
				switch (align)
				{
				case ContentAlignment.TopLeft:
					return TextFormatFlags.Default;
				case ContentAlignment.TopCenter:
					return TextFormatFlags.HorizontalCenter;
				case (ContentAlignment)3:
					break;
				case ContentAlignment.TopRight:
					return TextFormatFlags.Right;
				default:
					if (align == ContentAlignment.MiddleLeft)
					{
						return TextFormatFlags.VerticalCenter;
					}
					if (align == ContentAlignment.MiddleCenter)
					{
						return TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
					}
					break;
				}
			}
			else if (align <= ContentAlignment.BottomLeft)
			{
				if (align == ContentAlignment.MiddleRight)
				{
					return TextFormatFlags.Right | TextFormatFlags.VerticalCenter;
				}
				if (align == ContentAlignment.BottomLeft)
				{
					return TextFormatFlags.Bottom;
				}
			}
			else
			{
				if (align == ContentAlignment.BottomCenter)
				{
					return TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
				}
				if (align == ContentAlignment.BottomRight)
				{
					return TextFormatFlags.Bottom | TextFormatFlags.Right;
				}
			}
			return TextFormatFlags.VerticalCenter;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00006BB4 File Offset: 0x00004DB4
		private static GraphicsPath CreateRoundRectPath(Rectangle rect, int radius)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (radius <= 0)
			{
				graphicsPath.AddRectangle(rect);
				graphicsPath.CloseFigure();
				return graphicsPath;
			}
			int num = radius * 2;
			Rectangle rectangle = new Rectangle(rect.Location, new Size(num, num));
			graphicsPath.AddArc(rectangle, 180f, 90f);
			rectangle.X = rect.Right - num;
			graphicsPath.AddArc(rectangle, 270f, 90f);
			rectangle.Y = rect.Bottom - num;
			graphicsPath.AddArc(rectangle, 0f, 90f);
			rectangle.X = rect.Left;
			graphicsPath.AddArc(rectangle, 90f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00002FDE File Offset: 0x000011DE
		protected override void OnMouseEnter(EventArgs eventArgs_0)
		{
			base.OnMouseEnter(eventArgs_0);
			this._hovered = true;
			base.Invalidate();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00002FF4 File Offset: 0x000011F4
		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			base.OnMouseLeave(eventArgs_0);
			this._hovered = false;
			this._pressed = false;
			base.Invalidate();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003011 File Offset: 0x00001211
		protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseDown(mouseEventArgs_0);
			if (mouseEventArgs_0.Button == MouseButtons.Left && base.Enabled)
			{
				this._pressed = true;
				base.Focus();
				base.Invalidate();
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003043 File Offset: 0x00001243
		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			if (!base.Enabled)
			{
				return;
			}
			this._pressed = false;
			base.Invalidate();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003062 File Offset: 0x00001262
		protected override bool IsInputKey(Keys keyData)
		{
			return base.IsInputKey(keyData);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000306B File Offset: 0x0000126B
		protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
		{
			base.OnKeyDown(keyEventArgs_0);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003074 File Offset: 0x00001274
		protected override void OnKeyUp(KeyEventArgs keyEventArgs_0)
		{
			base.OnKeyUp(keyEventArgs_0);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00002C1B File Offset: 0x00000E1B
		public void NotifyDefault(bool value)
		{
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006C6C File Offset: 0x00004E6C
		public void PerformClick()
		{
			this.OnClick(EventArgs.Empty);
			Form form = base.FindForm();
			if (form != null && this._dialogResult != DialogResult.None)
			{
				form.DialogResult = this._dialogResult;
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000307D File Offset: 0x0000127D
		protected override AccessibleObject CreateAccessibilityInstance()
		{
			AccessibleObject accessibleObject = base.CreateAccessibilityInstance();
			base.AccessibleRole = AccessibleRole.PushButton;
			return accessibleObject;
		}

		// Token: 0x04000042 RID: 66
		private bool _hovered;

		// Token: 0x04000043 RID: 67
		private bool _pressed;

		// Token: 0x04000044 RID: 68
		private int _borderThickness = 1;

		// Token: 0x04000045 RID: 69
		private int _cornerRadius = 4;

		// Token: 0x04000046 RID: 70
		private int _horizontalPadding = 12;

		// Token: 0x04000047 RID: 71
		private ContentAlignment _textAlign = ContentAlignment.MiddleLeft;

		// Token: 0x04000048 RID: 72
		private Color _backNormal = Color.FromArgb(28, 28, 28);

		// Token: 0x04000049 RID: 73
		private Color _backHover = Color.FromArgb(36, 36, 36);

		// Token: 0x0400004A RID: 74
		private Color _backPressed = Color.FromArgb(18, 18, 18);

		// Token: 0x0400004B RID: 75
		private Color _borderNormal = Color.FromArgb(96, 96, 96);

		// Token: 0x0400004C RID: 76
		private Color _borderHover = Color.FromArgb(120, 120, 120);

		// Token: 0x0400004D RID: 77
		private Color _borderPressed = Color.FromArgb(160, 160, 160);

		// Token: 0x0400004E RID: 78
		private Color _foreDisabled = Color.FromArgb(150, 150, 150);

		// Token: 0x0400004F RID: 79
		private DialogResult _dialogResult;
	}
}
