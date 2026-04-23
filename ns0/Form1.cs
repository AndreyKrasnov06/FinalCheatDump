using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using ns1;

namespace ns0
{
	// Token: 0x0200004E RID: 78
	public partial class Form1 : Form
	{
		// Token: 0x06000259 RID: 601
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool IsIconic(IntPtr intptr_0);

		// Token: 0x0600025A RID: 602
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int ShowWindow(IntPtr intptr_0, int int_0);

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600025B RID: 603 RVA: 0x000040F1 File Offset: 0x000022F1
		// (set) Token: 0x0600025C RID: 604 RVA: 0x000040F8 File Offset: 0x000022F8
		public static Form1 Main { get; private set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600025D RID: 605 RVA: 0x00004100 File Offset: 0x00002300
		// (set) Token: 0x0600025E RID: 606 RVA: 0x00004107 File Offset: 0x00002307
		public static string ID { get; private set; }

		// Token: 0x0600025F RID: 607 RVA: 0x0001EDB4 File Offset: 0x0001CFB4
		public Form1(string string_6, int int_0, string string_7, string string_8)
		{
			base.Opacity = 0.0;
			base.Load += this.Form1_Load;
			this.bool_7 = true;
			Form1.ID = string_6;
			Form1.Main = this;
			Form1.byte_0 = Convert.FromBase64String(string_7);
			GClass2.smethod_1(ref Form1.byte_0);
			Form1.byte_1 = Convert.FromBase64String(string_8);
			GClass2.smethod_1(ref Form1.byte_1);
			this.InitializeComponent();
			base.FormClosing += this.Form1_FormClosing;
			this.formActivate_0 = new FormActivate();
			this.formVPN_0 = new FormVPN();
			this.labelTime.ReadOnly = true;
			this.labelTime.BorderStyle = BorderStyle.None;
			this.labelTime.Cursor = Cursors.Default;
			this.labelTime.TabStop = false;
			this.labelTime.GotFocus += this.labelTime_GotFocus;
			this.method_0(int_0, false);
			if (!this.bool_9)
			{
				this.timer_2 = new global::System.Windows.Forms.Timer
				{
					Interval = 60000
				};
				this.timer_2.Tick += this.timer_2_Tick;
				this.timer_2.Start();
			}
			this.buttonMinimized.GotFocus += this.buttonLumberjack_Enter;
			this.buttonClose.GotFocus += this.buttonLumberjack_Enter;
			this.class63_0.Size = new Size(30, 20);
			this.class63_0.Location = new Point(0, this.buttonMiner.Top + (this.buttonMiner.Height / 2 - this.class63_0.Height / 2) + 4);
			this.class63_0.BackColor = Color.FromArgb(232, 28, 90);
			this.class63_0.Radius = new Size(8, 10);
			this.panelMenu.Controls.Add(this.class63_0);
			this.class63_0.BringToFront();
			this.formFishing_0 = new FormFishing();
			this.formLumberjack_0 = new FormLumberjack();
			this.formMiner_0 = new FormMiner();
			this.formFarm_0 = new FormFarm();
			this.formMushroomer_0 = new FormMushroomer();
			this.formGym_0 = new FormGym();
			this.formSewing_0 = new FormSewing();
			this.formTaxi_0 = new FormTaxi();
			this.formThiefAuto_0 = new FormThiefAuto();
			this.formAntiAfk_0 = new FormAntiAfk();
			this.formDemorgan_0 = new FormDemorgan();
			this.formBuilder_0 = new FormBuilder();
			this.timer_0.Elapsed += this.timer_0_Elapsed;
			this.timer_0.Elapsed += this.timer_0_Elapsed_1;
			Class39.smethod_0(new EventHandler<GEventArgs0>(this.method_3));
			base.Show();
			Thread.Sleep(200);
			base.Activate();
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0001F0E4 File Offset: 0x0001D2E4
		private async void Form1_Load(object sender, EventArgs e)
		{
			TaskAwaiter<bool> taskAwaiter = Class43.smethod_4().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<bool> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<bool>);
			}
			if (taskAwaiter.GetResult())
			{
				this.string_0 = "FormNews";
				this.method_4(this.method_7(), this.method_6());
				if (this.keys_0 == Keys.F9 || this.keys_0 == Keys.F4 || this.keys_0 == Keys.F5 || this.keys_0 == Keys.Home || this.keys_0 == Keys.Delete || this.keys_0 == Keys.End || this.keys_0 == Keys.Next || this.keys_0 == Keys.Prior || this.keys_0 == Keys.Insert)
				{
					this.keys_0 = Keys.D2;
					this.genum0_0 = GEnum0.flag_2;
				}
				if (this.keys_1 == Keys.F10 || this.keys_1 == Keys.F4 || this.keys_1 == Keys.F5 || this.keys_1 == Keys.Home || this.keys_1 == Keys.Delete || this.keys_1 == Keys.End || this.keys_1 == Keys.Next || this.keys_1 == Keys.Prior || this.keys_1 == Keys.Insert)
				{
					this.keys_1 = Keys.D3;
					this.genum0_1 = GEnum0.flag_2;
				}
				if (this.keys_0 == Keys.None || this.keys_1 == Keys.None)
				{
					this.keys_0 = Keys.D2;
					this.genum0_0 = GEnum0.flag_2;
					this.keys_1 = Keys.D3;
					this.genum0_1 = GEnum0.flag_2;
				}
				this.method_10(this.keys_0, out this.string_1);
				this.method_10(this.keys_1, out this.string_2);
				this.label_HotKey0.Text = Form1.smethod_3(this.genum0_0, this.string_1);
				this.label_HotKey1.Text = Form1.smethod_3(this.genum0_1, this.string_2);
				Class39.smethod_2(base.Handle, 854640, this.genum0_0, this.keys_0);
				Class39.smethod_2(base.Handle, 854641, this.genum0_1, this.keys_1);
				if (this.genum0_0 != GEnum0.flag_4)
				{
					this.pictureBox4.Width = 99;
					this.pictureBox4.Left = 636 - this.pictureBox4.Width;
					this.pictureBox4.Image = Class2.hotkey_long;
					this.label_HotKey0.Width = 95;
					this.label_HotKey0.Left = 634 - this.label_HotKey0.Width;
					this.label1.Left = 473 - this.label_HotKey0.Width;
				}
				else
				{
					this.pictureBox4.Width = 49;
					this.pictureBox4.Left = 587;
					this.pictureBox4.Image = Class2.hotkey;
					this.label_HotKey0.Width = 45;
					this.label_HotKey0.Left = 589;
					this.label1.Left = 428;
				}
				if (this.genum0_1 != GEnum0.flag_4)
				{
					this.pictureBox3.Width = 99;
					this.pictureBox3.Left = 636 - this.pictureBox3.Width;
					this.pictureBox3.Image = Class2.hotkey_long;
					this.label_HotKey1.Width = 95;
					this.label_HotKey1.Left = 634 - this.label_HotKey1.Width;
					this.label2.Left = 473 - this.label_HotKey1.Width;
				}
				else
				{
					this.pictureBox3.Width = 49;
					this.pictureBox3.Left = 587;
					this.pictureBox3.Image = Class2.hotkey;
					this.label_HotKey1.Width = 45;
					this.label_HotKey1.Left = 589;
					this.label2.Left = 428;
				}
				base.Opacity = 1.0;
			}
			else
			{
				base.Close();
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000410F File Offset: 0x0000230F
		private void buttonLumberjack_Enter(object sender, EventArgs e)
		{
			base.ActiveControl = null;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0001F11C File Offset: 0x0001D31C
		public void method_0(int int_0, bool bool_11 = false)
		{
			if (int_0 > 691200000)
			{
				if (bool_11)
				{
					this.timer_2.Stop();
				}
				this.bool_9 = true;
				this.labelTime.Text = "Lifetime";
			}
			else
			{
				this.dateTime_0 = DateTime.Now.AddSeconds((double)int_0);
				int num = int_0 / 86400;
				int_0 %= 86400;
				int num2 = int_0 / 3600;
				int_0 %= 3600;
				int num3 = int_0 / 60;
				this.labelTime.Text = string.Format("Осталось: {0} д. {1} ч. {2} м.", num, num2, num3);
			}
			if (bool_11)
			{
				this.labelTime.ForeColor = Color.FromArgb(232, 28, 90);
				this.timer_3 = new global::System.Windows.Forms.Timer
				{
					Interval = 2000
				};
				this.timer_3.Tick += this.timer_3_Tick;
				this.timer_3.Start();
			}
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0001F214 File Offset: 0x0001D414
		private void timer_2_Tick(object sender, EventArgs e)
		{
			TimeSpan timeSpan = this.dateTime_0 - DateTime.Now;
			if (timeSpan.TotalSeconds > 0.0)
			{
				this.method_1(timeSpan);
				return;
			}
			this.timer_2.Stop();
			this.labelTime.Text = "Время вышло!";
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00004118 File Offset: 0x00002318
		private void timer_3_Tick(object sender, EventArgs e)
		{
			this.labelTime.ForeColor = Color.FromArgb(140, 140, 140);
			this.timer_3.Stop();
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0001F268 File Offset: 0x0001D468
		private void method_1(TimeSpan timeSpan_0)
		{
			int num = (int)timeSpan_0.TotalDays;
			int hours = timeSpan_0.Hours;
			int minutes = timeSpan_0.Minutes;
			this.labelTime.Text = string.Format("{0} д. {1} ч. {2} м.", num, hours, minutes);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00004144 File Offset: 0x00002344
		private void method_2(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				e.IsInputKey = true;
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0001F2B8 File Offset: 0x0001D4B8
		private void method_3(object sender, GEventArgs0 e)
		{
			if (this.bool_7)
			{
				return;
			}
			bool flag = e.Key == this.keys_0 && e.Modifiers == this.genum0_0;
			bool flag2 = e.Key == this.keys_1 && e.Modifiers == this.genum0_1;
			if (!this.bool_1 && flag)
			{
				this.bool_1 = true;
				base.ActiveControl = null;
				if (!Form1.bool_8)
				{
					Form1.Class30 @class = new Form1.Class30();
					this.method_9(true);
					this.timer_0.Start();
					base.Opacity = 0.0;
					try
					{
						@class.class76_0 = new Class76("GTA5");
						if (!Form1.string_5.Contains(@class.class76_0.Resolution))
						{
							new FormMessage("Разрешение игры " + @class.class76_0.Resolution + " не поддерживается! В настройках игры измените разрешение на одно из: 2560x1440, 1920x1200, 1920x1080, 1680x1050, 1600x900, 1440x900, 1366x768, 1280x1024, 1280x800, 1280x720.");
							return;
						}
						@class.class76_0.method_2();
					}
					catch (Exception)
					{
						new FormMessage("Окно игры не найдено.");
						return;
					}
					if (this.string_0 != "FormFishing")
					{
						Class65.smethod_0(this.string_0, this.genum0_0, this.keys_0, this.genum0_1, this.keys_1);
					}
					Task.Run(new Func<Task>(this.method_12)).Wait();
					Form1.cancellationTokenSource_0 = new CancellationTokenSource();
					Form1.cancellationToken_0 = Form1.cancellationTokenSource_0.Token;
					try
					{
						string text = this.string_0;
						if (text != null)
						{
							switch (text.Length)
							{
							case 7:
								if (text == "FormGym")
								{
									Task.Run(new Action(@class.method_5));
									Form1.bool_8 = true;
								}
								break;
							case 8:
							{
								char c = text[4];
								if (c != 'F')
								{
									if (c == 'T')
									{
										if (text == "FormTaxi")
										{
											Task.Run(new Action(@class.method_7));
											Form1.bool_8 = true;
										}
									}
								}
								else if (text == "FormFarm")
								{
									Task.Run(new Action(@class.method_3));
									Form1.bool_8 = true;
								}
								break;
							}
							case 9:
								if (text == "FormMiner")
								{
									Task.Run(new Action(@class.method_2));
									Form1.bool_8 = true;
								}
								break;
							case 10:
								if (text == "FormSewing")
								{
									Task.Run(new Action(@class.method_6));
									Form1.bool_8 = true;
								}
								break;
							case 11:
							{
								char c = text[4];
								if (c != 'A')
								{
									if (c != 'B')
									{
										if (c == 'F')
										{
											if (text == "FormFishing")
											{
												Task.Run(new Action(@class.method_0));
												Form1.bool_8 = true;
											}
										}
									}
									else if (text == "FormBuilder")
									{
										Task.Run(new Action(@class.method_11));
										Form1.bool_8 = true;
									}
								}
								else if (text == "FormAntiAfk")
								{
									Task.Run(new Action(@class.method_9));
									Form1.bool_8 = true;
								}
								break;
							}
							case 12:
								if (text == "FormDemorgan")
								{
									Task.Run(new Action(@class.method_10));
									Form1.bool_8 = true;
								}
								break;
							case 13:
								if (text == "FormThiefAuto")
								{
									Task.Run(new Action(@class.method_8));
									Form1.bool_8 = true;
								}
								break;
							case 14:
							{
								char c = text[4];
								if (c != 'L')
								{
									if (c == 'M')
									{
										if (text == "FormMushroomer")
										{
											Task.Run(new Action(@class.method_4));
											Form1.bool_8 = true;
										}
									}
								}
								else if (text == "FormLumberjack")
								{
									Task.Run(new Action(@class.method_1));
									Form1.bool_8 = true;
								}
								break;
							}
							}
						}
						return;
					}
					catch (Exception)
					{
						return;
					}
				}
				Form1.cancellationTokenSource_0.Cancel();
				Form1.bool_8 = false;
				this.method_11();
				this.timer_0.Start();
				this.method_9(false);
				return;
			}
			if (!this.bool_1 && !this.bool_2 && flag2)
			{
				base.ActiveControl = null;
				this.bool_2 = true;
				if (Form1.bool_8)
				{
					Form1.cancellationTokenSource_0.Cancel();
					this.method_11();
					Form1.bool_8 = false;
					if (this.string_0 == "Taxi")
					{
						this.timer_0.Start();
						Thread.Sleep(1000);
					}
				}
				this.method_9(false);
				this.timer_0.Start();
				if (Form1.IsIconic(base.Handle))
				{
					Form1.ShowWindow(base.Handle, 9);
				}
				base.Opacity = 1.0;
				base.Show();
				base.Activate();
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00004157 File Offset: 0x00002357
		protected override void WndProc(ref Message message_0)
		{
			if (message_0.Msg == 786)
			{
				Class39.smethod_6(message_0.LParam);
			}
			base.WndProc(ref message_0);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0001F7E4 File Offset: 0x0001D9E4
		private void method_4(Button button_0, Form form_0)
		{
			Color color = Color.FromArgb(240, 240, 240);
			Color color2 = Color.FromArgb(140, 140, 140);
			Color color3 = Color.FromArgb(17, 17, 17);
			Color color4 = Color.FromArgb(25, 25, 25);
			foreach (Button button in new Button[]
			{
				this.buttonFishing, this.buttonMiner, this.buttonLumberjack, this.buttonFarm, this.buttonMushroomer, this.buttonGym, this.buttonSewing, this.buttonTaxi, this.buttonThiefAuto, this.buttonAntiAfk,
				this.buttonDemorgan, this.buttonBuilder, this.buttonActivate, this.buttonNews, this.buttonVPN
			})
			{
				button.Font = new Font("Verdana", 12.5f);
				button.ForeColor = color2;
				button.BackColor = color4;
			}
			this.buttonSetting.BackColor = Color.FromArgb(17, 17, 17);
			this.buttonSetting.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
			this.buttonSetting.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
			if (form_0 == this.formSettings_0)
			{
				this.class63_0.Hide();
			}
			else if (form_0 != this.formActivate_0)
			{
				this.class63_0.Show();
				this.class63_0.Location = new Point(0, button_0.Top + (button_0.Height / 2 - this.class63_0.Height / 2) + 4);
			}
			else
			{
				this.class63_0.Show();
				this.class63_0.Location = new Point(0, button_0.Top + (button_0.Height / 2 - this.class63_0.Height / 2) + 4);
			}
			button_0.ForeColor = color;
			button_0.BackColor = color3;
			this.panel2.Controls.Clear();
			this.panelContent.Controls.Clear();
			form_0.Dock = DockStyle.Fill;
			form_0.TopLevel = false;
			form_0.TopMost = true;
			if (form_0 == this.formFishing_0)
			{
				this.panelContent.Controls.Add(this.scrollHost_0);
				this.scrollHost_0.SetContent(form_0);
				this.panel2.Visible = false;
				this.panelContent.Visible = true;
			}
			else
			{
				if (form_0 != this.formSettings_0 && form_0 != this.formNews_0)
				{
					if (form_0 != this.formVPN_0)
					{
						this.panelContent.Controls.Add(form_0);
						this.panel2.Visible = false;
						this.panelContent.Visible = true;
						goto IL_02F1;
					}
				}
				this.panel2.Controls.Add(form_0);
				this.panelContent.Visible = false;
				this.panel2.Visible = true;
			}
			IL_02F1:
			if (button_0 == this.buttonSetting)
			{
				this.buttonSetting.BackColor = Color.FromArgb(232, 28, 90);
				this.buttonSetting.FlatAppearance.MouseDownBackColor = Color.FromArgb(232, 28, 90);
				this.buttonSetting.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 28, 90);
			}
			form_0.Show();
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00004178 File Offset: 0x00002378
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.bool_0 = true;
				this.point_0 = Cursor.Position;
				this.point_1 = base.Location;
			}
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0001FB48 File Offset: 0x0001DD48
		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.bool_0)
			{
				Point position = Cursor.Position;
				base.Location = new Point(this.point_1.X + (position.X - this.point_0.X), this.point_1.Y + (position.Y - this.point_0.Y));
			}
		}

		// Token: 0x0600026C RID: 620 RVA: 0x000041A5 File Offset: 0x000023A5
		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.bool_0 = false;
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x000041BB File Offset: 0x000023BB
		private void buttonMinimized_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x000041C4 File Offset: 0x000023C4
		private void buttonClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0001FBAC File Offset: 0x0001DDAC
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Class43.smethod_9();
			Class39.smethod_5(base.Handle);
			this.method_11();
			string[] array = new string[]
			{
				"System.ValueTuple.dll", "System.Runtime.CompilerServices.Unsafe.dll", "System.Numerics.Vectors.dll", "System.Memory.dll", "System.Drawing.Common.dll", "System.Buffers.dll", "OpenCvSharp.dll", "OpenCvSharp.Extensions.dll", "Newtonsoft.Json.dll", "BouncyCastle.Cryptography.dll",
				"OpenCvSharp.WpfExtensions.dll", "AutoHotkey.Interop.dll", "psClick.dll", "Y35POW8doFBv"
			};
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
			string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string text = Path.Combine(Path.GetTempPath(), string.Format("{0:N}.bat", Guid.NewGuid()));
			StringBuilder stringBuilder = new StringBuilder();
			string text2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft\\Internet Explorer\\DOMStore");
			this.method_5(text2);
			try
			{
				stringBuilder.AppendLine("@echo off");
				stringBuilder.AppendLine("timeout /t 5 /nobreak > nul");
				foreach (string text3 in array)
				{
					string text4 = Path.Combine(folderPath, text3);
					stringBuilder.AppendLine("del /f /q \"" + text4 + "\" > nul 2>&1");
				}
				stringBuilder.AppendLine("timeout /t 10 /nobreak > nul");
				stringBuilder.AppendLine("del /f /q \"%SystemRoot%\\Prefetch\\POWERSHELL*.pf\" > nul 2>&1");
				stringBuilder.AppendLine("del /f /q \"%SystemRoot%\\Prefetch\\CONHOST*.pf\" > nul 2>&1");
				stringBuilder.AppendLine("del /f /q \"%SystemRoot%\\Prefetch\\CONSENT*.pf\" > nul 2>&1");
				stringBuilder.AppendLine("del /f /q \"%SystemRoot%\\Prefetch\\CMD.EXE*.pf\" > nul 2>&1");
				stringBuilder.AppendLine("del /f /q \"%SystemRoot%\\Prefetch\\TIMEOUT.EXE*.pf\" > nul 2>&1");
				stringBuilder.AppendLine("wevtutil sl \"Microsoft-Windows-PowerShell-DesiredStateConfiguration-FileDownloadManager/Analytic\" /e:false");
				stringBuilder.AppendLine("wevtutil sl \"Microsoft-Windows-PowerShell-DesiredStateConfiguration-FileDownloadManager/Debug\" /e:false");
				stringBuilder.AppendLine("wevtutil sl \"Microsoft-Windows-PowerShell-DesiredStateConfiguration-FileDownloadManager/Operational\" /e:false");
				stringBuilder.AppendLine("wevtutil sl \"Microsoft-Windows-PowerShell/Admin\" /e:false");
				stringBuilder.AppendLine("wevtutil sl \"Microsoft-Windows-PowerShell/Analytic\" /e:false");
				stringBuilder.AppendLine("wevtutil sl \"Microsoft-Windows-PowerShell/Debug\" /e:false");
				stringBuilder.AppendLine("wevtutil sl \"Microsoft-Windows-PowerShell/Operational\" /e:false");
				stringBuilder.AppendLine("del /f /q \"%SystemRoot%\\System32\\winevt\\Logs\\*PowerShell*\" > nul 2>&1");
				stringBuilder.AppendLine("del /f /q \"" + Path.Combine(folderPath2, "Microsoft\\Windows\\PowerShell\\StartupProfileData-NonInteractive*") + "\" > nul 2>&1");
				stringBuilder.AppendLine("del /f /q \"" + Path.Combine(folderPath2, "CrashDumps\\*powershell*") + "\" > nul 2>&1");
				stringBuilder.AppendLine("fsutil usn deletejournal /D C:");
			}
			finally
			{
				if (Form1.bool_10)
				{
					stringBuilder.AppendLine("shutdown /s /t 0");
				}
			}
			stringBuilder.AppendLine("del /f /q \"" + text + "\" > nul 2>&1");
			File.WriteAllText(text, stringBuilder.ToString(), Encoding.ASCII);
			Process.Start(new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/c \"\"" + text + "\"\"",
				CreateNoWindow = true,
				UseShellExecute = false,
				WindowStyle = ProcessWindowStyle.Hidden
			});
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0001FEA0 File Offset: 0x0001E0A0
		private void method_5(string string_6)
		{
			if (!Directory.Exists(string_6))
			{
				return;
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(string_6);
				directoryInfo.Attributes = FileAttributes.Normal;
				FileInfo[] files = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
				for (int i = 0; i < files.Length; i++)
				{
					files[i].Attributes = FileAttributes.Normal;
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories("*", SearchOption.AllDirectories);
				for (int i = 0; i < directories.Length; i++)
				{
					directories[i].Attributes = FileAttributes.Normal;
				}
				Directory.Delete(string_6, true);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0001FF38 File Offset: 0x0001E138
		private void buttonLumberjack_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			if (button.Tag.ToString() != this.string_0)
			{
				this.string_0 = button.Tag.ToString();
				this.method_4(button, this.method_6());
				GC.Collect();
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0001FF88 File Offset: 0x0001E188
		private Form method_6()
		{
			string text = this.string_0;
			if (text != null)
			{
				switch (text.Length)
				{
				case 7:
				{
					char c = text[4];
					if (c != 'G')
					{
						if (c == 'V')
						{
							if (text == "FormVPN")
							{
								this.method_8(false, false);
								return this.formVPN_0;
							}
						}
					}
					else if (text == "FormGym")
					{
						this.method_8(true, false);
						return this.formGym_0;
					}
					break;
				}
				case 8:
				{
					char c = text[4];
					if (c != 'F')
					{
						if (c != 'N')
						{
							if (c == 'T')
							{
								if (text == "FormTaxi")
								{
									this.method_8(true, false);
									return this.formTaxi_0;
								}
							}
						}
						else if (text == "FormNews")
						{
							this.method_8(false, false);
							return this.formNews_0;
						}
					}
					else if (text == "FormFarm")
					{
						this.method_8(true, false);
						return this.formFarm_0;
					}
					break;
				}
				case 9:
					if (text == "FormMiner")
					{
						this.method_8(true, false);
						return this.formMiner_0;
					}
					break;
				case 10:
					if (text == "FormSewing")
					{
						this.method_8(true, false);
						return this.formSewing_0;
					}
					break;
				case 11:
				{
					char c = text[4];
					if (c != 'A')
					{
						if (c != 'B')
						{
							if (c == 'F')
							{
								if (text == "FormFishing")
								{
									this.method_8(true, false);
									return this.formFishing_0;
								}
							}
						}
						else if (text == "FormBuilder")
						{
							this.method_8(true, false);
							return this.formBuilder_0;
						}
					}
					else if (text == "FormAntiAfk")
					{
						this.method_8(true, false);
						return this.formAntiAfk_0;
					}
					break;
				}
				case 12:
				{
					char c = text[4];
					if (c != 'A')
					{
						if (c != 'D')
						{
							if (c == 'S')
							{
								if (text == "FormSettings")
								{
									this.method_8(false, true);
									return this.formSettings_0;
								}
							}
						}
						else if (text == "FormDemorgan")
						{
							this.method_8(true, false);
							return this.formDemorgan_0;
						}
					}
					else if (!(text == "FormActivate"))
					{
					}
					break;
				}
				case 13:
					if (text == "FormThiefAuto")
					{
						this.method_8(true, false);
						return this.formThiefAuto_0;
					}
					break;
				case 14:
				{
					char c = text[4];
					if (c != 'L')
					{
						if (c == 'M')
						{
							if (text == "FormMushroomer")
							{
								this.method_8(true, false);
								return this.formMushroomer_0;
							}
						}
					}
					else if (text == "FormLumberjack")
					{
						this.method_8(true, false);
						return this.formLumberjack_0;
					}
					break;
				}
				}
			}
			this.method_8(false, false);
			return this.formActivate_0;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0002023C File Offset: 0x0001E43C
		private Button method_7()
		{
			string text = this.string_0;
			if (text != null)
			{
				switch (text.Length)
				{
				case 7:
					if (text == "FormGym")
					{
						return this.buttonGym;
					}
					break;
				case 8:
				{
					char c = text[4];
					if (c != 'F')
					{
						if (c != 'N')
						{
							if (c == 'T')
							{
								if (text == "FormTaxi")
								{
									return this.buttonTaxi;
								}
							}
						}
						else if (text == "FormNews")
						{
							return this.buttonNews;
						}
					}
					else if (text == "FormFarm")
					{
						return this.buttonFarm;
					}
					break;
				}
				case 9:
					if (text == "FormMiner")
					{
						return this.buttonMiner;
					}
					break;
				case 10:
					if (text == "FormSewing")
					{
						return this.buttonSewing;
					}
					break;
				case 11:
				{
					char c = text[4];
					if (c != 'A')
					{
						if (c != 'B')
						{
							if (c == 'F')
							{
								if (text == "FormFishing")
								{
									return this.buttonFishing;
								}
							}
						}
						else if (text == "FormBuilder")
						{
							return this.buttonBuilder;
						}
					}
					else if (text == "FormAntiAfk")
					{
						return this.buttonAntiAfk;
					}
					break;
				}
				case 12:
					if (text == "FormDemorgan")
					{
						return this.buttonDemorgan;
					}
					break;
				case 13:
					if (text == "FormThiefAuto")
					{
						return this.buttonThiefAuto;
					}
					break;
				case 14:
				{
					char c = text[4];
					if (c != 'L')
					{
						if (c == 'M')
						{
							if (text == "FormMushroomer")
							{
								return this.buttonMushroomer;
							}
						}
					}
					else if (text == "FormLumberjack")
					{
						return this.buttonLumberjack;
					}
					break;
				}
				}
			}
			return this.buttonFishing;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000203F8 File Offset: 0x0001E5F8
		private void method_8(bool bool_11, bool bool_12 = false)
		{
			if (!bool_11)
			{
				this.bool_1 = true;
			}
			else
			{
				this.bool_1 = false;
			}
			this.label8.Visible = bool_11;
			this.label5.Visible = bool_11;
			this.label_HotKey0.Visible = bool_11;
			this.label_HotKey1.Visible = bool_11;
			this.panel11.Visible = bool_11;
			this.panel10.Visible = bool_11;
			this.label4.Visible = false;
			this.label6.Visible = false;
			if (bool_12)
			{
				this.label3.Visible = bool_11;
				return;
			}
			this.label3.Visible = !bool_11;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00020498 File Offset: 0x0001E698
		public static void smethod_0()
		{
			Form1.cancellationTokenSource_0.Cancel();
			Form1.Main.method_11();
			Form1.bool_8 = false;
			Form1.Main.Opacity = 1.0;
			Form1.Main.Show();
			Form1.Main.Activate();
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000041CC File Offset: 0x000023CC
		public static void smethod_1()
		{
			Form1.cancellationTokenSource_0.Cancel();
			Form1.bool_8 = false;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x000204E8 File Offset: 0x0001E6E8
		private void method_9(bool bool_11)
		{
			if (!FormSettings.isSoundMute)
			{
				if (bool_11)
				{
					this.soundPlayer_0 = new SoundPlayer(Class2.start);
				}
				else
				{
					this.soundPlayer_0 = new SoundPlayer(Class2.stop);
				}
				this.soundPlayer_0.Stop();
				this.soundPlayer_0.Play();
			}
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00020538 File Offset: 0x0001E738
		private void label_HotKey0_Click(object sender, EventArgs e)
		{
			base.ActiveControl = null;
			if (this.bool_5)
			{
				return;
			}
			this.bool_6 = false;
			if (this.bool_4)
			{
				this.label_HotKey1.Text = this.string_2;
				this.bool_4 = false;
				this.label2.Visible = false;
			}
			this.string_1 = this.label_HotKey0.Text;
			this.label_HotKey0.Text = "...";
			this.label1.Visible = true;
			this.bool_3 = true;
			this.bool_5 = true;
			Class39.UnregisterHotKey(base.Handle, 0);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x000205D0 File Offset: 0x0001E7D0
		private void label_HotKey1_Click(object sender, EventArgs e)
		{
			base.ActiveControl = null;
			if (this.bool_6)
			{
				return;
			}
			this.bool_5 = false;
			if (this.bool_3)
			{
				this.label_HotKey0.Text = this.string_1;
				this.bool_3 = false;
				this.label1.Visible = false;
			}
			this.string_2 = this.label_HotKey1.Text;
			this.label_HotKey1.Text = "...";
			this.label2.Visible = true;
			this.bool_4 = true;
			this.bool_6 = true;
			Class39.UnregisterHotKey(base.Handle, 1);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00020668 File Offset: 0x0001E868
		private static bool smethod_2(Keys keys_2, out Keys keys_3, out GEnum0 genum0_2, out string string_6)
		{
			string_6 = null;
			keys_3 = keys_2 & Keys.KeyCode;
			genum0_2 = GEnum0.flag_4;
			bool flag = (keys_2 & Keys.Control) == Keys.Control;
			bool flag2 = (keys_2 & Keys.Shift) == Keys.Shift;
			bool flag3 = (keys_2 & Keys.Alt) == Keys.Alt;
			if ((flag > false) + (flag2 > false) + (flag3 > false) > true)
			{
				return false;
			}
			if (flag)
			{
				genum0_2 = GEnum0.flag_1;
			}
			if (flag2)
			{
				genum0_2 = GEnum0.flag_2;
			}
			if (flag3)
			{
				genum0_2 = GEnum0.flag_0;
			}
			if (keys_3 != Keys.ControlKey && keys_3 != Keys.ShiftKey)
			{
				if (keys_3 != Keys.Menu)
				{
					if (keys_3 == Keys.F12 && genum0_2 == GEnum0.flag_2)
					{
						return false;
					}
					foreach (Keys keys in new Keys[]
					{
						Keys.Tab,
						Keys.I,
						Keys.W,
						Keys.A,
						Keys.S,
						Keys.D,
						Keys.E,
						Keys.M
					})
					{
						if (keys_3 == keys)
						{
							return false;
						}
					}
					Keys[] array2 = new Keys[]
					{
						Keys.F1,
						Keys.F2,
						Keys.F3,
						Keys.F4,
						Keys.F5,
						Keys.F6,
						Keys.F7,
						Keys.F8,
						Keys.F9,
						Keys.F10,
						Keys.F11,
						Keys.F12,
						Keys.Insert,
						Keys.Home,
						Keys.Prior,
						Keys.Next,
						Keys.End,
						Keys.Delete
					};
					if (genum0_2 == GEnum0.flag_4)
					{
						foreach (Keys keys2 in array2)
						{
							if (keys_3 == keys2)
							{
								return false;
							}
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0002077C File Offset: 0x0001E97C
		private static string smethod_3(GEnum0 genum0_2, string string_6)
		{
			switch (genum0_2)
			{
			case GEnum0.flag_0:
				return "Alt + " + string_6;
			case GEnum0.flag_1:
				return "Ctrl + " + string_6;
			case GEnum0.flag_2:
				return "Shift + " + string_6;
			}
			return string_6;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000207C8 File Offset: 0x0001E9C8
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData != Keys.Tab)
			{
				if (keyData != Keys.Space)
				{
					if (keyData == Keys.Escape)
					{
						if (this.bool_3)
						{
							this.label_HotKey0.Text = this.string_1;
							this.bool_3 = false;
							this.bool_5 = false;
							this.label1.Visible = false;
							return true;
						}
						if (this.bool_4)
						{
							this.label_HotKey1.Text = this.string_2;
							this.bool_4 = false;
							this.bool_6 = false;
							this.label2.Visible = false;
							return true;
						}
					}
					Keys keys2;
					GEnum0 genum2;
					string text3;
					string text4;
					if (this.bool_3)
					{
						Keys keys;
						GEnum0 genum;
						string text;
						string text2;
						if (Form1.smethod_2(keyData, out keys, out genum, out text) && this.method_10(keys, out text2))
						{
							this.keys_0 = keys;
							this.genum0_0 = genum;
							Class39.smethod_4(base.Handle, 854640, this.genum0_0, this.keys_0);
							this.label1.Visible = false;
							this.label_HotKey0.Text = Form1.smethod_3(this.genum0_0, text2);
							if (this.genum0_0 != GEnum0.flag_4)
							{
								this.pictureBox4.Width = 99;
								this.pictureBox4.Left = 636 - this.pictureBox4.Width;
								this.pictureBox4.Image = Class2.hotkey_long;
								this.label_HotKey0.Width = 95;
								this.label_HotKey0.Left = 634 - this.label_HotKey0.Width;
								this.label1.Left = 473 - this.label_HotKey0.Width;
							}
							else
							{
								this.pictureBox4.Width = 49;
								this.pictureBox4.Left = 587;
								this.pictureBox4.Image = Class2.hotkey;
								this.label_HotKey0.Width = 45;
								this.label_HotKey0.Left = 589;
								this.label1.Left = 428;
							}
							this.bool_3 = false;
							this.bool_5 = false;
							return true;
						}
					}
					else if (this.bool_4 && Form1.smethod_2(keyData, out keys2, out genum2, out text3) && this.method_10(keys2, out text4))
					{
						this.keys_1 = keys2;
						this.genum0_1 = genum2;
						Class39.smethod_4(base.Handle, 854641, this.genum0_1, this.keys_1);
						this.label2.Visible = false;
						this.label_HotKey1.Text = Form1.smethod_3(this.genum0_1, text4);
						if (this.genum0_1 != GEnum0.flag_4)
						{
							this.pictureBox3.Width = 99;
							this.pictureBox3.Left = 636 - this.pictureBox3.Width;
							this.pictureBox3.Image = Class2.hotkey_long;
							this.label_HotKey1.Width = 95;
							this.label_HotKey1.Left = 634 - this.label_HotKey1.Width;
							this.label2.Left = 473 - this.label_HotKey1.Width;
						}
						else
						{
							this.pictureBox3.Width = 49;
							this.pictureBox3.Left = 587;
							this.pictureBox3.Image = Class2.hotkey;
							this.label_HotKey1.Width = 45;
							this.label_HotKey1.Left = 589;
							this.label2.Left = 428;
						}
						this.bool_4 = false;
						this.bool_6 = false;
						return true;
					}
					return base.ProcessCmdKey(ref msg, keyData);
				}
			}
			return true;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00020B3C File Offset: 0x0001ED3C
		private bool method_10(Keys keys_2, out string string_6)
		{
			if ((keys_2 >= Keys.A && keys_2 < Keys.E) || (keys_2 > Keys.E && keys_2 <= Keys.Z))
			{
				string_6 = keys_2.ToString();
				return true;
			}
			if (keys_2 >= Keys.D0 && keys_2 <= Keys.D9)
			{
				string_6 = keys_2.ToString().Substring(1);
				return true;
			}
			if (keys_2 >= Keys.NumPad0 && keys_2 <= Keys.NumPad9)
			{
				string_6 = "N" + keys_2.ToString().Substring(6);
				return true;
			}
			if ((keys_2 >= Keys.F1 && keys_2 <= Keys.F3) || (keys_2 >= Keys.F5 && keys_2 <= Keys.F12))
			{
				string_6 = "F" + (keys_2 - Keys.F1 + 1).ToString();
				return true;
			}
			if (keys_2 <= Keys.Divide)
			{
				switch (keys_2)
				{
				case Keys.Left:
					string_6 = "←";
					return true;
				case Keys.Up:
					string_6 = "↑";
					return true;
				case Keys.Right:
					string_6 = "→";
					return true;
				case Keys.Down:
					string_6 = "↓";
					return true;
				default:
					switch (keys_2)
					{
					case Keys.Multiply:
						string_6 = "N*";
						return true;
					case Keys.Add:
						string_6 = "N+";
						return true;
					case Keys.Subtract:
						string_6 = "N-";
						return true;
					case Keys.Decimal:
						string_6 = "N.";
						return true;
					case Keys.Divide:
						string_6 = "N/";
						return true;
					}
					break;
				}
			}
			else
			{
				switch (keys_2)
				{
				case Keys.OemSemicolon:
					string_6 = ";";
					return true;
				case Keys.Oemplus:
					string_6 = "+";
					return true;
				case Keys.Oemcomma:
					string_6 = ",";
					return true;
				case Keys.OemMinus:
					string_6 = "-";
					return true;
				case Keys.OemPeriod:
					string_6 = ".";
					return true;
				case Keys.OemQuestion:
					string_6 = "/";
					return true;
				case Keys.Oemtilde:
					string_6 = "~";
					return true;
				default:
					switch (keys_2)
					{
					case Keys.OemOpenBrackets:
						string_6 = "[";
						return true;
					case Keys.OemPipe:
						string_6 = "\\";
						return true;
					case Keys.OemCloseBrackets:
						string_6 = "]";
						return true;
					case Keys.OemQuotes:
						string_6 = "'";
						return true;
					}
					break;
				}
			}
			string_6 = keys_2.ToString();
			return false;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00020D3C File Offset: 0x0001EF3C
		public void method_11()
		{
			try
			{
				Form1.cancellationTokenSource_0.Cancel();
				if (base.InvokeRequired)
				{
					base.Invoke(new Action(this.method_11));
				}
				else
				{
					Class76.smethod_0();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000410F File Offset: 0x0000230F
		[CompilerGenerated]
		private void labelTime_GotFocus(object sender, EventArgs e)
		{
			base.ActiveControl = null;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x000041FD File Offset: 0x000023FD
		[CompilerGenerated]
		private void timer_0_Elapsed(object sender, ElapsedEventArgs e)
		{
			this.bool_1 = false;
			this.timer_0.Stop();
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00004211 File Offset: 0x00002411
		[CompilerGenerated]
		private void timer_0_Elapsed_1(object sender, ElapsedEventArgs e)
		{
			this.bool_2 = false;
			this.timer_0.Stop();
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00004225 File Offset: 0x00002425
		[CompilerGenerated]
		private Task method_12()
		{
			return Class50.smethod_0(this.string_0.Substring(4));
		}

		// Token: 0x040002D1 RID: 721
		[CompilerGenerated]
		private static Form1 form1_0;

		// Token: 0x040002D2 RID: 722
		public readonly FormFishing formFishing_0;

		// Token: 0x040002D3 RID: 723
		public readonly FormLumberjack formLumberjack_0;

		// Token: 0x040002D4 RID: 724
		public readonly FormMiner formMiner_0;

		// Token: 0x040002D5 RID: 725
		public readonly FormFarm formFarm_0;

		// Token: 0x040002D6 RID: 726
		public readonly FormMushroomer formMushroomer_0;

		// Token: 0x040002D7 RID: 727
		public readonly FormGym formGym_0;

		// Token: 0x040002D8 RID: 728
		public readonly FormSewing formSewing_0;

		// Token: 0x040002D9 RID: 729
		public readonly FormTaxi formTaxi_0;

		// Token: 0x040002DA RID: 730
		public readonly FormThiefAuto formThiefAuto_0;

		// Token: 0x040002DB RID: 731
		public readonly FormAntiAfk formAntiAfk_0;

		// Token: 0x040002DC RID: 732
		public readonly FormDemorgan formDemorgan_0;

		// Token: 0x040002DD RID: 733
		public readonly FormBuilder formBuilder_0;

		// Token: 0x040002DE RID: 734
		public readonly FormNews formNews_0 = new FormNews();

		// Token: 0x040002DF RID: 735
		public readonly FormSettings formSettings_0 = new FormSettings();

		// Token: 0x040002E0 RID: 736
		private readonly FormActivate formActivate_0;

		// Token: 0x040002E1 RID: 737
		public readonly FormVPN formVPN_0;

		// Token: 0x040002E2 RID: 738
		private readonly Class63 class63_0 = new Class63();

		// Token: 0x040002E3 RID: 739
		private Point point_0;

		// Token: 0x040002E4 RID: 740
		private Point point_1;

		// Token: 0x040002E5 RID: 741
		private bool bool_0;

		// Token: 0x040002E6 RID: 742
		private bool bool_1;

		// Token: 0x040002E7 RID: 743
		private bool bool_2;

		// Token: 0x040002E8 RID: 744
		private bool bool_3;

		// Token: 0x040002E9 RID: 745
		private bool bool_4;

		// Token: 0x040002EA RID: 746
		private bool bool_5;

		// Token: 0x040002EB RID: 747
		private bool bool_6;

		// Token: 0x040002EC RID: 748
		public Keys keys_0;

		// Token: 0x040002ED RID: 749
		public Keys keys_1;

		// Token: 0x040002EE RID: 750
		public GEnum0 genum0_0;

		// Token: 0x040002EF RID: 751
		public GEnum0 genum0_1;

		// Token: 0x040002F0 RID: 752
		public string string_0;

		// Token: 0x040002F1 RID: 753
		private string string_1;

		// Token: 0x040002F2 RID: 754
		private string string_2;

		// Token: 0x040002F3 RID: 755
		private readonly global::System.Timers.Timer timer_0 = new global::System.Timers.Timer(500.0);

		// Token: 0x040002F4 RID: 756
		private readonly global::System.Timers.Timer timer_1 = new global::System.Timers.Timer(500.0);

		// Token: 0x040002F5 RID: 757
		public DateTime dateTime_0;

		// Token: 0x040002F6 RID: 758
		private global::System.Windows.Forms.Timer timer_2;

		// Token: 0x040002F7 RID: 759
		private global::System.Windows.Forms.Timer timer_3;

		// Token: 0x040002F8 RID: 760
		public bool bool_7;

		// Token: 0x040002F9 RID: 761
		private static CancellationTokenSource cancellationTokenSource_0;

		// Token: 0x040002FA RID: 762
		public static bool bool_8 = false;

		// Token: 0x040002FB RID: 763
		private bool bool_9;

		// Token: 0x040002FC RID: 764
		public static byte[] byte_0;

		// Token: 0x040002FD RID: 765
		public static byte[] byte_1;

		// Token: 0x040002FE RID: 766
		public static string string_3 = "FormNews";

		// Token: 0x040002FF RID: 767
		[CompilerGenerated]
		private static string string_4;

		// Token: 0x04000300 RID: 768
		public static bool bool_10 = false;

		// Token: 0x04000301 RID: 769
		public static CancellationToken cancellationToken_0;

		// Token: 0x04000302 RID: 770
		private SoundPlayer soundPlayer_0;

		// Token: 0x04000303 RID: 771
		private ScrollHost scrollHost_0 = new ScrollHost
		{
			Dock = DockStyle.Fill
		};

		// Token: 0x04000304 RID: 772
		private static readonly string[] string_5 = new string[]
		{
			"2560x1440", "1920x1200", "1920x1080", "1680x1050", "1600x900", "1440x900", "1366x768", "1360x768", "1280x1024", "1280x800",
			"1280x720"
		};

		// Token: 0x0200004F RID: 79
		private static class Class29
		{
			// Token: 0x06000286 RID: 646
			[DllImport("user32.dll")]
			private static extern uint GetWindowLong(IntPtr intptr_0, int int_2);

			// Token: 0x06000287 RID: 647
			[DllImport("user32.dll")]
			private static extern bool GetWindowRect(IntPtr intptr_0, out Form1.Class29.Struct4 struct4_0);

			// Token: 0x06000288 RID: 648
			[DllImport("user32.dll", SetLastError = true)]
			private static extern bool SetWindowPos(IntPtr intptr_0, IntPtr intptr_1, int int_2, int int_3, int int_4, int int_5, uint uint_4);

			// Token: 0x06000289 RID: 649
			[DllImport("user32.dll", SetLastError = true)]
			private static extern bool AdjustWindowRectExForDpi(ref Form1.Class29.Struct4 struct4_0, uint uint_4, bool bool_0, uint uint_5, uint uint_6);

			// Token: 0x0600028A RID: 650
			[DllImport("user32.dll", SetLastError = true)]
			private static extern bool AdjustWindowRectEx(ref Form1.Class29.Struct4 struct4_0, uint uint_4, bool bool_0, uint uint_5);

			// Token: 0x0600028B RID: 651
			[DllImport("user32.dll", SetLastError = true)]
			private static extern uint GetDpiForWindow(IntPtr intptr_0);

			// Token: 0x0600028C RID: 652 RVA: 0x00023C58 File Offset: 0x00021E58
			public static void smethod_0(IntPtr intptr_0, int int_2, int int_3, int? nullable_0 = null, int? nullable_1 = null)
			{
				if (intptr_0 == IntPtr.Zero)
				{
					throw new ArgumentException("Invalid HWND");
				}
				uint windowLong = Form1.Class29.GetWindowLong(intptr_0, -16);
				uint windowLong2 = Form1.Class29.GetWindowLong(intptr_0, -20);
				Form1.Class29.Struct4 @struct = new Form1.Class29.Struct4
				{
					int_0 = 0,
					int_1 = 0,
					int_2 = int_2,
					int_3 = int_3
				};
				bool flag = false;
				try
				{
					uint dpiForWindow = Form1.Class29.GetDpiForWindow(intptr_0);
					if (dpiForWindow != 0U)
					{
						flag = Form1.Class29.AdjustWindowRectExForDpi(ref @struct, windowLong, false, windowLong2, dpiForWindow);
					}
				}
				catch (EntryPointNotFoundException)
				{
				}
				if (!flag)
				{
					Form1.Class29.AdjustWindowRectEx(ref @struct, windowLong, false, windowLong2);
				}
				int num = @struct.int_2 - @struct.int_0;
				int num2 = @struct.int_3 - @struct.int_1;
				int value;
				int value2;
				if (nullable_0 != null && nullable_1 != null)
				{
					value = nullable_0.Value;
					value2 = nullable_1.Value;
				}
				else
				{
					Form1.Class29.Struct4 struct2;
					Form1.Class29.GetWindowRect(intptr_0, out struct2);
					value = struct2.int_0;
					value2 = struct2.int_1;
				}
				Form1.Class29.SetWindowPos(intptr_0, IntPtr.Zero, value, value2, num, num2, 116U);
			}

			// Token: 0x0400032C RID: 812
			private const int int_0 = -16;

			// Token: 0x0400032D RID: 813
			private const int int_1 = -20;

			// Token: 0x0400032E RID: 814
			private const uint uint_0 = 4U;

			// Token: 0x0400032F RID: 815
			private const uint uint_1 = 16U;

			// Token: 0x04000330 RID: 816
			private const uint uint_2 = 32U;

			// Token: 0x04000331 RID: 817
			private const uint uint_3 = 64U;

			// Token: 0x02000050 RID: 80
			private struct Struct4
			{
				// Token: 0x04000332 RID: 818
				public int int_0;

				// Token: 0x04000333 RID: 819
				public int int_1;

				// Token: 0x04000334 RID: 820
				public int int_2;

				// Token: 0x04000335 RID: 821
				public int int_3;
			}
		}

		// Token: 0x02000051 RID: 81
		public class GException0 : Exception
		{
			// Token: 0x17000070 RID: 112
			// (get) Token: 0x0600028D RID: 653 RVA: 0x00004238 File Offset: 0x00002438
			// (set) Token: 0x0600028E RID: 654 RVA: 0x00004240 File Offset: 0x00002440
			public bool HasMessage { get; private set; }

			// Token: 0x0600028F RID: 655 RVA: 0x00004249 File Offset: 0x00002449
			public GException0()
			{
				this.HasMessage = false;
			}

			// Token: 0x06000290 RID: 656 RVA: 0x00004258 File Offset: 0x00002458
			public GException0(string string_0)
				: base(string_0)
			{
				this.HasMessage = true;
			}

			// Token: 0x04000336 RID: 822
			[CompilerGenerated]
			private bool bool_0;
		}

		// Token: 0x02000052 RID: 82
		[CompilerGenerated]
		private sealed class Class30
		{
			// Token: 0x06000292 RID: 658 RVA: 0x00004268 File Offset: 0x00002468
			internal void method_0()
			{
				Class26.smethod_1(this.class76_0);
			}

			// Token: 0x06000293 RID: 659 RVA: 0x00004275 File Offset: 0x00002475
			internal void method_1()
			{
				Class51.smethod_1(this.class76_0);
			}

			// Token: 0x06000294 RID: 660 RVA: 0x00004282 File Offset: 0x00002482
			internal void method_2()
			{
				Class53.smethod_1(this.class76_0);
			}

			// Token: 0x06000295 RID: 661 RVA: 0x0000428F File Offset: 0x0000248F
			internal void method_3()
			{
				Class24.smethod_1(this.class76_0);
			}

			// Token: 0x06000296 RID: 662 RVA: 0x0000429C File Offset: 0x0000249C
			internal void method_4()
			{
				Class57.smethod_1(this.class76_0);
			}

			// Token: 0x06000297 RID: 663 RVA: 0x000042A9 File Offset: 0x000024A9
			internal void method_5()
			{
				Class31.smethod_1(this.class76_0);
			}

			// Token: 0x06000298 RID: 664 RVA: 0x000042B6 File Offset: 0x000024B6
			internal void method_6()
			{
				Class67.smethod_1(this.class76_0);
			}

			// Token: 0x06000299 RID: 665 RVA: 0x000042C3 File Offset: 0x000024C3
			internal void method_7()
			{
				Class70.smethod_1(this.class76_0);
			}

			// Token: 0x0600029A RID: 666 RVA: 0x000042D0 File Offset: 0x000024D0
			internal void method_8()
			{
				Class73.smethod_1(this.class76_0);
			}

			// Token: 0x0600029B RID: 667 RVA: 0x000042DD File Offset: 0x000024DD
			internal void method_9()
			{
				Class6.smethod_1(this.class76_0);
			}

			// Token: 0x0600029C RID: 668 RVA: 0x000042EA File Offset: 0x000024EA
			internal void method_10()
			{
				Class18.smethod_1(this.class76_0);
			}

			// Token: 0x0600029D RID: 669 RVA: 0x000042F7 File Offset: 0x000024F7
			internal void method_11()
			{
				Class8.smethod_1(this.class76_0);
			}

			// Token: 0x04000337 RID: 823
			public Class76 class76_0;
		}
	}
}
