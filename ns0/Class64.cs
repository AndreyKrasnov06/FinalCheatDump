using System;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Security;

namespace ns0
{
	// Token: 0x02000099 RID: 153
	internal static class Class64
	{
		// Token: 0x06000463 RID: 1123 RVA: 0x00038610 File Offset: 0x00036810
		public static byte[] smethod_0(byte[] byte_1)
		{
			byte[] array;
			try
			{
				OaepEncoding oaepEncoding = new OaepEncoding(new RsaEngine(), new Sha256Digest(), new Sha256Digest(), null);
				oaepEncoding.Init(true, PublicKeyFactory.CreateKey(GClass2.smethod_3(ref Class64.byte_0, false)));
				array = oaepEncoding.ProcessBlock(byte_1, 0, byte_1.Length);
			}
			catch (Exception ex)
			{
				new FormMessage(ex);
				array = null;
			}
			return array;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00038674 File Offset: 0x00036874
		public static byte[] smethod_1(byte[] byte_1)
		{
			OaepEncoding oaepEncoding = new OaepEncoding(new RsaEngine(), new Sha256Digest(), new Sha256Digest(), null);
			oaepEncoding.Init(false, PrivateKeyFactory.CreateKey(GClass2.smethod_3(ref Class59.byte_0, false)));
			byte[] array = oaepEncoding.ProcessBlock(byte_1, 0, 384);
			GClass2.smethod_1(ref array);
			return array;
		}

		// Token: 0x0400051B RID: 1307
		public static byte[] byte_0 = new byte[]
		{
			48, 130, 1, 162, 48, 13, 6, 9, 42, 134,
			72, 134, 247, 13, 1, 1, 1, 5, 0, 3,
			130, 1, 143, 0, 48, 130, 1, 138, 2, 130,
			1, 129, 0, 128, 136, 30, 181, 83, 47, 129,
			24, 145, 169, 165, 109, 221, 4, 92, 111, 10,
			123, 105, 185, 159, 150, 141, 99, 92, 42, 200,
			147, 127, 235, 197, 223, 240, 90, 186, 22, 8,
			238, 75, 175, 106, 20, 100, 57, 13, 191, 233,
			54, 204, 62, 187, 122, 228, 4, 99, 203, 253,
			178, 37, 220, 145, 254, 103, 229, 25, 57, 228,
			189, 230, 3, 112, 243, 11, 12, 144, 183, 64,
			204, 55, 190, 151, 224, 190, 56, 179, 8, 241,
			184, 156, 97, 253, 166, 135, 130, 31, 61, 67,
			75, 18, 25, 180, 120, 182, 247, 71, 202, 80,
			102, 128, 108, 169, byte.MaxValue, 205, 148, 16, 106, 48,
			61, 108, 98, 252, 21, 88, 244, 254, 211, 205,
			203, 136, 86, 102, 133, 49, 232, 132, 125, 191,
			83, 7, 146, 203, 77, 63, 204, 142, 250, 238,
			83, 110, 101, 228, 98, 199, 143, 108, 224, 74,
			167, 92, 213, 157, 139, 85, 252, 89, 130, 202,
			83, 195, 148, 21, 119, 53, 159, 147, 12, 99,
			230, 37, 156, 86, 69, 155, 208, 57, 14, 169,
			239, 62, 150, 107, 30, 129, 55, 32, 50, 90,
			204, 13, 161, 185, 127, 124, 179, 136, 14, 45,
			239, 106, 200, 253, 57, 77, 162, 245, 22, 51,
			229, 221, 164, 102, 26, 54, 11, 112, 108, 190,
			99, 248, 165, 136, 198, 235, 11, 104, 47, 8,
			215, 217, 202, 45, 212, 196, 154, 121, 7, 35,
			228, 245, 44, 175, 24, 139, 152, 238, 99, 5,
			20, 0, 20, 136, 56, 7, 211, 9, 192, 164,
			121, 161, 138, 44, 83, 163, 65, 72, byte.MaxValue, 209,
			254, 87, 31, 81, 103, 27, 192, 77, 97, 25,
			134, 59, 20, 162, 133, 101, 167, 83, 120, 16,
			186, 107, 164, 164, 150, 124, 23, 136, 93, 213,
			43, 22, 78, 30, 153, 42, 115, 151, 37, 136,
			29, 146, 107, 248, 171, 26, 15, 199, 106, 81,
			63, 177, 171, 191, 151, 237, 71, 7, 94, 73,
			134, 19, 228, 67, 6, 73, 117, 166, 168, 108,
			248, 131, 165, 206, 123, 85, 2, 38, 161, 74,
			253, 163, 53, 86, 55, 132, 146, 18, 177, 197,
			91, 120, 170, 91, 84, 53, 39, 144, 76, 248,
			39, 201, 185, 249, 234, 112, 19, 2, 3, 1,
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 10
		};
	}
}
