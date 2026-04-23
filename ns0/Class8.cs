using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using ns1;
using OpenCvSharp;

namespace ns0
{
	// Token: 0x02000031 RID: 49
	internal static class Class8
	{
		// Token: 0x060001AE RID: 430 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0001661C File Offset: 0x0001481C
		public static void smethod_1(Class76 class76_1)
		{
			Class8.class76_0 = class76_1;
			Class8.cancellationToken_0 = Form1.cancellationToken_0;
			Class8.cancellationToken_0.Register(new Action(Class8.Class9.class9_0.method_0));
			string text = ((Class8.class76_0.Width == 1360) ? "1366x768" : Class8.class76_0.Resolution);
			Class8.rectangle_0 = Class50.smethod_3(Class8.class76_0, "regionGameBoards");
			Class8.rectangle_1 = Class50.smethod_3(Class8.class76_0, "regionGameElevator");
			Class8.rectangle_2 = Class50.smethod_3(Class8.class76_0, "regionBordsHit");
			Class8.rectangle_3 = Class50.smethod_3(Class8.class76_0, "regionElevatorHit");
			Class8.bitmap_0 = Class50.smethod_1(text, "gameBoards");
			Class8.bitmap_1 = Class50.smethod_1("Hit", "hit");
			Class8.bitmap_2 = Class50.smethod_1(text, "greenBoards");
			Class8.bitmap_3[0] = Class50.smethod_1(text, "greenElevator");
			Class8.bitmap_3[1] = Class50.smethod_1(text, "orangeElevator");
			try
			{
				if (!Class8.cancellationToken_0.IsCancellationRequested)
				{
					Class8.class76_0.method_2();
					while (!Class8.cancellationToken_0.IsCancellationRequested)
					{
						if (Class8.smethod_2())
						{
							Point[] array;
							while (!Class8.cancellationToken_0.IsCancellationRequested && Class8.smethod_2() && Class40.smethod_18(3, 1, Class8.bitmap_2, -2, out array, Class8.rectangle_2, 20, 80, Class8.class76_0))
							{
								Rectangle rectangle = new Rectangle(Class8.rectangle_2.X + array[0].X, Class8.rectangle_2.Y, Class8.bitmap_2.Width, Class8.rectangle_2.Height);
								while (!Class8.cancellationToken_0.IsCancellationRequested && Class8.smethod_2())
								{
									Point[] array2;
									if (Class40.smethod_18(3, 1, Class8.bitmap_1, -1, out array2, rectangle, 15, 100, Class8.class76_0))
									{
										Class46.smethod_6(Keys.Space, null, false);
										Class8.smethod_5(FormBuilder.Main.SpeedHit.Value);
										break;
									}
								}
							}
						}
						Point[] array3;
						if (Class40.smethod_24(6, 0, 0, 2, Class8.bitmap_3, -2, out array3, Class8.rectangle_3, 20, 98, Class8.class76_0))
						{
							int num = array3.Length - 1;
							Rectangle rectangle2 = new Rectangle(Class8.rectangle_3.X, Class8.rectangle_3.Y + array3[num].Y, Class8.rectangle_3.Width, Class8.bitmap_3[0].Height);
							Class46.smethod_8(Keys.Space, null, false);
							while (!Class8.cancellationToken_0.IsCancellationRequested && Class8.smethod_3())
							{
								if (Class40.smethod_18(3, 1, Class8.bitmap_1, -1, out array3, rectangle2, 15, 100, Class8.class76_0))
								{
									if (array3[0].Y < Class8.bitmap_3[0].Height / 3)
									{
										Class46.smethod_9(Keys.Space, null, false, true);
									}
									else
									{
										Class46.smethod_8(Keys.Space, null, false);
									}
								}
							}
							Class46.smethod_9(Keys.Space, null, false, true);
							Class8.smethod_4(200.0, 0.0);
							Class46.smethod_8(Keys.E, null, false);
							Class8.smethod_4(3000.0, 0.0);
							Class46.smethod_9(Keys.E, null, false, true);
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

		// Token: 0x060001B0 RID: 432 RVA: 0x0001699C File Offset: 0x00014B9C
		private static bool smethod_2()
		{
			Point[] array;
			return !Class8.cancellationToken_0.IsCancellationRequested && Class40.smethod_18(6, 1, Class8.bitmap_0, -2, out array, Class8.rectangle_0, 20, 95, Class8.class76_0);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000169D8 File Offset: 0x00014BD8
		private static bool smethod_3()
		{
			Point[] array;
			return !Class8.cancellationToken_0.IsCancellationRequested && Class40.smethod_18(6, 1, Class8.bitmap_0, -2, out array, Class8.rectangle_1, 20, 95, Class8.class76_0);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00016A14 File Offset: 0x00014C14
		private static void smethod_4(double double_2, double double_3 = 0.0)
		{
			if (Class8.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_3 > 0.0)
			{
				double num = Math.Min(double_2, double_3);
				double num2 = Math.Max(double_2, double_3);
				num3 = num + Class8.random_0.NextDouble() * (num2 - num);
			}
			else
			{
				num3 = double_2;
			}
			int i = (int)Math.Floor(num3);
			double num4 = num3 - (double)i;
			int num5 = 50;
			while (i > 0)
			{
				if (Class8.cancellationToken_0.IsCancellationRequested)
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
					if (Class8.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00016AF8 File Offset: 0x00014CF8
		public static void smethod_5(int int_2)
		{
			if (int_2 < 0 || int_2 > 100)
			{
				throw new ArgumentOutOfRangeException("speed", string.Format("speed must be in range [{0}..{1}]", 0, 100));
			}
			double num = 1.0 - (double)int_2 / 100.0;
			double num2 = num * 800.0;
			double num3 = num * 150.0;
			if (num3 <= 0.0)
			{
				Class8.smethod_4(num2, 0.0);
				return;
			}
			double num4 = num2 - num3 / 2.0;
			double num5 = num2 + num3 / 2.0;
			if (num4 < 0.0)
			{
				num4 = 0.0;
			}
			Class8.smethod_4(num4, num5);
		}

		// Token: 0x040001F0 RID: 496
		private static CancellationToken cancellationToken_0;

		// Token: 0x040001F1 RID: 497
		private static Class76 class76_0;

		// Token: 0x040001F2 RID: 498
		private static Mat mat_0 = null;

		// Token: 0x040001F3 RID: 499
		private static Bitmap bitmap_0;

		// Token: 0x040001F4 RID: 500
		private static Bitmap bitmap_1;

		// Token: 0x040001F5 RID: 501
		private static Bitmap bitmap_2;

		// Token: 0x040001F6 RID: 502
		private static Bitmap[] bitmap_3 = new Bitmap[2];

		// Token: 0x040001F7 RID: 503
		private static Rectangle rectangle_0;

		// Token: 0x040001F8 RID: 504
		private static Rectangle rectangle_1;

		// Token: 0x040001F9 RID: 505
		private static Rectangle rectangle_2;

		// Token: 0x040001FA RID: 506
		private static Rectangle rectangle_3;

		// Token: 0x040001FB RID: 507
		private static bool bool_0 = false;

		// Token: 0x040001FC RID: 508
		private static readonly Random random_0 = Class8.smethod_0();

		// Token: 0x040001FD RID: 509
		private const int int_0 = 0;

		// Token: 0x040001FE RID: 510
		private const int int_1 = 100;

		// Token: 0x040001FF RID: 511
		private const double double_0 = 800.0;

		// Token: 0x04000200 RID: 512
		private const double double_1 = 150.0;

		// Token: 0x02000032 RID: 50
		[CompilerGenerated]
		[Serializable]
		private sealed class Class9
		{
			// Token: 0x060001B7 RID: 439 RVA: 0x00016BB8 File Offset: 0x00014DB8
			internal void method_0()
			{
				Mat mat_ = Class8.mat_0;
				if (mat_ != null)
				{
					mat_.Dispose();
				}
				Bitmap bitmap_ = Class8.bitmap_0;
				if (bitmap_ != null)
				{
					bitmap_.Dispose();
				}
				Bitmap bitmap_2 = Class8.bitmap_1;
				if (bitmap_2 != null)
				{
					bitmap_2.Dispose();
				}
				Bitmap bitmap_3 = Class8.bitmap_2;
				if (bitmap_3 != null)
				{
					bitmap_3.Dispose();
				}
				foreach (Bitmap bitmap in Class8.bitmap_3)
				{
					if (bitmap != null)
					{
						bitmap.Dispose();
					}
				}
			}

			// Token: 0x04000201 RID: 513
			public static readonly Class8.Class9 class9_0 = new Class8.Class9();

			// Token: 0x04000202 RID: 514
			public static Action action_0;
		}
	}
}
