using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns1
{
	// Token: 0x0200003D RID: 61
	public partial class FormBuilder : GForm0
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00003DFF File Offset: 0x00001FFF
		// (set) Token: 0x060001EE RID: 494 RVA: 0x00003E06 File Offset: 0x00002006
		public static FormBuilder Main { get; private set; }

		// Token: 0x060001EF RID: 495 RVA: 0x00003E0E File Offset: 0x0000200E
		public FormBuilder()
		{
			this.InitializeComponent();
			FormBuilder.Main = this;
			this.SpeedHit.Value = 50;
		}

		// Token: 0x04000221 RID: 545
		[CompilerGenerated]
		private static FormBuilder formBuilder_0;
	}
}
