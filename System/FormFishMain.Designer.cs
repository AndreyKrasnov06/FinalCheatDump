namespace System
{
	// Token: 0x02000017 RID: 23
	public partial class FormFishMain : global::System.Windows.Forms.Form
	{
		// Token: 0x060000C0 RID: 192 RVA: 0x00003212 File Offset: 0x00001412
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000119EC File Offset: 0x0000FBEC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::System.FormFishMain));
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.commandButton4 = new global::System.CommandButton();
			this.commandButton3 = new global::System.CommandButton();
			this.commandButton2 = new global::System.CommandButton();
			this.commandButton1 = new global::System.CommandButton();
			this.scrollHost1 = new global::System.ScrollHost();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(374, 11);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(89, 18);
			this.label2.TabIndex = 8;
			this.label2.Text = "Отпустить";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(267, 11);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(74, 18);
			this.label1.TabIndex = 7;
			this.label1.Text = "Забрать";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.commandButton4.AccessibleRole = global::System.Windows.Forms.AccessibleRole.PushButton;
			this.commandButton4.BackColor = global::System.Drawing.Color.Transparent;
			this.commandButton4.BackColorHover = global::System.Drawing.Color.White;
			this.commandButton4.BackColorNormal = global::System.Drawing.Color.WhiteSmoke;
			this.commandButton4.BackColorPressed = global::System.Drawing.Color.White;
			this.commandButton4.BorderColorHover = global::System.Drawing.Color.Black;
			this.commandButton4.BorderColorNormal = global::System.Drawing.Color.Black;
			this.commandButton4.BorderColorPressed = global::System.Drawing.Color.Black;
			this.commandButton4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.commandButton4.Font = new global::System.Drawing.Font("Verdana", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.commandButton4.ForeColor = global::System.Drawing.Color.Black;
			this.commandButton4.Location = new global::System.Drawing.Point(35, 607);
			this.commandButton4.Name = "commandButton4";
			this.commandButton4.Size = new global::System.Drawing.Size(422, 35);
			this.commandButton4.TabIndex = 6;
			this.commandButton4.TabStop = false;
			this.commandButton4.Text = "OK";
			this.commandButton4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.commandButton4.Click += new global::System.EventHandler(this.commandButton4_Click);
			this.commandButton3.AccessibleRole = global::System.Windows.Forms.AccessibleRole.PushButton;
			this.commandButton3.BackColor = global::System.Drawing.Color.Transparent;
			this.commandButton3.BackColorHover = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.commandButton3.BackColorNormal = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.commandButton3.BackColorPressed = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.commandButton3.BorderColorHover = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton3.BorderColorNormal = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton3.BorderColorPressed = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.commandButton3.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.commandButton3.ForeColor = global::System.Drawing.Color.White;
			this.commandButton3.Location = new global::System.Drawing.Point(35, 530);
			this.commandButton3.Name = "commandButton3";
			this.commandButton3.Size = new global::System.Drawing.Size(420, 30);
			this.commandButton3.TabIndex = 5;
			this.commandButton3.TabStop = false;
			this.commandButton3.Text = "Забрать только трофейную рыбу";
			this.commandButton3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.commandButton3.Click += new global::System.EventHandler(this.commandButton3_Click);
			this.commandButton2.AccessibleRole = global::System.Windows.Forms.AccessibleRole.PushButton;
			this.commandButton2.BackColor = global::System.Drawing.Color.Transparent;
			this.commandButton2.BackColorHover = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.commandButton2.BackColorNormal = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.commandButton2.BackColorPressed = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.commandButton2.BorderColorHover = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton2.BorderColorNormal = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton2.BorderColorPressed = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.commandButton2.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.commandButton2.ForeColor = global::System.Drawing.Color.White;
			this.commandButton2.Location = new global::System.Drawing.Point(246, 566);
			this.commandButton2.Name = "commandButton2";
			this.commandButton2.Size = new global::System.Drawing.Size(209, 30);
			this.commandButton2.TabIndex = 4;
			this.commandButton2.TabStop = false;
			this.commandButton2.Text = "Отпустить всю рыбу";
			this.commandButton2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.commandButton2.Click += new global::System.EventHandler(this.commandButton2_Click);
			this.commandButton1.AccessibleRole = global::System.Windows.Forms.AccessibleRole.PushButton;
			this.commandButton1.BackColor = global::System.Drawing.Color.Transparent;
			this.commandButton1.BackColorHover = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.commandButton1.BackColorNormal = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.commandButton1.BackColorPressed = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.commandButton1.BorderColorHover = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton1.BorderColorNormal = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton1.BorderColorPressed = global::System.Drawing.Color.FromArgb(96, 96, 96);
			this.commandButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.commandButton1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.commandButton1.ForeColor = global::System.Drawing.Color.White;
			this.commandButton1.Location = new global::System.Drawing.Point(35, 566);
			this.commandButton1.Name = "commandButton1";
			this.commandButton1.Size = new global::System.Drawing.Size(205, 30);
			this.commandButton1.TabIndex = 3;
			this.commandButton1.TabStop = false;
			this.commandButton1.Text = "Забрать всю рыбу";
			this.commandButton1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.commandButton1.Click += new global::System.EventHandler(this.commandButton1_Click);
			this.scrollHost1.Location = new global::System.Drawing.Point(10, 46);
			this.scrollHost1.Name = "scrollHost1";
			this.scrollHost1.Padding = new global::System.Windows.Forms.Padding(0, 0, 4, 0);
			this.scrollHost1.Size = new global::System.Drawing.Size(479, 456);
			this.scrollHost1.TabIndex = 0;
			this.scrollHost1.Load += new global::System.EventHandler(this.scrollHost1_Load);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(490, 657);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.commandButton4);
			base.Controls.Add(this.commandButton3);
			base.Controls.Add(this.commandButton2);
			base.Controls.Add(this.commandButton1);
			base.Controls.Add(this.scrollHost1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormFishMain";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormFishMain_FormClosing);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400015A RID: 346
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400015B RID: 347
		private global::System.ScrollHost scrollHost1;

		// Token: 0x0400015C RID: 348
		private global::System.CommandButton commandButton1;

		// Token: 0x0400015D RID: 349
		private global::System.CommandButton commandButton2;

		// Token: 0x0400015E RID: 350
		private global::System.CommandButton commandButton3;

		// Token: 0x0400015F RID: 351
		private global::System.CommandButton commandButton4;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.Label label1;
	}
}
