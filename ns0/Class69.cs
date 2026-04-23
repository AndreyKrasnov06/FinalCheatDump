using System;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x020000A0 RID: 160
	internal class Class69 : MaskedTextBox
	{
		// Token: 0x0600048C RID: 1164 RVA: 0x00039F84 File Offset: 0x00038184
		protected override void WndProc(ref Message message_0)
		{
			if (message_0.Msg == 770)
			{
				if (Clipboard.ContainsText())
				{
					string text = Clipboard.GetText();
					text = text.Replace(" ", "");
					this.SelectedText = text;
				}
				return;
			}
			base.WndProc(ref message_0);
		}
	}
}
