namespace ns1
{
	// Token: 0x02000056 RID: 86
	public partial class FormAntiAfk : global::ns1.GForm0
	{
		// Token: 0x060002C1 RID: 705 RVA: 0x000044EF File Offset: 0x000026EF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x000253B8 File Offset: 0x000235B8
		private void InitializeComponent()
		{
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.label12 = new global::System.Windows.Forms.Label();
			this.toggleButton_Move = new global::ns0.GClass3();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.toggleButton_Phone = new global::ns0.GClass3();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.toggleButton_Pad = new global::ns0.GClass3();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.label7 = new global::System.Windows.Forms.Label();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.toggleButton_Demorgan = new global::ns0.GClass3();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.label9 = new global::System.Windows.Forms.Label();
			this.toggleButton_Casino = new global::ns0.GClass3();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			base.SuspendLayout();
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Location = new global::System.Drawing.Point(30, 240);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(661, 40);
			this.panel3.TabIndex = 25;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(20, 10);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(447, 18);
			this.label4.TabIndex = 1;
			this.label4.Text = "1. Нажмите хоткей [Запустить] чтобы включить бота";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new global::System.Drawing.Point(30, 286);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(661, 40);
			this.panel1.TabIndex = 26;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(20, 10);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(430, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "2. Бот ходит в разные стороны и дергает камерой";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel5.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Location = new global::System.Drawing.Point(30, 332);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(661, 40);
			this.panel5.TabIndex = 28;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(20, 10);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(332, 18);
			this.label5.TabIndex = 1;
			this.label5.Text = "При необходимости бот поест / попьет";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel11.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel11.Controls.Add(this.label12);
			this.panel11.Controls.Add(this.toggleButton_Move);
			this.panel11.Location = new global::System.Drawing.Point(30, 0);
			this.panel11.Name = "panel11";
			this.panel11.Size = new global::System.Drawing.Size(661, 40);
			this.panel11.TabIndex = 29;
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label12.ForeColor = global::System.Drawing.Color.White;
			this.label12.Location = new global::System.Drawing.Point(20, 10);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(437, 18);
			this.label12.TabIndex = 1;
			this.label12.Text = "Включить ходьбу в разные стороны / бег / прыжки";
			this.label12.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_Move.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_Move.AutoSize = true;
			this.toggleButton_Move.Checked = true;
			this.toggleButton_Move.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.toggleButton_Move.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_Move.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_Move.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Move.Name = "toggleButton_Move";
			this.toggleButton_Move.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_Move.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Move.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_Move.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Move.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Move.TabIndex = 0;
			this.toggleButton_Move.TabStop = false;
			this.toggleButton_Move.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_Move.UseVisualStyleBackColor = true;
			this.toggleButton_Move.CheckedChanged += new global::System.EventHandler(this.toggleButton_Move_CheckedChanged);
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.toggleButton_Phone);
			this.panel2.Location = new global::System.Drawing.Point(30, 46);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(661, 40);
			this.panel2.TabIndex = 30;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(20, 10);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(306, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Включить использование телефона";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_Phone.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_Phone.AutoSize = true;
			this.toggleButton_Phone.Checked = true;
			this.toggleButton_Phone.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.toggleButton_Phone.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_Phone.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_Phone.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Phone.Name = "toggleButton_Phone";
			this.toggleButton_Phone.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_Phone.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Phone.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_Phone.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Phone.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Phone.TabIndex = 0;
			this.toggleButton_Phone.TabStop = false;
			this.toggleButton_Phone.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_Phone.UseVisualStyleBackColor = true;
			this.toggleButton_Phone.CheckedChanged += new global::System.EventHandler(this.toggleButton_Phone_CheckedChanged);
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.toggleButton_Pad);
			this.panel4.Location = new global::System.Drawing.Point(30, 92);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(661, 40);
			this.panel4.TabIndex = 31;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label3.ForeColor = global::System.Drawing.Color.White;
			this.label3.Location = new global::System.Drawing.Point(20, 10);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(306, 18);
			this.label3.TabIndex = 1;
			this.label3.Text = "Включить использование планшета";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_Pad.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_Pad.AutoSize = true;
			this.toggleButton_Pad.Checked = true;
			this.toggleButton_Pad.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.toggleButton_Pad.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_Pad.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_Pad.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Pad.Name = "toggleButton_Pad";
			this.toggleButton_Pad.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_Pad.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Pad.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_Pad.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Pad.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Pad.TabIndex = 0;
			this.toggleButton_Pad.TabStop = false;
			this.toggleButton_Pad.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_Pad.UseVisualStyleBackColor = true;
			this.toggleButton_Pad.CheckedChanged += new global::System.EventHandler(this.toggleButton_Pad_CheckedChanged);
			this.panel7.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel7.Controls.Add(this.label7);
			this.panel7.Location = new global::System.Drawing.Point(30, 378);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(661, 40);
			this.panel7.TabIndex = 30;
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label7.ForeColor = global::System.Drawing.Color.White;
			this.label7.Location = new global::System.Drawing.Point(20, 10);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(620, 18);
			this.label7.TabIndex = 1;
			this.label7.Text = "Включите нужные функции и оставьте персонажа в гараже своего дома";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel8.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.toggleButton_Demorgan);
			this.panel8.Location = new global::System.Drawing.Point(30, 138);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(661, 40);
			this.panel8.TabIndex = 32;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label8.ForeColor = global::System.Drawing.Color.White;
			this.label8.Location = new global::System.Drawing.Point(20, 10);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(410, 18);
			this.label8.TabIndex = 1;
			this.label8.Text = "Включить остановку при попадании в деморган";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_Demorgan.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_Demorgan.AutoSize = true;
			this.toggleButton_Demorgan.Checked = true;
			this.toggleButton_Demorgan.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.toggleButton_Demorgan.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_Demorgan.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_Demorgan.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Demorgan.Name = "toggleButton_Demorgan";
			this.toggleButton_Demorgan.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_Demorgan.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Demorgan.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_Demorgan.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Demorgan.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Demorgan.TabIndex = 0;
			this.toggleButton_Demorgan.TabStop = false;
			this.toggleButton_Demorgan.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_Demorgan.UseVisualStyleBackColor = true;
			this.toggleButton_Demorgan.CheckedChanged += new global::System.EventHandler(this.toggleButton_Demorgan_CheckedChanged);
			this.panel9.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel9.Controls.Add(this.label9);
			this.panel9.Controls.Add(this.toggleButton_Casino);
			this.panel9.Location = new global::System.Drawing.Point(30, 184);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(661, 40);
			this.panel9.TabIndex = 33;
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label9.ForeColor = global::System.Drawing.Color.White;
			this.label9.Location = new global::System.Drawing.Point(20, 10);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(428, 18);
			this.label9.TabIndex = 1;
			this.label9.Text = "Персонаж находится в казино за игровым столом";
			this.label9.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_Casino.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_Casino.AutoSize = true;
			this.toggleButton_Casino.Checked = true;
			this.toggleButton_Casino.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.toggleButton_Casino.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_Casino.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_Casino.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Casino.Name = "toggleButton_Casino";
			this.toggleButton_Casino.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_Casino.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Casino.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_Casino.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Casino.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Casino.TabIndex = 0;
			this.toggleButton_Casino.TabStop = false;
			this.toggleButton_Casino.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_Casino.UseVisualStyleBackColor = true;
			this.toggleButton_Casino.CheckedChanged += new global::System.EventHandler(this.toggleButton_Casino_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 464);
			base.Controls.Add(this.panel9);
			base.Controls.Add(this.panel8);
			base.Controls.Add(this.panel7);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel11);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormAntiAfk";
			this.Text = "FormAntiAfk";
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400035B RID: 859
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x0400035C RID: 860
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400035D RID: 861
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400035E RID: 862
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400035F RID: 863
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000360 RID: 864
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000361 RID: 865
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000362 RID: 866
		private global::System.Windows.Forms.Panel panel11;

		// Token: 0x04000363 RID: 867
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000364 RID: 868
		private global::ns0.GClass3 toggleButton_Move;

		// Token: 0x04000365 RID: 869
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000366 RID: 870
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000367 RID: 871
		private global::ns0.GClass3 toggleButton_Phone;

		// Token: 0x04000368 RID: 872
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000369 RID: 873
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400036A RID: 874
		private global::ns0.GClass3 toggleButton_Pad;

		// Token: 0x0400036B RID: 875
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x0400036C RID: 876
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400036D RID: 877
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x0400036E RID: 878
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400036F RID: 879
		private global::ns0.GClass3 toggleButton_Demorgan;

		// Token: 0x04000370 RID: 880
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x04000371 RID: 881
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000372 RID: 882
		private global::ns0.GClass3 toggleButton_Casino;
	}
}
