namespace ns1
{
	// Token: 0x0200003D RID: 61
	public partial class FormBuilder : global::ns1.GForm0
	{
		// Token: 0x060001F0 RID: 496 RVA: 0x00003E2F File Offset: 0x0000202F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x000181F8 File Offset: 0x000163F8
		private void InitializeComponent()
		{
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.SpeedHit = new global::System.Slider();
			this.label7 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label11 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel8.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel8.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel8.Controls.Add(this.SpeedHit);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Location = new global::System.Drawing.Point(30, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(661, 40);
			this.panel8.TabIndex = 4;
			this.SpeedHit.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.SpeedHit.ForeColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedHit.Location = new global::System.Drawing.Point(256, 6);
			this.SpeedHit.Name = "SpeedHit";
			this.SpeedHit.Size = new global::System.Drawing.Size(392, 28);
			this.SpeedHit.TabIndex = 2;
			this.SpeedHit.TabStop = false;
			this.SpeedHit.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedHit.ThumbRadius = 8;
			this.SpeedHit.Value = 80;
			this.SpeedHit.ValueBoxWidth = 49;
			this.SpeedHit.ValueColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.SpeedHit.ValueFont = new global::System.Drawing.Font("Verdana", 12f);
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label7.ForeColor = global::System.Drawing.Color.White;
			this.label7.Location = new global::System.Drawing.Point(20, 10);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(232, 18);
			this.label7.TabIndex = 1;
			this.label7.Text = "Скорость ударов молотком";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Location = new global::System.Drawing.Point(30, 204);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(661, 40);
			this.panel1.TabIndex = 15;
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label11.ForeColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.label11.Location = new global::System.Drawing.Point(20, 10);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(603, 18);
			this.label11.TabIndex = 1;
			this.label11.Text = "Если пишет \"Вы отказались забивать доски\" убавьте скорость молотка";
			this.label11.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Location = new global::System.Drawing.Point(30, 148);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(661, 40);
			this.panel4.TabIndex = 21;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(20, 10);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(621, 18);
			this.label5.TabIndex = 1;
			this.label5.Text = "3. Бот сам пройдет мини-игры с поднятием лифта и забиванием гвоздей";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Location = new global::System.Drawing.Point(30, 102);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(661, 40);
			this.panel3.TabIndex = 20;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(20, 10);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(572, 18);
			this.label4.TabIndex = 1;
			this.label4.Text = "2. Подойдите к лифту или стене (с досками в руках) и зажмите [E]";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel6.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel6.Controls.Add(this.label8);
			this.panel6.Location = new global::System.Drawing.Point(30, 56);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(661, 40);
			this.panel6.TabIndex = 19;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label8.ForeColor = global::System.Drawing.Color.White;
			this.label8.Location = new global::System.Drawing.Point(20, 10);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(447, 18);
			this.label8.TabIndex = 1;
			this.label8.Text = "1. Нажмите хоткей [Запустить] чтобы включить бота";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Location = new global::System.Drawing.Point(30, 250);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(661, 40);
			this.panel2.TabIndex = 22;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.label1.Location = new global::System.Drawing.Point(20, 10);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(551, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Шлифовать доски бот не умеет, возможно в будущем реализую.";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 464);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel8);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormBuilder";
			this.Text = "FormBuilder";
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000222 RID: 546
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000223 RID: 547
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x04000224 RID: 548
		public global::System.Slider SpeedHit;

		// Token: 0x04000225 RID: 549
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000226 RID: 550
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000227 RID: 551
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000228 RID: 552
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000229 RID: 553
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400022A RID: 554
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400022B RID: 555
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400022C RID: 556
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x0400022D RID: 557
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400022E RID: 558
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400022F RID: 559
		private global::System.Windows.Forms.Label label1;
	}
}
