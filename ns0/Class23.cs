using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;

namespace ns0
{
	// Token: 0x02000044 RID: 68
	internal static class Class23
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00003FCE File Offset: 0x000021CE
		// (set) Token: 0x06000216 RID: 534 RVA: 0x00003FD5 File Offset: 0x000021D5
		public static Dictionary<string, byte[]> Data { get; private set; } = new Dictionary<string, byte[]>();

		// Token: 0x06000217 RID: 535 RVA: 0x00019BDC File Offset: 0x00017DDC
		public static void smethod_0(JObject jobject_0)
		{
			foreach (JProperty jproperty in jobject_0.Properties())
			{
				string name = jproperty.Name;
				string text = (string)jproperty.Value;
				if (!string.IsNullOrWhiteSpace(text))
				{
					try
					{
						byte[] array = Convert.FromBase64String(text);
						Class23.Data[name] = array;
					}
					catch (FormatException)
					{
					}
				}
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00003FDD File Offset: 0x000021DD
		public static void smethod_1()
		{
			Dictionary<string, byte[]> data = Class23.Data;
			if (data == null)
			{
				return;
			}
			data.Clear();
		}

		// Token: 0x0400024D RID: 589
		[CompilerGenerated]
		private static Dictionary<string, byte[]> dictionary_0;
	}
}
