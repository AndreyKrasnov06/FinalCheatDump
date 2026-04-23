using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using psClick;

namespace ns0
{
	// Token: 0x0200002D RID: 45
	internal class Class4
	{
		// Token: 0x0600019C RID: 412 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00015154 File Offset: 0x00013354
		public static void smethod_1(Class76 class76_1, Rectangle rectangle_0, List<BaseSymbolStruct> list_0, bool bool_0 = false)
		{
			Class4.cancellationToken_0 = Form1.cancellationToken_0;
			Class4.class76_0 = class76_1;
			List<Color> list = new List<Color>
			{
				Color.FromArgb(246, 246, 246),
				Color.FromArgb(0, 0, 0)
			};
			List<int> list2 = new List<int> { 600, 150 };
			List<Line> list3 = new List<Line>();
			Bitmap bitmap = null;
			int num = 0;
			Class4.smethod_3(400.0, 500.0);
			Point[] array;
			while (!Class4.cancellationToken_0.IsCancellationRequested && Class40.smethod_29(1, list, list2, 2, out array, 7, 40, 36, 40, 36, rectangle_0, 10, 800, 9999, Class4.class76_0))
			{
				using (Bitmap bitmap2 = Class40.smethod_5(Class4.class76_0, rectangle_0))
				{
					string text = ReadText.SymbolsToString(ReadText.Recognize(bitmap2, 120, 30, 59, 11, 1, 2, 10, 212, 0, 50, 0, 50, 1, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 30, 5, 70, 70, 0, 0, 0, 0, 0, 0, new Color[] { ColorTranslator.FromHtml("000000") }, new Color[0], new int[] { 1 }, new int[0], list_0, false, 0, ref list3, ref bitmap, false, new Size(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, new int[0], new char[0]), 1, list3, true).Replace(".", "");
					if (text == "A")
					{
						Class46.smethod_6(Keys.A, Class4.class76_0, bool_0);
						num++;
						goto IL_0246;
					}
					if (text == "AA" || text == "W")
					{
						Class46.smethod_6(Keys.W, Class4.class76_0, bool_0);
						num++;
						goto IL_0246;
					}
					if (text == "S")
					{
						Class46.smethod_6(Keys.S, Class4.class76_0, bool_0);
						num++;
						goto IL_0246;
					}
					if (!(text == "D"))
					{
						Class4.smethod_3(50.0, 0.0);
						continue;
					}
					Class46.smethod_6(Keys.D, Class4.class76_0, bool_0);
					num++;
					goto IL_0246;
				}
				IL_022A:
				Class4.smethod_3(850.0, 950.0);
				continue;
				IL_0246:
				if (num >= 4)
				{
					break;
				}
				goto IL_022A;
			}
			bitmap.Dispose();
		}

		// Token: 0x0600019E RID: 414 RVA: 0x000153D0 File Offset: 0x000135D0
		public static string smethod_2(Bitmap bitmap_0, List<BaseSymbolStruct> list_0)
		{
			List<Line> list = new List<Line>();
			Bitmap bitmap = null;
			string text;
			try
			{
				text = ReadText.SymbolsToString(ReadText.Recognize(bitmap_0, 118, 43, 60, 9, 0, 5, 4, 180, 0, 50, 0, 50, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 5, 5, 70, 70, 1, 0, 1, 0, 1, 0, new Color[0], new Color[0], new int[0], new int[0], list_0, false, 0, ref list, ref bitmap, false, new Size(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, new int[0], new char[0]), 40, list, true);
			}
			finally
			{
				if (bitmap != null)
				{
					bitmap.Dispose();
				}
			}
			return text;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00015480 File Offset: 0x00013680
		private static void smethod_3(double double_0, double double_1 = 0.0)
		{
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class4.random_0.NextDouble() * (num2 - num);
			}
			else
			{
				num3 = double_0;
			}
			int num4 = (int)Math.Floor(num3);
			double num5 = num3 - (double)num4;
			if (num4 > 0)
			{
				Thread.Sleep(num4);
			}
			if (num5 > 0.0)
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				double num6 = num5 / 1000.0 * (double)Stopwatch.Frequency;
				while ((double)stopwatch.ElapsedTicks < num6)
				{
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x040001D7 RID: 471
		private static CancellationToken cancellationToken_0;

		// Token: 0x040001D8 RID: 472
		private static Class76 class76_0;

		// Token: 0x040001D9 RID: 473
		private static readonly Random random_0 = Class4.smethod_0();
	}
}
