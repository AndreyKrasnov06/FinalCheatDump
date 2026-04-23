namespace ns1
{
	// Token: 0x02000060 RID: 96
	public partial class FormSettings : global::ns1.GForm0
	{
		// Token: 0x0600032B RID: 811 RVA: 0x00004ABF File Offset: 0x00002CBF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0002D650 File Offset: 0x0002B850
		private void InitializeComponent()
		{
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.label7 = new global::System.Windows.Forms.Label();
			this.toggleButton_SoundMute = new global::ns0.GClass3();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			base.SuspendLayout();
			this.panel6.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel6.Controls.Add(this.label8);
			this.panel6.Location = new global::System.Drawing.Point(30, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(661, 40);
			this.panel6.TabIndex = 21;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label8.ForeColor = global::System.Drawing.Color.White;
			this.label8.Location = new global::System.Drawing.Point(20, 10);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(212, 18);
			this.label8.TabIndex = 1;
			this.label8.Text = "Вкладка в разработке...";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel5.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel5.Controls.Add(this.label7);
			this.panel5.Controls.Add(this.toggleButton_SoundMute);
			this.panel5.Location = new global::System.Drawing.Point(30, 46);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(661, 40);
			this.panel5.TabIndex = 22;
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label7.ForeColor = global::System.Drawing.Color.White;
			this.label7.Location = new global::System.Drawing.Point(20, 10);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(510, 18);
			this.label7.TabIndex = 1;
			this.label7.Text = "Отключить звуковое уведомление при запуске и остановке";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toggleButton_SoundMute.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.toggleButton_SoundMute.AutoSize = true;
			this.toggleButton_SoundMute.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.toggleButton_SoundMute.Location = new global::System.Drawing.Point(593, 10);
			this.toggleButton_SoundMute.MinimumSize = new global::System.Drawing.Size(45, 22);
			this.toggleButton_SoundMute.Name = "toggleButton_SoundMute";
			this.toggleButton_SoundMute.OffBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.toggleButton_SoundMute.OffToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_SoundMute.OnBackColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.toggleButton_SoundMute.OnToggleColor = global::System.Drawing.Color.White;
			this.toggleButton_SoundMute.Size = new global::System.Drawing.Size(45, 22);
			this.toggleButton_SoundMute.TabIndex = 0;
			this.toggleButton_SoundMute.TabStop = false;
			this.toggleButton_SoundMute.ThumbColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.toggleButton_SoundMute.UseVisualStyleBackColor = true;
			this.toggleButton_SoundMute.CheckedChanged += new global::System.EventHandler(this.toggleButton_SoundMute_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 464);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel6);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormSettings";
			base.Tag = "";
			this.Text = "FormSetting";
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000416 RID: 1046
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000417 RID: 1047
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000418 RID: 1048
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000419 RID: 1049
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x0400041A RID: 1050
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400041B RID: 1051
		private global::ns0.GClass3 toggleButton_SoundMute;
	}
}
