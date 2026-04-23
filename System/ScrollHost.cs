using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace System
{
	// Token: 0x02000024 RID: 36
	[DesignerCategory("Code")]
	public sealed class ScrollHost : UserControl
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00003691 File Offset: 0x00001891
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00014454 File Offset: 0x00012654
		[DefaultValue(4)]
		public int ScrollBarRightGap
		{
			get
			{
				return this._scrollBarRightGap;
			}
			set
			{
				int num = ((value < 0) ? 0 : value);
				if (num == this._scrollBarRightGap)
				{
					return;
				}
				this._scrollBarRightGap = num;
				this.UpdateLayoutPaddingRight();
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00014484 File Offset: 0x00012684
		public ScrollHost()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this._bar = new global::System.ScrollBar
			{
				Dock = DockStyle.Right,
				Margin = new Padding(0),
				Visible = false
			};
			this._viewport = new ScrollHost.DoubleBufferedPanel
			{
				Dock = DockStyle.Fill,
				Padding = new Padding(0),
				BackColor = Color.FromArgb(22, 22, 22)
			};
			this._content = new Panel
			{
				Location = new Point(0, 0),
				Width = 100,
				Height = 0,
				BackColor = Color.FromArgb(22, 22, 22)
			};
			this._content.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.UpdateLayoutPaddingRight();
			this._viewport.Controls.Add(this._content);
			base.Controls.Add(this._viewport);
			base.Controls.Add(this._bar);
			this._bar.ValueChanged += delegate(object sender, EventArgs e)
			{
				this.UpdateContentLocation();
			};
			this._viewport.MouseWheel += delegate(object sender, MouseEventArgs e)
			{
				this.ScrollBy(-Math.Sign(e.Delta) * this._bar.SmallChange);
			};
			this._content.MouseWheel += delegate(object sender, MouseEventArgs e)
			{
				this.ScrollBy(-Math.Sign(e.Delta) * this._bar.SmallChange);
			};
			base.SizeChanged += delegate(object sender, EventArgs e)
			{
				this.RefreshMetrics();
			};
			this._content.ControlAdded += delegate(object sender, ControlEventArgs e)
			{
				this.WireChildEvents();
			};
			this._content.ControlRemoved += delegate(object sender, ControlEventArgs e)
			{
				this.RefreshMetrics();
			};
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00003699 File Offset: 0x00001899
		[Browsable(false)]
		public Control ContentContainer
		{
			get
			{
				return this._content;
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00014608 File Offset: 0x00012808
		public void SetContent(Control control)
		{
			this._content.Controls.Clear();
			Form form = control as Form;
			if (form != null)
			{
				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;
				form.Show();
				control = form;
			}
			control.Dock = DockStyle.Top;
			this._content.Controls.Add(control);
			this.RefreshMetrics();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00014664 File Offset: 0x00012864
		public void SetContent(Form form)
		{
			this._content.Controls.Clear();
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Show();
			form.Dock = DockStyle.Top;
			this._content.Controls.Add(form);
			this.RefreshMetrics();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000146B4 File Offset: 0x000128B4
		private void WireChildEvents()
		{
			foreach (object obj in this._content.Controls)
			{
				((Control)obj).SizeChanged += delegate(object sender, EventArgs e)
				{
					this.RefreshMetrics();
				};
			}
			this.RefreshMetrics();
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000036A1 File Offset: 0x000018A1
		private void ScrollBy(int dy)
		{
			if (!this._bar.Visible)
			{
				return;
			}
			this._bar.Value = this._bar.Value + dy;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00014724 File Offset: 0x00012924
		private void RefreshMetrics()
		{
			int height = this._viewport.ClientSize.Height;
			this._content.Width = this._viewport.ClientSize.Width;
			int num = (from Control control_0 in this._content.Controls
				select control_0.Bottom).DefaultIfEmpty(0).Max();
			this._content.Height = num;
			this._bar.ContentSize = num;
			this._bar.ViewportSize = height;
			this._bar.Visible = num > height;
			this.UpdateContentLocation();
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000036C9 File Offset: 0x000018C9
		private void UpdateContentLocation()
		{
			this._content.Location = new Point(0, -this._bar.Value);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000147DC File Offset: 0x000129DC
		private void UpdateLayoutPaddingRight()
		{
			base.Padding = new Padding(base.Padding.Left, base.Padding.Top, this._scrollBarRightGap, base.Padding.Bottom);
			if (!base.IsHandleCreated)
			{
				return;
			}
			this.RefreshMetrics();
		}

		// Token: 0x040001B2 RID: 434
		private readonly Panel _viewport;

		// Token: 0x040001B3 RID: 435
		private readonly Panel _content;

		// Token: 0x040001B4 RID: 436
		private readonly global::System.ScrollBar _bar;

		// Token: 0x040001B5 RID: 437
		private int _scrollBarRightGap = 4;

		// Token: 0x02000025 RID: 37
		private sealed class DoubleBufferedPanel : Panel
		{
			// Token: 0x0600014B RID: 331 RVA: 0x00003720 File Offset: 0x00001920
			public DoubleBufferedPanel()
			{
				this.DoubleBuffered = true;
			}
		}
	}
}
