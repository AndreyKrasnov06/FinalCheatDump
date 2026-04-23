using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x020000A6 RID: 166
	internal class Class75
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x00005351 File Offset: 0x00003551
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x00005359 File Offset: 0x00003559
		public string LastOpenedForm { get; set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x00005362 File Offset: 0x00003562
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x0000536A File Offset: 0x0000356A
		public GEnum0[] Modifiers { get; set; } = new GEnum0[2];

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x00005373 File Offset: 0x00003573
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x0000537B File Offset: 0x0000357B
		public Keys[] Hotkey { get; set; } = new Keys[2];

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x00005384 File Offset: 0x00003584
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x0000538C File Offset: 0x0000358C
		public List<GClass4> Forms { get; set; }

		// Token: 0x04000557 RID: 1367
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000558 RID: 1368
		[CompilerGenerated]
		private GEnum0[] genum0_0;

		// Token: 0x04000559 RID: 1369
		[CompilerGenerated]
		private Keys[] keys_0;

		// Token: 0x0400055A RID: 1370
		[CompilerGenerated]
		private List<GClass4> list_0;
	}
}
