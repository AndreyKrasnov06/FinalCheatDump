using System;
using System.Security.Cryptography;

namespace ns0
{
	// Token: 0x0200000A RID: 10
	public static class GClass2
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002AC1 File Offset: 0x00000CC1
		public static void smethod_0(byte[] byte_0)
		{
			if (byte_0 == null)
			{
				throw new ArgumentNullException("data");
			}
			ProtectedMemory.Protect(byte_0, MemoryProtectionScope.SameProcess);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002AD8 File Offset: 0x00000CD8
		public static void smethod_1(ref byte[] byte_0)
		{
			if (byte_0 == null)
			{
				throw new ArgumentNullException("data");
			}
			byte_0 = GClass2.smethod_4(byte_0);
			ProtectedMemory.Protect(byte_0, MemoryProtectionScope.SameProcess);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002AFA File Offset: 0x00000CFA
		public static void smethod_2(ref byte[] byte_0)
		{
			if (byte_0 == null)
			{
				throw new ArgumentNullException("data");
			}
			ProtectedMemory.Unprotect(byte_0, MemoryProtectionScope.SameProcess);
			byte_0 = GClass2.smethod_5(byte_0);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002B1C File Offset: 0x00000D1C
		public static byte[] smethod_3(ref byte[] byte_0, bool bool_0 = false)
		{
			if (byte_0 == null)
			{
				throw new ArgumentNullException("data");
			}
			ProtectedMemory.Unprotect(byte_0, MemoryProtectionScope.SameProcess);
			byte[] array = GClass2.smethod_5(byte_0);
			ProtectedMemory.Protect(byte_0, MemoryProtectionScope.SameProcess);
			if (bool_0)
			{
				GClass2.smethod_6(ref byte_0);
			}
			return array;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00005818 File Offset: 0x00003A18
		private static byte[] smethod_4(byte[] byte_0)
		{
			int num = 16;
			int num2 = 16 - byte_0.Length % 16;
			if (num2 == 0)
			{
				num2 = num;
			}
			byte[] array = new byte[byte_0.Length + num2];
			Array.Copy(byte_0, array, byte_0.Length);
			using (RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider())
			{
				byte[] array2 = new byte[num2 - 1];
				rngcryptoServiceProvider.GetBytes(array2);
				Array.Copy(array2, 0, array, byte_0.Length, array2.Length);
			}
			array[array.Length - 1] = (byte)num2;
			return array;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000589C File Offset: 0x00003A9C
		private static byte[] smethod_5(byte[] byte_0)
		{
			if (byte_0 == null || byte_0.Length == 0)
			{
				return byte_0;
			}
			int num = (int)byte_0[byte_0.Length - 1];
			if (num > 0 && num <= 16)
			{
				byte[] array = new byte[byte_0.Length - num];
				Array.Copy(byte_0, array, array.Length);
				return array;
			}
			throw new InvalidOperationException("Invalid padding length. Length: " + num.ToString());
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002B4D File Offset: 0x00000D4D
		public static void smethod_6(ref byte[] byte_0)
		{
			if (byte_0 != null)
			{
				Array.Clear(byte_0, 0, byte_0.Length);
				byte_0 = null;
			}
			GC.Collect();
		}
	}
}
