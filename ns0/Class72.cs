using System;
using System.Collections.Generic;

namespace ns0
{
	// Token: 0x020000A3 RID: 163
	internal class Class72
	{
		// Token: 0x06000494 RID: 1172 RVA: 0x0003A214 File Offset: 0x00038414
		public static double smethod_0(string string_0, string string_1)
		{
			int length = string_0.Length;
			int length2 = string_1.Length;
			int[,] array = new int[length + 1, length2 + 1];
			if (length == 0)
			{
				return -1.0;
			}
			if (length2 == 0)
			{
				return -1.0;
			}
			for (int i = 0; i <= length; i++)
			{
				array[i, 0] = i;
			}
			for (int j = 0; j <= length2; j++)
			{
				array[0, j] = j;
			}
			for (int k = 1; k <= length2; k++)
			{
				for (int l = 1; l <= length; l++)
				{
					int num = ((string_0[l - 1] != string_1[k - 1]) ? 1 : 0);
					array[l, k] = Math.Min(Math.Min(array[l - 1, k] + 1, array[l, k - 1] + 1), array[l - 1, k - 1] + num);
				}
			}
			return 1.0 - (double)array[length, length2] / (double)Math.Max(string_0.Length, string_1.Length);
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0003A328 File Offset: 0x00038528
		public static string smethod_1(string string_0, Dictionary<string, string> dictionary_0, out double double_0)
		{
			double_0 = -1.0;
			if (!string.IsNullOrWhiteSpace(string_0) && dictionary_0 != null && dictionary_0.Count != 0)
			{
				string text = null;
				foreach (string text2 in dictionary_0.Values)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						double num = Class72.smethod_0(string_0, text2);
						if (num > double_0)
						{
							double_0 = num;
							text = text2;
							if (double_0 >= 1.0)
							{
								break;
							}
						}
					}
				}
				return text;
			}
			return null;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0003A3C4 File Offset: 0x000385C4
		public static int smethod_2(string string_0, string[] string_1, double double_0, out double double_1)
		{
			double_1 = -1.0;
			if (string.IsNullOrWhiteSpace(string_0) || string_1 == null || string_1.Length == 0)
			{
				return -1;
			}
			int num = -1;
			for (int i = 0; i < string_1.Length; i++)
			{
				string text = string_1[i];
				if (!string.IsNullOrEmpty(text))
				{
					double num2 = Class72.smethod_0(string_0, text);
					if (num2 > double_1)
					{
						double_1 = num2;
						num = i;
					}
				}
			}
			if (double_1 < double_0)
			{
				return -1;
			}
			return num;
		}
	}
}
