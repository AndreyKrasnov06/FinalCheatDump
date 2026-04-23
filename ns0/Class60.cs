using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x02000095 RID: 149
	internal static class Class60
	{
		// Token: 0x06000452 RID: 1106 RVA: 0x0003851C File Offset: 0x0003671C
		[STAThread]
		public static void smethod_0(string[] string_0)
		{
			if (string_0.Length == 4)
			{
				Task.Run(new Action(Class10.smethod_0));
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				CursorHelper.DisableAppStarting();
				Class1.smethod_0();
				try
				{
					Application.Run(new Form1(string_0[0], int.Parse(string_0[1]), string_0[2], string_0[3]));
				}
				finally
				{
					CursorHelper.RestoreAppStarting();
					Class1.smethod_1();
				}
			}
		}
	}
}
