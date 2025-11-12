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
            this.客户管理ToolStripMenuItem = new System.Windows.Forms.Button();
            this.库存管理ToolStripMenuItem = new System.Windows.Forms.Button();
            this.销售订单ToolStripMenuItem = new System.Windows.Forms.Button();
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
            this.menuStrip1.Size = new System.Drawing.Size(693, 25);
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
            // 客户管理ToolStripMenuItem
            // 
            this.客户管理ToolStripMenuItem.Location = new System.Drawing.Point(87, 136);
            this.客户管理ToolStripMenuItem.Name = "客户管理ToolStripMenuItem";
            this.客户管理ToolStripMenuItem.Size = new System.Drawing.Size(151, 40);
            this.客户管理ToolStripMenuItem.TabIndex = 2;
            this.客户管理ToolStripMenuItem.Text = "客户管理";
            this.客户管理ToolStripMenuItem.UseVisualStyleBackColor = true;
            this.客户管理ToolStripMenuItem.Click += new System.EventHandler(this.客户管理ToolStripMenuItem_Click);
            // 
            // 库存管理ToolStripMenuItem
            // 
            this.库存管理ToolStripMenuItem.Location = new System.Drawing.Point(280, 136);
            this.库存管理ToolStripMenuItem.Name = "库存管理ToolStripMenuItem";
            this.库存管理ToolStripMenuItem.Size = new System.Drawing.Size(151, 40);
            this.库存管理ToolStripMenuItem.TabIndex = 3;
            this.库存管理ToolStripMenuItem.Text = "入库管理";
            this.库存管理ToolStripMenuItem.UseVisualStyleBackColor = true;
            this.库存管理ToolStripMenuItem.Click += new System.EventHandler(this.入库管理ToolStripMenuItem_Click);
            // 
            // 销售订单ToolStripMenuItem
            // 
            this.销售订单ToolStripMenuItem.Location = new System.Drawing.Point(484, 136);
            this.销售订单ToolStripMenuItem.Name = "销售订单ToolStripMenuItem";
            this.销售订单ToolStripMenuItem.Size = new System.Drawing.Size(151, 40);
            this.销售订单ToolStripMenuItem.TabIndex = 4;
            this.销售订单ToolStripMenuItem.Text = "发货";
            this.销售订单ToolStripMenuItem.UseVisualStyleBackColor = true;
            this.销售订单ToolStripMenuItem.Click += new System.EventHandler(this.发货ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(271, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "物流管理系统";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 206);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.销售订单ToolStripMenuItem);
            this.Controls.Add(this.库存管理ToolStripMenuItem);
            this.Controls.Add(this.客户管理ToolStripMenuItem);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 密码修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Button 客户管理ToolStripMenuItem;
        private System.Windows.Forms.Button 库存管理ToolStripMenuItem;
        private System.Windows.Forms.Button 销售订单ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}