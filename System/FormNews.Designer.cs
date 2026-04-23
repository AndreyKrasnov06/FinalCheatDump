namespace System
{
	// Token: 0x02000018 RID: 24
	public partial class FormNews : global::System.Windows.Forms.Form
	{
		// Token: 0x060000DB RID: 219 RVA: 0x000032E0 File Offset: 0x000014E0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00013008 File Offset: 0x00011208
		private void InitializeComponent()
		{
			this.webBrowser1 = new global::System.Windows.Forms.WebBrowser();
			base.SuspendLayout();
			this.webBrowser1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new global::System.Drawing.Point(0, 0);
			this.webBrowser1.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScrollBarsEnabled = false;
			this.webBrowser1.Size = new global::System.Drawing.Size(721, 581);
			this.webBrowser1.TabIndex = 0;
			this.webBrowser1.TabStop = false;
			this.webBrowser1.Url = new global::System.Uri("", global::System.UriKind.Relative);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new global::System.Drawing.Size(721, 581);
			base.Controls.Add(this.webBrowser1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormNews";
			this.Text = "FormNews";
			base.ResumeLayout(false);
		}

		// Token: 0x04000178 RID: 376
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.WebBrowser webBrowser1;
	}
}
