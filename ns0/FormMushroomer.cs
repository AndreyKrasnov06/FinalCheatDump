using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x02000058 RID: 88
	public partial class FormMushroomer : Form
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00004516 File Offset: 0x00002716
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x0000451D File Offset: 0x0000271D
		public static bool IsAutoRunning { get; private set; }

		// Token: 0x060002C8 RID: 712 RVA: 0x00004525 File Offset: 0x00002725
		public FormMushroomer()
		{
			this.InitializeComponent();
			FormMushroomer.IsAutoRunning = true;
			this.toggleButton_AutoRunning.Checked = FormMushroomer.IsAutoRunning;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00004549 File Offset: 0x00002749
		private void toggleButton_AutoRunning_CheckedChanged(object sender, EventArgs e)
		{
			FormMushroomer.IsAutoRunning = this.toggleButton_AutoRunning.Checked;
		}

		// Token: 0x04000373 RID: 883
		[CompilerGenerated]
		private static bool bool_0;
	}
}
