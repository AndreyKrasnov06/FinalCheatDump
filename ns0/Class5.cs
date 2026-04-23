using System;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace ns0
{
	// Token: 0x0200002E RID: 46
	internal static class Class5
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x00015514 File Offset: 0x00013714
		public static byte[] smethod_0(ref byte[] byte_0)
		{
			byte[] array = new byte[32];
			byte[] array2 = new byte[12];
			new SecureRandom().NextBytes(array);
			new SecureRandom().NextBytes(array2);
			GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
			AeadParameters aeadParameters = new AeadParameters(new KeyParameter(array), 128, array2);
			int num = array.Length;
			int num2 = array2.Length;
			GClass2.smethod_1(ref array);
			GClass2.smethod_1(ref array2);
			gcmBlockCipher.Init(true, aeadParameters);
			GClass2.smethod_2(ref byte_0);
			byte[] array3 = new byte[gcmBlockCipher.GetOutputSize(byte_0.Length)];
			int num3 = gcmBlockCipher.ProcessBytes(byte_0, 0, byte_0.Length, array3, 0);
			GClass2.smethod_1(ref byte_0);
			GClass2.smethod_6(ref byte_0);
			gcmBlockCipher.DoFinal(array3, num3);
			int num4 = array3.Length;
			GClass2.smethod_1(ref array3);
			byte[] array4 = new byte[num + num2];
			Buffer.BlockCopy(GClass2.smethod_3(ref array, true), 0, array4, 0, num);
			Buffer.BlockCopy(GClass2.smethod_3(ref array2, true), 0, array4, num, num2);
			byte[] array5 = Class64.smethod_0(array4);
			GClass2.smethod_6(ref array4);
			int num5 = array5.Length;
			GClass2.smethod_1(ref array5);
			byte[] array6 = new byte[num4 + num5];
			Buffer.BlockCopy(GClass2.smethod_3(ref array3, true), 0, array6, 0, num4);
			Buffer.BlockCopy(GClass2.smethod_3(ref array5, true), 0, array6, num4, num5);
			GClass2.smethod_1(ref array6);
			return array6;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00015658 File Offset: 0x00013858
		public static byte[] smethod_1(ref byte[] byte_0)
		{
			byte[] array = new byte[32];
			byte[] array2 = new byte[12];
			byte[] array3 = Class64.smethod_1(GClass2.smethod_3(ref byte_0, false));
			Buffer.BlockCopy(GClass2.smethod_3(ref array3, false), 0, array2, 0, 12);
			GClass2.smethod_1(ref array2);
			Buffer.BlockCopy(GClass2.smethod_3(ref array3, true), 12, array, 0, 32);
			GClass2.smethod_1(ref array);
			GClass2.smethod_2(ref byte_0);
			byte[] array4 = new byte[byte_0.Length - 384];
			Buffer.BlockCopy(byte_0, 384, array4, 0, array4.Length);
			GClass2.smethod_6(ref byte_0);
			GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
			AeadParameters aeadParameters = new AeadParameters(new KeyParameter(GClass2.smethod_3(ref array, true)), 128, GClass2.smethod_3(ref array2, false));
			gcmBlockCipher.Init(false, aeadParameters);
			byte[] array5 = new byte[gcmBlockCipher.GetOutputSize(array4.Length)];
			int num = gcmBlockCipher.ProcessBytes(array4, 0, array4.Length, array5, 0);
			GClass2.smethod_6(ref array4);
			byte[] array6;
			try
			{
				gcmBlockCipher.DoFinal(array5, num);
				GClass2.smethod_1(ref array5);
				array6 = array5;
			}
			catch (InvalidCipherTextException ex)
			{
				new FormMessage(ex);
				new FormMessage(" Length:" + GClass2.smethod_3(ref array2, false).Length.ToString());
				throw new CryptographicException("CryptographicException: Ошибка аутентификации. ");
			}
			return array6;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000157A4 File Offset: 0x000139A4
		public static byte[] smethod_2(byte[] byte_0, ref byte[] byte_1)
		{
			byte[] array = new byte[32];
			byte[] array2 = new byte[12];
			Buffer.BlockCopy(GClass2.smethod_3(ref byte_1, false), 0, array, 0, 32);
			GClass2.smethod_1(ref array);
			Buffer.BlockCopy(GClass2.smethod_3(ref byte_1, false), 32, array2, 0, 12);
			GClass2.smethod_1(ref array2);
			GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
			AeadParameters aeadParameters = new AeadParameters(new KeyParameter(GClass2.smethod_3(ref array, true)), 128, GClass2.smethod_3(ref array2, true));
			gcmBlockCipher.Init(false, aeadParameters);
			byte[] array3 = new byte[gcmBlockCipher.GetOutputSize(byte_0.Length)];
			int num = gcmBlockCipher.ProcessBytes(byte_0, 0, byte_0.Length, array3, 0);
			byte[] array4;
			try
			{
				gcmBlockCipher.DoFinal(array3, num);
				GClass2.smethod_1(ref array3);
				array4 = array3;
			}
			catch (InvalidCipherTextException ex)
			{
				new FormMessage(ex);
				new FormMessage(" Length:" + GClass2.smethod_3(ref array2, false).Length.ToString());
				throw new CryptographicException("CryptographicException: Ошибка аутентификации. ");
			}
			return array4;
		}
	}
}
