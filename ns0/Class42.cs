using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using ns1;
using OpenCvSharp;

namespace ns0
{
	// Token: 0x02000071 RID: 113
	internal class Class42 : IDisposable
	{
		// Token: 0x060003A9 RID: 937 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00032758 File Offset: 0x00030958
		public Class42(Class76 class76_1, CancellationToken cancellationToken_1)
		{
			Class42.cancellationToken_0 = cancellationToken_1;
			this.class76_0 = class76_1;
			string resolution = this.class76_0.Resolution;
			this.rect_0 = Class50.smethod_4(this.class76_0, "regionOpenInventory");
			this.size_0 = Class50.smethod_6(this.class76_0, "menuOffset");
			this.size_1 = Class50.smethod_6(this.class76_0, "useArea");
			for (int i = 0; i < this.mat_0.Length; i++)
			{
				this.mat_0[i] = Class50.smethod_2(resolution, "open_" + i.ToString());
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00032804 File Offset: 0x00030A04
		public void method_0()
		{
			try
			{
				Point point;
				while (!Class40.smethod_10(this.mat_0, this.rect_0, 0.8, false, out point, this.class76_0) && !Class42.cancellationToken_0.IsCancellationRequested)
				{
					if (FormFishing.KeyInventory == Keys.None)
					{
						Class46.smethod_6(Keys.I, null, false);
						if (Class40.smethod_15(this.mat_0, this.rect_0, 0.8, false, out point, this.class76_0, Class42.cancellationToken_0, 3000, 100, false))
						{
							FormFishing.KeyInventory = Keys.I;
							break;
						}
						Class46.smethod_6(Keys.Tab, null, false);
						if (Class40.smethod_15(this.mat_0, this.rect_0, 0.8, false, out point, this.class76_0, Class42.cancellationToken_0, 3000, 100, false))
						{
							FormFishing.KeyInventory = Keys.Tab;
							break;
						}
					}
					else
					{
						Class46.smethod_6(FormFishing.KeyInventory, null, false);
						if (Class40.smethod_15(this.mat_0, this.rect_0, 0.8, false, out point, this.class76_0, Class42.cancellationToken_0, 5000, 100, false))
						{
							break;
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00032948 File Offset: 0x00030B48
		public void method_1()
		{
			try
			{
				Point point;
				while (Class40.smethod_10(this.mat_0, this.rect_0, 0.8, false, out point, this.class76_0) && !Class42.cancellationToken_0.IsCancellationRequested)
				{
					Class46.smethod_6(FormFishing.KeyInventory, null, false);
					if (Class40.smethod_15(this.mat_0, this.rect_0, 0.8, false, out point, this.class76_0, Class42.cancellationToken_0, 5000, 100, true))
					{
						break;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x000329E0 File Offset: 0x00030BE0
		public void method_2(Point point_0)
		{
			Class56.smethod_33(point_0, this.class76_0);
			Class42.smethod_1(500.0, 0.0);
			point_0.X += this.size_0.Width;
			point_0.Y += this.size_0.Height;
			Class56.smethod_27(point_0, this.size_1, this.class76_0, true);
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00032A58 File Offset: 0x00030C58
		private static void smethod_1(double double_0, double double_1 = 0.0)
		{
			if (Class42.cancellationToken_0.IsCancellationRequested)
			{
				throw new Form1.GException0();
			}
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class42.random_0.NextDouble() * (num2 - num);
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
				if (Class42.cancellationToken_0.IsCancellationRequested)
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
					if (Class42.cancellationToken_0.IsCancellationRequested)
					{
						throw new Form1.GException0();
					}
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00032B3C File Offset: 0x00030D3C
		public void Dispose()
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
			foreach (Mat mat in this.mat_0)
			{
				if (mat != null)
				{
					mat.Dispose();
				}
			}
		}

		// Token: 0x04000458 RID: 1112
		private bool bool_0;

		// Token: 0x04000459 RID: 1113
		private static CancellationToken cancellationToken_0;

		// Token: 0x0400045A RID: 1114
		private Class76 class76_0;

		// Token: 0x0400045B RID: 1115
		private Rect rect_0;

		// Token: 0x0400045C RID: 1116
		private Size size_0;

		// Token: 0x0400045D RID: 1117
		private Size size_1;

		// Token: 0x0400045E RID: 1118
		private Mat[] mat_0 = new Mat[3];

		// Token: 0x0400045F RID: 1119
		private static readonly Random random_0 = Class42.smethod_0();
	}
}
