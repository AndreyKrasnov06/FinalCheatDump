using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using Microsoft.Win32;

namespace ns0
{
	// Token: 0x02000036 RID: 54
	internal static class Class13
	{
		// Token: 0x060001C5 RID: 453 RVA: 0x0001715C File Offset: 0x0001535C
		public static int smethod_0(bool bool_0)
		{
			if (!Class13.smethod_1())
			{
				Class13.smethod_2();
				return 0;
			}
			try
			{
				foreach (string text in Class13.string_0)
				{
					Class13.smethod_3(text + "\\ScriptBlockLogging", "EnableScriptBlockLogging", (bool_0 > false) ? 1 : 0);
					Class13.smethod_3(text + "\\ScriptBlockLogging", "EnableScriptBlockInvocationLogging", (bool_0 > false) ? 1 : 0);
					Class13.smethod_3(text + "\\ModuleLogging", "EnableModuleLogging", (bool_0 > false) ? 1 : 0);
					if (!bool_0)
					{
						Class13.smethod_5(text + "\\ModuleLogging\\ModuleNames");
					}
					else
					{
						Class13.smethod_6(text + "\\ModuleLogging\\ModuleNames", new Action<RegistryKey>(Class13.Class14.class14_0.method_0));
					}
					Class13.smethod_3(text + "\\Transcription", "EnableTranscripting", (bool_0 > false) ? 1 : 0);
					if (!bool_0)
					{
						Class13.smethod_4(text + "\\Transcription", "OutputDirectory");
						Class13.smethod_4(text + "\\Transcription", "IncludeInvocationHeader");
					}
				}
			}
			catch
			{
			}
			return 0;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00016F08 File Offset: 0x00015108
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

		// Token: 0x060001C7 RID: 455 RVA: 0x00017284 File Offset: 0x00015484
		private static void smethod_2()
		{
			try
			{
				string fileName = Process.GetCurrentProcess().MainModule.FileName;
				Process.Start(new ProcessStartInfo
				{
					FileName = fileName,
					UseShellExecute = true,
					Verb = "runas",
					WindowStyle = ProcessWindowStyle.Hidden
				});
			}
			catch
			{
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000172E4 File Offset: 0x000154E4
		private static void smethod_3(string string_1, string string_2, int int_0)
		{
			Class13.Class15 @class = new Class13.Class15();
			@class.string_0 = string_2;
			@class.int_0 = int_0;
			try
			{
				Class13.smethod_6(string_1, new Action<RegistryKey>(@class.method_0));
			}
			catch
			{
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0001732C File Offset: 0x0001552C
		private static void smethod_4(string string_1, string string_2)
		{
			try
			{
				using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
				{
					using (RegistryKey registryKey2 = registryKey.OpenSubKey(string_1, true))
					{
						if (registryKey2 != null && registryKey2.GetValue(string_2) != null)
						{
							registryKey2.DeleteValue(string_2, false);
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000173AC File Offset: 0x000155AC
		private static void smethod_5(string string_1)
		{
			try
			{
				using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
				{
					registryKey.DeleteSubKeyTree(string_1, false);
				}
			}
			catch
			{
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00017400 File Offset: 0x00015600
		private static void smethod_6(string string_1, Action<RegistryKey> action_0)
		{
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.CreateSubKey(string_1, true))
				{
					action_0(registryKey2);
				}
			}
		}

		// Token: 0x04000209 RID: 521
		private static readonly string[] string_0 = new string[] { "SOFTWARE\\Policies\\Microsoft\\Windows\\PowerShell", "SOFTWARE\\Policies\\Microsoft\\PowerShellCore" };

		// Token: 0x02000037 RID: 55
		[CompilerGenerated]
		[Serializable]
		private sealed class Class14
		{
			// Token: 0x060001CF RID: 463 RVA: 0x00003D0C File Offset: 0x00001F0C
			internal void method_0(RegistryKey registryKey_0)
			{
				registryKey_0.SetValue("*", "*", RegistryValueKind.String);
			}

			// Token: 0x0400020A RID: 522
			public static readonly Class13.Class14 class14_0 = new Class13.Class14();

			// Token: 0x0400020B RID: 523
			public static Action<RegistryKey> action_0;
		}

		// Token: 0x02000038 RID: 56
		[CompilerGenerated]
		private sealed class Class15
		{
			// Token: 0x060001D1 RID: 465 RVA: 0x00003D1F File Offset: 0x00001F1F
			internal void method_0(RegistryKey registryKey_0)
			{
				registryKey_0.SetValue(this.string_0, this.int_0, RegistryValueKind.DWord);
			}

			// Token: 0x0400020C RID: 524
			public string string_0;

			// Token: 0x0400020D RID: 525
			public int int_0;
		}
	}
}
