using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 共享单车管理系统
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPWDForm adminPWDForm = new AdminPWDForm();
            adminPWDForm.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("你真的要退出吗？", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
                Application.Exit();//退出当前应用
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a="1";
            RideForm roideForm = new RideForm(a);
            
            roideForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectForm selectForm = new SelectForm();   
            selectForm.ShowDialog();
        }
    }
}
