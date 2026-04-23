using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using ns0;

namespace ns1
{
	// Token: 0x02000054 RID: 84
	internal partial class FormActivate : GForm0
	{
		// Token: 0x060002A0 RID: 672 RVA: 0x000241CC File Offset: 0x000223CC
		public FormActivate()
		{
			FormActivate.httpClient_0.BaseAddress = new Uri("https://antia.space/majestic/");
			FormActivate.httpClient_0.DefaultRequestHeaders.Remove(Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_0, false)));
			FormActivate.httpClient_0.DefaultRequestHeaders.Add(Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_0, false)), Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_1, false)));
			FormActivate.httpClient_0.Timeout = TimeSpan.FromSeconds(5.0);
			this.InitializeComponent();
			this.label9.Text = Form1.ID;
			this.linkLabel1.GotFocus += this.linkLabel2_GotFocus;
			this.linkLabel2.GotFocus += this.linkLabel2_GotFocus;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000410F File Offset: 0x0000230F
		private void linkLabel2_GotFocus(object sender, EventArgs e)
		{
			base.ActiveControl = null;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00004312 File Offset: 0x00002512
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://funpay.com/users/1819974/");
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000431F File Offset: 0x0000251F
		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://discord.com/invite/fjjqNahEbH");
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000432C File Offset: 0x0000252C
		private void maskedTextBox1_Click(object sender, EventArgs e)
		{
			if (this.maskedTextBox1.Text == "     -     -     -     -")
			{
				this.maskedTextBox1.Text = "";
			}
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00004355 File Offset: 0x00002555
		private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar) && char.IsLower(e.KeyChar))
			{
				e.KeyChar = char.ToUpper(e.KeyChar);
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x000242B0 File Offset: 0x000224B0
		private void label2_Click(object sender, EventArgs e)
		{
			base.ActiveControl = null;
			Clipboard.SetText(Form1.ID);
			this.label9.ForeColor = Color.FromArgb(50, 190, 131);
			this.label9.Text = "Cкопировано";
			this.timer_0.Start();
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00004382 File Offset: 0x00002582
		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.label9.ForeColor = Color.FromArgb(243, 243, 243);
			this.label9.Text = Form1.ID;
			this.timer_0.Stop();
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00024308 File Offset: 0x00022508
		private async void maskedTextBox1_TextChanged(object sender, EventArgs e)
		{
			if (this.maskedTextBox1.MaskFull)
			{
				base.ActiveControl = null;
				if (!Regex.IsMatch(this.maskedTextBox1.Text, "^[A-Z0-9-]+$"))
				{
					new FormMessage("Ключ содержит недопустимые символы.");
				}
				else
				{
					try
					{
						Class61 @class = new Class61
						{
							ID = Form1.ID,
							Key = this.maskedTextBox1.Text
						};
						byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@class));
						@class.method_0();
						GClass2.smethod_1(ref bytes);
						byte[] array = Class5.smethod_0(ref bytes);
						ByteArrayContent byteArrayContent = new ByteArrayContent(GClass2.smethod_3(ref array, true));
						byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
						HttpResponseMessage httpResponseMessage = await FormActivate.httpClient_0.PostAsync("activate", byteArrayContent);
						using (HttpResponseMessage httpResponseMessage2 = httpResponseMessage)
						{
							byteArrayContent.Dispose();
							httpResponseMessage2.EnsureSuccessStatusCode();
							byte[] array2 = await httpResponseMessage2.Content.ReadAsByteArrayAsync();
							GClass2.smethod_1(ref array2);
							byte[] array3 = Class5.smethod_1(ref array2);
							byte[] array4;
							byte[] array5;
							byte[] array6;
							JsonConvert.DeserializeObject<Class62>(Encoding.UTF8.GetString(GClass2.smethod_3(ref array3, true))).method_0(out array4, out array5, out array6);
							if (Encoding.UTF8.GetString(GClass2.smethod_3(ref array4, true)) == "error")
							{
								new FormMessage(Encoding.UTF8.GetString(GClass2.smethod_3(ref array6, true)));
								GClass2.smethod_6(ref array6);
							}
							else
							{
								Form1.Main.method_0(int.Parse(Encoding.UTF8.GetString(GClass2.smethod_3(ref array5, true))), true);
								this.maskedTextBox1.Text = "";
								Class43.smethod_4();
							}
						}
						HttpResponseMessage httpResponseMessage2 = null;
						byteArrayContent = null;
					}
					catch (Exception ex)
					{
						new FormMessage(ex);
					}
				}
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x000043BE File Offset: 0x000025BE
		private void label_Reset_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("АКТИВАЦИЯ СБРОСИТСЯ И ПРОЦЕСС БОТА ЗАКРОЕТСЯ.\nПРОДОЛЖИТЬ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				Class43.smethod_5();
			}
		}

		// Token: 0x0400033C RID: 828
		private static readonly HttpClient httpClient_0 = new HttpClient();

		// Token: 0x0400033D RID: 829
		private const string string_0 = "https://antia.space/majestic/";
	}
}
