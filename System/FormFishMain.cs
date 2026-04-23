using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns0;

namespace System
{
	// Token: 0x02000017 RID: 23
	public partial class FormFishMain : Form
	{
		// Token: 0x060000B9 RID: 185 RVA: 0x00003192 File Offset: 0x00001392
		public FormFishMain()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00011958 File Offset: 0x0000FB58
		private void scrollHost1_Load(object sender, EventArgs e)
		{
			base.Controls.Add(this.scrollHost1);
			FormFishMain.fishContent.AutoScaleMode = AutoScaleMode.None;
			FormFishMain.fishContent.AutoSize = false;
			FormFishMain.fishContent.Margin = Padding.Empty;
			FormFishMain.fishContent.AutoScroll = false;
			FormFishMain.fishContent.Dock = DockStyle.Top;
			FormFishMain.fishContent.Height = FormFishMain.fishContent.AutoScrollMinSize.Height;
			this.scrollHost1.ScrollBarRightGap = 4;
			this.scrollHost1.SetContent(FormFishMain.fishContent);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000031A0 File Offset: 0x000013A0
		private void commandButton1_Click(object sender, EventArgs e)
		{
			FormFishMain.fishContent.SetAllPickUp(false);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000031AD File Offset: 0x000013AD
		private void commandButton2_Click(object sender, EventArgs e)
		{
			FormFishMain.fishContent.SetAllBack();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000031B9 File Offset: 0x000013B9
		private void commandButton3_Click(object sender, EventArgs e)
		{
			FormFishMain.fishContent.SetAllPickUp(true);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000031C6 File Offset: 0x000013C6
		private void commandButton4_Click(object sender, EventArgs e)
		{
			FormFishMain.fishContent.GetAllChecked();
			base.Hide();
			Form1.Main.bool_7 = false;
			Form1.Main.Show();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000031EE File Offset: 0x000013EE
		private void FormFishMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			base.Hide();
			Form1.Main.bool_7 = false;
			Form1.Main.Show();
		}

		// Token: 0x04000159 RID: 345
		public static readonly FishContent fishContent = new FishContent();
	}
}
