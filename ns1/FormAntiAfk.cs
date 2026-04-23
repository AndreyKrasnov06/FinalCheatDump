using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	// Token: 0x02000056 RID: 86
	public partial class FormAntiAfk : GForm0
	{
		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060002AF RID: 687 RVA: 0x00004414 File Offset: 0x00002614
		// (set) Token: 0x060002B0 RID: 688 RVA: 0x0000441B File Offset: 0x0000261B
		public static FormAntiAfk Main { get; private set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x00004423 File Offset: 0x00002623
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x0000442A File Offset: 0x0000262A
		public static bool IsMove { get; private set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x00004432 File Offset: 0x00002632
		// (set) Token: 0x060002B4 RID: 692 RVA: 0x00004439 File Offset: 0x00002639
		public static bool IsPhone { get; private set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x00004441 File Offset: 0x00002641
		// (set) Token: 0x060002B6 RID: 694 RVA: 0x00004448 File Offset: 0x00002648
		public static bool IsPad { get; private set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x00004450 File Offset: 0x00002650
		// (set) Token: 0x060002B8 RID: 696 RVA: 0x00004457 File Offset: 0x00002657
		public static bool IsDemorgan { get; private set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x0000445F File Offset: 0x0000265F
		// (set) Token: 0x060002BA RID: 698 RVA: 0x00004466 File Offset: 0x00002666
		public static bool IsCasino { get; private set; }

		// Token: 0x060002BB RID: 699 RVA: 0x000252B8 File Offset: 0x000234B8
		public FormAntiAfk()
		{
			this.InitializeComponent();
			FormAntiAfk.Main = this;
			FormAntiAfk.IsMove = true;
			FormAntiAfk.IsPhone = true;
			FormAntiAfk.IsPad = true;
			FormAntiAfk.IsDemorgan = true;
			FormAntiAfk.IsCasino = false;
			this.toggleButton_Move.Checked = FormAntiAfk.IsMove;
			this.toggleButton_Phone.Checked = FormAntiAfk.IsPhone;
			this.toggleButton_Pad.Checked = FormAntiAfk.IsPad;
			this.toggleButton_Demorgan.Checked = FormAntiAfk.IsDemorgan;
			this.toggleButton_Casino.Checked = FormAntiAfk.IsCasino;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000446E File Offset: 0x0000266E
		private void toggleButton_Move_CheckedChanged(object sender, EventArgs e)
		{
			FormAntiAfk.IsMove = this.toggleButton_Move.Checked;
			if (FormAntiAfk.IsMove)
			{
				this.toggleButton_Casino.Checked = false;
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00004493 File Offset: 0x00002693
		private void toggleButton_Phone_CheckedChanged(object sender, EventArgs e)
		{
			FormAntiAfk.IsPhone = this.toggleButton_Phone.Checked;
			if (FormAntiAfk.IsPhone)
			{
				this.toggleButton_Casino.Checked = false;
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x000044B8 File Offset: 0x000026B8
		private void toggleButton_Pad_CheckedChanged(object sender, EventArgs e)
		{
			FormAntiAfk.IsPad = this.toggleButton_Pad.Checked;
			if (FormAntiAfk.IsPad)
			{
				this.toggleButton_Casino.Checked = false;
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x000044DD File Offset: 0x000026DD
		private void toggleButton_Demorgan_CheckedChanged(object sender, EventArgs e)
		{
			FormAntiAfk.IsDemorgan = this.toggleButton_Demorgan.Checked;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00025348 File Offset: 0x00023548
		private void toggleButton_Casino_CheckedChanged(object sender, EventArgs e)
		{
			FormAntiAfk.IsCasino = this.toggleButton_Casino.Checked;
			if (FormAntiAfk.IsCasino)
			{
				this.toggleButton_Move.Checked = false;
				this.toggleButton_Phone.Checked = false;
				this.toggleButton_Pad.Checked = false;
				return;
			}
			this.toggleButton_Move.Checked = true;
			this.toggleButton_Phone.Checked = true;
			this.toggleButton_Pad.Checked = true;
		}

		// Token: 0x04000355 RID: 853
		[CompilerGenerated]
		private static FormAntiAfk formAntiAfk_0;

		// Token: 0x04000356 RID: 854
		[CompilerGenerated]
		private static bool bool_0;

		// Token: 0x04000357 RID: 855
		[CompilerGenerated]
		private static bool bool_1;

		// Token: 0x04000358 RID: 856
		[CompilerGenerated]
		private static bool bool_2;

		// Token: 0x04000359 RID: 857
		[CompilerGenerated]
		private static bool bool_3;

		// Token: 0x0400035A RID: 858
		[CompilerGenerated]
		private static bool bool_4;
	}
}
