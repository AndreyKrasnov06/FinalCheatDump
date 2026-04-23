using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	// Token: 0x02000057 RID: 87
	public partial class GForm0 : Form, Interface0
	{
		// Token: 0x060002C3 RID: 707 RVA: 0x00026714 File Offset: 0x00024914
		public virtual GClass4 imethod_0()
		{
			GClass4 gclass = new GClass4
			{
				FormName = base.Name,
				Slider = new Dictionary<string, int>(),
				ToggleButtons = new Dictionary<string, bool>(),
				TextBoxes = new Dictionary<string, string>(),
				ComboBoxes = new Dictionary<string, int>()
			};
			this.method_0(base.Controls, gclass);
			return gclass;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00026770 File Offset: 0x00024970
		protected void method_0(Control.ControlCollection controlCollection_0, GClass4 gclass4_0)
		{
			foreach (object obj in controlCollection_0)
			{
				Control control = (Control)obj;
				Control control2 = control;
				CheckBox checkBox = control2 as CheckBox;
				if (checkBox == null)
				{
					TextBox textBox = control2 as TextBox;
					if (textBox == null)
					{
						Slider slider = control2 as Slider;
						if (slider == null)
						{
							TrackBar trackBar = control2 as TrackBar;
							if (trackBar == null)
							{
								global::System.ComboBox comboBox = control2 as global::System.ComboBox;
								if (comboBox != null && !string.IsNullOrEmpty(comboBox.Name))
								{
									gclass4_0.ComboBoxes[comboBox.Name] = comboBox.SelectedIndex;
								}
							}
							else if (!string.IsNullOrEmpty(trackBar.Name))
							{
								gclass4_0.Slider[trackBar.Name] = trackBar.Value;
							}
						}
						else if (!string.IsNullOrEmpty(slider.Name))
						{
							gclass4_0.Slider[slider.Name] = slider.Value;
						}
					}
					else
					{
						gclass4_0.TextBoxes[textBox.Name] = textBox.Text ?? string.Empty;
					}
				}
				else
				{
					gclass4_0.ToggleButtons[checkBox.Name] = checkBox.Checked;
				}
				if (control.HasChildren)
				{
					this.method_0(control.Controls, gclass4_0);
				}
			}
		}
	}
}
