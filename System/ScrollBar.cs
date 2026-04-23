using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace System
{
	// Token: 0x02000023 RID: 35
	[DesignerCategory("Code")]
	public sealed class ScrollBar : Control
	{
		// Token: 0x06000110 RID: 272 RVA: 0x00013EDC File Offset: 0x000120DC
		public ScrollBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.TabStop = false;
			base.Width = 12;
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00003503 File Offset: 0x00001703
		// (set) Token: 0x06000112 RID: 274 RVA: 0x0000350B File Offset: 0x0000170B
		[Browsable(false)]
		public int ContentSize
		{
			get
			{
				return this._contentSize;
			}
			set
			{
				this._contentSize = Math.Max(0, value);
				this.CoerceValue();
				base.Invalidate();
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00003526 File Offset: 0x00001726
		// (set) Token: 0x06000114 RID: 276 RVA: 0x0000352E File Offset: 0x0000172E
		[Browsable(false)]
		public int ViewportSize
		{
			get
			{
				return this._viewportSize;
			}
			set
			{
				this._viewportSize = Math.Max(0, value);
				this.CoerceValue();
				base.Invalidate();
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00003549 File Offset: 0x00001749
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00013F68 File Offset: 0x00012168
		[Browsable(false)]
		public int Value
		{
			get
			{
				return this._value;
			}
			set
			{
				int num = Math.Max(0, this._contentSize - this._viewportSize);
				int num2 = Math.Max(0, Math.Min(num, value));
				if (num2 != this._value)
				{
					this._value = num2;
					base.Invalidate();
					EventHandler valueChanged = this.ValueChanged;
					if (valueChanged == null)
					{
						return;
					}
					valueChanged(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00003551 File Offset: 0x00001751
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00003559 File Offset: 0x00001759
		[DefaultValue(40)]
		public int SmallChange { get; set; } = 40;

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00003562 File Offset: 0x00001762
		// (set) Token: 0x0600011A RID: 282 RVA: 0x0000356A File Offset: 0x0000176A
		[DefaultValue(200)]
		public int LargeChange { get; set; } = 200;

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00003573 File Offset: 0x00001773
		// (set) Token: 0x0600011C RID: 284 RVA: 0x0000357B File Offset: 0x0000177B
		[DefaultValue(typeof(Color), "40,43,48")]
		public Color TrackColor { get; set; } = Color.FromArgb(40, 43, 48);

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00003584 File Offset: 0x00001784
		// (set) Token: 0x0600011E RID: 286 RVA: 0x0000358C File Offset: 0x0000178C
		[DefaultValue(typeof(Color), "86,92,101")]
		public Color ThumbColor { get; set; } = Color.FromArgb(86, 92, 101);

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00003595 File Offset: 0x00001795
		// (set) Token: 0x06000120 RID: 288 RVA: 0x0000359D File Offset: 0x0000179D
		[DefaultValue(typeof(Color), "110,116,126")]
		public Color ThumbHoverColor { get; set; } = Color.FromArgb(110, 116, 126);

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000121 RID: 289 RVA: 0x000035A6 File Offset: 0x000017A6
		// (set) Token: 0x06000122 RID: 290 RVA: 0x000035AE File Offset: 0x000017AE
		[DefaultValue(4)]
		public int CornerRadius { get; set; } = 4;

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000123 RID: 291 RVA: 0x000035B7 File Offset: 0x000017B7
		// (set) Token: 0x06000124 RID: 292 RVA: 0x000035BF File Offset: 0x000017BF
		[DefaultValue(8)]
		public int BarWidth { get; set; } = 8;

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000125 RID: 293 RVA: 0x000035C8 File Offset: 0x000017C8
		// (set) Token: 0x06000126 RID: 294 RVA: 0x000035D0 File Offset: 0x000017D0
		[DefaultValue(0)]
		public int BarPaddingTop { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000127 RID: 295 RVA: 0x000035D9 File Offset: 0x000017D9
		// (set) Token: 0x06000128 RID: 296 RVA: 0x000035E1 File Offset: 0x000017E1
		[DefaultValue(8)]
		public int BarPaddingBottom { get; set; } = 8;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000129 RID: 297 RVA: 0x00013FC4 File Offset: 0x000121C4
		// (remove) Token: 0x0600012A RID: 298 RVA: 0x00013FFC File Offset: 0x000121FC
		public event EventHandler ValueChanged;

		// Token: 0x0600012B RID: 299 RVA: 0x00014034 File Offset: 0x00012234
		protected override void OnPaint(PaintEventArgs paintEventArgs_0)
		{
			base.OnPaint(paintEventArgs_0);
			paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Rectangle trackRect = this.GetTrackRect();
			using (SolidBrush solidBrush = new SolidBrush(this.TrackColor))
			{
				global::System.ScrollBar.FillRoundRect(paintEventArgs_0.Graphics, solidBrush, trackRect, this.CornerRadius);
			}
			if (!this.IsScrollable())
			{
				return;
			}
			Rectangle thumbRect = this.GetThumbRect();
			using (SolidBrush solidBrush2 = new SolidBrush((this._hover || this._dragging) ? this.ThumbHoverColor : this.ThumbColor))
			{
				global::System.ScrollBar.FillRoundRect(paintEventArgs_0.Graphics, solidBrush2, thumbRect, this.CornerRadius);
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000035EA File Offset: 0x000017EA
		protected override void OnMouseEnter(EventArgs eventArgs_0)
		{
			this._hover = true;
			base.Invalidate();
			base.OnMouseEnter(eventArgs_0);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00003600 File Offset: 0x00001800
		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			if (!this._dragging)
			{
				this._hover = false;
				base.Invalidate();
			}
			base.OnMouseLeave(eventArgs_0);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000361E File Offset: 0x0000181E
		protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
		{
			if (this.IsScrollable())
			{
				this.Value -= Math.Sign(mouseEventArgs_0.Delta) * this.SmallChange;
			}
			base.OnMouseWheel(mouseEventArgs_0);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000140F8 File Offset: 0x000122F8
		protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseDown(mouseEventArgs_0);
			if (!this.IsScrollable())
			{
				return;
			}
			Rectangle thumbRect = this.GetThumbRect();
			if (thumbRect.Contains(mouseEventArgs_0.Location))
			{
				this._dragging = true;
				this._dragOffset = mouseEventArgs_0.Y - thumbRect.Top;
				base.Capture = true;
				return;
			}
			if (mouseEventArgs_0.Y < thumbRect.Top)
			{
				this.Value -= this.LargeChange;
				return;
			}
			this.Value += this.LargeChange;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00014184 File Offset: 0x00012384
		protected override void OnMouseMove(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseMove(mouseEventArgs_0);
			if (this._dragging)
			{
				Rectangle trackRect = this.GetTrackRect();
				int thumbHeight = this.GetThumbHeight();
				int num = mouseEventArgs_0.Y - this._dragOffset;
				num = Math.Max(trackRect.Top, Math.Min(trackRect.Bottom - thumbHeight, num));
				int num2 = trackRect.Height - thumbHeight;
				int num3 = Math.Max(1, this._contentSize - this._viewportSize);
				float num4 = (float)(num - trackRect.Top) / (float)num2;
				this.Value = (int)Math.Round((double)(num4 * (float)num3));
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000364E File Offset: 0x0000184E
		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			if (this._dragging)
			{
				this._dragging = false;
				base.Capture = false;
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000366D File Offset: 0x0000186D
		private bool IsScrollable()
		{
			return this._contentSize > this._viewportSize && this._viewportSize > 0 && base.Height > 0;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0001421C File Offset: 0x0001241C
		private void CoerceValue()
		{
			int num = Math.Max(0, this._contentSize - this._viewportSize);
			if (this._value > num)
			{
				this._value = num;
			}
			if (this._value < 0)
			{
				this._value = 0;
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00014260 File Offset: 0x00012460
		private Rectangle GetTrackRect()
		{
			int num = (base.Width - this.BarWidth) / 2;
			int barPaddingTop = this.BarPaddingTop;
			int barPaddingBottom = this.BarPaddingBottom;
			return new Rectangle(num, barPaddingTop, this.BarWidth, base.Height - barPaddingTop - barPaddingBottom);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000142A0 File Offset: 0x000124A0
		private int GetThumbHeight()
		{
			if (!this.IsScrollable())
			{
				return 0;
			}
			int num = 24;
			Rectangle trackRect = this.GetTrackRect();
			int num2 = (int)Math.Round((double)((float)trackRect.Height * ((float)this.ViewportSize / (float)this.ContentSize)));
			return Math.Max(num, Math.Min(num2, trackRect.Height));
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000142F4 File Offset: 0x000124F4
		private Rectangle GetThumbRect()
		{
			Rectangle trackRect = this.GetTrackRect();
			int thumbHeight = this.GetThumbHeight();
			int num = trackRect.Height - thumbHeight;
			int num2 = Math.Max(1, this._contentSize - this._viewportSize);
			int num3 = trackRect.Top + ((num == 0) ? 0 : ((int)Math.Round((double)((float)num * ((float)this._value / (float)num2)))));
			return new Rectangle(trackRect.X, num3, trackRect.Width, thumbHeight);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00014368 File Offset: 0x00012568
		private static void FillRoundRect(Graphics graphics_0, Brush brush_0, Rectangle rectangle_0, int radius)
		{
			if (radius <= 0)
			{
				graphics_0.FillRectangle(brush_0, rectangle_0);
				return;
			}
			using (GraphicsPath graphicsPath = global::System.ScrollBar.RoundedRect(rectangle_0, radius))
			{
				graphics_0.FillPath(brush_0, graphicsPath);
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000143B0 File Offset: 0x000125B0
		private static GraphicsPath RoundedRect(Rectangle rectangle_0, int radius)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int num = radius * 2;
			graphicsPath.AddArc(rectangle_0.Left, rectangle_0.Top, num, num, 180f, 90f);
			graphicsPath.AddArc(rectangle_0.Right - num, rectangle_0.Top, num, num, 270f, 90f);
			graphicsPath.AddArc(rectangle_0.Right - num, rectangle_0.Bottom - num, num, num, 0f, 90f);
			graphicsPath.AddArc(rectangle_0.Left, rectangle_0.Bottom - num, num, num, 90f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		// Token: 0x040001A2 RID: 418
		private int _contentSize;

		// Token: 0x040001A3 RID: 419
		private int _viewportSize;

		// Token: 0x040001A4 RID: 420
		private int _value;

		// Token: 0x040001A5 RID: 421
		private bool _hover;

		// Token: 0x040001A6 RID: 422
		private bool _dragging;

		// Token: 0x040001A7 RID: 423
		private int _dragOffset;
	}
}
