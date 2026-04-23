using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ns0
{
	// Token: 0x02000096 RID: 150
	internal class Class61
	{
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x0000512D File Offset: 0x0000332D
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x00005135 File Offset: 0x00003335
		[JsonProperty("id")]
		public string ID { get; set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x0000513E File Offset: 0x0000333E
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x00005146 File Offset: 0x00003346
		[JsonProperty("key")]
		public string Key { get; set; }

		// Token: 0x06000457 RID: 1111 RVA: 0x0000514F File Offset: 0x0000334F
		public void method_0()
		{
			this.ID = null;
			this.Key = null;
			this.string_2 = null;
			this.string_3 = null;
			this.string_4 = null;
			this.string_5 = null;
			this.string_6 = null;
			this.string_7 = null;
		}

		// Token: 0x0400050F RID: 1295
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000510 RID: 1296
		[CompilerGenerated]
		private string string_1;

		// Token: 0x04000511 RID: 1297
		[JsonProperty("UUID")]
		public string string_2;

		// Token: 0x04000512 RID: 1298
		[JsonProperty("SystemDrive")]
		public string string_3;

		// Token: 0x04000513 RID: 1299
		[JsonProperty("Motherboard")]
		public string string_4;

		// Token: 0x04000514 RID: 1300
		[JsonProperty("Processor")]
		public string string_5;

		// Token: 0x04000515 RID: 1301
		[JsonProperty("RAM")]
		public string string_6;

		// Token: 0x04000516 RID: 1302
		[JsonProperty("VideoCard")]
		public string string_7;
	}
}
