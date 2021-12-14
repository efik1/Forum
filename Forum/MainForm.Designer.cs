namespace Forum
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Exit = new System.Windows.Forms.Label();
            this.main = new System.Windows.Forms.Panel();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.BackPageBut = new System.Windows.Forms.Label();
            this.NextPageBut = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CommCount = new System.Windows.Forms.Label();
            this.CommPict = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PostText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogOutpictureBox = new System.Windows.Forms.PictureBox();
            this.TopPictureBox = new System.Windows.Forms.PictureBox();
            this.NewsPIctureBox = new System.Windows.Forms.PictureBox();
            this.Settings = new System.Windows.Forms.Label();
            this.News = new System.Windows.Forms.Label();
            this.SettingBox = new System.Windows.Forms.PictureBox();
            this.PenBox = new System.Windows.Forms.PictureBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.TopPosts = new System.Windows.Forms.Label();
            this.RuPanel = new System.Windows.Forms.Label();
            this.ForumPanel = new System.Windows.Forms.Label();
            this.MyPosts = new System.Windows.Forms.Label();
            this.AccOut = new System.Windows.Forms.Label();
            this.main.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommPict)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogOutpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewsPIctureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.AutoSize = true;
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Location = new System.Drawing.Point(859, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(25, 30);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "x";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseEnter += new System.EventHandler(this.Exit_MouseEnter);
            this.Exit.MouseLeave += new System.EventHandler(this.Exit_MouseLeave);
            // 
            // main
            // 
            this.main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(231)))), ((int)(((byte)(221)))));
            this.main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.main.Controls.Add(this.comboBox);
            this.main.Controls.Add(this.BackPageBut);
            this.main.Controls.Add(this.NextPageBut);
            this.main.Controls.Add(this.groupBox1);
            this.main.Controls.Add(this.panel1);
            this.main.Controls.Add(this.Exit);
            this.main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.main.Location = new System.Drawing.Point(0, 0);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(891, 450);
            this.main.TabIndex = 1;
            this.main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.main_MouseDown);
            this.main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.main_MouseMove);
            // 
            // comboBox
            // 
            this.comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "От старых к новым",
            "От новых к старым",
            "По количеству комментариев"});
            this.comboBox.Location = new System.Drawing.Point(184, 9);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(187, 23);
            this.comboBox.TabIndex = 12;
            this.comboBox.Text = "Сортировка";
            this.comboBox.Visible = false;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // BackPageBut
            // 
            this.BackPageBut.AutoSize = true;
            this.BackPageBut.BackColor = System.Drawing.Color.Transparent;
            this.BackPageBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackPageBut.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackPageBut.ForeColor = System.Drawing.Color.White;
            this.BackPageBut.Location = new System.Drawing.Point(477, 410);
            this.BackPageBut.Name = "BackPageBut";
            this.BackPageBut.Size = new System.Drawing.Size(29, 30);
            this.BackPageBut.TabIndex = 11;
            this.BackPageBut.Text = "<";
            this.BackPageBut.Visible = false;
            this.BackPageBut.Click += new System.EventHandler(this.BackPageBut_Click);
            this.BackPageBut.MouseEnter += new System.EventHandler(this.BackPageBut_MouseEnter);
            this.BackPageBut.MouseLeave += new System.EventHandler(this.BackPageBut_MouseLeave);
            // 
            // NextPageBut
            // 
            this.NextPageBut.AutoSize = true;
            this.NextPageBut.BackColor = System.Drawing.Color.Transparent;
            this.NextPageBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextPageBut.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NextPageBut.ForeColor = System.Drawing.Color.White;
            this.NextPageBut.Location = new System.Drawing.Point(512, 410);
            this.NextPageBut.Name = "NextPageBut";
            this.NextPageBut.Size = new System.Drawing.Size(29, 30);
            this.NextPageBut.TabIndex = 10;
            this.NextPageBut.Text = ">";
            this.NextPageBut.Visible = false;
            this.NextPageBut.Click += new System.EventHandler(this.NextPageBut_Click);
            this.NextPageBut.MouseEnter += new System.EventHandler(this.NextPageBut_MouseEnter);
            this.NextPageBut.MouseLeave += new System.EventHandler(this.NextPageBut_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(231)))), ((int)(((byte)(221)))));
            this.groupBox1.CausesValidation = false;
            this.groupBox1.Controls.Add(this.CommCount);
            this.groupBox1.Controls.Add(this.CommPict);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.PostText);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(184, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 90);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // CommCount
            // 
            this.CommCount.AutoSize = true;
            this.CommCount.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CommCount.Location = new System.Drawing.Point(105, 67);
            this.CommCount.Name = "CommCount";
            this.CommCount.Size = new System.Drawing.Size(38, 13);
            this.CommCount.TabIndex = 14;
            this.CommCount.Text = "label1";
            // 
            // CommPict
            // 
            this.CommPict.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CommPict.Image = global::Forum.Properties.Resources._1737374_comment_comments_description_note_notice_icon;
            this.CommPict.Location = new System.Drawing.Point(87, 63);
            this.CommPict.Name = "CommPict";
            this.CommPict.Size = new System.Drawing.Size(18, 20);
            this.CommPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CommPict.TabIndex = 13;
            this.CommPict.TabStop = false;
            this.CommPict.Click += new System.EventHandler(this.CommPict_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(6, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_Click);
            // 
            // PostText
            // 
            this.PostText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(231)))), ((int)(((byte)(221)))));
            this.PostText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PostText.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PostText.ForeColor = System.Drawing.Color.White;
            this.PostText.Location = new System.Drawing.Point(6, 22);
            this.PostText.MaxLength = 100;
            this.PostText.Multiline = true;
            this.PostText.Name = "PostText";
            this.PostText.ReadOnly = true;
            this.PostText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PostText.Size = new System.Drawing.Size(687, 36);
            this.PostText.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(135)))), ((int)(((byte)(122)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.LogOutpictureBox);
            this.panel1.Controls.Add(this.TopPictureBox);
            this.panel1.Controls.Add(this.NewsPIctureBox);
            this.panel1.Controls.Add(this.Settings);
            this.panel1.Controls.Add(this.News);
            this.panel1.Controls.Add(this.SettingBox);
            this.panel1.Controls.Add(this.PenBox);
            this.panel1.Controls.Add(this.LoginLabel);
            this.panel1.Controls.Add(this.TopPosts);
            this.panel1.Controls.Add(this.RuPanel);
            this.panel1.Controls.Add(this.ForumPanel);
            this.panel1.Controls.Add(this.MyPosts);
            this.panel1.Controls.Add(this.AccOut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 446);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // LogOutpictureBox
            // 
            this.LogOutpictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.LogOutpictureBox.ErrorImage = global::Forum.Properties.Resources._326699_settings_icon;
            this.LogOutpictureBox.Image = global::Forum.Properties.Resources.out_icon;
            this.LogOutpictureBox.Location = new System.Drawing.Point(10, 186);
            this.LogOutpictureBox.Name = "LogOutpictureBox";
            this.LogOutpictureBox.Size = new System.Drawing.Size(18, 18);
            this.LogOutpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogOutpictureBox.TabIndex = 17;
            this.LogOutpictureBox.TabStop = false;
            // 
            // TopPictureBox
            // 
            this.TopPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.TopPictureBox.ErrorImage = global::Forum.Properties.Resources._326699_settings_icon;
            this.TopPictureBox.Image = global::Forum.Properties.Resources.hot;
            this.TopPictureBox.Location = new System.Drawing.Point(10, 102);
            this.TopPictureBox.Name = "TopPictureBox";
            this.TopPictureBox.Size = new System.Drawing.Size(18, 18);
            this.TopPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TopPictureBox.TabIndex = 16;
            this.TopPictureBox.TabStop = false;
            // 
            // NewsPIctureBox
            // 
            this.NewsPIctureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.NewsPIctureBox.ErrorImage = global::Forum.Properties.Resources._326699_settings_icon;
            this.NewsPIctureBox.Image = global::Forum.Properties.Resources._new;
            this.NewsPIctureBox.Location = new System.Drawing.Point(10, 123);
            this.NewsPIctureBox.Name = "NewsPIctureBox";
            this.NewsPIctureBox.Size = new System.Drawing.Size(18, 18);
            this.NewsPIctureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NewsPIctureBox.TabIndex = 15;
            this.NewsPIctureBox.TabStop = false;
            // 
            // Settings
            // 
            this.Settings.AutoSize = true;
            this.Settings.BackColor = System.Drawing.Color.Transparent;
            this.Settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Settings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Settings.ForeColor = System.Drawing.Color.White;
            this.Settings.Location = new System.Drawing.Point(34, 162);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(95, 21);
            this.Settings.TabIndex = 14;
            this.Settings.Text = "Настройки";
            this.Settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            this.Settings.MouseEnter += new System.EventHandler(this.Settings_MouseEnter);
            this.Settings.MouseLeave += new System.EventHandler(this.Settings_MouseLeave);
            // 
            // News
            // 
            this.News.AutoSize = true;
            this.News.BackColor = System.Drawing.Color.Transparent;
            this.News.Cursor = System.Windows.Forms.Cursors.Hand;
            this.News.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.News.ForeColor = System.Drawing.Color.White;
            this.News.Location = new System.Drawing.Point(34, 120);
            this.News.Name = "News";
            this.News.Size = new System.Drawing.Size(57, 21);
            this.News.TabIndex = 13;
            this.News.Text = "Лента";
            this.News.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.News.Click += new System.EventHandler(this.News_Click);
            this.News.MouseEnter += new System.EventHandler(this.News_MouseEnter);
            this.News.MouseLeave += new System.EventHandler(this.News_MouseLeave);
            // 
            // SettingBox
            // 
            this.SettingBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.SettingBox.ErrorImage = global::Forum.Properties.Resources._326699_settings_icon;
            this.SettingBox.Image = ((System.Drawing.Image)(resources.GetObject("SettingBox.Image")));
            this.SettingBox.Location = new System.Drawing.Point(10, 165);
            this.SettingBox.Name = "SettingBox";
            this.SettingBox.Size = new System.Drawing.Size(18, 18);
            this.SettingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SettingBox.TabIndex = 12;
            this.SettingBox.TabStop = false;
            // 
            // PenBox
            // 
            this.PenBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PenBox.ErrorImage = global::Forum.Properties.Resources._7830730_pen_content_icon;
            this.PenBox.Image = ((System.Drawing.Image)(resources.GetObject("PenBox.Image")));
            this.PenBox.Location = new System.Drawing.Point(10, 144);
            this.PenBox.Name = "PenBox";
            this.PenBox.Size = new System.Drawing.Size(18, 18);
            this.PenBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PenBox.TabIndex = 11;
            this.PenBox.TabStop = false;
            this.PenBox.Click += new System.EventHandler(this.PenBox_Click);
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.BackColor = System.Drawing.Color.Transparent;
            this.LoginLabel.CausesValidation = false;
            this.LoginLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.LoginLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoginLabel.ForeColor = System.Drawing.Color.White;
            this.LoginLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LoginLabel.Location = new System.Drawing.Point(43, 55);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LoginLabel.Size = new System.Drawing.Size(78, 30);
            this.LoginLabel.TabIndex = 10;
            this.LoginLabel.Text = "admin";
            this.LoginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TopPosts
            // 
            this.TopPosts.AutoSize = true;
            this.TopPosts.BackColor = System.Drawing.Color.Transparent;
            this.TopPosts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TopPosts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TopPosts.ForeColor = System.Drawing.Color.White;
            this.TopPosts.Location = new System.Drawing.Point(34, 99);
            this.TopPosts.Name = "TopPosts";
            this.TopPosts.Size = new System.Drawing.Size(38, 21);
            this.TopPosts.TabIndex = 9;
            this.TopPosts.Text = "Топ";
            this.TopPosts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TopPosts.Click += new System.EventHandler(this.TopPosts_Click);
            this.TopPosts.MouseEnter += new System.EventHandler(this.TopPosts_MouseEnter);
            this.TopPosts.MouseLeave += new System.EventHandler(this.TopPosts_MouseLeave);
            // 
            // RuPanel
            // 
            this.RuPanel.AutoSize = true;
            this.RuPanel.BackColor = System.Drawing.Color.Transparent;
            this.RuPanel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RuPanel.ForeColor = System.Drawing.Color.Black;
            this.RuPanel.Location = new System.Drawing.Point(98, 7);
            this.RuPanel.Name = "RuPanel";
            this.RuPanel.Size = new System.Drawing.Size(51, 37);
            this.RuPanel.TabIndex = 4;
            this.RuPanel.Text = ".ru";
            this.RuPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ForumPanel
            // 
            this.ForumPanel.AutoSize = true;
            this.ForumPanel.BackColor = System.Drawing.Color.Transparent;
            this.ForumPanel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForumPanel.ForeColor = System.Drawing.Color.White;
            this.ForumPanel.Location = new System.Drawing.Point(10, 7);
            this.ForumPanel.Name = "ForumPanel";
            this.ForumPanel.Size = new System.Drawing.Size(100, 37);
            this.ForumPanel.TabIndex = 8;
            this.ForumPanel.Text = "Forum";
            this.ForumPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyPosts
            // 
            this.MyPosts.AutoSize = true;
            this.MyPosts.BackColor = System.Drawing.Color.Transparent;
            this.MyPosts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MyPosts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MyPosts.ForeColor = System.Drawing.Color.White;
            this.MyPosts.Location = new System.Drawing.Point(34, 141);
            this.MyPosts.Name = "MyPosts";
            this.MyPosts.Size = new System.Drawing.Size(97, 21);
            this.MyPosts.TabIndex = 7;
            this.MyPosts.Text = "Мои посты";
            this.MyPosts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MyPosts.Click += new System.EventHandler(this.MyPosts_Click);
            this.MyPosts.MouseEnter += new System.EventHandler(this.MyPosts_MouseEnter);
            this.MyPosts.MouseLeave += new System.EventHandler(this.MyPosts_MouseLeave);
            // 
            // AccOut
            // 
            this.AccOut.AutoSize = true;
            this.AccOut.BackColor = System.Drawing.Color.Transparent;
            this.AccOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AccOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AccOut.ForeColor = System.Drawing.Color.White;
            this.AccOut.Location = new System.Drawing.Point(34, 183);
            this.AccOut.Name = "AccOut";
            this.AccOut.Size = new System.Drawing.Size(60, 21);
            this.AccOut.TabIndex = 5;
            this.AccOut.Text = "Выйти";
            this.AccOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AccOut.Click += new System.EventHandler(this.AccOut_Click);
            this.AccOut.MouseEnter += new System.EventHandler(this.AccOut_MouseEnter);
            this.AccOut.MouseLeave += new System.EventHandler(this.AccOut_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 450);
            this.Controls.Add(this.main);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.main.ResumeLayout(false);
            this.main.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommPict)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogOutpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewsPIctureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label Exit;
        private Panel main;
        private Label RuPanel;
        private Label AccOut;
        private Panel panel1;
        private Label TopPosts;
        private Label ForumPanel;
        private Label MyPosts;
        private GroupBox groupBox1;
        private Label LoginLabel;
        private TextBox PostText;
        private Label NextPageBut;
        private Label BackPageBut;
        private Button button1;
        private PictureBox PenBox;
        private PictureBox CommPict;
        private Label CommCount;
        private ComboBox comboBox;
        private Label Settings;
        private Label News;
        private PictureBox SettingBox;
        private PictureBox LogOutpictureBox;
        private PictureBox TopPictureBox;
        private PictureBox NewsPIctureBox;
    }
}