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


        private void ToolStripMenuItem_Click1(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Show();
        }

        private void  ToolStripMenuItem_Click2(object sender, EventArgs e)
        {
            staffForm Form = new staffForm();
            Form.Show();
        }

        private void ToolStripMenuItem_Click3(object sender, EventArgs e)
        {
            departmentForm Form = new departmentForm();
            Form.Show();
        }

        private void ToolStripMenuItem_Click4(object sender, EventArgs e)
        {
            AttendanceFrom Form = new AttendanceFrom();
            Form.Show();
        }
    }
}
