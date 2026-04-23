namespace ns1
{
	// Token: 0x0200003E RID: 62
	public partial class FormVPN : global::ns1.GForm0
	{
		// Token: 0x060001F3 RID: 499 RVA: 0x00003E5C File Offset: 0x0000205C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00018BC0 File Offset: 0x00016DC0
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Location = new global::System.Drawing.Point(28, 44);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(660, 370);
			this.panel2.TabIndex = 36;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label8.ForeColor = global::System.Drawing.Color.White;
			this.label8.Location = new global::System.Drawing.Point(216, 237);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(250, 90);
			this.label8.TabIndex = 39;
			this.label8.Text = "Discord: antiabot\r\n\r\nTelegram: @antia_bot_ru\r\n\r\nVK: https://vk.com/antia_bot";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label6.ForeColor = global::System.Drawing.Color.White;
			this.label6.Location = new global::System.Drawing.Point(163, 155);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(398, 54);
			this.label6.TabIndex = 37;
			this.label6.Text = "3 одновременных подключений 350 руб./мес\r\n\r\n10 одновременных подключений 500 руб./мес";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(74, 155);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(80, 18);
			this.label5.TabIndex = 36;
			this.label5.Text = "Тарифы:";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(74, 97);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(0, 18);
			this.label4.TabIndex = 35;
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(74, 31);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(507, 90);
			this.label2.TabIndex = 33;
			this.label2.Text = "VPN конфигурация VLESS + gRPC + Reality\r\n\r\nЛокация США, Скорость ~150 Мбит/с, Безлимитный трафик\r\n\r\nРаботает на Windows, Android, IOS\r\n";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 464);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormVPN";
			this.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.Text = "FormVPN";
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000230 RID: 560
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000231 RID: 561
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000232 RID: 562
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000233 RID: 563
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000234 RID: 564
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000235 RID: 565
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000236 RID: 566
		private global::System.Windows.Forms.Label label8;
	}
}
