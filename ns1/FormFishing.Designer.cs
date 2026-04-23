namespace ns1
{
	// Token: 0x0200005B RID: 91
	public partial class FormFishing : global::ns1.GForm0
	{
		// Token: 0x060002F9 RID: 761 RVA: 0x00004818 File Offset: 0x00002A18
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00028650 File Offset: 0x00026850
		private void InitializeComponent()
		{
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.comboBox2 = new global::System.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.toggleButton_OverWeight = new global::ns0.GClass3();
			this.commandButton1 = new global::System.CommandButton();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label14 = new global::System.Windows.Forms.Label();
			this.SpeedCast = new global::System.Slider();
			this.panel13 = new global::System.Windows.Forms.Panel();
			this.label7 = new global::System.Windows.Forms.Label();
			this.SpeedClick = new global::System.Slider();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.label6 = new global::System.Windows.Forms.Label();
			this.toggleButton_Ocean = new global::ns0.GClass3();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label12 = new global::System.Windows.Forms.Label();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.label10 = new global::System.Windows.Forms.Label();
			this.toggleButton_AnotherBait = new global::ns0.GClass3();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.toggleButton_HandleNeeds = new global::ns0.GClass3();
			this.panel12 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.toggleButton_Trunk = new global::ns0.GClass3();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.toggleButton_Shore = new global::ns0.GClass3();
			this.toggleButton_ReuseBait = new global::ns0.GClass3();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.panel5.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel11.SuspendLayout();
			base.SuspendLayout();
			this.panel5.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel5.Controls.Add(this.comboBox2);
			this.panel5.Controls.Add(this.label1);
			this.panel5.Controls.Add(this.toggleButton_OverWeight);
			this.panel5.Location = new global::System.Drawing.Point(30, 233);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(661, 40);
			this.panel5.TabIndex = 25;
			this.comboBox2.BackColor = global::System.Drawing.Color.Transparent;
			this.comboBox2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.comboBox2.FillColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.comboBox2.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.comboBox2.ForeColor = global::System.Drawing.Color.White;
			this.comboBox2.ItemsDesign.AddRange(new string[] { "отпускать рыбу", "остановиться", "закрыть игру", "выключить компьютер" });
			this.comboBox2.Location = new global::System.Drawing.Point(325, 5);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.SelectedIndex = 0;
			this.comboBox2.Size = new global::System.Drawing.Size(246, 30);
			this.comboBox2.TabIndex = 1000;
			this.comboBox2.TabStop = false;
			this.comboBox2.Text = "comboBox2";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(20, 10);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(299, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "При избыточном весе в инвентаре";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_OverWeight.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_OverWeight.AutoSize = true;
			this.toggleButton_OverWeight.Checked = true;
			this.toggleButton_OverWeight.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.toggleButton_OverWeight.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_OverWeight.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_OverWeight.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_OverWeight.Name = "toggleButton_OverWeight";
			this.toggleButton_OverWeight.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_OverWeight.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_OverWeight.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_OverWeight.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_OverWeight.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_OverWeight.TabIndex = 0;
			this.toggleButton_OverWeight.TabStop = false;
			this.toggleButton_OverWeight.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_OverWeight.UseVisualStyleBackColor = true;
			this.toggleButton_OverWeight.CheckedChanged += new global::System.EventHandler(this.toggleButton_OverWeight_CheckedChanged);
			this.commandButton1.BackColor = global::System.Drawing.Color.Transparent;
			this.commandButton1.BackColorHover = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.commandButton1.BackColorNormal = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.commandButton1.BackColorPressed = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.commandButton1.BorderColorHover = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton1.BorderColorNormal = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton1.BorderColorPressed = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.commandButton1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.commandButton1.ForeColor = global::System.Drawing.Color.White;
			this.commandButton1.Location = new global::System.Drawing.Point(468, 5);
			this.commandButton1.Name = "commandButton1";
			this.commandButton1.Size = new global::System.Drawing.Size(170, 30);
			this.commandButton1.TabIndex = 2;
			this.commandButton1.TabStop = false;
			this.commandButton1.Text = "ВЫБРАТЬ";
			this.commandButton1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.commandButton1.Click += new global::System.EventHandler(this.commandButton1_Click);
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label3.ForeColor = global::System.Drawing.Color.White;
			this.label3.Location = new global::System.Drawing.Point(20, 10);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(439, 18);
			this.label3.TabIndex = 1;
			this.label3.Text = "Выберите рыбу которую нужно Забрать / Отпустить";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel1.Controls.Add(this.commandButton1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new global::System.Drawing.Point(30, 75);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(661, 40);
			this.panel1.TabIndex = 30;
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label14.ForeColor = global::System.Drawing.Color.White;
			this.label14.Location = new global::System.Drawing.Point(20, 10);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(344, 18);
			this.label14.TabIndex = 1;
			this.label14.Text = "Скорость заброса удочки после вылова";
			this.label14.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.SpeedCast.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.SpeedCast.ForeColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedCast.Location = new global::System.Drawing.Point(358, 6);
			this.SpeedCast.Name = "SpeedCast";
			this.SpeedCast.Size = new global::System.Drawing.Size(290, 28);
			this.SpeedCast.TabIndex = 2;
			this.SpeedCast.TabStop = false;
			this.SpeedCast.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedCast.ThumbRadius = 8;
			this.SpeedCast.Value = 80;
			this.SpeedCast.ValueBoxWidth = 49;
			this.SpeedCast.ValueColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedCast.ValueFont = new global::System.Drawing.Font("Verdana", 12f);
			this.panel13.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel13.Controls.Add(this.label14);
			this.panel13.Controls.Add(this.SpeedCast);
			this.panel13.Location = new global::System.Drawing.Point(30, 177);
			this.panel13.Name = "panel13";
			this.panel13.Size = new global::System.Drawing.Size(661, 40);
			this.panel13.TabIndex = 29;
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label7.ForeColor = global::System.Drawing.Color.White;
			this.label7.Location = new global::System.Drawing.Point(20, 10);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(335, 18);
			this.label7.TabIndex = 1;
			this.label7.Text = "Скорость клика по Забрать / Отпустить";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.SpeedClick.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.SpeedClick.ForeColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedClick.Location = new global::System.Drawing.Point(358, 6);
			this.SpeedClick.Name = "SpeedClick";
			this.SpeedClick.Size = new global::System.Drawing.Size(290, 28);
			this.SpeedClick.TabIndex = 2;
			this.SpeedClick.TabStop = false;
			this.SpeedClick.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedClick.ThumbRadius = 8;
			this.SpeedClick.ValueBoxWidth = 49;
			this.SpeedClick.ValueColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedClick.ValueFont = new global::System.Drawing.Font("Verdana", 12f);
			this.panel7.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel7.Controls.Add(this.label7);
			this.panel7.Controls.Add(this.SpeedClick);
			this.panel7.Location = new global::System.Drawing.Point(30, 131);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(661, 40);
			this.panel7.TabIndex = 28;
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label6.ForeColor = global::System.Drawing.Color.White;
			this.label6.Location = new global::System.Drawing.Point(20, 10);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(149, 18);
			this.label6.TabIndex = 1;
			this.label6.Text = "Рыбалка с лодки";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_Ocean.AutoSize = true;
			this.toggleButton_Ocean.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_Ocean.Location = new global::System.Drawing.Point(258, 10);
			this.toggleButton_Ocean.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Ocean.Name = "toggleButton_Ocean";
			this.toggleButton_Ocean.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_Ocean.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Ocean.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_Ocean.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Ocean.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Ocean.TabIndex = 0;
			this.toggleButton_Ocean.TabStop = false;
			this.toggleButton_Ocean.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_Ocean.UseVisualStyleBackColor = true;
			this.toggleButton_Ocean.CheckedChanged += new global::System.EventHandler(this.toggleButton_Ocean_CheckedChanged);
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel4.Controls.Add(this.label6);
			this.panel4.Controls.Add(this.toggleButton_Ocean);
			this.panel4.Location = new global::System.Drawing.Point(365, 19);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(326, 40);
			this.panel4.TabIndex = 20;
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label12.ForeColor = global::System.Drawing.Color.White;
			this.label12.Location = new global::System.Drawing.Point(20, 10);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(424, 18);
			this.label12.TabIndex = 1;
			this.label12.Text = "После 7 поклёвок снять и надеть ту же приманку";
			this.label12.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel9.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel9.Controls.Add(this.label10);
			this.panel9.Controls.Add(this.toggleButton_AnotherBait);
			this.panel9.Location = new global::System.Drawing.Point(30, 325);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(661, 40);
			this.panel9.TabIndex = 22;
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label10.ForeColor = global::System.Drawing.Color.White;
			this.label10.Location = new global::System.Drawing.Point(20, 10);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(398, 18);
			this.label10.TabIndex = 1;
			this.label10.Text = "После 7 поклёвок менять приманку на другую";
			this.label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_AnotherBait.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_AnotherBait.AutoSize = true;
			this.toggleButton_AnotherBait.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_AnotherBait.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_AnotherBait.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_AnotherBait.Name = "toggleButton_AnotherBait";
			this.toggleButton_AnotherBait.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_AnotherBait.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_AnotherBait.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_AnotherBait.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_AnotherBait.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_AnotherBait.TabIndex = 0;
			this.toggleButton_AnotherBait.TabStop = false;
			this.toggleButton_AnotherBait.Tag = "";
			this.toggleButton_AnotherBait.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_AnotherBait.UseVisualStyleBackColor = true;
			this.toggleButton_AnotherBait.CheckedChanged += new global::System.EventHandler(this.toggleButton_AnotherBait_CheckedChanged);
			this.panel6.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel6.Controls.Add(this.label8);
			this.panel6.Controls.Add(this.toggleButton_HandleNeeds);
			this.panel6.Location = new global::System.Drawing.Point(30, 371);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(661, 40);
			this.panel6.TabIndex = 23;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label8.ForeColor = global::System.Drawing.Color.White;
			this.label8.Location = new global::System.Drawing.Point(20, 10);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(384, 18);
			this.label8.TabIndex = 1;
			this.label8.Text = "Кушать / пить / лечиться при необходимости";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_HandleNeeds.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_HandleNeeds.AutoSize = true;
			this.toggleButton_HandleNeeds.Checked = true;
			this.toggleButton_HandleNeeds.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.toggleButton_HandleNeeds.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_HandleNeeds.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_HandleNeeds.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_HandleNeeds.Name = "toggleButton_HandleNeeds";
			this.toggleButton_HandleNeeds.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_HandleNeeds.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_HandleNeeds.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_HandleNeeds.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_HandleNeeds.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_HandleNeeds.TabIndex = 0;
			this.toggleButton_HandleNeeds.TabStop = false;
			this.toggleButton_HandleNeeds.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_HandleNeeds.UseVisualStyleBackColor = true;
			this.toggleButton_HandleNeeds.CheckedChanged += new global::System.EventHandler(this.toggleButton_HandleNeeds_CheckedChanged);
			this.panel12.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel12.Controls.Add(this.label13);
			this.panel12.Controls.Add(this.toggleButton_Trunk);
			this.panel12.Location = new global::System.Drawing.Point(30, 417);
			this.panel12.Name = "panel12";
			this.panel12.Size = new global::System.Drawing.Size(661, 40);
			this.panel12.TabIndex = 24;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label13.ForeColor = global::System.Drawing.Color.White;
			this.label13.Location = new global::System.Drawing.Point(20, 10);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(551, 18);
			this.label13.TabIndex = 1;
			this.label13.Text = "Складывать рыбу в багажник транспорта (Работает с 6го ранга)";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_Trunk.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_Trunk.AutoSize = true;
			this.toggleButton_Trunk.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_Trunk.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_Trunk.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Trunk.Name = "toggleButton_Trunk";
			this.toggleButton_Trunk.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_Trunk.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Trunk.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_Trunk.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Trunk.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Trunk.TabIndex = 0;
			this.toggleButton_Trunk.TabStop = false;
			this.toggleButton_Trunk.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_Trunk.UseVisualStyleBackColor = true;
			this.toggleButton_Trunk.CheckedChanged += new global::System.EventHandler(this.toggleButton_Trunk_CheckedChanged);
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.toggleButton_Shore);
			this.panel3.Location = new global::System.Drawing.Point(30, 19);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(326, 40);
			this.panel3.TabIndex = 19;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(20, 10);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(158, 18);
			this.label5.TabIndex = 1;
			this.label5.Text = "Рыбалка с берега";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_Shore.AutoSize = true;
			this.toggleButton_Shore.Checked = true;
			this.toggleButton_Shore.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.toggleButton_Shore.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_Shore.Location = new global::System.Drawing.Point(258, 10);
			this.toggleButton_Shore.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Shore.Name = "toggleButton_Shore";
			this.toggleButton_Shore.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_Shore.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Shore.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_Shore.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Shore.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Shore.TabIndex = 0;
			this.toggleButton_Shore.TabStop = false;
			this.toggleButton_Shore.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_Shore.UseVisualStyleBackColor = true;
			this.toggleButton_Shore.CheckedChanged += new global::System.EventHandler(this.toggleButton_Shore_CheckedChanged);
			this.toggleButton_ReuseBait.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_ReuseBait.AutoSize = true;
			this.toggleButton_ReuseBait.Checked = true;
			this.toggleButton_ReuseBait.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.toggleButton_ReuseBait.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_ReuseBait.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_ReuseBait.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_ReuseBait.Name = "toggleButton_ReuseBait";
			this.toggleButton_ReuseBait.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_ReuseBait.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_ReuseBait.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_ReuseBait.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_ReuseBait.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_ReuseBait.TabIndex = 0;
			this.toggleButton_ReuseBait.TabStop = false;
			this.toggleButton_ReuseBait.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_ReuseBait.UseVisualStyleBackColor = true;
			this.toggleButton_ReuseBait.CheckedChanged += new global::System.EventHandler(this.toggleButton_ReuseBait_CheckedChanged);
			this.panel11.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel11.Controls.Add(this.label12);
			this.panel11.Controls.Add(this.toggleButton_ReuseBait);
			this.panel11.Location = new global::System.Drawing.Point(30, 279);
			this.panel11.Name = "panel11";
			this.panel11.Size = new global::System.Drawing.Size(661, 40);
			this.panel11.TabIndex = 21;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 491);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel13);
			base.Controls.Add(this.panel7);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel9);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.panel12);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel11);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormFishing";
			base.Tag = "";
			this.Text = "FormFishing";
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel13.ResumeLayout(false);
			this.panel13.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel12.ResumeLayout(false);
			this.panel12.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040003A8 RID: 936
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x040003A9 RID: 937
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x040003AA RID: 938
		public global::System.ComboBox comboBox2;

		// Token: 0x040003AB RID: 939
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040003AC RID: 940
		private global::ns0.GClass3 toggleButton_OverWeight;

		// Token: 0x040003AD RID: 941
		private global::System.CommandButton commandButton1;

		// Token: 0x040003AE RID: 942
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040003AF RID: 943
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040003B0 RID: 944
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040003B1 RID: 945
		public global::System.Slider SpeedCast;

		// Token: 0x040003B2 RID: 946
		private global::System.Windows.Forms.Panel panel13;

		// Token: 0x040003B3 RID: 947
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040003B4 RID: 948
		public global::System.Slider SpeedClick;

		// Token: 0x040003B5 RID: 949
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x040003B6 RID: 950
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040003B7 RID: 951
		private global::ns0.GClass3 toggleButton_Ocean;

		// Token: 0x040003B8 RID: 952
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040003B9 RID: 953
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040003BA RID: 954
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x040003BB RID: 955
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040003BC RID: 956
		private global::ns0.GClass3 toggleButton_AnotherBait;

		// Token: 0x040003BD RID: 957
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040003BE RID: 958
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040003BF RID: 959
		private global::ns0.GClass3 toggleButton_HandleNeeds;

		// Token: 0x040003C0 RID: 960
		private global::System.Windows.Forms.Panel panel12;

		// Token: 0x040003C1 RID: 961
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040003C2 RID: 962
		private global::ns0.GClass3 toggleButton_Trunk;

		// Token: 0x040003C3 RID: 963
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040003C4 RID: 964
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040003C5 RID: 965
		private global::ns0.GClass3 toggleButton_Shore;

		// Token: 0x040003C6 RID: 966
		private global::ns0.GClass3 toggleButton_ReuseBait;

		// Token: 0x040003C7 RID: 967
		private global::System.Windows.Forms.Panel panel11;
	}
}
