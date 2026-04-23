using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;

namespace ns0
{
	// Token: 0x020000A1 RID: 161
	internal static class Class70
	{
		// Token: 0x0600048E RID: 1166 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00039FCC File Offset: 0x000381CC
		public static void smethod_1(Class76 class76_1)
		{
			Class70.Class71 @class = new Class70.Class71();
			Class70.class76_0 = class76_1;
			Class70.cancellationToken_0 = Form1.cancellationToken_0;
			@class.mat_0 = null;
			@class.mat_1 = null;
			Class70.cancellationToken_0.Register(new Action(@class.method_0));
			string text = ((Class70.class76_0.Width == 1360) ? "1366x768" : Class70.class76_0.Resolution);
			Rect rect = Class50.smethod_4(Class70.class76_0, "regionMessage");
			Rect rect2 = Class50.smethod_4(Class70.class76_0, "regionOrder");
			Class50.smethod_5(Class70.class76_0, "regionClick");
			@class.mat_0 = Class50.smethod_2(text, "message_green");
			@class.mat_1 = Class50.smethod_2(text, "order");
			try
			{
				while (!Class70.cancellationToken_0.IsCancellationRequested)
				{
					Point point;
					if (Class40.smethod_13(@class.mat_1, rect2, 0.95, false, out point, class76_1))
					{
						Class46.smethod_6(Keys.Y, class76_1, false);
						if (Class40.smethod_14(@class.mat_0, rect, 0.8, false, out point, Class70.class76_0, Class70.cancellationToken_0, 2000, 100, false))
						{
							Form1.Main.method_11();
							Form1.smethod_1();
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

		// Token: 0x06000490 RID: 1168 RVA: 0x0003A130 File Offset: 0x00038330
		private static void smethod_2(double double_0, double double_1 = 0.0)
		{
			if (Class70.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class70.random_0.NextDouble() * (num2 - num);
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
				if (Class70.cancellationToken_0.IsCancellationRequested)
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
					if (Class70.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x04000549 RID: 1353
		private static CancellationToken cancellationToken_0;

		// Token: 0x0400054A RID: 1354
		private static Class76 class76_0;

		// Token: 0x0400054B RID: 1355
		private static readonly Random random_0 = Class70.smethod_0();

		// Token: 0x020000A2 RID: 162
		[CompilerGenerated]
		private sealed class Class71
		{
			// Token: 0x06000493 RID: 1171 RVA: 0x00005305 File Offset: 0x00003505
			internal void method_0()
			{
				Mat mat = this.mat_0;
				if (mat != null)
				{
					mat.Dispose();
				}
				Mat mat2 = this.mat_1;
				if (mat2 == null)
				{
					return;
				}
				mat2.Dispose();
			}

			// Token: 0x0400054C RID: 1356
			public Mat mat_0;

			// Token: 0x0400054D RID: 1357
			public Mat mat_1;
		}
	}
}
