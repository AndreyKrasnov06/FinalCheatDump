using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	// Token: 0x0200005B RID: 91
	public partial class FormFishing : GForm0
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060002DD RID: 733 RVA: 0x00004678 File Offset: 0x00002878
		// (set) Token: 0x060002DE RID: 734 RVA: 0x0000467F File Offset: 0x0000287F
		public static FormFishing Main { get; private set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00004687 File Offset: 0x00002887
		// (set) Token: 0x060002E0 RID: 736 RVA: 0x0000468E File Offset: 0x0000288E
		public static bool IsShore { get; private set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x00004696 File Offset: 0x00002896
		// (set) Token: 0x060002E2 RID: 738 RVA: 0x0000469D File Offset: 0x0000289D
		public static bool IsOcean { get; private set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x000046A5 File Offset: 0x000028A5
		// (set) Token: 0x060002E4 RID: 740 RVA: 0x000046AC File Offset: 0x000028AC
		public static bool IsOverWeight { get; private set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x000046B4 File Offset: 0x000028B4
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x000046BB File Offset: 0x000028BB
		public static bool IsReuseBait { get; private set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x000046C3 File Offset: 0x000028C3
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x000046CA File Offset: 0x000028CA
		public static bool IsAnotherBait { get; private set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x000046D2 File Offset: 0x000028D2
		// (set) Token: 0x060002EA RID: 746 RVA: 0x000046D9 File Offset: 0x000028D9
		public static bool IsHandleNeeds { get; private set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060002EB RID: 747 RVA: 0x000046E1 File Offset: 0x000028E1
		// (set) Token: 0x060002EC RID: 748 RVA: 0x000046E8 File Offset: 0x000028E8
		public static bool IsTrunk { get; private set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060002ED RID: 749 RVA: 0x000046F0 File Offset: 0x000028F0
		// (set) Token: 0x060002EE RID: 750 RVA: 0x000046F7 File Offset: 0x000028F7
		public static Keys KeyInventory { get; set; }

		// Token: 0x060002EF RID: 751 RVA: 0x00028584 File Offset: 0x00026784
		public FormFishing()
		{
			this.InitializeComponent();
			FormFishing.Main = this;
			FormFishing.IsShore = true;
			FormFishing.IsOcean = false;
			FormFishing.IsOverWeight = true;
			FormFishing.IsReuseBait = true;
			FormFishing.IsAnotherBait = false;
			FormFishing.IsHandleNeeds = true;
			FormFishing.IsTrunk = false;
			this.SpeedClick.Value = 50;
			this.SpeedCast.Value = 80;
			this.toggleButton_Ocean.Checked = FormFishing.IsOcean;
			this.toggleButton_OverWeight.Checked = FormFishing.IsOverWeight;
			this.toggleButton_ReuseBait.Checked = FormFishing.IsReuseBait;
			this.toggleButton_AnotherBait.Checked = FormFishing.IsAnotherBait;
			this.toggleButton_HandleNeeds.Checked = FormFishing.IsHandleNeeds;
			this.toggleButton_Trunk.Checked = FormFishing.IsTrunk;
			FormFishing.KeyInventory = Keys.None;
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000046FF File Offset: 0x000028FF
		private void toggleButton_OverWeight_CheckedChanged(object sender, EventArgs e)
		{
			FormFishing.IsOverWeight = this.toggleButton_OverWeight.Checked;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00004711 File Offset: 0x00002911
		private void toggleButton_Shore_CheckedChanged(object sender, EventArgs e)
		{
			FormFishing.IsShore = this.toggleButton_Shore.Checked;
			this.toggleButton_Ocean.Checked = !FormFishing.IsShore;
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00004736 File Offset: 0x00002936
		private void toggleButton_Ocean_CheckedChanged(object sender, EventArgs e)
		{
			FormFishing.IsOcean = this.toggleButton_Ocean.Checked;
			this.toggleButton_Shore.Checked = !FormFishing.IsOcean;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000475B File Offset: 0x0000295B
		private void toggleButton_ReuseBait_CheckedChanged(object sender, EventArgs e)
		{
			FormFishing.IsReuseBait = this.toggleButton_ReuseBait.Checked;
			if (FormFishing.IsReuseBait && this.toggleButton_AnotherBait.Checked)
			{
				this.toggleButton_AnotherBait.Checked = false;
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000478D File Offset: 0x0000298D
		private void toggleButton_AnotherBait_CheckedChanged(object sender, EventArgs e)
		{
			FormFishing.IsAnotherBait = this.toggleButton_AnotherBait.Checked;
			if (FormFishing.IsAnotherBait && this.toggleButton_ReuseBait.Checked)
			{
				this.toggleButton_ReuseBait.Checked = false;
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x000047BF File Offset: 0x000029BF
		private void toggleButton_HandleNeeds_CheckedChanged(object sender, EventArgs e)
		{
			FormFishing.IsHandleNeeds = this.toggleButton_HandleNeeds.Checked;
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x000047D1 File Offset: 0x000029D1
		private void toggleButton_Trunk_CheckedChanged(object sender, EventArgs e)
		{
			FormFishing.IsTrunk = this.toggleButton_Trunk.Checked;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x000047E3 File Offset: 0x000029E3
		private void commandButton1_Click(object sender, EventArgs e)
		{
			Form1.Main.bool_7 = true;
			Form1.Main.Hide();
			FormFishing.formFishMain_0.Show();
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00004804 File Offset: 0x00002A04
		public void method_1(bool bool_7)
		{
			CheckBox checkBox = this.toggleButton_Trunk;
			FormFishing.IsTrunk = bool_7;
			checkBox.Checked = bool_7;
		}

		// Token: 0x0400039E RID: 926
		[CompilerGenerated]
		private static FormFishing formFishing_0;

		// Token: 0x0400039F RID: 927
		[CompilerGenerated]
		private static bool bool_0;

		// Token: 0x040003A0 RID: 928
		[CompilerGenerated]
		private static bool bool_1;

		// Token: 0x040003A1 RID: 929
		[CompilerGenerated]
		private static bool bool_2;

		// Token: 0x040003A2 RID: 930
		[CompilerGenerated]
		private static bool bool_3;

		// Token: 0x040003A3 RID: 931
		[CompilerGenerated]
		private static bool bool_4;

		// Token: 0x040003A4 RID: 932
		[CompilerGenerated]
		private static bool bool_5;

		// Token: 0x040003A5 RID: 933
		[CompilerGenerated]
		private static bool bool_6;

		// Token: 0x040003A6 RID: 934
		[CompilerGenerated]
		private static Keys keys_0;

		// Token: 0x040003A7 RID: 935
		private static readonly FormFishMain formFishMain_0 = new FormFishMain();
	}
}
