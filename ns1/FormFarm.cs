using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	// Token: 0x0200005A RID: 90
	public partial class FormFarm : GForm0
	{
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060002CF RID: 719 RVA: 0x000045A7 File Offset: 0x000027A7
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x000045AE File Offset: 0x000027AE
		public static FormFarm Main { get; private set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x000045B6 File Offset: 0x000027B6
		// (set) Token: 0x060002D2 RID: 722 RVA: 0x000045BD File Offset: 0x000027BD
		public static bool IsPressE { get; private set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x000045C5 File Offset: 0x000027C5
		// (set) Token: 0x060002D4 RID: 724 RVA: 0x000045CC File Offset: 0x000027CC
		public static bool IsCaptcha { get; private set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x000045D4 File Offset: 0x000027D4
		// (set) Token: 0x060002D6 RID: 726 RVA: 0x000045DB File Offset: 0x000027DB
		public static bool IsOrange { get; private set; }

		// Token: 0x060002D7 RID: 727 RVA: 0x00027614 File Offset: 0x00025814
		public FormFarm()
		{
			this.InitializeComponent();
			FormFarm.Main = this;
			FormFarm.IsPressE = true;
			FormFarm.IsCaptcha = false;
			FormFarm.IsOrange = true;
			this.SpeedClick.Value = 60;
			this.toggleButton_PressE.Checked = FormFarm.IsPressE;
			this.toggleButton_Captcha.Checked = FormFarm.IsCaptcha;
			this.toggleButton_Captcha.Checked = FormFarm.IsOrange;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x000045E3 File Offset: 0x000027E3
		private void toggleButton_PressE_CheckedChanged(object sender, EventArgs e)
		{
			FormFarm.IsPressE = this.toggleButton_PressE.Checked;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x000045F5 File Offset: 0x000027F5
		private void toggleButton_Captcha_CheckedChanged(object sender, EventArgs e)
		{
			FormFarm.IsCaptcha = this.toggleButton_Captcha.Checked;
			if (FormFarm.IsCaptcha)
			{
				this.toggleButton_Orange.Checked = false;
				return;
			}
			this.toggleButton_Orange.Checked = true;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00004627 File Offset: 0x00002827
		private void toggleButton_Orange_CheckedChanged(object sender, EventArgs e)
		{
			FormFarm.IsOrange = this.toggleButton_Orange.Checked;
			if (FormFarm.IsOrange)
			{
				this.toggleButton_Captcha.Checked = false;
				return;
			}
			this.toggleButton_Captcha.Checked = true;
		}

		// Token: 0x04000387 RID: 903
		[CompilerGenerated]
		private static FormFarm formFarm_0;

		// Token: 0x04000388 RID: 904
		[CompilerGenerated]
		private static bool bool_0;

		// Token: 0x04000389 RID: 905
		[CompilerGenerated]
		private static bool bool_1;

		// Token: 0x0400038A RID: 906
		[CompilerGenerated]
		private static bool bool_2;
	}
}
