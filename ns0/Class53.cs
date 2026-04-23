using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ns1;
using OpenCvSharp;

namespace ns0
{
	// Token: 0x0200008A RID: 138
	internal static class Class53
	{
		// Token: 0x0600040C RID: 1036 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0003630C File Offset: 0x0003450C
		public static void smethod_1(Class76 class76_1)
		{
			Class53.class76_0 = class76_1;
			Class53.cancellationToken_0 = Form1.cancellationToken_0;
			Class53.cancellationToken_0.Register(new Action(Class53.Class54.class54_0.method_0));
			Class53.rectangle_0 = Class50.smethod_3(Class53.class76_0, "regionE");
			Class53.rectangle_1 = Class50.smethod_3(Class53.class76_0, "regionLBM");
			Class53.rect_0 = Class50.smethod_4(Class53.class76_0, "regionGame");
			Class53.rectangle_2 = Class50.smethod_3(Class53.class76_0, "regionStone");
			Class53.bitmap_0 = Class50.smethod_1(Class53.class76_0.Resolution, "e");
			Class53.mat_0 = Class50.smethod_2(Class53.class76_0.Resolution, "game");
			for (int i = 0; i < Class53.bitmap_1.Length; i++)
			{
				Class53.bitmap_1[i] = Class50.smethod_1("LBM", "lbm_" + i.ToString());
			}
			for (int j = 0; j < Class53.bitmap_2.Length; j++)
			{
				Class53.bitmap_2[j] = Class50.smethod_1("Stone", "stone_" + j.ToString());
			}
			if (FormMiner.IsAutoRunning)
			{
				Task.Run(new Action(Class53.Class54.class54_0.method_1));
			}
			try
			{
				if (!Class53.cancellationToken_0.IsCancellationRequested)
				{
					Class53.class76_0.method_2();
					while (!Class53.cancellationToken_0.IsCancellationRequested)
					{
						Point[] array;
						if (!Class53.cancellationToken_0.IsCancellationRequested && Class40.smethod_18(6, 1, Class53.bitmap_1[0], -1, out array, Class53.rectangle_1, 10, 90, Class53.class76_0))
						{
							if (FormMiner.IsAutoRunning)
							{
								Class53.bool_0 = false;
								Class53.smethod_5(100.0, 0.0);
							}
							Class53.smethod_3();
						}
						Point point;
						if (!Class53.cancellationToken_0.IsCancellationRequested && Class40.smethod_13(Class53.mat_0, Class53.rect_0, 0.9, false, out point, Class53.class76_0))
						{
							if (FormMiner.IsAutoRunning)
							{
								Class53.bool_0 = false;
								Class53.smethod_5(100.0, 0.0);
							}
							Class53.smethod_5(250.0 + Class53.random_0.NextDouble() * 500.0, 0.0);
							Class53.smethod_4();
							if (FormMiner.IsAutoRunning)
							{
								Class53.bool_0 = true;
							}
							Class53.smethod_5(1000.0 + Class53.random_0.NextDouble() * 200.0, 0.0);
						}
						if (!Class53.cancellationToken_0.IsCancellationRequested && FormMiner.IsPressE && Class40.smethod_18(6, 1, Class53.bitmap_0, -2, out array, Class53.rectangle_0, 25, 90, Class53.class76_0))
						{
							Class46.smethod_6(Keys.E, null, false);
							if (Class40.smethod_19(6, 1, Class53.bitmap_1[0], -1, out array, Class53.rectangle_1, 10, 90, Class53.class76_0, Class53.cancellationToken_0, 1000, 100, false))
							{
								Class53.smethod_5(150.0 + Class53.random_0.NextDouble() * 100.0, 0.0);
								Class53.smethod_3();
							}
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

		// Token: 0x0600040E RID: 1038 RVA: 0x00036694 File Offset: 0x00034894
		private static void smethod_2()
		{
			while (!Class53.cancellationToken_0.IsCancellationRequested)
			{
				if (!Class46.smethod_10(Keys.LShiftKey) || !Class46.smethod_10(Keys.W) || !Class53.class76_0.IsActive)
				{
					if (!Class53.bool_0 || !Class53.class76_0.IsActive)
					{
						Class53.smethod_5(80.0, 120.0);
						continue;
					}
				}
				while (!Class53.cancellationToken_0.IsCancellationRequested)
				{
					if ((!Class46.smethod_10(Keys.LShiftKey) && !Class46.smethod_10(Keys.W) && Class53.class76_0.IsActive) || (Class53.bool_0 && Class53.class76_0.IsActive))
					{
						Class46.smethod_8(Keys.W, null, false);
						Class46.smethod_8(Keys.LShiftKey, null, false);
						Class53.bool_0 = true;
						while (!Class53.cancellationToken_0.IsCancellationRequested)
						{
							if (Class46.smethod_10(Keys.S) || !Class46.smethod_10(Keys.LShiftKey) || !Class46.smethod_10(Keys.W) || !Class53.class76_0.IsActive || !Class53.bool_0)
							{
								Class46.smethod_9(Keys.W, null, false, true);
								Class46.smethod_9(Keys.LShiftKey, null, false, true);
								Class53.bool_0 = false;
								break;
							}
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x000367D0 File Offset: 0x000349D0
		private static void smethod_3()
		{
			while (!Class53.cancellationToken_0.IsCancellationRequested)
			{
				Point[] array;
				if (!Class40.smethod_24(6, 1, -1, -1, Class53.bitmap_1, -1, out array, Class53.rectangle_1, 10, 90, Class53.class76_0))
				{
					return;
				}
				Class56.smethod_17(FormMiner.Main.SpeedSpam.Value);
			}
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00036824 File Offset: 0x00034A24
		private static void smethod_4()
		{
			Point point;
			while (!Class53.cancellationToken_0.IsCancellationRequested && Class40.smethod_13(Class53.mat_0, Class53.rect_0, 0.9, false, out point, Class53.class76_0))
			{
				using (Bitmap bitmap = Class40.smethod_5(Class53.class76_0, Class53.rectangle_2))
				{
					if (bitmap == null)
					{
						break;
					}
					Point[] array;
					Class40.smethod_23(3, 0, 0, 2, Class53.bitmap_2, -1, out array, 20, 90, bitmap);
					Point[] array2;
					Class40.smethod_23(3, 0, 1, 16, Class53.bitmap_2, -1, out array2, 17, 90, bitmap);
					Point[] array3;
					Class40.smethod_23(3, 0, 17, 6, Class53.bitmap_2, -1, out array3, 6, 90, bitmap);
					Point[] array4 = array3.Concat(array).Concat(array2).ToArray<Point>();
					List<Rectangle> list = new List<Rectangle>();
					if (array4 != null && array4.Length != 0 && !Class53.cancellationToken_0.IsCancellationRequested)
					{
						foreach (Point point2 in array4)
						{
							Class53.Class55 @class = new Class53.Class55();
							if (Class53.cancellationToken_0.IsCancellationRequested)
							{
								return;
							}
							@class.point_0 = new Point(Class53.rectangle_2.Left + point2.X, Class53.rectangle_2.Top + point2.Y);
							bool flag = list.Any(new Func<Rectangle, bool>(@class.method_0));
							if (!Class53.cancellationToken_0.IsCancellationRequested && !flag)
							{
								if (!Class40.smethod_13(Class53.mat_0, Class53.rect_0, 0.9, false, out point, Class53.class76_0))
								{
									return;
								}
								Class56.smethod_6(Class53.class76_0, FormMiner.Main.SpeedClick.Value, FormMiner.Main.SpeedSpam.Value, @class.point_0, Class53.bitmap_2[0].Size);
								list.Add(new Rectangle(@class.point_0.X - 40, @class.point_0.Y - 40, 80, 80));
							}
						}
					}
				}
			}
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00036A58 File Offset: 0x00034C58
		private static void smethod_5(double double_0, double double_1 = 0.0)
		{
			if (Class53.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class53.random_0.NextDouble() * (num2 - num);
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
				if (Class53.cancellationToken_0.IsCancellationRequested)
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
					if (Class53.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x040004DE RID: 1246
		private static CancellationToken cancellationToken_0;

		// Token: 0x040004DF RID: 1247
		private static Class76 class76_0;

		// Token: 0x040004E0 RID: 1248
		private static Bitmap bitmap_0 = null;

		// Token: 0x040004E1 RID: 1249
		private static Mat mat_0;

		// Token: 0x040004E2 RID: 1250
		private static Bitmap[] bitmap_1 = new Bitmap[2];

		// Token: 0x040004E3 RID: 1251
		private static Bitmap[] bitmap_2 = new Bitmap[24];

		// Token: 0x040004E4 RID: 1252
		private static Rectangle rectangle_0;

		// Token: 0x040004E5 RID: 1253
		private static Rectangle rectangle_1;

		// Token: 0x040004E6 RID: 1254
		private static Rectangle rectangle_2;

		// Token: 0x040004E7 RID: 1255
		private static Rect rect_0;

		// Token: 0x040004E8 RID: 1256
		private static readonly Random random_0 = Class53.smethod_0();

		// Token: 0x040004E9 RID: 1257
		private static bool bool_0 = false;

		// Token: 0x0200008B RID: 139
		[CompilerGenerated]
		[Serializable]
		private sealed class Class54
		{
			// Token: 0x06000415 RID: 1045 RVA: 0x00036B3C File Offset: 0x00034D3C
			internal void method_0()
			{
				Bitmap bitmap_ = Class53.bitmap_0;
				if (bitmap_ != null)
				{
					bitmap_.Dispose();
				}
				Mat mat_ = Class53.mat_0;
				if (mat_ != null)
				{
					mat_.Dispose();
				}
				foreach (Bitmap bitmap in Class53.bitmap_1)
				{
					if (bitmap != null)
					{
						bitmap.Dispose();
					}
				}
				foreach (Bitmap bitmap2 in Class53.bitmap_2)
				{
					if (bitmap2 != null)
					{
						bitmap2.Dispose();
					}
				}
			}

			// Token: 0x06000416 RID: 1046 RVA: 0x00005035 File Offset: 0x00003235
			internal void method_1()
			{
				Class53.smethod_2();
			}

			// Token: 0x040004EA RID: 1258
			public static readonly Class53.Class54 class54_0 = new Class53.Class54();

			// Token: 0x040004EB RID: 1259
			public static Action action_0;

			// Token: 0x040004EC RID: 1260
			public static Action action_1;
		}

		// Token: 0x0200008C RID: 140
		[CompilerGenerated]
		private sealed class Class55
		{
			// Token: 0x06000418 RID: 1048 RVA: 0x0000503C File Offset: 0x0000323C
			internal bool method_0(Rectangle rectangle_0)
			{
				return rectangle_0.Contains(this.point_0);
			}

			// Token: 0x040004ED RID: 1261
			public Point point_0;
		}
	}
}
