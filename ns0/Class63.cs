using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x02000098 RID: 152
	internal class Class63 : Panel
	{
		// Token: 0x0600045D RID: 1117
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5);

		// Token: 0x0600045E RID: 1118
		[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
		private static extern bool DeleteObject(IntPtr intptr_0);

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x000051D2 File Offset: 0x000033D2
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x000051DA File Offset: 0x000033DA
		public Size Radius { get; set; } = new Size(0, 0);

		// Token: 0x06000461 RID: 1121 RVA: 0x000051E3 File Offset: 0x000033E3
		public Class63()
		{
			this.DoubleBuffered = true;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000385B8 File Offset: 0x000367B8
		protected override void OnPaint(PaintEventArgs paintEventArgs_0)
		{
			base.OnPaint(paintEventArgs_0);
			IntPtr intPtr = Class63.CreateRoundRectRgn(-10, 0, base.Width, base.Height, this.Radius.Width, this.Radius.Height);
			base.Region = Region.FromHrgn(intPtr);
			Class63.DeleteObject(intPtr);
		}

		// Token: 0x0400051A RID: 1306
		[CompilerGenerated]
		private Size size_0;
	}
}
