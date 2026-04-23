namespace ns0
{
	// Token: 0x02000058 RID: 88
	public partial class FormMushroomer : global::System.Windows.Forms.Form
	{
		// Token: 0x060002CA RID: 714 RVA: 0x0000455B File Offset: 0x0000275B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x000268EC File Offset: 0x00024AEC
		private void InitializeComponent()
		{
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.toggleButton_AutoRunning = new global::ns0.GClass3();
			this.panel3.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Location = new global::System.Drawing.Point(30, 102);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(661, 40);
			this.panel3.TabIndex = 18;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(20, 10);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(207, 18);
			this.label4.TabIndex = 1;
			this.label4.Text = "2. Подбегайте к грибам";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel6.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel6.Controls.Add(this.label8);
			this.panel6.Location = new global::System.Drawing.Point(30, 56);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(661, 40);
			this.panel6.TabIndex = 17;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label8.ForeColor = global::System.Drawing.Color.White;
			this.label8.Location = new global::System.Drawing.Point(20, 10);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(447, 18);
			this.label8.TabIndex = 1;
			this.label8.Text = "1. Нажмите хоткей [Запустить] чтобы включить бота";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Location = new global::System.Drawing.Point(30, 148);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(661, 40);
			this.panel4.TabIndex = 19;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(20, 10);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(610, 18);
			this.label5.TabIndex = 1;
			this.label5.Text = "3. Бот сам нажмет [E] при наличии уведомления в левом верхнем углу";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.toggleButton_AutoRunning);
			this.panel2.Location = new global::System.Drawing.Point(30, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(661, 40);
			this.panel2.TabIndex = 21;
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
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel6);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormMushroomer";
			base.Tag = "";
			this.Text = "FormMushroomer";
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000374 RID: 884
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000375 RID: 885
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000376 RID: 886
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000377 RID: 887
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000378 RID: 888
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000379 RID: 889
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400037A RID: 890
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400037B RID: 891
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400037C RID: 892
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400037D RID: 893
		private global::ns0.GClass3 toggleButton_AutoRunning;
	}
}
