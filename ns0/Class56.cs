using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using AutoHotkey.Interop;
using OpenCvSharp;

namespace ns0
{
	// Token: 0x0200008D RID: 141
	internal class Class56
	{
		// Token: 0x06000419 RID: 1049
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint SendInput(uint uint_4, Class56.Struct21[] struct21_0, int int_6);

		// Token: 0x0600041A RID: 1050
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int int_6);

		// Token: 0x0600041B RID: 1051
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern short GetAsyncKeyState(int int_6);

		// Token: 0x0600041C RID: 1052
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		private static extern bool PostMessage(IntPtr intptr_0, uint uint_4, IntPtr intptr_1, IntPtr intptr_2);

		// Token: 0x0600041D RID: 1053
		[DllImport("user32.dll")]
		private static extern bool GetCursorPos(out Class56.Struct24 struct24_0);

		// Token: 0x0600041E RID: 1054
		[DllImport("user32.dll")]
		private static extern bool ScreenToClient(IntPtr intptr_0, ref Class56.Struct24 struct24_0);

		// Token: 0x0600041F RID: 1055 RVA: 0x00015108 File Offset: 0x00013308
		private static Random smethod_0()
		{
			byte[] array = new byte[4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0000504B File Offset: 0x0000324B
		public static bool smethod_1(Keys keys_0)
		{
			return ((int)Class56.GetAsyncKeyState((int)keys_0) & 32768) != 0;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00036BB0 File Offset: 0x00034DB0
		public static Point smethod_2(IntPtr intptr_0)
		{
			Class56.Struct24 @struct;
			Class56.GetCursorPos(out @struct);
			Class56.ScreenToClient(intptr_0, ref @struct);
			return new Point(@struct.int_0, @struct.int_1);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00036BE0 File Offset: 0x00034DE0
		private static Point smethod_3(Point point_0)
		{
			int systemMetrics = Class56.GetSystemMetrics(0);
			int systemMetrics2 = Class56.GetSystemMetrics(1);
			int num = (int)Math.Round((double)point_0.X * 65535.0 / (double)(systemMetrics - 1));
			int num2 = (int)Math.Round((double)point_0.Y * 65535.0 / (double)(systemMetrics2 - 1));
			return new Point(num, num2);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00036C3C File Offset: 0x00034E3C
		private static void smethod_4(Point point_0)
		{
			Point point = Class56.smethod_3(point_0);
			Class56.Struct21 @struct = new Class56.Struct21
			{
				uint_0 = 0U,
				struct22_0 = new Class56.Struct22
				{
					struct23_0 = new Class56.Struct23
					{
						int_0 = point.X,
						int_1 = point.Y,
						uint_1 = 32769U,
						uint_0 = 0U,
						intptr_0 = IntPtr.Zero,
						uint_2 = 0U
					}
				}
			};
			Class56.SendInput(1U, new Class56.Struct21[] { @struct }, Marshal.SizeOf(typeof(Class56.Struct21)));
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00036CEC File Offset: 0x00034EEC
		private static void smethod_5()
		{
			Class56.SendInput(2U, new Class56.Struct21[]
			{
				new Class56.Struct21
				{
					uint_0 = 0U,
					struct22_0 = new Class56.Struct22
					{
						struct23_0 = new Class56.Struct23
						{
							uint_1 = 2U
						}
					}
				},
				new Class56.Struct21
				{
					uint_0 = 0U,
					struct22_0 = new Class56.Struct22
					{
						struct23_0 = new Class56.Struct23
						{
							uint_1 = 4U
						}
					}
				}
			}, Marshal.SizeOf(typeof(Class56.Struct21)));
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00036D98 File Offset: 0x00034F98
		public static void smethod_6(Class76 class76_0, int int_6, int int_7, Point point_0 = default(Point), Size size_0 = default(Size))
		{
			if (point_0.X > 0 && point_0.Y > 0)
			{
				int num = size_0.Width / 3;
				point_0.X += size_0.Width / 2 + Class56.random_0.Next(0, num + 1);
				num = size_0.Height / 3;
				point_0.Y += size_0.Height / 2 + Class56.random_0.Next(0, num + 1);
				Class56.smethod_21(int_6, point_0, class76_0, 100);
				Class56.smethod_19(int_7);
				return;
			}
			Class56.smethod_19(int_7);
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00036E30 File Offset: 0x00035030
		public static void smethod_7(Class76 class76_0, int int_6, int int_7, Rectangle rectangle_0)
		{
			Point point = new Point(rectangle_0.X, rectangle_0.Y);
			Size size = new Size(rectangle_0.Width, rectangle_0.Height);
			if (point.X > 0 && point.Y > 0)
			{
				int num = size.Width / 3;
				point.X += size.Width / 2 + Class56.random_0.Next(0, num + 1);
				num = size.Height / 3;
				point.Y += size.Height / 2 + Class56.random_0.Next(0, num + 1);
				Class56.smethod_21(int_6, point, class76_0, 100);
				Class56.smethod_19(int_7);
				return;
			}
			Class56.smethod_19(int_7);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00036EF4 File Offset: 0x000350F4
		public static void smethod_8(Class76 class76_0, int int_6, int int_7, Rect rect_0)
		{
			Point point = new Point(rect_0.X, rect_0.Y);
			Size size = new Size(rect_0.Width, rect_0.Height);
			if (point.X > 0 && point.Y > 0)
			{
				int num = size.Width / 3;
				point.X += size.Width / 2 + Class56.random_0.Next(0, num + 1);
				num = size.Height / 3;
				point.Y += size.Height / 2 + Class56.random_0.Next(0, num + 1);
				Class56.smethod_21(int_6, point, class76_0, 100);
				Class56.smethod_19(int_7);
				return;
			}
			Class56.smethod_19(int_7);
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00036FB4 File Offset: 0x000351B4
		public static void smethod_9(Class76 class76_0, Point point_0 = default(Point), Size size_0 = default(Size))
		{
			if (class76_0.method_4() == Class76.Enum5.const_0)
			{
				class76_0.method_2();
			}
			if (point_0.X > 0 && point_0.Y > 0)
			{
				int num = size_0.Width / 3;
				point_0.X += Class56.random_0.Next(-num, num + 1);
				num = size_0.Height / 3;
				point_0.Y += Class56.random_0.Next(-num, num + 1);
				Class56.smethod_20(point_0, class76_0, 100);
				Class56.smethod_10(true);
				return;
			}
			Class56.smethod_10(true);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00037048 File Offset: 0x00035248
		private static void smethod_10(bool bool_0 = true)
		{
			double num = 60.0 + Class56.random_0.NextDouble() * 40.0;
			double num2 = 50.0 + Class56.random_0.NextDouble() * 30.0;
			Class56.Struct21 @struct = new Class56.Struct21
			{
				uint_0 = 0U,
				struct22_0 = new Class56.Struct22
				{
					struct23_0 = new Class56.Struct23
					{
						uint_1 = 2U
					}
				}
			};
			Class56.SendInput(1U, new Class56.Struct21[] { @struct }, Marshal.SizeOf(typeof(Class56.Struct21)));
			if (bool_0)
			{
				Class56.smethod_36(num, 0.0);
			}
			Class56.Struct21 struct2 = new Class56.Struct21
			{
				uint_0 = 0U,
				struct22_0 = new Class56.Struct22
				{
					struct23_0 = new Class56.Struct23
					{
						uint_1 = 4U
					}
				}
			};
			Class56.SendInput(1U, new Class56.Struct21[] { struct2 }, Marshal.SizeOf(typeof(Class56.Struct21)));
			if (bool_0)
			{
				Class56.smethod_36(num2, 0.0);
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0000505C File Offset: 0x0000325C
		private static double smethod_11(double double_0, double double_1)
		{
			return double_0 + Class56.random_0.NextDouble() * (double_1 - double_0);
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00004F23 File Offset: 0x00003123
		private static int smethod_12(int int_6, int int_7, int int_8)
		{
			if (int_6 < int_7)
			{
				return int_7;
			}
			if (int_6 <= int_8)
			{
				return int_6;
			}
			return int_8;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0003717C File Offset: 0x0003537C
		private static double smethod_13(int int_6, double double_0, double double_1)
		{
			int num = Class56.smethod_12(int_6, 0, 100);
			double num2 = 1.0 - (double)num / 100.0;
			return 1.0 + Math.Pow(num2, double_1) * (double_0 - 1.0);
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0000506E File Offset: 0x0000326E
		private static int smethod_14(int int_6)
		{
			return (int)Math.Round((double)(Class56.smethod_12(int_6, 0, 100) * 28) / 100.0);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0000506E File Offset: 0x0000326E
		private static int smethod_15(int int_6)
		{
			return (int)Math.Round((double)(Class56.smethod_12(int_6, 0, 100) * 28) / 100.0);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x000371C8 File Offset: 0x000353C8
		[return: TupleElementNames(new string[] { "downMs", "postMs" })]
		public static ValueTuple<double, double> smethod_16(int int_6, double double_0 = 3.0, double double_1 = 1.2)
		{
			double num = Class56.smethod_13(int_6, double_0, double_1);
			double num2 = Class56.smethod_11(50.0, 80.0) * num;
			double num3 = Class56.smethod_11(40.0, 70.0) * num;
			return new ValueTuple<double, double>(num2, num3);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00037218 File Offset: 0x00035418
		public static void smethod_17(int int_6)
		{
			ValueTuple<double, double> valueTuple = Class56.smethod_16(int_6, 3.0, 1.2);
			double item = valueTuple.Item1;
			double item2 = valueTuple.Item2;
			Class56.Struct21 @struct = new Class56.Struct21
			{
				uint_0 = 0U,
				struct22_0 = new Class56.Struct22
				{
					struct23_0 = new Class56.Struct23
					{
						uint_1 = 2U
					}
				}
			};
			Class56.SendInput(1U, new Class56.Struct21[] { @struct }, Marshal.SizeOf(typeof(Class56.Struct21)));
			Class56.smethod_36(item, 0.0);
			Class56.Struct21 struct2 = new Class56.Struct21
			{
				uint_0 = 0U,
				struct22_0 = new Class56.Struct22
				{
					struct23_0 = new Class56.Struct23
					{
						uint_1 = 4U
					}
				}
			};
			Class56.SendInput(1U, new Class56.Struct21[] { struct2 }, Marshal.SizeOf(typeof(Class56.Struct21)));
			Class56.smethod_36(item2, 0.0);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00037218 File Offset: 0x00035418
		public static void smethod_18(int int_6)
		{
			ValueTuple<double, double> valueTuple = Class56.smethod_16(int_6, 3.0, 1.2);
			double item = valueTuple.Item1;
			double item2 = valueTuple.Item2;
			Class56.Struct21 @struct = new Class56.Struct21
			{
				uint_0 = 0U,
				struct22_0 = new Class56.Struct22
				{
					struct23_0 = new Class56.Struct23
					{
						uint_1 = 2U
					}
				}
			};
			Class56.SendInput(1U, new Class56.Struct21[] { @struct }, Marshal.SizeOf(typeof(Class56.Struct21)));
			Class56.smethod_36(item, 0.0);
			Class56.Struct21 struct2 = new Class56.Struct21
			{
				uint_0 = 0U,
				struct22_0 = new Class56.Struct22
				{
					struct23_0 = new Class56.Struct23
					{
						uint_1 = 4U
					}
				}
			};
			Class56.SendInput(1U, new Class56.Struct21[] { struct2 }, Marshal.SizeOf(typeof(Class56.Struct21)));
			Class56.smethod_36(item2, 0.0);
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00037218 File Offset: 0x00035418
		public static void smethod_19(int int_6)
		{
			ValueTuple<double, double> valueTuple = Class56.smethod_16(int_6, 3.0, 1.2);
			double item = valueTuple.Item1;
			double item2 = valueTuple.Item2;
			Class56.Struct21 @struct = new Class56.Struct21
			{
				uint_0 = 0U,
				struct22_0 = new Class56.Struct22
				{
					struct23_0 = new Class56.Struct23
					{
						uint_1 = 2U
					}
				}
			};
			Class56.SendInput(1U, new Class56.Struct21[] { @struct }, Marshal.SizeOf(typeof(Class56.Struct21)));
			Class56.smethod_36(item, 0.0);
			Class56.Struct21 struct2 = new Class56.Struct21
			{
				uint_0 = 0U,
				struct22_0 = new Class56.Struct22
				{
					struct23_0 = new Class56.Struct23
					{
						uint_1 = 4U
					}
				}
			};
			Class56.SendInput(1U, new Class56.Struct21[] { struct2 }, Marshal.SizeOf(typeof(Class56.Struct21)));
			Class56.smethod_36(item2, 0.0);
		}

		// Token: 0x06000433 RID: 1075
		[DllImport("user32.dll")]
		private static extern bool ClientToScreen(IntPtr intptr_0, ref Point point_0);

		// Token: 0x06000434 RID: 1076 RVA: 0x0003732C File Offset: 0x0003552C
		private static void smethod_20(Point point_0, Class76 class76_0, int int_6 = 100)
		{
			Point point = Class56.smethod_2(class76_0.Handle);
			Point point2 = new Point(point_0.X, point_0.Y);
			Class56.ClientToScreen(class76_0.Handle, ref point);
			Class56.ClientToScreen(class76_0.Handle, ref point2);
			int num = 180 + Class56.random_0.Next(0, 40);
			double num2 = (double)(point.X + point2.X) / 2.0 + (double)Class56.random_0.Next(-20, 20);
			double num3 = (double)(point.Y + point2.Y) / 2.0 + (double)Class56.random_0.Next(-20, 20);
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			for (;;)
			{
				double num4 = stopwatch.Elapsed.TotalMilliseconds / (double)num;
				if (num4 >= 1.0)
				{
					break;
				}
				num4 = num4 * num4 * num4 * (num4 * (num4 * 6.0 - 15.0) + 10.0);
				double num5 = (1.0 - num4) * (1.0 - num4) * (double)point.X + 2.0 * (1.0 - num4) * num4 * num2 + num4 * num4 * (double)point2.X;
				double num6 = (1.0 - num4) * (1.0 - num4) * (double)point.Y + 2.0 * (1.0 - num4) * num4 * num3 + num4 * num4 * (double)point2.Y;
				Class56.smethod_4(new Point((int)Math.Round(num5), (int)Math.Round(num6)));
				Thread.SpinWait(int_6);
			}
			Class56.smethod_4(point2);
			stopwatch.Stop();
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00037510 File Offset: 0x00035710
		public static void smethod_21(int int_6, Point point_0, Class76 class76_0, int int_7 = 100)
		{
			Point point = Class56.smethod_2(class76_0.Handle);
			Point point2 = new Point(point_0.X, point_0.Y);
			Class56.ClientToScreen(class76_0.Handle, ref point);
			Class56.ClientToScreen(class76_0.Handle, ref point2);
			int num = Class56.smethod_22(int_6) + Class56.random_0.Next(0, 40);
			double num2 = (double)(point.X + point2.X) / 2.0 + (double)Class56.random_0.Next(-20, 20);
			double num3 = (double)(point.Y + point2.Y) / 2.0 + (double)Class56.random_0.Next(-20, 20);
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			for (;;)
			{
				double num4 = stopwatch.Elapsed.TotalMilliseconds / (double)num;
				if (num4 >= 1.0)
				{
					break;
				}
				num4 = num4 * num4 * num4 * (num4 * (num4 * 6.0 - 15.0) + 10.0);
				double num5 = (1.0 - num4) * (1.0 - num4) * (double)point.X + 2.0 * (1.0 - num4) * num4 * num2 + num4 * num4 * (double)point2.X;
				double num6 = (1.0 - num4) * (1.0 - num4) * (double)point.Y + 2.0 * (1.0 - num4) * num4 * num3 + num4 * num4 * (double)point2.Y;
				Class56.smethod_4(new Point((int)Math.Round(num5), (int)Math.Round(num6)));
				Thread.SpinWait(int_7);
			}
			Class56.smethod_4(point2);
			stopwatch.Stop();
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x000376F4 File Offset: 0x000358F4
		private static int smethod_22(int int_6)
		{
			int num = Math.Min(100, Math.Max(0, int_6));
			return (400 * (100 - num) + 20 * num + 50) / 100;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00037728 File Offset: 0x00035928
		public static void smethod_23(int int_6, int int_7, int int_8 = 0, int int_9 = 0)
		{
			Class56.autoHotkeyEngine_0.ExecRaw("CoordMode, Mouse, Client");
			Class56.autoHotkeyEngine_0.ExecRaw(string.Format("MouseMove, {0}, {1}, {2}", int_6 + int_8 / 2, int_7 + int_9 / 2, Class56.int_1));
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00037778 File Offset: 0x00035978
		public static void smethod_24(int int_6 = -1, int int_7 = -1, int int_8 = 0, int int_9 = 0)
		{
			if (int_6 > -1 && int_7 > -1)
			{
				Class56.autoHotkeyEngine_0.ExecRaw("CoordMode, Mouse, Client");
				Class56.autoHotkeyEngine_0.ExecRaw("MouseMove, " + (int_6 + int_8 / 2).ToString() + ", " + (int_7 + int_9 / 2).ToString());
				Class56.smethod_36(40.0, 150.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton down}");
				Class56.smethod_36(60.0, 90.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton up}");
				Class56.smethod_36(60.0, 90.0);
				return;
			}
			Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton down}");
			Class56.smethod_36(40.0, 70.0);
			Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton up}");
			Class56.smethod_36(15.0, 30.0);
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00037888 File Offset: 0x00035A88
		public static void smethod_25(Rectangle rectangle_0, Class76 class76_0, bool bool_0 = true)
		{
			Point point = new Point
			{
				X = rectangle_0.X,
				Y = rectangle_0.Y
			};
			if (point.X >= 0 && point.Y >= 0)
			{
				point.X += rectangle_0.Width / 2;
				point.Y += rectangle_0.Height / 2;
				if (bool_0)
				{
					int num = rectangle_0.Width / 3;
					point.X += Class56.random_0.Next(-num, num + 1);
					num = rectangle_0.Height / 3;
					point.Y += Class56.random_0.Next(-num, num + 1);
				}
				Class56.smethod_20(point, class76_0, 100);
				Class56.smethod_36(30.0, 80.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton down}");
				Class56.smethod_36(40.0, 70.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton up}");
				Class56.smethod_36(15.0, 30.0);
				return;
			}
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000379C4 File Offset: 0x00035BC4
		public static void smethod_26(Rect rect_0, Class76 class76_0, bool bool_0 = true)
		{
			Point point = new Point
			{
				X = rect_0.X,
				Y = rect_0.Y
			};
			if (point.X >= 0 && point.Y >= 0)
			{
				point.X += rect_0.Width / 2;
				point.Y += rect_0.Height / 2;
				if (bool_0)
				{
					int num = rect_0.Width / 3;
					point.X += Class56.random_0.Next(-num, num + 1);
					num = rect_0.Height / 3;
					point.Y += Class56.random_0.Next(-num, num + 1);
				}
				Class56.smethod_20(point, class76_0, 100);
				Class56.smethod_36(30.0, 80.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton down}");
				Class56.smethod_36(40.0, 70.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton up}");
				Class56.smethod_36(15.0, 30.0);
				return;
			}
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00037AF8 File Offset: 0x00035CF8
		public static void smethod_27(Point point_0, Size size_0, Class76 class76_0, bool bool_0 = true)
		{
			if (point_0.X >= 0 && point_0.Y >= 0)
			{
				point_0.X += size_0.Width / 2;
				point_0.Y += size_0.Height / 2;
				if (bool_0)
				{
					int num = size_0.Width / 3;
					point_0.X += Class56.random_0.Next(-num, num + 1);
					num = size_0.Height / 3;
					point_0.Y += Class56.random_0.Next(-num, num + 1);
				}
				Class56.smethod_20(point_0, class76_0, 100);
				Class56.smethod_36(30.0, 80.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton down}");
				Class56.smethod_36(40.0, 70.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton up}");
				Class56.smethod_36(15.0, 30.0);
				return;
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00037C0C File Offset: 0x00035E0C
		public static void smethod_28(Point point_0, Class76 class76_0)
		{
			if (point_0.X >= 0 && point_0.Y >= 0)
			{
				Class56.smethod_20(point_0, class76_0, 100);
				Class56.smethod_36(30.0, 80.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton down}");
				Class56.smethod_36(40.0, 70.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{LButton up}");
				Class56.smethod_36(15.0, 30.0);
				return;
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00037C9C File Offset: 0x00035E9C
		public static void smethod_29()
		{
			Class56.autoHotkeyEngine_0.ExecRaw("SendInput {LButton down}");
			Class56.smethod_36(20.0, 0.0);
			Class56.autoHotkeyEngine_0.ExecRaw("SendInput {LButton up}");
			Class56.smethod_36(20.0, 0.0);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00037CF8 File Offset: 0x00035EF8
		public static void smethod_30(int int_6 = -1, int int_7 = -1, int int_8 = 0, int int_9 = 0)
		{
			if (int_6 > -1 && int_7 > -1)
			{
				Class56.autoHotkeyEngine_0.ExecRaw("CoordMode, Mouse, Client");
				Class56.autoHotkeyEngine_0.ExecRaw("MouseMove, " + (int_6 + int_8 / 2).ToString() + ", " + (int_7 + int_9 / 2).ToString());
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {LButton down}");
				Class56.smethod_36(40.0 + Class56.random_0.NextDouble() * 10.0, 0.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {LButton up}");
				Class56.smethod_36(10.0 + Class56.random_0.NextDouble() * 10.0, 0.0);
				return;
			}
			Class56.autoHotkeyEngine_0.ExecRaw("SendInput {LButton down}");
			Class56.autoHotkeyEngine_0.ExecRaw("SendInput {LButton up}");
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0000508D File Offset: 0x0000328D
		public static void smethod_31()
		{
			if (!Class56.smethod_1(Keys.LButton))
			{
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {LButton down}");
			}
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x000050A6 File Offset: 0x000032A6
		public static void smethod_32()
		{
			if (Class56.smethod_1(Keys.LButton))
			{
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {LButton up}");
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00037DEC File Offset: 0x00035FEC
		public static void smethod_33(Point point_0, Class76 class76_0)
		{
			if (point_0.X >= 0 && point_0.Y >= 0)
			{
				Class56.smethod_20(point_0, class76_0, 100);
				Class56.smethod_36(30.0, 80.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{RButton down}");
				Class56.smethod_36(40.0, 70.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{RButton up}");
				Class56.smethod_36(15.0, 30.0);
				return;
			}
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00037E7C File Offset: 0x0003607C
		public static void smethod_34(int int_6 = -1, int int_7 = -1, int int_8 = 0, int int_9 = 0)
		{
			if (int_6 > -1 && int_7 > -1)
			{
				Class56.autoHotkeyEngine_0.ExecRaw("CoordMode, Mouse, Client");
				Class56.autoHotkeyEngine_0.ExecRaw("MouseMove, " + (int_6 + int_8 / 2).ToString() + ", " + (int_7 + int_9 / 2).ToString());
				Class56.smethod_36(30.0, 80.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{RButton down}");
				Class56.smethod_36(40.0, 70.0);
				Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{RButton up}");
				Class56.smethod_36(15.0, 30.0);
				return;
			}
			Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{RButton down}");
			Class56.smethod_36(40.0, 70.0);
			Class56.autoHotkeyEngine_0.ExecRaw("SendInput {Blind}{RButton up}");
			Class56.smethod_36(15.0, 30.0);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00037F8C File Offset: 0x0003618C
		public static void smethod_35(Class76 class76_0, int int_6 = -1, int int_7 = -1, int int_8 = 0, int int_9 = 0)
		{
			if (int_6 > -1 && int_7 > -1)
			{
				IntPtr intPtr = (IntPtr)((int_7 + int_8 / 2 << 16) | (int_6 + int_9 / 2));
				Class56.PostMessage(class76_0.Handle, 6U, IntPtr.Zero, IntPtr.Zero);
				Class56.PostMessage(class76_0.Handle, 513U, IntPtr.Zero, intPtr);
				Class56.PostMessage(class76_0.Handle, 514U, IntPtr.Zero, intPtr);
				return;
			}
			Class56.PostMessage(class76_0.Handle, 513U, IntPtr.Zero, IntPtr.Zero);
			Class56.PostMessage(class76_0.Handle, 514U, IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00038034 File Offset: 0x00036234
		private static void smethod_36(double double_0, double double_1 = 0.0)
		{
			double num3;
			if (double_1 > 0.0)
			{
				double num = Math.Min(double_0, double_1);
				double num2 = Math.Max(double_0, double_1);
				num3 = num + Class56.random_0.NextDouble() * (num2 - num);
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

		// Token: 0x040004EE RID: 1262
		private const int int_0 = 0;

		// Token: 0x040004EF RID: 1263
		private const uint uint_0 = 1U;

		// Token: 0x040004F0 RID: 1264
		private const uint uint_1 = 32768U;

		// Token: 0x040004F1 RID: 1265
		private const uint uint_2 = 2U;

		// Token: 0x040004F2 RID: 1266
		private const uint uint_3 = 4U;

		// Token: 0x040004F3 RID: 1267
		private static readonly AutoHotkeyEngine autoHotkeyEngine_0 = new AutoHotkeyEngine();

		// Token: 0x040004F4 RID: 1268
		private static readonly Random random_0 = Class56.smethod_0();

		// Token: 0x040004F5 RID: 1269
		public static int int_1 = 1;

		// Token: 0x040004F6 RID: 1270
		private const int int_2 = 28;

		// Token: 0x040004F7 RID: 1271
		private const int int_3 = 28;

		// Token: 0x040004F8 RID: 1272
		private const int int_4 = 100;

		// Token: 0x040004F9 RID: 1273
		private static int int_5;

		// Token: 0x0200008E RID: 142
		private struct Struct21
		{
			// Token: 0x040004FA RID: 1274
			public uint uint_0;

			// Token: 0x040004FB RID: 1275
			public Class56.Struct22 struct22_0;
		}

		// Token: 0x0200008F RID: 143
		[StructLayout(LayoutKind.Explicit)]
		private struct Struct22
		{
			// Token: 0x040004FC RID: 1276
			[FieldOffset(0)]
			public Class56.Struct23 struct23_0;
		}

		// Token: 0x02000090 RID: 144
		private struct Struct23
		{
			// Token: 0x040004FD RID: 1277
			public int int_0;

			// Token: 0x040004FE RID: 1278
			public int int_1;

			// Token: 0x040004FF RID: 1279
			public uint uint_0;

			// Token: 0x04000500 RID: 1280
			public uint uint_1;

			// Token: 0x04000501 RID: 1281
			public uint uint_2;

			// Token: 0x04000502 RID: 1282
			public IntPtr intptr_0;
		}

		// Token: 0x02000091 RID: 145
		private struct Struct24
		{
			// Token: 0x04000503 RID: 1283
			public int int_0;

			// Token: 0x04000504 RID: 1284
			public int int_1;
		}
	}
}
