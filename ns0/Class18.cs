using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ns0
{
	// Token: 0x0200003B RID: 59
	internal class Class18
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00017550 File Offset: 0x00015750
		public static void smethod_1(Class76 class76_1)
		{
			try
			{
				Class18.class76_0 = class76_1;
				Class18.cancellationToken_0 = Form1.cancellationToken_0;
				Class18.cancellationToken_0.Register(new Action(Class18.Class19.class19_0.method_0));
				string text = ((Class18.class76_0.Width == 1360) ? "1366x768" : Class18.class76_0.Resolution);
				Class18.rect_0 = Class50.smethod_4(Class18.class76_0, "regionToiletGame");
				Class18.rectangle_0 = Class50.smethod_3(Class18.class76_0, "regionToiletItem");
				Class18.rectangle_1 = Class50.smethod_3(Class18.class76_0, "regionToiletMoveMouse");
				Class18.rectangle_2[0] = Class50.smethod_3(Class18.class76_0, "regionFloorGame0");
				Class18.rectangle_2[1] = Class50.smethod_3(Class18.class76_0, "regionFloorGame1");
				Class18.rect_1 = Class50.smethod_4(Class18.class76_0, "regionFloorItem");
				Class18.rectangle_3 = Class50.smethod_3(Class18.class76_0, "regionFloorMoveMouse");
				Class18.mat_0 = Class50.smethod_2(text, "toilet");
				Class18.mat_1 = Class50.smethod_2(text, "brush");
				Class18.bitmap_0 = Class50.smethod_1(text, "fork");
				Class18.bitmap_1[0] = Class50.smethod_1("Floor", "white");
				Class18.bitmap_1[1] = Class50.smethod_1(text, "floor");
				Class18.mat_2 = Class50.smethod_2(text, "sponge");
				if (!Class18.cancellationToken_0.IsCancellationRequested)
				{
					while (!Class18.cancellationToken_0.IsCancellationRequested)
					{
						using (Bitmap bitmap = Class40.smethod_2(Class18.class76_0))
						{
							if (Class18.smethod_2(bitmap))
							{
								continue;
							}
							if (Class18.smethod_4(bitmap))
							{
								continue;
							}
						}
						Class18.smethod_6(100.0, 0.0);
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

		// Token: 0x060001E3 RID: 483 RVA: 0x00017770 File Offset: 0x00015970
		private static bool smethod_2(Bitmap bitmap_2)
		{
			Point point;
			if (bitmap_2 != null && Class40.smethod_16(Class18.mat_0, Class18.rect_0, 0.9, false, out point, BitmapConverter.ToMat(bitmap_2)))
			{
				ValueTuple<bool, Point> valueTuple = Class18.smethod_3();
				bool item = valueTuple.Item1;
				Point item2 = valueTuple.Item2;
				if (!Class18.cancellationToken_0.IsCancellationRequested && item)
				{
					int num = Class18.rectangle_0.X + item2.X;
					int num2 = Class18.rectangle_0.Y + item2.Y;
					string resolution = Class18.class76_0.Resolution;
					if (resolution != null)
					{
						int length = resolution.Length;
						int num3;
						int num4;
						if (length != 8)
						{
							if (length != 9)
							{
								return false;
							}
							switch (resolution[7])
							{
							case '0':
								if (!(resolution == "1920x1200"))
								{
									return false;
								}
								num3 = 34000;
								num4 = 1;
								break;
							case '1':
							case '3':
							case '6':
							case '7':
								return false;
							case '2':
								if (!(resolution == "1280x1024"))
								{
									return false;
								}
								num3 = 35000;
								num4 = 1;
								break;
							case '4':
								if (!(resolution == "2560x1440"))
								{
									return false;
								}
								num3 = 34000;
								num4 = 1;
								break;
							case '5':
								if (!(resolution == "1680x1050"))
								{
									return false;
								}
								num3 = 34000;
								num4 = 1;
								break;
							case '8':
								if (!(resolution == "1920x1080"))
								{
									return false;
								}
								num3 = 34000;
								num4 = 1;
								break;
							default:
								return false;
							}
						}
						else
						{
							switch (resolution[1])
							{
							case '2':
								if (!(resolution == "1280x800"))
								{
									if (!(resolution == "1280x720"))
									{
										return false;
									}
									num3 = 35000;
									num4 = 1;
								}
								else
								{
									num3 = 35000;
									num4 = 1;
								}
								break;
							case '3':
								if (!(resolution == "1366x768"))
								{
									return false;
								}
								num3 = 35000;
								num4 = 1;
								break;
							case '4':
								if (!(resolution == "1440x900"))
								{
									return false;
								}
								num3 = 35000;
								num4 = 1;
								break;
							case '5':
								return false;
							case '6':
								if (!(resolution == "1600x900"))
								{
									return false;
								}
								num3 = 35000;
								num4 = 1;
								break;
							default:
								return false;
							}
						}
						Class56.int_1 = num4;
						Class56.smethod_23(num, num2, 0, 0);
						Class18.smethod_6(150.0, 250.0);
						if (Class18.cancellationToken_0.IsCancellationRequested)
						{
							throw new Form1.GException0();
						}
						Class56.smethod_31();
						Class18.smethod_6(150.0, 250.0);
						int x = Class18.rectangle_1.X;
						int y = Class18.rectangle_1.Y;
						int num5 = x + Class18.rectangle_1.Width;
						int num6 = y + Class18.rectangle_1.Height;
						int num7 = 6;
						int num8 = (num6 - y) / 6;
						int num9 = num3 / num8;
						for (int i = 0; i <= num8; i++)
						{
							if (Class18.cancellationToken_0.IsCancellationRequested)
							{
								throw new Form1.GException0();
							}
							if (!Class40.smethod_13(Class18.mat_0, Class18.rect_0, 0.8, false, out point, Class18.class76_0))
							{
								Class56.smethod_32();
								break;
							}
							Class56.smethod_23(x, y + i * num7, 0, 0);
							Class18.smethod_6((double)num9, 0.0);
							if (Class18.cancellationToken_0.IsCancellationRequested)
							{
								throw new Form1.GException0();
							}
							if (!Class40.smethod_13(Class18.mat_0, Class18.rect_0, 0.8, false, out point, Class18.class76_0))
							{
								Class56.smethod_32();
								break;
							}
							i++;
							Class56.smethod_23(num5, y + i * num7, 0, 0);
							Class18.smethod_6((double)num9, 0.0);
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00017B38 File Offset: 0x00015D38
		private static ValueTuple<bool, Point> smethod_3()
		{
			ValueTuple<bool, Point> valueTuple;
			using (Bitmap bitmap = Class40.smethod_5(Class18.class76_0, Class18.rectangle_0))
			{
				Point[] array = new Point[1];
				if (Class40.smethod_17(Class18.mat_1, 0.9, false, out array[0], BitmapConverter.ToMat(bitmap)))
				{
					valueTuple = new ValueTuple<bool, Point>(true, new Point(array[0].X + Class18.mat_1.Width / 2, array[0].Y + Class18.mat_1.Height / 2));
				}
				else if (Class40.smethod_21(6, 1, Class18.bitmap_0, -2, out array, 25, 90, bitmap))
				{
					valueTuple = new ValueTuple<bool, Point>(true, new Point(array[0].X + Class18.bitmap_0.Width / 2, array[0].Y + Class18.bitmap_0.Height / 2));
				}
				else
				{
					valueTuple = new ValueTuple<bool, Point>(false, new Point(-1, -1));
				}
			}
			return valueTuple;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00017C44 File Offset: 0x00015E44
		private static bool smethod_4(Bitmap bitmap_2)
		{
			Point[] array;
			if (!Class40.smethod_20(6, 1, Class18.bitmap_1[0], -1, out array, Class18.rectangle_2[0], 20, 98, bitmap_2) && !Class40.smethod_20(6, 1, Class18.bitmap_1[1], -1, out array, Class18.rectangle_2[1], 30, 90, bitmap_2))
			{
				return false;
			}
			Class18.smethod_6(1000.0, 0.0);
			Point point;
			if (!Class18.cancellationToken_0.IsCancellationRequested && Class40.smethod_13(Class18.mat_2, Class18.rect_1, 0.98, false, out point, Class18.class76_0))
			{
				int num = Class18.rect_1.X + point.X + Class18.mat_2.Width / 2;
				int num2 = Class18.rect_1.Y + point.Y + Class18.mat_2.Height / 2;
				string resolution = Class18.class76_0.Resolution;
				if (resolution != null)
				{
					int length = resolution.Length;
					int num3;
					int num4;
					if (length != 8)
					{
						if (length != 9)
						{
							return false;
						}
						switch (resolution[7])
						{
						case '0':
							if (!(resolution == "1920x1200"))
							{
								return false;
							}
							num3 = 5000;
							num4 = 5;
							break;
						case '1':
						case '3':
						case '6':
						case '7':
							return false;
						case '2':
							if (!(resolution == "1280x1024"))
							{
								return false;
							}
							num3 = 2000;
							num4 = 7;
							break;
						case '4':
							if (!(resolution == "2560x1440"))
							{
								return false;
							}
							num3 = 0;
							num4 = 4;
							break;
						case '5':
							if (!(resolution == "1680x1050"))
							{
								return false;
							}
							num3 = 0;
							num4 = 8;
							break;
						case '8':
							if (!(resolution == "1920x1080"))
							{
								return false;
							}
							num3 = 3000;
							num4 = 6;
							break;
						default:
							return false;
						}
					}
					else
					{
						switch (resolution[1])
						{
						case '2':
							if (!(resolution == "1280x800"))
							{
								if (!(resolution == "1280x720"))
								{
									return false;
								}
								Class18.rectangle_3.X = Class18.rectangle_3.X - 10;
								num3 = 6000;
								num4 = 12;
							}
							else
							{
								Class18.rectangle_3.X = Class18.rectangle_3.X - 10;
								num3 = 4000;
								num4 = 10;
							}
							break;
						case '3':
							if (!(resolution == "1366x768"))
							{
								return false;
							}
							num3 = 0;
							num4 = 12;
							break;
						case '4':
							if (!(resolution == "1440x900"))
							{
								return false;
							}
							num3 = 0;
							num4 = 9;
							break;
						case '5':
							return false;
						case '6':
							if (!(resolution == "1600x900"))
							{
								return false;
							}
							num3 = 7000;
							num4 = 8;
							break;
						default:
							return false;
						}
					}
					Class56.int_1 = num4;
					Class56.smethod_23(num, num2, 0, 0);
					if (Class18.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Class56.smethod_31();
					int x = Class18.rectangle_3.X;
					int y = Class18.rectangle_3.Y;
					int num5 = x + Class18.rectangle_3.Width;
					int num6 = y + Class18.rectangle_3.Height;
					int num7 = 5;
					int num8 = (num6 - y) / 5;
					int num9 = num3 / num8 / 2;
					for (int i = 0; i <= num8; i++)
					{
						if (Class18.cancellationToken_0.IsCancellationRequested)
						{
							throw new Form1.GException0();
						}
						Point point2;
						if (!Class18.smethod_5(out point2))
						{
							Class56.smethod_32();
							return true;
						}
						Class56.smethod_23(x, y + i * num7, 0, 0);
						Class18.smethod_6((double)num9, 0.0);
						if (Class18.cancellationToken_0.IsCancellationRequested)
						{
							throw new Form1.GException0();
						}
						if (!Class18.smethod_5(out point2))
						{
							Class56.smethod_32();
							return true;
						}
						Class56.smethod_23(num5, y + ++i * num7, 0, 0);
						Class18.smethod_6((double)num9, 0.0);
					}
					return false;
				}
				return false;
			}
			return false;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00018014 File Offset: 0x00016214
		private static bool smethod_5(out Point point_0)
		{
			using (Bitmap bitmap = Class40.smethod_2(Class18.class76_0))
			{
				for (int i = 0; i < Class18.bitmap_1.Length; i++)
				{
					Point[] array;
					if (Class40.smethod_20(6, 1, Class18.bitmap_1[i], -1, out array, Class18.rectangle_2[i], 20, 98, bitmap))
					{
						point_0 = array[0];
						return true;
					}
				}
			}
			point_0 = new Point(-1, -1);
			return false;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x000180A0 File Offset: 0x000162A0
		private static void smethod_6(double double_0, double double_1 = 0.0)
		{
			if (Class18.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class18.random_0.NextDouble() * (num2 - num);
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
				if (Class18.cancellationToken_0.IsCancellationRequested)
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
					if (Class18.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x04000211 RID: 529
		private static CancellationToken cancellationToken_0;

		// Token: 0x04000212 RID: 530
		private static Class76 class76_0;

		// Token: 0x04000213 RID: 531
		private static Mat mat_0;

		// Token: 0x04000214 RID: 532
		private static Mat mat_1;

		// Token: 0x04000215 RID: 533
		private static Bitmap bitmap_0;

		// Token: 0x04000216 RID: 534
		private static Bitmap[] bitmap_1 = new Bitmap[2];

		// Token: 0x04000217 RID: 535
		private static Mat mat_2;

		// Token: 0x04000218 RID: 536
		private static Rect rect_0;

		// Token: 0x04000219 RID: 537
		private static Rectangle rectangle_0;

		// Token: 0x0400021A RID: 538
		private static Rectangle rectangle_1;

		// Token: 0x0400021B RID: 539
		private static Rectangle[] rectangle_2 = new Rectangle[2];

		// Token: 0x0400021C RID: 540
		private static Rect rect_1;

		// Token: 0x0400021D RID: 541
		private static Rectangle rectangle_3;

		// Token: 0x0400021E RID: 542
		private static readonly Random random_0 = Class18.smethod_0();

		// Token: 0x0200003C RID: 60
		[CompilerGenerated]
		[Serializable]
		private sealed class Class19
		{
			// Token: 0x060001EC RID: 492 RVA: 0x00018184 File Offset: 0x00016384
			internal void method_0()
			{
				Class56.smethod_32();
				Mat mat_ = Class18.mat_0;
				if (mat_ != null)
				{
					mat_.Dispose();
				}
				Mat mat_2 = Class18.mat_1;
				if (mat_2 != null)
				{
					mat_2.Dispose();
				}
				Bitmap bitmap_ = Class18.bitmap_0;
				if (bitmap_ != null)
				{
					bitmap_.Dispose();
				}
				Mat mat_3 = Class18.mat_2;
				if (mat_3 != null)
				{
					mat_3.Dispose();
				}
				foreach (Bitmap bitmap in Class18.bitmap_1)
				{
					if (bitmap != null)
					{
						bitmap.Dispose();
					}
				}
			}

			// Token: 0x0400021F RID: 543
			public static readonly Class18.Class19 class19_0 = new Class18.Class19();

			// Token: 0x04000220 RID: 544
			public static Action action_0;
		}
	}
}
