using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace ns0
{
	// Token: 0x020000A7 RID: 167
	internal class Class76
	{
		// Token: 0x060004A8 RID: 1192
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool IsIconic(IntPtr intptr_2);

		// Token: 0x060004A9 RID: 1193
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int ShowWindow(IntPtr intptr_2, int int_6);

		// Token: 0x060004AA RID: 1194
		[DllImport("user32.dll")]
		private static extern IntPtr SetWinEventHook(uint uint_0, uint uint_1, IntPtr intptr_2, Class76.Delegate0 delegate0_1, uint uint_2, uint uint_3, uint uint_4);

		// Token: 0x060004AB RID: 1195
		[DllImport("user32.dll")]
		private static extern bool UnhookWinEvent(IntPtr intptr_2);

		// Token: 0x060004AC RID: 1196
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr GetForegroundWindow();

		// Token: 0x060004AD RID: 1197
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool SetForegroundWindow(IntPtr intptr_2);

		// Token: 0x060004AE RID: 1198
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr FindWindow(string string_1, string string_2);

		// Token: 0x060004AF RID: 1199
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool GetClientRect(IntPtr intptr_2, out Class76.Struct26 struct26_0);

		// Token: 0x060004B0 RID: 1200
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool SetWindowPos(IntPtr intptr_2, IntPtr intptr_3, int int_6, int int_7, int int_8, int int_9, uint uint_0);

		// Token: 0x060004B1 RID: 1201
		[DllImport("user32.dll")]
		private static extern bool ClientToScreen(IntPtr intptr_2, ref Point point_0);

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060004B2 RID: 1202 RVA: 0x000053B5 File Offset: 0x000035B5
		// (set) Token: 0x060004B3 RID: 1203 RVA: 0x000053BD File Offset: 0x000035BD
		public IntPtr Handle { get; private set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060004B4 RID: 1204 RVA: 0x000053C6 File Offset: 0x000035C6
		// (set) Token: 0x060004B5 RID: 1205 RVA: 0x000053CE File Offset: 0x000035CE
		public int Width { get; private set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x000053D7 File Offset: 0x000035D7
		// (set) Token: 0x060004B7 RID: 1207 RVA: 0x000053DF File Offset: 0x000035DF
		public int Height { get; private set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x000053E8 File Offset: 0x000035E8
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x000053F0 File Offset: 0x000035F0
		public int Top { get; private set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x000053F9 File Offset: 0x000035F9
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x00005401 File Offset: 0x00003601
		public int Bottom { get; private set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x0000540A File Offset: 0x0000360A
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x00005412 File Offset: 0x00003612
		public int Left { get; private set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x0000541B File Offset: 0x0000361B
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x00005423 File Offset: 0x00003623
		public int Right { get; private set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0000542C File Offset: 0x0000362C
		// (set) Token: 0x060004C1 RID: 1217 RVA: 0x00005434 File Offset: 0x00003634
		public string Resolution { get; private set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x0000543D File Offset: 0x0000363D
		// (set) Token: 0x060004C3 RID: 1219 RVA: 0x00005445 File Offset: 0x00003645
		public bool IsActive { get; private set; }

		// Token: 0x060004C4 RID: 1220 RVA: 0x0003A7CC File Offset: 0x000389CC
		public Class76(string string_1)
		{
			Process[] processesByName = Process.GetProcessesByName(string_1);
			if (processesByName.Length == 0)
			{
				throw new Exception("Окно " + string_1 + " не найдено!");
			}
			this.Handle = Class76.FindWindow(null, processesByName[0].MainWindowTitle);
			if (Class76.IsIconic(this.Handle))
			{
				Class76.ShowWindow(this.Handle, 9);
				Thread.Sleep(2000);
			}
			Class76.Struct26 @struct;
			Class76.GetClientRect(this.Handle, out @struct);
			Point point = new Point(@struct.int_0, @struct.int_1);
			Class76.ClientToScreen(this.Handle, ref point);
			this.Width = @struct.Width;
			this.Height = @struct.Height;
			this.Left = point.X;
			this.Top = point.Y;
			this.Right = point.X + @struct.Width;
			this.Bottom = point.Y + @struct.Height;
			this.Resolution = this.Width.ToString() + "x" + this.Height.ToString();
			Class76.delegate0_0 = new Class76.Delegate0(this.method_0);
			Class76.intptr_1 = Class76.SetWinEventHook(3U, 3U, IntPtr.Zero, Class76.delegate0_0, 0U, 0U, 0U);
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0000544E File Offset: 0x0000364E
		private void method_0(IntPtr intptr_2, uint uint_0, IntPtr intptr_3, int int_6, int int_7, uint uint_1, uint uint_2)
		{
			Task.Run(new Action(this.method_6));
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00005462 File Offset: 0x00003662
		public static void smethod_0()
		{
			Class76.UnhookWinEvent(Class76.intptr_1);
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0003A91C File Offset: 0x00038B1C
		public string method_1()
		{
			Class76.Struct26 @struct;
			Class76.GetClientRect(this.Handle, out @struct);
			Point point = new Point(@struct.int_0, @struct.int_1);
			Class76.ClientToScreen(this.Handle, ref point);
			this.Width = @struct.Width;
			this.Height = @struct.Height;
			this.Left = point.X;
			this.Top = point.Y;
			this.Right = point.X + @struct.Width;
			this.Bottom = point.Y + @struct.Height;
			return this.Width.ToString() + "x" + this.Height.ToString();
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0003A9DC File Offset: 0x00038BDC
		public void method_2()
		{
			if (Class76.IsIconic(this.Handle))
			{
				Class76.ShowWindow(this.Handle, 9);
				Thread.Sleep(600);
			}
			if (Class76.GetForegroundWindow() != this.Handle)
			{
				Class76.SetForegroundWindow(this.Handle);
			}
			this.IsActive = true;
		}

		// Token: 0x060004C9 RID: 1225
		[DllImport("user32.dll")]
		private static extern uint GetWindowLong(IntPtr intptr_2, int int_6);

		// Token: 0x060004CA RID: 1226
		[DllImport("user32.dll")]
		private static extern bool GetWindowRect(IntPtr intptr_2, out Class76.Struct26 struct26_0);

		// Token: 0x060004CB RID: 1227
		[DllImport("user32.dll")]
		private static extern uint GetDpiForWindow(IntPtr intptr_2);

		// Token: 0x060004CC RID: 1228
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool AdjustWindowRectEx(ref Class76.Struct26 struct26_0, uint uint_0, bool bool_1, uint uint_1);

		// Token: 0x060004CD RID: 1229
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool AdjustWindowRectExForDpi(ref Class76.Struct26 struct26_0, uint uint_0, bool bool_1, uint uint_1, uint uint_2);

		// Token: 0x060004CE RID: 1230 RVA: 0x0003AA34 File Offset: 0x00038C34
		public void method_3(int int_6, int int_7)
		{
			IntPtr handle = this.Handle;
			if (handle == IntPtr.Zero)
			{
				throw new InvalidOperationException("Окно GTA V не найдено.");
			}
			Class76.ShowWindow(handle, 9);
			uint windowLong = Class76.GetWindowLong(handle, -16);
			uint windowLong2 = Class76.GetWindowLong(handle, -20);
			Class76.Struct26 @struct = new Class76.Struct26
			{
				int_0 = 0,
				int_1 = 0,
				int_2 = int_6,
				int_3 = int_7
			};
			bool flag = false;
			try
			{
				uint dpiForWindow = Class76.GetDpiForWindow(handle);
				if (dpiForWindow != 0U)
				{
					flag = Class76.AdjustWindowRectExForDpi(ref @struct, windowLong, false, windowLong2, dpiForWindow);
				}
			}
			catch (EntryPointNotFoundException)
			{
			}
			if (!flag)
			{
				Class76.AdjustWindowRectEx(ref @struct, windowLong, false, windowLong2);
			}
			int num = @struct.int_2 - @struct.int_0;
			int num2 = @struct.int_3 - @struct.int_1;
			Class76.Struct26 struct2;
			Class76.GetWindowRect(handle, out struct2);
			int num3 = struct2.int_0;
			int num4 = struct2.int_1;
			if (!Class76.SetWindowPos(handle, IntPtr.Zero, num3, num4, num, num2, 116U))
			{
				throw new InvalidOperationException("Не удалось изменить размер окна.");
			}
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0003AB44 File Offset: 0x00038D44
		public Class76.Enum5 method_4()
		{
			Class76.Enum5 @enum;
			try
			{
				string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Rockstar Games\\GTA V\\settings.xml");
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(text);
				XmlNode xmlNode = xmlDocument.SelectSingleNode("/Settings/video/Windowed");
				if (xmlNode != null)
				{
					if (int.Parse(xmlNode.Attributes["value"].Value) == 0)
					{
						@enum = Class76.Enum5.const_1;
					}
					else
					{
						@enum = Class76.Enum5.const_0;
					}
				}
				else
				{
					@enum = Class76.Enum5.const_1;
				}
			}
			catch
			{
				@enum = Class76.Enum5.const_1;
			}
			return @enum;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0003ABBC File Offset: 0x00038DBC
		public string method_5()
		{
			double num = (double)this.Width / (double)this.Height;
			if (Math.Abs(num - 1.7777777777777777) < 0.01)
			{
				return "16x9";
			}
			if (Math.Abs(num - 1.6) < 0.01)
			{
				return "16x10";
			}
			if (Math.Abs(num - 1.25) < 0.01)
			{
				return "5x4";
			}
			if (Math.Abs(num - 1.3333333333333333) < 0.01)
			{
				return "4x3";
			}
			if (Math.Abs(num - 2.3333333333333335) < 0.01)
			{
				return "21x9";
			}
			if (Math.Abs(num - 1.5) < 0.01)
			{
				return "3x2";
			}
			return "unknown";
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0003ACA4 File Offset: 0x00038EA4
		[CompilerGenerated]
		private void method_6()
		{
			Thread.Sleep(1000);
			IntPtr foregroundWindow = Class76.GetForegroundWindow();
			this.IsActive = foregroundWindow == this.Handle;
		}

		// Token: 0x0400055B RID: 1371
		[CompilerGenerated]
		private IntPtr intptr_0;

		// Token: 0x0400055C RID: 1372
		[CompilerGenerated]
		private int int_0;

		// Token: 0x0400055D RID: 1373
		[CompilerGenerated]
		private int int_1;

		// Token: 0x0400055E RID: 1374
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400055F RID: 1375
		[CompilerGenerated]
		private int int_3;

		// Token: 0x04000560 RID: 1376
		[CompilerGenerated]
		private int int_4;

		// Token: 0x04000561 RID: 1377
		[CompilerGenerated]
		private int int_5;

		// Token: 0x04000562 RID: 1378
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000563 RID: 1379
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000564 RID: 1380
		private static Class76.Delegate0 delegate0_0;

		// Token: 0x04000565 RID: 1381
		private static IntPtr intptr_1;

		// Token: 0x020000A8 RID: 168
		private struct Struct26
		{
			// Token: 0x170000B7 RID: 183
			// (get) Token: 0x060004D2 RID: 1234 RVA: 0x0000546F File Offset: 0x0000366F
			public int Width
			{
				get
				{
					return this.int_2 - this.int_0;
				}
			}

			// Token: 0x170000B8 RID: 184
			// (get) Token: 0x060004D3 RID: 1235 RVA: 0x0000547E File Offset: 0x0000367E
			public int Height
			{
				get
				{
					return this.int_3 - this.int_1;
				}
			}

			// Token: 0x04000566 RID: 1382
			public int int_0;

			// Token: 0x04000567 RID: 1383
			public int int_1;

			// Token: 0x04000568 RID: 1384
			public int int_2;

			// Token: 0x04000569 RID: 1385
			public int int_3;
		}

		// Token: 0x020000A9 RID: 169
		// (Invoke) Token: 0x060004D5 RID: 1237
		private delegate void Delegate0(IntPtr intptr_0, uint uint_0, IntPtr intptr_1, int int_0, int int_1, uint uint_1, uint uint_2);

		// Token: 0x020000AA RID: 170
		public enum Enum5
		{
			// Token: 0x0400056B RID: 1387
			const_0,
			// Token: 0x0400056C RID: 1388
			const_1
		}
	}
}
