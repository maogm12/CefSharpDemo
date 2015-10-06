namespace CefSharpDemo
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CsCallJs1Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.CsCallJs2Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.devToolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.jsCallCsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.测试ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenu,
            this.exitMenu});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // openMenu
            // 
            this.openMenu.Name = "openMenu";
            this.openMenu.Size = new System.Drawing.Size(152, 22);
            this.openMenu.Text = "打开";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(152, 22);
            this.exitMenu.Text = "退出";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CsCallJs1Menu,
            this.CsCallJs2Menu,
            this.devToolsMenu,
            this.jsCallCsMenu});
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.测试ToolStripMenuItem.Text = "测试";
            // 
            // CsCallJs1Menu
            // 
            this.CsCallJs1Menu.Name = "CsCallJs1Menu";
            this.CsCallJs1Menu.Size = new System.Drawing.Size(152, 22);
            this.CsCallJs1Menu.Text = "C# Call JS 1";
            this.CsCallJs1Menu.Click += new System.EventHandler(this.cs2js1Menu_Click);
            // 
            // CsCallJs2Menu
            // 
            this.CsCallJs2Menu.Name = "CsCallJs2Menu";
            this.CsCallJs2Menu.Size = new System.Drawing.Size(152, 22);
            this.CsCallJs2Menu.Text = "C# Call JS 2";
            this.CsCallJs2Menu.Click += new System.EventHandler(this.cs2js2Menu_Click);
            // 
            // devToolsMenu
            // 
            this.devToolsMenu.Name = "devToolsMenu";
            this.devToolsMenu.Size = new System.Drawing.Size(152, 22);
            this.devToolsMenu.Text = "DevTools";
            this.devToolsMenu.Click += new System.EventHandler(this.devToolsMenu_Click);
            // 
            // jsCallCsMenu
            // 
            this.jsCallCsMenu.Name = "jsCallCsMenu";
            this.jsCallCsMenu.Size = new System.Drawing.Size(152, 22);
            this.jsCallCsMenu.Text = "JS Call C#";
            this.jsCallCsMenu.Click += new System.EventHandler(this.jsCallCsMenu_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMeMenu});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // aboutMeMenu
            // 
            this.aboutMeMenu.Name = "aboutMeMenu";
            this.aboutMeMenu.Size = new System.Drawing.Size(112, 22);
            this.aboutMeMenu.Text = "关于我";
            this.aboutMeMenu.Click += new System.EventHandler(this.aboutMeMenu_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 25);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(784, 536);
            this.mainPanel.TabIndex = 1;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text files (*.txt)|*.txt";
            this.openFileDialog.Title = "打开文件";
            this.openFileDialog.ValidateNames = false;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMeMenu;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CsCallJs1Menu;
        private System.Windows.Forms.ToolStripMenuItem CsCallJs2Menu;
        private System.Windows.Forms.ToolStripMenuItem devToolsMenu;
        private System.Windows.Forms.ToolStripMenuItem jsCallCsMenu;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

