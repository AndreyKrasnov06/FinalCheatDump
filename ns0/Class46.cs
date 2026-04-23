using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using AutoHotkey.Interop;

namespace ns0
{
	// Token: 0x0200007B RID: 123
	internal static class Class46
	{
		// Token: 0x060003CC RID: 972
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint SendInput(uint uint_7, Class46.Struct13[] struct13_0, int int_0);

		// Token: 0x060003CD RID: 973
		[DllImport("user32.dll")]
		private static extern short GetAsyncKeyState(int int_0);

		// Token: 0x060003CE RID: 974
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool PostMessage(IntPtr intptr_0, uint uint_7, IntPtr intptr_1, IntPtr intptr_2);

		// Token: 0x060003CF RID: 975
		[DllImport("user32.dll")]
		private static extern uint MapVirtualKey(uint uint_7, uint uint_8);

		// Token: 0x060003D0 RID: 976 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00004EDE File Offset: 0x000030DE
		public static void smethod_1(Keys keys_0)
		{
			Class46.smethod_4((ushort)keys_0, true);
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00004EE8 File Offset: 0x000030E8
		public static void smethod_2(Keys keys_0)
		{
			Class46.smethod_4((ushort)keys_0, false);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00004EF2 File Offset: 0x000030F2
		public static void smethod_3(Keys keys_0)
		{
			Class46.smethod_1(keys_0);
			Class46.smethod_2(keys_0);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00034360 File Offset: 0x00032560
		private static void smethod_4(ushort ushort_0, bool bool_0)
		{
			Class46.Struct13 @struct = new Class46.Struct13
			{
				uint_0 = 1U,
				struct14_0 = new Class46.Struct14
				{
					struct15_0 = new Class46.Struct15
					{
						ushort_0 = ushort_0,
						ushort_1 = 0,
						uint_0 = (bool_0 ? 0U : 2U),
						uint_1 = 0U,
						intptr_0 = IntPtr.Zero
					}
				}
			};
			Class46.Struct13[] array = new Class46.Struct13[] { @struct };
			Class46.SendInput(1U, array, Marshal.SizeOf(typeof(Class46.Struct13)));
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000343F8 File Offset: 0x000325F8
		public static void smethod_5(Keys keys_0, Class76 class76_0 = null, bool bool_0 = false)
		{
			if (bool_0)
			{
				uint num = Class46.MapVirtualKey((uint)keys_0, 0U);
				IntPtr intPtr = (IntPtr)((int)keys_0);
				IntPtr intPtr2 = (IntPtr)((long)((ulong)(1U | (num << 16))));
				IntPtr intPtr3 = (IntPtr)((long)((ulong)(3221225473U | (num << 16))));
				if (keys_0 == Keys.E)
				{
					Class46.PostMessage(class76_0.Handle, 256U, intPtr, intPtr2);
					Class46.smethod_11(50.0, 90.0);
					Class46.PostMessage(class76_0.Handle, 257U, intPtr, intPtr3);
					Class46.smethod_11(100.0, 180.0);
					return;
				}
				Class46.PostMessage(class76_0.Handle, 256U, intPtr, intPtr2);
				Class46.smethod_11(100.0, 180.0);
				Class46.PostMessage(class76_0.Handle, 257U, intPtr, intPtr3);
				Class46.smethod_11(100.0, 180.0);
				return;
			}
			else
			{
				if (class76_0 != null && class76_0.method_4() == Class76.Enum5.const_0)
				{
					class76_0.method_2();
				}
				string text;
				Class45.dictionary_0.TryGetValue(keys_0, out text);
				if (keys_0 == Keys.Return)
				{
					Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " down}");
					Class46.smethod_11(20.0, 0.0);
					Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " up}");
				}
				if (keys_0 == Keys.E)
				{
					Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " down}");
					Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " up}");
					return;
				}
				Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " down}");
				Class46.smethod_11(80.0, 120.0);
				Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " up}");
				Class46.smethod_11(80.0, 120.0);
				return;
			}
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x000345F8 File Offset: 0x000327F8
		public static void smethod_6(Keys keys_0, Class76 class76_0 = null, bool bool_0 = false)
		{
			if (bool_0)
			{
				uint num = Class46.MapVirtualKey((uint)keys_0, 0U);
				IntPtr intPtr = (IntPtr)((int)keys_0);
				IntPtr intPtr2 = (IntPtr)((long)((ulong)(1U | (num << 16))));
				IntPtr intPtr3 = (IntPtr)((long)((ulong)(3221225473U | (num << 16))));
				if (keys_0 == Keys.E)
				{
					Class46.PostMessage(class76_0.Handle, 256U, intPtr, intPtr2);
					Class46.smethod_11(60.0, 100.0);
					Class46.PostMessage(class76_0.Handle, 257U, intPtr, intPtr3);
					Class46.smethod_11(100.0, 180.0);
					return;
				}
				Class46.PostMessage(class76_0.Handle, 256U, intPtr, intPtr2);
				Class46.smethod_11(80.0, 120.0);
				Class46.PostMessage(class76_0.Handle, 257U, intPtr, intPtr3);
				Class46.smethod_11(100.0, 180.0);
				return;
			}
			else
			{
				if (class76_0 != null && class76_0.method_4() == Class76.Enum5.const_0)
				{
					class76_0.method_2();
				}
				if (keys_0 == Keys.Return)
				{
					string text;
					Class45.dictionary_0.TryGetValue(keys_0, out text);
					Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " down}");
					Class46.smethod_11(20.0, 0.0);
					Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " up}");
				}
				if (keys_0 == Keys.E)
				{
					Class46.smethod_3(Keys.E);
					return;
				}
				string text2;
				Class45.dictionary_0.TryGetValue(keys_0, out text2);
				Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text2 + " down}");
				Class46.smethod_11(80.0, 120.0);
				Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text2 + " up}");
				return;
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x000347C0 File Offset: 0x000329C0
		public static void smethod_7(Keys keys_0, Class76 class76_0 = null)
		{
			string text;
			Class45.dictionary_0.TryGetValue(keys_0, out text);
			if (class76_0 != null && class76_0.method_4() == Class76.Enum5.const_0)
			{
				class76_0.method_2();
			}
			if (keys_0 == Keys.E)
			{
				Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " down}");
				Class46.smethod_11(60.0, 100.0);
				Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " up}");
				return;
			}
			Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " down}");
			Class46.smethod_11(60.0, 100.0);
			Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " up}");
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00034888 File Offset: 0x00032A88
		public static bool smethod_8(Keys keys_0, Class76 class76_0 = null, bool bool_0 = false)
		{
			string text;
			Class45.dictionary_0.TryGetValue(keys_0, out text);
			if (class76_0 != null && class76_0.method_4() == Class76.Enum5.const_0)
			{
				class76_0.method_2();
			}
			if (!Class46.smethod_10(keys_0))
			{
				Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " down}");
				if (!bool_0)
				{
					Class46.smethod_11(40.0, 90.0);
				}
				return true;
			}
			return false;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x000348F4 File Offset: 0x00032AF4
		public static bool smethod_9(Keys keys_0, Class76 class76_0 = null, bool bool_0 = false, bool bool_1 = true)
		{
			string text;
			Class45.dictionary_0.TryGetValue(keys_0, out text);
			if (class76_0 != null && class76_0.method_4() == Class76.Enum5.const_0)
			{
				class76_0.method_2();
			}
			if (!Class46.smethod_10(keys_0))
			{
				return false;
			}
			if (!bool_1)
			{
				Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " up}");
				return true;
			}
			Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " up}");
			if (!bool_0)
			{
				Class46.smethod_11(40.0, 90.0);
			}
			else
			{
				Class46.smethod_11(20.0, 30.0);
			}
			return true;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00004F00 File Offset: 0x00003100
		public static bool smethod_10(Keys keys_0)
		{
			return ((int)Class46.GetAsyncKeyState((int)keys_0) & 32768) != 0;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00034998 File Offset: 0x00032B98
		private static void smethod_11(double double_0, double double_1 = 0.0)
		{
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class46.random_0.NextDouble() * (num2 - num);
			}
			else
			{
				num3 = double_0;
			}
			int num4 = (int)Math.Floor(num3);
			double num5 = num3 - (double)num4;
			if (num4 > 0)
			{
				Thread.Sleep(num4);
			}
			if (num5 > 0.0)
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				double num6 = num5 / 1000.0 * (double)Stopwatch.Frequency;
				while ((double)stopwatch.ElapsedTicks < num6)
				{
					Thread.SpinWait(10);
				}
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00034A2C File Offset: 0x00032C2C
		public static void smethod_12(Keys keys_0, int int_0, Class76 class76_0 = null, bool bool_0 = false)
		{
			ValueTuple<int, int> valueTuple = Class46.smethod_16(int_0, 3.0, 1.2);
			int item = valueTuple.Item1;
			int item2 = valueTuple.Item2;
			if (bool_0)
			{
				uint num = Class46.MapVirtualKey((uint)keys_0, 0U);
				IntPtr intPtr = (IntPtr)((int)keys_0);
				IntPtr intPtr2 = (IntPtr)((long)((ulong)(1U | (num << 16))));
				IntPtr intPtr3 = (IntPtr)((long)((ulong)(3221225473U | (num << 16))));
				Class46.PostMessage(class76_0.Handle, 256U, intPtr, intPtr2);
				Class46.smethod_11((double)item, 0.0);
				Class46.PostMessage(class76_0.Handle, 257U, intPtr, intPtr3);
				Class46.smethod_11((double)item2, 0.0);
				return;
			}
			if (class76_0 != null && class76_0.method_4() == Class76.Enum5.const_0)
			{
				class76_0.method_2();
			}
			string text;
			Class45.dictionary_0.TryGetValue(keys_0, out text);
			Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " down}");
			Class46.smethod_11((double)item, 0.0);
			Class46.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{" + text + " up}");
			Class46.smethod_11((double)item2, 0.0);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00004F11 File Offset: 0x00003111
		private static double smethod_13(double double_0, double double_1)
		{
			return double_0 + Class46.random_0.NextDouble() * (double_1 - double_0);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00004F23 File Offset: 0x00003123
		private static int smethod_14(int int_0, int int_1, int int_2)
		{
			if (int_0 < int_1)
			{
				return int_1;
			}
			if (int_0 <= int_2)
			{
				return int_0;
			}
			return int_2;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00034B50 File Offset: 0x00032D50
		private static double smethod_15(int int_0, double double_0, double double_1)
		{
			int num = Class46.smethod_14(int_0, 0, 100);
			double num2 = 1.0 - (double)num / 100.0;
			return 1.0 + Math.Pow(num2, double_1) * (double_0 - 1.0);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00034B9C File Offset: 0x00032D9C
		[return: TupleElementNames(new string[] { "downMs", "postMs" })]
		public static ValueTuple<int, int> smethod_16(int int_0, double double_0 = 3.0, double double_1 = 1.2)
		{
			double num = Class46.smethod_15(int_0, double_0, double_1);
			double num2 = Class46.smethod_13(60.0, 100.0) * num;
			double num3 = Class46.smethod_13(50.0, 80.0) * num;
			return new ValueTuple<int, int>((int)Math.Round(num2), (int)Math.Round(num3));
		}

		// Token: 0x04000491 RID: 1169
		private const uint uint_0 = 1U;

		// Token: 0x04000492 RID: 1170
		private const uint uint_1 = 1U;

		// Token: 0x04000493 RID: 1171
		private const uint uint_2 = 2U;

		// Token: 0x04000494 RID: 1172
		private const uint uint_3 = 8U;

		// Token: 0x04000495 RID: 1173
		private const uint uint_4 = 0U;

		// Token: 0x04000496 RID: 1174
		private const uint uint_5 = 256U;

		// Token: 0x04000497 RID: 1175
		private const uint uint_6 = 257U;

		// Token: 0x04000498 RID: 1176
		private static readonly AutoHotkeyEngine autoHotkeyEngine_0 = new AutoHotkeyEngine();

		// Token: 0x04000499 RID: 1177
		private static readonly Random random_0 = Class46.smethod_0();

		// Token: 0x0200007C RID: 124
		private struct Struct13
		{
			// Token: 0x0400049A RID: 1178
			public uint uint_0;

			// Token: 0x0400049B RID: 1179
			public Class46.Struct14 struct14_0;
		}

		// Token: 0x0200007D RID: 125
		[StructLayout(LayoutKind.Explicit)]
		private struct Struct14
		{
			// Token: 0x0400049C RID: 1180
			[FieldOffset(0)]
			public Class46.Struct16 struct16_0;

			// Token: 0x0400049D RID: 1181
			[FieldOffset(0)]
			public Class46.Struct15 struct15_0;

			// Token: 0x0400049E RID: 1182
			[FieldOffset(0)]
			public Class46.Struct17 struct17_0;
		}

		// Token: 0x0200007E RID: 126
		private struct Struct15
		{
			// Token: 0x0400049F RID: 1183
			public ushort ushort_0;

			// Token: 0x040004A0 RID: 1184
			public ushort ushort_1;

			// Token: 0x040004A1 RID: 1185
			public uint uint_0;

			// Token: 0x040004A2 RID: 1186
			public uint uint_1;

			// Token: 0x040004A3 RID: 1187
			public IntPtr intptr_0;
		}

		// Token: 0x0200007F RID: 127
		private struct Struct16
		{
			// Token: 0x040004A4 RID: 1188
			public int int_0;

			// Token: 0x040004A5 RID: 1189
			public int int_1;

			// Token: 0x040004A6 RID: 1190
			public uint uint_0;

			// Token: 0x040004A7 RID: 1191
			public uint uint_1;

			// Token: 0x040004A8 RID: 1192
			public uint uint_2;

			// Token: 0x040004A9 RID: 1193
			public IntPtr intptr_0;
		}

		// Token: 0x02000080 RID: 128
		private struct Struct17
		{
			// Token: 0x040004AA RID: 1194
			public uint uint_0;

			// Token: 0x040004AB RID: 1195
			public ushort ushort_0;

			// Token: 0x040004AC RID: 1196
			public ushort ushort_1;
		}
	}
}
