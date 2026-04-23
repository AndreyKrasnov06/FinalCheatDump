using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x0200000C RID: 12
	[DesignerCategory("Code")]
	public class GClass3 : CheckBox
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00005968 File Offset: 0x00003B68
		public GClass3()
		{
			this.MinimumSize = new Size(45, 22);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.Selectable, false);
			base.TabStop = false;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002B67 File Offset: 0x00000D67
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00002B6F File Offset: 0x00000D6F
		[Category("Toggle Button")]
		public Color OnBackColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002B7E File Offset: 0x00000D7E
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002B86 File Offset: 0x00000D86
		[Category("Toggle Button")]
		public Color OffBackColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002B95 File Offset: 0x00000D95
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00002B9D File Offset: 0x00000D9D
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Color OnToggleColor { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002BA6 File Offset: 0x00000DA6
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00002BAE File Offset: 0x00000DAE
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Color OffToggleColor { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002BB7 File Offset: 0x00000DB7
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00002BBF File Offset: 0x00000DBF
		[Category("Toggle Button")]
		[DefaultValue(true)]
		public bool SolidStyle
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002BCE File Offset: 0x00000DCE
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00002BD6 File Offset: 0x00000DD6
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "White")]
		public Color ThumbColor
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002BE5 File Offset: 0x00000DE5
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00002BED File Offset: 0x00000DED
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "50, 0, 0, 0")]
		public Color ThumbShadowColor
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002BFC File Offset: 0x00000DFC
		// (set) Token: 0x06000032 RID: 50 RVA: 0x00002C04 File Offset: 0x00000E04
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool UseThumbShadow
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002C13 File Offset: 0x00000E13
		// (set) Token: 0x06000034 RID: 52 RVA: 0x00002C1B File Offset: 0x00000E1B
		[Browsable(false)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000059E8 File Offset: 0x00003BE8
		private GraphicsPath method_0()
		{
			int num = base.Height - 1;
			Rectangle rectangle = new Rectangle(0, 0, num, num);
			Rectangle rectangle2 = new Rectangle(base.Width - num - 2, 0, num, num);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.StartFigure();
			graphicsPath.AddArc(rectangle, 90f, 180f);
			graphicsPath.AddArc(rectangle2, 270f, 180f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00005A50 File Offset: 0x00003C50
		protected override void OnPaint(PaintEventArgs paintEventArgs_0)
		{
			base.OnPaint(paintEventArgs_0);
			Graphics graphics = paintEventArgs_0.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			int num = base.Height - 5;
			Graphics graphics2 = graphics;
			Control parent = base.Parent;
			graphics2.Clear((parent != null) ? parent.BackColor : this.BackColor);
			GraphicsPath graphicsPath = this.method_0();
			if (base.Checked)
			{
				if (this.bool_1)
				{
					graphics.FillPath(new SolidBrush(this.color_0), graphicsPath);
				}
				else
				{
					graphics.DrawPath(new Pen(this.color_0, 2f), graphicsPath);
				}
			}
			else if (this.bool_1)
			{
				graphics.FillPath(new SolidBrush(this.color_1), graphicsPath);
			}
			else
			{
				graphics.DrawPath(new Pen(this.color_1, 2f), graphicsPath);
			}
			Rectangle rectangle = (base.Checked ? new Rectangle(base.Width - base.Height + 1, 1, num, num) : new Rectangle(2, 1, num, num));
			if (this.bool_0)
			{
				using (SolidBrush solidBrush = new SolidBrush(this.color_3))
				{
					graphics.FillEllipse(solidBrush, rectangle.X, rectangle.Y + 2, rectangle.Width, rectangle.Height);
				}
			}
			using (SolidBrush solidBrush2 = new SolidBrush(this.color_2))
			{
				graphics.FillEllipse(solidBrush2, rectangle);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002C1D File Offset: 0x00000E1D
		protected override bool ShowFocusCues
		{
			get
			{
				return false;
			}
		}

		// Token: 0x04000015 RID: 21
		private Color color_0 = Color.MediumSlateBlue;

		// Token: 0x04000016 RID: 22
		private Color color_1 = Color.Gray;

		// Token: 0x04000017 RID: 23
		private Color color_2 = Color.White;

		// Token: 0x04000018 RID: 24
		private Color color_3 = Color.FromArgb(50, 0, 0, 0);

		// Token: 0x04000019 RID: 25
		private bool bool_0 = true;

		// Token: 0x0400001A RID: 26
		private bool bool_1 = true;

		// Token: 0x0400001B RID: 27
		[CompilerGenerated]
		private Color color_4;

		// Token: 0x0400001C RID: 28
		[CompilerGenerated]
		private Color color_5;
	}
}
