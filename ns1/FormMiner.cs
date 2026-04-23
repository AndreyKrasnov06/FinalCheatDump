using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	// Token: 0x0200005F RID: 95
	public partial class FormMiner : GForm0
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600031A RID: 794 RVA: 0x000049F5 File Offset: 0x00002BF5
		// (set) Token: 0x0600031B RID: 795 RVA: 0x000049FC File Offset: 0x00002BFC
		public static FormMiner Main { get; private set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600031C RID: 796 RVA: 0x00004A04 File Offset: 0x00002C04
		// (set) Token: 0x0600031D RID: 797 RVA: 0x00004A0B File Offset: 0x00002C0B
		public static bool IsPressE { get; private set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00004A13 File Offset: 0x00002C13
		// (set) Token: 0x0600031F RID: 799 RVA: 0x00004A1A File Offset: 0x00002C1A
		public static bool IsAutoRunning { get; private set; }

		// Token: 0x06000320 RID: 800 RVA: 0x0002C5A8 File Offset: 0x0002A7A8
		public FormMiner()
		{
			this.InitializeComponent();
			FormMiner.Main = this;
			FormMiner.IsPressE = true;
			FormMiner.IsAutoRunning = true;
			this.SpeedSpam.Value = 100;
			this.SpeedClick.Value = 60;
			this.toggleButton_PressE.Checked = FormMiner.IsPressE;
			this.toggleButton_AutoRunning.Checked = FormMiner.IsAutoRunning;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00004A22 File Offset: 0x00002C22
		private void toggleButton_PressE_CheckedChanged(object sender, EventArgs e)
		{
			FormMiner.IsPressE = this.toggleButton_PressE.Checked;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00004A34 File Offset: 0x00002C34
		private void toggleButton_AutoRunning_CheckedChanged(object sender, EventArgs e)
		{
			FormMiner.IsAutoRunning = this.toggleButton_AutoRunning.Checked;
		}

		// Token: 0x040003FC RID: 1020
		[CompilerGenerated]
		private static FormMiner formMiner_0;

		// Token: 0x040003FD RID: 1021
		[CompilerGenerated]
		private static bool bool_0;

		// Token: 0x040003FE RID: 1022
		[CompilerGenerated]
		private static bool bool_1;
	}
}
