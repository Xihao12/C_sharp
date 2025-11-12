using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("你真的要退出吗？", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
                Application.Exit();//退出当前应用
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PWDForm password = new PWDForm();
            password.Show();
        }



        private void 客户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Custom carForm = new Custom();
            carForm.Show();
        }

        private void 入库管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            warehousing spaceForm = new warehousing();
            spaceForm.Show();
        }

        private void 发货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            outbound outb = new outbound();
            outb.Show();
        }

    }
}
