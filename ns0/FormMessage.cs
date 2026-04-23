using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x0200005E RID: 94
	public partial class FormMessage : Form
	{
		// Token: 0x06000312 RID: 786 RVA: 0x0002BE40 File Offset: 0x0002A040
		public FormMessage(Exception exception_0)
		{
			this.InitializeComponent();
			Form1.Main.bool_7 = true;
			Form1.Main.Hide();
			Form1.Main.Opacity = 0.0;
			this.label1.Text = exception_0.Message;
			SystemSounds.Hand.Play();
			base.TopMost = true;
			base.ShowDialog();
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0002BEAC File Offset: 0x0002A0AC
		public FormMessage(string string_0)
		{
			this.InitializeComponent();
			Form1.Main.bool_7 = true;
			Form1.Main.Hide();
			Form1.Main.Opacity = 0.0;
			this.label1.Text = string_0;
			SystemSounds.Hand.Play();
			base.TopMost = true;
			base.ShowDialog();
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00004963 File Offset: 0x00002B63
		private void buttonOK_Click(object sender, EventArgs e)
		{
			Form1.Main.bool_7 = false;
			Form1.Main.Opacity = 1.0;
			Form1.Main.Show();
			base.Close();
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00004993 File Offset: 0x00002B93
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.bool_0 = true;
				this.point_0 = Cursor.Position;
				this.point_1 = base.Location;
			}
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0002BF14 File Offset: 0x0002A114
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.bool_0)
			{
				Point position = Cursor.Position;
				base.Location = new Point(this.point_1.X + (position.X - this.point_0.X), this.point_1.Y + (position.Y - this.point_0.Y));
			}
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000049C0 File Offset: 0x00002BC0
		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.bool_0 = false;
			}
		}

		// Token: 0x040003F2 RID: 1010
		private Point point_0;

		// Token: 0x040003F3 RID: 1011
		private Point point_1;

		// Token: 0x040003F4 RID: 1012
		private bool bool_0;
	}
}
