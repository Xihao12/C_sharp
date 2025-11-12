using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 共享单车管理系统
{
    public partial class AdminPWDForm : Form
    {
        public AdminPWDForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text != "" && txtNewPwd.Text != "" && txtCrmPwd.Text != "")
            {
                //构造SqlConnection对象
                SqlConnection myConn = new SqlConnection();
                myConn.ConnectionString = "server=localhost;database=bicycle;uid=sa;pwd=123456;integrated security=yes";
                //构造SqlCommand对象
                string sql = "select password from bicycle_admin where aname='" + Program.adminName + "'";
                SqlCommand cmd = new SqlCommand(sql, myConn);
                //打开连接
                myConn.Open();
                string password = cmd.ExecuteScalar().ToString();
                myConn.Close();
                if (password == txtPwd.Text)
                {
                    //MessageBox.Show("旧密码正确！", "提示");
                    if (txtNewPwd.Text == txtCrmPwd.Text)
                    {
                        //update
                        cmd.CommandText = string.Format("update bicycle_admin set password='{0}' where aname='{1}'", txtNewPwd.Text, Program.adminName);//更新sql语句
                        myConn.Open();
                        int res = cmd.ExecuteNonQuery();//执行增删改操作
                        if (res > 0)
                        {
                            MessageBox.Show("更新成功", "提示");
                            this.Close();
                        }
                        else
                            MessageBox.Show("更新失败", "提示");

                        myConn.Close();
                    }
                    else
                        MessageBox.Show("新密码和确认密码不一致！", "提示");
                }
                else
                    MessageBox.Show("旧密码错误！", "提示");
            }
            else
                MessageBox.Show("所有项都必须填写！", "警告");
        }
    }
}
