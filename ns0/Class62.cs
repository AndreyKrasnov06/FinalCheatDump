using System;
using System.Text;
using Newtonsoft.Json;

namespace ns0
{
	// Token: 0x02000097 RID: 151
	internal class Class62
	{
		// Token: 0x06000459 RID: 1113 RVA: 0x00005189 File Offset: 0x00003389
		public void method_0(out byte[] byte_0, out byte[] byte_1, out byte[] byte_2)
		{
			byte_0 = this.method_1(this.string_0);
			byte_1 = this.method_1(this.string_1);
			byte_2 = this.method_1(this.string_2);
			this.method_2();
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00038590 File Offset: 0x00036790
		private byte[] method_1(string string_3)
		{
			if (string_3 == null)
			{
				return null;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(string_3);
			GClass2.smethod_1(ref bytes);
			return bytes;
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x000051BB File Offset: 0x000033BB
		private void method_2()
		{
			this.string_0 = null;
			this.string_1 = null;
			this.string_2 = null;
		}

		// Token: 0x04000517 RID: 1303
		[JsonProperty("status")]
		public string string_0;

		// Token: 0x04000518 RID: 1304
		[JsonProperty("time")]
		public string string_1;

		// Token: 0x04000519 RID: 1305
		[JsonProperty("message")]
		public string string_2;
	}
}
