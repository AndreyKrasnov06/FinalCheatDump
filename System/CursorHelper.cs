using System;
using System.Runtime.InteropServices;

namespace System
{
	// Token: 0x02000013 RID: 19
	internal class CursorHelper
	{
		// Token: 0x06000096 RID: 150
		[DllImport("user32.dll")]
		private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

		// Token: 0x06000097 RID: 151
		[DllImport("user32.dll")]
		private static extern IntPtr CopyIcon(IntPtr hCursor);

		// Token: 0x06000098 RID: 152
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SetSystemCursor(IntPtr hcur, uint id);

		// Token: 0x06000099 RID: 153 RVA: 0x00006CA4 File Offset: 0x00004EA4
		public static void DisableAppStarting()
		{
			if (CursorHelper._origAppStarting != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = CursorHelper.LoadCursor(IntPtr.Zero, 32650);
			if (intPtr != IntPtr.Zero)
			{
				CursorHelper._origAppStarting = CursorHelper.CopyIcon(intPtr);
			}
			IntPtr intPtr2 = CursorHelper.LoadCursor(IntPtr.Zero, 32512);
			if (intPtr2 != IntPtr.Zero)
			{
				CursorHelper.SetSystemCursor(CursorHelper.CopyIcon(intPtr2), 32650U);
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000308D File Offset: 0x0000128D
		public static void RestoreAppStarting()
		{
			if (CursorHelper._origAppStarting == IntPtr.Zero)
			{
				return;
			}
			CursorHelper.SetSystemCursor(CursorHelper._origAppStarting, 32650U);
			CursorHelper._origAppStarting = IntPtr.Zero;
		}

		// Token: 0x04000050 RID: 80
		private const int IDC_ARROW = 32512;

		// Token: 0x04000051 RID: 81
		private const int IDC_APPSTARTING = 32650;

		// Token: 0x04000052 RID: 82
		private const uint OCR_APPSTARTING = 32650U;

		// Token: 0x04000053 RID: 83
		private static IntPtr _origAppStarting = IntPtr.Zero;
	}
}
