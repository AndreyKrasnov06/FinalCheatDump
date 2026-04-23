using System;
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
	// Token: 0x02000092 RID: 146
	internal static class Class57
	{
		// Token: 0x06000447 RID: 1095 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x000380C8 File Offset: 0x000362C8
		public static void smethod_1(Class76 class76_1)
		{
			Class57.class76_0 = class76_1;
			Class57.cancellationToken_0 = Form1.cancellationToken_0;
			Class57.cancellationToken_0.Register(new Action(Class57.Class58.class58_0.method_0));
			string text = ((Class57.class76_0.Width == 1360) ? "1366x768" : Class57.class76_0.Resolution);
			Class57.rectangle_0 = Class50.smethod_3(Class57.class76_0, "regionE");
			Class57.bitmap_0 = Class50.smethod_1(text, "e");
			if (FormMushroomer.IsAutoRunning)
			{
				Task.Run(new Action(Class57.Class58.class58_0.method_1));
			}
			try
			{
				while (!Class57.cancellationToken_0.IsCancellationRequested)
				{
					Point[] array;
					if (!Class57.cancellationToken_0.IsCancellationRequested && Class40.smethod_18(6, 1, Class57.bitmap_0, -2, out array, Class57.rectangle_0, 25, 90, Class57.class76_0))
					{
						Class46.smethod_6(Keys.E, Class57.class76_0, false);
						Class57.smethod_3(10.0 + Class57.random_0.NextDouble() * 20.0, 0.0);
						if (FormLumberjack.IsAutoRunning)
						{
							Class57.bool_0 = false;
						}
						Class57.smethod_3(200.0, 400.0);
						if (FormLumberjack.IsAutoRunning)
						{
							Class57.bool_0 = true;
						}
					}
					Class57.smethod_3(50.0, 0.0);
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

		// Token: 0x06000449 RID: 1097 RVA: 0x0003827C File Offset: 0x0003647C
		private static void smethod_2()
		{
			while (!Class57.cancellationToken_0.IsCancellationRequested)
			{
				if (!Class46.smethod_10(Keys.LShiftKey) || !Class46.smethod_10(Keys.W) || !Class57.class76_0.IsActive)
				{
					if (!Class57.bool_0 || !Class57.class76_0.IsActive)
					{
						Class57.smethod_3(80.0, 120.0);
						continue;
					}
				}
				while (!Class57.cancellationToken_0.IsCancellationRequested)
				{
					if ((!Class46.smethod_10(Keys.LShiftKey) && !Class46.smethod_10(Keys.W) && Class57.class76_0.IsActive) || (Class57.bool_0 && Class57.class76_0.IsActive))
					{
						Class46.smethod_8(Keys.W, null, false);
						Class46.smethod_8(Keys.LShiftKey, null, false);
						Class57.bool_0 = true;
						while (!Class57.cancellationToken_0.IsCancellationRequested)
						{
							if (Class46.smethod_10(Keys.S) || !Class46.smethod_10(Keys.LShiftKey) || !Class46.smethod_10(Keys.W) || !Class57.class76_0.IsActive || !Class57.bool_0)
							{
								Class46.smethod_9(Keys.W, null, false, true);
								Class46.smethod_9(Keys.LShiftKey, null, false, true);
								Class57.bool_0 = false;
								break;
							}
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x000383B8 File Offset: 0x000365B8
		private static void smethod_3(double double_0, double double_1 = 0.0)
		{
			if (Class57.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class57.random_0.NextDouble() * (num2 - num);
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
				if (Class57.cancellationToken_0.IsCancellationRequested)
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
					if (Class57.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x04000505 RID: 1285
		private static CancellationToken cancellationToken_0;

		// Token: 0x04000506 RID: 1286
		private static Class76 class76_0;

		// Token: 0x04000507 RID: 1287
		private static Bitmap bitmap_0;

		// Token: 0x04000508 RID: 1288
		private static Rectangle rectangle_0;

		// Token: 0x04000509 RID: 1289
		private static readonly Random random_0 = Class57.smethod_0();

		// Token: 0x0400050A RID: 1290
		private static bool bool_0 = false;

		// Token: 0x02000093 RID: 147
		[CompilerGenerated]
		[Serializable]
		private sealed class Class58
		{
			// Token: 0x0600044E RID: 1102 RVA: 0x000050F9 File Offset: 0x000032F9
			internal void method_0()
			{
				Bitmap bitmap_ = Class57.bitmap_0;
				if (bitmap_ == null)
				{
					return;
				}
				bitmap_.Dispose();
			}

			// Token: 0x0600044F RID: 1103 RVA: 0x0000510A File Offset: 0x0000330A
			internal void method_1()
			{
				Class57.smethod_2();
			}

			// Token: 0x0400050B RID: 1291
			public static readonly Class57.Class58 class58_0 = new Class57.Class58();

			// Token: 0x0400050C RID: 1292
			public static Action action_0;

			// Token: 0x0400050D RID: 1293
			public static Action action_1;
		}
	}
}
