using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	// Token: 0x0200005C RID: 92
	public partial class FormGym : GForm0
	{
		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060002FC RID: 764 RVA: 0x00004843 File Offset: 0x00002A43
		// (set) Token: 0x060002FD RID: 765 RVA: 0x0000484A File Offset: 0x00002A4A
		public static FormGym Main { get; private set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00004852 File Offset: 0x00002A52
		// (set) Token: 0x060002FF RID: 767 RVA: 0x00004859 File Offset: 0x00002A59
		public static bool IsPressE { get; private set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000300 RID: 768 RVA: 0x00004861 File Offset: 0x00002A61
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00004868 File Offset: 0x00002A68
		public static bool IsBackground { get; private set; }

		// Token: 0x06000302 RID: 770 RVA: 0x00004870 File Offset: 0x00002A70
		public FormGym()
		{
			this.InitializeComponent();
			FormGym.Main = this;
			FormGym.IsPressE = true;
			FormGym.IsBackground = false;
			this.toggleButton_PressE.Checked = FormGym.IsPressE;
			this.toggleButton_Background.Checked = FormGym.IsBackground;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x000048B0 File Offset: 0x00002AB0
		private void toggleButton_PressE_CheckedChanged(object sender, EventArgs e)
		{
			FormGym.IsPressE = this.toggleButton_PressE.Checked;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x000048C2 File Offset: 0x00002AC2
		private void toggleButton_Background_CheckedChanged(object sender, EventArgs e)
		{
			FormGym.IsBackground = this.toggleButton_Background.Checked;
		}

		// Token: 0x040003C8 RID: 968
		[CompilerGenerated]
		private static FormGym formGym_0;

		// Token: 0x040003C9 RID: 969
		[CompilerGenerated]
		private static bool bool_0;

		// Token: 0x040003CA RID: 970
		[CompilerGenerated]
		private static bool bool_1;
	}
}
