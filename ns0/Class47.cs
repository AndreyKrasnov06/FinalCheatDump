using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;

namespace ns0
{
	// Token: 0x02000081 RID: 129
	internal class Class47 : IDisposable
	{
		// Token: 0x060003E2 RID: 994 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00034BF8 File Offset: 0x00032DF8
		public Class47(Class76 class76_1, CancellationToken cancellationToken_1)
		{
			Class47.cancellationToken_0 = cancellationToken_1;
			this.class76_0 = class76_1;
			string text = ((class76_1.Width == 1360) ? "1366x768" : class76_1.Resolution);
			this.rect_0 = Class50.smethod_4(this.class76_0, "regionOpenPad");
			this.mat_0 = Class50.smethod_2(text, "pad");
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00034C5C File Offset: 0x00032E5C
		public void method_0()
		{
			try
			{
				Point point;
				while (!Class47.cancellationToken_0.IsCancellationRequested && !Class40.smethod_13(this.mat_0, this.rect_0, 0.95, false, out point, this.class76_0))
				{
					Class46.smethod_6(Keys.Down, null, false);
					Class47.smethod_1(1500.0, 3000.0);
					Class56.smethod_8(this.class76_0, 50, 50, this.rect_0);
					Class47.smethod_1(1500.0, 3000.0);
					if (Class40.smethod_14(this.mat_0, this.rect_0, 0.95, false, out point, this.class76_0, Class47.cancellationToken_0, 3000, 100, false))
					{
						break;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00034D40 File Offset: 0x00032F40
		public void method_1()
		{
			try
			{
				Point point;
				while (!Class47.cancellationToken_0.IsCancellationRequested && Class40.smethod_13(this.mat_0, this.rect_0, 0.95, false, out point, this.class76_0))
				{
					Class46.smethod_6(Keys.Down, null, false);
					Class47.smethod_1(1500.0, 3000.0);
					if (Class40.smethod_14(this.mat_0, this.rect_0, 0.95, false, out point, this.class76_0, Class47.cancellationToken_0, 3000, 100, true))
					{
						break;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00034DF0 File Offset: 0x00032FF0
		private static void smethod_1(double double_0, double double_1 = 0.0)
		{
			if (Class47.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class47.random_0.NextDouble() * (num2 - num);
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
				if (Class47.cancellationToken_0.IsCancellationRequested)
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
					if (Class47.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00004F48 File Offset: 0x00003148
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

		// Token: 0x040004AD RID: 1197
		private bool bool_0;

		// Token: 0x040004AE RID: 1198
		private static CancellationToken cancellationToken_0;

		// Token: 0x040004AF RID: 1199
		private readonly Class76 class76_0;

		// Token: 0x040004B0 RID: 1200
		private Rect rect_0;

		// Token: 0x040004B1 RID: 1201
		private readonly Mat mat_0;

		// Token: 0x040004B2 RID: 1202
		private static readonly Random random_0 = Class47.smethod_0();
	}
}
