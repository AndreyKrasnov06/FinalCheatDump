namespace ns0
{
	// Token: 0x02000062 RID: 98
	public partial class FormTaxi : global::System.Windows.Forms.Form
	{
		// Token: 0x06000331 RID: 817 RVA: 0x00004B19 File Offset: 0x00002D19
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0002E0B0 File Offset: 0x0002C2B0
		private void InitializeComponent()
		{
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel9.SuspendLayout();
			base.SuspendLayout();
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Location = new global::System.Drawing.Point(30, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(661, 40);
			this.panel3.TabIndex = 22;
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
			this.panel1.Location = new global::System.Drawing.Point(30, 46);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(661, 40);
			this.panel1.TabIndex = 23;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(20, 10);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(607, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "2. При появлении уведомления о вызове бот нажмет Y и примет заказ";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Location = new global::System.Drawing.Point(30, 92);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(661, 40);
			this.panel2.TabIndex = 24;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(20, 10);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(628, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "3. Для принятия нового заказа просто снова нажмите хоткей [Запустить]";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label10.ForeColor = global::System.Drawing.Color.LimeGreen;
			this.label10.Location = new global::System.Drawing.Point(20, 10);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(527, 18);
			this.label10.TabIndex = 1;
			this.label10.Text = "Включите уведомления на телефоне в приложении UberDrive";
			this.label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel9.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel9.Controls.Add(this.label10);
			this.panel9.Location = new global::System.Drawing.Point(30, 148);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(661, 40);
			this.panel9.TabIndex = 24;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 464);
			base.Controls.Add(this.panel9);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormTaxi";
			base.Tag = "";
			this.Text = "FormTaxi";
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000425 RID: 1061
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000426 RID: 1062
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000427 RID: 1063
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000428 RID: 1064
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000429 RID: 1065
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400042A RID: 1066
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400042B RID: 1067
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400042C RID: 1068
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400042D RID: 1069
		private global::System.Windows.Forms.Panel panel9;
	}
}
