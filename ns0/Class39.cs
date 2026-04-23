using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x0200006D RID: 109
	internal class Class39
	{
		// Token: 0x0600036F RID: 879
		[DllImport("user32.dll")]
		private static extern bool RegisterHotKey(IntPtr intptr_0, int int_2, GEnum0 genum0_0, Keys keys_0);

		// Token: 0x06000370 RID: 880
		[DllImport("user32.dll")]
		public static extern bool UnregisterHotKey(IntPtr intptr_0, int int_2);

		// Token: 0x06000371 RID: 881 RVA: 0x0002F664 File Offset: 0x0002D864
		[CompilerGenerated]
		public static void smethod_0(EventHandler<GEventArgs0> eventHandler_1)
		{
			EventHandler<GEventArgs0> eventHandler = Class39.eventHandler_0;
			EventHandler<GEventArgs0> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<GEventArgs0> eventHandler3 = (EventHandler<GEventArgs0>)Delegate.Combine(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange<EventHandler<GEventArgs0>>(ref Class39.eventHandler_0, eventHandler3, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0002F698 File Offset: 0x0002D898
		[CompilerGenerated]
		public static void smethod_1(EventHandler<GEventArgs0> eventHandler_1)
		{
			EventHandler<GEventArgs0> eventHandler = Class39.eventHandler_0;
			EventHandler<GEventArgs0> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<GEventArgs0> eventHandler3 = (EventHandler<GEventArgs0>)Delegate.Remove(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange<EventHandler<GEventArgs0>>(ref Class39.eventHandler_0, eventHandler3, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0002F6CC File Offset: 0x0002D8CC
		public static void smethod_2(IntPtr intptr_0, int int_2, GEnum0 genum0_0, Keys keys_0)
		{
			if (!Class39.RegisterHotKey(intptr_0, int_2, genum0_0, keys_0))
			{
				string message = new Win32Exception(Marshal.GetLastWin32Error()).Message;
				MessageBox.Show("Ошибка при регистрации хоткея: " + message);
				return;
			}
			Class39.int_0++;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00004D20 File Offset: 0x00002F20
		public static void smethod_3(IntPtr intptr_0, int int_2, Keys keys_0)
		{
			Class39.RegisterHotKey(intptr_0, int_2, GEnum0.flag_4, keys_0);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00004D2C File Offset: 0x00002F2C
		public static void smethod_4(IntPtr intptr_0, int int_2, GEnum0 genum0_0, Keys keys_0)
		{
			Class39.UnregisterHotKey(intptr_0, int_2);
			Class39.RegisterHotKey(intptr_0, int_2, genum0_0, keys_0);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0002F714 File Offset: 0x0002D914
		public static void smethod_5(IntPtr intptr_0)
		{
			for (int i = 0; i < Class39.int_0; i++)
			{
				Class39.UnregisterHotKey(intptr_0, i);
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0002F73C File Offset: 0x0002D93C
		public static void smethod_6(IntPtr intptr_0)
		{
			Keys keys = (Keys)(((int)intptr_0 >> 16) & 65535);
			GEnum0 genum = (GEnum0)((int)intptr_0 & 65535);
			EventHandler<GEventArgs0> eventHandler = Class39.eventHandler_0;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(null, new GEventArgs0(keys, genum));
		}

		// Token: 0x0400044F RID: 1103
		private static int int_0;

		// Token: 0x04000450 RID: 1104
		[CompilerGenerated]
		private static EventHandler<GEventArgs0> eventHandler_0;

		// Token: 0x04000451 RID: 1105
		public const int int_1 = 786;
	}
}
