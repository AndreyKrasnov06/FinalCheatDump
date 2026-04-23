using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using psClick;

namespace ns0
{
	// Token: 0x0200009E RID: 158
	internal static class Class67
	{
		// Token: 0x0600047B RID: 1147 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00038E5C File Offset: 0x0003705C
		public static void smethod_1(Class76 class76_1)
		{
			Class67.class76_0 = class76_1;
			Class67.cancellationToken_1 = Form1.cancellationToken_0;
			Class67.cancellationToken_1.Register(new Action(Class67.Class68.class68_0.method_0));
			object obj = ((Class67.class76_0.Width == 1360) ? "1366x768" : Class67.class76_0.Resolution);
			Class67.point_0 = Class50.smethod_5(Class67.class76_0, "center");
			Class67.rectangle_6 = Class50.smethod_3(Class67.class76_0, "stop");
			Class67.rectangle_2 = new Rectangle(Class67.point_0.X, Class67.point_0.Y + 48, 2, 50);
			Class67.rectangle_3 = new Rectangle(Class67.point_0.X, Class67.point_0.Y + 48, 2, 90);
			Class67.rectangle_4 = new Rectangle(Class67.point_0.X - 60, Class67.point_0.Y + 24, 60, 50);
			Class67.rectangle_5 = new Rectangle(Class67.point_0.X + 2, Class67.point_0.Y + 24, 60, 50);
			Class67.rectangle_0 = Class50.smethod_3(Class67.class76_0, "regionE");
			Class67.rectangle_1 = Class50.smethod_3(Class67.class76_0, "regionGame");
			Class67.rect_0 = Class50.smethod_4(Class67.class76_0, "regionMessage");
			Class67.size_0 = Class50.smethod_6(Class67.class76_0, "textMessage");
			object obj2 = obj;
			Class67.bitmap_0 = Class50.smethod_1(obj2, "e");
			Class67.bitmap_1 = Class50.smethod_1(obj2, "game");
			Class67.mat_0 = Class50.smethod_2(obj2, "message_green");
			Class67.mat_1 = Class50.smethod_2(obj2, "message_red");
			Class67.list_0 = Class50.smethod_7<List<BaseSymbolStruct>>("SymbolBase", "message_base", new Func<string, List<BaseSymbolStruct>>(ReadText.LoadSymbolBase));
			try
			{
				Class67.class76_0.method_2();
				Class46.smethod_5(Keys.E, Class67.class76_0, false);
				while (!Class67.cancellationToken_1.IsCancellationRequested)
				{
					using (Bitmap bitmap = Class40.smethod_2(Class67.class76_0))
					{
						Point[] array;
						if (Class67.smethod_3(bitmap))
						{
							Class67.smethod_4();
							Class67.smethod_2();
						}
						else if (Class40.smethod_20(6, 1, Class67.bitmap_0, -1, out array, Class67.rectangle_0, 25, 90, bitmap))
						{
							Class46.smethod_5(Keys.E, Class67.class76_0, false);
							Class67.smethod_10(50.0, 0.0);
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

		// Token: 0x0600047D RID: 1149 RVA: 0x00039104 File Offset: 0x00037304
		private static void smethod_2()
		{
			Rectangle rectangle = new Rectangle
			{
				Width = Class67.size_0.Width,
				Height = Class67.size_0.Height
			};
			while (!Class67.cancellationToken_1.IsCancellationRequested)
			{
				Class67.smethod_10(50.0, 0.0);
				using (Bitmap bitmap = Class40.smethod_2(Class67.class76_0))
				{
					using (Mat mat = BitmapConverter.ToMat(bitmap))
					{
						Point point;
						if (Class40.smethod_16(Class67.mat_0, Class67.rect_0, 0.8, false, out point, mat))
						{
							break;
						}
						Point point2;
						if (Class40.smethod_16(Class67.mat_1, Class67.rect_0, 0.8, false, out point2, mat))
						{
							Class67.smethod_9();
							rectangle.X = Class67.rect_0.X + point2.X + Class67.mat_1.Width + 3;
							rectangle.Y = Class67.rect_0.Y + point2.Y - 4;
							using (Bitmap bitmap2 = bitmap.Clone(rectangle, bitmap.PixelFormat))
							{
								string text = Regex.Replace(Class4.smethod_2(bitmap2, Class67.list_0), "[^а-я]", "");
								if (Class72.smethod_0(text, "предмет не вмещается по весу".Replace(" ", "")) >= 0.5 || Class72.smethod_0(text, "у вас нет свободного места в инвентаре".Replace(" ", "")) >= 0.5)
								{
									Console.Beep(400, 400);
									Console.Beep(400, 400);
									throw new Form1.GException0("Инвентарь переполнен.");
								}
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00039318 File Offset: 0x00037518
		private static bool smethod_3(Bitmap bitmap_3 = null)
		{
			bitmap_3 = bitmap_3 ?? Class40.smethod_2(Class67.class76_0);
			Point[] array;
			return Class40.smethod_20(6, 1, Class67.bitmap_1, -1, out array, Class67.rectangle_1, 25, 90, bitmap_3);
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00039354 File Offset: 0x00037554
		private static void smethod_4()
		{
			try
			{
				Class67.bool_2 = false;
				Class67.bool_0 = false;
				Class67.bool_1 = false;
				Class67.cancellationTokenSource_0 = new CancellationTokenSource();
				Class67.cancellationToken_0 = Class67.cancellationTokenSource_0.Token;
				Thread thread = new Thread(new ThreadStart(Class67.Class68.class68_0.method_1));
				Thread thread2 = new Thread(new ThreadStart(Class67.Class68.class68_0.method_2));
				thread.Start();
				thread2.Start();
				while (!Class67.cancellationToken_1.IsCancellationRequested && Class67.smethod_3(null))
				{
					Class67.smethod_10(1.0, 0.0);
				}
				Class67.cancellationTokenSource_0.Cancel();
				Class67.smethod_9();
			}
			catch (Exception)
			{
				Class67.smethod_9();
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00039438 File Offset: 0x00037638
		private static void smethod_5()
		{
			try
			{
				Class67.smethod_6(Keys.Space);
				Class67.smethod_10(800.0, 1200.0);
				Class67.smethod_7(Keys.Space, true);
				while (!Class67.cancellationToken_0.IsCancellationRequested)
				{
					if (!Class67.bool_2)
					{
						if (Class67.bool_0)
						{
							if (Class67.cancellationToken_0.IsCancellationRequested)
							{
								break;
							}
							Class67.smethod_6(Keys.Space);
							Class67.smethod_10(100.0, 0.0);
							if (Class67.cancellationToken_0.IsCancellationRequested)
							{
								break;
							}
							Class67.bool_0 = false;
						}
						using (Bitmap bitmap = Class40.smethod_0(Class67.class76_0, Class67.rectangle_6))
						{
							Point[] array;
							if (Class40.smethod_31(1, new List<Color> { Color.FromArgb(233, 141, 3) }, new List<int> { 1 }, 1, out array, 7, 2, 2, 2, 2, 15, 1, 9999, bitmap))
							{
								Class67.smethod_7(Keys.Space, true);
							}
						}
						if (Class67.bool_1)
						{
							Class67.bool_1 = false;
							using (Bitmap bitmap2 = Class40.smethod_0(Class67.class76_0, Class67.rectangle_3))
							{
								Point[] array;
								if (Class40.smethod_31(200, new List<Color> { Color.FromArgb(255, 255, 255) }, new List<int> { 1 }, 1, out array, 7, 2, 2, 2, 2, 15, 1, 9999, bitmap2))
								{
									if (Class67.cancellationToken_0.IsCancellationRequested)
									{
										break;
									}
									Class67.smethod_6(Keys.Space);
								}
								else
								{
									Class67.smethod_7(Keys.Space, true);
								}
								continue;
							}
						}
						using (Bitmap bitmap3 = Class40.smethod_0(Class67.class76_0, Class67.rectangle_2))
						{
							Point[] array;
							if (Class40.smethod_31(200, new List<Color> { Color.FromArgb(255, 255, 255) }, new List<int> { 1 }, 1, out array, 7, 2, 2, 2, 2, 15, 1, 9999, bitmap3))
							{
								if (Class67.cancellationToken_0.IsCancellationRequested)
								{
									break;
								}
								Class67.smethod_6(Keys.Space);
							}
							else
							{
								Class67.smethod_7(Keys.Space, true);
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
				else
				{
					Form1.smethod_0();
				}
			}
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x000396E8 File Offset: 0x000378E8
		private static void smethod_6(Keys keys_0)
		{
			while (!Class67.cancellationToken_0.IsCancellationRequested)
			{
				if (!Class67.bool_2)
				{
					Class67.bool_2 = true;
					Class46.smethod_8(keys_0, null, true);
					Class67.bool_2 = false;
					return;
				}
				Class67.smethod_10(1.0, 0.0);
			}
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00039738 File Offset: 0x00037938
		private static void smethod_7(Keys keys_0, bool bool_3 = true)
		{
			while (!Class67.cancellationToken_0.IsCancellationRequested)
			{
				if (!Class67.bool_2)
				{
					Class67.bool_2 = true;
					Class46.smethod_9(keys_0, null, true, true);
					Class67.bool_2 = false;
					return;
				}
				Class67.smethod_10(1.0, 0.0);
			}
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0003978C File Offset: 0x0003798C
		private static void smethod_8()
		{
			try
			{
				while (!Class67.cancellationToken_0.IsCancellationRequested)
				{
					if (!Class67.bool_2)
					{
						int num;
						using (Bitmap bitmap = Class40.smethod_1(Class67.class76_0, Class67.rectangle_4))
						{
							Point[] array;
							num = Class40.smethod_30(0, new List<Color> { Color.FromArgb(255, 255, 255) }, new List<int> { 1 }, 1, out array, 7, 2, 2, 2, 2, 15, 1, 9999, bitmap);
						}
						int num2;
						using (Bitmap bitmap2 = Class40.smethod_1(Class67.class76_0, Class67.rectangle_5))
						{
							Point[] array;
							num2 = Class40.smethod_30(0, new List<Color> { Color.FromArgb(255, 255, 255) }, new List<int> { 1 }, 1, out array, 7, 2, 2, 2, 2, 15, 1, 9999, bitmap2);
						}
						if (!Class67.cancellationToken_0.IsCancellationRequested && num > num2)
						{
							Class67.smethod_7(Keys.A, true);
							if (Class67.cancellationToken_0.IsCancellationRequested)
							{
								break;
							}
							Class67.smethod_6(Keys.D);
							Stopwatch stopwatch = Stopwatch.StartNew();
							while (!Class67.cancellationToken_0.IsCancellationRequested && stopwatch.Elapsed.Seconds <= 5)
							{
								using (Bitmap bitmap3 = Class40.smethod_1(Class67.class76_0, Class67.rectangle_2))
								{
									Point[] array;
									if (Class40.smethod_31(200, new List<Color> { Color.FromArgb(255, 255, 255) }, new List<int> { 1 }, 1, out array, 7, 2, 2, 2, 2, 15, 1, 9999, bitmap3))
									{
										stopwatch.Stop();
										Class67.smethod_7(Keys.D, true);
										break;
									}
								}
							}
							if (!Class67.cancellationToken_0.IsCancellationRequested && stopwatch.Elapsed.TotalSeconds > 5.0)
							{
								stopwatch.Restart();
								while (!Class67.cancellationToken_0.IsCancellationRequested && stopwatch.Elapsed.Seconds <= 5)
								{
									using (Bitmap bitmap4 = Class40.smethod_1(Class67.class76_0, Class67.rectangle_3))
									{
										Point[] array;
										if (Class40.smethod_31(200, new List<Color> { Color.FromArgb(255, 255, 255) }, new List<int> { 1 }, 1, out array, 7, 2, 2, 2, 2, 15, 1, 9999, bitmap4))
										{
											stopwatch.Reset();
											Class67.smethod_7(Keys.D, true);
											Class67.bool_0 = true;
											Class67.bool_1 = true;
											break;
										}
									}
								}
								Class67.smethod_7(Keys.D, true);
							}
						}
						else if (!Class67.cancellationToken_0.IsCancellationRequested && num < num2)
						{
							Class67.smethod_7(Keys.D, true);
							if (Class67.cancellationToken_0.IsCancellationRequested)
							{
								break;
							}
							Class67.smethod_6(Keys.A);
							Stopwatch stopwatch2 = Stopwatch.StartNew();
							while (!Class67.cancellationToken_0.IsCancellationRequested && stopwatch2.Elapsed.Seconds <= 5)
							{
								using (Bitmap bitmap5 = Class40.smethod_1(Class67.class76_0, Class67.rectangle_2))
								{
									Point[] array;
									if (Class40.smethod_31(200, new List<Color> { Color.FromArgb(255, 255, 255) }, new List<int> { 1 }, 1, out array, 7, 2, 2, 2, 2, 15, 1, 9999, bitmap5))
									{
										stopwatch2.Stop();
										Class67.smethod_7(Keys.A, true);
										break;
									}
								}
							}
							if (!Class67.cancellationToken_0.IsCancellationRequested && stopwatch2.Elapsed.TotalSeconds > 5.0)
							{
								stopwatch2.Restart();
								while (!Class67.cancellationToken_0.IsCancellationRequested && stopwatch2.Elapsed.Seconds <= 5)
								{
									using (Bitmap bitmap6 = Class40.smethod_1(Class67.class76_0, Class67.rectangle_3))
									{
										Point[] array;
										if (Class40.smethod_31(200, new List<Color> { Color.FromArgb(255, 255, 255) }, new List<int> { 1 }, 1, out array, 7, 2, 2, 2, 2, 15, 1, 9999, bitmap6))
										{
											stopwatch2.Reset();
											Class67.smethod_7(Keys.A, true);
											Class67.bool_0 = true;
											Class67.bool_1 = true;
											break;
										}
									}
								}
								Class67.smethod_7(Keys.A, true);
							}
						}
						else
						{
							if (Class67.cancellationToken_0.IsCancellationRequested)
							{
								break;
							}
							Class67.smethod_6(Keys.D);
							Stopwatch stopwatch3 = Stopwatch.StartNew();
							while (!Class67.cancellationToken_0.IsCancellationRequested && stopwatch3.Elapsed.Seconds <= 3)
							{
								using (Bitmap bitmap7 = Class40.smethod_1(Class67.class76_0, Class67.rectangle_2))
								{
									Point[] array;
									if (Class40.smethod_31(200, new List<Color> { Color.FromArgb(255, 255, 255) }, new List<int> { 1 }, 1, out array, 7, 2, 2, 2, 2, 15, 1, 9999, bitmap7))
									{
										stopwatch3.Stop();
										Class67.smethod_7(Keys.D, true);
										break;
									}
								}
							}
							if (stopwatch3.Elapsed.Seconds > 3)
							{
								Class67.bool_2 = true;
								Class46.smethod_8(Keys.Space, null, false);
								Class67.smethod_10(5000.0, 0.0);
								Class67.bool_2 = false;
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
				else
				{
					Form1.smethod_0();
				}
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00005296 File Offset: 0x00003496
		private static void smethod_9()
		{
			Class46.smethod_9(Keys.Space, null, false, false);
			Class46.smethod_9(Keys.A, null, false, false);
			Class46.smethod_9(Keys.D, null, false, false);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00039E10 File Offset: 0x00038010
		private static void smethod_10(double double_0, double double_1 = 0.0)
		{
			if (Class67.cancellationToken_1.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class67.random_0.NextDouble() * (num2 - num);
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
				if (Class67.cancellationToken_1.IsCancellationRequested)
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
					if (Class67.cancellationToken_1.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x0400052D RID: 1325
		private static CancellationTokenSource cancellationTokenSource_0;

		// Token: 0x0400052E RID: 1326
		private static CancellationToken cancellationToken_0;

		// Token: 0x0400052F RID: 1327
		private static CancellationToken cancellationToken_1;

		// Token: 0x04000530 RID: 1328
		private static Class76 class76_0;

		// Token: 0x04000531 RID: 1329
		private static Bitmap bitmap_0;

		// Token: 0x04000532 RID: 1330
		private static Bitmap bitmap_1;

		// Token: 0x04000533 RID: 1331
		private static Bitmap bitmap_2;

		// Token: 0x04000534 RID: 1332
		private static Mat mat_0;

		// Token: 0x04000535 RID: 1333
		private static Mat mat_1;

		// Token: 0x04000536 RID: 1334
		private static Rectangle rectangle_0;

		// Token: 0x04000537 RID: 1335
		private static Rectangle rectangle_1;

		// Token: 0x04000538 RID: 1336
		private static Rect rect_0;

		// Token: 0x04000539 RID: 1337
		private static Size size_0;

		// Token: 0x0400053A RID: 1338
		private static List<BaseSymbolStruct> list_0;

		// Token: 0x0400053B RID: 1339
		private static readonly Random random_0 = Class67.smethod_0();

		// Token: 0x0400053C RID: 1340
		private static Point point_0;

		// Token: 0x0400053D RID: 1341
		private static Rectangle rectangle_2;

		// Token: 0x0400053E RID: 1342
		private static Rectangle rectangle_3;

		// Token: 0x0400053F RID: 1343
		private static Rectangle rectangle_4;

		// Token: 0x04000540 RID: 1344
		private static Rectangle rectangle_5;

		// Token: 0x04000541 RID: 1345
		private static Rectangle rectangle_6;

		// Token: 0x04000542 RID: 1346
		private static bool bool_0 = false;

		// Token: 0x04000543 RID: 1347
		private static bool bool_1 = false;

		// Token: 0x04000544 RID: 1348
		private static bool bool_2 = false;

		// Token: 0x0200009F RID: 159
		[CompilerGenerated]
		[Serializable]
		private sealed class Class68
		{
			// Token: 0x06000489 RID: 1161 RVA: 0x00039EF4 File Offset: 0x000380F4
			internal void method_0()
			{
				CancellationTokenSource cancellationTokenSource_ = Class67.cancellationTokenSource_0;
				if (cancellationTokenSource_ != null)
				{
					cancellationTokenSource_.Cancel();
				}
				Class46.smethod_9(Keys.A, null, false, true);
				Class46.smethod_9(Keys.D, null, false, true);
				Class46.smethod_9(Keys.Space, null, false, true);
				Bitmap bitmap_ = Class67.bitmap_0;
				if (bitmap_ != null)
				{
					bitmap_.Dispose();
				}
				Bitmap bitmap_2 = Class67.bitmap_1;
				if (bitmap_2 != null)
				{
					bitmap_2.Dispose();
				}
				Bitmap bitmap_3 = Class67.bitmap_2;
				if (bitmap_3 != null)
				{
					bitmap_3.Dispose();
				}
				Mat mat_ = Class67.mat_0;
				if (mat_ != null)
				{
					mat_.Dispose();
				}
				Mat mat_2 = Class67.mat_1;
				if (mat_2 == null)
				{
					return;
				}
				mat_2.Dispose();
			}

			// Token: 0x0600048A RID: 1162 RVA: 0x000052E3 File Offset: 0x000034E3
			internal void method_1()
			{
				Class67.smethod_5();
			}

			// Token: 0x0600048B RID: 1163 RVA: 0x000052EA File Offset: 0x000034EA
			internal void method_2()
			{
				Class67.smethod_8();
			}

			// Token: 0x04000545 RID: 1349
			public static readonly Class67.Class68 class68_0 = new Class67.Class68();

			// Token: 0x04000546 RID: 1350
			public static Action action_0;

			// Token: 0x04000547 RID: 1351
			public static ThreadStart threadStart_0;

			// Token: 0x04000548 RID: 1352
			public static ThreadStart threadStart_1;
		}
	}
}
