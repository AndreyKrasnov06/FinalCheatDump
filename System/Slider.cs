using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace System
{
	// Token: 0x02000027 RID: 39
	[DesignerCategory("Code")]
	[DefaultEvent("ValueChanged")]
	public class Slider : UserControl
	{
		// Token: 0x0600014F RID: 335 RVA: 0x00014834 File Offset: 0x00012A34
		public Slider()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.Selectable, false);
			base.TabStop = false;
			base.Size = new Size(220, 28);
			this.BackColor = Color.FromArgb(24, 24, 24);
			this.ForeColor = this._valueColor;
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000150 RID: 336 RVA: 0x00003743 File Offset: 0x00001943
		// (set) Token: 0x06000151 RID: 337 RVA: 0x0000374B File Offset: 0x0000194B
		[Category("Behavior")]
		[DefaultValue(0)]
		public int Minimum
		{
			get
			{
				return this._minimum;
			}
			set
			{
				if (value > this._maximum)
				{
					this._maximum = value;
				}
				this._minimum = value;
				if (this._value < this._minimum)
				{
					this._value = this._minimum;
				}
				base.Invalidate();
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00003784 File Offset: 0x00001984
		// (set) Token: 0x06000153 RID: 339 RVA: 0x0000378C File Offset: 0x0000198C
		[Category("Behavior")]
		[DefaultValue(100)]
		public int Maximum
		{
			get
			{
				return this._maximum;
			}
			set
			{
				if (value < this._minimum)
				{
					this._minimum = value;
				}
				this._maximum = value;
				if (this._value > this._maximum)
				{
					this._value = this._maximum;
				}
				base.Invalidate();
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000154 RID: 340 RVA: 0x000037C5 File Offset: 0x000019C5
		// (set) Token: 0x06000155 RID: 341 RVA: 0x00014930 File Offset: 0x00012B30
		[Category("Behavior")]
		[DefaultValue(50)]
		public int Value
		{
			get
			{
				return this._value;
			}
			set
			{
				int num = Slider.Clamp(value, this._minimum, this._maximum);
				if (num != this._value)
				{
					this._value = num;
					base.Invalidate();
					this.OnValueChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000156 RID: 342 RVA: 0x000037CD File Offset: 0x000019CD
		// (set) Token: 0x06000157 RID: 343 RVA: 0x000037D5 File Offset: 0x000019D5
		[Category("Behavior")]
		[DefaultValue(1)]
		public int Step
		{
			get
			{
				return this._step;
			}
			set
			{
				this._step = Math.Max(1, value);
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000158 RID: 344 RVA: 0x000037E4 File Offset: 0x000019E4
		// (set) Token: 0x06000159 RID: 345 RVA: 0x000037EC File Offset: 0x000019EC
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "60, 60, 60")]
		public Color TrackColor
		{
			get
			{
				return this._trackColor;
			}
			set
			{
				this._trackColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600015A RID: 346 RVA: 0x000037FB File Offset: 0x000019FB
		// (set) Token: 0x0600015B RID: 347 RVA: 0x00003803 File Offset: 0x00001A03
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "232, 28, 90")]
		public Color FillColor
		{
			get
			{
				return this._fillColor;
			}
			set
			{
				this._fillColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00003812 File Offset: 0x00001A12
		// (set) Token: 0x0600015D RID: 349 RVA: 0x0000381A File Offset: 0x00001A1A
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "White")]
		public Color ThumbColor
		{
			get
			{
				return this._thumbColor;
			}
			set
			{
				this._thumbColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600015E RID: 350 RVA: 0x00003829 File Offset: 0x00001A29
		// (set) Token: 0x0600015F RID: 351 RVA: 0x00003831 File Offset: 0x00001A31
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "White")]
		public Color ValueColor
		{
			get
			{
				return this._valueColor;
			}
			set
			{
				this._valueColor = value;
				this.ForeColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00003847 File Offset: 0x00001A47
		// (set) Token: 0x06000161 RID: 353 RVA: 0x0000384F File Offset: 0x00001A4F
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool ShowValue
		{
			get
			{
				return this._showValue;
			}
			set
			{
				this._showValue = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000162 RID: 354 RVA: 0x0000385E File Offset: 0x00001A5E
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00003866 File Offset: 0x00001A66
		[Category("Appearance")]
		[DefaultValue(9)]
		public int ThumbRadius
		{
			get
			{
				return this._thumbRadius;
			}
			set
			{
				if (value < 2)
				{
					value = 2;
				}
				this._thumbRadius = value;
				base.Invalidate();
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000164 RID: 356 RVA: 0x00014974 File Offset: 0x00012B74
		// (remove) Token: 0x06000165 RID: 357 RVA: 0x000149AC File Offset: 0x00012BAC
		public event EventHandler ValueChanged;

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000166 RID: 358 RVA: 0x0000387C File Offset: 0x00001A7C
		// (set) Token: 0x06000167 RID: 359 RVA: 0x00003884 File Offset: 0x00001A84
		[Category("Appearance")]
		[DefaultValue(42)]
		public int ValueBoxWidth
		{
			get
			{
				return this._valueBoxWidth;
			}
			set
			{
				this._valueBoxWidth = Math.Max(24, value);
				base.Invalidate();
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000168 RID: 360 RVA: 0x0000389A File Offset: 0x00001A9A
		// (set) Token: 0x06000169 RID: 361 RVA: 0x000038A2 File Offset: 0x00001AA2
		[Category("Appearance")]
		[DefaultValue(6)]
		public int ValueBoxMargin
		{
			get
			{
				return this._valueBoxMargin;
			}
			set
			{
				this._valueBoxMargin = Math.Max(0, value);
				base.Invalidate();
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600016A RID: 362 RVA: 0x000038B7 File Offset: 0x00001AB7
		// (set) Token: 0x0600016B RID: 363 RVA: 0x000038BF File Offset: 0x00001ABF
		[Category("Appearance")]
		public Font ValueFont
		{
			get
			{
				return this._valueFont;
			}
			set
			{
				if (value != null)
				{
					this._valueFont = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600016C RID: 364 RVA: 0x000038D1 File Offset: 0x00001AD1
		// (set) Token: 0x0600016D RID: 365 RVA: 0x000038D9 File Offset: 0x00001AD9
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool AutoSizeValueBox
		{
			get
			{
				return this._autoSizeValueBox;
			}
			set
			{
				this._autoSizeValueBox = value;
				base.Invalidate();
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000149E4 File Offset: 0x00012BE4
		protected override void OnPaint(PaintEventArgs paintEventArgs_0)
		{
			base.OnPaint(paintEventArgs_0);
			Graphics graphics = paintEventArgs_0.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			if (this._autoSizeValueBox)
			{
				this._valueBoxWidth = (int)Math.Ceiling((double)graphics.MeasureString(this._maximum.ToString(), this._valueFont).Width) + this._valueBoxMargin * 2;
			}
			int width = base.Width;
			int height = base.Height;
			int num = height / 2;
			int num2 = Math.Max(this._trackPadding + this._thumbRadius + 8, width - this._valueBoxWidth);
			Rectangle rectangle = new Rectangle(num2, 0, width - num2, height);
			int num3 = this._trackPadding + this._thumbRadius;
			int num4 = Math.Min(width - this._trackPadding - this._thumbRadius, num2 - 4);
			if (num4 <= num3)
			{
				num4 = num3 + 1;
			}
			int num5 = num - this._trackHeight / 2;
			using (SolidBrush solidBrush = new SolidBrush(this.BackColor))
			{
				graphics.FillRectangle(solidBrush, base.ClientRectangle);
			}
			float num6 = ((this._maximum == this._minimum) ? 0f : ((float)(this._value - this._minimum) / (float)(this._maximum - this._minimum)));
			num6 = Math.Max(0f, Math.Min(1f, num6));
			int num7 = num3 + (int)Math.Round((double)(num6 * (float)(num4 - num3)));
			Rectangle rectangle2 = new Rectangle(num7 - this._thumbRadius, num - this._thumbRadius, this._thumbRadius * 2, this._thumbRadius * 2);
			Region clip = graphics.Clip;
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddEllipse(rectangle2);
				graphics.SetClip(graphicsPath, CombineMode.Exclude);
				using (SolidBrush solidBrush2 = new SolidBrush(this._trackColor))
				{
					graphics.FillRectangle(solidBrush2, num3, num5, num4 - num3, this._trackHeight);
				}
				using (SolidBrush solidBrush3 = new SolidBrush(this._fillColor))
				{
					graphics.FillRectangle(solidBrush3, num3, num5, Math.Max(0, num7 - num3), this._trackHeight);
				}
			}
			graphics.Clip = clip;
			using (SolidBrush solidBrush4 = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
			{
				graphics.FillEllipse(solidBrush4, rectangle2.X, rectangle2.Y + 2, rectangle2.Width, rectangle2.Height);
			}
			using (SolidBrush solidBrush5 = new SolidBrush(this._thumbColor))
			{
				graphics.FillEllipse(solidBrush5, rectangle2);
			}
			if (this._showValue)
			{
				string text = this._value.ToString();
				using (StringFormat stringFormat = new StringFormat
				{
					Alignment = StringAlignment.Near,
					LineAlignment = StringAlignment.Center
				})
				{
					using (SolidBrush solidBrush6 = new SolidBrush(this._valueColor))
					{
						Rectangle rectangle3 = new Rectangle(rectangle.X + this._valueBoxMargin, 0, Math.Max(0, rectangle.Width - this._valueBoxMargin), height);
						graphics.DrawString(text, this._valueFont, solidBrush6, rectangle3, stringFormat);
					}
				}
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000038E8 File Offset: 0x00001AE8
		protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseDown(mouseEventArgs_0);
			this._dragging = true;
			base.Capture = true;
			this.SetValueFromX(mouseEventArgs_0.X);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000390B File Offset: 0x00001B0B
		protected override void OnMouseMove(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseMove(mouseEventArgs_0);
			if (this._dragging)
			{
				this.SetValueFromX(mouseEventArgs_0.X);
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00003928 File Offset: 0x00001B28
		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			this._dragging = false;
			base.Capture = false;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00014D84 File Offset: 0x00012F84
		private void SetValueFromX(int int_0)
		{
			int num = Math.Max(this._trackPadding + this._thumbRadius + 8, base.Width - this._valueBoxWidth);
			int num2 = this._trackPadding + this._thumbRadius;
			int num3 = Math.Min(base.Width - this._trackPadding - this._thumbRadius, num - 4);
			if (num3 <= num2)
			{
				return;
			}
			int_0 = Slider.Clamp(int_0, num2, num3);
			float num4 = (float)(int_0 - num2) / (float)(num3 - num2);
			int num5 = this._minimum + (int)Math.Round((double)(num4 * (float)(this._maximum - this._minimum)));
			if (this._step > 1)
			{
				num5 = Slider.Clamp(this._minimum + (int)Math.Round((double)(num5 - this._minimum) / (double)this._step) * this._step, this._minimum, this._maximum);
			}
			this.Value = num5;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000393F File Offset: 0x00001B3F
		private static int Clamp(int int_0, int min, int max)
		{
			if (int_0 < min)
			{
				return min;
			}
			if (int_0 > max)
			{
				return max;
			}
			return int_0;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00014E64 File Offset: 0x00013064
		protected virtual void OnValueChanged(EventArgs eventArgs_0)
		{
			EventHandler valueChanged = this.ValueChanged;
			if (valueChanged != null)
			{
				valueChanged(this, eventArgs_0);
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000175 RID: 373 RVA: 0x00002C1D File Offset: 0x00000E1D
		protected override bool ShowFocusCues
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000394E File Offset: 0x00001B4E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000396D File Offset: 0x00001B6D
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.Font;
		}

		// Token: 0x040001B8 RID: 440
		private int _minimum;

		// Token: 0x040001B9 RID: 441
		private int _maximum = 100;

		// Token: 0x040001BA RID: 442
		private int _value = 50;

		// Token: 0x040001BB RID: 443
		private int _step = 1;

		// Token: 0x040001BC RID: 444
		private bool _dragging;

		// Token: 0x040001BD RID: 445
		private int _thumbRadius = 8;

		// Token: 0x040001BE RID: 446
		private int _trackHeight = 4;

		// Token: 0x040001BF RID: 447
		private int _trackPadding = 16;

		// Token: 0x040001C0 RID: 448
		private bool _showValue = true;

		// Token: 0x040001C1 RID: 449
		private Color _trackColor = Color.FromArgb(60, 60, 60);

		// Token: 0x040001C2 RID: 450
		private Color _fillColor = Color.FromArgb(232, 28, 90);

		// Token: 0x040001C3 RID: 451
		private Color _thumbColor = Color.White;

		// Token: 0x040001C4 RID: 452
		private Color _valueColor = Color.White;

		// Token: 0x040001C6 RID: 454
		private int _valueBoxWidth = 42;

		// Token: 0x040001C7 RID: 455
		private int _valueBoxMargin = 6;

		// Token: 0x040001C8 RID: 456
		private Font _valueFont = new Font("Verdana", 12f, FontStyle.Regular);

		// Token: 0x040001C9 RID: 457
		private bool _autoSizeValueBox = true;

		// Token: 0x040001CA RID: 458
		private IContainer components;
	}
}
