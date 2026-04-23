namespace ns1
{
	// Token: 0x0200005D RID: 93
	public partial class FormLumberjack : global::ns1.GForm0
	{
		// Token: 0x06000310 RID: 784 RVA: 0x00004944 File Offset: 0x00002B44
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0002ADF0 File Offset: 0x00028FF0
		private void InitializeComponent()
		{
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.label6 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.toggleButton_PressE = new global::ns0.GClass3();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.SpeedClick = new global::System.Slider();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.SpeedSpam = new global::System.Slider();
			this.label7 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.toggleButton_AutoRunning = new global::ns0.GClass3();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel5.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel5.Controls.Add(this.label6);
			this.panel5.Location = new global::System.Drawing.Point(30, 342);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(661, 40);
			this.panel5.TabIndex = 14;
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label6.ForeColor = global::System.Drawing.Color.White;
			this.label6.Location = new global::System.Drawing.Point(20, 10);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(490, 18);
			this.label6.TabIndex = 1;
			this.label6.Text = "4. Бот сам спамит [ЛКМ] и кликает по веткам в миниигре";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Location = new global::System.Drawing.Point(30, 296);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(661, 40);
			this.panel4.TabIndex = 13;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(20, 10);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(610, 18);
			this.label5.TabIndex = 1;
			this.label5.Text = "3. Бот сам нажмет [E] при наличии уведомления в левом верхнем углу";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Location = new global::System.Drawing.Point(30, 250);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(661, 40);
			this.panel3.TabIndex = 12;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(20, 10);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(228, 18);
			this.label4.TabIndex = 1;
			this.label4.Text = "2. Подбегайте к деревьям";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel6.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel6.Controls.Add(this.label8);
			this.panel6.Location = new global::System.Drawing.Point(30, 204);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(661, 40);
			this.panel6.TabIndex = 11;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label8.ForeColor = global::System.Drawing.Color.White;
			this.label8.Location = new global::System.Drawing.Point(20, 10);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(447, 18);
			this.label8.TabIndex = 1;
			this.label8.Text = "1. Нажмите хоткей [Запустить] чтобы включить бота";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel7.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel7.Controls.Add(this.label1);
			this.panel7.Controls.Add(this.toggleButton_PressE);
			this.panel7.Location = new global::System.Drawing.Point(30, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(661, 40);
			this.panel7.TabIndex = 1;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(20, 10);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(183, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Нажимать кнопку [E]";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_PressE.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_PressE.AutoSize = true;
			this.toggleButton_PressE.Checked = true;
			this.toggleButton_PressE.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.toggleButton_PressE.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_PressE.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_PressE.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_PressE.Name = "toggleButton_PressE";
			this.toggleButton_PressE.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_PressE.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_PressE.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_PressE.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_PressE.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_PressE.TabIndex = 0;
			this.toggleButton_PressE.TabStop = false;
			this.toggleButton_PressE.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_PressE.UseVisualStyleBackColor = true;
			this.toggleButton_PressE.CheckedChanged += new global::System.EventHandler(this.toggleButton_PressE_CheckedChanged);
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel1.Controls.Add(this.SpeedClick);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new global::System.Drawing.Point(30, 148);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(661, 40);
			this.panel1.TabIndex = 6;
			this.SpeedClick.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.SpeedClick.ForeColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedClick.Location = new global::System.Drawing.Point(256, 6);
			this.SpeedClick.Name = "SpeedClick";
			this.SpeedClick.Size = new global::System.Drawing.Size(392, 28);
			this.SpeedClick.TabIndex = 2;
			this.SpeedClick.TabStop = false;
			this.SpeedClick.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedClick.ThumbRadius = 8;
			this.SpeedClick.ValueBoxWidth = 49;
			this.SpeedClick.ValueColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedClick.ValueFont = new global::System.Drawing.Font("Verdana", 12f);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(20, 10);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(190, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Скорость сбора веток";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel8.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel8.Controls.Add(this.SpeedSpam);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Location = new global::System.Drawing.Point(30, 102);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(661, 40);
			this.panel8.TabIndex = 5;
			this.SpeedSpam.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.SpeedSpam.ForeColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedSpam.Location = new global::System.Drawing.Point(256, 6);
			this.SpeedSpam.Name = "SpeedSpam";
			this.SpeedSpam.Size = new global::System.Drawing.Size(392, 28);
			this.SpeedSpam.TabIndex = 2;
			this.SpeedSpam.TabStop = false;
			this.SpeedSpam.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedSpam.ThumbRadius = 8;
			this.SpeedSpam.Value = 30;
			this.SpeedSpam.ValueBoxWidth = 49;
			this.SpeedSpam.ValueColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedSpam.ValueFont = new global::System.Drawing.Font("Verdana", 12f);
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label7.ForeColor = global::System.Drawing.Color.White;
			this.label7.Location = new global::System.Drawing.Point(20, 10);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(181, 18);
			this.label7.TabIndex = 1;
			this.label7.Text = "Скорость спама ЛКМ";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.toggleButton_AutoRunning);
			this.panel2.Location = new global::System.Drawing.Point(30, 46);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(661, 40);
			this.panel2.TabIndex = 20;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label3.ForeColor = global::System.Drawing.Color.White;
			this.label3.Location = new global::System.Drawing.Point(20, 10);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(557, 18);
			this.label3.TabIndex = 1;
			this.label3.Text = "Автобег вперёд  (Включить: SHIFT+W, Выключить: SHIFT или W)";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_AutoRunning.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_AutoRunning.AutoSize = true;
			this.toggleButton_AutoRunning.Checked = true;
			this.toggleButton_AutoRunning.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.toggleButton_AutoRunning.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_AutoRunning.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_AutoRunning.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_AutoRunning.Name = "toggleButton_AutoRunning";
			this.toggleButton_AutoRunning.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_AutoRunning.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_AutoRunning.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_AutoRunning.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_AutoRunning.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_AutoRunning.TabIndex = 0;
			this.toggleButton_AutoRunning.TabStop = false;
			this.toggleButton_AutoRunning.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_AutoRunning.UseVisualStyleBackColor = true;
			this.toggleButton_AutoRunning.CheckedChanged += new global::System.EventHandler(this.toggleButton_AutoRunning_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 464);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel8);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.panel7);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Location = new global::System.Drawing.Point(20, 9);
			base.Name = "FormLumberjack";
			base.Tag = "";
			this.Text = "FormLumberjack";
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040003DD RID: 989
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x040003DE RID: 990
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x040003DF RID: 991
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040003E0 RID: 992
		private global::ns0.GClass3 toggleButton_PressE;

		// Token: 0x040003E1 RID: 993
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040003E2 RID: 994
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040003E3 RID: 995
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040003E4 RID: 996
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040003E5 RID: 997
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040003E6 RID: 998
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040003E7 RID: 999
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x040003E8 RID: 1000
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040003E9 RID: 1001
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040003EA RID: 1002
		public global::System.Slider SpeedClick;

		// Token: 0x040003EB RID: 1003
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040003EC RID: 1004
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x040003ED RID: 1005
		public global::System.Slider SpeedSpam;

		// Token: 0x040003EE RID: 1006
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040003EF RID: 1007
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040003F0 RID: 1008
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040003F1 RID: 1009
		private global::ns0.GClass3 toggleButton_AutoRunning;
	}
}
