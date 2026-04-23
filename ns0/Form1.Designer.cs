namespace ns0
{
	// Token: 0x0200004E RID: 78
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x0600027F RID: 639 RVA: 0x000041DE File Offset: 0x000023DE
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00020D8C File Offset: 0x0001EF8C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns0.Form1));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.buttonSetting = new global::System.Windows.Forms.Button();
			this.labelTime = new global::System.Windows.Forms.TextBox();
			this.buttonMinimized = new global::System.Windows.Forms.Button();
			this.buttonClose = new global::System.Windows.Forms.Button();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.panelMenu = new global::System.Windows.Forms.Panel();
			this.buttonVPN = new global::System.Windows.Forms.Button();
			this.buttonActivate = new global::System.Windows.Forms.Button();
			this.buttonMiner = new global::System.Windows.Forms.Button();
			this.buttonNews = new global::System.Windows.Forms.Button();
			this.buttonBuilder = new global::System.Windows.Forms.Button();
			this.buttonDemorgan = new global::System.Windows.Forms.Button();
			this.buttonFishing = new global::System.Windows.Forms.Button();
			this.buttonAntiAfk = new global::System.Windows.Forms.Button();
			this.buttonThiefAuto = new global::System.Windows.Forms.Button();
			this.buttonTaxi = new global::System.Windows.Forms.Button();
			this.buttonSewing = new global::System.Windows.Forms.Button();
			this.buttonGym = new global::System.Windows.Forms.Button();
			this.buttonMushroomer = new global::System.Windows.Forms.Button();
			this.buttonFarm = new global::System.Windows.Forms.Button();
			this.buttonLumberjack = new global::System.Windows.Forms.Button();
			this.panelContent = new global::System.Windows.Forms.Panel();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.label_HotKey0 = new global::System.Windows.Forms.Label();
			this.pictureBox4 = new global::System.Windows.Forms.PictureBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel10 = new global::System.Windows.Forms.Panel();
			this.label_HotKey1 = new global::System.Windows.Forms.Label();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panelMenu.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel11.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			this.panel10.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			base.SuspendLayout();
			this.panel1.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel1.Controls.Add(this.buttonSetting);
			this.panel1.Controls.Add(this.labelTime);
			this.panel1.Controls.Add(this.buttonMinimized);
			this.panel1.Controls.Add(this.buttonClose);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(909, 60);
			this.panel1.TabIndex = 0;
			this.panel1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.panel1.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.panel1.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			this.buttonSetting.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.buttonSetting.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonSetting.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonSetting.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("buttonSetting.BackgroundImage");
			this.buttonSetting.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.buttonSetting.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonSetting.FlatAppearance.BorderSize = 0;
			this.buttonSetting.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonSetting.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonSetting.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonSetting.Location = new global::System.Drawing.Point(770, 0);
			this.buttonSetting.Name = "buttonSetting";
			this.buttonSetting.Size = new global::System.Drawing.Size(46, 32);
			this.buttonSetting.TabIndex = 0;
			this.buttonSetting.TabStop = false;
			this.buttonSetting.Tag = "FormSettings";
			this.buttonSetting.Text = " ";
			this.buttonSetting.UseVisualStyleBackColor = false;
			this.buttonSetting.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonSetting.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.labelTime.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.labelTime.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.labelTime.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.labelTime.Font = new global::System.Drawing.Font("Verdana", 10.5f);
			this.labelTime.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.labelTime.Location = new global::System.Drawing.Point(488, 7);
			this.labelTime.Name = "labelTime";
			this.labelTime.ReadOnly = true;
			this.labelTime.ShortcutsEnabled = false;
			this.labelTime.Size = new global::System.Drawing.Size(267, 18);
			this.labelTime.TabIndex = 0;
			this.labelTime.TabStop = false;
			this.labelTime.Text = "29 д. 59 ч. 59 м.";
			this.labelTime.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.buttonMinimized.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.buttonMinimized.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonMinimized.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonMinimized.BackgroundImage = global::ns0.Class2.Bitmap_0;
			this.buttonMinimized.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.buttonMinimized.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonMinimized.FlatAppearance.BorderSize = 0;
			this.buttonMinimized.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonMinimized.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonMinimized.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonMinimized.Location = new global::System.Drawing.Point(817, 0);
			this.buttonMinimized.Name = "buttonMinimized";
			this.buttonMinimized.Size = new global::System.Drawing.Size(46, 32);
			this.buttonMinimized.TabIndex = 0;
			this.buttonMinimized.TabStop = false;
			this.buttonMinimized.UseVisualStyleBackColor = false;
			this.buttonMinimized.Click += new global::System.EventHandler(this.buttonMinimized_Click);
			this.buttonMinimized.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonClose.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.buttonClose.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonClose.BackgroundImage = global::ns0.Class2.close21;
			this.buttonClose.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.buttonClose.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonClose.FlatAppearance.BorderSize = 0;
			this.buttonClose.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonClose.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(231, 24, 42);
			this.buttonClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Location = new global::System.Drawing.Point(863, 0);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new global::System.Drawing.Size(46, 32);
			this.buttonClose.TabIndex = 0;
			this.buttonClose.TabStop = false;
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new global::System.EventHandler(this.buttonClose_Click);
			this.buttonClose.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.pictureBox1.Image = global::ns0.Class2.majestic_logo;
			this.pictureBox1.Location = new global::System.Drawing.Point(35, 6);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(128, 50);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			this.panelMenu.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelMenu.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.panelMenu.Controls.Add(this.buttonVPN);
			this.panelMenu.Controls.Add(this.buttonActivate);
			this.panelMenu.Controls.Add(this.buttonMiner);
			this.panelMenu.Controls.Add(this.buttonNews);
			this.panelMenu.Controls.Add(this.buttonBuilder);
			this.panelMenu.Controls.Add(this.buttonDemorgan);
			this.panelMenu.Controls.Add(this.buttonFishing);
			this.panelMenu.Controls.Add(this.buttonAntiAfk);
			this.panelMenu.Controls.Add(this.buttonThiefAuto);
			this.panelMenu.Controls.Add(this.buttonTaxi);
			this.panelMenu.Controls.Add(this.buttonSewing);
			this.panelMenu.Controls.Add(this.buttonGym);
			this.panelMenu.Controls.Add(this.buttonMushroomer);
			this.panelMenu.Controls.Add(this.buttonFarm);
			this.panelMenu.Controls.Add(this.buttonLumberjack);
			this.panelMenu.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panelMenu.Location = new global::System.Drawing.Point(0, 60);
			this.panelMenu.Margin = new global::System.Windows.Forms.Padding(0);
			this.panelMenu.Name = "panelMenu";
			this.panelMenu.Size = new global::System.Drawing.Size(188, 581);
			this.panelMenu.TabIndex = 0;
			this.buttonVPN.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.buttonVPN.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonVPN.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonVPN.FlatAppearance.BorderSize = 0;
			this.buttonVPN.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonVPN.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonVPN.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonVPN.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonVPN.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonVPN.Image = global::ns0.Class2.vpn2;
			this.buttonVPN.Location = new global::System.Drawing.Point(0, 532);
			this.buttonVPN.Margin = new global::System.Windows.Forms.Padding(0);
			this.buttonVPN.Name = "buttonVPN";
			this.buttonVPN.Size = new global::System.Drawing.Size(188, 38);
			this.buttonVPN.TabIndex = 11;
			this.buttonVPN.TabStop = false;
			this.buttonVPN.Tag = "FormVPN";
			this.buttonVPN.Text = "Наш VPN";
			this.buttonVPN.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonVPN.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonVPN.UseVisualStyleBackColor = false;
			this.buttonVPN.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonActivate.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.buttonActivate.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonActivate.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonActivate.FlatAppearance.BorderSize = 0;
			this.buttonActivate.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonActivate.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonActivate.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonActivate.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonActivate.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonActivate.Image = global::ns0.Class2.activate3;
			this.buttonActivate.Location = new global::System.Drawing.Point(0, 494);
			this.buttonActivate.Margin = new global::System.Windows.Forms.Padding(0);
			this.buttonActivate.Name = "buttonActivate";
			this.buttonActivate.Size = new global::System.Drawing.Size(188, 38);
			this.buttonActivate.TabIndex = 0;
			this.buttonActivate.TabStop = false;
			this.buttonActivate.Tag = "FormActivate";
			this.buttonActivate.Text = "Активация";
			this.buttonActivate.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonActivate.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonActivate.UseVisualStyleBackColor = false;
			this.buttonActivate.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonActivate.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonMiner.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonMiner.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonMiner.FlatAppearance.BorderSize = 0;
			this.buttonMiner.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonMiner.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonMiner.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonMiner.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonMiner.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonMiner.Image = global::ns0.Class2.free_icon_pickaxe_64787871;
			this.buttonMiner.Location = new global::System.Drawing.Point(0, 114);
			this.buttonMiner.Name = "buttonMiner";
			this.buttonMiner.Size = new global::System.Drawing.Size(188, 38);
			this.buttonMiner.TabIndex = 0;
			this.buttonMiner.TabStop = false;
			this.buttonMiner.Tag = "FormMiner";
			this.buttonMiner.Text = "Карьер";
			this.buttonMiner.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonMiner.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonMiner.UseVisualStyleBackColor = false;
			this.buttonMiner.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonMiner.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonNews.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonNews.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonNews.FlatAppearance.BorderSize = 0;
			this.buttonNews.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonNews.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonNews.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonNews.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonNews.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonNews.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("buttonNews.Image");
			this.buttonNews.Location = new global::System.Drawing.Point(0, 0);
			this.buttonNews.Margin = new global::System.Windows.Forms.Padding(0);
			this.buttonNews.Name = "buttonNews";
			this.buttonNews.Size = new global::System.Drawing.Size(188, 38);
			this.buttonNews.TabIndex = 0;
			this.buttonNews.TabStop = false;
			this.buttonNews.Tag = "FormNews";
			this.buttonNews.Text = "Новости";
			this.buttonNews.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonNews.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonNews.UseVisualStyleBackColor = false;
			this.buttonNews.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonNews.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonBuilder.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonBuilder.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonBuilder.FlatAppearance.BorderSize = 0;
			this.buttonBuilder.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonBuilder.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonBuilder.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonBuilder.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonBuilder.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonBuilder.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("buttonBuilder.Image");
			this.buttonBuilder.Location = new global::System.Drawing.Point(0, 152);
			this.buttonBuilder.Name = "buttonBuilder";
			this.buttonBuilder.Size = new global::System.Drawing.Size(188, 38);
			this.buttonBuilder.TabIndex = 0;
			this.buttonBuilder.TabStop = false;
			this.buttonBuilder.Tag = "FormBuilder";
			this.buttonBuilder.Text = "Стройка";
			this.buttonBuilder.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonBuilder.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonBuilder.UseVisualStyleBackColor = false;
			this.buttonBuilder.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonBuilder.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonDemorgan.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonDemorgan.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonDemorgan.FlatAppearance.BorderSize = 0;
			this.buttonDemorgan.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonDemorgan.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonDemorgan.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonDemorgan.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonDemorgan.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonDemorgan.Image = global::ns0.Class2.demorgan6;
			this.buttonDemorgan.Location = new global::System.Drawing.Point(0, 456);
			this.buttonDemorgan.Margin = new global::System.Windows.Forms.Padding(0);
			this.buttonDemorgan.Name = "buttonDemorgan";
			this.buttonDemorgan.Size = new global::System.Drawing.Size(188, 38);
			this.buttonDemorgan.TabIndex = 0;
			this.buttonDemorgan.TabStop = false;
			this.buttonDemorgan.Tag = "FormDemorgan";
			this.buttonDemorgan.Text = "Деморган";
			this.buttonDemorgan.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonDemorgan.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonDemorgan.UseVisualStyleBackColor = false;
			this.buttonDemorgan.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonDemorgan.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonFishing.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonFishing.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonFishing.FlatAppearance.BorderSize = 0;
			this.buttonFishing.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonFishing.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonFishing.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonFishing.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonFishing.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonFishing.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("buttonFishing.Image");
			this.buttonFishing.Location = new global::System.Drawing.Point(0, 38);
			this.buttonFishing.Name = "buttonFishing";
			this.buttonFishing.Size = new global::System.Drawing.Size(188, 38);
			this.buttonFishing.TabIndex = 0;
			this.buttonFishing.TabStop = false;
			this.buttonFishing.Tag = "FormFishing";
			this.buttonFishing.Text = "Рыбалка";
			this.buttonFishing.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonFishing.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonFishing.UseVisualStyleBackColor = false;
			this.buttonFishing.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonFishing.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonAntiAfk.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonAntiAfk.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonAntiAfk.FlatAppearance.BorderSize = 0;
			this.buttonAntiAfk.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonAntiAfk.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonAntiAfk.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonAntiAfk.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonAntiAfk.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonAntiAfk.Image = global::ns0.Class2.anti_afk3;
			this.buttonAntiAfk.Location = new global::System.Drawing.Point(0, 418);
			this.buttonAntiAfk.Name = "buttonAntiAfk";
			this.buttonAntiAfk.Size = new global::System.Drawing.Size(188, 38);
			this.buttonAntiAfk.TabIndex = 0;
			this.buttonAntiAfk.TabStop = false;
			this.buttonAntiAfk.Tag = "FormAntiAfk";
			this.buttonAntiAfk.Text = "АнтиАфк";
			this.buttonAntiAfk.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonAntiAfk.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonAntiAfk.UseVisualStyleBackColor = false;
			this.buttonAntiAfk.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonAntiAfk.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonThiefAuto.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonThiefAuto.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonThiefAuto.FlatAppearance.BorderSize = 0;
			this.buttonThiefAuto.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonThiefAuto.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonThiefAuto.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonThiefAuto.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonThiefAuto.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonThiefAuto.Image = global::ns0.Class2.thief_auto4;
			this.buttonThiefAuto.Location = new global::System.Drawing.Point(0, 380);
			this.buttonThiefAuto.Name = "buttonThiefAuto";
			this.buttonThiefAuto.Size = new global::System.Drawing.Size(188, 38);
			this.buttonThiefAuto.TabIndex = 0;
			this.buttonThiefAuto.TabStop = false;
			this.buttonThiefAuto.Tag = "FormThiefAuto";
			this.buttonThiefAuto.Text = "Угонщик";
			this.buttonThiefAuto.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonThiefAuto.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonThiefAuto.UseVisualStyleBackColor = false;
			this.buttonThiefAuto.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonThiefAuto.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonTaxi.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonTaxi.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonTaxi.FlatAppearance.BorderSize = 0;
			this.buttonTaxi.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonTaxi.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonTaxi.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonTaxi.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonTaxi.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonTaxi.Image = global::ns0.Class2.taxi2;
			this.buttonTaxi.Location = new global::System.Drawing.Point(0, 342);
			this.buttonTaxi.Name = "buttonTaxi";
			this.buttonTaxi.Size = new global::System.Drawing.Size(188, 38);
			this.buttonTaxi.TabIndex = 0;
			this.buttonTaxi.TabStop = false;
			this.buttonTaxi.Tag = "FormTaxi";
			this.buttonTaxi.Text = "Таксист";
			this.buttonTaxi.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonTaxi.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonTaxi.UseVisualStyleBackColor = false;
			this.buttonTaxi.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonTaxi.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonSewing.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonSewing.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonSewing.FlatAppearance.BorderSize = 0;
			this.buttonSewing.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonSewing.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonSewing.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonSewing.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonSewing.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonSewing.Image = global::ns0.Class2.sewing3;
			this.buttonSewing.Location = new global::System.Drawing.Point(0, 304);
			this.buttonSewing.Name = "buttonSewing";
			this.buttonSewing.Size = new global::System.Drawing.Size(188, 38);
			this.buttonSewing.TabIndex = 0;
			this.buttonSewing.TabStop = false;
			this.buttonSewing.Tag = "FormSewing";
			this.buttonSewing.Text = "Швейка";
			this.buttonSewing.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonSewing.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonSewing.UseVisualStyleBackColor = false;
			this.buttonSewing.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonSewing.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonGym.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonGym.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonGym.FlatAppearance.BorderSize = 0;
			this.buttonGym.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonGym.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonGym.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonGym.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonGym.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonGym.Image = global::ns0.Class2.gym;
			this.buttonGym.Location = new global::System.Drawing.Point(0, 266);
			this.buttonGym.Name = "buttonGym";
			this.buttonGym.Size = new global::System.Drawing.Size(188, 38);
			this.buttonGym.TabIndex = 0;
			this.buttonGym.TabStop = false;
			this.buttonGym.Tag = "FormGym";
			this.buttonGym.Text = "Качалка";
			this.buttonGym.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonGym.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonGym.UseVisualStyleBackColor = false;
			this.buttonGym.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonGym.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonMushroomer.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonMushroomer.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonMushroomer.FlatAppearance.BorderSize = 0;
			this.buttonMushroomer.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonMushroomer.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonMushroomer.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonMushroomer.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonMushroomer.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonMushroomer.Image = global::ns0.Class2.mushrooms1;
			this.buttonMushroomer.Location = new global::System.Drawing.Point(0, 228);
			this.buttonMushroomer.Name = "buttonMushroomer";
			this.buttonMushroomer.Size = new global::System.Drawing.Size(188, 38);
			this.buttonMushroomer.TabIndex = 0;
			this.buttonMushroomer.TabStop = false;
			this.buttonMushroomer.Tag = "FormMushroomer";
			this.buttonMushroomer.Text = "Грибник";
			this.buttonMushroomer.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonMushroomer.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonMushroomer.UseVisualStyleBackColor = false;
			this.buttonMushroomer.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonMushroomer.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonFarm.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonFarm.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonFarm.FlatAppearance.BorderSize = 0;
			this.buttonFarm.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonFarm.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonFarm.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonFarm.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonFarm.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonFarm.Image = global::ns0.Class2.farm4;
			this.buttonFarm.Location = new global::System.Drawing.Point(0, 190);
			this.buttonFarm.Name = "buttonFarm";
			this.buttonFarm.Size = new global::System.Drawing.Size(188, 38);
			this.buttonFarm.TabIndex = 0;
			this.buttonFarm.TabStop = false;
			this.buttonFarm.Tag = "FormFarm";
			this.buttonFarm.Text = "Фермер";
			this.buttonFarm.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonFarm.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonFarm.UseVisualStyleBackColor = false;
			this.buttonFarm.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonFarm.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.buttonLumberjack.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.buttonLumberjack.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.buttonLumberjack.FlatAppearance.BorderSize = 0;
			this.buttonLumberjack.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.buttonLumberjack.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.buttonLumberjack.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.buttonLumberjack.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.buttonLumberjack.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.buttonLumberjack.Image = global::ns0.Class2.axe;
			this.buttonLumberjack.Location = new global::System.Drawing.Point(0, 76);
			this.buttonLumberjack.Name = "buttonLumberjack";
			this.buttonLumberjack.Size = new global::System.Drawing.Size(188, 38);
			this.buttonLumberjack.TabIndex = 10;
			this.buttonLumberjack.TabStop = false;
			this.buttonLumberjack.Tag = "FormLumberjack";
			this.buttonLumberjack.Text = "Лесоруб";
			this.buttonLumberjack.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.buttonLumberjack.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonLumberjack.UseVisualStyleBackColor = false;
			this.buttonLumberjack.Click += new global::System.EventHandler(this.buttonLumberjack_Click);
			this.buttonLumberjack.Enter += new global::System.EventHandler(this.buttonLumberjack_Enter);
			this.panelContent.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelContent.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			this.panelContent.Location = new global::System.Drawing.Point(0, 117);
			this.panelContent.Margin = new global::System.Windows.Forms.Padding(0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new global::System.Drawing.Size(721, 464);
			this.panelContent.TabIndex = 0;
			this.panel6.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel6.BackColor = global::System.Drawing.Color.FromArgb(22, 22, 22);
			this.panel6.Controls.Add(this.label6);
			this.panel6.Controls.Add(this.label4);
			this.panel6.Controls.Add(this.panelContent);
			this.panel6.Controls.Add(this.panel11);
			this.panel6.Controls.Add(this.panel10);
			this.panel6.Controls.Add(this.label3);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new global::System.Drawing.Point(188, 60);
			this.panel6.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(721, 581);
			this.panel6.TabIndex = 0;
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label6.ForeColor = global::System.Drawing.Color.FromArgb(232, 28, 90);
			this.label6.Location = new global::System.Drawing.Point(30, 49);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(660, 54);
			this.label6.TabIndex = 33;
			this.label6.Text = componentResourceManager.GetString("label6.Text");
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label6.Visible = false;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Verdana", 12.5f);
			this.label4.ForeColor = global::System.Drawing.Color.Red;
			this.label4.Location = new global::System.Drawing.Point(116, 17);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(489, 20);
			this.label4.TabIndex = 32;
			this.label4.Text = "Разыгрываю 10 активаций на 9999 дней (Lifetime) !!!";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label4.Visible = false;
			this.panel11.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel11.Controls.Add(this.label_HotKey0);
			this.panel11.Controls.Add(this.pictureBox4);
			this.panel11.Controls.Add(this.label1);
			this.panel11.Controls.Add(this.label8);
			this.panel11.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.panel11.Location = new global::System.Drawing.Point(30, 15);
			this.panel11.Name = "panel11";
			this.panel11.Size = new global::System.Drawing.Size(661, 40);
			this.panel11.TabIndex = 4;
			this.label_HotKey0.BackColor = global::System.Drawing.Color.White;
			this.label_HotKey0.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.label_HotKey0.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label_HotKey0.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f);
			this.label_HotKey0.ForeColor = global::System.Drawing.Color.Black;
			this.label_HotKey0.Location = new global::System.Drawing.Point(589, 5);
			this.label_HotKey0.Name = "label_HotKey0";
			this.label_HotKey0.Size = new global::System.Drawing.Size(45, 25);
			this.label_HotKey0.TabIndex = 0;
			this.label_HotKey0.Text = "F9";
			this.label_HotKey0.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label_HotKey0.Click += new global::System.EventHandler(this.label_HotKey0_Click);
			this.pictureBox4.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.pictureBox4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox4.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new global::System.Drawing.Point(587, 5);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new global::System.Drawing.Size(49, 27);
			this.pictureBox4.TabIndex = 2;
			this.pictureBox4.TabStop = false;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.label1.Location = new global::System.Drawing.Point(428, 10);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(155, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "Укажите клавишу";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Visible = false;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label8.ForeColor = global::System.Drawing.Color.White;
			this.label8.Location = new global::System.Drawing.Point(20, 10);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(203, 18);
			this.label8.TabIndex = 0;
			this.label8.Text = "Запустить / Остановить";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel10.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.panel10.Controls.Add(this.label_HotKey1);
			this.panel10.Controls.Add(this.pictureBox3);
			this.panel10.Controls.Add(this.label2);
			this.panel10.Controls.Add(this.label5);
			this.panel10.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.panel10.Location = new global::System.Drawing.Point(30, 61);
			this.panel10.Name = "panel10";
			this.panel10.Size = new global::System.Drawing.Size(661, 40);
			this.panel10.TabIndex = 2;
			this.label_HotKey1.BackColor = global::System.Drawing.Color.White;
			this.label_HotKey1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.label_HotKey1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label_HotKey1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f);
			this.label_HotKey1.ForeColor = global::System.Drawing.Color.Black;
			this.label_HotKey1.Location = new global::System.Drawing.Point(589, 6);
			this.label_HotKey1.Name = "label_HotKey1";
			this.label_HotKey1.Size = new global::System.Drawing.Size(45, 25);
			this.label_HotKey1.TabIndex = 0;
			this.label_HotKey1.Text = "F10";
			this.label_HotKey1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label_HotKey1.Click += new global::System.EventHandler(this.label_HotKey1_Click);
			this.pictureBox3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(587, 5);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(49, 27);
			this.pictureBox3.TabIndex = 2;
			this.pictureBox3.TabStop = false;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(140, 140, 140);
			this.label2.Location = new global::System.Drawing.Point(428, 10);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(155, 18);
			this.label2.TabIndex = 4;
			this.label2.Text = "Укажите клавишу";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label2.Visible = false;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(20, 10);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(293, 18);
			this.label5.TabIndex = 0;
			this.label5.Text = "Показать окно меню и остановить";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.BackColor = global::System.Drawing.Color.FromArgb(17, 17, 17);
			this.label3.Font = new global::System.Drawing.Font("Verdana", 12f);
			this.label3.ForeColor = global::System.Drawing.Color.White;
			this.label3.Location = new global::System.Drawing.Point(30, 15);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(663, 99);
			this.label3.TabIndex = 31;
			this.label3.Text = "Продлевать активацию можно в любое время.\r\n\r\nПри этом оставшееся время суммируется с новым.";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.Visible = false;
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(188, 60);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(721, 581);
			this.panel2.TabIndex = 1;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			base.ClientSize = new global::System.Drawing.Size(909, 641);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.panelMenu);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			this.MinimumSize = new global::System.Drawing.Size(909, 641);
			base.Name = "Form1";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panelMenu.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			base.ResumeLayout(false);
			global::ns0.GClass2.smethod_0(global::ns0.Class59.byte_0);
			global::ns0.GClass2.smethod_0(global::ns0.Class64.byte_0);
		}

		// Token: 0x04000305 RID: 773
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000306 RID: 774
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000307 RID: 775
		private global::System.Windows.Forms.Panel panelMenu;

		// Token: 0x04000308 RID: 776
		private global::System.Windows.Forms.Button buttonClose;

		// Token: 0x04000309 RID: 777
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400030A RID: 778
		private global::System.Windows.Forms.Button buttonMinimized;

		// Token: 0x0400030B RID: 779
		private global::System.Windows.Forms.Button buttonFishing;

		// Token: 0x0400030C RID: 780
		private global::System.Windows.Forms.Button buttonLumberjack;

		// Token: 0x0400030D RID: 781
		private global::System.Windows.Forms.Button buttonMiner;

		// Token: 0x0400030E RID: 782
		private global::System.Windows.Forms.Button buttonFarm;

		// Token: 0x0400030F RID: 783
		private global::System.Windows.Forms.Button buttonMushroomer;

		// Token: 0x04000310 RID: 784
		private global::System.Windows.Forms.Button buttonActivate;

		// Token: 0x04000311 RID: 785
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000312 RID: 786
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x04000313 RID: 787
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000314 RID: 788
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000315 RID: 789
		private global::System.Windows.Forms.Panel panel11;

		// Token: 0x04000316 RID: 790
		private global::System.Windows.Forms.Label label_HotKey0;

		// Token: 0x04000317 RID: 791
		private global::System.Windows.Forms.PictureBox pictureBox4;

		// Token: 0x04000318 RID: 792
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000319 RID: 793
		private global::System.Windows.Forms.Label label_HotKey1;

		// Token: 0x0400031A RID: 794
		private global::System.Windows.Forms.Panel panelContent;

		// Token: 0x0400031B RID: 795
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400031C RID: 796
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400031D RID: 797
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400031E RID: 798
		private global::System.Windows.Forms.Button buttonThiefAuto;

		// Token: 0x0400031F RID: 799
		private global::System.Windows.Forms.Button buttonTaxi;

		// Token: 0x04000320 RID: 800
		private global::System.Windows.Forms.Button buttonSewing;

		// Token: 0x04000321 RID: 801
		private global::System.Windows.Forms.Button buttonGym;

		// Token: 0x04000322 RID: 802
		private global::System.Windows.Forms.Button buttonAntiAfk;

		// Token: 0x04000323 RID: 803
		private global::System.Windows.Forms.Button buttonDemorgan;

		// Token: 0x04000324 RID: 804
		private global::System.Windows.Forms.Button buttonSetting;

		// Token: 0x04000325 RID: 805
		private global::System.Windows.Forms.Button buttonBuilder;

		// Token: 0x04000326 RID: 806
		private global::System.Windows.Forms.Button buttonNews;

		// Token: 0x04000327 RID: 807
		private global::System.Windows.Forms.TextBox labelTime;

		// Token: 0x04000328 RID: 808
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000329 RID: 809
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400032A RID: 810
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400032B RID: 811
		private global::System.Windows.Forms.Button buttonVPN;
	}
}
