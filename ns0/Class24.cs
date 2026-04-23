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
	// Token: 0x02000045 RID: 69
	internal static class Class24
	{
		// Token: 0x0600021A RID: 538 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00019C60 File Offset: 0x00017E60
		public static void smethod_1(Class76 class76_1)
		{
			Class24.class76_0 = class76_1;
			Class24.cancellationToken_0 = Form1.cancellationToken_0;
			Class24.cancellationToken_0.Register(new Action(Class24.Class25.class25_0.method_0));
			List<Color> list = new List<Color>
			{
				Color.FromArgb(246, 246, 246),
				Color.FromArgb(0, 0, 0)
			};
			List<int> list2 = new List<int> { 600, 150 };
			object obj = ((Class24.class76_0.Width == 1360) ? "1366x768" : Class24.class76_0.Resolution);
			Class24.rectangle_0 = Class50.smethod_3(Class24.class76_0, "regionE");
			Class24.rectangle_1 = Class50.smethod_3(Class24.class76_0, "regionGame");
			Class24.rectangle_1 = new Rectangle
			{
				X = Class24.rectangle_1.X - 1,
				Y = Class24.rectangle_1.Y - 1,
				Width = Class24.rectangle_1.Width + 2,
				Height = Class24.rectangle_1.Height + 2
			};
			Class24.rectangle_2 = Class50.smethod_3(Class24.class76_0, "regionOrange");
			Class24.rectangle_3 = Class50.smethod_3(Class24.class76_0, "regionCaptcha");
			object obj2 = obj;
			Class24.bitmap_0 = Class50.smethod_1(obj2, "e");
			Class24.bitmap_1 = Class50.smethod_1(obj2, "game");
			for (int i = 0; i < Class24.bitmap_2.Length; i++)
			{
				Class24.bitmap_2[i] = Class50.smethod_1("Orange", "orange_" + i.ToString());
			}
			Class24.list_0 = Class50.smethod_7<List<BaseSymbolStruct>>("SymbolBase", "captcha_base", new Func<string, List<BaseSymbolStruct>>(ReadText.LoadSymbolBase));
			if (Class24.class76_0.Height > 1080)
			{
				Class24.int_0 = 80;
			}
			else if (Class24.class76_0.Height <= 1080)
			{
				Class24.int_0 = 50;
			}
			try
			{
				Class24.class76_0.method_2();
				while (!Class24.cancellationToken_0.IsCancellationRequested)
				{
					Point[] array;
					if (!FormFarm.IsCaptcha && Class40.smethod_18(6, 1, Class24.bitmap_1, -2, out array, Class24.rectangle_1, 25, 95, Class24.class76_0))
					{
						Class24.smethod_3(10.0 + Class24.random_0.NextDouble() * 20.0, 0.0);
						Class24.smethod_2();
					}
					if (FormFarm.IsCaptcha && Class40.smethod_29(1, list, list2, 2, out array, 7, 40, 36, 40, 36, Class24.rectangle_3, 10, 800, 9999, Class24.class76_0))
					{
						Class24.smethod_3(10.0 + Class24.random_0.NextDouble() * 20.0, 0.0);
						Class4.smethod_1(Class24.class76_0, Class24.rectangle_3, Class24.list_0, false);
					}
					if (FormFarm.IsPressE && Class40.smethod_18(6, 1, Class24.bitmap_0, -2, out array, Class24.rectangle_0, 25, 90, Class24.class76_0))
					{
						Class46.smethod_6(Keys.E, null, false);
					}
					Class24.smethod_3(50.0 + Class24.random_0.NextDouble() * 10.0, 0.0);
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

		// Token: 0x0600021C RID: 540 RVA: 0x00019FEC File Offset: 0x000181EC
		private static void smethod_2()
		{
			Point[] array;
			while (!Class24.cancellationToken_0.IsCancellationRequested && Class40.smethod_18(9, 1, Class24.bitmap_1, -2, out array, Class24.rectangle_1, 25, 95, Class24.class76_0))
			{
				using (Bitmap bitmap = Class40.smethod_2(Class24.class76_0))
				{
					if (Class24.cancellationToken_0.IsCancellationRequested || !Class40.smethod_20(9, 1, Class24.bitmap_1, -2, out array, Class24.rectangle_1, 25, 95, bitmap))
					{
						break;
					}
					Point[] array2;
					if (!Class24.cancellationToken_0.IsCancellationRequested && Class40.smethod_22(3, 0, -1, -1, Class24.bitmap_2, -1, out array2, Class24.rectangle_2, 15, 50, bitmap) && Class40.smethod_18(9, 1, Class24.bitmap_1, -2, out array, Class24.rectangle_1, 25, 95, Class24.class76_0))
					{
						List<Rectangle> list = new List<Rectangle>();
						array = array2;
						int i = 0;
						while (i < array.Length)
						{
							Point point = array[i];
							if (Class24.cancellationToken_0.IsCancellationRequested)
							{
								return;
							}
							bool flag = false;
							using (List<Rectangle>.Enumerator enumerator = list.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									Rectangle rectangle = enumerator.Current;
									if (rectangle.Contains(point))
									{
										flag = true;
										break;
									}
								}
								goto IL_0202;
							}
							goto IL_012B;
							IL_01F7:
							i++;
							continue;
							IL_012B:
							Point[] array3;
							if (!flag && Class40.smethod_18(9, 1, Class24.bitmap_1, -2, out array3, Class24.rectangle_1, 25, 95, Class24.class76_0))
							{
								Class56.smethod_6(Class24.class76_0, FormFarm.Main.SpeedClick.Value, FormFarm.Main.SpeedClick.Value, new Point(Class24.rectangle_2.Left + point.X, Class24.rectangle_2.Top + point.Y), new Size(Class24.bitmap_2[0].Width, Class24.bitmap_2[0].Height));
								list.Add(new Rectangle(point.X - Class24.int_0, point.Y - Class24.int_0, Class24.int_0 * 2, Class24.int_0 * 2));
								goto IL_01F7;
							}
							goto IL_01F7;
							IL_0202:
							if (!Class24.cancellationToken_0.IsCancellationRequested)
							{
								goto IL_012B;
							}
							goto IL_01F7;
						}
						list.Clear();
						Class24.smethod_3(100.0, 0.0);
					}
				}
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0001A280 File Offset: 0x00018480
		private static void smethod_3(double double_0, double double_1 = 0.0)
		{
			if (Class24.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class24.random_0.NextDouble() * (num2 - num);
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
				if (Class24.cancellationToken_0.IsCancellationRequested)
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
					if (Class24.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x0400024E RID: 590
		private static CancellationToken cancellationToken_0;

		// Token: 0x0400024F RID: 591
		private static Class76 class76_0;

		// Token: 0x04000250 RID: 592
		private static Bitmap bitmap_0;

		// Token: 0x04000251 RID: 593
		private static Bitmap bitmap_1;

		// Token: 0x04000252 RID: 594
		private static Bitmap[] bitmap_2 = new Bitmap[8];

		// Token: 0x04000253 RID: 595
		private static Rectangle rectangle_0;

		// Token: 0x04000254 RID: 596
		private static Rectangle rectangle_1;

		// Token: 0x04000255 RID: 597
		private static Rectangle rectangle_2;

		// Token: 0x04000256 RID: 598
		private static Rectangle rectangle_3;

		// Token: 0x04000257 RID: 599
		private static int int_0;

		// Token: 0x04000258 RID: 600
		private static List<BaseSymbolStruct> list_0;

		// Token: 0x04000259 RID: 601
		private static readonly Random random_0 = Class24.smethod_0();

		// Token: 0x02000046 RID: 70
		[CompilerGenerated]
		[Serializable]
		private sealed class Class25
		{
			// Token: 0x06000221 RID: 545 RVA: 0x0001A364 File Offset: 0x00018564
			internal void method_0()
			{
				Bitmap bitmap_ = Class24.bitmap_0;
				if (bitmap_ != null)
				{
					bitmap_.Dispose();
				}
				Bitmap bitmap_2 = Class24.bitmap_1;
				if (bitmap_2 != null)
				{
					bitmap_2.Dispose();
				}
				foreach (Bitmap bitmap in Class24.bitmap_2)
				{
					if (bitmap != null)
					{
						bitmap.Dispose();
					}
				}
			}

			// Token: 0x0400025A RID: 602
			public static readonly Class24.Class25 class25_0 = new Class24.Class25();

			// Token: 0x0400025B RID: 603
			public static Action action_0;
		}
	}
}
