using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ns0
{
	// Token: 0x0200003A RID: 58
	internal class Class17 : IDisposable
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00003D7B File Offset: 0x00001F7B
		// (set) Token: 0x060001DA RID: 474 RVA: 0x00003D83 File Offset: 0x00001F83
		public Dictionary<string, string> Images { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00003D8C File Offset: 0x00001F8C
		// (set) Token: 0x060001DC RID: 476 RVA: 0x00003D94 File Offset: 0x00001F94
		public Dictionary<string, float[]> Coordinates { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00003D9D File Offset: 0x00001F9D
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00003DA5 File Offset: 0x00001FA5
		public string Format { get; set; }

		// Token: 0x060001DF RID: 479 RVA: 0x00003DAE File Offset: 0x00001FAE
		public void Dispose()
		{
			Dictionary<string, string> images = this.Images;
			if (images != null)
			{
				images.Clear();
			}
			Dictionary<string, float[]> coordinates = this.Coordinates;
			if (coordinates == null)
			{
				return;
			}
			coordinates.Clear();
		}

		// Token: 0x0400020E RID: 526
		[CompilerGenerated]
		private Dictionary<string, string> dictionary_0;

		// Token: 0x0400020F RID: 527
		[CompilerGenerated]
		private Dictionary<string, float[]> dictionary_1;

		// Token: 0x04000210 RID: 528
		[CompilerGenerated]
		private string string_0;
	}
}
