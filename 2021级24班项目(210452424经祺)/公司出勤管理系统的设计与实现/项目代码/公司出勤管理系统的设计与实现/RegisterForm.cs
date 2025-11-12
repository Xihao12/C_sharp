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

namespace WindowsFormsApplication2
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        //注册按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("两次密码输入的不相同，请重新输入！", "警告");
                    return;
                }
                SqlConnection myConn = new SqlConnection();
                myConn.ConnectionString = DataBaseInfocs.URL;
                //构造SqlCommand对象
                string sql = "select username from tb_user where username='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, myConn);
                //打开连接
                myConn.Open();
                object res = cmd.ExecuteScalar();
                if (res != null && textBox1.Text == res.ToString())
                {
                    MessageBox.Show("用户名已存在！", "警告");
                    return;
                }
                //新增用户sql
                string insertStr = "insert into tb_user (username, password) values ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                SqlCommand cmd2 = new SqlCommand(insertStr, myConn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("注册成功！", "成功");

                //关闭数据库连接
                myConn.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("*为必选项", "警告");
            }
        }

       
    }
}
