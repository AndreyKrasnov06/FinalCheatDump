using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;

namespace ns0
{
	// Token: 0x02000082 RID: 130
	internal class Class48 : IDisposable
	{
		// Token: 0x060003E9 RID: 1001 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00034ED4 File Offset: 0x000330D4
		public Class48(Class76 class76_1, CancellationToken cancellationToken_1)
		{
			Class48.cancellationToken_0 = cancellationToken_1;
			this.class76_0 = class76_1;
			string text = ((class76_1.Width == 1360) ? "1366x768" : class76_1.Resolution);
			this.rect_0 = Class50.smethod_4(this.class76_0, "regionOpenPhone");
			this.mat_0 = Class50.smethod_2(text, "open");
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00034F38 File Offset: 0x00033138
		public void method_0()
		{
			try
			{
				Point point;
				while (!Class48.cancellationToken_0.IsCancellationRequested && !Class40.smethod_13(this.mat_0, this.rect_0, 0.95, false, out point, this.class76_0))
				{
					Class46.smethod_6(Keys.Up, null, false);
					Class48.smethod_1(1500.0, 3000.0);
					Class56.smethod_8(this.class76_0, 50, 50, this.rect_0);
					Class48.smethod_1(1500.0, 3000.0);
					if (Class40.smethod_14(this.mat_0, this.rect_0, 0.95, false, out point, this.class76_0, Class48.cancellationToken_0, 3000, 100, false))
					{
						break;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0003501C File Offset: 0x0003321C
		public void method_1()
		{
			try
			{
				Point point;
				while (!Class48.cancellationToken_0.IsCancellationRequested && Class40.smethod_13(this.mat_0, this.rect_0, 0.95, false, out point, this.class76_0))
				{
					Class46.smethod_6(Keys.Up, null, false);
					Class48.smethod_1(1500.0, 3000.0);
					if (Class40.smethod_14(this.mat_0, this.rect_0, 0.95, false, out point, this.class76_0, Class48.cancellationToken_0, 3000, 100, true))
					{
						break;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000350CC File Offset: 0x000332CC
		private static void smethod_1(double double_0, double double_1 = 0.0)
		{
			if (Class48.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class48.random_0.NextDouble() * (num2 - num);
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
				if (Class48.cancellationToken_0.IsCancellationRequested)
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
					if (Class48.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00004F76 File Offset: 0x00003176
		public void Dispose()
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
			Mat mat = this.mat_0;
			if (mat == null)
			{
				return;
			}
			mat.Dispose();
		}

		// Token: 0x040004B3 RID: 1203
		private bool bool_0;

		// Token: 0x040004B4 RID: 1204
		private static CancellationToken cancellationToken_0;

		// Token: 0x040004B5 RID: 1205
		private Class76 class76_0;

		// Token: 0x040004B6 RID: 1206
		private Rect rect_0;

		// Token: 0x040004B7 RID: 1207
		private Mat mat_0;

		// Token: 0x040004B8 RID: 1208
		private static readonly Random random_0 = Class48.smethod_0();
	}
}
