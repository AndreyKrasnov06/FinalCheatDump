using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace System
{
	// Token: 0x02000022 RID: 34
	[DefaultEvent("CheckedChanged")]
	[DefaultProperty("Checked")]
	public sealed class PinkCheckBox : Control
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x00013AEC File Offset: 0x00011CEC
		public PinkCheckBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.Selectable, false);
			base.TabStop = false;
			this.BackColor = Color.Transparent;
			base.Size = new Size(26, 26);
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x000033C8 File Offset: 0x000015C8
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x000033D0 File Offset: 0x000015D0
		[Category("Behavior")]
		[Description("Текущее состояние флажка.")]
		[DefaultValue(false)]
		public bool Checked
		{
			get
			{
				return this._checked;
			}
			set
			{
				if (this._checked == value)
				{
					return;
				}
				this._checked = value;
				base.Invalidate();
				if (this.CheckedChanged != null)
				{
					this.CheckedChanged(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000F7 RID: 247 RVA: 0x00013BA0 File Offset: 0x00011DA0
		// (remove) Token: 0x060000F8 RID: 248 RVA: 0x00013BD8 File Offset: 0x00011DD8
		[Category("Behavior")]
		[Description("Срабатывает при изменении состояния флажка.")]
		public event EventHandler CheckedChanged;

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00003402 File Offset: 0x00001602
		// (set) Token: 0x060000FA RID: 250 RVA: 0x0000340A File Offset: 0x0000160A
		[Category("Appearance")]
		[Description("Вертикальный сдвиг галочки в пикселях: отрицательный — вверх, положительный — вниз.")]
		[DefaultValue(0)]
		public int CheckMarkOffsetY { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00003413 File Offset: 0x00001613
		// (set) Token: 0x060000FC RID: 252 RVA: 0x0000341B File Offset: 0x0000161B
		[Category("Appearance")]
		[Description("Цвет фона в выключенном состоянии.")]
		public Color OffBackColor
		{
			get
			{
				return this._offBackColor;
			}
			set
			{
				this._offBackColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000FD RID: 253 RVA: 0x0000342A File Offset: 0x0000162A
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00003432 File Offset: 0x00001632
		[Category("Appearance")]
		[Description("Цвет рамки в выключенном состоянии.")]
		public Color OffBorderColor
		{
			get
			{
				return this._offBorderColor;
			}
			set
			{
				this._offBorderColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00003441 File Offset: 0x00001641
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00003449 File Offset: 0x00001649
		[Category("Appearance")]
		[Description("Цвет фона во включенном состоянии.")]
		public Color OnBackColor
		{
			get
			{
				return this._onBackColor;
			}
			set
			{
				this._onBackColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00003458 File Offset: 0x00001658
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00003460 File Offset: 0x00001660
		[Category("Appearance")]
		[Description("Цвет галочки во включенном состоянии.")]
		public Color CheckMarkColor
		{
			get
			{
				return this._checkColor;
			}
			set
			{
				this._checkColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000103 RID: 259 RVA: 0x0000346F File Offset: 0x0000166F
		// (set) Token: 0x06000104 RID: 260 RVA: 0x00003477 File Offset: 0x00001677
		[Category("Appearance")]
		[Description("Радиус скругления углов.")]
		[DefaultValue(8)]
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

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000105 RID: 261 RVA: 0x0000348C File Offset: 0x0000168C
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00003494 File Offset: 0x00001694
		[Category("Appearance")]
		[Description("Толщина линии галочки в логических пикселях, если AutoCheckThickness=false.")]
		[DefaultValue(2)]
		public int CheckMarkThickness
		{
			get
			{
				return this._checkThickness;
			}
			set
			{
				this._checkThickness = Math.Max(1, value);
				base.Invalidate();
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000107 RID: 263 RVA: 0x000034A9 File Offset: 0x000016A9
		// (set) Token: 0x06000108 RID: 264 RVA: 0x000034B1 File Offset: 0x000016B1
		[Category("Layout")]
		[Description("Внутренний отступ вокруг квадрата.")]
		[DefaultValue(2)]
		public int GlyphPadding { get; set; } = 2;

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000109 RID: 265 RVA: 0x000034BA File Offset: 0x000016BA
		// (set) Token: 0x0600010A RID: 266 RVA: 0x000034C2 File Offset: 0x000016C2
		[Category("Appearance")]
		[Description("Автоматически подбирать толщину галочки относительно размера квадрата.")]
		[DefaultValue(true)]
		public bool AutoCheckThickness { get; set; } = true;

		// Token: 0x0600010B RID: 267 RVA: 0x00013C10 File Offset: 0x00011E10
		protected override void OnPaint(PaintEventArgs paintEventArgs_0)
		{
			base.OnPaint(paintEventArgs_0);
			Graphics graphics = paintEventArgs_0.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			float num = (float)base.DeviceDpi / 96f;
			int num2 = (int)Math.Round((double)((float)this.GlyphPadding * num));
			Rectangle rectangle = Rectangle.Inflate(base.ClientRectangle, -num2, -num2);
			int num3 = (int)Math.Round((double)((float)this._cornerRadius * num));
			using (GraphicsPath graphicsPath = PinkCheckBox.RoundedRect(rectangle, num3))
			{
				if (this._checked)
				{
					using (SolidBrush solidBrush = new SolidBrush(this._onBackColor))
					{
						graphics.FillPath(solidBrush, graphicsPath);
						goto IL_00EA;
					}
				}
				using (SolidBrush solidBrush2 = new SolidBrush(this._offBackColor))
				{
					graphics.FillPath(solidBrush2, graphicsPath);
				}
				using (Pen pen = new Pen(this._offBorderColor))
				{
					graphics.DrawPath(pen, graphicsPath);
				}
			}
			IL_00EA:
			if (this._checked)
			{
				int num4 = (this.AutoCheckThickness ? Math.Max(2, (int)Math.Round((double)((float)Math.Min(rectangle.Width, rectangle.Height) * 0.1f))) : ((int)Math.Round((double)((float)this._checkThickness * num))));
				float num5 = (float)this.CheckMarkOffsetY * ((float)base.DeviceDpi / 96f);
				PinkCheckBox.DrawCheckmark(graphics, rectangle, this._checkColor, num4, num5);
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000034CB File Offset: 0x000016CB
		protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseDown(mouseEventArgs_0);
			if (mouseEventArgs_0.Button == MouseButtons.Left && base.Enabled)
			{
				this.Checked = !this.Checked;
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00006BB4 File Offset: 0x00004DB4
		private static GraphicsPath RoundedRect(Rectangle rectangle_0, int radius)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (radius <= 0)
			{
				graphicsPath.AddRectangle(rectangle_0);
				graphicsPath.CloseFigure();
				return graphicsPath;
			}
			int num = radius * 2;
			Rectangle rectangle = new Rectangle(rectangle_0.Location, new Size(num, num));
			graphicsPath.AddArc(rectangle, 180f, 90f);
			rectangle.X = rectangle_0.Right - num;
			graphicsPath.AddArc(rectangle, 270f, 90f);
			rectangle.Y = rectangle_0.Bottom - num;
			graphicsPath.AddArc(rectangle, 0f, 90f);
			rectangle.X = rectangle_0.Left;
			graphicsPath.AddArc(rectangle, 90f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00013DB0 File Offset: 0x00011FB0
		private static void DrawCheckmark(Graphics graphics_0, Rectangle rect, Color color, int thickness, float offsetY = 0f)
		{
			float num = (float)rect.Width;
			float num2 = (float)rect.Height;
			PointF pointF = new PointF((float)rect.Left + 0.26f * num, (float)rect.Top + 0.6f * num2);
			PointF pointF2 = new PointF((float)rect.Left + 0.46f * num, (float)rect.Top + 0.73f * num2);
			PointF pointF3 = new PointF((float)rect.Left + 0.78f * num, (float)rect.Top + 0.34f * num2);
			pointF.Y += offsetY;
			pointF2.Y += offsetY;
			pointF3.Y += offsetY;
			using (Pen pen = new Pen(color, (float)thickness))
			{
				pen.StartCap = LineCap.Round;
				pen.EndCap = LineCap.Round;
				pen.LineJoin = LineJoin.Round;
				graphics_0.DrawLines(pen, new PointF[] { pointF, pointF2, pointF3 });
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000034F8 File Offset: 0x000016F8
		public override Size GetPreferredSize(Size proposedSize)
		{
			return new Size(26, 26);
		}

		// Token: 0x04000197 RID: 407
		private bool _checked;

		// Token: 0x04000198 RID: 408
		private Color _offBackColor = Color.FromArgb(36, 36, 36);

		// Token: 0x04000199 RID: 409
		private Color _offBorderColor = Color.FromArgb(58, 58, 58);

		// Token: 0x0400019A RID: 410
		private Color _onBackColor = Color.FromArgb(236, 36, 104);

		// Token: 0x0400019B RID: 411
		private Color _checkColor = Color.White;

		// Token: 0x0400019C RID: 412
		private int _cornerRadius = 3;

		// Token: 0x0400019D RID: 413
		private int _checkThickness = 2;
	}
}
