namespace ns1
{
	// Token: 0x02000054 RID: 84
	internal partial class FormActivate : global::ns1.GForm0
	{
		// Token: 0x060002AA RID: 682 RVA: 0x000043DB File Offset: 0x000025DB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00024340 File Offset: 0x00022540
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.maskedTextBox1 = new global::ns0.Class69();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.linkLabel1 = new global::System.Windows.Forms.LinkLabel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.timer_0 = new global::System.Windows.Forms.Timer(this.icontainer_0);
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.linkLabel2 = new global::System.Windows.Forms.LinkLabel();
			this.label_Reset = new global::System.Windows.Forms.Label();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			base.SuspendLayout();
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel2.Controls.Add(this.maskedTextBox1);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Location = new global::System.Drawing.Point(30, 17);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(661, 40);
			this.panel2.TabIndex = 33;
			this.maskedTextBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.maskedTextBox1.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.maskedTextBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.maskedTextBox1.Culture = new global::System.Globalization.CultureInfo("");
			this.maskedTextBox1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.maskedTextBox1.ForeColor = global::System.Drawing.Color.White;
			this.maskedTextBox1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.maskedTextBox1.Location = new global::System.Drawing.Point(256, 8);
			this.maskedTextBox1.Mask = "AAAAA-AAAAA-AAAAA-AAAAA-AAAAA";
			this.maskedTextBox1.Name = "maskedTextBox1";
			this.maskedTextBox1.PromptChar = 'x';
			this.maskedTextBox1.Size = new global::System.Drawing.Size(383, 27);
			this.maskedTextBox1.TabIndex = 32;
			this.maskedTextBox1.TabStop = false;
			this.maskedTextBox1.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.maskedTextBox1.Click += new global::System.EventHandler(this.maskedTextBox1_Click);
			this.maskedTextBox1.TextChanged += new global::System.EventHandler(this.maskedTextBox1_TextChanged);
			this.maskedTextBox1.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(20, 10);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(230, 18);
			this.label4.TabIndex = 31;
			this.label4.Text = "Вставьте ключ в это поле:";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new global::System.Drawing.Point(30, 63);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(661, 40);
			this.panel1.TabIndex = 34;
			this.linkLabel1.ActiveLinkColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.linkLabel1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.linkLabel1.LinkColor = global::System.Drawing.SystemColors.MenuHighlight;
			this.linkLabel1.Location = new global::System.Drawing.Point(323, 10);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new global::System.Drawing.Size(300, 18);
			this.linkLabel1.TabIndex = 34;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "https://funpay.com/users/1819974/";
			this.linkLabel1.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(20, 10);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(300, 18);
			this.label1.TabIndex = 33;
			this.label1.Text = "Купить ключ активации можно тут:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel3.Controls.Add(this.label9);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Location = new global::System.Drawing.Point(30, 109);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(661, 40);
			this.panel3.TabIndex = 35;
			this.label9.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.label9.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.label9.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label9.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.label9.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label9.ForeColor = global::System.Drawing.Color.White;
			this.label9.Location = new global::System.Drawing.Point(215, 5);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(424, 27);
			this.label9.TabIndex = 38;
			this.label9.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label9.Click += new global::System.EventHandler(this.label2_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(20, 10);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(189, 18);
			this.label2.TabIndex = 33;
			this.label2.Text = "ID этого компьютера:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label2.Click += new global::System.EventHandler(this.label2_Click);
			this.timer_0.Interval = 2000;
			this.timer_0.Tick += new global::System.EventHandler(this.timer_0_Tick);
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel4.Controls.Add(this.linkLabel2);
			this.panel4.Location = new global::System.Drawing.Point(30, 165);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(661, 40);
			this.panel4.TabIndex = 39;
			this.linkLabel2.ActiveLinkColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.linkLabel2.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.linkLabel2.LinkColor = global::System.Drawing.SystemColors.MenuHighlight;
			this.linkLabel2.Location = new global::System.Drawing.Point(125, 10);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new global::System.Drawing.Size(414, 18);
			this.linkLabel2.TabIndex = 33;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Написать в поддержку / Создать тикет в Discord";
			this.linkLabel2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel2.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			this.label_Reset.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.label_Reset.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_Reset.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.label_Reset.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label_Reset.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label_Reset.ForeColor = global::System.Drawing.Color.White;
			this.label_Reset.Location = new global::System.Drawing.Point(367, 10);
			this.label_Reset.Name = "label_Reset";
			this.label_Reset.Size = new global::System.Drawing.Size(240, 23);
			this.label_Reset.TabIndex = 40;
			this.label_Reset.Text = ">>Нажмите эту кнопку<<";
			this.label_Reset.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label_Reset.Click += new global::System.EventHandler(this.label_Reset_Click);
			this.panel5.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel5.Controls.Add(this.label_Reset);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Location = new global::System.Drawing.Point(30, 221);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(661, 126);
			this.panel5.TabIndex = 35;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label3.ForeColor = global::System.Drawing.Color.White;
			this.label3.Location = new global::System.Drawing.Point(20, 10);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(624, 90);
			this.label3.TabIndex = 33;
			this.label3.Text = "Если в игре вас вызвали на проверку - \r\n\r\nВаша лицензия будет сброшена и при запуске бот не будет активирован\r\n\r\n(После сброса активация восстановится автоматически через 2 часа)\r\n";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 464);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormActivate";
			base.Tag = "";
			this.Text = "FormActivate";
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400033E RID: 830
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x0400033F RID: 831
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000340 RID: 832
		private global::ns0.Class69 maskedTextBox1;

		// Token: 0x04000341 RID: 833
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000342 RID: 834
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000343 RID: 835
		private global::System.Windows.Forms.LinkLabel linkLabel1;

		// Token: 0x04000344 RID: 836
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000345 RID: 837
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000346 RID: 838
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000347 RID: 839
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000348 RID: 840
		private global::System.Windows.Forms.Timer timer_0;

		// Token: 0x04000349 RID: 841
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400034A RID: 842
		private global::System.Windows.Forms.LinkLabel linkLabel2;

		// Token: 0x0400034B RID: 843
		private global::System.Windows.Forms.Label label_Reset;

		// Token: 0x0400034C RID: 844
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x0400034D RID: 845
		private global::System.Windows.Forms.Label label3;
	}
}
