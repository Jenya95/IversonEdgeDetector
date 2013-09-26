namespace Iverson_edge_detector
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.UndoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomInButton = new System.Windows.Forms.ToolStripButton();
            this.ZoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NegativeButton = new System.Windows.Forms.ToolStripButton();
            this.PositiveButton = new System.Windows.Forms.ToolStripButton();
            this.EdgeButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FunctionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PositiveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NegativeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EdgeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RussianMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnglishMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.InstructionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolstripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ScaleButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.Scale400MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Scale200MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Scale150MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Scale125MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Scale100MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Scale50MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenButton,
            this.SaveButton,
            this.UndoButton,
            this.toolStripSeparator1,
            this.ZoomInButton,
            this.ZoomOutButton,
            this.toolStripSeparator2,
            this.NegativeButton,
            this.PositiveButton,
            this.EdgeButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(571, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(23, 22);
            this.OpenButton.Text = "toolStripButton4";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(23, 22);
            this.SaveButton.Text = "toolStripButton4";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UndoButton.Image = ((System.Drawing.Image)(resources.GetObject("UndoButton.Image")));
            this.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(23, 22);
            this.UndoButton.Text = "toolStripButton4";
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomInButton.Image")));
            this.ZoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.Size = new System.Drawing.Size(23, 22);
            this.ZoomInButton.Text = "toolStripButton1";
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOutButton.Image")));
            this.ZoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.Size = new System.Drawing.Size(23, 22);
            this.ZoomOutButton.Text = "toolStripButton2";
            this.ZoomOutButton.Click += new System.EventHandler(this.ZoomOutButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // NegativeButton
            // 
            this.NegativeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NegativeButton.Image = ((System.Drawing.Image)(resources.GetObject("NegativeButton.Image")));
            this.NegativeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NegativeButton.Name = "NegativeButton";
            this.NegativeButton.Size = new System.Drawing.Size(23, 22);
            this.NegativeButton.Text = "toolStripButton2";
            this.NegativeButton.Click += new System.EventHandler(this.NegativeButton_Click);
            // 
            // PositiveButton
            // 
            this.PositiveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PositiveButton.Image = ((System.Drawing.Image)(resources.GetObject("PositiveButton.Image")));
            this.PositiveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PositiveButton.Name = "PositiveButton";
            this.PositiveButton.Size = new System.Drawing.Size(23, 22);
            this.PositiveButton.Text = "Detect positive lines";
            this.PositiveButton.Click += new System.EventHandler(this.PositiveButton_Click);
            // 
            // EdgeButton
            // 
            this.EdgeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EdgeButton.Image = ((System.Drawing.Image)(resources.GetObject("EdgeButton.Image")));
            this.EdgeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EdgeButton.Name = "EdgeButton";
            this.EdgeButton.Size = new System.Drawing.Size(23, 22);
            this.EdgeButton.Text = "toolStripButton3";
            this.EdgeButton.Click += new System.EventHandler(this.EdgeButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.FunctionsMenu,
            this.SettingsMenu,
            this.HelpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(571, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.toolStripSeparator4,
            this.SaveMenuItem,
            this.SaveAsMenuItem,
            this.toolStripSeparator5,
            this.CloseMenuItem,
            this.toolStripSeparator6,
            this.ExitMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Size = new System.Drawing.Size(112, 22);
            this.OpenMenuItem.Text = "Open";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(109, 6);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(112, 22);
            this.SaveMenuItem.Text = "Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // SaveAsMenuItem
            // 
            this.SaveAsMenuItem.Name = "SaveAsMenuItem";
            this.SaveAsMenuItem.Size = new System.Drawing.Size(112, 22);
            this.SaveAsMenuItem.Text = "Save as";
            this.SaveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(109, 6);
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new System.Drawing.Size(112, 22);
            this.CloseMenuItem.Text = "Close";
            this.CloseMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(109, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(112, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoMenuItem,
            this.UndoAllMenuItem});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 20);
            this.EditMenu.Text = "Edit";
            // 
            // UndoMenuItem
            // 
            this.UndoMenuItem.Name = "UndoMenuItem";
            this.UndoMenuItem.Size = new System.Drawing.Size(120, 22);
            this.UndoMenuItem.Text = "Undo";
            this.UndoMenuItem.Click += new System.EventHandler(this.UndoMenuItem_Click);
            // 
            // UndoAllMenuItem
            // 
            this.UndoAllMenuItem.Name = "UndoAllMenuItem";
            this.UndoAllMenuItem.Size = new System.Drawing.Size(120, 22);
            this.UndoAllMenuItem.Text = "Undo All";
            this.UndoAllMenuItem.Click += new System.EventHandler(this.UndoAllMenuItem_Click);
            // 
            // FunctionsMenu
            // 
            this.FunctionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PositiveMenuItem,
            this.NegativeMenuItem,
            this.EdgeMenuItem});
            this.FunctionsMenu.Name = "FunctionsMenu";
            this.FunctionsMenu.Size = new System.Drawing.Size(82, 20);
            this.FunctionsMenu.Text = "Instruments";
            // 
            // PositiveMenuItem
            // 
            this.PositiveMenuItem.Name = "PositiveMenuItem";
            this.PositiveMenuItem.Size = new System.Drawing.Size(183, 22);
            this.PositiveMenuItem.Text = "Detect positive lines";
            this.PositiveMenuItem.Click += new System.EventHandler(this.PositiveMenuItem_Click);
            // 
            // NegativeMenuItem
            // 
            this.NegativeMenuItem.Name = "NegativeMenuItem";
            this.NegativeMenuItem.Size = new System.Drawing.Size(183, 22);
            this.NegativeMenuItem.Text = "Detect negative lines";
            this.NegativeMenuItem.Click += new System.EventHandler(this.NegativeMenuItem_Click);
            // 
            // EdgeMenuItem
            // 
            this.EdgeMenuItem.Name = "EdgeMenuItem";
            this.EdgeMenuItem.Size = new System.Drawing.Size(183, 22);
            this.EdgeMenuItem.Text = "Detect edges";
            this.EdgeMenuItem.Click += new System.EventHandler(this.EdgeMenuItem_Click);
            // 
            // SettingsMenu
            // 
            this.SettingsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageMenuItem,
            this.ThreshMenuItem});
            this.SettingsMenu.Name = "SettingsMenu";
            this.SettingsMenu.Size = new System.Drawing.Size(61, 20);
            this.SettingsMenu.Text = "Settings";
            // 
            // LanguageMenuItem
            // 
            this.LanguageMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RussianMenuItem,
            this.EnglishMenuItem});
            this.LanguageMenuItem.Name = "LanguageMenuItem";
            this.LanguageMenuItem.Size = new System.Drawing.Size(143, 22);
            this.LanguageMenuItem.Text = "Language";
            // 
            // RussianMenuItem
            // 
            this.RussianMenuItem.Checked = true;
            this.RussianMenuItem.CheckOnClick = true;
            this.RussianMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RussianMenuItem.Name = "RussianMenuItem";
            this.RussianMenuItem.Size = new System.Drawing.Size(119, 22);
            this.RussianMenuItem.Text = "Русский";
            this.RussianMenuItem.Click += new System.EventHandler(this.RussianMenuItem_Click);
            // 
            // EnglishMenuItem
            // 
            this.EnglishMenuItem.CheckOnClick = true;
            this.EnglishMenuItem.Name = "EnglishMenuItem";
            this.EnglishMenuItem.Size = new System.Drawing.Size(119, 22);
            this.EnglishMenuItem.Text = "English";
            this.EnglishMenuItem.Click += new System.EventHandler(this.EnglishMenuItem_Click);
            // 
            // ThreshMenuItem
            // 
            this.ThreshMenuItem.Name = "ThreshMenuItem";
            this.ThreshMenuItem.Size = new System.Drawing.Size(143, 22);
            this.ThreshMenuItem.Text = "Set threshold";
            this.ThreshMenuItem.Click += new System.EventHandler(this.ThreshMenuItem_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InstructionsMenuItem,
            this.toolStripSeparator3,
            this.AboutMenuItem});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "Help";
            // 
            // InstructionsMenuItem
            // 
            this.InstructionsMenuItem.Name = "InstructionsMenuItem";
            this.InstructionsMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.InstructionsMenuItem.Size = new System.Drawing.Size(155, 22);
            this.InstructionsMenuItem.Text = "Instructions";
            this.InstructionsMenuItem.Click += new System.EventHandler(this.InstructionsMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(163, 6);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(155, 22);
            this.AboutMenuItem.Text = "About";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(571, 242);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolstripProgressBar,
            this.ScaleButton});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 294);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(571, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 2, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(34, 19);
            this.toolStripStatusLabel1.Text = "0 x 0";
            // 
            // toolstripProgressBar
            // 
            this.toolstripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolstripProgressBar.Margin = new System.Windows.Forms.Padding(1, 3, 0, 3);
            this.toolstripProgressBar.Name = "toolstripProgressBar";
            this.toolstripProgressBar.Size = new System.Drawing.Size(100, 18);
            this.toolstripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // ScaleButton
            // 
            this.ScaleButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Scale400MenuItem,
            this.Scale200MenuItem,
            this.Scale150MenuItem,
            this.Scale125MenuItem,
            this.Scale100MenuItem,
            this.Scale50MenuItem});
            this.ScaleButton.Image = ((System.Drawing.Image)(resources.GetObject("ScaleButton.Image")));
            this.ScaleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScaleButton.Name = "ScaleButton";
            this.ScaleButton.Size = new System.Drawing.Size(63, 22);
            this.ScaleButton.Text = "Scale";
            // 
            // Scale400MenuItem
            // 
            this.Scale400MenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Scale400MenuItem.Name = "Scale400MenuItem";
            this.Scale400MenuItem.Size = new System.Drawing.Size(102, 22);
            this.Scale400MenuItem.Text = "400%";
            this.Scale400MenuItem.Click += new System.EventHandler(this.Scale400MenuItem_Click);
            // 
            // Scale200MenuItem
            // 
            this.Scale200MenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Scale200MenuItem.Name = "Scale200MenuItem";
            this.Scale200MenuItem.Size = new System.Drawing.Size(102, 22);
            this.Scale200MenuItem.Text = "200%";
            this.Scale200MenuItem.Click += new System.EventHandler(this.Scale200MenuItem_Click);
            // 
            // Scale150MenuItem
            // 
            this.Scale150MenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Scale150MenuItem.Name = "Scale150MenuItem";
            this.Scale150MenuItem.Size = new System.Drawing.Size(102, 22);
            this.Scale150MenuItem.Text = "150%";
            this.Scale150MenuItem.Click += new System.EventHandler(this.Scale150MenuItem_Click);
            // 
            // Scale125MenuItem
            // 
            this.Scale125MenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Scale125MenuItem.Name = "Scale125MenuItem";
            this.Scale125MenuItem.Size = new System.Drawing.Size(102, 22);
            this.Scale125MenuItem.Text = "125%";
            this.Scale125MenuItem.Click += new System.EventHandler(this.Scale125MenuItem_Click);
            // 
            // Scale100MenuItem
            // 
            this.Scale100MenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Scale100MenuItem.Name = "Scale100MenuItem";
            this.Scale100MenuItem.Size = new System.Drawing.Size(102, 22);
            this.Scale100MenuItem.Text = "100%";
            this.Scale100MenuItem.Click += new System.EventHandler(this.Scale100MenuItem_Click);
            // 
            // Scale50MenuItem
            // 
            this.Scale50MenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Scale50MenuItem.Name = "Scale50MenuItem";
            this.Scale50MenuItem.Size = new System.Drawing.Size(102, 22);
            this.Scale50MenuItem.Text = "50%";
            this.Scale50MenuItem.Click += new System.EventHandler(this.Scale50MenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 245);
            this.panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(571, 318);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(587, 356);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iverson edge detector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripButton PositiveButton;
        private System.Windows.Forms.ToolStripMenuItem EditMenu;
        private System.Windows.Forms.ToolStripMenuItem UndoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UndoAllMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton NegativeButton;
        private System.Windows.Forms.ToolStripButton EdgeButton;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton UndoButton;
        private System.Windows.Forms.ToolStripMenuItem FunctionsMenu;
        private System.Windows.Forms.ToolStripMenuItem PositiveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NegativeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EdgeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenu;
        private System.Windows.Forms.ToolStripMenuItem LanguageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RussianMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnglishMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThreshMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolstripProgressBar;
        private System.Windows.Forms.ToolStripButton ZoomInButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton ZoomOutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton ScaleButton;
        private System.Windows.Forms.ToolStripMenuItem Scale100MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Scale400MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Scale200MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Scale150MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Scale125MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Scale50MenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem InstructionsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
    }
}

