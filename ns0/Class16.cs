using System;
using System.Drawing;
using OpenCvSharp;

namespace ns0
{
	// Token: 0x02000039 RID: 57
	internal class Class16
	{
		// Token: 0x060001D2 RID: 466 RVA: 0x00017460 File Offset: 0x00015660
		public static Rectangle smethod_0(Class76 class76_0, float[] float_0)
		{
			int num = (int)(float_0[0] * (float)class76_0.Width);
			int num2 = (int)(float_0[1] * (float)class76_0.Height);
			int num3 = (int)(float_0[2] * (float)class76_0.Width) - num;
			int num4 = (int)(float_0[3] * (float)class76_0.Height) - num2;
			return new Rectangle(num, num2, num3, num4);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x000174B0 File Offset: 0x000156B0
		public static Rectangle smethod_1(Class76 class76_0, double[] double_0)
		{
			int num = (int)(double_0[0] * (double)class76_0.Width);
			int num2 = (int)(double_0[1] * (double)class76_0.Height);
			int num3 = (int)(double_0[2] * (double)class76_0.Width) - num;
			int num4 = (int)(double_0[3] * (double)class76_0.Height) - num2;
			return new Rectangle(num, num2, num3, num4);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00017500 File Offset: 0x00015700
		public static Point smethod_2(Class76 class76_0, float float_0, float float_1)
		{
			int num = (int)(float_0 * (float)class76_0.Width);
			int num2 = (int)(float_1 * (float)class76_0.Height);
			return new Point(num, num2);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00017528 File Offset: 0x00015728
		public static Size smethod_3(Class76 class76_0, float float_0, float float_1)
		{
			int num = (int)(float_0 * (float)class76_0.Width);
			int num2 = (int)(float_1 * (float)class76_0.Height);
			return new Size(num, num2);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00003D39 File Offset: 0x00001F39
		public static Rectangle smethod_4(Rect rect_0)
		{
			return new Rectangle(rect_0.X, rect_0.Y, rect_0.Width, rect_0.Height);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00003D58 File Offset: 0x00001F58
		public static Rect smethod_5(Rectangle rectangle_0)
		{
			return new Rect(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		}
	}
}
