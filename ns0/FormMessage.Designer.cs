namespace ns0
{
	// Token: 0x0200005E RID: 94
	public partial class FormMessage : global::System.Windows.Forms.Form
	{
		// Token: 0x06000318 RID: 792 RVA: 0x000049D6 File Offset: 0x00002BD6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0002BF78 File Offset: 0x0002A178
		private void InitializeComponent()
		{
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.buttonMinimized = new global::System.Windows.Forms.Button();
			this.buttonClose = new global::System.Windows.Forms.Button();
			this.buttonOK = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.pictureBox1.Image = global::ns0.Class2.majestic_logo;
			this.pictureBox1.Location = new global::System.Drawing.Point(35, 6);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(128, 50);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel1.Controls.Add(this.buttonMinimized);
			this.panel1.Controls.Add(this.buttonClose);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(620, 60);
			this.panel1.TabIndex = 1;
			this.panel1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
			this.panel1.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
			this.panel1.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
			this.buttonMinimized.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonMinimized.BackgroundImage = global::ns0.Class2.Bitmap_0;
			this.buttonMinimized.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.buttonMinimized.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonMinimized.FlatAppearance.BorderSize = 0;
			this.buttonMinimized.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonMinimized.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonMinimized.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonMinimized.Location = new global::System.Drawing.Point(848, 0);
			this.buttonMinimized.Name = "buttonMinimized";
			this.buttonMinimized.Size = new global::System.Drawing.Size(46, 32);
			this.buttonMinimized.TabIndex = 0;
			this.buttonMinimized.TabStop = false;
			this.buttonMinimized.UseVisualStyleBackColor = false;
			this.buttonClose.BackgroundImage = global::ns0.Class2.close21;
			this.buttonClose.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.buttonClose.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonClose.FlatAppearance.BorderSize = 0;
			this.buttonClose.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonClose.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(231, 24, 42);
			this.buttonClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Location = new global::System.Drawing.Point(894, 0);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new global::System.Drawing.Size(46, 32);
			this.buttonClose.TabIndex = 0;
			this.buttonClose.TabStop = false;
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonOK.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.buttonOK.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonOK.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonOK.FlatAppearance.BorderSize = 0;
			this.buttonOK.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonOK.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(40, 40, 39);
			this.buttonOK.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new global::System.Drawing.Font("Verdana", 14.25f);
			this.buttonOK.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonOK.Location = new global::System.Drawing.Point(105, 179);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new global::System.Drawing.Size(410, 74);
			this.buttonOK.TabIndex = 11;
			this.buttonOK.TabStop = false;
			this.buttonOK.Tag = "Lumberjack";
			this.buttonOK.Text = "OK";
			this.buttonOK.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonOK.UseVisualStyleBackColor = false;
			this.buttonOK.Click += new global::System.EventHandler(this.buttonOK_Click);
			this.label1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(35, 74);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(550, 91);
			this.label1.TabIndex = 12;
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = global::System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
			this.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			base.ClientSize = new global::System.Drawing.Size(620, 280);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormMessage";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040003F5 RID: 1013
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x040003F6 RID: 1014
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040003F7 RID: 1015
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040003F8 RID: 1016
		private global::System.Windows.Forms.Button buttonMinimized;

		// Token: 0x040003F9 RID: 1017
		private global::System.Windows.Forms.Button buttonClose;

		// Token: 0x040003FA RID: 1018
		private global::System.Windows.Forms.Button buttonOK;

		// Token: 0x040003FB RID: 1019
		private global::System.Windows.Forms.Label label1;
	}
}
