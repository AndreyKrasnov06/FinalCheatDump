namespace ns0
{
	// Token: 0x02000061 RID: 97
	public partial class FormSewing : global::System.Windows.Forms.Form
	{
		// Token: 0x0600032E RID: 814 RVA: 0x00004AEC File Offset: 0x00002CEC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0002DAC4 File Offset: 0x0002BCC4
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel9.SuspendLayout();
			base.SuspendLayout();
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Location = new global::System.Drawing.Point(30, 92);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(661, 40);
			this.panel4.TabIndex = 22;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(20, 10);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(425, 18);
			this.label5.TabIndex = 1;
			this.label5.Text = "3. Бот сам шьет формы до заполнения инвентаря";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Location = new global::System.Drawing.Point(30, 46);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(661, 40);
			this.panel3.TabIndex = 21;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(20, 10);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(447, 18);
			this.label4.TabIndex = 1;
			this.label4.Text = "2. Нажмите хоткей [Запустить] чтобы включить бота";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel6.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel6.Controls.Add(this.label8);
			this.panel6.Location = new global::System.Drawing.Point(30, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(661, 40);
			this.panel6.TabIndex = 20;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label8.ForeColor = global::System.Drawing.Color.White;
			this.label8.Location = new global::System.Drawing.Point(20, 10);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(339, 18);
			this.label8.TabIndex = 1;
			this.label8.Text = "1. Встаньте в маркер у швейного стола";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label10.ForeColor = global::System.Drawing.Color.FromArgb(0, 192, 0);
			this.label10.Location = new global::System.Drawing.Point(20, 10);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(174, 18);
			this.label10.TabIndex = 1;
			this.label10.Text = "Швейка обновлена.";
			this.label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel9.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel9.Controls.Add(this.label10);
			this.panel9.Location = new global::System.Drawing.Point(30, 148);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(661, 40);
			this.panel9.TabIndex = 23;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 464);
			base.Controls.Add(this.panel9);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel6);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormSewing";
			base.Tag = "";
			this.Text = "FormSewing";
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400041C RID: 1052
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x0400041D RID: 1053
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400041E RID: 1054
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400041F RID: 1055
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000420 RID: 1056
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000421 RID: 1057
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000422 RID: 1058
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000423 RID: 1059
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000424 RID: 1060
		private global::System.Windows.Forms.Panel panel9;
	}
}
