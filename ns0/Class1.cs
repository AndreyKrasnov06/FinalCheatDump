using System;
using System.Runtime.InteropServices;

namespace ns0
{
	// Token: 0x0200000B RID: 11
	internal static class Class1
	{
		// Token: 0x0600001E RID: 30
		[DllImport("winmm.dll")]
		private static extern uint timeBeginPeriod(uint uint_0);

		// Token: 0x0600001F RID: 31
		[DllImport("winmm.dll")]
		private static extern uint timeEndPeriod(uint uint_0);

		// Token: 0x06000020 RID: 32 RVA: 0x000058F0 File Offset: 0x00003AF0
		public static void smethod_0()
		{
			if (Class1.bool_0)
			{
				return;
			}
			uint num = Class1.timeBeginPeriod(1U);
			if (num != 0U)
			{
				throw new InvalidOperationException("timeBeginPeriod(1) failed: " + num.ToString());
			}
			Class1.bool_0 = true;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000592C File Offset: 0x00003B2C
		public static void smethod_1()
		{
			if (!Class1.bool_0)
			{
				return;
			}
			uint num = Class1.timeEndPeriod(1U);
			if (num != 0U)
			{
				throw new InvalidOperationException("timeEndPeriod(1) failed: " + num.ToString());
			}
			Class1.bool_0 = false;
		}

		// Token: 0x04000014 RID: 20
		private static bool bool_0;
	}
}
