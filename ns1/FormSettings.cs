using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	// Token: 0x02000060 RID: 96
	public partial class FormSettings : GForm0
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000325 RID: 805 RVA: 0x00004A65 File Offset: 0x00002C65
		// (set) Token: 0x06000326 RID: 806 RVA: 0x00004A6C File Offset: 0x00002C6C
		public static FormSettings Main { get; private set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000327 RID: 807 RVA: 0x00004A74 File Offset: 0x00002C74
		// (set) Token: 0x06000328 RID: 808 RVA: 0x00004A7B File Offset: 0x00002C7B
		public static bool isSoundMute { get; private set; }

		// Token: 0x06000329 RID: 809 RVA: 0x00004A83 File Offset: 0x00002C83
		public FormSettings()
		{
			this.InitializeComponent();
			FormSettings.Main = this;
			FormSettings.isSoundMute = false;
			this.toggleButton_SoundMute.Checked = FormSettings.isSoundMute;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00004AAD File Offset: 0x00002CAD
		private void toggleButton_SoundMute_CheckedChanged(object sender, EventArgs e)
		{
			FormSettings.isSoundMute = this.toggleButton_SoundMute.Checked;
		}

		// Token: 0x04000414 RID: 1044
		[CompilerGenerated]
		private static FormSettings formSettings_0;

		// Token: 0x04000415 RID: 1045
		[CompilerGenerated]
		private static bool bool_0;
	}
}
