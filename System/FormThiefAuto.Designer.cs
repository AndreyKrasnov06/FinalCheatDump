namespace System
{
	// Token: 0x02000021 RID: 33
	public partial class FormThiefAuto : global::System.Windows.Forms.Form
	{
		// Token: 0x060000F2 RID: 242 RVA: 0x000033A9 File Offset: 0x000015A9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0001350C File Offset: 0x0001170C
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.label10 = new global::System.Windows.Forms.Label();
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
			this.panel4.TabIndex = 25;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(20, 10);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(374, 18);
			this.label5.TabIndex = 1;
			this.label5.Text = "3. Бот сам взломает дверь турбодекодером";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Location = new global::System.Drawing.Point(30, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(661, 40);
			this.panel3.TabIndex = 24;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(20, 10);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(447, 18);
			this.label4.TabIndex = 1;
			this.label4.Text = "1. Нажмите хоткей [Запустить] чтобы включить бота";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel6.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel6.Controls.Add(this.label8);
			this.panel6.Location = new global::System.Drawing.Point(30, 46);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(661, 40);
			this.panel6.TabIndex = 23;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label8.ForeColor = global::System.Drawing.Color.White;
			this.label8.Location = new global::System.Drawing.Point(20, 10);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(211, 18);
			this.label8.TabIndex = 1;
			this.label8.Text = "2. Начните взлом двери";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel9.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel9.Controls.Add(this.label10);
			this.panel9.Location = new global::System.Drawing.Point(30, 148);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(661, 40);
			this.panel9.TabIndex = 26;
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label10.ForeColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.label10.Location = new global::System.Drawing.Point(20, 10);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(505, 18);
			this.label10.TabIndex = 1;
			this.label10.Text = "Взлом зажигания скорее всего разрабатываться не будет!";
			this.label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 464);
			base.Controls.Add(this.panel9);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel6);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormThiefAuto";
			this.Text = "FormThiefAuto";
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

		// Token: 0x0400018E RID: 398
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400018F RID: 399
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000190 RID: 400
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000191 RID: 401
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000192 RID: 402
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000193 RID: 403
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000194 RID: 404
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000195 RID: 405
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x04000196 RID: 406
		private global::System.Windows.Forms.Label label10;
	}
}
