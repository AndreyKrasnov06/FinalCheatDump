namespace ns1
{
	// Token: 0x0200005C RID: 92
	public partial class FormGym : global::ns1.GForm0
	{
		// Token: 0x06000305 RID: 773 RVA: 0x000048D4 File Offset: 0x00002AD4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0002A24C File Offset: 0x0002844C
		private void InitializeComponent()
		{
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.label9 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.toggleButton_PressE = new global::ns0.GClass3();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.toggleButton_Background = new global::ns0.GClass3();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label11 = new global::System.Windows.Forms.Label();
			this.panel8.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel8.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel8.Controls.Add(this.label9);
			this.panel8.Location = new global::System.Drawing.Point(30, 194);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(661, 40);
			this.panel8.TabIndex = 9;
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label9.ForeColor = global::System.Drawing.Color.White;
			this.label9.Location = new global::System.Drawing.Point(20, 10);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(305, 18);
			this.label9.TabIndex = 1;
			this.label9.Text = "3. Бот за вас введет капчу [WASD]";
			this.label9.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Location = new global::System.Drawing.Point(30, 148);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(661, 40);
			this.panel4.TabIndex = 11;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(20, 10);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(634, 18);
			this.label5.TabIndex = 1;
			this.label5.Text = "2. Бот за вас нажмет [E] при наличии уведомления в левом верхнем углу";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel6.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel6.Controls.Add(this.label8);
			this.panel6.Location = new global::System.Drawing.Point(30, 102);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(661, 40);
			this.panel6.TabIndex = 10;
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
			this.panel7.TabIndex = 2;
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
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.toggleButton_Background);
			this.panel1.Location = new global::System.Drawing.Point(30, 46);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(661, 40);
			this.panel1.TabIndex = 3;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(20, 10);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(455, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Работать в фоновом режиме, используйте [ALT+TAB]";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_Background.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_Background.AutoSize = true;
			this.toggleButton_Background.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_Background.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_Background.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Background.Name = "toggleButton_Background";
			this.toggleButton_Background.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_Background.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Background.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_Background.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_Background.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_Background.TabIndex = 0;
			this.toggleButton_Background.TabStop = false;
			this.toggleButton_Background.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_Background.UseVisualStyleBackColor = true;
			this.toggleButton_Background.CheckedChanged += new global::System.EventHandler(this.toggleButton_Background_CheckedChanged);
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Location = new global::System.Drawing.Point(30, 250);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(661, 40);
			this.panel2.TabIndex = 15;
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label11.ForeColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.label11.Location = new global::System.Drawing.Point(20, 10);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(612, 18);
			this.label11.TabIndex = 1;
			this.label11.Text = "Для работы в фоне нужен \"Оконный без рамки / Оконный\" режим игры";
			this.label11.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 464);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel8);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.panel7);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormGym";
			base.Tag = "";
			this.Text = "FormGym";
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040003CB RID: 971
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x040003CC RID: 972
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x040003CD RID: 973
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040003CE RID: 974
		private global::ns0.GClass3 toggleButton_PressE;

		// Token: 0x040003CF RID: 975
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040003D0 RID: 976
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040003D1 RID: 977
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040003D2 RID: 978
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040003D3 RID: 979
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x040003D4 RID: 980
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040003D5 RID: 981
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040003D6 RID: 982
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040003D7 RID: 983
		private global::ns0.GClass3 toggleButton_Background;

		// Token: 0x040003D8 RID: 984
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040003D9 RID: 985
		private global::System.Windows.Forms.Label label11;
	}
}
