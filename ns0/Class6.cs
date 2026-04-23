using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ns1;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using psClick;

namespace ns0
{
	// Token: 0x0200002F RID: 47
	internal static class Class6
	{
		// Token: 0x060001A5 RID: 421 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000158A4 File Offset: 0x00013AA4
		public static void smethod_1(Class76 class76_1)
		{
			Class6.class76_0 = class76_1;
			Class6.cancellationToken_0 = Form1.cancellationToken_0;
			Class6.class48_0 = new Class48(Class6.class76_0, Class6.cancellationToken_0);
			Class6.class47_0 = new Class47(Class6.class76_0, Class6.cancellationToken_0);
			Class6.rect_0 = Class50.smethod_4(Class6.class76_0, "regionStatusBar");
			Class6.rect_1 = Class50.smethod_4(Class6.class76_0, "regionMessage");
			Class6.rectangle_0 = Class50.smethod_3(Class6.class76_0, "regionDemoran");
			Class6.rectangle_1 = Class50.smethod_3(Class6.class76_0, "regionCasinoEat");
			Class6.rectangle_2 = Class50.smethod_3(Class6.class76_0, "regionCasinoDrink");
			Class6.rectangle_3 = Class50.smethod_3(Class6.class76_0, "regionHospital");
			Class6.rectangle_4 = Class50.smethod_3(Class6.class76_0, "regionButtonHospital");
			Class6.size_0 = Class50.smethod_6(Class6.class76_0, "textMessage");
			string text = ((Class6.class76_0.Width == 1360) ? "1366x768" : Class6.class76_0.Resolution);
			Class6.mat_0 = Class50.smethod_2(text, "hunger");
			Class6.mat_1 = Class50.smethod_2(text, "thirst");
			Class6.mat_2 = Class50.smethod_2(text, "message_orange");
			Class6.bitmap_0 = Class50.smethod_1("Demorgan", "demorgan");
			Class6.list_0 = Class50.smethod_7<List<BaseSymbolStruct>>("SymbolBase", "message_base", new Func<string, List<BaseSymbolStruct>>(ReadText.LoadSymbolBase));
			new Point(Class6.class76_0.Width / 2, Class6.class76_0.Height);
			Class6.cancellationToken_0.Register(new Action(Class6.Class7.class7_0.method_0));
			Rectangle rectangle = new Rectangle
			{
				X = Class6.rect_0.X,
				Y = Class6.rect_0.Y,
				Width = Class6.rect_0.Width,
				Height = Class6.rect_0.Height
			};
			try
			{
				Class6.bool_0 = true;
				Class6.bool_1 = false;
				new Thread(new ThreadStart(Class6.smethod_3)).Start();
				if (FormAntiAfk.IsCasino)
				{
					Class46.smethod_6(Keys.Oemtilde, null, false);
					while (!Class6.cancellationToken_0.IsCancellationRequested)
					{
						Point[] array;
						if (FormAntiAfk.IsDemorgan && Class40.smethod_18(6, 1, Class6.bitmap_0, -1, out array, Class6.rectangle_0, 20, 100, Class6.class76_0))
						{
							throw new Form1.GException0("Персонаж находится в деморгане, работа остановлена.");
						}
						using (Mat mat = BitmapConverter.ToMat(Class40.smethod_5(Class6.class76_0, rectangle)))
						{
							Point point;
							if (Class6.bool_1 || Class40.smethod_17(Class6.mat_0, 0.8, false, out point, mat))
							{
								Class56.smethod_7(Class6.class76_0, 50, 50, Class6.rectangle_1);
							}
							if (Class6.bool_1 || Class40.smethod_17(Class6.mat_1, 0.8, false, out point, mat))
							{
								Class56.smethod_7(Class6.class76_0, 50, 50, Class6.rectangle_2);
							}
							if (Class6.bool_1)
							{
								Class6.bool_1 = false;
								new Thread(new ThreadStart(Class6.smethod_3)).Start();
							}
						}
						Class6.smethod_4(100.0, 0.0);
					}
				}
				else
				{
					while (!Class6.cancellationToken_0.IsCancellationRequested)
					{
						Point[] array;
						if (FormAntiAfk.IsDemorgan && Class40.smethod_18(6, 1, Class6.bitmap_0, -1, out array, Class6.rectangle_0, 20, 100, Class6.class76_0))
						{
							throw new Form1.GException0("Персонаж находится в деморгане, работа остановлена.");
						}
						if (Class6.smethod_2())
						{
							Class6.bool_1 = true;
							while (!Class6.cancellationToken_0.IsCancellationRequested)
							{
								if (Class6.smethod_2())
								{
									Class56.smethod_7(Class6.class76_0, Class6.random_0.Next(40, 60), Class6.random_0.Next(10, 30), Class6.rectangle_4);
								}
								Class6.smethod_4(1000.0, 0.0);
								if (FormAntiAfk.IsDemorgan && Class40.smethod_18(6, 1, Class6.bitmap_0, -1, out array, Class6.rectangle_0, 20, 100, Class6.class76_0))
								{
									throw new Form1.GException0("Персонаж находится в деморгане, работа остановлена.");
								}
							}
						}
						using (Mat mat2 = BitmapConverter.ToMat(Class40.smethod_5(Class6.class76_0, rectangle)))
						{
							Point point;
							if (Class6.bool_0 && (Class6.bool_1 || Class40.smethod_17(Class6.mat_0, 0.8, false, out point, mat2) || Class40.smethod_17(Class6.mat_1, 0.8, false, out point, mat2)))
							{
								using (Class20 @class = new Class20(class76_1, Class6.cancellationToken_0))
								{
									Class6.bool_0 = @class.method_2();
								}
								if (Class6.bool_1 && Class6.bool_0)
								{
									Class6.bool_1 = false;
									new Thread(new ThreadStart(Class6.smethod_3)).Start();
								}
							}
						}
						int num = Class6.random_0.Next(-400, 400);
						int num2 = Class6.random_0.Next(-200, 200);
						int num3 = Class6.random_0.Next(0, 3);
						if (num3 < 1)
						{
							Class49.smethod_0(num, num2);
							Class6.smethod_4(300.0, 500.0);
							Class49.smethod_0(-num, -num2);
							Class6.smethod_4(1000.0, 2000.0);
						}
						int num4 = Class6.random_0.Next(0, 2);
						int num5 = Class6.random_0.Next(0, 2);
						int num6 = Class6.random_0.Next(0, 2);
						int num7 = Class6.random_0.Next(0, 2);
						int num8 = Class6.random_0.Next(0, 4);
						int num9 = Class6.random_0.Next(0, 4);
						if (num7 > 1)
						{
							Class56.smethod_24(-1, -1, 0, 0);
						}
						if (FormAntiAfk.IsPhone && num8 == 1)
						{
							Class6.class48_0.method_0();
							Class6.class48_0.method_1();
						}
						if (FormAntiAfk.IsPad && num9 == 1)
						{
							Class6.class47_0.method_0();
							Class6.class47_0.method_1();
						}
						if (FormAntiAfk.IsMove && num4 < 1)
						{
							Class46.smethod_8(Keys.W, Class6.class76_0, false);
						}
						else if (FormAntiAfk.IsMove)
						{
							Class46.smethod_8(Keys.S, Class6.class76_0, false);
						}
						Class6.smethod_4(200.0, 600.0);
						Class6.cancellationToken_0.ThrowIfCancellationRequested();
						if (FormAntiAfk.IsMove && num5 < 1)
						{
							Class46.smethod_8(Keys.A, Class6.class76_0, false);
						}
						else if (FormAntiAfk.IsMove)
						{
							Class46.smethod_8(Keys.D, Class6.class76_0, false);
						}
						Class6.smethod_4(750.0, 1251.0);
						Class6.cancellationToken_0.ThrowIfCancellationRequested();
						if (FormAntiAfk.IsMove && num6 < 1)
						{
							Class46.smethod_8(Keys.Space, Class6.class76_0, false);
							Class6.smethod_4(80.0, 250.0);
							Class46.smethod_9(Keys.Space, Class6.class76_0, false, true);
						}
						Class6.smethod_4(1500.0, 2500.0);
						Class6.cancellationToken_0.ThrowIfCancellationRequested();
						if (num3 == 1)
						{
							Class49.smethod_0(num, num2);
							Class6.smethod_4(300.0, 500.0);
							Class49.smethod_0(-num, -num2);
							Class6.smethod_4(1000.0, 2000.0);
						}
						if (FormAntiAfk.IsMove && num6 > 0)
						{
							Class46.smethod_8(Keys.Space, Class6.class76_0, false);
							Class6.smethod_4(80.0, 250.0);
							Class46.smethod_9(Keys.Space, Class6.class76_0, false, true);
						}
						if (FormAntiAfk.IsMove && num4 < 1)
						{
							Class46.smethod_9(Keys.W, Class6.class76_0, false, true);
						}
						else if (FormAntiAfk.IsMove)
						{
							Class46.smethod_9(Keys.S, Class6.class76_0, false, true);
						}
						Class6.smethod_4(200.0, 500.0);
						if (num3 > 1)
						{
							Class49.smethod_0(num, num2);
							Class6.smethod_4(300.0, 500.0);
							Class49.smethod_0(-num, -num2);
							Class6.smethod_4(1000.0, 2000.0);
						}
						if (FormAntiAfk.IsMove && num5 < 1)
						{
							Class46.smethod_9(Keys.A, Class6.class76_0, false, true);
						}
						else if (FormAntiAfk.IsMove)
						{
							Class46.smethod_9(Keys.D, Class6.class76_0, false, true);
						}
						Class6.smethod_4((double)new Random().Next(2000, 6501), 0.0);
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
			catch (Exception)
			{
				Form1.Main.method_11();
				Form1.smethod_0();
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000161BC File Offset: 0x000143BC
		private static bool smethod_2()
		{
			bool flag;
			try
			{
				string text;
				using (Bitmap bitmap = Class40.smethod_5(Class6.class76_0, Class6.rectangle_3))
				{
					text = Class4.smethod_2(bitmap, Class6.list_0);
				}
				text = Regex.Replace(text, "[^а-я]", "");
				flag = Class72.smethod_0(text, "больница".Replace(" ", "")) >= 0.7 || Class72.smethod_0(text, "водьнина".Replace(" ", "")) >= 0.7 || Class72.smethod_0(text, "шдьии".Replace(" ", "")) >= 0.9;
			}
			catch (Form1.GException0)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0001629C File Offset: 0x0001449C
		private static void smethod_3()
		{
			try
			{
				Rectangle rectangle = new Rectangle
				{
					Width = Class6.size_0.Width,
					Height = Class6.size_0.Height
				};
				while (!Class6.cancellationToken_0.IsCancellationRequested && !Class6.bool_1)
				{
					using (Bitmap bitmap = Class40.smethod_0(Class6.class76_0, default(Rectangle)))
					{
						using (Mat mat = BitmapConverter.ToMat(bitmap))
						{
							Point point;
							if (Class40.smethod_16(Class6.mat_2, Class6.rect_1, 0.8, false, out point, mat))
							{
								rectangle.X = Class6.rect_1.X + point.X + Class6.mat_2.Width + 3;
								rectangle.Y = Class6.rect_1.Y + point.Y - 4;
								string text;
								using (Bitmap bitmap2 = bitmap.Clone(rectangle, bitmap.PixelFormat))
								{
									text = Class4.smethod_2(bitmap2, Class6.list_0);
								}
								text = Regex.Replace(text, "[^а-я]", "");
								if (Class72.smethod_0(text, "вам срочно нужно выпить воды вы теряете силы".Replace(" ", "")) >= 0.5 || Class72.smethod_0(text, "вам срочно нужно поесть вы теряете силы".Replace(" ", "")) >= 0.5)
								{
									Class6.bool_1 = true;
									break;
								}
								Class6.smethod_4(100.0, 0.0);
							}
							else
							{
								Class6.smethod_4(100.0, 0.0);
							}
						}
					}
				}
			}
			catch (Form1.GException0)
			{
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000164B4 File Offset: 0x000146B4
		private static void smethod_4(double double_0, double double_1 = 0.0)
		{
			if (Class6.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class6.random_0.NextDouble() * (num2 - num);
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
				if (Class6.cancellationToken_0.IsCancellationRequested)
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
					if (Class6.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x040001DA RID: 474
		private static CancellationToken cancellationToken_0;

		// Token: 0x040001DB RID: 475
		private static Class76 class76_0;

		// Token: 0x040001DC RID: 476
		private static Rect rect_0;

		// Token: 0x040001DD RID: 477
		private static Rect rect_1;

		// Token: 0x040001DE RID: 478
		private static Rectangle rectangle_0;

		// Token: 0x040001DF RID: 479
		private static Rectangle rectangle_1;

		// Token: 0x040001E0 RID: 480
		private static Rectangle rectangle_2;

		// Token: 0x040001E1 RID: 481
		private static Rectangle rectangle_3;

		// Token: 0x040001E2 RID: 482
		private static Rectangle rectangle_4;

		// Token: 0x040001E3 RID: 483
		private static Size size_0;

		// Token: 0x040001E4 RID: 484
		private static Mat mat_0;

		// Token: 0x040001E5 RID: 485
		private static Mat mat_1;

		// Token: 0x040001E6 RID: 486
		private static Mat mat_2;

		// Token: 0x040001E7 RID: 487
		private static Bitmap bitmap_0;

		// Token: 0x040001E8 RID: 488
		private static readonly Random random_0 = Class6.smethod_0();

		// Token: 0x040001E9 RID: 489
		private static Class48 class48_0;

		// Token: 0x040001EA RID: 490
		private static Class47 class47_0;

		// Token: 0x040001EB RID: 491
		private static List<BaseSymbolStruct> list_0;

		// Token: 0x040001EC RID: 492
		private static bool bool_0;

		// Token: 0x040001ED RID: 493
		private static bool bool_1;

		// Token: 0x02000030 RID: 48
		[CompilerGenerated]
		[Serializable]
		private sealed class Class7
		{
			// Token: 0x060001AD RID: 429 RVA: 0x00016598 File Offset: 0x00014798
			internal void method_0()
			{
				Class46.smethod_9(Keys.W, null, false, true);
				Class46.smethod_9(Keys.A, null, false, true);
				Class46.smethod_9(Keys.S, null, false, true);
				Class46.smethod_9(Keys.D, null, false, true);
				Class46.smethod_9(Keys.Space, null, false, true);
				Mat mat_ = Class6.mat_2;
				if (mat_ != null)
				{
					mat_.Dispose();
				}
				Bitmap bitmap_ = Class6.bitmap_0;
				if (bitmap_ != null)
				{
					bitmap_.Dispose();
				}
				Mat mat_2 = Class6.mat_0;
				if (mat_2 != null)
				{
					mat_2.Dispose();
				}
				Mat mat_3 = Class6.mat_1;
				if (mat_3 == null)
				{
					return;
				}
				mat_3.Dispose();
			}

			// Token: 0x040001EE RID: 494
			public static readonly Class6.Class7 class7_0 = new Class6.Class7();

			// Token: 0x040001EF RID: 495
			public static Action action_0;
		}
	}
}
