using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;

namespace ns0
{
	// Token: 0x02000083 RID: 131
	internal class Class49
	{
		// Token: 0x060003F0 RID: 1008
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint SendInput(uint uint_2, Class49.Struct18[] struct18_0, int int_0);

		// Token: 0x060003F1 RID: 1009 RVA: 0x000351B0 File Offset: 0x000333B0
		public static void smethod_0(int int_0, int int_1)
		{
			Class49.Struct18[] array = new Class49.Struct18[1];
			array[0].uint_0 = 0U;
			array[0].struct19_0.int_0 = int_0;
			array[0].struct19_0.int_1 = int_1;
			array[0].struct19_0.uint_0 = 0U;
			array[0].struct19_0.uint_1 = 1U;
			array[0].struct19_0.uint_2 = 0U;
			array[0].struct19_0.intptr_0 = IntPtr.Zero;
			Class49.SendInput((uint)array.Length, array, Marshal.SizeOf(typeof(Class49.Struct18)));
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_1()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0003525C File Offset: 0x0003345C
		public static void smethod_2(int int_0 = 10)
		{
			for (int i = 0; i < int_0; i++)
			{
				int num = Class49.random_0.Next(-20, 30);
				int num2 = Class49.random_0.Next(-10, 20);
				Class49.smethod_0(num, num2);
				Thread.Sleep(Class49.random_0.Next(15, 30));
			}
		}

		// Token: 0x040004B9 RID: 1209
		private const uint uint_0 = 0U;

		// Token: 0x040004BA RID: 1210
		private const uint uint_1 = 1U;

		// Token: 0x040004BB RID: 1211
		private static readonly Random random_0 = Class49.smethod_1();

		// Token: 0x02000084 RID: 132
		private struct Struct18
		{
			// Token: 0x040004BC RID: 1212
			public uint uint_0;

			// Token: 0x040004BD RID: 1213
			public Class49.Struct19 struct19_0;
		}

		// Token: 0x02000085 RID: 133
		private struct Struct19
		{
			// Token: 0x040004BE RID: 1214
			public int int_0;

			// Token: 0x040004BF RID: 1215
			public int int_1;

			// Token: 0x040004C0 RID: 1216
			public uint uint_0;

			// Token: 0x040004C1 RID: 1217
			public uint uint_1;

			// Token: 0x040004C2 RID: 1218
			public uint uint_2;

			// Token: 0x040004C3 RID: 1219
			public IntPtr intptr_0;
		}
	}
}
