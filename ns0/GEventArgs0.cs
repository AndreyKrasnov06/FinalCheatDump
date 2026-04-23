using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x0200006C RID: 108
	public class GEventArgs0 : EventArgs
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600036A RID: 874 RVA: 0x00004CE8 File Offset: 0x00002EE8
		// (set) Token: 0x0600036B RID: 875 RVA: 0x00004CF0 File Offset: 0x00002EF0
		public Keys Key { get; private set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00004CF9 File Offset: 0x00002EF9
		// (set) Token: 0x0600036D RID: 877 RVA: 0x00004D01 File Offset: 0x00002F01
		public GEnum0 Modifiers { get; private set; }

		// Token: 0x0600036E RID: 878 RVA: 0x00004D0A File Offset: 0x00002F0A
		public GEventArgs0(Keys keys_1, GEnum0 genum0_1)
		{
			this.Key = keys_1;
			this.Modifiers = genum0_1;
		}

		// Token: 0x0400044D RID: 1101
		[CompilerGenerated]
		private Keys keys_0;

		// Token: 0x0400044E RID: 1102
		[CompilerGenerated]
		private GEnum0 genum0_0;
	}
}
