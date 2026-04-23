using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using ns1;
using psClick;

namespace ns0
{
	// Token: 0x02000063 RID: 99
	internal static class Class31
	{
		// Token: 0x06000333 RID: 819 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0002E694 File Offset: 0x0002C894
		public static void smethod_1(Class76 class76_1)
		{
			Class31.class76_0 = class76_1;
			Class31.cancellationToken_0 = Form1.cancellationToken_0;
			Class31.cancellationToken_0.Register(new Action(Class31.Class32.class32_0.method_0));
			List<Color> list = new List<Color>
			{
				Color.FromArgb(246, 246, 246),
				Color.FromArgb(0, 0, 0)
			};
			List<int> list2 = new List<int> { 600, 150 };
			string text = ((Class31.class76_0.Width == 1360) ? "1366x768" : Class31.class76_0.Resolution);
			Class31.rectangle_0 = Class50.smethod_3(Class31.class76_0, "regionE");
			Class31.rectangle_1 = Class50.smethod_3(Class31.class76_0, "regionCaptcha");
			Class31.bitmap_0 = Class50.smethod_1(text, "e");
			Class31.list_0 = Class50.smethod_7<List<BaseSymbolStruct>>("SymbolBase", "captcha_base", new Func<string, List<BaseSymbolStruct>>(ReadText.LoadSymbolBase));
			try
			{
				Point[] array;
				if (FormGym.IsPressE && !Class40.smethod_29(1, list, list2, 2, out array, 7, 40, 36, 40, 36, Class31.rectangle_1, 10, 800, 9999, Class31.class76_0))
				{
					Class46.smethod_6(Keys.E, Class31.class76_0, FormGym.IsBackground);
					Class31.smethod_2(150.0, 280.0);
				}
				while (!Class31.cancellationToken_0.IsCancellationRequested)
				{
					if (FormGym.IsPressE && Class40.smethod_18(6, 1, Class31.bitmap_0, -2, out array, Class31.rectangle_0, 25, 90, Class31.class76_0))
					{
						Class46.smethod_6(Keys.E, Class31.class76_0, FormGym.IsBackground);
						Class31.smethod_2(150.0, 280.0);
					}
					if (!Class31.cancellationToken_0.IsCancellationRequested && Class40.smethod_29(1, list, list2, 2, out array, 7, 40, 36, 40, 36, Class31.rectangle_1, 10, 700, 9999, Class31.class76_0))
					{
						Class4.smethod_1(Class31.class76_0, Class31.rectangle_1, Class31.list_0, FormGym.IsBackground);
						Class31.smethod_2(400.0, 850.0);
						if (!Class31.cancellationToken_0.IsCancellationRequested && FormGym.IsPressE && !Class40.smethod_29(1, list, list2, 2, out array, 7, 40, 36, 40, 36, Class31.rectangle_1, 10, 700, 9999, Class31.class76_0))
						{
							Class46.smethod_6(Keys.E, Class31.class76_0, FormGym.IsBackground);
							Class31.smethod_2(150.0, 280.0);
						}
					}
					else
					{
						Class31.smethod_2(50.0, 0.0);
					}
				}
			}
			catch (Form1.GException0 gexception)
			{
				Form1.Main.method_11();
				if (gexception.HasMessage)
				{
					Form1.smethod_0();
					new FormMessage(gexception);
				}
			}
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0002E990 File Offset: 0x0002CB90
		private static void smethod_2(double double_0, double double_1 = 0.0)
		{
			if (Class31.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class31.random_0.NextDouble() * (num2 - num);
			}
			else
			{
				num3 = double_0;
			}
			int i = (int)Math.Floor(num3);
			double num4 = num3 - (double)i;
			int num5 = 50;
			while (i > 0)
			{
				if (Class31.cancellationToken_0.IsCancellationRequested)
				{
					throw new Form1.GException0();
				}
				int num6 = Math.Min(num5, i);
				Thread.Sleep(num6);
				i -= num6;
			}
			if (num4 > 0.0)
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				double num7 = num4 / 1000.0 * (double)Stopwatch.Frequency;
				while ((double)stopwatch.ElapsedTicks < num7)
				{
					if (Class31.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x0400042E RID: 1070
		private static CancellationToken cancellationToken_0;

		// Token: 0x0400042F RID: 1071
		private static Class76 class76_0;

		// Token: 0x04000430 RID: 1072
		private static Bitmap bitmap_0;

		// Token: 0x04000431 RID: 1073
		private static Rectangle rectangle_0;

		// Token: 0x04000432 RID: 1074
		private static Rectangle rectangle_1;

		// Token: 0x04000433 RID: 1075
		private static List<BaseSymbolStruct> list_0;

		// Token: 0x04000434 RID: 1076
		private static readonly Random random_0 = Class31.smethod_0();

		// Token: 0x02000064 RID: 100
		[CompilerGenerated]
		[Serializable]
		private sealed class Class32
		{
			// Token: 0x06000339 RID: 825 RVA: 0x00004B50 File Offset: 0x00002D50
			internal void method_0()
			{
				Bitmap bitmap_ = Class31.bitmap_0;
				if (bitmap_ == null)
				{
					return;
				}
				bitmap_.Dispose();
			}

			// Token: 0x04000435 RID: 1077
			public static readonly Class31.Class32 class32_0 = new Class31.Class32();

			// Token: 0x04000436 RID: 1078
			public static Action action_0;
		}
	}
}
