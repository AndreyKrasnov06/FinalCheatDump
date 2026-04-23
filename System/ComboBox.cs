using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace System
{
	// Token: 0x0200000D RID: 13
	[DesignerCategory("Code")]
	[DefaultEvent("SelectedIndexChanged")]
	public sealed class ComboBox : Control
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002C20 File Offset: 0x00000E20
		private bool IsDesignHost
		{
			get
			{
				ISite site = this.Site;
				return (site != null && site.DesignMode) || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00005BCC File Offset: 0x00003DCC
		public ComboBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.Font = new Font("Verdana", 12f, FontStyle.Regular, GraphicsUnit.Point);
			base.Size = new Size(210, this._headerHeight);
			this.Cursor = Cursors.Hand;
			base.TabStop = false;
			this.ForeColor = global::System.ComboBox.Fore;
			this.BackColor = Color.Transparent;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002C1B File Offset: 0x00000E1B
		protected override void OnPaintBackground(PaintEventArgs paintEventArgs_0)
		{
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002C40 File Offset: 0x00000E40
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002C48 File Offset: 0x00000E48
		[Category("Appearance")]
		[DisplayName("FillColor")]
		[Description("Цвет фона закрытого состояния контрола. Для наведения и нажатия автоматически вычисляются близкие оттенки.")]
		public Color FillColor
		{
			get
			{
				return this._backNormal;
			}
			set
			{
				this._backNormal = value;
				this._backHover = Color.FromArgb(37, 37, 37);
				this._backPressed = Color.FromArgb(37, 37, 37);
				base.Invalidate();
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002C79 File Offset: 0x00000E79
		public void ResetFillColor()
		{
			this.FillColor = global::System.ComboBox.DefaultFill;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002C86 File Offset: 0x00000E86
		public bool ShouldSerializeFillColor()
		{
			return this._backNormal != global::System.ComboBox.DefaultFill;
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002C98 File Offset: 0x00000E98
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IList<string> Items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002CA0 File Offset: 0x00000EA0
		[Category("Data")]
		[DisplayName("Items")]
		[Description("Список элементов для отображения в выпадающем списке.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", typeof(UITypeEditor))]
		public StringCollection ItemsDesign
		{
			get
			{
				return this._itemsDesign;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002CA8 File Offset: 0x00000EA8
		[Browsable(false)]
		public string SelectedItem
		{
			get
			{
				if (this._selectedIndex >= 0 && this._selectedIndex < this._items.Count)
				{
					return this._items[this._selectedIndex];
				}
				return null;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002CD9 File Offset: 0x00000ED9
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00005CA4 File Offset: 0x00003EA4
		[DefaultValue(-1)]
		[Category("Behavior")]
		public int SelectedIndex
		{
			get
			{
				return this._selectedIndex;
			}
			set
			{
				if (value < -1)
				{
					value = -1;
				}
				this._requestedIndex = value;
				if (this._items.Count == 0)
				{
					this._selectedIndex = -1;
					base.Invalidate();
					return;
				}
				if (value >= this._items.Count)
				{
					if (this.IsDesignHost)
					{
						this._selectedIndex = this._items.Count - 1;
						base.Invalidate();
						return;
					}
					throw new ArgumentOutOfRangeException("value");
				}
				else
				{
					this._selectedIndex = value;
					base.Invalidate();
					EventHandler selectedIndexChanged = this.SelectedIndexChanged;
					if (selectedIndexChanged == null)
					{
						return;
					}
					selectedIndexChanged(this, EventArgs.Empty);
					return;
				}
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002CE1 File Offset: 0x00000EE1
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002CE9 File Offset: 0x00000EE9
		[DefaultValue(32)]
		[Category("Appearance")]
		public int ItemHeight
		{
			get
			{
				return this._rowHeight;
			}
			set
			{
				this._rowHeight = Math.Max(this.Font.Height + 4, value);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002D04 File Offset: 0x00000F04
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00002D0C File Offset: 0x00000F0C
		[DefaultValue(36)]
		[Category("Appearance")]
		public int HeaderHeight
		{
			get
			{
				return this._headerHeight;
			}
			set
			{
				this._headerHeight = Math.Max(this.Font.Height + 6, value);
				base.Height = this._headerHeight;
				base.Invalidate();
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000048 RID: 72 RVA: 0x00005D38 File Offset: 0x00003F38
		// (remove) Token: 0x06000049 RID: 73 RVA: 0x00005D70 File Offset: 0x00003F70
		public event EventHandler SelectedIndexChanged;

		// Token: 0x0600004A RID: 74 RVA: 0x00005DA8 File Offset: 0x00003FA8
		public void AddRange(IEnumerable<string> items)
		{
			if (items == null)
			{
				return;
			}
			foreach (string text in items.Where((string string_0) => string_0 != null))
			{
				this._itemsDesign.Add(text);
			}
			this.SyncFromDesign();
			base.Invalidate();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002D39 File Offset: 0x00000F39
		public void Clear()
		{
			this._itemsDesign.Clear();
			this._items.Clear();
			this._selectedIndex = -1;
			base.Invalidate();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002C1D File Offset: 0x00000E1D
		protected override bool IsInputKey(Keys keyData)
		{
			return false;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002D5E File Offset: 0x00000F5E
		protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
		{
			keyEventArgs_0.Handled = true;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002D67 File Offset: 0x00000F67
		protected override void OnKeyPress(KeyPressEventArgs keyPressEventArgs_0)
		{
			keyPressEventArgs_0.Handled = true;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002D70 File Offset: 0x00000F70
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			return true;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002D73 File Offset: 0x00000F73
		protected override void OnMouseEnter(EventArgs eventArgs_0)
		{
			this._hover = true;
			base.Invalidate();
			base.OnMouseEnter(eventArgs_0);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002D89 File Offset: 0x00000F89
		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			this._hover = false;
			base.Invalidate();
			base.OnMouseLeave(eventArgs_0);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00005E2C File Offset: 0x0000402C
		protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
		{
			if (mouseEventArgs_0.Button != MouseButtons.Left)
			{
				return;
			}
			this._suppressMouseUp = true;
			if (this._dropDown != null && this._dropDown.Visible)
			{
				this.HideDropDown();
				return;
			}
			if (this._preventImmediateReopen)
			{
				this._preventImmediateReopen = false;
				return;
			}
			this.ShowDropDown();
			this._pressed = true;
			base.Invalidate();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002D9F File Offset: 0x00000F9F
		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			if (mevent.Button != MouseButtons.Left)
			{
				return;
			}
			if (this._suppressMouseUp)
			{
				this._suppressMouseUp = false;
				this._pressed = false;
				base.Invalidate();
				return;
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002DCC File Offset: 0x00000FCC
		protected override void OnLostFocus(EventArgs eventArgs_0)
		{
			base.OnLostFocus(eventArgs_0);
			this.HideDropDown();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002DDB File Offset: 0x00000FDB
		private void ToggleDropDown()
		{
			if (this._dropDown != null && this._dropDown.Visible)
			{
				this.HideDropDown();
				return;
			}
			this.ShowDropDown();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00005E90 File Offset: 0x00004090
		private void ShowDropDown()
		{
			this.SyncFromDesign();
			if (this._items.Count == 0)
			{
				return;
			}
			this.EnsureDropDownCreated();
			this._host.Sync(this._items, this._selectedIndex, this._rowHeight, this._headerHeight, this.Font);
			Point point = base.PointToScreen(new Point(0, base.Height));
			this._dropDown.Show(point);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002DFF File Offset: 0x00000FFF
		private void HideDropDown()
		{
			if (this._dropDown == null)
			{
				return;
			}
			this._dropDown.Close();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00005F00 File Offset: 0x00004100
		private void EnsureDropDownCreated()
		{
			if (this._dropDown != null)
			{
				return;
			}
			this._host = new global::System.ComboBox.PopupHost(delegate(int idx)
			{
				this.SelectedIndex = idx;
				this.HideDropDown();
			}, new Action(this.HideDropDown));
			ToolStripControlHost toolStripControlHost = new ToolStripControlHost(this._host)
			{
				Margin = Padding.Empty,
				Padding = Padding.Empty,
				AutoSize = false
			};
			this._dropDown = new ToolStripDropDown
			{
				AutoClose = true,
				Margin = Padding.Empty,
				Padding = Padding.Empty,
				DropShadowEnabled = true,
				BackColor = global::System.ComboBox.DropBack
			};
			this._dropDown.Items.Add(toolStripControlHost);
			this._dropDown.Closed += delegate(object sender, ToolStripDropDownClosedEventArgs e)
			{
				this._pressed = false;
				base.Invalidate();
			};
			this._dropDown.Opened += delegate(object sender, EventArgs e)
			{
				int width = base.Width;
				int num = Math.Min(this._items.Count, 8) * this._rowHeight;
				if (num <= 0)
				{
					num = this._rowHeight;
				}
				this._host.Size = new Size(width, num);
				((ToolStripControlHost)this._dropDown.Items[0]).Size = this._host.Size;
			};
			this._dropDown.Closing += delegate(object sender, ToolStripDropDownClosingEventArgs e)
			{
				if (e.CloseReason != ToolStripDropDownCloseReason.AppClicked)
				{
					this._preventImmediateReopen = false;
					return;
				}
				if (base.RectangleToScreen(new Rectangle(0, 0, base.Width, base.Height)).Contains(Control.MousePosition))
				{
					this._preventImmediateReopen = true;
					base.BeginInvoke(new Action(delegate
					{
						this._preventImmediateReopen = false;
					}));
					return;
				}
				this._preventImmediateReopen = false;
			};
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00005FF4 File Offset: 0x000041F4
		protected override void OnPaint(PaintEventArgs paintEventArgs_0)
		{
			this.SyncFromDesign();
			Graphics graphics = paintEventArgs_0.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
			using (SolidBrush solidBrush = new SolidBrush(this._pressed ? this._backPressed : (this._hover ? this._backHover : this._backNormal)))
			{
				using (Pen pen = new Pen(global::System.ComboBox.BorderColor))
				{
					graphics.FillRectangle(solidBrush, rectangle);
					graphics.DrawRectangle(pen, rectangle);
				}
			}
			string text = this.SelectedItem ?? string.Empty;
			Rectangle rectangle2 = new Rectangle(10, 0, rectangle.Width - 40, rectangle.Height);
			using (StringFormat stringFormat = new StringFormat
			{
				LineAlignment = StringAlignment.Center,
				Trimming = StringTrimming.EllipsisCharacter
			})
			{
				using (SolidBrush solidBrush2 = new SolidBrush(global::System.ComboBox.Fore))
				{
					graphics.DrawString(text, this.Font, solidBrush2, rectangle2, stringFormat);
				}
			}
			int num = rectangle.Right - 18;
			int num2 = rectangle.Top + rectangle.Height / 2;
			global::System.ComboBox.DrawChevron(graphics, new Point(num, num2), 6, (this._dropDown == null || !this._dropDown.Visible) ? global::System.ComboBox.Direction.Down : global::System.ComboBox.Direction.Up);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006190 File Offset: 0x00004390
		private static void DrawChevron(Graphics graphics_0, Point center, int size, global::System.ComboBox.Direction dir)
		{
			int num = ((dir == global::System.ComboBox.Direction.Down) ? 1 : (-1));
			Point point = new Point(center.X - size, center.Y - num * size / 2);
			Point point2 = new Point(center.X, center.Y + num * size / 2);
			Point point3 = new Point(center.X + size, center.Y - num * size / 2);
			using (Pen pen = new Pen(global::System.ComboBox.Fore, 2f))
			{
				graphics_0.DrawLines(pen, new Point[] { point, point2, point3 });
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00006250 File Offset: 0x00004450
		private void SyncFromDesign()
		{
			this._items.Clear();
			foreach (string text in this._itemsDesign)
			{
				if (!string.IsNullOrEmpty(text))
				{
					this._items.Add(text);
				}
			}
			if (this._items.Count == 0)
			{
				this._selectedIndex = -1;
				return;
			}
			if (this._requestedIndex >= 0 && this._requestedIndex < this._items.Count)
			{
				this._selectedIndex = this._requestedIndex;
				return;
			}
			if (this._selectedIndex < 0 || this._selectedIndex >= this._items.Count)
			{
				this._selectedIndex = 0;
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002E15 File Offset: 0x00001015
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.SyncFromDesign();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002E23 File Offset: 0x00001023
		private static Color AdjustBrightness(Color color_0, int delta)
		{
			return Color.FromArgb((int)color_0.A, global::System.ComboBox.smethod_0((int)color_0.R + delta), global::System.ComboBox.smethod_0((int)color_0.G + delta), global::System.ComboBox.smethod_0((int)color_0.B + delta));
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002E82 File Offset: 0x00001082
		[CompilerGenerated]
		internal static int smethod_0(int int_0)
		{
			if (int_0 < 0)
			{
				return 0;
			}
			if (int_0 <= 255)
			{
				return int_0;
			}
			return 255;
		}

		// Token: 0x0400001D RID: 29
		private readonly List<string> _items = new List<string>();

		// Token: 0x0400001E RID: 30
		private readonly StringCollection _itemsDesign = new StringCollection();

		// Token: 0x0400001F RID: 31
		private int _selectedIndex = -1;

		// Token: 0x04000020 RID: 32
		private bool _hover;

		// Token: 0x04000021 RID: 33
		private bool _pressed;

		// Token: 0x04000022 RID: 34
		private ToolStripDropDown _dropDown;

		// Token: 0x04000023 RID: 35
		private global::System.ComboBox.PopupHost _host;

		// Token: 0x04000024 RID: 36
		private int _rowHeight = 32;

		// Token: 0x04000025 RID: 37
		private int _headerHeight = 36;

		// Token: 0x04000026 RID: 38
		private int _requestedIndex = -1;

		// Token: 0x04000027 RID: 39
		private bool _preventImmediateReopen;

		// Token: 0x04000028 RID: 40
		private bool _suppressMouseUp;

		// Token: 0x04000029 RID: 41
		private static readonly Color DefaultFill = Color.FromArgb(37, 37, 37);

		// Token: 0x0400002A RID: 42
		private Color _backNormal = global::System.ComboBox.DefaultFill;

		// Token: 0x0400002B RID: 43
		private Color _backHover = Color.FromArgb(37, 37, 37);

		// Token: 0x0400002C RID: 44
		private Color _backPressed = Color.FromArgb(37, 37, 37);

		// Token: 0x0400002D RID: 45
		private static readonly Color BorderColor = Color.FromArgb(70, 70, 70);

		// Token: 0x0400002E RID: 46
		private static readonly Color Fore = Color.White;

		// Token: 0x0400002F RID: 47
		private static readonly Color DropBack = Color.FromArgb(17, 17, 17);

		// Token: 0x04000030 RID: 48
		private static readonly Color DropHover = Color.FromArgb(37, 37, 37);

		// Token: 0x04000031 RID: 49
		private static readonly Color Separator = Color.FromArgb(60, 60, 60);

		// Token: 0x0200000E RID: 14
		private enum Direction
		{
			// Token: 0x04000034 RID: 52
			Down,
			// Token: 0x04000035 RID: 53
			Up
		}

		// Token: 0x0200000F RID: 15
		private sealed class PopupHost : Control
		{
			// Token: 0x06000065 RID: 101 RVA: 0x00006460 File Offset: 0x00004660
			public PopupHost(Action<int> onItemClicked, Action requestClose)
			{
				if (onItemClicked == null)
				{
					throw new ArgumentNullException("onItemClicked");
				}
				this._onItemClicked = onItemClicked;
				if (requestClose == null)
				{
					throw new ArgumentNullException("requestClose");
				}
				this._requestClose = requestClose;
				base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
				this.Cursor = Cursors.Hand;
				base.TabStop = false;
				this.BackColor = global::System.ComboBox.DropBack;
			}

			// Token: 0x06000066 RID: 102 RVA: 0x000064F4 File Offset: 0x000046F4
			public void Sync(IEnumerable<string> src, int selectedIndex, int rowHeight, int headerHeight, Font font)
			{
				this._items.Clear();
				this._items.AddRange(src.Where((string string_0) => string_0 != null));
				this._selectedIndex = Math.Min(Math.Max(-1, selectedIndex), this._items.Count - 1);
				this._rowHeight = rowHeight;
				this._headerHeight = headerHeight;
				this._font = font;
				base.Invalidate();
			}

			// Token: 0x06000067 RID: 103 RVA: 0x00006578 File Offset: 0x00004778
			protected override void OnMouseMove(MouseEventArgs mouseEventArgs_0)
			{
				base.OnMouseMove(mouseEventArgs_0);
				int num = this.HitTest(mouseEventArgs_0.Location);
				if (num != this._hoverIndex)
				{
					this._hoverIndex = num;
					base.Invalidate();
				}
			}

			// Token: 0x06000068 RID: 104 RVA: 0x00002E99 File Offset: 0x00001099
			protected override void OnMouseLeave(EventArgs eventArgs_0)
			{
				base.OnMouseLeave(eventArgs_0);
				this._hoverIndex = -1;
				base.Invalidate();
			}

			// Token: 0x06000069 RID: 105 RVA: 0x000065B0 File Offset: 0x000047B0
			protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
			{
				base.OnMouseDown(mouseEventArgs_0);
				if (mouseEventArgs_0.Button != MouseButtons.Left)
				{
					return;
				}
				int num = this.HitTest(mouseEventArgs_0.Location);
				if (num >= 0 && num < this._items.Count)
				{
					this._onItemClicked(num);
				}
			}

			// Token: 0x0600006A RID: 106 RVA: 0x00006600 File Offset: 0x00004800
			protected override void OnPaint(PaintEventArgs paintEventArgs_0)
			{
				Graphics graphics = paintEventArgs_0.Graphics;
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				using (SolidBrush solidBrush = new SolidBrush(global::System.ComboBox.DropBack))
				{
					using (Pen pen = new Pen(global::System.ComboBox.BorderColor))
					{
						graphics.FillRectangle(solidBrush, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
						graphics.DrawRectangle(pen, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
					}
				}
				for (int i = 0; i < this._items.Count; i++)
				{
					int num = i * this._rowHeight;
					Rectangle rectangle = new Rectangle(0, num, base.Width, this._rowHeight);
					if (i == this._hoverIndex)
					{
						using (SolidBrush solidBrush2 = new SolidBrush(global::System.ComboBox.DropHover))
						{
							graphics.FillRectangle(solidBrush2, rectangle);
						}
					}
					using (StringFormat stringFormat = new StringFormat
					{
						LineAlignment = StringAlignment.Center,
						Trimming = StringTrimming.EllipsisCharacter
					})
					{
						using (SolidBrush solidBrush3 = new SolidBrush(global::System.ComboBox.Fore))
						{
							graphics.DrawString(this._items[i], this._font, solidBrush3, new Rectangle(10, num, base.Width - 20, this._rowHeight), stringFormat);
						}
					}
					using (Pen pen2 = new Pen(global::System.ComboBox.Separator))
					{
						graphics.DrawLine(pen2, 0, num + this._rowHeight - 1, base.Width, num + this._rowHeight - 1);
					}
				}
			}

			// Token: 0x0600006B RID: 107 RVA: 0x000067F4 File Offset: 0x000049F4
			private int HitTest(Point point_0)
			{
				int num = point_0.Y / this._rowHeight;
				if (num >= 0 && num < this._items.Count)
				{
					return num;
				}
				return -1;
			}

			// Token: 0x04000036 RID: 54
			private readonly Action<int> _onItemClicked;

			// Token: 0x04000037 RID: 55
			private readonly Action _requestClose;

			// Token: 0x04000038 RID: 56
			private readonly List<string> _items = new List<string>();

			// Token: 0x04000039 RID: 57
			private int _hoverIndex = -1;

			// Token: 0x0400003A RID: 58
			private int _selectedIndex = -1;

			// Token: 0x0400003B RID: 59
			private int _rowHeight = 32;

			// Token: 0x0400003C RID: 60
			private int _headerHeight = 36;

			// Token: 0x0400003D RID: 61
			private Font _font;
		}
	}
}
