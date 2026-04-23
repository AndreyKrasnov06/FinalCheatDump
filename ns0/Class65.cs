using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ns0
{
	// Token: 0x0200009B RID: 155
	internal class Class65
	{
		// Token: 0x06000471 RID: 1137 RVA: 0x000386C4 File Offset: 0x000368C4
		static Class65()
		{
			Class65.httpClient_0.DefaultRequestHeaders.Remove(Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_0, false)));
			Class65.httpClient_0.DefaultRequestHeaders.Add(Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_0, false)), Encoding.UTF8.GetString(GClass2.smethod_3(ref Form1.byte_1, false)));
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00038818 File Offset: 0x00036A18
		public static async void smethod_0(string string_1, GEnum0 genum0_0, Keys keys_0, GEnum0 genum0_1, Keys keys_1)
		{
			try
			{
				Class75 @class = new Class75
				{
					LastOpenedForm = string_1,
					Modifiers = new GEnum0[] { genum0_0, genum0_1 },
					Hotkey = new Keys[] { keys_0, keys_1 },
					Forms = new List<GClass4>()
				};
				foreach (Form form in Class65.form_0)
				{
					@class.Forms.Add(Class65.smethod_1(form));
				}
				string text = JsonConvert.SerializeObject(@class);
				if (Class43.jtoken_0 != null)
				{
					Class65.httpClient_0.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Class43.jtoken_0.ToString());
					StringContent stringContent = new StringContent(text, Encoding.UTF8);
					await Class65.httpClient_0.PostAsync("", stringContent);
				}
			}
			catch (HttpRequestException)
			{
			}
			catch (JsonException)
			{
			}
			catch (Exception ex)
			{
				new FormMessage("Error saving settings: " + ex.Message);
			}
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00038870 File Offset: 0x00036A70
		private static GClass4 smethod_1(Form form_1)
		{
			Interface0 @interface = form_1 as Interface0;
			if (@interface != null)
			{
				return @interface.imethod_0();
			}
			return new GClass4
			{
				FormName = form_1.Name
			};
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x000388A0 File Offset: 0x00036AA0
		public static void smethod_2(JToken jtoken_0)
		{
			try
			{
				if (jtoken_0 != null)
				{
					if (jtoken_0.Type != 10)
					{
						Class75 @class = JsonConvert.DeserializeObject<Class75>(jtoken_0.ToString());
						if (((@class != null) ? @class.Forms : null) != null)
						{
							Form1.string_3 = @class.LastOpenedForm;
							Form1.Main.genum0_0 = @class.Modifiers[0];
							Form1.Main.keys_0 = @class.Hotkey[0];
							Form1.Main.genum0_1 = @class.Modifiers[1];
							Form1.Main.keys_1 = @class.Hotkey[1];
							Form[] array = Class65.form_0;
							for (int i = 0; i < array.Length; i++)
							{
								Class65.Class66 class2 = new Class65.Class66();
								class2.form_0 = array[i];
								GClass4 gclass = @class.Forms.FirstOrDefault(new Func<GClass4, bool>(class2.method_0));
								if (gclass != null)
								{
									Class65.smethod_3(class2.form_0, gclass);
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				new FormMessage("Ошибка загрузки настроек: " + ex.Message);
			}
			finally
			{
				Form1.Main.bool_7 = false;
			}
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x000389C8 File Offset: 0x00036BC8
		private static void smethod_3(Form form_1, GClass4 gclass4_0)
		{
			if (form_1 != null && gclass4_0 != null)
			{
				foreach (KeyValuePair<string, bool> keyValuePair in (gclass4_0.ToggleButtons ?? new Dictionary<string, bool>()))
				{
					CheckBox checkBox = form_1.Controls.Find(keyValuePair.Key, true).FirstOrDefault<Control>() as CheckBox;
					if (checkBox != null)
					{
						checkBox.Checked = keyValuePair.Value;
					}
				}
				foreach (KeyValuePair<string, string> keyValuePair2 in (gclass4_0.TextBoxes ?? new Dictionary<string, string>()))
				{
					TextBox textBox = form_1.Controls.Find(keyValuePair2.Key, true).FirstOrDefault<Control>() as TextBox;
					if (textBox != null)
					{
						textBox.Text = keyValuePair2.Value ?? string.Empty;
					}
				}
				foreach (KeyValuePair<string, int> keyValuePair3 in (gclass4_0.Slider ?? new Dictionary<string, int>()))
				{
					Control control = form_1.Controls.Find(keyValuePair3.Key, true).FirstOrDefault<Control>();
					Slider slider = control as Slider;
					if (slider != null)
					{
						int num = keyValuePair3.Value;
						if (num < slider.Minimum)
						{
							num = slider.Minimum;
						}
						else if (num > slider.Maximum)
						{
							num = slider.Maximum;
						}
						slider.Value = num;
					}
					else
					{
						TrackBar trackBar = control as TrackBar;
						if (trackBar != null)
						{
							int num2 = keyValuePair3.Value;
							if (num2 < trackBar.Minimum)
							{
								num2 = trackBar.Minimum;
							}
							else if (num2 > trackBar.Maximum)
							{
								num2 = trackBar.Maximum;
							}
							trackBar.Value = num2;
						}
					}
				}
				foreach (KeyValuePair<string, int> keyValuePair4 in (gclass4_0.ComboBoxes ?? new Dictionary<string, int>()))
				{
					global::System.ComboBox comboBox = form_1.Controls.Find(keyValuePair4.Key, true).FirstOrDefault<Control>() as global::System.ComboBox;
					if (comboBox != null)
					{
						comboBox.SelectedIndex = keyValuePair4.Value;
					}
				}
				return;
			}
		}

		// Token: 0x04000521 RID: 1313
		private static readonly HttpClient httpClient_0 = new HttpClient
		{
			BaseAddress = new Uri("https://antia.space/majestic/settings"),
			Timeout = TimeSpan.FromSeconds(5.0)
		};

		// Token: 0x04000522 RID: 1314
		private const string string_0 = "https://antia.space/majestic/settings";

		// Token: 0x04000523 RID: 1315
		private static readonly Form[] form_0 = new Form[]
		{
			Form1.Main.formFishing_0,
			Form1.Main.formLumberjack_0,
			Form1.Main.formMiner_0,
			Form1.Main.formFarm_0,
			Form1.Main.formMushroomer_0,
			Form1.Main.formGym_0,
			Form1.Main.formSewing_0,
			Form1.Main.formTaxi_0,
			Form1.Main.formThiefAuto_0,
			Form1.Main.formAntiAfk_0,
			Form1.Main.formDemorgan_0,
			Form1.Main.formBuilder_0,
			Form1.Main.formSettings_0
		};

		// Token: 0x0200009C RID: 156
		[CompilerGenerated]
		private sealed class Class66
		{
			// Token: 0x06000478 RID: 1144 RVA: 0x00005270 File Offset: 0x00003470
			internal bool method_0(GClass4 gclass4_0)
			{
				return gclass4_0.FormName == this.form_0.Name;
			}

			// Token: 0x04000524 RID: 1316
			public Form form_0;
		}
	}
}
