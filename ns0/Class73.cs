using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x020000A4 RID: 164
	internal static class Class73
	{
		// Token: 0x06000498 RID: 1176 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0003A424 File Offset: 0x00038624
		public static void smethod_1(Class76 class76_1)
		{
			Class73.class76_0 = class76_1;
			Class73.cancellationToken_0 = Form1.cancellationToken_0;
			Class73.cancellationToken_0.Register(new Action(Class73.Class74.class74_0.method_0));
			string text = ((Class73.class76_0.Width == 1360) ? "1366x768" : Class73.class76_0.Resolution);
			Class73.rectangle_0 = Class50.smethod_3(Class73.class76_0, "regionDoorGame");
			Class73.rectangle_1 = Class50.smethod_3(Class73.class76_0, "regionDoorPin");
			Class73.bitmap_1 = Class50.smethod_1(text, "game");
			for (int i = 0; i < 2; i++)
			{
				Class73.bitmap_0[i] = Class50.smethod_1("Door", "door" + i.ToString());
			}
			try
			{
				while (!Class73.cancellationToken_0.IsCancellationRequested)
				{
					Point[] array;
					while (!Class73.cancellationToken_0.IsCancellationRequested && Class40.smethod_18(6, 1, Class73.bitmap_1, -1, out array, Class73.rectangle_0, 15, 98, Class73.class76_0))
					{
						Point[] array2;
						if (!Class73.cancellationToken_0.IsCancellationRequested && Class40.smethod_24(6, 1, -1, -1, Class73.bitmap_0, -1, out array2, Class73.rectangle_1, 25, 100, Class73.class76_0))
						{
							Class73.smethod_2(100.0, 0.0);
							Rectangle rectangle = new Rectangle(Class73.rectangle_1.Left + array2[0].X + 2, Class73.rectangle_1.Top + array2[0].Y, 1, 1);
							using (Bitmap bitmap = Class40.smethod_5(Class73.class76_0, rectangle))
							{
								while (!Class73.cancellationToken_0.IsCancellationRequested)
								{
									Class56.smethod_29();
									if (!Class40.smethod_18(3, 1, bitmap, -1, out array, rectangle, 15, 100, Class73.class76_0))
									{
										Class46.smethod_6(Keys.Return, null, false);
										Class73.smethod_2(400.0, 500.0);
										break;
									}
								}
							}
						}
						Class73.smethod_2(50.0, 0.0);
					}
					Class73.smethod_2(200.0, 0.0);
				}
			}
			catch (Form1.GException0 gexception)
			{
				Form1.Main.method_11();
				if (gexception.HasMessage)
				{
					new FormMessage(gexception);
				}
				Form1.smethod_0();
			}
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0003A6A8 File Offset: 0x000388A8
		private static void smethod_2(double double_0, double double_1 = 0.0)
		{
			if (Class73.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class73.random_0.NextDouble() * (num2 - num);
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
				if (Class73.cancellationToken_0.IsCancellationRequested)
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
					if (Class73.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x0400054E RID: 1358
		private static CancellationToken cancellationToken_0;

		// Token: 0x0400054F RID: 1359
		private static Class76 class76_0;

		// Token: 0x04000550 RID: 1360
		private static Bitmap[] bitmap_0 = new Bitmap[2];

		// Token: 0x04000551 RID: 1361
		private static Bitmap bitmap_1 = null;

		// Token: 0x04000552 RID: 1362
		private static Rectangle rectangle_0;

		// Token: 0x04000553 RID: 1363
		private static Rectangle rectangle_1;

		// Token: 0x04000554 RID: 1364
		private static readonly Random random_0 = Class73.smethod_0();

		// Token: 0x020000A5 RID: 165
		[CompilerGenerated]
		[Serializable]
		private sealed class Class74
		{
			// Token: 0x0600049E RID: 1182 RVA: 0x0003A78C File Offset: 0x0003898C
			internal void method_0()
			{
				Bitmap bitmap_ = Class73.bitmap_1;
				if (bitmap_ != null)
				{
					bitmap_.Dispose();
				}
				foreach (Bitmap bitmap in Class73.bitmap_0)
				{
					if (bitmap != null)
					{
						bitmap.Dispose();
					}
				}
			}

			// Token: 0x04000555 RID: 1365
			public static readonly Class73.Class74 class74_0 = new Class73.Class74();

			// Token: 0x04000556 RID: 1366
			public static Action action_0;
		}
	}
}
