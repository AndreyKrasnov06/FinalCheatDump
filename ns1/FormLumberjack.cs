using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	// Token: 0x0200005D RID: 93
	public partial class FormLumberjack : GForm0
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000307 RID: 775 RVA: 0x000048F3 File Offset: 0x00002AF3
		// (set) Token: 0x06000308 RID: 776 RVA: 0x000048FA File Offset: 0x00002AFA
		public static FormLumberjack Main { get; private set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000309 RID: 777 RVA: 0x00004902 File Offset: 0x00002B02
		// (set) Token: 0x0600030A RID: 778 RVA: 0x00004909 File Offset: 0x00002B09
		public static bool IsPressE { get; private set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600030B RID: 779 RVA: 0x00004911 File Offset: 0x00002B11
		// (set) Token: 0x0600030C RID: 780 RVA: 0x00004918 File Offset: 0x00002B18
		public static bool IsAutoRunning { get; private set; }

		// Token: 0x0600030D RID: 781 RVA: 0x0002AD88 File Offset: 0x00028F88
		public FormLumberjack()
		{
			this.InitializeComponent();
			FormLumberjack.Main = this;
			FormLumberjack.IsPressE = true;
			FormLumberjack.IsAutoRunning = true;
			this.SpeedSpam.Value = 100;
			this.SpeedClick.Value = 50;
			this.toggleButton_PressE.Checked = FormLumberjack.IsPressE;
			this.toggleButton_AutoRunning.Checked = FormLumberjack.IsAutoRunning;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00004920 File Offset: 0x00002B20
		private void toggleButton_PressE_CheckedChanged(object sender, EventArgs e)
		{
			FormLumberjack.IsPressE = this.toggleButton_PressE.Checked;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00004932 File Offset: 0x00002B32
		private void toggleButton_AutoRunning_CheckedChanged(object sender, EventArgs e)
		{
			FormLumberjack.IsAutoRunning = this.toggleButton_AutoRunning.Checked;
		}

		// Token: 0x040003DA RID: 986
		[CompilerGenerated]
		private static FormLumberjack formLumberjack_0;

		// Token: 0x040003DB RID: 987
		[CompilerGenerated]
		private static bool bool_0;

		// Token: 0x040003DC RID: 988
		[CompilerGenerated]
		private static bool bool_1;
	}
}
