using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ns1;

namespace ns0
{
	// Token: 0x02000088 RID: 136
	internal static class Class51
	{
		// Token: 0x06000401 RID: 1025 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00035ADC File Offset: 0x00033CDC
		public static void smethod_1(Class76 class76_1)
		{
			Class51.class76_0 = class76_1;
			Class51.cancellationToken_0 = Form1.cancellationToken_0;
			Class51.cancellationToken_0.Register(new Action(Class51.Class52.class52_0.method_0));
			object obj = ((Class51.class76_0.Width == 1360) ? "1366x768" : Class51.class76_0.Resolution);
			Class51.rectangle_0 = Class50.smethod_3(Class51.class76_0, "regionE");
			Class51.rectangle_1 = Class50.smethod_3(Class51.class76_0, "regionLBM");
			Class51.rectangle_2 = Class50.smethod_3(Class51.class76_0, "regionGame");
			Class51.rectangle_3 = Class50.smethod_3(Class51.class76_0, "regionWood");
			object obj2 = obj;
			Class51.bitmap_0 = Class50.smethod_1(obj2, "e");
			Class51.bitmap_1 = Class50.smethod_1(obj2, "game");
			for (int i = 0; i < Class51.bitmap_2.Length; i++)
			{
				Class51.bitmap_2[i] = Class50.smethod_1("LBM", "lbm_" + i.ToString());
			}
			for (int j = 0; j < Class51.bitmap_3.Length; j++)
			{
				try
				{
					Class51.bitmap_3[j] = Class50.smethod_1("Wood", "wood_" + j.ToString());
				}
				catch (Exception)
				{
				}
			}
			if (FormLumberjack.IsAutoRunning)
			{
				Task.Run(new Action(Class51.Class52.class52_0.method_1));
			}
			try
			{
				Class51.class76_0.method_2();
				while (!Class51.cancellationToken_0.IsCancellationRequested)
				{
					Point[] array;
					if (!Class51.cancellationToken_0.IsCancellationRequested && Class40.smethod_18(6, 1, Class51.bitmap_2[0], -1, out array, Class51.rectangle_1, 20, 90, Class51.class76_0))
					{
						if (FormLumberjack.IsAutoRunning)
						{
							Class51.bool_0 = false;
							Class51.smethod_5(100.0, 0.0);
						}
						Class51.smethod_5(10.0 + Class51.random_0.NextDouble() * 20.0, 0.0);
						Class51.smethod_3();
					}
					if (!Class51.cancellationToken_0.IsCancellationRequested && Class40.smethod_18(6, 1, Class51.bitmap_1, -1, out array, Class51.rectangle_2, 25, 90, Class51.class76_0))
					{
						if (FormLumberjack.IsAutoRunning)
						{
							Class51.bool_0 = false;
							Class51.smethod_5(100.0, 0.0);
						}
						Class51.smethod_4();
						if (FormLumberjack.IsAutoRunning)
						{
							Class51.bool_0 = true;
						}
						Class51.smethod_5(1800.0 + Class51.random_0.NextDouble() * 200.0, 0.0);
					}
					if (!Class51.cancellationToken_0.IsCancellationRequested && FormLumberjack.IsPressE && Class40.smethod_18(6, 1, Class51.bitmap_0, -2, out array, Class51.rectangle_0, 25, 90, Class51.class76_0))
					{
						Class46.smethod_6(Keys.E, null, false);
						if (Class40.smethod_19(6, 1, Class51.bitmap_2[0], -1, out array, Class51.rectangle_1, 20, 90, Class51.class76_0, Class51.cancellationToken_0, 1000, 100, false))
						{
							Class51.smethod_3();
						}
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

		// Token: 0x06000403 RID: 1027 RVA: 0x00035E48 File Offset: 0x00034048
		private static void smethod_2()
		{
			while (!Class51.cancellationToken_0.IsCancellationRequested)
			{
				if (!Class46.smethod_10(Keys.LShiftKey) || !Class46.smethod_10(Keys.W) || !Class51.class76_0.IsActive)
				{
					if (!Class51.bool_0 || !Class51.class76_0.IsActive)
					{
						Class51.smethod_5(80.0, 120.0);
						continue;
					}
				}
				while (!Class51.cancellationToken_0.IsCancellationRequested)
				{
					if ((!Class46.smethod_10(Keys.LShiftKey) && !Class46.smethod_10(Keys.W) && Class51.class76_0.IsActive) || (Class51.bool_0 && Class51.class76_0.IsActive))
					{
						Class46.smethod_8(Keys.W, null, false);
						Class46.smethod_8(Keys.LShiftKey, null, false);
						Class51.bool_0 = true;
						while (!Class51.cancellationToken_0.IsCancellationRequested)
						{
							if (Class46.smethod_10(Keys.S) || !Class51.bool_0 || !Class46.smethod_10(Keys.LShiftKey) || !Class46.smethod_10(Keys.W) || !Class51.class76_0.IsActive)
							{
								Class46.smethod_9(Keys.W, null, false, true);
								Class46.smethod_9(Keys.LShiftKey, null, false, true);
								Class51.bool_0 = false;
								break;
							}
						}
						break;
					}
				}
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00035F84 File Offset: 0x00034184
		private static void smethod_3()
		{
			while (!Class51.cancellationToken_0.IsCancellationRequested)
			{
				Point[] array;
				if (!Class40.smethod_24(6, 1, -1, -1, Class51.bitmap_2, -1, out array, Class51.rectangle_1, 20, 90, Class51.class76_0))
				{
					return;
				}
				Class56.smethod_18(FormLumberjack.Main.SpeedSpam.Value);
			}
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00035FD8 File Offset: 0x000341D8
		private static void smethod_4()
		{
			Point[] array;
			while (!Class51.cancellationToken_0.IsCancellationRequested && Class40.smethod_18(6, 1, Class51.bitmap_1, -1, out array, Class51.rectangle_2, 25, 90, Class51.class76_0))
			{
				Point[] array2;
				if (Class40.smethod_24(3, 0, -1, -1, Class51.bitmap_3, -1, out array2, Class51.rectangle_3, 10, 78, Class51.class76_0))
				{
					List<Rectangle> list = new List<Rectangle>();
					array = array2;
					int i = 0;
					while (i < array.Length)
					{
						Point point = array[i];
						if (Class51.cancellationToken_0.IsCancellationRequested)
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
							goto IL_01A9;
						}
						goto IL_00C4;
						IL_017E:
						i++;
						continue;
						IL_00C4:
						if (flag)
						{
							goto IL_017E;
						}
						Point[] array3;
						if (Class40.smethod_18(6, 1, Class51.bitmap_1, -1, out array3, Class51.rectangle_2, 25, 90, Class51.class76_0))
						{
							Class56.smethod_6(Class51.class76_0, FormLumberjack.Main.SpeedClick.Value, FormLumberjack.Main.SpeedSpam.Value, new Point(Class51.rectangle_3.Left + point.X, Class51.rectangle_3.Top + point.Y), new Size(Class51.bitmap_3[0].Width, Class51.bitmap_3[0].Height));
							list.Add(new Rectangle(point.X - 35, point.Y - 35, 70, 70));
							goto IL_017E;
						}
						return;
						IL_01A9:
						if (!Class51.cancellationToken_0.IsCancellationRequested)
						{
							goto IL_00C4;
						}
						goto IL_017E;
					}
					list.Clear();
					Class51.smethod_5(100.0, 0.0);
				}
			}
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x000361B4 File Offset: 0x000343B4
		private static void smethod_5(double double_0, double double_1 = 0.0)
		{
			if (Class51.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class51.random_0.NextDouble() * (num2 - num);
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
				if (Class51.cancellationToken_0.IsCancellationRequested)
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
					if (Class51.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x040004CF RID: 1231
		private static CancellationToken cancellationToken_0;

		// Token: 0x040004D0 RID: 1232
		private static Class76 class76_0;

		// Token: 0x040004D1 RID: 1233
		private static Bitmap bitmap_0;

		// Token: 0x040004D2 RID: 1234
		private static Bitmap bitmap_1;

		// Token: 0x040004D3 RID: 1235
		private static Bitmap[] bitmap_2 = new Bitmap[2];

		// Token: 0x040004D4 RID: 1236
		private static Bitmap[] bitmap_3 = new Bitmap[24];

		// Token: 0x040004D5 RID: 1237
		private static Rectangle rectangle_0;

		// Token: 0x040004D6 RID: 1238
		private static Rectangle rectangle_1;

		// Token: 0x040004D7 RID: 1239
		private static Rectangle rectangle_2;

		// Token: 0x040004D8 RID: 1240
		private static Rectangle rectangle_3;

		// Token: 0x040004D9 RID: 1241
		private static readonly Random random_0 = Class51.smethod_0();

		// Token: 0x040004DA RID: 1242
		private static bool bool_0 = false;

		// Token: 0x02000089 RID: 137
		[CompilerGenerated]
		[Serializable]
		private sealed class Class52
		{
			// Token: 0x0600040A RID: 1034 RVA: 0x00036298 File Offset: 0x00034498
			internal void method_0()
			{
				Bitmap bitmap_ = Class51.bitmap_0;
				if (bitmap_ != null)
				{
					bitmap_.Dispose();
				}
				Bitmap bitmap_2 = Class51.bitmap_1;
				if (bitmap_2 != null)
				{
					bitmap_2.Dispose();
				}
				foreach (Bitmap bitmap in Class51.bitmap_2)
				{
					if (bitmap != null)
					{
						bitmap.Dispose();
					}
				}
				foreach (Bitmap bitmap2 in Class51.bitmap_3)
				{
					if (bitmap2 != null)
					{
						bitmap2.Dispose();
					}
				}
			}

			// Token: 0x0600040B RID: 1035 RVA: 0x00004FF3 File Offset: 0x000031F3
			internal void method_1()
			{
				Class51.smethod_2();
			}

			// Token: 0x040004DB RID: 1243
			public static readonly Class51.Class52 class52_0 = new Class51.Class52();

			// Token: 0x040004DC RID: 1244
			public static Action action_0;

			// Token: 0x040004DD RID: 1245
			public static Action action_1;
		}
	}
}
