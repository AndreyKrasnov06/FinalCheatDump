using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace System
{
	// Token: 0x02000014 RID: 20
	public class FishContent : UserControl
	{
		// Token: 0x0600009D RID: 157 RVA: 0x00006D1C File Offset: 0x00004F1C
		static FishContent()
		{
			foreach (FieldInfo fieldInfo in typeof(FishContent).GetFields(FishContent.FieldFlags))
			{
				if (fieldInfo.FieldType == typeof(bool))
				{
					fieldInfo.SetValue(null, true);
				}
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000030C7 File Offset: 0x000012C7
		public FishContent()
		{
			this.InitializeComponent();
			this.WireHandlers(this);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00006D7C File Offset: 0x00004F7C
		public Dictionary<string, bool> GetAllChecked()
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>(StringComparer.Ordinal);
			foreach (FieldInfo fieldInfo in typeof(FishContent).GetFields(FishContent.FieldFlags))
			{
				if (fieldInfo.FieldType == typeof(bool))
				{
					bool flag = (bool)fieldInfo.GetValue(null);
					dictionary[fieldInfo.Name] = flag;
				}
			}
			return dictionary;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00006DF0 File Offset: 0x00004FF0
		public void SetAllPickUp(bool OnlyTrophy = false)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(delegate
				{
					this.SetAllPickUp(OnlyTrophy);
				}));
				return;
			}
			base.SuspendLayout();
			this._bulkUpdating = true;
			try
			{
				foreach (PinkCheckBox pinkCheckBox in FishContent.EnumerateControls<PinkCheckBox>(this))
				{
					if ((pinkCheckBox.Name ?? string.Empty).IndexOf("_PickUp", StringComparison.Ordinal) >= 0)
					{
						pinkCheckBox.Checked = true;
						PinkCheckBox pinkCheckBox2 = this.FindPair(pinkCheckBox, true);
						if (pinkCheckBox2 != null)
						{
							pinkCheckBox2.Checked = false;
						}
					}
				}
				if (OnlyTrophy)
				{
					this.SetPickBack("ModestCatch", false, true);
					this.SetPickBack("GoodCatch", false, true);
					this.SetPickBack("RecordCatch", false, true);
					this.SetPickBack("TrophyCatch", true, false);
				}
				else
				{
					this.SetPickBack("ModestCatch", true, false);
					this.SetPickBack("GoodCatch", true, false);
					this.SetPickBack("RecordCatch", true, false);
					this.SetPickBack("TrophyCatch", true, false);
				}
			}
			finally
			{
				this._bulkUpdating = false;
				base.ResumeLayout();
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000030DC File Offset: 0x000012DC
		private PinkCheckBox FindCb(string name)
		{
			return base.Controls.Find(name, true).OfType<PinkCheckBox>().FirstOrDefault<PinkCheckBox>();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00006F3C File Offset: 0x0000513C
		private void SetPickBack(string baseName, bool pick, bool back)
		{
			PinkCheckBox pinkCheckBox = this.FindCb("CheckBox_" + baseName + "_PickUp");
			PinkCheckBox pinkCheckBox2 = this.FindCb("CheckBox_" + baseName + "_Back");
			if (pinkCheckBox != null)
			{
				pinkCheckBox.Checked = pick;
			}
			if (pinkCheckBox2 != null)
			{
				pinkCheckBox2.Checked = back;
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00006F8C File Offset: 0x0000518C
		public void SetAllBack()
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(this.SetAllBack));
				return;
			}
			base.SuspendLayout();
			this._bulkUpdating = true;
			try
			{
				foreach (PinkCheckBox pinkCheckBox in FishContent.EnumerateControls<PinkCheckBox>(this))
				{
					string text = pinkCheckBox.Name ?? string.Empty;
					if (text.IndexOf("_PickUp", StringComparison.Ordinal) >= 0)
					{
						PinkCheckBox pinkCheckBox2 = this.FindPair(pinkCheckBox, true);
						if (text.IndexOf("Catch", StringComparison.Ordinal) >= 0)
						{
							pinkCheckBox.Checked = true;
							if (pinkCheckBox2 != null)
							{
								pinkCheckBox2.Checked = false;
							}
						}
						else
						{
							pinkCheckBox.Checked = false;
							if (pinkCheckBox2 != null)
							{
								pinkCheckBox2.Checked = true;
							}
						}
					}
				}
			}
			finally
			{
				this._bulkUpdating = false;
				base.ResumeLayout();
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00007078 File Offset: 0x00005278
		private void PickUp_CheckedChanged(object sender, EventArgs e)
		{
			PinkCheckBox pinkCheckBox = sender as PinkCheckBox;
			if (pinkCheckBox == null)
			{
				return;
			}
			string text = FishContent.ExtractBaseName(pinkCheckBox.Name, true);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			FishContent.SetFlagByName(text, pinkCheckBox.Checked);
			if (this._bulkUpdating)
			{
				return;
			}
			PinkCheckBox pinkCheckBox2 = this.FindPair(pinkCheckBox, true);
			if (pinkCheckBox2 != null)
			{
				pinkCheckBox2.Checked = !pinkCheckBox.Checked;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000070D8 File Offset: 0x000052D8
		private void Back_CheckedChanged(object sender, EventArgs e)
		{
			PinkCheckBox pinkCheckBox = sender as PinkCheckBox;
			if (pinkCheckBox == null)
			{
				return;
			}
			string text = FishContent.ExtractBaseName(pinkCheckBox.Name, false);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			FishContent.SetFlagByName(text, !pinkCheckBox.Checked);
			if (this._bulkUpdating)
			{
				return;
			}
			PinkCheckBox pinkCheckBox2 = this.FindPair(pinkCheckBox, false);
			if (pinkCheckBox2 != null)
			{
				pinkCheckBox2.Checked = !pinkCheckBox.Checked;
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000713C File Offset: 0x0000533C
		private void WireHandlers(Control root)
		{
			foreach (PinkCheckBox pinkCheckBox in FishContent.EnumerateControls<PinkCheckBox>(root))
			{
				string text = pinkCheckBox.Name ?? string.Empty;
				if (text.EndsWith("_PickUp", StringComparison.Ordinal))
				{
					pinkCheckBox.CheckedChanged -= this.PickUp_CheckedChanged;
					pinkCheckBox.CheckedChanged += this.PickUp_CheckedChanged;
				}
				else if (text.EndsWith("_Back", StringComparison.Ordinal))
				{
					pinkCheckBox.CheckedChanged -= this.Back_CheckedChanged;
					pinkCheckBox.CheckedChanged += this.Back_CheckedChanged;
				}
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000030F5 File Offset: 0x000012F5
		private static IEnumerable<T> EnumerateControls<T>(Control root) where T : Control
		{
			FishContent.<EnumerateControls>d__50<T> <EnumerateControls>d__ = new FishContent.<EnumerateControls>d__50<T>(-2);
			<EnumerateControls>d__.<>3__root = root;
			return <EnumerateControls>d__;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000071FC File Offset: 0x000053FC
		private PinkCheckBox FindPair(PinkCheckBox source, bool isPickUp)
		{
			string text = FishContent.ExtractBaseName(source.Name, isPickUp);
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			string text2 = "CheckBox_" + text + (isPickUp ? "_Back" : "_PickUp");
			return base.Controls.Find(text2, true).FirstOrDefault<Control>() as PinkCheckBox;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00007254 File Offset: 0x00005454
		private static string ExtractBaseName(string controlName, bool isPickUp)
		{
			if (string.IsNullOrEmpty(controlName))
			{
				return null;
			}
			if (!controlName.StartsWith("CheckBox_", StringComparison.Ordinal))
			{
				return null;
			}
			string text = (isPickUp ? "_PickUp" : "_Back");
			if (!controlName.EndsWith(text, StringComparison.Ordinal))
			{
				return null;
			}
			int length = "CheckBox_".Length;
			int num = controlName.Length - length - text.Length;
			if (num <= 0)
			{
				return null;
			}
			return controlName.Substring(length, num);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000072C0 File Offset: 0x000054C0
		private static void SetFlagByName(string fieldName, bool value)
		{
			FieldInfo field = typeof(FishContent).GetField(fieldName, FishContent.FieldFlags);
			if (field != null && field.FieldType == typeof(bool))
			{
				field.SetValue(null, value);
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003105 File Offset: 0x00001305
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00007310 File Offset: 0x00005510
		private void InitializeComponent()
		{
			this.panel15 = new Panel();
			this.CheckBox_ModestCatch_Back = new PinkCheckBox();
			this.panel14 = new Panel();
			this.CheckBox_TrophyCatch_Back = new PinkCheckBox();
			this.panel16 = new Panel();
			this.CheckBox_ModestCatch_PickUp = new PinkCheckBox();
			this.panel17 = new Panel();
			this.label10 = new Label();
			this.panel13 = new Panel();
			this.CheckBox_TrophyCatch_PickUp = new PinkCheckBox();
			this.panel12 = new Panel();
			this.CheckBox_RecordCatch_Back = new PinkCheckBox();
			this.panel10 = new Panel();
			this.CheckBox_RecordCatch_PickUp = new PinkCheckBox();
			this.panel9 = new Panel();
			this.CheckBox_GoodCatch_Back = new PinkCheckBox();
			this.panel8 = new Panel();
			this.CheckBox_GoodCatch_PickUp = new PinkCheckBox();
			this.panel5 = new Panel();
			this.label9 = new Label();
			this.panel4 = new Panel();
			this.label8 = new Label();
			this.panel3 = new Panel();
			this.label7 = new Label();
			this.panel7 = new Panel();
			this.CheckBox_Albula_Back = new PinkCheckBox();
			this.panel6 = new Panel();
			this.CheckBox_Albula_PickUp = new PinkCheckBox();
			this.panel2 = new Panel();
			this.label6 = new Label();
			this.panel1 = new Panel();
			this.CheckBox_Lesh_Back = new PinkCheckBox();
			this.panel102 = new Panel();
			this.CheckBox_Lesh_PickUp = new PinkCheckBox();
			this.panel103 = new Panel();
			this.label3 = new Label();
			this.panel72 = new Panel();
			this.CheckBox_Sazan_Back = new PinkCheckBox();
			this.panel69 = new Panel();
			this.CheckBox_Ruster_Back = new PinkCheckBox();
			this.panel73 = new Panel();
			this.CheckBox_Sazan_PickUp = new PinkCheckBox();
			this.panel74 = new Panel();
			this.label30 = new Label();
			this.panel42 = new Panel();
			this.CheckBox_RechnoyOkun_Back = new PinkCheckBox();
			this.panel70 = new Panel();
			this.CheckBox_Ruster_PickUp = new PinkCheckBox();
			this.panel33 = new Panel();
			this.CheckBox_Krasnoperka_Back = new PinkCheckBox();
			this.panel71 = new Panel();
			this.label29 = new Label();
			this.panel43 = new Panel();
			this.CheckBox_RechnoyOkun_PickUp = new PinkCheckBox();
			this.panel34 = new Panel();
			this.CheckBox_Krasnoperka_PickUp = new PinkCheckBox();
			this.panel44 = new Panel();
			this.label20 = new Label();
			this.panel35 = new Panel();
			this.label17 = new Label();
			this.panel45 = new Panel();
			this.CheckBox_RadujnayaForel_Back = new PinkCheckBox();
			this.panel36 = new Panel();
			this.CheckBox_KorichneviySom_Back = new PinkCheckBox();
			this.panel46 = new Panel();
			this.CheckBox_PribrejniyBass_Back = new PinkCheckBox();
			this.panel37 = new Panel();
			this.CheckBox_ZerkalniyKarp_Back = new PinkCheckBox();
			this.panel47 = new Panel();
			this.CheckBox_RadujnayaForel_PickUp = new PinkCheckBox();
			this.panel38 = new Panel();
			this.CheckBox_KorichneviySom_PickUp = new PinkCheckBox();
			this.panel48 = new Panel();
			this.label21 = new Label();
			this.panel39 = new Panel();
			this.label18 = new Label();
			this.panel49 = new Panel();
			this.CheckBox_PribrejniyBass_PickUp = new PinkCheckBox();
			this.panel40 = new Panel();
			this.CheckBox_ZerkalniyKarp_PickUp = new PinkCheckBox();
			this.panel50 = new Panel();
			this.label22 = new Label();
			this.panel41 = new Panel();
			this.label19 = new Label();
			this.panel51 = new Panel();
			this.CheckBox_PolosatiyLavrak_Back = new PinkCheckBox();
			this.panel24 = new Panel();
			this.CheckBox_Jereh_Back = new PinkCheckBox();
			this.panel52 = new Panel();
			this.CheckBox_Marlin_Back = new PinkCheckBox();
			this.panel21 = new Panel();
			this.CheckBox_Vobla_Back = new PinkCheckBox();
			this.panel53 = new Panel();
			this.CheckBox_PolosatiyLavrak_PickUp = new PinkCheckBox();
			this.panel25 = new Panel();
			this.CheckBox_Jereh_PickUp = new PinkCheckBox();
			this.panel54 = new Panel();
			this.CheckBox_Marlin_PickUp = new PinkCheckBox();
			this.panel22 = new Panel();
			this.CheckBox_Vobla_PickUp = new PinkCheckBox();
			this.panel55 = new Panel();
			this.label23 = new Label();
			this.panel26 = new Panel();
			this.label14 = new Label();
			this.panel56 = new Panel();
			this.label24 = new Label();
			this.panel23 = new Panel();
			this.label13 = new Label();
			this.panel57 = new Panel();
			this.CheckBox_Plotva_Back = new PinkCheckBox();
			this.panel27 = new Panel();
			this.CheckBox_DrevnyayaGineriya_Back = new PinkCheckBox();
			this.panel58 = new Panel();
			this.CheckBox_KrugliyTrahinot_Back = new PinkCheckBox();
			this.panel18 = new Panel();
			this.CheckBox_Barrakuda_Back = new PinkCheckBox();
			this.panel59 = new Panel();
			this.CheckBox_ObiknovennayaShuka_Back = new PinkCheckBox();
			this.panel28 = new Panel();
			this.CheckBox_Golavl_Back = new PinkCheckBox();
			this.panel60 = new Panel();
			this.CheckBox_KrasniyGorbil_Back = new PinkCheckBox();
			this.panel61 = new Panel();
			this.CheckBox_Plotva_PickUp = new PinkCheckBox();
			this.panel29 = new Panel();
			this.CheckBox_DrevnyayaGineriya_PickUp = new PinkCheckBox();
			this.panel62 = new Panel();
			this.CheckBox_KrugliyTrahinot_PickUp = new PinkCheckBox();
			this.panel19 = new Panel();
			this.CheckBox_Barrakuda_PickUp = new PinkCheckBox();
			this.panel63 = new Panel();
			this.label25 = new Label();
			this.panel30 = new Panel();
			this.label15 = new Label();
			this.panel64 = new Panel();
			this.label26 = new Label();
			this.panel20 = new Panel();
			this.label11 = new Label();
			this.panel65 = new Panel();
			this.CheckBox_ObiknovennayaShuka_PickUp = new PinkCheckBox();
			this.panel31 = new Panel();
			this.CheckBox_Golavl_PickUp = new PinkCheckBox();
			this.panel66 = new Panel();
			this.CheckBox_KrasniyGorbil_PickUp = new PinkCheckBox();
			this.panel67 = new Panel();
			this.label27 = new Label();
			this.panel32 = new Panel();
			this.label16 = new Label();
			this.panel68 = new Panel();
			this.label28 = new Label();
			this.panel11 = new Panel();
			this.CheckBox_Tarpon_Back = new PinkCheckBox();
			this.panel104 = new Panel();
			this.CheckBox_Tarpon_PickUp = new PinkCheckBox();
			this.panel105 = new Panel();
			this.label1 = new Label();
			this.panel96 = new Panel();
			this.CheckBox_ToksichniyOkun_Back = new PinkCheckBox();
			this.panel87 = new Panel();
			this.CheckBox_SudakObiknovenniy_Back = new PinkCheckBox();
			this.panel97 = new Panel();
			this.CheckBox_ToksichniyOkun_PickUp = new PinkCheckBox();
			this.panel84 = new Panel();
			this.CheckBox_SomObiknovenniy_Back = new PinkCheckBox();
			this.panel98 = new Panel();
			this.label38 = new Label();
			this.panel88 = new Panel();
			this.CheckBox_SudakObiknovenniy_PickUp = new PinkCheckBox();
			this.panel99 = new Panel();
			this.CheckBox_TemniyGorbil_Back = new PinkCheckBox();
			this.panel85 = new Panel();
			this.CheckBox_SomObiknovenniy_PickUp = new PinkCheckBox();
			this.panel100 = new Panel();
			this.CheckBox_TemniyGorbil_PickUp = new PinkCheckBox();
			this.panel101 = new Panel();
			this.label39 = new Label();
			this.panel89 = new Panel();
			this.label35 = new Label();
			this.panel86 = new Panel();
			this.label34 = new Label();
			this.panel90 = new Panel();
			this.CheckBox_Sterlyad_Back = new PinkCheckBox();
			this.panel81 = new Panel();
			this.CheckBox_SnukObiknovenniy_Back = new PinkCheckBox();
			this.panel91 = new Panel();
			this.CheckBox_StalnogoloviyLosos_Back = new PinkCheckBox();
			this.panel78 = new Panel();
			this.CheckBox_Seriola_Back = new PinkCheckBox();
			this.panel92 = new Panel();
			this.CheckBox_Sterlyad_PickUp = new PinkCheckBox();
			this.panel82 = new Panel();
			this.CheckBox_SnukObiknovenniy_PickUp = new PinkCheckBox();
			this.panel93 = new Panel();
			this.label36 = new Label();
			this.panel83 = new Panel();
			this.label33 = new Label();
			this.panel94 = new Panel();
			this.CheckBox_StalnogoloviyLosos_PickUp = new PinkCheckBox();
			this.panel95 = new Panel();
			this.label37 = new Label();
			this.panel75 = new Panel();
			this.CheckBox_SerebryaniyKaras_Back = new PinkCheckBox();
			this.panel79 = new Panel();
			this.CheckBox_Seriola_PickUp = new PinkCheckBox();
			this.panel80 = new Panel();
			this.label32 = new Label();
			this.panel76 = new Panel();
			this.CheckBox_SerebryaniyKaras_PickUp = new PinkCheckBox();
			this.panel77 = new Panel();
			this.label31 = new Label();
			this.panel15.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panel16.SuspendLayout();
			this.panel17.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel102.SuspendLayout();
			this.panel103.SuspendLayout();
			this.panel72.SuspendLayout();
			this.panel69.SuspendLayout();
			this.panel73.SuspendLayout();
			this.panel74.SuspendLayout();
			this.panel42.SuspendLayout();
			this.panel70.SuspendLayout();
			this.panel33.SuspendLayout();
			this.panel71.SuspendLayout();
			this.panel43.SuspendLayout();
			this.panel34.SuspendLayout();
			this.panel44.SuspendLayout();
			this.panel35.SuspendLayout();
			this.panel45.SuspendLayout();
			this.panel36.SuspendLayout();
			this.panel46.SuspendLayout();
			this.panel37.SuspendLayout();
			this.panel47.SuspendLayout();
			this.panel38.SuspendLayout();
			this.panel48.SuspendLayout();
			this.panel39.SuspendLayout();
			this.panel49.SuspendLayout();
			this.panel40.SuspendLayout();
			this.panel50.SuspendLayout();
			this.panel41.SuspendLayout();
			this.panel51.SuspendLayout();
			this.panel24.SuspendLayout();
			this.panel52.SuspendLayout();
			this.panel21.SuspendLayout();
			this.panel53.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel54.SuspendLayout();
			this.panel22.SuspendLayout();
			this.panel55.SuspendLayout();
			this.panel26.SuspendLayout();
			this.panel56.SuspendLayout();
			this.panel23.SuspendLayout();
			this.panel57.SuspendLayout();
			this.panel27.SuspendLayout();
			this.panel58.SuspendLayout();
			this.panel18.SuspendLayout();
			this.panel59.SuspendLayout();
			this.panel28.SuspendLayout();
			this.panel60.SuspendLayout();
			this.panel61.SuspendLayout();
			this.panel29.SuspendLayout();
			this.panel62.SuspendLayout();
			this.panel19.SuspendLayout();
			this.panel63.SuspendLayout();
			this.panel30.SuspendLayout();
			this.panel64.SuspendLayout();
			this.panel20.SuspendLayout();
			this.panel65.SuspendLayout();
			this.panel31.SuspendLayout();
			this.panel66.SuspendLayout();
			this.panel67.SuspendLayout();
			this.panel32.SuspendLayout();
			this.panel68.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel104.SuspendLayout();
			this.panel105.SuspendLayout();
			this.panel96.SuspendLayout();
			this.panel87.SuspendLayout();
			this.panel97.SuspendLayout();
			this.panel84.SuspendLayout();
			this.panel98.SuspendLayout();
			this.panel88.SuspendLayout();
			this.panel99.SuspendLayout();
			this.panel85.SuspendLayout();
			this.panel100.SuspendLayout();
			this.panel101.SuspendLayout();
			this.panel89.SuspendLayout();
			this.panel86.SuspendLayout();
			this.panel90.SuspendLayout();
			this.panel81.SuspendLayout();
			this.panel91.SuspendLayout();
			this.panel78.SuspendLayout();
			this.panel92.SuspendLayout();
			this.panel82.SuspendLayout();
			this.panel93.SuspendLayout();
			this.panel83.SuspendLayout();
			this.panel94.SuspendLayout();
			this.panel95.SuspendLayout();
			this.panel75.SuspendLayout();
			this.panel79.SuspendLayout();
			this.panel80.SuspendLayout();
			this.panel76.SuspendLayout();
			this.panel77.SuspendLayout();
			base.SuspendLayout();
			this.panel15.BackColor = Color.FromArgb(17, 17, 17);
			this.panel15.Controls.Add(this.CheckBox_ModestCatch_Back);
			this.panel15.Location = new Point(354, 6);
			this.panel15.Name = "panel15";
			this.panel15.Size = new Size(109, 35);
			this.panel15.TabIndex = 28;
			this.CheckBox_ModestCatch_Back.BackColor = Color.Transparent;
			this.CheckBox_ModestCatch_Back.CheckMarkColor = Color.White;
			this.CheckBox_ModestCatch_Back.CheckMarkOffsetY = -2;
			this.CheckBox_ModestCatch_Back.CornerRadius = 5;
			this.CheckBox_ModestCatch_Back.Cursor = Cursors.Hand;
			this.CheckBox_ModestCatch_Back.Location = new Point(40, 3);
			this.CheckBox_ModestCatch_Back.Name = "CheckBox_ModestCatch_Back";
			this.CheckBox_ModestCatch_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_ModestCatch_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_ModestCatch_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_ModestCatch_Back.Size = new Size(26, 26);
			this.CheckBox_ModestCatch_Back.TabIndex = 1;
			this.CheckBox_ModestCatch_Back.TabStop = false;
			this.CheckBox_ModestCatch_Back.Text = "pinkCheckBox5";
			this.panel14.BackColor = Color.FromArgb(17, 17, 17);
			this.panel14.Controls.Add(this.CheckBox_TrophyCatch_Back);
			this.panel14.Location = new Point(354, 129);
			this.panel14.Name = "panel14";
			this.panel14.Size = new Size(109, 35);
			this.panel14.TabIndex = 19;
			this.CheckBox_TrophyCatch_Back.BackColor = Color.Transparent;
			this.CheckBox_TrophyCatch_Back.CheckMarkColor = Color.White;
			this.CheckBox_TrophyCatch_Back.CheckMarkOffsetY = -2;
			this.CheckBox_TrophyCatch_Back.CornerRadius = 5;
			this.CheckBox_TrophyCatch_Back.Cursor = Cursors.Hand;
			this.CheckBox_TrophyCatch_Back.Location = new Point(40, 3);
			this.CheckBox_TrophyCatch_Back.Name = "CheckBox_TrophyCatch_Back";
			this.CheckBox_TrophyCatch_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_TrophyCatch_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_TrophyCatch_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_TrophyCatch_Back.Size = new Size(26, 26);
			this.CheckBox_TrophyCatch_Back.TabIndex = 1;
			this.CheckBox_TrophyCatch_Back.TabStop = false;
			this.CheckBox_TrophyCatch_Back.Text = "pinkCheckBox8";
			this.panel16.BackColor = Color.FromArgb(17, 17, 17);
			this.panel16.Controls.Add(this.CheckBox_ModestCatch_PickUp);
			this.panel16.Location = new Point(239, 6);
			this.panel16.Name = "panel16";
			this.panel16.Size = new Size(109, 35);
			this.panel16.TabIndex = 26;
			this.CheckBox_ModestCatch_PickUp.BackColor = Color.Transparent;
			this.CheckBox_ModestCatch_PickUp.Checked = true;
			this.CheckBox_ModestCatch_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_ModestCatch_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_ModestCatch_PickUp.CornerRadius = 5;
			this.CheckBox_ModestCatch_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_ModestCatch_PickUp.Location = new Point(41, 4);
			this.CheckBox_ModestCatch_PickUp.Name = "CheckBox_ModestCatch_PickUp";
			this.CheckBox_ModestCatch_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_ModestCatch_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_ModestCatch_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_ModestCatch_PickUp.Size = new Size(26, 26);
			this.CheckBox_ModestCatch_PickUp.TabIndex = 0;
			this.CheckBox_ModestCatch_PickUp.TabStop = false;
			this.CheckBox_ModestCatch_PickUp.Text = "pinkCheckBox1";
			this.panel17.BackColor = Color.FromArgb(32, 35, 32);
			this.panel17.Controls.Add(this.label10);
			this.panel17.Location = new Point(0, 6);
			this.panel17.Name = "panel17";
			this.panel17.Size = new Size(233, 35);
			this.panel17.TabIndex = 24;
			this.label10.AutoSize = true;
			this.label10.Font = new Font("Verdana", 12f);
			this.label10.ForeColor = Color.White;
			this.label10.Location = new Point(20, 7);
			this.label10.Name = "label10";
			this.label10.Size = new Size(136, 18);
			this.label10.TabIndex = 12;
			this.label10.Text = "Скромный улов";
			this.label10.TextAlign = ContentAlignment.MiddleCenter;
			this.panel13.BackColor = Color.FromArgb(17, 17, 17);
			this.panel13.Controls.Add(this.CheckBox_TrophyCatch_PickUp);
			this.panel13.Location = new Point(239, 129);
			this.panel13.Name = "panel13";
			this.panel13.Size = new Size(109, 35);
			this.panel13.TabIndex = 20;
			this.CheckBox_TrophyCatch_PickUp.BackColor = Color.Transparent;
			this.CheckBox_TrophyCatch_PickUp.Checked = true;
			this.CheckBox_TrophyCatch_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_TrophyCatch_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_TrophyCatch_PickUp.CornerRadius = 5;
			this.CheckBox_TrophyCatch_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_TrophyCatch_PickUp.Location = new Point(41, 4);
			this.CheckBox_TrophyCatch_PickUp.Name = "CheckBox_TrophyCatch_PickUp";
			this.CheckBox_TrophyCatch_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_TrophyCatch_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_TrophyCatch_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_TrophyCatch_PickUp.Size = new Size(26, 26);
			this.CheckBox_TrophyCatch_PickUp.TabIndex = 1;
			this.CheckBox_TrophyCatch_PickUp.TabStop = false;
			this.CheckBox_TrophyCatch_PickUp.Text = "pinkCheckBox4";
			this.panel12.BackColor = Color.FromArgb(17, 17, 17);
			this.panel12.Controls.Add(this.CheckBox_RecordCatch_Back);
			this.panel12.Location = new Point(354, 88);
			this.panel12.Name = "panel12";
			this.panel12.Size = new Size(109, 35);
			this.panel12.TabIndex = 21;
			this.CheckBox_RecordCatch_Back.BackColor = Color.Transparent;
			this.CheckBox_RecordCatch_Back.CheckMarkColor = Color.White;
			this.CheckBox_RecordCatch_Back.CheckMarkOffsetY = -2;
			this.CheckBox_RecordCatch_Back.CornerRadius = 5;
			this.CheckBox_RecordCatch_Back.Cursor = Cursors.Hand;
			this.CheckBox_RecordCatch_Back.Location = new Point(40, 3);
			this.CheckBox_RecordCatch_Back.Name = "CheckBox_RecordCatch_Back";
			this.CheckBox_RecordCatch_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_RecordCatch_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_RecordCatch_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_RecordCatch_Back.Size = new Size(26, 26);
			this.CheckBox_RecordCatch_Back.TabIndex = 1;
			this.CheckBox_RecordCatch_Back.TabStop = false;
			this.CheckBox_RecordCatch_Back.Text = "pinkCheckBox7";
			this.panel10.BackColor = Color.FromArgb(17, 17, 17);
			this.panel10.Controls.Add(this.CheckBox_RecordCatch_PickUp);
			this.panel10.Location = new Point(239, 88);
			this.panel10.Name = "panel10";
			this.panel10.Size = new Size(109, 35);
			this.panel10.TabIndex = 22;
			this.CheckBox_RecordCatch_PickUp.BackColor = Color.Transparent;
			this.CheckBox_RecordCatch_PickUp.Checked = true;
			this.CheckBox_RecordCatch_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_RecordCatch_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_RecordCatch_PickUp.CornerRadius = 5;
			this.CheckBox_RecordCatch_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_RecordCatch_PickUp.Location = new Point(41, 4);
			this.CheckBox_RecordCatch_PickUp.Name = "CheckBox_RecordCatch_PickUp";
			this.CheckBox_RecordCatch_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_RecordCatch_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_RecordCatch_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_RecordCatch_PickUp.Size = new Size(26, 26);
			this.CheckBox_RecordCatch_PickUp.TabIndex = 1;
			this.CheckBox_RecordCatch_PickUp.TabStop = false;
			this.CheckBox_RecordCatch_PickUp.Text = "pinkCheckBox3";
			this.panel9.BackColor = Color.FromArgb(17, 17, 17);
			this.panel9.Controls.Add(this.CheckBox_GoodCatch_Back);
			this.panel9.Location = new Point(354, 47);
			this.panel9.Name = "panel9";
			this.panel9.Size = new Size(109, 35);
			this.panel9.TabIndex = 29;
			this.CheckBox_GoodCatch_Back.BackColor = Color.Transparent;
			this.CheckBox_GoodCatch_Back.CheckMarkColor = Color.White;
			this.CheckBox_GoodCatch_Back.CheckMarkOffsetY = -2;
			this.CheckBox_GoodCatch_Back.CornerRadius = 5;
			this.CheckBox_GoodCatch_Back.Cursor = Cursors.Hand;
			this.CheckBox_GoodCatch_Back.Location = new Point(40, 3);
			this.CheckBox_GoodCatch_Back.Name = "CheckBox_GoodCatch_Back";
			this.CheckBox_GoodCatch_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_GoodCatch_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_GoodCatch_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_GoodCatch_Back.Size = new Size(26, 26);
			this.CheckBox_GoodCatch_Back.TabIndex = 1;
			this.CheckBox_GoodCatch_Back.TabStop = false;
			this.CheckBox_GoodCatch_Back.Text = "pinkCheckBox6";
			this.panel8.BackColor = Color.FromArgb(17, 17, 17);
			this.panel8.Controls.Add(this.CheckBox_GoodCatch_PickUp);
			this.panel8.Location = new Point(239, 47);
			this.panel8.Name = "panel8";
			this.panel8.Size = new Size(109, 35);
			this.panel8.TabIndex = 27;
			this.CheckBox_GoodCatch_PickUp.BackColor = Color.Transparent;
			this.CheckBox_GoodCatch_PickUp.Checked = true;
			this.CheckBox_GoodCatch_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_GoodCatch_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_GoodCatch_PickUp.CornerRadius = 5;
			this.CheckBox_GoodCatch_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_GoodCatch_PickUp.Location = new Point(41, 4);
			this.CheckBox_GoodCatch_PickUp.Name = "CheckBox_GoodCatch_PickUp";
			this.CheckBox_GoodCatch_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_GoodCatch_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_GoodCatch_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_GoodCatch_PickUp.Size = new Size(26, 26);
			this.CheckBox_GoodCatch_PickUp.TabIndex = 1;
			this.CheckBox_GoodCatch_PickUp.TabStop = false;
			this.CheckBox_GoodCatch_PickUp.Text = "pinkCheckBox2";
			this.panel5.BackColor = Color.FromArgb(25, 135, 98);
			this.panel5.Controls.Add(this.label9);
			this.panel5.Location = new Point(0, 129);
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size(233, 35);
			this.panel5.TabIndex = 25;
			this.label9.AutoSize = true;
			this.label9.Font = new Font("Verdana", 12f);
			this.label9.ForeColor = Color.White;
			this.label9.Location = new Point(20, 7);
			this.label9.Name = "label9";
			this.label9.Size = new Size(148, 18);
			this.label9.TabIndex = 12;
			this.label9.Text = "Трофейный улов";
			this.label9.TextAlign = ContentAlignment.MiddleCenter;
			this.panel4.BackColor = Color.FromArgb(138, 27, 39);
			this.panel4.Controls.Add(this.label8);
			this.panel4.Location = new Point(0, 88);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(233, 35);
			this.panel4.TabIndex = 23;
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Verdana", 12f);
			this.label8.ForeColor = Color.White;
			this.label8.Location = new Point(20, 7);
			this.label8.Name = "label8";
			this.label8.Size = new Size(144, 18);
			this.label8.TabIndex = 12;
			this.label8.Text = "Рекордный улов";
			this.label8.TextAlign = ContentAlignment.MiddleCenter;
			this.panel3.BackColor = Color.FromArgb(37, 79, 112);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Location = new Point(0, 47);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(233, 35);
			this.panel3.TabIndex = 18;
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Verdana", 12f);
			this.label7.ForeColor = Color.White;
			this.label7.Location = new Point(20, 7);
			this.label7.Name = "label7";
			this.label7.Size = new Size(127, 18);
			this.label7.TabIndex = 12;
			this.label7.Text = "Хороший улов";
			this.label7.TextAlign = ContentAlignment.MiddleCenter;
			this.panel7.BackColor = Color.FromArgb(17, 17, 17);
			this.panel7.Controls.Add(this.CheckBox_Albula_Back);
			this.panel7.Location = new Point(354, 180);
			this.panel7.Name = "panel7";
			this.panel7.Size = new Size(109, 35);
			this.panel7.TabIndex = 32;
			this.CheckBox_Albula_Back.BackColor = Color.Transparent;
			this.CheckBox_Albula_Back.CheckMarkColor = Color.White;
			this.CheckBox_Albula_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Albula_Back.CornerRadius = 5;
			this.CheckBox_Albula_Back.Cursor = Cursors.Hand;
			this.CheckBox_Albula_Back.Location = new Point(41, 4);
			this.CheckBox_Albula_Back.Name = "CheckBox_Albula_Back";
			this.CheckBox_Albula_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Albula_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Albula_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Albula_Back.Size = new Size(26, 26);
			this.CheckBox_Albula_Back.TabIndex = 1;
			this.CheckBox_Albula_Back.TabStop = false;
			this.CheckBox_Albula_Back.Text = "pinkCheckBox16";
			this.panel6.BackColor = Color.FromArgb(17, 17, 17);
			this.panel6.Controls.Add(this.CheckBox_Albula_PickUp);
			this.panel6.Location = new Point(239, 180);
			this.panel6.Name = "panel6";
			this.panel6.Size = new Size(109, 35);
			this.panel6.TabIndex = 31;
			this.CheckBox_Albula_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Albula_PickUp.Checked = true;
			this.CheckBox_Albula_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Albula_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Albula_PickUp.CornerRadius = 5;
			this.CheckBox_Albula_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Albula_PickUp.Location = new Point(41, 4);
			this.CheckBox_Albula_PickUp.Name = "CheckBox_Albula_PickUp";
			this.CheckBox_Albula_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Albula_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Albula_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Albula_PickUp.Size = new Size(26, 26);
			this.CheckBox_Albula_PickUp.TabIndex = 1;
			this.CheckBox_Albula_PickUp.TabStop = false;
			this.CheckBox_Albula_PickUp.Text = "pinkCheckBox9";
			this.panel2.BackColor = Color.FromArgb(17, 17, 17);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Location = new Point(0, 180);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(233, 35);
			this.panel2.TabIndex = 30;
			this.label6.AutoSize = true;
			this.label6.Font = new Font("Verdana", 12f);
			this.label6.ForeColor = Color.White;
			this.label6.Location = new Point(20, 7);
			this.label6.Name = "label6";
			this.label6.Size = new Size(77, 18);
			this.label6.TabIndex = 12;
			this.label6.Text = "Альбула";
			this.label6.TextAlign = ContentAlignment.MiddleCenter;
			this.panel1.BackColor = Color.FromArgb(17, 17, 17);
			this.panel1.Controls.Add(this.CheckBox_Lesh_Back);
			this.panel1.Location = new Point(354, 631);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(109, 35);
			this.panel1.TabIndex = 158;
			this.CheckBox_Lesh_Back.BackColor = Color.Transparent;
			this.CheckBox_Lesh_Back.CheckMarkColor = Color.White;
			this.CheckBox_Lesh_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Lesh_Back.CornerRadius = 5;
			this.CheckBox_Lesh_Back.Cursor = Cursors.Hand;
			this.CheckBox_Lesh_Back.Location = new Point(41, 4);
			this.CheckBox_Lesh_Back.Name = "CheckBox_Lesh_Back";
			this.CheckBox_Lesh_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Lesh_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Lesh_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Lesh_Back.Size = new Size(26, 26);
			this.CheckBox_Lesh_Back.TabIndex = 1;
			this.CheckBox_Lesh_Back.TabStop = false;
			this.CheckBox_Lesh_Back.Text = "pinkCheckBox65";
			this.panel102.BackColor = Color.FromArgb(17, 17, 17);
			this.panel102.Controls.Add(this.CheckBox_Lesh_PickUp);
			this.panel102.Location = new Point(239, 631);
			this.panel102.Name = "panel102";
			this.panel102.Size = new Size(109, 35);
			this.panel102.TabIndex = 157;
			this.CheckBox_Lesh_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Lesh_PickUp.Checked = true;
			this.CheckBox_Lesh_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Lesh_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Lesh_PickUp.CornerRadius = 5;
			this.CheckBox_Lesh_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Lesh_PickUp.Location = new Point(41, 4);
			this.CheckBox_Lesh_PickUp.Name = "CheckBox_Lesh_PickUp";
			this.CheckBox_Lesh_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Lesh_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Lesh_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Lesh_PickUp.Size = new Size(26, 26);
			this.CheckBox_Lesh_PickUp.TabIndex = 1;
			this.CheckBox_Lesh_PickUp.TabStop = false;
			this.CheckBox_Lesh_PickUp.Text = "pinkCheckBox66";
			this.panel103.BackColor = Color.FromArgb(17, 17, 17);
			this.panel103.Controls.Add(this.label3);
			this.panel103.Location = new Point(0, 631);
			this.panel103.Name = "panel103";
			this.panel103.Size = new Size(233, 35);
			this.panel103.TabIndex = 156;
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Verdana", 12f);
			this.label3.ForeColor = Color.White;
			this.label3.Location = new Point(20, 7);
			this.label3.Name = "label3";
			this.label3.Size = new Size(44, 18);
			this.label3.TabIndex = 12;
			this.label3.Text = "Лещ";
			this.label3.TextAlign = ContentAlignment.MiddleCenter;
			this.panel72.BackColor = Color.FromArgb(17, 17, 17);
			this.panel72.Controls.Add(this.CheckBox_Sazan_Back);
			this.panel72.Location = new Point(354, 1000);
			this.panel72.Name = "panel72";
			this.panel72.Size = new Size(109, 35);
			this.panel72.TabIndex = 155;
			this.CheckBox_Sazan_Back.BackColor = Color.Transparent;
			this.CheckBox_Sazan_Back.CheckMarkColor = Color.White;
			this.CheckBox_Sazan_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Sazan_Back.CornerRadius = 5;
			this.CheckBox_Sazan_Back.Cursor = Cursors.Hand;
			this.CheckBox_Sazan_Back.Location = new Point(41, 4);
			this.CheckBox_Sazan_Back.Name = "CheckBox_Sazan_Back";
			this.CheckBox_Sazan_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Sazan_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Sazan_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Sazan_Back.Size = new Size(26, 26);
			this.CheckBox_Sazan_Back.TabIndex = 1;
			this.CheckBox_Sazan_Back.TabStop = false;
			this.CheckBox_Sazan_Back.Text = "pinkCheckBox48";
			this.panel69.BackColor = Color.FromArgb(17, 17, 17);
			this.panel69.Controls.Add(this.CheckBox_Ruster_Back);
			this.panel69.Location = new Point(354, 959);
			this.panel69.Name = "panel69";
			this.panel69.Size = new Size(109, 35);
			this.panel69.TabIndex = 154;
			this.CheckBox_Ruster_Back.BackColor = Color.Transparent;
			this.CheckBox_Ruster_Back.CheckMarkColor = Color.White;
			this.CheckBox_Ruster_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Ruster_Back.CornerRadius = 5;
			this.CheckBox_Ruster_Back.Cursor = Cursors.Hand;
			this.CheckBox_Ruster_Back.Location = new Point(41, 4);
			this.CheckBox_Ruster_Back.Name = "CheckBox_Ruster_Back";
			this.CheckBox_Ruster_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Ruster_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Ruster_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Ruster_Back.Size = new Size(26, 26);
			this.CheckBox_Ruster_Back.TabIndex = 1;
			this.CheckBox_Ruster_Back.TabStop = false;
			this.CheckBox_Ruster_Back.Text = "pinkCheckBox45";
			this.panel73.BackColor = Color.FromArgb(17, 17, 17);
			this.panel73.Controls.Add(this.CheckBox_Sazan_PickUp);
			this.panel73.Location = new Point(239, 1000);
			this.panel73.Name = "panel73";
			this.panel73.Size = new Size(109, 35);
			this.panel73.TabIndex = 153;
			this.CheckBox_Sazan_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Sazan_PickUp.Checked = true;
			this.CheckBox_Sazan_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Sazan_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Sazan_PickUp.CornerRadius = 5;
			this.CheckBox_Sazan_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Sazan_PickUp.Location = new Point(41, 4);
			this.CheckBox_Sazan_PickUp.Name = "CheckBox_Sazan_PickUp";
			this.CheckBox_Sazan_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Sazan_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Sazan_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Sazan_PickUp.Size = new Size(26, 26);
			this.CheckBox_Sazan_PickUp.TabIndex = 1;
			this.CheckBox_Sazan_PickUp.TabStop = false;
			this.CheckBox_Sazan_PickUp.Text = "pinkCheckBox47";
			this.panel74.BackColor = Color.FromArgb(17, 17, 17);
			this.panel74.Controls.Add(this.label30);
			this.panel74.Location = new Point(0, 1000);
			this.panel74.Name = "panel74";
			this.panel74.Size = new Size(233, 35);
			this.panel74.TabIndex = 150;
			this.label30.AutoSize = true;
			this.label30.Font = new Font("Verdana", 12f);
			this.label30.ForeColor = Color.White;
			this.label30.Location = new Point(20, 7);
			this.label30.Name = "label30";
			this.label30.Size = new Size(58, 18);
			this.label30.TabIndex = 12;
			this.label30.Text = "Сазан";
			this.label30.TextAlign = ContentAlignment.MiddleCenter;
			this.panel42.BackColor = Color.FromArgb(17, 17, 17);
			this.panel42.Controls.Add(this.CheckBox_RechnoyOkun_Back);
			this.panel42.Location = new Point(354, 918);
			this.panel42.Name = "panel42";
			this.panel42.Size = new Size(109, 35);
			this.panel42.TabIndex = 149;
			this.CheckBox_RechnoyOkun_Back.BackColor = Color.Transparent;
			this.CheckBox_RechnoyOkun_Back.CheckMarkColor = Color.White;
			this.CheckBox_RechnoyOkun_Back.CheckMarkOffsetY = -2;
			this.CheckBox_RechnoyOkun_Back.CornerRadius = 5;
			this.CheckBox_RechnoyOkun_Back.Cursor = Cursors.Hand;
			this.CheckBox_RechnoyOkun_Back.Location = new Point(41, 4);
			this.CheckBox_RechnoyOkun_Back.Name = "CheckBox_RechnoyOkun_Back";
			this.CheckBox_RechnoyOkun_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_RechnoyOkun_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_RechnoyOkun_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_RechnoyOkun_Back.Size = new Size(26, 26);
			this.CheckBox_RechnoyOkun_Back.TabIndex = 1;
			this.CheckBox_RechnoyOkun_Back.TabStop = false;
			this.CheckBox_RechnoyOkun_Back.Text = "pinkCheckBox44";
			this.panel70.BackColor = Color.FromArgb(17, 17, 17);
			this.panel70.Controls.Add(this.CheckBox_Ruster_PickUp);
			this.panel70.Location = new Point(239, 959);
			this.panel70.Name = "panel70";
			this.panel70.Size = new Size(109, 35);
			this.panel70.TabIndex = 152;
			this.CheckBox_Ruster_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Ruster_PickUp.Checked = true;
			this.CheckBox_Ruster_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Ruster_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Ruster_PickUp.CornerRadius = 5;
			this.CheckBox_Ruster_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Ruster_PickUp.Location = new Point(41, 4);
			this.CheckBox_Ruster_PickUp.Name = "CheckBox_Ruster_PickUp";
			this.CheckBox_Ruster_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Ruster_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Ruster_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Ruster_PickUp.Size = new Size(26, 26);
			this.CheckBox_Ruster_PickUp.TabIndex = 1;
			this.CheckBox_Ruster_PickUp.TabStop = false;
			this.CheckBox_Ruster_PickUp.Text = "pinkCheckBox46";
			this.panel33.BackColor = Color.FromArgb(17, 17, 17);
			this.panel33.Controls.Add(this.CheckBox_Krasnoperka_Back);
			this.panel33.Location = new Point(354, 508);
			this.panel33.Name = "panel33";
			this.panel33.Size = new Size(109, 35);
			this.panel33.TabIndex = 122;
			this.CheckBox_Krasnoperka_Back.BackColor = Color.Transparent;
			this.CheckBox_Krasnoperka_Back.CheckMarkColor = Color.White;
			this.CheckBox_Krasnoperka_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Krasnoperka_Back.CornerRadius = 5;
			this.CheckBox_Krasnoperka_Back.Cursor = Cursors.Hand;
			this.CheckBox_Krasnoperka_Back.Location = new Point(41, 4);
			this.CheckBox_Krasnoperka_Back.Name = "CheckBox_Krasnoperka_Back";
			this.CheckBox_Krasnoperka_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Krasnoperka_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Krasnoperka_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Krasnoperka_Back.Size = new Size(26, 26);
			this.CheckBox_Krasnoperka_Back.TabIndex = 1;
			this.CheckBox_Krasnoperka_Back.TabStop = false;
			this.CheckBox_Krasnoperka_Back.Text = "pinkCheckBox26";
			this.panel71.BackColor = Color.FromArgb(17, 17, 17);
			this.panel71.Controls.Add(this.label29);
			this.panel71.Location = new Point(0, 959);
			this.panel71.Name = "panel71";
			this.panel71.Size = new Size(233, 35);
			this.panel71.TabIndex = 151;
			this.label29.AutoSize = true;
			this.label29.Font = new Font("Verdana", 12f);
			this.label29.ForeColor = Color.White;
			this.label29.Location = new Point(20, 7);
			this.label29.Name = "label29";
			this.label29.Size = new Size(63, 18);
			this.label29.TabIndex = 12;
			this.label29.Text = "Рустер";
			this.label29.TextAlign = ContentAlignment.MiddleCenter;
			this.panel43.BackColor = Color.FromArgb(17, 17, 17);
			this.panel43.Controls.Add(this.CheckBox_RechnoyOkun_PickUp);
			this.panel43.Location = new Point(239, 918);
			this.panel43.Name = "panel43";
			this.panel43.Size = new Size(109, 35);
			this.panel43.TabIndex = 148;
			this.CheckBox_RechnoyOkun_PickUp.BackColor = Color.Transparent;
			this.CheckBox_RechnoyOkun_PickUp.Checked = true;
			this.CheckBox_RechnoyOkun_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_RechnoyOkun_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_RechnoyOkun_PickUp.CornerRadius = 5;
			this.CheckBox_RechnoyOkun_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_RechnoyOkun_PickUp.Location = new Point(41, 4);
			this.CheckBox_RechnoyOkun_PickUp.Name = "CheckBox_RechnoyOkun_PickUp";
			this.CheckBox_RechnoyOkun_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_RechnoyOkun_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_RechnoyOkun_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_RechnoyOkun_PickUp.Size = new Size(26, 26);
			this.CheckBox_RechnoyOkun_PickUp.TabIndex = 1;
			this.CheckBox_RechnoyOkun_PickUp.TabStop = false;
			this.CheckBox_RechnoyOkun_PickUp.Text = "pinkCheckBox43";
			this.panel34.BackColor = Color.FromArgb(17, 17, 17);
			this.panel34.Controls.Add(this.CheckBox_Krasnoperka_PickUp);
			this.panel34.Location = new Point(239, 508);
			this.panel34.Name = "panel34";
			this.panel34.Size = new Size(109, 35);
			this.panel34.TabIndex = 121;
			this.CheckBox_Krasnoperka_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Krasnoperka_PickUp.Checked = true;
			this.CheckBox_Krasnoperka_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Krasnoperka_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Krasnoperka_PickUp.CornerRadius = 5;
			this.CheckBox_Krasnoperka_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Krasnoperka_PickUp.Location = new Point(41, 4);
			this.CheckBox_Krasnoperka_PickUp.Name = "CheckBox_Krasnoperka_PickUp";
			this.CheckBox_Krasnoperka_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Krasnoperka_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Krasnoperka_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Krasnoperka_PickUp.Size = new Size(26, 26);
			this.CheckBox_Krasnoperka_PickUp.TabIndex = 1;
			this.CheckBox_Krasnoperka_PickUp.TabStop = false;
			this.CheckBox_Krasnoperka_PickUp.Text = "pinkCheckBox25";
			this.panel44.BackColor = Color.FromArgb(17, 17, 17);
			this.panel44.Controls.Add(this.label20);
			this.panel44.Location = new Point(0, 918);
			this.panel44.Name = "panel44";
			this.panel44.Size = new Size(233, 35);
			this.panel44.TabIndex = 147;
			this.label20.AutoSize = true;
			this.label20.Font = new Font("Verdana", 12f);
			this.label20.ForeColor = Color.White;
			this.label20.Location = new Point(20, 7);
			this.label20.Name = "label20";
			this.label20.Size = new Size(121, 18);
			this.label20.TabIndex = 12;
			this.label20.Text = "Речной окунь";
			this.label20.TextAlign = ContentAlignment.MiddleCenter;
			this.panel35.BackColor = Color.FromArgb(17, 17, 17);
			this.panel35.Controls.Add(this.label17);
			this.panel35.Location = new Point(0, 508);
			this.panel35.Name = "panel35";
			this.panel35.Size = new Size(233, 35);
			this.panel35.TabIndex = 120;
			this.label17.AutoSize = true;
			this.label17.Font = new Font("Verdana", 12f);
			this.label17.ForeColor = Color.White;
			this.label17.Location = new Point(20, 7);
			this.label17.Name = "label17";
			this.label17.Size = new Size(117, 18);
			this.label17.TabIndex = 12;
			this.label17.Text = "Краснопёрка";
			this.label17.TextAlign = ContentAlignment.MiddleCenter;
			this.panel45.BackColor = Color.FromArgb(17, 17, 17);
			this.panel45.Controls.Add(this.CheckBox_RadujnayaForel_Back);
			this.panel45.Location = new Point(354, 877);
			this.panel45.Name = "panel45";
			this.panel45.Size = new Size(109, 35);
			this.panel45.TabIndex = 146;
			this.CheckBox_RadujnayaForel_Back.BackColor = Color.Transparent;
			this.CheckBox_RadujnayaForel_Back.CheckMarkColor = Color.White;
			this.CheckBox_RadujnayaForel_Back.CheckMarkOffsetY = -2;
			this.CheckBox_RadujnayaForel_Back.CornerRadius = 5;
			this.CheckBox_RadujnayaForel_Back.Cursor = Cursors.Hand;
			this.CheckBox_RadujnayaForel_Back.Location = new Point(41, 4);
			this.CheckBox_RadujnayaForel_Back.Name = "CheckBox_RadujnayaForel_Back";
			this.CheckBox_RadujnayaForel_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_RadujnayaForel_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_RadujnayaForel_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_RadujnayaForel_Back.Size = new Size(26, 26);
			this.CheckBox_RadujnayaForel_Back.TabIndex = 1;
			this.CheckBox_RadujnayaForel_Back.TabStop = false;
			this.CheckBox_RadujnayaForel_Back.Text = "pinkCheckBox41";
			this.panel36.BackColor = Color.FromArgb(17, 17, 17);
			this.panel36.Controls.Add(this.CheckBox_KorichneviySom_Back);
			this.panel36.Location = new Point(354, 467);
			this.panel36.Name = "panel36";
			this.panel36.Size = new Size(109, 35);
			this.panel36.TabIndex = 119;
			this.CheckBox_KorichneviySom_Back.BackColor = Color.Transparent;
			this.CheckBox_KorichneviySom_Back.CheckMarkColor = Color.White;
			this.CheckBox_KorichneviySom_Back.CheckMarkOffsetY = -2;
			this.CheckBox_KorichneviySom_Back.CornerRadius = 5;
			this.CheckBox_KorichneviySom_Back.Cursor = Cursors.Hand;
			this.CheckBox_KorichneviySom_Back.Location = new Point(41, 4);
			this.CheckBox_KorichneviySom_Back.Name = "CheckBox_KorichneviySom_Back";
			this.CheckBox_KorichneviySom_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_KorichneviySom_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_KorichneviySom_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_KorichneviySom_Back.Size = new Size(26, 26);
			this.CheckBox_KorichneviySom_Back.TabIndex = 1;
			this.CheckBox_KorichneviySom_Back.TabStop = false;
			this.CheckBox_KorichneviySom_Back.Text = "pinkCheckBox23";
			this.panel46.BackColor = Color.FromArgb(17, 17, 17);
			this.panel46.Controls.Add(this.CheckBox_PribrejniyBass_Back);
			this.panel46.Location = new Point(354, 836);
			this.panel46.Name = "panel46";
			this.panel46.Size = new Size(109, 35);
			this.panel46.TabIndex = 142;
			this.CheckBox_PribrejniyBass_Back.BackColor = Color.Transparent;
			this.CheckBox_PribrejniyBass_Back.CheckMarkColor = Color.White;
			this.CheckBox_PribrejniyBass_Back.CheckMarkOffsetY = -2;
			this.CheckBox_PribrejniyBass_Back.CornerRadius = 5;
			this.CheckBox_PribrejniyBass_Back.Cursor = Cursors.Hand;
			this.CheckBox_PribrejniyBass_Back.Location = new Point(41, 4);
			this.CheckBox_PribrejniyBass_Back.Name = "CheckBox_PribrejniyBass_Back";
			this.CheckBox_PribrejniyBass_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_PribrejniyBass_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_PribrejniyBass_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_PribrejniyBass_Back.Size = new Size(26, 26);
			this.CheckBox_PribrejniyBass_Back.TabIndex = 1;
			this.CheckBox_PribrejniyBass_Back.TabStop = false;
			this.CheckBox_PribrejniyBass_Back.Text = "pinkCheckBox40";
			this.panel37.BackColor = Color.FromArgb(17, 17, 17);
			this.panel37.Controls.Add(this.CheckBox_ZerkalniyKarp_Back);
			this.panel37.Location = new Point(354, 426);
			this.panel37.Name = "panel37";
			this.panel37.Size = new Size(109, 35);
			this.panel37.TabIndex = 115;
			this.CheckBox_ZerkalniyKarp_Back.BackColor = Color.Transparent;
			this.CheckBox_ZerkalniyKarp_Back.CheckMarkColor = Color.White;
			this.CheckBox_ZerkalniyKarp_Back.CheckMarkOffsetY = -2;
			this.CheckBox_ZerkalniyKarp_Back.CornerRadius = 5;
			this.CheckBox_ZerkalniyKarp_Back.Cursor = Cursors.Hand;
			this.CheckBox_ZerkalniyKarp_Back.Location = new Point(41, 4);
			this.CheckBox_ZerkalniyKarp_Back.Name = "CheckBox_ZerkalniyKarp_Back";
			this.CheckBox_ZerkalniyKarp_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_ZerkalniyKarp_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_ZerkalniyKarp_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_ZerkalniyKarp_Back.Size = new Size(26, 26);
			this.CheckBox_ZerkalniyKarp_Back.TabIndex = 1;
			this.CheckBox_ZerkalniyKarp_Back.TabStop = false;
			this.CheckBox_ZerkalniyKarp_Back.Text = "pinkCheckBox22";
			this.panel47.BackColor = Color.FromArgb(17, 17, 17);
			this.panel47.Controls.Add(this.CheckBox_RadujnayaForel_PickUp);
			this.panel47.Location = new Point(239, 877);
			this.panel47.Name = "panel47";
			this.panel47.Size = new Size(109, 35);
			this.panel47.TabIndex = 145;
			this.CheckBox_RadujnayaForel_PickUp.BackColor = Color.Transparent;
			this.CheckBox_RadujnayaForel_PickUp.Checked = true;
			this.CheckBox_RadujnayaForel_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_RadujnayaForel_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_RadujnayaForel_PickUp.CornerRadius = 5;
			this.CheckBox_RadujnayaForel_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_RadujnayaForel_PickUp.Location = new Point(41, 4);
			this.CheckBox_RadujnayaForel_PickUp.Name = "CheckBox_RadujnayaForel_PickUp";
			this.CheckBox_RadujnayaForel_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_RadujnayaForel_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_RadujnayaForel_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_RadujnayaForel_PickUp.Size = new Size(26, 26);
			this.CheckBox_RadujnayaForel_PickUp.TabIndex = 1;
			this.CheckBox_RadujnayaForel_PickUp.TabStop = false;
			this.CheckBox_RadujnayaForel_PickUp.Text = "pinkCheckBox42";
			this.panel38.BackColor = Color.FromArgb(17, 17, 17);
			this.panel38.Controls.Add(this.CheckBox_KorichneviySom_PickUp);
			this.panel38.Location = new Point(239, 467);
			this.panel38.Name = "panel38";
			this.panel38.Size = new Size(109, 35);
			this.panel38.TabIndex = 118;
			this.CheckBox_KorichneviySom_PickUp.BackColor = Color.Transparent;
			this.CheckBox_KorichneviySom_PickUp.Checked = true;
			this.CheckBox_KorichneviySom_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_KorichneviySom_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_KorichneviySom_PickUp.CornerRadius = 5;
			this.CheckBox_KorichneviySom_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_KorichneviySom_PickUp.Location = new Point(41, 4);
			this.CheckBox_KorichneviySom_PickUp.Name = "CheckBox_KorichneviySom_PickUp";
			this.CheckBox_KorichneviySom_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_KorichneviySom_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_KorichneviySom_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_KorichneviySom_PickUp.Size = new Size(26, 26);
			this.CheckBox_KorichneviySom_PickUp.TabIndex = 1;
			this.CheckBox_KorichneviySom_PickUp.TabStop = false;
			this.CheckBox_KorichneviySom_PickUp.Text = "pinkCheckBox24";
			this.panel48.BackColor = Color.FromArgb(17, 17, 17);
			this.panel48.Controls.Add(this.label21);
			this.panel48.Location = new Point(0, 877);
			this.panel48.Name = "panel48";
			this.panel48.Size = new Size(233, 35);
			this.panel48.TabIndex = 144;
			this.label21.AutoSize = true;
			this.label21.Font = new Font("Verdana", 12f);
			this.label21.ForeColor = Color.White;
			this.label21.Location = new Point(20, 7);
			this.label21.Name = "label21";
			this.label21.Size = new Size(158, 18);
			this.label21.TabIndex = 12;
			this.label21.Text = "Радужная форель";
			this.label21.TextAlign = ContentAlignment.MiddleCenter;
			this.panel39.BackColor = Color.FromArgb(17, 17, 17);
			this.panel39.Controls.Add(this.label18);
			this.panel39.Location = new Point(0, 467);
			this.panel39.Name = "panel39";
			this.panel39.Size = new Size(233, 35);
			this.panel39.TabIndex = 117;
			this.label18.AutoSize = true;
			this.label18.Font = new Font("Verdana", 12f);
			this.label18.ForeColor = Color.White;
			this.label18.Location = new Point(20, 7);
			this.label18.Name = "label18";
			this.label18.Size = new Size(147, 18);
			this.label18.TabIndex = 12;
			this.label18.Text = "Коричневый сом";
			this.label18.TextAlign = ContentAlignment.MiddleCenter;
			this.panel49.BackColor = Color.FromArgb(17, 17, 17);
			this.panel49.Controls.Add(this.CheckBox_PribrejniyBass_PickUp);
			this.panel49.Location = new Point(239, 836);
			this.panel49.Name = "panel49";
			this.panel49.Size = new Size(109, 35);
			this.panel49.TabIndex = 143;
			this.CheckBox_PribrejniyBass_PickUp.BackColor = Color.Transparent;
			this.CheckBox_PribrejniyBass_PickUp.Checked = true;
			this.CheckBox_PribrejniyBass_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_PribrejniyBass_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_PribrejniyBass_PickUp.CornerRadius = 5;
			this.CheckBox_PribrejniyBass_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_PribrejniyBass_PickUp.Location = new Point(41, 4);
			this.CheckBox_PribrejniyBass_PickUp.Name = "CheckBox_PribrejniyBass_PickUp";
			this.CheckBox_PribrejniyBass_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_PribrejniyBass_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_PribrejniyBass_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_PribrejniyBass_PickUp.Size = new Size(26, 26);
			this.CheckBox_PribrejniyBass_PickUp.TabIndex = 1;
			this.CheckBox_PribrejniyBass_PickUp.TabStop = false;
			this.CheckBox_PribrejniyBass_PickUp.Text = "pinkCheckBox39";
			this.panel40.BackColor = Color.FromArgb(17, 17, 17);
			this.panel40.Controls.Add(this.CheckBox_ZerkalniyKarp_PickUp);
			this.panel40.Location = new Point(239, 426);
			this.panel40.Name = "panel40";
			this.panel40.Size = new Size(109, 35);
			this.panel40.TabIndex = 116;
			this.CheckBox_ZerkalniyKarp_PickUp.BackColor = Color.Transparent;
			this.CheckBox_ZerkalniyKarp_PickUp.Checked = true;
			this.CheckBox_ZerkalniyKarp_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_ZerkalniyKarp_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_ZerkalniyKarp_PickUp.CornerRadius = 5;
			this.CheckBox_ZerkalniyKarp_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_ZerkalniyKarp_PickUp.Location = new Point(41, 4);
			this.CheckBox_ZerkalniyKarp_PickUp.Name = "CheckBox_ZerkalniyKarp_PickUp";
			this.CheckBox_ZerkalniyKarp_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_ZerkalniyKarp_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_ZerkalniyKarp_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_ZerkalniyKarp_PickUp.Size = new Size(26, 26);
			this.CheckBox_ZerkalniyKarp_PickUp.TabIndex = 1;
			this.CheckBox_ZerkalniyKarp_PickUp.TabStop = false;
			this.CheckBox_ZerkalniyKarp_PickUp.Text = "pinkCheckBox21";
			this.panel50.BackColor = Color.FromArgb(17, 17, 17);
			this.panel50.Controls.Add(this.label22);
			this.panel50.Location = new Point(0, 836);
			this.panel50.Name = "panel50";
			this.panel50.Size = new Size(233, 35);
			this.panel50.TabIndex = 141;
			this.label22.AutoSize = true;
			this.label22.Font = new Font("Verdana", 12f);
			this.label22.ForeColor = Color.White;
			this.label22.Location = new Point(20, 7);
			this.label22.Name = "label22";
			this.label22.Size = new Size(160, 18);
			this.label22.TabIndex = 12;
			this.label22.Text = "Прибрежный Басс";
			this.label22.TextAlign = ContentAlignment.MiddleCenter;
			this.panel41.BackColor = Color.FromArgb(17, 17, 17);
			this.panel41.Controls.Add(this.label19);
			this.panel41.Location = new Point(0, 426);
			this.panel41.Name = "panel41";
			this.panel41.Size = new Size(233, 35);
			this.panel41.TabIndex = 114;
			this.label19.AutoSize = true;
			this.label19.Font = new Font("Verdana", 12f);
			this.label19.ForeColor = Color.White;
			this.label19.Location = new Point(20, 7);
			this.label19.Name = "label19";
			this.label19.Size = new Size(153, 18);
			this.label19.TabIndex = 12;
			this.label19.Text = "Зеркальный карп";
			this.label19.TextAlign = ContentAlignment.MiddleCenter;
			this.panel51.BackColor = Color.FromArgb(17, 17, 17);
			this.panel51.Controls.Add(this.CheckBox_PolosatiyLavrak_Back);
			this.panel51.Location = new Point(354, 795);
			this.panel51.Name = "panel51";
			this.panel51.Size = new Size(109, 35);
			this.panel51.TabIndex = 140;
			this.CheckBox_PolosatiyLavrak_Back.BackColor = Color.Transparent;
			this.CheckBox_PolosatiyLavrak_Back.CheckMarkColor = Color.White;
			this.CheckBox_PolosatiyLavrak_Back.CheckMarkOffsetY = -2;
			this.CheckBox_PolosatiyLavrak_Back.CornerRadius = 5;
			this.CheckBox_PolosatiyLavrak_Back.Cursor = Cursors.Hand;
			this.CheckBox_PolosatiyLavrak_Back.Location = new Point(41, 4);
			this.CheckBox_PolosatiyLavrak_Back.Name = "CheckBox_PolosatiyLavrak_Back";
			this.CheckBox_PolosatiyLavrak_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_PolosatiyLavrak_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_PolosatiyLavrak_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_PolosatiyLavrak_Back.Size = new Size(26, 26);
			this.CheckBox_PolosatiyLavrak_Back.TabIndex = 1;
			this.CheckBox_PolosatiyLavrak_Back.TabStop = false;
			this.CheckBox_PolosatiyLavrak_Back.Text = "pinkCheckBox37";
			this.panel24.BackColor = Color.FromArgb(17, 17, 17);
			this.panel24.Controls.Add(this.CheckBox_Jereh_Back);
			this.panel24.Location = new Point(354, 385);
			this.panel24.Name = "panel24";
			this.panel24.Size = new Size(109, 35);
			this.panel24.TabIndex = 113;
			this.CheckBox_Jereh_Back.BackColor = Color.Transparent;
			this.CheckBox_Jereh_Back.CheckMarkColor = Color.White;
			this.CheckBox_Jereh_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Jereh_Back.CornerRadius = 5;
			this.CheckBox_Jereh_Back.Cursor = Cursors.Hand;
			this.CheckBox_Jereh_Back.Location = new Point(41, 4);
			this.CheckBox_Jereh_Back.Name = "CheckBox_Jereh_Back";
			this.CheckBox_Jereh_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Jereh_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Jereh_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Jereh_Back.Size = new Size(26, 26);
			this.CheckBox_Jereh_Back.TabIndex = 1;
			this.CheckBox_Jereh_Back.TabStop = false;
			this.CheckBox_Jereh_Back.Text = "pinkCheckBox19";
			this.panel52.BackColor = Color.FromArgb(17, 17, 17);
			this.panel52.Controls.Add(this.CheckBox_Marlin_Back);
			this.panel52.Location = new Point(354, 672);
			this.panel52.Name = "panel52";
			this.panel52.Size = new Size(109, 35);
			this.panel52.TabIndex = 131;
			this.CheckBox_Marlin_Back.BackColor = Color.Transparent;
			this.CheckBox_Marlin_Back.CheckMarkColor = Color.White;
			this.CheckBox_Marlin_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Marlin_Back.CornerRadius = 5;
			this.CheckBox_Marlin_Back.Cursor = Cursors.Hand;
			this.CheckBox_Marlin_Back.Location = new Point(41, 4);
			this.CheckBox_Marlin_Back.Name = "CheckBox_Marlin_Back";
			this.CheckBox_Marlin_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Marlin_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Marlin_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Marlin_Back.Size = new Size(26, 26);
			this.CheckBox_Marlin_Back.TabIndex = 1;
			this.CheckBox_Marlin_Back.TabStop = false;
			this.CheckBox_Marlin_Back.Text = "pinkCheckBox32";
			this.panel21.BackColor = Color.FromArgb(17, 17, 17);
			this.panel21.Controls.Add(this.CheckBox_Vobla_Back);
			this.panel21.Location = new Point(354, 262);
			this.panel21.Name = "panel21";
			this.panel21.Size = new Size(109, 35);
			this.panel21.TabIndex = 104;
			this.CheckBox_Vobla_Back.BackColor = Color.Transparent;
			this.CheckBox_Vobla_Back.CheckMarkColor = Color.White;
			this.CheckBox_Vobla_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Vobla_Back.CornerRadius = 5;
			this.CheckBox_Vobla_Back.Cursor = Cursors.Hand;
			this.CheckBox_Vobla_Back.Location = new Point(41, 4);
			this.CheckBox_Vobla_Back.Name = "CheckBox_Vobla_Back";
			this.CheckBox_Vobla_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Vobla_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Vobla_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Vobla_Back.Size = new Size(26, 26);
			this.CheckBox_Vobla_Back.TabIndex = 1;
			this.CheckBox_Vobla_Back.TabStop = false;
			this.CheckBox_Vobla_Back.Text = "pinkCheckBox14";
			this.panel53.BackColor = Color.FromArgb(17, 17, 17);
			this.panel53.Controls.Add(this.CheckBox_PolosatiyLavrak_PickUp);
			this.panel53.Location = new Point(239, 795);
			this.panel53.Name = "panel53";
			this.panel53.Size = new Size(109, 35);
			this.panel53.TabIndex = 139;
			this.CheckBox_PolosatiyLavrak_PickUp.BackColor = Color.Transparent;
			this.CheckBox_PolosatiyLavrak_PickUp.Checked = true;
			this.CheckBox_PolosatiyLavrak_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_PolosatiyLavrak_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_PolosatiyLavrak_PickUp.CornerRadius = 5;
			this.CheckBox_PolosatiyLavrak_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_PolosatiyLavrak_PickUp.Location = new Point(41, 4);
			this.CheckBox_PolosatiyLavrak_PickUp.Name = "CheckBox_PolosatiyLavrak_PickUp";
			this.CheckBox_PolosatiyLavrak_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_PolosatiyLavrak_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_PolosatiyLavrak_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_PolosatiyLavrak_PickUp.Size = new Size(26, 26);
			this.CheckBox_PolosatiyLavrak_PickUp.TabIndex = 1;
			this.CheckBox_PolosatiyLavrak_PickUp.TabStop = false;
			this.CheckBox_PolosatiyLavrak_PickUp.Text = "pinkCheckBox38";
			this.panel25.BackColor = Color.FromArgb(17, 17, 17);
			this.panel25.Controls.Add(this.CheckBox_Jereh_PickUp);
			this.panel25.Location = new Point(239, 385);
			this.panel25.Name = "panel25";
			this.panel25.Size = new Size(109, 35);
			this.panel25.TabIndex = 112;
			this.CheckBox_Jereh_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Jereh_PickUp.Checked = true;
			this.CheckBox_Jereh_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Jereh_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Jereh_PickUp.CornerRadius = 5;
			this.CheckBox_Jereh_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Jereh_PickUp.Location = new Point(41, 4);
			this.CheckBox_Jereh_PickUp.Name = "CheckBox_Jereh_PickUp";
			this.CheckBox_Jereh_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Jereh_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Jereh_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Jereh_PickUp.Size = new Size(26, 26);
			this.CheckBox_Jereh_PickUp.TabIndex = 1;
			this.CheckBox_Jereh_PickUp.TabStop = false;
			this.CheckBox_Jereh_PickUp.Text = "pinkCheckBox20";
			this.panel54.BackColor = Color.FromArgb(17, 17, 17);
			this.panel54.Controls.Add(this.CheckBox_Marlin_PickUp);
			this.panel54.Location = new Point(239, 672);
			this.panel54.Name = "panel54";
			this.panel54.Size = new Size(109, 35);
			this.panel54.TabIndex = 130;
			this.CheckBox_Marlin_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Marlin_PickUp.Checked = true;
			this.CheckBox_Marlin_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Marlin_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Marlin_PickUp.CornerRadius = 5;
			this.CheckBox_Marlin_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Marlin_PickUp.Location = new Point(41, 4);
			this.CheckBox_Marlin_PickUp.Name = "CheckBox_Marlin_PickUp";
			this.CheckBox_Marlin_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Marlin_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Marlin_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Marlin_PickUp.Size = new Size(26, 26);
			this.CheckBox_Marlin_PickUp.TabIndex = 1;
			this.CheckBox_Marlin_PickUp.TabStop = false;
			this.CheckBox_Marlin_PickUp.Text = "pinkCheckBox31";
			this.panel22.BackColor = Color.FromArgb(17, 17, 17);
			this.panel22.Controls.Add(this.CheckBox_Vobla_PickUp);
			this.panel22.Location = new Point(239, 262);
			this.panel22.Name = "panel22";
			this.panel22.Size = new Size(109, 35);
			this.panel22.TabIndex = 103;
			this.CheckBox_Vobla_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Vobla_PickUp.Checked = true;
			this.CheckBox_Vobla_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Vobla_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Vobla_PickUp.CornerRadius = 5;
			this.CheckBox_Vobla_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Vobla_PickUp.Location = new Point(41, 4);
			this.CheckBox_Vobla_PickUp.Name = "CheckBox_Vobla_PickUp";
			this.CheckBox_Vobla_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Vobla_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Vobla_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Vobla_PickUp.Size = new Size(26, 26);
			this.CheckBox_Vobla_PickUp.TabIndex = 1;
			this.CheckBox_Vobla_PickUp.TabStop = false;
			this.CheckBox_Vobla_PickUp.Text = "pinkCheckBox11";
			this.panel55.BackColor = Color.FromArgb(17, 17, 17);
			this.panel55.Controls.Add(this.label23);
			this.panel55.Location = new Point(0, 795);
			this.panel55.Name = "panel55";
			this.panel55.Size = new Size(233, 35);
			this.panel55.TabIndex = 138;
			this.label23.AutoSize = true;
			this.label23.Font = new Font("Verdana", 12f);
			this.label23.ForeColor = Color.White;
			this.label23.Location = new Point(20, 7);
			this.label23.Name = "label23";
			this.label23.Size = new Size(163, 18);
			this.label23.TabIndex = 12;
			this.label23.Text = "Полосатый лаврак";
			this.label23.TextAlign = ContentAlignment.MiddleCenter;
			this.panel26.BackColor = Color.FromArgb(17, 17, 17);
			this.panel26.Controls.Add(this.label14);
			this.panel26.Location = new Point(0, 385);
			this.panel26.Name = "panel26";
			this.panel26.Size = new Size(233, 35);
			this.panel26.TabIndex = 111;
			this.label14.AutoSize = true;
			this.label14.Font = new Font("Verdana", 12f);
			this.label14.ForeColor = Color.White;
			this.label14.Location = new Point(20, 7);
			this.label14.Name = "label14";
			this.label14.Size = new Size(64, 18);
			this.label14.TabIndex = 12;
			this.label14.Text = "Жерех";
			this.label14.TextAlign = ContentAlignment.MiddleCenter;
			this.panel56.BackColor = Color.FromArgb(17, 17, 17);
			this.panel56.Controls.Add(this.label24);
			this.panel56.Location = new Point(0, 672);
			this.panel56.Name = "panel56";
			this.panel56.Size = new Size(233, 35);
			this.panel56.TabIndex = 129;
			this.label24.AutoSize = true;
			this.label24.Font = new Font("Verdana", 12f);
			this.label24.ForeColor = Color.White;
			this.label24.Location = new Point(20, 7);
			this.label24.Name = "label24";
			this.label24.Size = new Size(71, 18);
			this.label24.TabIndex = 12;
			this.label24.Text = "Марлин";
			this.label24.TextAlign = ContentAlignment.MiddleCenter;
			this.panel23.BackColor = Color.FromArgb(17, 17, 17);
			this.panel23.Controls.Add(this.label13);
			this.panel23.Location = new Point(0, 262);
			this.panel23.Name = "panel23";
			this.panel23.Size = new Size(233, 35);
			this.panel23.TabIndex = 102;
			this.label13.AutoSize = true;
			this.label13.Font = new Font("Verdana", 12f);
			this.label13.ForeColor = Color.White;
			this.label13.Location = new Point(20, 7);
			this.label13.Name = "label13";
			this.label13.Size = new Size(59, 18);
			this.label13.TabIndex = 12;
			this.label13.Text = "Вобла";
			this.label13.TextAlign = ContentAlignment.MiddleCenter;
			this.panel57.BackColor = Color.FromArgb(17, 17, 17);
			this.panel57.Controls.Add(this.CheckBox_Plotva_Back);
			this.panel57.Location = new Point(354, 754);
			this.panel57.Name = "panel57";
			this.panel57.Size = new Size(109, 35);
			this.panel57.TabIndex = 137;
			this.CheckBox_Plotva_Back.BackColor = Color.Transparent;
			this.CheckBox_Plotva_Back.CheckMarkColor = Color.White;
			this.CheckBox_Plotva_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Plotva_Back.CornerRadius = 5;
			this.CheckBox_Plotva_Back.Cursor = Cursors.Hand;
			this.CheckBox_Plotva_Back.Location = new Point(41, 4);
			this.CheckBox_Plotva_Back.Name = "CheckBox_Plotva_Back";
			this.CheckBox_Plotva_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Plotva_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Plotva_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Plotva_Back.Size = new Size(26, 26);
			this.CheckBox_Plotva_Back.TabIndex = 1;
			this.CheckBox_Plotva_Back.TabStop = false;
			this.CheckBox_Plotva_Back.Text = "pinkCheckBox36";
			this.panel27.BackColor = Color.FromArgb(17, 17, 17);
			this.panel27.Controls.Add(this.CheckBox_DrevnyayaGineriya_Back);
			this.panel27.Location = new Point(354, 344);
			this.panel27.Name = "panel27";
			this.panel27.Size = new Size(109, 35);
			this.panel27.TabIndex = 110;
			this.CheckBox_DrevnyayaGineriya_Back.BackColor = Color.Transparent;
			this.CheckBox_DrevnyayaGineriya_Back.CheckMarkColor = Color.White;
			this.CheckBox_DrevnyayaGineriya_Back.CheckMarkOffsetY = -2;
			this.CheckBox_DrevnyayaGineriya_Back.CornerRadius = 5;
			this.CheckBox_DrevnyayaGineriya_Back.Cursor = Cursors.Hand;
			this.CheckBox_DrevnyayaGineriya_Back.Location = new Point(41, 4);
			this.CheckBox_DrevnyayaGineriya_Back.Name = "CheckBox_DrevnyayaGineriya_Back";
			this.CheckBox_DrevnyayaGineriya_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_DrevnyayaGineriya_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_DrevnyayaGineriya_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_DrevnyayaGineriya_Back.Size = new Size(26, 26);
			this.CheckBox_DrevnyayaGineriya_Back.TabIndex = 1;
			this.CheckBox_DrevnyayaGineriya_Back.TabStop = false;
			this.CheckBox_DrevnyayaGineriya_Back.Text = "pinkCheckBox18";
			this.panel58.BackColor = Color.FromArgb(17, 17, 17);
			this.panel58.Controls.Add(this.CheckBox_KrugliyTrahinot_Back);
			this.panel58.Location = new Point(354, 590);
			this.panel58.Name = "panel58";
			this.panel58.Size = new Size(109, 35);
			this.panel58.TabIndex = 128;
			this.CheckBox_KrugliyTrahinot_Back.BackColor = Color.Transparent;
			this.CheckBox_KrugliyTrahinot_Back.CheckMarkColor = Color.White;
			this.CheckBox_KrugliyTrahinot_Back.CheckMarkOffsetY = -2;
			this.CheckBox_KrugliyTrahinot_Back.CornerRadius = 5;
			this.CheckBox_KrugliyTrahinot_Back.Cursor = Cursors.Hand;
			this.CheckBox_KrugliyTrahinot_Back.Location = new Point(41, 4);
			this.CheckBox_KrugliyTrahinot_Back.Name = "CheckBox_KrugliyTrahinot_Back";
			this.CheckBox_KrugliyTrahinot_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_KrugliyTrahinot_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_KrugliyTrahinot_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_KrugliyTrahinot_Back.Size = new Size(26, 26);
			this.CheckBox_KrugliyTrahinot_Back.TabIndex = 1;
			this.CheckBox_KrugliyTrahinot_Back.TabStop = false;
			this.CheckBox_KrugliyTrahinot_Back.Text = "pinkCheckBox29";
			this.panel18.BackColor = Color.FromArgb(17, 17, 17);
			this.panel18.Controls.Add(this.CheckBox_Barrakuda_Back);
			this.panel18.Location = new Point(354, 221);
			this.panel18.Name = "panel18";
			this.panel18.Size = new Size(109, 35);
			this.panel18.TabIndex = 101;
			this.CheckBox_Barrakuda_Back.BackColor = Color.Transparent;
			this.CheckBox_Barrakuda_Back.CheckMarkColor = Color.White;
			this.CheckBox_Barrakuda_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Barrakuda_Back.CornerRadius = 5;
			this.CheckBox_Barrakuda_Back.Cursor = Cursors.Hand;
			this.CheckBox_Barrakuda_Back.Location = new Point(41, 4);
			this.CheckBox_Barrakuda_Back.Name = "CheckBox_Barrakuda_Back";
			this.CheckBox_Barrakuda_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Barrakuda_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Barrakuda_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Barrakuda_Back.Size = new Size(26, 26);
			this.CheckBox_Barrakuda_Back.TabIndex = 1;
			this.CheckBox_Barrakuda_Back.TabStop = false;
			this.CheckBox_Barrakuda_Back.Text = "pinkCheckBox15";
			this.panel59.BackColor = Color.FromArgb(17, 17, 17);
			this.panel59.Controls.Add(this.CheckBox_ObiknovennayaShuka_Back);
			this.panel59.Location = new Point(354, 713);
			this.panel59.Name = "panel59";
			this.panel59.Size = new Size(109, 35);
			this.panel59.TabIndex = 133;
			this.CheckBox_ObiknovennayaShuka_Back.BackColor = Color.Transparent;
			this.CheckBox_ObiknovennayaShuka_Back.CheckMarkColor = Color.White;
			this.CheckBox_ObiknovennayaShuka_Back.CheckMarkOffsetY = -2;
			this.CheckBox_ObiknovennayaShuka_Back.CornerRadius = 5;
			this.CheckBox_ObiknovennayaShuka_Back.Cursor = Cursors.Hand;
			this.CheckBox_ObiknovennayaShuka_Back.Location = new Point(41, 4);
			this.CheckBox_ObiknovennayaShuka_Back.Name = "CheckBox_ObiknovennayaShuka_Back";
			this.CheckBox_ObiknovennayaShuka_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_ObiknovennayaShuka_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_ObiknovennayaShuka_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_ObiknovennayaShuka_Back.Size = new Size(26, 26);
			this.CheckBox_ObiknovennayaShuka_Back.TabIndex = 1;
			this.CheckBox_ObiknovennayaShuka_Back.TabStop = false;
			this.CheckBox_ObiknovennayaShuka_Back.Text = "pinkCheckBox33";
			this.panel28.BackColor = Color.FromArgb(17, 17, 17);
			this.panel28.Controls.Add(this.CheckBox_Golavl_Back);
			this.panel28.Location = new Point(354, 303);
			this.panel28.Name = "panel28";
			this.panel28.Size = new Size(109, 35);
			this.panel28.TabIndex = 106;
			this.CheckBox_Golavl_Back.BackColor = Color.Transparent;
			this.CheckBox_Golavl_Back.CheckMarkColor = Color.White;
			this.CheckBox_Golavl_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Golavl_Back.CornerRadius = 5;
			this.CheckBox_Golavl_Back.Cursor = Cursors.Hand;
			this.CheckBox_Golavl_Back.Location = new Point(41, 4);
			this.CheckBox_Golavl_Back.Name = "CheckBox_Golavl_Back";
			this.CheckBox_Golavl_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Golavl_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Golavl_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Golavl_Back.Size = new Size(26, 26);
			this.CheckBox_Golavl_Back.TabIndex = 1;
			this.CheckBox_Golavl_Back.TabStop = false;
			this.CheckBox_Golavl_Back.Text = "pinkCheckBox13";
			this.panel60.BackColor = Color.FromArgb(17, 17, 17);
			this.panel60.Controls.Add(this.CheckBox_KrasniyGorbil_Back);
			this.panel60.Location = new Point(354, 549);
			this.panel60.Name = "panel60";
			this.panel60.Size = new Size(109, 35);
			this.panel60.TabIndex = 125;
			this.CheckBox_KrasniyGorbil_Back.BackColor = Color.Transparent;
			this.CheckBox_KrasniyGorbil_Back.CheckMarkColor = Color.White;
			this.CheckBox_KrasniyGorbil_Back.CheckMarkOffsetY = -2;
			this.CheckBox_KrasniyGorbil_Back.CornerRadius = 5;
			this.CheckBox_KrasniyGorbil_Back.Cursor = Cursors.Hand;
			this.CheckBox_KrasniyGorbil_Back.Location = new Point(41, 4);
			this.CheckBox_KrasniyGorbil_Back.Name = "CheckBox_KrasniyGorbil_Back";
			this.CheckBox_KrasniyGorbil_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_KrasniyGorbil_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_KrasniyGorbil_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_KrasniyGorbil_Back.Size = new Size(26, 26);
			this.CheckBox_KrasniyGorbil_Back.TabIndex = 1;
			this.CheckBox_KrasniyGorbil_Back.TabStop = false;
			this.CheckBox_KrasniyGorbil_Back.Text = "pinkCheckBox28";
			this.panel61.BackColor = Color.FromArgb(17, 17, 17);
			this.panel61.Controls.Add(this.CheckBox_Plotva_PickUp);
			this.panel61.Location = new Point(239, 754);
			this.panel61.Name = "panel61";
			this.panel61.Size = new Size(109, 35);
			this.panel61.TabIndex = 136;
			this.CheckBox_Plotva_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Plotva_PickUp.Checked = true;
			this.CheckBox_Plotva_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Plotva_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Plotva_PickUp.CornerRadius = 5;
			this.CheckBox_Plotva_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Plotva_PickUp.Location = new Point(41, 4);
			this.CheckBox_Plotva_PickUp.Name = "CheckBox_Plotva_PickUp";
			this.CheckBox_Plotva_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Plotva_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Plotva_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Plotva_PickUp.Size = new Size(26, 26);
			this.CheckBox_Plotva_PickUp.TabIndex = 1;
			this.CheckBox_Plotva_PickUp.TabStop = false;
			this.CheckBox_Plotva_PickUp.Text = "pinkCheckBox35";
			this.panel29.BackColor = Color.FromArgb(17, 17, 17);
			this.panel29.Controls.Add(this.CheckBox_DrevnyayaGineriya_PickUp);
			this.panel29.Location = new Point(239, 344);
			this.panel29.Name = "panel29";
			this.panel29.Size = new Size(109, 35);
			this.panel29.TabIndex = 109;
			this.CheckBox_DrevnyayaGineriya_PickUp.BackColor = Color.Transparent;
			this.CheckBox_DrevnyayaGineriya_PickUp.Checked = true;
			this.CheckBox_DrevnyayaGineriya_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_DrevnyayaGineriya_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_DrevnyayaGineriya_PickUp.CornerRadius = 5;
			this.CheckBox_DrevnyayaGineriya_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_DrevnyayaGineriya_PickUp.Location = new Point(41, 4);
			this.CheckBox_DrevnyayaGineriya_PickUp.Name = "CheckBox_DrevnyayaGineriya_PickUp";
			this.CheckBox_DrevnyayaGineriya_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_DrevnyayaGineriya_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_DrevnyayaGineriya_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_DrevnyayaGineriya_PickUp.Size = new Size(26, 26);
			this.CheckBox_DrevnyayaGineriya_PickUp.TabIndex = 1;
			this.CheckBox_DrevnyayaGineriya_PickUp.TabStop = false;
			this.CheckBox_DrevnyayaGineriya_PickUp.Text = "pinkCheckBox17";
			this.panel62.BackColor = Color.FromArgb(17, 17, 17);
			this.panel62.Controls.Add(this.CheckBox_KrugliyTrahinot_PickUp);
			this.panel62.Location = new Point(239, 590);
			this.panel62.Name = "panel62";
			this.panel62.Size = new Size(109, 35);
			this.panel62.TabIndex = 127;
			this.CheckBox_KrugliyTrahinot_PickUp.BackColor = Color.Transparent;
			this.CheckBox_KrugliyTrahinot_PickUp.Checked = true;
			this.CheckBox_KrugliyTrahinot_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_KrugliyTrahinot_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_KrugliyTrahinot_PickUp.CornerRadius = 5;
			this.CheckBox_KrugliyTrahinot_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_KrugliyTrahinot_PickUp.Location = new Point(41, 4);
			this.CheckBox_KrugliyTrahinot_PickUp.Name = "CheckBox_KrugliyTrahinot_PickUp";
			this.CheckBox_KrugliyTrahinot_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_KrugliyTrahinot_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_KrugliyTrahinot_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_KrugliyTrahinot_PickUp.Size = new Size(26, 26);
			this.CheckBox_KrugliyTrahinot_PickUp.TabIndex = 1;
			this.CheckBox_KrugliyTrahinot_PickUp.TabStop = false;
			this.CheckBox_KrugliyTrahinot_PickUp.Text = "pinkCheckBox30";
			this.panel19.BackColor = Color.FromArgb(17, 17, 17);
			this.panel19.Controls.Add(this.CheckBox_Barrakuda_PickUp);
			this.panel19.Location = new Point(239, 221);
			this.panel19.Name = "panel19";
			this.panel19.Size = new Size(109, 35);
			this.panel19.TabIndex = 100;
			this.CheckBox_Barrakuda_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Barrakuda_PickUp.Checked = true;
			this.CheckBox_Barrakuda_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Barrakuda_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Barrakuda_PickUp.CornerRadius = 5;
			this.CheckBox_Barrakuda_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Barrakuda_PickUp.Location = new Point(41, 4);
			this.CheckBox_Barrakuda_PickUp.Name = "CheckBox_Barrakuda_PickUp";
			this.CheckBox_Barrakuda_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Barrakuda_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Barrakuda_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Barrakuda_PickUp.Size = new Size(26, 26);
			this.CheckBox_Barrakuda_PickUp.TabIndex = 1;
			this.CheckBox_Barrakuda_PickUp.TabStop = false;
			this.CheckBox_Barrakuda_PickUp.Text = "pinkCheckBox10";
			this.panel63.BackColor = Color.FromArgb(17, 17, 17);
			this.panel63.Controls.Add(this.label25);
			this.panel63.Location = new Point(0, 754);
			this.panel63.Name = "panel63";
			this.panel63.Size = new Size(233, 35);
			this.panel63.TabIndex = 135;
			this.label25.AutoSize = true;
			this.label25.Font = new Font("Verdana", 12f);
			this.label25.ForeColor = Color.White;
			this.label25.Location = new Point(20, 7);
			this.label25.Name = "label25";
			this.label25.Size = new Size(67, 18);
			this.label25.TabIndex = 12;
			this.label25.Text = "Плотва";
			this.label25.TextAlign = ContentAlignment.MiddleCenter;
			this.panel30.BackColor = Color.FromArgb(17, 17, 17);
			this.panel30.Controls.Add(this.label15);
			this.panel30.Location = new Point(0, 344);
			this.panel30.Name = "panel30";
			this.panel30.Size = new Size(233, 35);
			this.panel30.TabIndex = 108;
			this.label15.AutoSize = true;
			this.label15.Font = new Font("Verdana", 12f);
			this.label15.ForeColor = Color.White;
			this.label15.Location = new Point(20, 7);
			this.label15.Name = "label15";
			this.label15.Size = new Size(154, 18);
			this.label15.TabIndex = 12;
			this.label15.Text = "Древняя гинерия";
			this.label15.TextAlign = ContentAlignment.MiddleCenter;
			this.panel64.BackColor = Color.FromArgb(17, 17, 17);
			this.panel64.Controls.Add(this.label26);
			this.panel64.Location = new Point(0, 590);
			this.panel64.Name = "panel64";
			this.panel64.Size = new Size(233, 35);
			this.panel64.TabIndex = 126;
			this.label26.AutoSize = true;
			this.label26.Font = new Font("Verdana", 12f);
			this.label26.ForeColor = Color.White;
			this.label26.Location = new Point(20, 7);
			this.label26.Name = "label26";
			this.label26.Size = new Size(157, 18);
			this.label26.TabIndex = 12;
			this.label26.Text = "Круглый трахинот";
			this.label26.TextAlign = ContentAlignment.MiddleCenter;
			this.panel20.BackColor = Color.FromArgb(17, 17, 17);
			this.panel20.Controls.Add(this.label11);
			this.panel20.Location = new Point(0, 221);
			this.panel20.Name = "panel20";
			this.panel20.Size = new Size(233, 35);
			this.panel20.TabIndex = 99;
			this.label11.AutoSize = true;
			this.label11.Font = new Font("Verdana", 12f);
			this.label11.ForeColor = Color.White;
			this.label11.Location = new Point(20, 7);
			this.label11.Name = "label11";
			this.label11.Size = new Size(97, 18);
			this.label11.TabIndex = 12;
			this.label11.Text = "Барракуда";
			this.label11.TextAlign = ContentAlignment.MiddleCenter;
			this.panel65.BackColor = Color.FromArgb(17, 17, 17);
			this.panel65.Controls.Add(this.CheckBox_ObiknovennayaShuka_PickUp);
			this.panel65.Location = new Point(239, 713);
			this.panel65.Name = "panel65";
			this.panel65.Size = new Size(109, 35);
			this.panel65.TabIndex = 134;
			this.CheckBox_ObiknovennayaShuka_PickUp.BackColor = Color.Transparent;
			this.CheckBox_ObiknovennayaShuka_PickUp.Checked = true;
			this.CheckBox_ObiknovennayaShuka_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_ObiknovennayaShuka_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_ObiknovennayaShuka_PickUp.CornerRadius = 5;
			this.CheckBox_ObiknovennayaShuka_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_ObiknovennayaShuka_PickUp.Location = new Point(41, 4);
			this.CheckBox_ObiknovennayaShuka_PickUp.Name = "CheckBox_ObiknovennayaShuka_PickUp";
			this.CheckBox_ObiknovennayaShuka_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_ObiknovennayaShuka_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_ObiknovennayaShuka_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_ObiknovennayaShuka_PickUp.Size = new Size(26, 26);
			this.CheckBox_ObiknovennayaShuka_PickUp.TabIndex = 1;
			this.CheckBox_ObiknovennayaShuka_PickUp.TabStop = false;
			this.CheckBox_ObiknovennayaShuka_PickUp.Text = "pinkCheckBox34";
			this.panel31.BackColor = Color.FromArgb(17, 17, 17);
			this.panel31.Controls.Add(this.CheckBox_Golavl_PickUp);
			this.panel31.Location = new Point(239, 303);
			this.panel31.Name = "panel31";
			this.panel31.Size = new Size(109, 35);
			this.panel31.TabIndex = 107;
			this.CheckBox_Golavl_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Golavl_PickUp.Checked = true;
			this.CheckBox_Golavl_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Golavl_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Golavl_PickUp.CornerRadius = 5;
			this.CheckBox_Golavl_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Golavl_PickUp.Location = new Point(41, 4);
			this.CheckBox_Golavl_PickUp.Name = "CheckBox_Golavl_PickUp";
			this.CheckBox_Golavl_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Golavl_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Golavl_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Golavl_PickUp.Size = new Size(26, 26);
			this.CheckBox_Golavl_PickUp.TabIndex = 1;
			this.CheckBox_Golavl_PickUp.TabStop = false;
			this.CheckBox_Golavl_PickUp.Text = "pinkCheckBox12";
			this.panel66.BackColor = Color.FromArgb(17, 17, 17);
			this.panel66.Controls.Add(this.CheckBox_KrasniyGorbil_PickUp);
			this.panel66.Location = new Point(239, 549);
			this.panel66.Name = "panel66";
			this.panel66.Size = new Size(109, 35);
			this.panel66.TabIndex = 124;
			this.CheckBox_KrasniyGorbil_PickUp.BackColor = Color.Transparent;
			this.CheckBox_KrasniyGorbil_PickUp.Checked = true;
			this.CheckBox_KrasniyGorbil_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_KrasniyGorbil_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_KrasniyGorbil_PickUp.CornerRadius = 5;
			this.CheckBox_KrasniyGorbil_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_KrasniyGorbil_PickUp.Location = new Point(41, 4);
			this.CheckBox_KrasniyGorbil_PickUp.Name = "CheckBox_KrasniyGorbil_PickUp";
			this.CheckBox_KrasniyGorbil_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_KrasniyGorbil_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_KrasniyGorbil_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_KrasniyGorbil_PickUp.Size = new Size(26, 26);
			this.CheckBox_KrasniyGorbil_PickUp.TabIndex = 1;
			this.CheckBox_KrasniyGorbil_PickUp.TabStop = false;
			this.CheckBox_KrasniyGorbil_PickUp.Text = "pinkCheckBox27";
			this.panel67.BackColor = Color.FromArgb(17, 17, 17);
			this.panel67.Controls.Add(this.label27);
			this.panel67.Location = new Point(0, 713);
			this.panel67.Name = "panel67";
			this.panel67.Size = new Size(233, 35);
			this.panel67.TabIndex = 132;
			this.label27.AutoSize = true;
			this.label27.Font = new Font("Verdana", 12f);
			this.label27.ForeColor = Color.White;
			this.label27.Location = new Point(20, 7);
			this.label27.Name = "label27";
			this.label27.Size = new Size(180, 18);
			this.label27.TabIndex = 12;
			this.label27.Text = "Обыкновенная щука";
			this.label27.TextAlign = ContentAlignment.MiddleCenter;
			this.panel32.BackColor = Color.FromArgb(17, 17, 17);
			this.panel32.Controls.Add(this.label16);
			this.panel32.Location = new Point(0, 303);
			this.panel32.Name = "panel32";
			this.panel32.Size = new Size(233, 35);
			this.panel32.TabIndex = 105;
			this.label16.AutoSize = true;
			this.label16.Font = new Font("Verdana", 12f);
			this.label16.ForeColor = Color.White;
			this.label16.Location = new Point(20, 7);
			this.label16.Name = "label16";
			this.label16.Size = new Size(76, 18);
			this.label16.TabIndex = 12;
			this.label16.Text = "Голавль";
			this.label16.TextAlign = ContentAlignment.MiddleCenter;
			this.panel68.BackColor = Color.FromArgb(17, 17, 17);
			this.panel68.Controls.Add(this.label28);
			this.panel68.Location = new Point(0, 549);
			this.panel68.Name = "panel68";
			this.panel68.Size = new Size(233, 35);
			this.panel68.TabIndex = 123;
			this.label28.AutoSize = true;
			this.label28.Font = new Font("Verdana", 12f);
			this.label28.ForeColor = Color.White;
			this.label28.Location = new Point(20, 7);
			this.label28.Name = "label28";
			this.label28.Size = new Size(155, 18);
			this.label28.TabIndex = 12;
			this.label28.Text = "Красный горбыль";
			this.label28.TextAlign = ContentAlignment.MiddleCenter;
			this.panel11.BackColor = Color.FromArgb(17, 17, 17);
			this.panel11.Controls.Add(this.CheckBox_Tarpon_Back);
			this.panel11.Location = new Point(354, 1328);
			this.panel11.Name = "panel11";
			this.panel11.Size = new Size(109, 35);
			this.panel11.TabIndex = 188;
			this.CheckBox_Tarpon_Back.BackColor = Color.Transparent;
			this.CheckBox_Tarpon_Back.CheckMarkColor = Color.White;
			this.CheckBox_Tarpon_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Tarpon_Back.CornerRadius = 5;
			this.CheckBox_Tarpon_Back.Cursor = Cursors.Hand;
			this.CheckBox_Tarpon_Back.Location = new Point(41, 4);
			this.CheckBox_Tarpon_Back.Name = "CheckBox_Tarpon_Back";
			this.CheckBox_Tarpon_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Tarpon_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Tarpon_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Tarpon_Back.Size = new Size(26, 26);
			this.CheckBox_Tarpon_Back.TabIndex = 1;
			this.CheckBox_Tarpon_Back.TabStop = false;
			this.CheckBox_Tarpon_Back.Text = "pinkCheckBox64";
			this.panel104.BackColor = Color.FromArgb(17, 17, 17);
			this.panel104.Controls.Add(this.CheckBox_Tarpon_PickUp);
			this.panel104.Location = new Point(239, 1328);
			this.panel104.Name = "panel104";
			this.panel104.Size = new Size(109, 35);
			this.panel104.TabIndex = 186;
			this.CheckBox_Tarpon_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Tarpon_PickUp.Checked = true;
			this.CheckBox_Tarpon_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Tarpon_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Tarpon_PickUp.CornerRadius = 5;
			this.CheckBox_Tarpon_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Tarpon_PickUp.Location = new Point(41, 4);
			this.CheckBox_Tarpon_PickUp.Name = "CheckBox_Tarpon_PickUp";
			this.CheckBox_Tarpon_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Tarpon_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Tarpon_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Tarpon_PickUp.Size = new Size(26, 26);
			this.CheckBox_Tarpon_PickUp.TabIndex = 1;
			this.CheckBox_Tarpon_PickUp.TabStop = false;
			this.CheckBox_Tarpon_PickUp.Text = "pinkCheckBox63";
			this.panel105.BackColor = Color.FromArgb(17, 17, 17);
			this.panel105.Controls.Add(this.label1);
			this.panel105.Location = new Point(0, 1328);
			this.panel105.Name = "panel105";
			this.panel105.Size = new Size(233, 35);
			this.panel105.TabIndex = 184;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Verdana", 12f);
			this.label1.ForeColor = Color.White;
			this.label1.Location = new Point(20, 7);
			this.label1.Name = "label1";
			this.label1.Size = new Size(68, 18);
			this.label1.TabIndex = 12;
			this.label1.Text = "Тарпон";
			this.label1.TextAlign = ContentAlignment.MiddleCenter;
			this.panel96.BackColor = Color.FromArgb(17, 17, 17);
			this.panel96.Controls.Add(this.CheckBox_ToksichniyOkun_Back);
			this.panel96.Location = new Point(354, 1410);
			this.panel96.Name = "panel96";
			this.panel96.Size = new Size(109, 35);
			this.panel96.TabIndex = 187;
			this.CheckBox_ToksichniyOkun_Back.BackColor = Color.Transparent;
			this.CheckBox_ToksichniyOkun_Back.CheckMarkColor = Color.White;
			this.CheckBox_ToksichniyOkun_Back.CheckMarkOffsetY = -2;
			this.CheckBox_ToksichniyOkun_Back.CornerRadius = 5;
			this.CheckBox_ToksichniyOkun_Back.Cursor = Cursors.Hand;
			this.CheckBox_ToksichniyOkun_Back.Location = new Point(41, 4);
			this.CheckBox_ToksichniyOkun_Back.Name = "CheckBox_ToksichniyOkun_Back";
			this.CheckBox_ToksichniyOkun_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_ToksichniyOkun_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_ToksichniyOkun_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_ToksichniyOkun_Back.Size = new Size(26, 26);
			this.CheckBox_ToksichniyOkun_Back.TabIndex = 1;
			this.CheckBox_ToksichniyOkun_Back.TabStop = false;
			this.CheckBox_ToksichniyOkun_Back.Text = "pinkCheckBox65";
			this.panel87.BackColor = Color.FromArgb(17, 17, 17);
			this.panel87.Controls.Add(this.CheckBox_SudakObiknovenniy_Back);
			this.panel87.Location = new Point(354, 1287);
			this.panel87.Name = "panel87";
			this.panel87.Size = new Size(109, 35);
			this.panel87.TabIndex = 179;
			this.CheckBox_SudakObiknovenniy_Back.BackColor = Color.Transparent;
			this.CheckBox_SudakObiknovenniy_Back.CheckMarkColor = Color.White;
			this.CheckBox_SudakObiknovenniy_Back.CheckMarkOffsetY = -2;
			this.CheckBox_SudakObiknovenniy_Back.CornerRadius = 5;
			this.CheckBox_SudakObiknovenniy_Back.Cursor = Cursors.Hand;
			this.CheckBox_SudakObiknovenniy_Back.Location = new Point(41, 4);
			this.CheckBox_SudakObiknovenniy_Back.Name = "CheckBox_SudakObiknovenniy_Back";
			this.CheckBox_SudakObiknovenniy_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_SudakObiknovenniy_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_SudakObiknovenniy_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_SudakObiknovenniy_Back.Size = new Size(26, 26);
			this.CheckBox_SudakObiknovenniy_Back.TabIndex = 1;
			this.CheckBox_SudakObiknovenniy_Back.TabStop = false;
			this.CheckBox_SudakObiknovenniy_Back.Text = "pinkCheckBox61";
			this.panel97.BackColor = Color.FromArgb(17, 17, 17);
			this.panel97.Controls.Add(this.CheckBox_ToksichniyOkun_PickUp);
			this.panel97.Location = new Point(239, 1410);
			this.panel97.Name = "panel97";
			this.panel97.Size = new Size(109, 35);
			this.panel97.TabIndex = 185;
			this.CheckBox_ToksichniyOkun_PickUp.BackColor = Color.Transparent;
			this.CheckBox_ToksichniyOkun_PickUp.Checked = true;
			this.CheckBox_ToksichniyOkun_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_ToksichniyOkun_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_ToksichniyOkun_PickUp.CornerRadius = 5;
			this.CheckBox_ToksichniyOkun_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_ToksichniyOkun_PickUp.Location = new Point(41, 4);
			this.CheckBox_ToksichniyOkun_PickUp.Name = "CheckBox_ToksichniyOkun_PickUp";
			this.CheckBox_ToksichniyOkun_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_ToksichniyOkun_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_ToksichniyOkun_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_ToksichniyOkun_PickUp.Size = new Size(26, 26);
			this.CheckBox_ToksichniyOkun_PickUp.TabIndex = 1;
			this.CheckBox_ToksichniyOkun_PickUp.TabStop = false;
			this.CheckBox_ToksichniyOkun_PickUp.Text = "pinkCheckBox66";
			this.panel84.BackColor = Color.FromArgb(17, 17, 17);
			this.panel84.Controls.Add(this.CheckBox_SomObiknovenniy_Back);
			this.panel84.Location = new Point(354, 1164);
			this.panel84.Name = "panel84";
			this.panel84.Size = new Size(109, 35);
			this.panel84.TabIndex = 170;
			this.CheckBox_SomObiknovenniy_Back.BackColor = Color.Transparent;
			this.CheckBox_SomObiknovenniy_Back.CheckMarkColor = Color.White;
			this.CheckBox_SomObiknovenniy_Back.CheckMarkOffsetY = -2;
			this.CheckBox_SomObiknovenniy_Back.CornerRadius = 5;
			this.CheckBox_SomObiknovenniy_Back.Cursor = Cursors.Hand;
			this.CheckBox_SomObiknovenniy_Back.Location = new Point(41, 4);
			this.CheckBox_SomObiknovenniy_Back.Name = "CheckBox_SomObiknovenniy_Back";
			this.CheckBox_SomObiknovenniy_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_SomObiknovenniy_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_SomObiknovenniy_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_SomObiknovenniy_Back.Size = new Size(26, 26);
			this.CheckBox_SomObiknovenniy_Back.TabIndex = 1;
			this.CheckBox_SomObiknovenniy_Back.TabStop = false;
			this.CheckBox_SomObiknovenniy_Back.Text = "pinkCheckBox56";
			this.panel98.BackColor = Color.FromArgb(17, 17, 17);
			this.panel98.Controls.Add(this.label38);
			this.panel98.Location = new Point(0, 1410);
			this.panel98.Name = "panel98";
			this.panel98.Size = new Size(233, 35);
			this.panel98.TabIndex = 183;
			this.label38.AutoSize = true;
			this.label38.Font = new Font("Verdana", 12f);
			this.label38.ForeColor = Color.White;
			this.label38.Location = new Point(20, 7);
			this.label38.Name = "label38";
			this.label38.Size = new Size(151, 18);
			this.label38.TabIndex = 12;
			this.label38.Text = "Токсичный окунь";
			this.label38.TextAlign = ContentAlignment.MiddleCenter;
			this.panel88.BackColor = Color.FromArgb(17, 17, 17);
			this.panel88.Controls.Add(this.CheckBox_SudakObiknovenniy_PickUp);
			this.panel88.Location = new Point(239, 1287);
			this.panel88.Name = "panel88";
			this.panel88.Size = new Size(109, 35);
			this.panel88.TabIndex = 178;
			this.CheckBox_SudakObiknovenniy_PickUp.BackColor = Color.Transparent;
			this.CheckBox_SudakObiknovenniy_PickUp.Checked = true;
			this.CheckBox_SudakObiknovenniy_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_SudakObiknovenniy_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_SudakObiknovenniy_PickUp.CornerRadius = 5;
			this.CheckBox_SudakObiknovenniy_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_SudakObiknovenniy_PickUp.Location = new Point(41, 4);
			this.CheckBox_SudakObiknovenniy_PickUp.Name = "CheckBox_SudakObiknovenniy_PickUp";
			this.CheckBox_SudakObiknovenniy_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_SudakObiknovenniy_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_SudakObiknovenniy_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_SudakObiknovenniy_PickUp.Size = new Size(26, 26);
			this.CheckBox_SudakObiknovenniy_PickUp.TabIndex = 1;
			this.CheckBox_SudakObiknovenniy_PickUp.TabStop = false;
			this.CheckBox_SudakObiknovenniy_PickUp.Text = "pinkCheckBox62";
			this.panel99.BackColor = Color.FromArgb(17, 17, 17);
			this.panel99.Controls.Add(this.CheckBox_TemniyGorbil_Back);
			this.panel99.Location = new Point(354, 1369);
			this.panel99.Name = "panel99";
			this.panel99.Size = new Size(109, 35);
			this.panel99.TabIndex = 182;
			this.CheckBox_TemniyGorbil_Back.BackColor = Color.Transparent;
			this.CheckBox_TemniyGorbil_Back.CheckMarkColor = Color.White;
			this.CheckBox_TemniyGorbil_Back.CheckMarkOffsetY = -2;
			this.CheckBox_TemniyGorbil_Back.CornerRadius = 5;
			this.CheckBox_TemniyGorbil_Back.Cursor = Cursors.Hand;
			this.CheckBox_TemniyGorbil_Back.Location = new Point(41, 4);
			this.CheckBox_TemniyGorbil_Back.Name = "CheckBox_TemniyGorbil_Back";
			this.CheckBox_TemniyGorbil_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_TemniyGorbil_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_TemniyGorbil_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_TemniyGorbil_Back.Size = new Size(26, 26);
			this.CheckBox_TemniyGorbil_Back.TabIndex = 1;
			this.CheckBox_TemniyGorbil_Back.TabStop = false;
			this.CheckBox_TemniyGorbil_Back.Text = "pinkCheckBox64";
			this.panel85.BackColor = Color.FromArgb(17, 17, 17);
			this.panel85.Controls.Add(this.CheckBox_SomObiknovenniy_PickUp);
			this.panel85.Location = new Point(239, 1164);
			this.panel85.Name = "panel85";
			this.panel85.Size = new Size(109, 35);
			this.panel85.TabIndex = 169;
			this.CheckBox_SomObiknovenniy_PickUp.BackColor = Color.Transparent;
			this.CheckBox_SomObiknovenniy_PickUp.Checked = true;
			this.CheckBox_SomObiknovenniy_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_SomObiknovenniy_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_SomObiknovenniy_PickUp.CornerRadius = 5;
			this.CheckBox_SomObiknovenniy_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_SomObiknovenniy_PickUp.Location = new Point(41, 4);
			this.CheckBox_SomObiknovenniy_PickUp.Name = "CheckBox_SomObiknovenniy_PickUp";
			this.CheckBox_SomObiknovenniy_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_SomObiknovenniy_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_SomObiknovenniy_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_SomObiknovenniy_PickUp.Size = new Size(26, 26);
			this.CheckBox_SomObiknovenniy_PickUp.TabIndex = 1;
			this.CheckBox_SomObiknovenniy_PickUp.TabStop = false;
			this.CheckBox_SomObiknovenniy_PickUp.Text = "pinkCheckBox55";
			this.panel100.BackColor = Color.FromArgb(17, 17, 17);
			this.panel100.Controls.Add(this.CheckBox_TemniyGorbil_PickUp);
			this.panel100.Location = new Point(239, 1369);
			this.panel100.Name = "panel100";
			this.panel100.Size = new Size(109, 35);
			this.panel100.TabIndex = 181;
			this.CheckBox_TemniyGorbil_PickUp.BackColor = Color.Transparent;
			this.CheckBox_TemniyGorbil_PickUp.Checked = true;
			this.CheckBox_TemniyGorbil_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_TemniyGorbil_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_TemniyGorbil_PickUp.CornerRadius = 5;
			this.CheckBox_TemniyGorbil_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_TemniyGorbil_PickUp.Location = new Point(41, 4);
			this.CheckBox_TemniyGorbil_PickUp.Name = "CheckBox_TemniyGorbil_PickUp";
			this.CheckBox_TemniyGorbil_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_TemniyGorbil_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_TemniyGorbil_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_TemniyGorbil_PickUp.Size = new Size(26, 26);
			this.CheckBox_TemniyGorbil_PickUp.TabIndex = 1;
			this.CheckBox_TemniyGorbil_PickUp.TabStop = false;
			this.CheckBox_TemniyGorbil_PickUp.Text = "pinkCheckBox63";
			this.panel101.BackColor = Color.FromArgb(17, 17, 17);
			this.panel101.Controls.Add(this.label39);
			this.panel101.Location = new Point(0, 1369);
			this.panel101.Name = "panel101";
			this.panel101.Size = new Size(233, 35);
			this.panel101.TabIndex = 180;
			this.label39.AutoSize = true;
			this.label39.Font = new Font("Verdana", 12f);
			this.label39.ForeColor = Color.White;
			this.label39.Location = new Point(20, 7);
			this.label39.Name = "label39";
			this.label39.Size = new Size(146, 18);
			this.label39.TabIndex = 12;
			this.label39.Text = "Тёмный горбыль";
			this.label39.TextAlign = ContentAlignment.MiddleCenter;
			this.panel89.BackColor = Color.FromArgb(17, 17, 17);
			this.panel89.Controls.Add(this.label35);
			this.panel89.Location = new Point(0, 1287);
			this.panel89.Name = "panel89";
			this.panel89.Size = new Size(233, 35);
			this.panel89.TabIndex = 177;
			this.label35.AutoSize = true;
			this.label35.Font = new Font("Verdana", 12f);
			this.label35.ForeColor = Color.White;
			this.label35.Location = new Point(20, 7);
			this.label35.Name = "label35";
			this.label35.Size = new Size(186, 18);
			this.label35.TabIndex = 12;
			this.label35.Text = "Судак обыкновенный";
			this.label35.TextAlign = ContentAlignment.MiddleCenter;
			this.panel86.BackColor = Color.FromArgb(17, 17, 17);
			this.panel86.Controls.Add(this.label34);
			this.panel86.Location = new Point(0, 1164);
			this.panel86.Name = "panel86";
			this.panel86.Size = new Size(233, 35);
			this.panel86.TabIndex = 168;
			this.label34.AutoSize = true;
			this.label34.Font = new Font("Verdana", 12f);
			this.label34.ForeColor = Color.White;
			this.label34.Location = new Point(20, 7);
			this.label34.Name = "label34";
			this.label34.Size = new Size(169, 18);
			this.label34.TabIndex = 12;
			this.label34.Text = "Сом обыкновенный";
			this.label34.TextAlign = ContentAlignment.MiddleCenter;
			this.panel90.BackColor = Color.FromArgb(17, 17, 17);
			this.panel90.Controls.Add(this.CheckBox_Sterlyad_Back);
			this.panel90.Location = new Point(354, 1246);
			this.panel90.Name = "panel90";
			this.panel90.Size = new Size(109, 35);
			this.panel90.TabIndex = 175;
			this.CheckBox_Sterlyad_Back.BackColor = Color.Transparent;
			this.CheckBox_Sterlyad_Back.CheckMarkColor = Color.White;
			this.CheckBox_Sterlyad_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Sterlyad_Back.CornerRadius = 5;
			this.CheckBox_Sterlyad_Back.Cursor = Cursors.Hand;
			this.CheckBox_Sterlyad_Back.Location = new Point(41, 4);
			this.CheckBox_Sterlyad_Back.Name = "CheckBox_Sterlyad_Back";
			this.CheckBox_Sterlyad_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Sterlyad_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Sterlyad_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Sterlyad_Back.Size = new Size(26, 26);
			this.CheckBox_Sterlyad_Back.TabIndex = 1;
			this.CheckBox_Sterlyad_Back.TabStop = false;
			this.CheckBox_Sterlyad_Back.Text = "pinkCheckBox60";
			this.panel81.BackColor = Color.FromArgb(17, 17, 17);
			this.panel81.Controls.Add(this.CheckBox_SnukObiknovenniy_Back);
			this.panel81.Location = new Point(354, 1123);
			this.panel81.Name = "panel81";
			this.panel81.Size = new Size(109, 35);
			this.panel81.TabIndex = 167;
			this.CheckBox_SnukObiknovenniy_Back.BackColor = Color.Transparent;
			this.CheckBox_SnukObiknovenniy_Back.CheckMarkColor = Color.White;
			this.CheckBox_SnukObiknovenniy_Back.CheckMarkOffsetY = -2;
			this.CheckBox_SnukObiknovenniy_Back.CornerRadius = 5;
			this.CheckBox_SnukObiknovenniy_Back.Cursor = Cursors.Hand;
			this.CheckBox_SnukObiknovenniy_Back.Location = new Point(41, 4);
			this.CheckBox_SnukObiknovenniy_Back.Name = "CheckBox_SnukObiknovenniy_Back";
			this.CheckBox_SnukObiknovenniy_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_SnukObiknovenniy_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_SnukObiknovenniy_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_SnukObiknovenniy_Back.Size = new Size(26, 26);
			this.CheckBox_SnukObiknovenniy_Back.TabIndex = 1;
			this.CheckBox_SnukObiknovenniy_Back.TabStop = false;
			this.CheckBox_SnukObiknovenniy_Back.Text = "pinkCheckBox53";
			this.panel91.BackColor = Color.FromArgb(17, 17, 17);
			this.panel91.Controls.Add(this.CheckBox_StalnogoloviyLosos_Back);
			this.panel91.Location = new Point(354, 1205);
			this.panel91.Name = "panel91";
			this.panel91.Size = new Size(109, 35);
			this.panel91.TabIndex = 176;
			this.CheckBox_StalnogoloviyLosos_Back.BackColor = Color.Transparent;
			this.CheckBox_StalnogoloviyLosos_Back.CheckMarkColor = Color.White;
			this.CheckBox_StalnogoloviyLosos_Back.CheckMarkOffsetY = -2;
			this.CheckBox_StalnogoloviyLosos_Back.CornerRadius = 5;
			this.CheckBox_StalnogoloviyLosos_Back.Cursor = Cursors.Hand;
			this.CheckBox_StalnogoloviyLosos_Back.Location = new Point(41, 4);
			this.CheckBox_StalnogoloviyLosos_Back.Name = "CheckBox_StalnogoloviyLosos_Back";
			this.CheckBox_StalnogoloviyLosos_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_StalnogoloviyLosos_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_StalnogoloviyLosos_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_StalnogoloviyLosos_Back.Size = new Size(26, 26);
			this.CheckBox_StalnogoloviyLosos_Back.TabIndex = 1;
			this.CheckBox_StalnogoloviyLosos_Back.TabStop = false;
			this.CheckBox_StalnogoloviyLosos_Back.Text = "pinkCheckBox57";
			this.panel78.BackColor = Color.FromArgb(17, 17, 17);
			this.panel78.Controls.Add(this.CheckBox_Seriola_Back);
			this.panel78.Location = new Point(354, 1082);
			this.panel78.Name = "panel78";
			this.panel78.Size = new Size(109, 35);
			this.panel78.TabIndex = 166;
			this.CheckBox_Seriola_Back.BackColor = Color.Transparent;
			this.CheckBox_Seriola_Back.CheckMarkColor = Color.White;
			this.CheckBox_Seriola_Back.CheckMarkOffsetY = -2;
			this.CheckBox_Seriola_Back.CornerRadius = 5;
			this.CheckBox_Seriola_Back.Cursor = Cursors.Hand;
			this.CheckBox_Seriola_Back.Location = new Point(41, 4);
			this.CheckBox_Seriola_Back.Name = "CheckBox_Seriola_Back";
			this.CheckBox_Seriola_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Seriola_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Seriola_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Seriola_Back.Size = new Size(26, 26);
			this.CheckBox_Seriola_Back.TabIndex = 1;
			this.CheckBox_Seriola_Back.TabStop = false;
			this.CheckBox_Seriola_Back.Text = "pinkCheckBox52";
			this.panel92.BackColor = Color.FromArgb(17, 17, 17);
			this.panel92.Controls.Add(this.CheckBox_Sterlyad_PickUp);
			this.panel92.Location = new Point(239, 1246);
			this.panel92.Name = "panel92";
			this.panel92.Size = new Size(109, 35);
			this.panel92.TabIndex = 173;
			this.CheckBox_Sterlyad_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Sterlyad_PickUp.Checked = true;
			this.CheckBox_Sterlyad_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Sterlyad_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Sterlyad_PickUp.CornerRadius = 5;
			this.CheckBox_Sterlyad_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Sterlyad_PickUp.Location = new Point(41, 4);
			this.CheckBox_Sterlyad_PickUp.Name = "CheckBox_Sterlyad_PickUp";
			this.CheckBox_Sterlyad_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Sterlyad_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Sterlyad_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Sterlyad_PickUp.Size = new Size(26, 26);
			this.CheckBox_Sterlyad_PickUp.TabIndex = 1;
			this.CheckBox_Sterlyad_PickUp.TabStop = false;
			this.CheckBox_Sterlyad_PickUp.Text = "pinkCheckBox59";
			this.panel82.BackColor = Color.FromArgb(17, 17, 17);
			this.panel82.Controls.Add(this.CheckBox_SnukObiknovenniy_PickUp);
			this.panel82.Location = new Point(239, 1123);
			this.panel82.Name = "panel82";
			this.panel82.Size = new Size(109, 35);
			this.panel82.TabIndex = 165;
			this.CheckBox_SnukObiknovenniy_PickUp.BackColor = Color.Transparent;
			this.CheckBox_SnukObiknovenniy_PickUp.Checked = true;
			this.CheckBox_SnukObiknovenniy_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_SnukObiknovenniy_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_SnukObiknovenniy_PickUp.CornerRadius = 5;
			this.CheckBox_SnukObiknovenniy_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_SnukObiknovenniy_PickUp.Location = new Point(41, 4);
			this.CheckBox_SnukObiknovenniy_PickUp.Name = "CheckBox_SnukObiknovenniy_PickUp";
			this.CheckBox_SnukObiknovenniy_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_SnukObiknovenniy_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_SnukObiknovenniy_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_SnukObiknovenniy_PickUp.Size = new Size(26, 26);
			this.CheckBox_SnukObiknovenniy_PickUp.TabIndex = 1;
			this.CheckBox_SnukObiknovenniy_PickUp.TabStop = false;
			this.CheckBox_SnukObiknovenniy_PickUp.Text = "pinkCheckBox54";
			this.panel93.BackColor = Color.FromArgb(17, 17, 17);
			this.panel93.Controls.Add(this.label36);
			this.panel93.Location = new Point(0, 1246);
			this.panel93.Name = "panel93";
			this.panel93.Size = new Size(233, 35);
			this.panel93.TabIndex = 171;
			this.label36.AutoSize = true;
			this.label36.Font = new Font("Verdana", 12f);
			this.label36.ForeColor = Color.White;
			this.label36.Location = new Point(20, 7);
			this.label36.Name = "label36";
			this.label36.Size = new Size(85, 18);
			this.label36.TabIndex = 12;
			this.label36.Text = "Стерлядь";
			this.label36.TextAlign = ContentAlignment.MiddleCenter;
			this.panel83.BackColor = Color.FromArgb(17, 17, 17);
			this.panel83.Controls.Add(this.label33);
			this.panel83.Location = new Point(0, 1123);
			this.panel83.Name = "panel83";
			this.panel83.Size = new Size(233, 35);
			this.panel83.TabIndex = 163;
			this.label33.AutoSize = true;
			this.label33.Font = new Font("Verdana", 12f);
			this.label33.ForeColor = Color.White;
			this.label33.Location = new Point(20, 7);
			this.label33.Name = "label33";
			this.label33.Size = new Size(176, 18);
			this.label33.TabIndex = 12;
			this.label33.Text = "Снук обыкновенный";
			this.label33.TextAlign = ContentAlignment.MiddleCenter;
			this.panel94.BackColor = Color.FromArgb(17, 17, 17);
			this.panel94.Controls.Add(this.CheckBox_StalnogoloviyLosos_PickUp);
			this.panel94.Location = new Point(239, 1205);
			this.panel94.Name = "panel94";
			this.panel94.Size = new Size(109, 35);
			this.panel94.TabIndex = 174;
			this.CheckBox_StalnogoloviyLosos_PickUp.BackColor = Color.Transparent;
			this.CheckBox_StalnogoloviyLosos_PickUp.Checked = true;
			this.CheckBox_StalnogoloviyLosos_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_StalnogoloviyLosos_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_StalnogoloviyLosos_PickUp.CornerRadius = 5;
			this.CheckBox_StalnogoloviyLosos_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_StalnogoloviyLosos_PickUp.Location = new Point(41, 4);
			this.CheckBox_StalnogoloviyLosos_PickUp.Name = "CheckBox_StalnogoloviyLosos_PickUp";
			this.CheckBox_StalnogoloviyLosos_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_StalnogoloviyLosos_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_StalnogoloviyLosos_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_StalnogoloviyLosos_PickUp.Size = new Size(26, 26);
			this.CheckBox_StalnogoloviyLosos_PickUp.TabIndex = 1;
			this.CheckBox_StalnogoloviyLosos_PickUp.TabStop = false;
			this.CheckBox_StalnogoloviyLosos_PickUp.Text = "pinkCheckBox58";
			this.panel95.BackColor = Color.FromArgb(17, 17, 17);
			this.panel95.Controls.Add(this.label37);
			this.panel95.Location = new Point(0, 1205);
			this.panel95.Name = "panel95";
			this.panel95.Size = new Size(233, 35);
			this.panel95.TabIndex = 172;
			this.label37.AutoSize = true;
			this.label37.Font = new Font("Verdana", 12f);
			this.label37.ForeColor = Color.White;
			this.label37.Location = new Point(20, 7);
			this.label37.Name = "label37";
			this.label37.Size = new Size(208, 18);
			this.label37.TabIndex = 12;
			this.label37.Text = "Стальноголовый лосось";
			this.label37.TextAlign = ContentAlignment.MiddleCenter;
			this.panel75.BackColor = Color.FromArgb(17, 17, 17);
			this.panel75.Controls.Add(this.CheckBox_SerebryaniyKaras_Back);
			this.panel75.Location = new Point(354, 1041);
			this.panel75.Name = "panel75";
			this.panel75.Size = new Size(109, 35);
			this.panel75.TabIndex = 161;
			this.CheckBox_SerebryaniyKaras_Back.BackColor = Color.Transparent;
			this.CheckBox_SerebryaniyKaras_Back.CheckMarkColor = Color.White;
			this.CheckBox_SerebryaniyKaras_Back.CheckMarkOffsetY = -2;
			this.CheckBox_SerebryaniyKaras_Back.CornerRadius = 5;
			this.CheckBox_SerebryaniyKaras_Back.Cursor = Cursors.Hand;
			this.CheckBox_SerebryaniyKaras_Back.Location = new Point(41, 4);
			this.CheckBox_SerebryaniyKaras_Back.Name = "CheckBox_SerebryaniyKaras_Back";
			this.CheckBox_SerebryaniyKaras_Back.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_SerebryaniyKaras_Back.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_SerebryaniyKaras_Back.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_SerebryaniyKaras_Back.Size = new Size(26, 26);
			this.CheckBox_SerebryaniyKaras_Back.TabIndex = 1;
			this.CheckBox_SerebryaniyKaras_Back.TabStop = false;
			this.CheckBox_SerebryaniyKaras_Back.Text = "pinkCheckBox49";
			this.panel79.BackColor = Color.FromArgb(17, 17, 17);
			this.panel79.Controls.Add(this.CheckBox_Seriola_PickUp);
			this.panel79.Location = new Point(239, 1082);
			this.panel79.Name = "panel79";
			this.panel79.Size = new Size(109, 35);
			this.panel79.TabIndex = 164;
			this.CheckBox_Seriola_PickUp.BackColor = Color.Transparent;
			this.CheckBox_Seriola_PickUp.Checked = true;
			this.CheckBox_Seriola_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_Seriola_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_Seriola_PickUp.CornerRadius = 5;
			this.CheckBox_Seriola_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_Seriola_PickUp.Location = new Point(41, 4);
			this.CheckBox_Seriola_PickUp.Name = "CheckBox_Seriola_PickUp";
			this.CheckBox_Seriola_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_Seriola_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_Seriola_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_Seriola_PickUp.Size = new Size(26, 26);
			this.CheckBox_Seriola_PickUp.TabIndex = 1;
			this.CheckBox_Seriola_PickUp.TabStop = false;
			this.CheckBox_Seriola_PickUp.Text = "pinkCheckBox51";
			this.panel80.BackColor = Color.FromArgb(17, 17, 17);
			this.panel80.Controls.Add(this.label32);
			this.panel80.Location = new Point(0, 1082);
			this.panel80.Name = "panel80";
			this.panel80.Size = new Size(233, 35);
			this.panel80.TabIndex = 162;
			this.label32.AutoSize = true;
			this.label32.Font = new Font("Verdana", 12f);
			this.label32.ForeColor = Color.White;
			this.label32.Location = new Point(20, 7);
			this.label32.Name = "label32";
			this.label32.Size = new Size(79, 18);
			this.label32.TabIndex = 12;
			this.label32.Text = "Сериола";
			this.label32.TextAlign = ContentAlignment.MiddleCenter;
			this.panel76.BackColor = Color.FromArgb(17, 17, 17);
			this.panel76.Controls.Add(this.CheckBox_SerebryaniyKaras_PickUp);
			this.panel76.Location = new Point(239, 1041);
			this.panel76.Name = "panel76";
			this.panel76.Size = new Size(109, 35);
			this.panel76.TabIndex = 160;
			this.CheckBox_SerebryaniyKaras_PickUp.BackColor = Color.Transparent;
			this.CheckBox_SerebryaniyKaras_PickUp.Checked = true;
			this.CheckBox_SerebryaniyKaras_PickUp.CheckMarkColor = Color.White;
			this.CheckBox_SerebryaniyKaras_PickUp.CheckMarkOffsetY = -2;
			this.CheckBox_SerebryaniyKaras_PickUp.CornerRadius = 5;
			this.CheckBox_SerebryaniyKaras_PickUp.Cursor = Cursors.Hand;
			this.CheckBox_SerebryaniyKaras_PickUp.Location = new Point(41, 4);
			this.CheckBox_SerebryaniyKaras_PickUp.Name = "CheckBox_SerebryaniyKaras_PickUp";
			this.CheckBox_SerebryaniyKaras_PickUp.OffBackColor = Color.FromArgb(36, 36, 36);
			this.CheckBox_SerebryaniyKaras_PickUp.OffBorderColor = Color.FromArgb(58, 58, 58);
			this.CheckBox_SerebryaniyKaras_PickUp.OnBackColor = Color.FromArgb(236, 36, 104);
			this.CheckBox_SerebryaniyKaras_PickUp.Size = new Size(26, 26);
			this.CheckBox_SerebryaniyKaras_PickUp.TabIndex = 1;
			this.CheckBox_SerebryaniyKaras_PickUp.TabStop = false;
			this.CheckBox_SerebryaniyKaras_PickUp.Text = "pinkCheckBox50";
			this.panel77.BackColor = Color.FromArgb(17, 17, 17);
			this.panel77.Controls.Add(this.label31);
			this.panel77.Location = new Point(0, 1041);
			this.panel77.Name = "panel77";
			this.panel77.Size = new Size(233, 35);
			this.panel77.TabIndex = 159;
			this.label31.AutoSize = true;
			this.label31.Font = new Font("Verdana", 12f);
			this.label31.ForeColor = Color.White;
			this.label31.Location = new Point(20, 7);
			this.label31.Name = "label31";
			this.label31.Size = new Size(174, 18);
			this.label31.TabIndex = 12;
			this.label31.Text = "Серебряный карась";
			this.label31.TextAlign = ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoScroll = true;
			base.AutoScrollMinSize = new Size(463, 1452);
			this.BackColor = Color.FromArgb(22, 22, 22);
			base.Controls.Add(this.panel11);
			base.Controls.Add(this.panel104);
			base.Controls.Add(this.panel105);
			base.Controls.Add(this.panel96);
			base.Controls.Add(this.panel87);
			base.Controls.Add(this.panel97);
			base.Controls.Add(this.panel84);
			base.Controls.Add(this.panel98);
			base.Controls.Add(this.panel88);
			base.Controls.Add(this.panel99);
			base.Controls.Add(this.panel85);
			base.Controls.Add(this.panel100);
			base.Controls.Add(this.panel101);
			base.Controls.Add(this.panel89);
			base.Controls.Add(this.panel86);
			base.Controls.Add(this.panel90);
			base.Controls.Add(this.panel81);
			base.Controls.Add(this.panel91);
			base.Controls.Add(this.panel78);
			base.Controls.Add(this.panel92);
			base.Controls.Add(this.panel82);
			base.Controls.Add(this.panel93);
			base.Controls.Add(this.panel83);
			base.Controls.Add(this.panel94);
			base.Controls.Add(this.panel95);
			base.Controls.Add(this.panel75);
			base.Controls.Add(this.panel79);
			base.Controls.Add(this.panel80);
			base.Controls.Add(this.panel76);
			base.Controls.Add(this.panel77);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel102);
			base.Controls.Add(this.panel103);
			base.Controls.Add(this.panel72);
			base.Controls.Add(this.panel69);
			base.Controls.Add(this.panel73);
			base.Controls.Add(this.panel74);
			base.Controls.Add(this.panel42);
			base.Controls.Add(this.panel70);
			base.Controls.Add(this.panel33);
			base.Controls.Add(this.panel71);
			base.Controls.Add(this.panel43);
			base.Controls.Add(this.panel34);
			base.Controls.Add(this.panel44);
			base.Controls.Add(this.panel35);
			base.Controls.Add(this.panel45);
			base.Controls.Add(this.panel36);
			base.Controls.Add(this.panel46);
			base.Controls.Add(this.panel37);
			base.Controls.Add(this.panel47);
			base.Controls.Add(this.panel38);
			base.Controls.Add(this.panel48);
			base.Controls.Add(this.panel39);
			base.Controls.Add(this.panel49);
			base.Controls.Add(this.panel40);
			base.Controls.Add(this.panel50);
			base.Controls.Add(this.panel41);
			base.Controls.Add(this.panel51);
			base.Controls.Add(this.panel24);
			base.Controls.Add(this.panel52);
			base.Controls.Add(this.panel21);
			base.Controls.Add(this.panel53);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel54);
			base.Controls.Add(this.panel22);
			base.Controls.Add(this.panel55);
			base.Controls.Add(this.panel26);
			base.Controls.Add(this.panel56);
			base.Controls.Add(this.panel23);
			base.Controls.Add(this.panel57);
			base.Controls.Add(this.panel27);
			base.Controls.Add(this.panel58);
			base.Controls.Add(this.panel18);
			base.Controls.Add(this.panel59);
			base.Controls.Add(this.panel28);
			base.Controls.Add(this.panel60);
			base.Controls.Add(this.panel61);
			base.Controls.Add(this.panel29);
			base.Controls.Add(this.panel62);
			base.Controls.Add(this.panel19);
			base.Controls.Add(this.panel63);
			base.Controls.Add(this.panel30);
			base.Controls.Add(this.panel64);
			base.Controls.Add(this.panel20);
			base.Controls.Add(this.panel65);
			base.Controls.Add(this.panel31);
			base.Controls.Add(this.panel66);
			base.Controls.Add(this.panel67);
			base.Controls.Add(this.panel32);
			base.Controls.Add(this.panel68);
			base.Controls.Add(this.panel7);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel15);
			base.Controls.Add(this.panel14);
			base.Controls.Add(this.panel16);
			base.Controls.Add(this.panel17);
			base.Controls.Add(this.panel13);
			base.Controls.Add(this.panel12);
			base.Controls.Add(this.panel10);
			base.Controls.Add(this.panel9);
			base.Controls.Add(this.panel8);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Name = "FishContent";
			base.Size = new Size(446, 783);
			this.panel15.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panel16.ResumeLayout(false);
			this.panel17.ResumeLayout(false);
			this.panel17.PerformLayout();
			this.panel13.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel102.ResumeLayout(false);
			this.panel103.ResumeLayout(false);
			this.panel103.PerformLayout();
			this.panel72.ResumeLayout(false);
			this.panel69.ResumeLayout(false);
			this.panel73.ResumeLayout(false);
			this.panel74.ResumeLayout(false);
			this.panel74.PerformLayout();
			this.panel42.ResumeLayout(false);
			this.panel70.ResumeLayout(false);
			this.panel33.ResumeLayout(false);
			this.panel71.ResumeLayout(false);
			this.panel71.PerformLayout();
			this.panel43.ResumeLayout(false);
			this.panel34.ResumeLayout(false);
			this.panel44.ResumeLayout(false);
			this.panel44.PerformLayout();
			this.panel35.ResumeLayout(false);
			this.panel35.PerformLayout();
			this.panel45.ResumeLayout(false);
			this.panel36.ResumeLayout(false);
			this.panel46.ResumeLayout(false);
			this.panel37.ResumeLayout(false);
			this.panel47.ResumeLayout(false);
			this.panel38.ResumeLayout(false);
			this.panel48.ResumeLayout(false);
			this.panel48.PerformLayout();
			this.panel39.ResumeLayout(false);
			this.panel39.PerformLayout();
			this.panel49.ResumeLayout(false);
			this.panel40.ResumeLayout(false);
			this.panel50.ResumeLayout(false);
			this.panel50.PerformLayout();
			this.panel41.ResumeLayout(false);
			this.panel41.PerformLayout();
			this.panel51.ResumeLayout(false);
			this.panel24.ResumeLayout(false);
			this.panel52.ResumeLayout(false);
			this.panel21.ResumeLayout(false);
			this.panel53.ResumeLayout(false);
			this.panel25.ResumeLayout(false);
			this.panel54.ResumeLayout(false);
			this.panel22.ResumeLayout(false);
			this.panel55.ResumeLayout(false);
			this.panel55.PerformLayout();
			this.panel26.ResumeLayout(false);
			this.panel26.PerformLayout();
			this.panel56.ResumeLayout(false);
			this.panel56.PerformLayout();
			this.panel23.ResumeLayout(false);
			this.panel23.PerformLayout();
			this.panel57.ResumeLayout(false);
			this.panel27.ResumeLayout(false);
			this.panel58.ResumeLayout(false);
			this.panel18.ResumeLayout(false);
			this.panel59.ResumeLayout(false);
			this.panel28.ResumeLayout(false);
			this.panel60.ResumeLayout(false);
			this.panel61.ResumeLayout(false);
			this.panel29.ResumeLayout(false);
			this.panel62.ResumeLayout(false);
			this.panel19.ResumeLayout(false);
			this.panel63.ResumeLayout(false);
			this.panel63.PerformLayout();
			this.panel30.ResumeLayout(false);
			this.panel30.PerformLayout();
			this.panel64.ResumeLayout(false);
			this.panel64.PerformLayout();
			this.panel20.ResumeLayout(false);
			this.panel20.PerformLayout();
			this.panel65.ResumeLayout(false);
			this.panel31.ResumeLayout(false);
			this.panel66.ResumeLayout(false);
			this.panel67.ResumeLayout(false);
			this.panel67.PerformLayout();
			this.panel32.ResumeLayout(false);
			this.panel32.PerformLayout();
			this.panel68.ResumeLayout(false);
			this.panel68.PerformLayout();
			this.panel11.ResumeLayout(false);
			this.panel104.ResumeLayout(false);
			this.panel105.ResumeLayout(false);
			this.panel105.PerformLayout();
			this.panel96.ResumeLayout(false);
			this.panel87.ResumeLayout(false);
			this.panel97.ResumeLayout(false);
			this.panel84.ResumeLayout(false);
			this.panel98.ResumeLayout(false);
			this.panel98.PerformLayout();
			this.panel88.ResumeLayout(false);
			this.panel99.ResumeLayout(false);
			this.panel85.ResumeLayout(false);
			this.panel100.ResumeLayout(false);
			this.panel101.ResumeLayout(false);
			this.panel101.PerformLayout();
			this.panel89.ResumeLayout(false);
			this.panel89.PerformLayout();
			this.panel86.ResumeLayout(false);
			this.panel86.PerformLayout();
			this.panel90.ResumeLayout(false);
			this.panel81.ResumeLayout(false);
			this.panel91.ResumeLayout(false);
			this.panel78.ResumeLayout(false);
			this.panel92.ResumeLayout(false);
			this.panel82.ResumeLayout(false);
			this.panel93.ResumeLayout(false);
			this.panel93.PerformLayout();
			this.panel83.ResumeLayout(false);
			this.panel83.PerformLayout();
			this.panel94.ResumeLayout(false);
			this.panel95.ResumeLayout(false);
			this.panel95.PerformLayout();
			this.panel75.ResumeLayout(false);
			this.panel79.ResumeLayout(false);
			this.panel80.ResumeLayout(false);
			this.panel80.PerformLayout();
			this.panel76.ResumeLayout(false);
			this.panel77.ResumeLayout(false);
			this.panel77.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000054 RID: 84
		private static bool ModestCatch;

		// Token: 0x04000055 RID: 85
		private static bool GoodCatch;

		// Token: 0x04000056 RID: 86
		private static bool RecordCatch;

		// Token: 0x04000057 RID: 87
		private static bool TrophyCatch;

		// Token: 0x04000058 RID: 88
		private static bool Albula;

		// Token: 0x04000059 RID: 89
		private static bool Barrakuda;

		// Token: 0x0400005A RID: 90
		private static bool Vobla;

		// Token: 0x0400005B RID: 91
		private static bool Golavl;

		// Token: 0x0400005C RID: 92
		private static bool DrevnyayaGineriya;

		// Token: 0x0400005D RID: 93
		private static bool Jereh;

		// Token: 0x0400005E RID: 94
		private static bool ZerkalniyKarp;

		// Token: 0x0400005F RID: 95
		private static bool KorichneviySom;

		// Token: 0x04000060 RID: 96
		private static bool Krasnoperka;

		// Token: 0x04000061 RID: 97
		private static bool KrasniyGorbil;

		// Token: 0x04000062 RID: 98
		private static bool KrugliyTrahinot;

		// Token: 0x04000063 RID: 99
		private static bool Lesh;

		// Token: 0x04000064 RID: 100
		private static bool Marlin;

		// Token: 0x04000065 RID: 101
		private static bool ObiknovennayaShuka;

		// Token: 0x04000066 RID: 102
		private static bool Plotva;

		// Token: 0x04000067 RID: 103
		private static bool PolosatiyLavrak;

		// Token: 0x04000068 RID: 104
		private static bool PribrejniyBass;

		// Token: 0x04000069 RID: 105
		private static bool RadujnayaForel;

		// Token: 0x0400006A RID: 106
		private static bool RechnoyOkun;

		// Token: 0x0400006B RID: 107
		private static bool Ruster;

		// Token: 0x0400006C RID: 108
		private static bool Sazan;

		// Token: 0x0400006D RID: 109
		private static bool SerebryaniyKaras;

		// Token: 0x0400006E RID: 110
		private static bool Seriola;

		// Token: 0x0400006F RID: 111
		private static bool SnukObiknovenniy;

		// Token: 0x04000070 RID: 112
		private static bool SomObiknovenniy;

		// Token: 0x04000071 RID: 113
		private static bool StalnogoloviyLosos;

		// Token: 0x04000072 RID: 114
		private static bool Sterlyad;

		// Token: 0x04000073 RID: 115
		private static bool SudakObiknovenniy;

		// Token: 0x04000074 RID: 116
		private static bool Tarpon;

		// Token: 0x04000075 RID: 117
		private static bool TemniyGorbil;

		// Token: 0x04000076 RID: 118
		private static bool ToksichniyOkun;

		// Token: 0x04000077 RID: 119
		private bool _bulkUpdating;

		// Token: 0x04000078 RID: 120
		private const string Prefix = "CheckBox_";

		// Token: 0x04000079 RID: 121
		private const string PickUpSuffix = "_PickUp";

		// Token: 0x0400007A RID: 122
		private const string BackSuffix = "_Back";

		// Token: 0x0400007B RID: 123
		private static readonly BindingFlags FieldFlags = BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

		// Token: 0x0400007C RID: 124
		private IContainer components;

		// Token: 0x0400007D RID: 125
		private Panel panel15;

		// Token: 0x0400007E RID: 126
		private PinkCheckBox CheckBox_ModestCatch_Back;

		// Token: 0x0400007F RID: 127
		private Panel panel14;

		// Token: 0x04000080 RID: 128
		private PinkCheckBox CheckBox_TrophyCatch_Back;

		// Token: 0x04000081 RID: 129
		private Panel panel16;

		// Token: 0x04000082 RID: 130
		private PinkCheckBox CheckBox_ModestCatch_PickUp;

		// Token: 0x04000083 RID: 131
		private Panel panel17;

		// Token: 0x04000084 RID: 132
		private Label label10;

		// Token: 0x04000085 RID: 133
		private Panel panel13;

		// Token: 0x04000086 RID: 134
		private PinkCheckBox CheckBox_TrophyCatch_PickUp;

		// Token: 0x04000087 RID: 135
		private Panel panel12;

		// Token: 0x04000088 RID: 136
		private PinkCheckBox CheckBox_RecordCatch_Back;

		// Token: 0x04000089 RID: 137
		private Panel panel10;

		// Token: 0x0400008A RID: 138
		private PinkCheckBox CheckBox_RecordCatch_PickUp;

		// Token: 0x0400008B RID: 139
		private Panel panel9;

		// Token: 0x0400008C RID: 140
		private PinkCheckBox CheckBox_GoodCatch_Back;

		// Token: 0x0400008D RID: 141
		private Panel panel8;

		// Token: 0x0400008E RID: 142
		private PinkCheckBox CheckBox_GoodCatch_PickUp;

		// Token: 0x0400008F RID: 143
		private Panel panel5;

		// Token: 0x04000090 RID: 144
		private Label label9;

		// Token: 0x04000091 RID: 145
		private Panel panel4;

		// Token: 0x04000092 RID: 146
		private Label label8;

		// Token: 0x04000093 RID: 147
		private Panel panel3;

		// Token: 0x04000094 RID: 148
		private Label label7;

		// Token: 0x04000095 RID: 149
		private Panel panel7;

		// Token: 0x04000096 RID: 150
		private PinkCheckBox CheckBox_Albula_Back;

		// Token: 0x04000097 RID: 151
		private Panel panel6;

		// Token: 0x04000098 RID: 152
		private PinkCheckBox CheckBox_Albula_PickUp;

		// Token: 0x04000099 RID: 153
		private Panel panel2;

		// Token: 0x0400009A RID: 154
		private Label label6;

		// Token: 0x0400009B RID: 155
		private Panel panel1;

		// Token: 0x0400009C RID: 156
		private PinkCheckBox CheckBox_Lesh_Back;

		// Token: 0x0400009D RID: 157
		private Panel panel102;

		// Token: 0x0400009E RID: 158
		private PinkCheckBox CheckBox_Lesh_PickUp;

		// Token: 0x0400009F RID: 159
		private Panel panel103;

		// Token: 0x040000A0 RID: 160
		private Label label3;

		// Token: 0x040000A1 RID: 161
		private Panel panel72;

		// Token: 0x040000A2 RID: 162
		private PinkCheckBox CheckBox_Sazan_Back;

		// Token: 0x040000A3 RID: 163
		private Panel panel69;

		// Token: 0x040000A4 RID: 164
		private PinkCheckBox CheckBox_Ruster_Back;

		// Token: 0x040000A5 RID: 165
		private Panel panel73;

		// Token: 0x040000A6 RID: 166
		private PinkCheckBox CheckBox_Sazan_PickUp;

		// Token: 0x040000A7 RID: 167
		private Panel panel74;

		// Token: 0x040000A8 RID: 168
		private Label label30;

		// Token: 0x040000A9 RID: 169
		private Panel panel42;

		// Token: 0x040000AA RID: 170
		private PinkCheckBox CheckBox_RechnoyOkun_Back;

		// Token: 0x040000AB RID: 171
		private Panel panel70;

		// Token: 0x040000AC RID: 172
		private PinkCheckBox CheckBox_Ruster_PickUp;

		// Token: 0x040000AD RID: 173
		private Panel panel33;

		// Token: 0x040000AE RID: 174
		private PinkCheckBox CheckBox_Krasnoperka_Back;

		// Token: 0x040000AF RID: 175
		private Panel panel71;

		// Token: 0x040000B0 RID: 176
		private Label label29;

		// Token: 0x040000B1 RID: 177
		private Panel panel43;

		// Token: 0x040000B2 RID: 178
		private PinkCheckBox CheckBox_RechnoyOkun_PickUp;

		// Token: 0x040000B3 RID: 179
		private Panel panel34;

		// Token: 0x040000B4 RID: 180
		private PinkCheckBox CheckBox_Krasnoperka_PickUp;

		// Token: 0x040000B5 RID: 181
		private Panel panel44;

		// Token: 0x040000B6 RID: 182
		private Label label20;

		// Token: 0x040000B7 RID: 183
		private Panel panel35;

		// Token: 0x040000B8 RID: 184
		private Label label17;

		// Token: 0x040000B9 RID: 185
		private Panel panel45;

		// Token: 0x040000BA RID: 186
		private PinkCheckBox CheckBox_RadujnayaForel_Back;

		// Token: 0x040000BB RID: 187
		private Panel panel36;

		// Token: 0x040000BC RID: 188
		private PinkCheckBox CheckBox_KorichneviySom_Back;

		// Token: 0x040000BD RID: 189
		private Panel panel46;

		// Token: 0x040000BE RID: 190
		private PinkCheckBox CheckBox_PribrejniyBass_Back;

		// Token: 0x040000BF RID: 191
		private Panel panel37;

		// Token: 0x040000C0 RID: 192
		private PinkCheckBox CheckBox_ZerkalniyKarp_Back;

		// Token: 0x040000C1 RID: 193
		private Panel panel47;

		// Token: 0x040000C2 RID: 194
		private PinkCheckBox CheckBox_RadujnayaForel_PickUp;

		// Token: 0x040000C3 RID: 195
		private Panel panel38;

		// Token: 0x040000C4 RID: 196
		private PinkCheckBox CheckBox_KorichneviySom_PickUp;

		// Token: 0x040000C5 RID: 197
		private Panel panel48;

		// Token: 0x040000C6 RID: 198
		private Label label21;

		// Token: 0x040000C7 RID: 199
		private Panel panel39;

		// Token: 0x040000C8 RID: 200
		private Label label18;

		// Token: 0x040000C9 RID: 201
		private Panel panel49;

		// Token: 0x040000CA RID: 202
		private PinkCheckBox CheckBox_PribrejniyBass_PickUp;

		// Token: 0x040000CB RID: 203
		private Panel panel40;

		// Token: 0x040000CC RID: 204
		private PinkCheckBox CheckBox_ZerkalniyKarp_PickUp;

		// Token: 0x040000CD RID: 205
		private Panel panel50;

		// Token: 0x040000CE RID: 206
		private Label label22;

		// Token: 0x040000CF RID: 207
		private Panel panel41;

		// Token: 0x040000D0 RID: 208
		private Label label19;

		// Token: 0x040000D1 RID: 209
		private Panel panel51;

		// Token: 0x040000D2 RID: 210
		private PinkCheckBox CheckBox_PolosatiyLavrak_Back;

		// Token: 0x040000D3 RID: 211
		private Panel panel24;

		// Token: 0x040000D4 RID: 212
		private PinkCheckBox CheckBox_Jereh_Back;

		// Token: 0x040000D5 RID: 213
		private Panel panel52;

		// Token: 0x040000D6 RID: 214
		private PinkCheckBox CheckBox_Marlin_Back;

		// Token: 0x040000D7 RID: 215
		private Panel panel21;

		// Token: 0x040000D8 RID: 216
		private PinkCheckBox CheckBox_Vobla_Back;

		// Token: 0x040000D9 RID: 217
		private Panel panel53;

		// Token: 0x040000DA RID: 218
		private PinkCheckBox CheckBox_PolosatiyLavrak_PickUp;

		// Token: 0x040000DB RID: 219
		private Panel panel25;

		// Token: 0x040000DC RID: 220
		private PinkCheckBox CheckBox_Jereh_PickUp;

		// Token: 0x040000DD RID: 221
		private Panel panel54;

		// Token: 0x040000DE RID: 222
		private PinkCheckBox CheckBox_Marlin_PickUp;

		// Token: 0x040000DF RID: 223
		private Panel panel22;

		// Token: 0x040000E0 RID: 224
		private PinkCheckBox CheckBox_Vobla_PickUp;

		// Token: 0x040000E1 RID: 225
		private Panel panel55;

		// Token: 0x040000E2 RID: 226
		private Label label23;

		// Token: 0x040000E3 RID: 227
		private Panel panel26;

		// Token: 0x040000E4 RID: 228
		private Label label14;

		// Token: 0x040000E5 RID: 229
		private Panel panel56;

		// Token: 0x040000E6 RID: 230
		private Label label24;

		// Token: 0x040000E7 RID: 231
		private Panel panel23;

		// Token: 0x040000E8 RID: 232
		private Label label13;

		// Token: 0x040000E9 RID: 233
		private Panel panel57;

		// Token: 0x040000EA RID: 234
		private PinkCheckBox CheckBox_Plotva_Back;

		// Token: 0x040000EB RID: 235
		private Panel panel27;

		// Token: 0x040000EC RID: 236
		private PinkCheckBox CheckBox_DrevnyayaGineriya_Back;

		// Token: 0x040000ED RID: 237
		private Panel panel58;

		// Token: 0x040000EE RID: 238
		private PinkCheckBox CheckBox_KrugliyTrahinot_Back;

		// Token: 0x040000EF RID: 239
		private Panel panel18;

		// Token: 0x040000F0 RID: 240
		private PinkCheckBox CheckBox_Barrakuda_Back;

		// Token: 0x040000F1 RID: 241
		private Panel panel59;

		// Token: 0x040000F2 RID: 242
		private PinkCheckBox CheckBox_ObiknovennayaShuka_Back;

		// Token: 0x040000F3 RID: 243
		private Panel panel28;

		// Token: 0x040000F4 RID: 244
		private PinkCheckBox CheckBox_Golavl_Back;

		// Token: 0x040000F5 RID: 245
		private Panel panel60;

		// Token: 0x040000F6 RID: 246
		private PinkCheckBox CheckBox_KrasniyGorbil_Back;

		// Token: 0x040000F7 RID: 247
		private Panel panel61;

		// Token: 0x040000F8 RID: 248
		private PinkCheckBox CheckBox_Plotva_PickUp;

		// Token: 0x040000F9 RID: 249
		private Panel panel29;

		// Token: 0x040000FA RID: 250
		private PinkCheckBox CheckBox_DrevnyayaGineriya_PickUp;

		// Token: 0x040000FB RID: 251
		private Panel panel62;

		// Token: 0x040000FC RID: 252
		private PinkCheckBox CheckBox_KrugliyTrahinot_PickUp;

		// Token: 0x040000FD RID: 253
		private Panel panel19;

		// Token: 0x040000FE RID: 254
		private PinkCheckBox CheckBox_Barrakuda_PickUp;

		// Token: 0x040000FF RID: 255
		private Panel panel63;

		// Token: 0x04000100 RID: 256
		private Label label25;

		// Token: 0x04000101 RID: 257
		private Panel panel30;

		// Token: 0x04000102 RID: 258
		private Label label15;

		// Token: 0x04000103 RID: 259
		private Panel panel64;

		// Token: 0x04000104 RID: 260
		private Label label26;

		// Token: 0x04000105 RID: 261
		private Panel panel20;

		// Token: 0x04000106 RID: 262
		private Label label11;

		// Token: 0x04000107 RID: 263
		private Panel panel65;

		// Token: 0x04000108 RID: 264
		private PinkCheckBox CheckBox_ObiknovennayaShuka_PickUp;

		// Token: 0x04000109 RID: 265
		private Panel panel31;

		// Token: 0x0400010A RID: 266
		private PinkCheckBox CheckBox_Golavl_PickUp;

		// Token: 0x0400010B RID: 267
		private Panel panel66;

		// Token: 0x0400010C RID: 268
		private PinkCheckBox CheckBox_KrasniyGorbil_PickUp;

		// Token: 0x0400010D RID: 269
		private Panel panel67;

		// Token: 0x0400010E RID: 270
		private Label label27;

		// Token: 0x0400010F RID: 271
		private Panel panel32;

		// Token: 0x04000110 RID: 272
		private Label label16;

		// Token: 0x04000111 RID: 273
		private Panel panel68;

		// Token: 0x04000112 RID: 274
		private Label label28;

		// Token: 0x04000113 RID: 275
		private Panel panel11;

		// Token: 0x04000114 RID: 276
		private PinkCheckBox CheckBox_Tarpon_Back;

		// Token: 0x04000115 RID: 277
		private Panel panel104;

		// Token: 0x04000116 RID: 278
		private PinkCheckBox CheckBox_Tarpon_PickUp;

		// Token: 0x04000117 RID: 279
		private Panel panel105;

		// Token: 0x04000118 RID: 280
		private Label label1;

		// Token: 0x04000119 RID: 281
		private Panel panel96;

		// Token: 0x0400011A RID: 282
		private PinkCheckBox CheckBox_ToksichniyOkun_Back;

		// Token: 0x0400011B RID: 283
		private Panel panel87;

		// Token: 0x0400011C RID: 284
		private PinkCheckBox CheckBox_SudakObiknovenniy_Back;

		// Token: 0x0400011D RID: 285
		private Panel panel97;

		// Token: 0x0400011E RID: 286
		private PinkCheckBox CheckBox_ToksichniyOkun_PickUp;

		// Token: 0x0400011F RID: 287
		private Panel panel84;

		// Token: 0x04000120 RID: 288
		private PinkCheckBox CheckBox_SomObiknovenniy_Back;

		// Token: 0x04000121 RID: 289
		private Panel panel98;

		// Token: 0x04000122 RID: 290
		private Label label38;

		// Token: 0x04000123 RID: 291
		private Panel panel88;

		// Token: 0x04000124 RID: 292
		private PinkCheckBox CheckBox_SudakObiknovenniy_PickUp;

		// Token: 0x04000125 RID: 293
		private Panel panel99;

		// Token: 0x04000126 RID: 294
		private PinkCheckBox CheckBox_TemniyGorbil_Back;

		// Token: 0x04000127 RID: 295
		private Panel panel85;

		// Token: 0x04000128 RID: 296
		private PinkCheckBox CheckBox_SomObiknovenniy_PickUp;

		// Token: 0x04000129 RID: 297
		private Panel panel100;

		// Token: 0x0400012A RID: 298
		private PinkCheckBox CheckBox_TemniyGorbil_PickUp;

		// Token: 0x0400012B RID: 299
		private Panel panel101;

		// Token: 0x0400012C RID: 300
		private Label label39;

		// Token: 0x0400012D RID: 301
		private Panel panel89;

		// Token: 0x0400012E RID: 302
		private Label label35;

		// Token: 0x0400012F RID: 303
		private Panel panel86;

		// Token: 0x04000130 RID: 304
		private Label label34;

		// Token: 0x04000131 RID: 305
		private Panel panel90;

		// Token: 0x04000132 RID: 306
		private PinkCheckBox CheckBox_Sterlyad_Back;

		// Token: 0x04000133 RID: 307
		private Panel panel81;

		// Token: 0x04000134 RID: 308
		private PinkCheckBox CheckBox_SnukObiknovenniy_Back;

		// Token: 0x04000135 RID: 309
		private Panel panel91;

		// Token: 0x04000136 RID: 310
		private PinkCheckBox CheckBox_StalnogoloviyLosos_Back;

		// Token: 0x04000137 RID: 311
		private Panel panel78;

		// Token: 0x04000138 RID: 312
		private PinkCheckBox CheckBox_Seriola_Back;

		// Token: 0x04000139 RID: 313
		private Panel panel92;

		// Token: 0x0400013A RID: 314
		private PinkCheckBox CheckBox_Sterlyad_PickUp;

		// Token: 0x0400013B RID: 315
		private Panel panel82;

		// Token: 0x0400013C RID: 316
		private PinkCheckBox CheckBox_SnukObiknovenniy_PickUp;

		// Token: 0x0400013D RID: 317
		private Panel panel93;

		// Token: 0x0400013E RID: 318
		private Label label36;

		// Token: 0x0400013F RID: 319
		private Panel panel83;

		// Token: 0x04000140 RID: 320
		private Label label33;

		// Token: 0x04000141 RID: 321
		private Panel panel94;

		// Token: 0x04000142 RID: 322
		private PinkCheckBox CheckBox_StalnogoloviyLosos_PickUp;

		// Token: 0x04000143 RID: 323
		private Panel panel95;

		// Token: 0x04000144 RID: 324
		private Label label37;

		// Token: 0x04000145 RID: 325
		private Panel panel75;

		// Token: 0x04000146 RID: 326
		private PinkCheckBox CheckBox_SerebryaniyKaras_Back;

		// Token: 0x04000147 RID: 327
		private Panel panel79;

		// Token: 0x04000148 RID: 328
		private PinkCheckBox CheckBox_Seriola_PickUp;

		// Token: 0x04000149 RID: 329
		private Panel panel80;

		// Token: 0x0400014A RID: 330
		private Label label32;

		// Token: 0x0400014B RID: 331
		private Panel panel76;

		// Token: 0x0400014C RID: 332
		private PinkCheckBox CheckBox_SerebryaniyKaras_PickUp;

		// Token: 0x0400014D RID: 333
		private Panel panel77;

		// Token: 0x0400014E RID: 334
		private Label label31;
	}
}
