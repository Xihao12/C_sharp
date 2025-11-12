namespace WindowsFormsApplication2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.密码修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账号管理ToolStripMenuItem = new System.Windows.Forms.Button();
            this.车辆管理ToolStripMenuItem = new System.Windows.Forms.Button();
            this.车位管理ToolStripMenuItem = new System.Windows.Forms.Button();
            this.车位绑定ToolStripMenuItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.密码修改ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 密码修改ToolStripMenuItem
            // 
            this.密码修改ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.密码修改ToolStripMenuItem.Name = "密码修改ToolStripMenuItem";
            this.密码修改ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.密码修改ToolStripMenuItem.Text = "密码修改";
            this.密码修改ToolStripMenuItem.Click += new System.EventHandler(this.密码修改ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 账号管理ToolStripMenuItem
            // 
            this.账号管理ToolStripMenuItem.Location = new System.Drawing.Point(37, 389);
            this.账号管理ToolStripMenuItem.Name = "账号管理ToolStripMenuItem";
            this.账号管理ToolStripMenuItem.Size = new System.Drawing.Size(151, 40);
            this.账号管理ToolStripMenuItem.TabIndex = 1;
            this.账号管理ToolStripMenuItem.Text = "账号管理";
            this.账号管理ToolStripMenuItem.UseVisualStyleBackColor = true;
            this.账号管理ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click1);
            // 
            // 车辆管理ToolStripMenuItem
            // 
            this.车辆管理ToolStripMenuItem.Location = new System.Drawing.Point(227, 389);
            this.车辆管理ToolStripMenuItem.Name = "车辆管理ToolStripMenuItem";
            this.车辆管理ToolStripMenuItem.Size = new System.Drawing.Size(151, 40);
            this.车辆管理ToolStripMenuItem.TabIndex = 2;
            this.车辆管理ToolStripMenuItem.Text = "员工管理";
            this.车辆管理ToolStripMenuItem.UseVisualStyleBackColor = true;
            this.车辆管理ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click2);
            // 
            // 车位管理ToolStripMenuItem
            // 
            this.车位管理ToolStripMenuItem.Location = new System.Drawing.Point(414, 389);
            this.车位管理ToolStripMenuItem.Name = "车位管理ToolStripMenuItem";
            this.车位管理ToolStripMenuItem.Size = new System.Drawing.Size(151, 40);
            this.车位管理ToolStripMenuItem.TabIndex = 3;
            this.车位管理ToolStripMenuItem.Text = "部门管理";
            this.车位管理ToolStripMenuItem.UseVisualStyleBackColor = true;
            this.车位管理ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click3);
            // 
            // 车位绑定ToolStripMenuItem
            // 
            this.车位绑定ToolStripMenuItem.Location = new System.Drawing.Point(605, 389);
            this.车位绑定ToolStripMenuItem.Name = "车位绑定ToolStripMenuItem";
            this.车位绑定ToolStripMenuItem.Size = new System.Drawing.Size(151, 40);
            this.车位绑定ToolStripMenuItem.TabIndex = 4;
            this.车位绑定ToolStripMenuItem.Text = "员工出勤";
            this.车位绑定ToolStripMenuItem.UseVisualStyleBackColor = true;
            this.车位绑定ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(255, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "公司出勤管理系统";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.车位绑定ToolStripMenuItem);
            this.Controls.Add(this.车位管理ToolStripMenuItem);
            this.Controls.Add(this.车辆管理ToolStripMenuItem);
            this.Controls.Add(this.账号管理ToolStripMenuItem);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "欢迎使用";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 密码修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Button 账号管理ToolStripMenuItem;
        private System.Windows.Forms.Button 车辆管理ToolStripMenuItem;
        private System.Windows.Forms.Button 车位管理ToolStripMenuItem;
        private System.Windows.Forms.Button 车位绑定ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}