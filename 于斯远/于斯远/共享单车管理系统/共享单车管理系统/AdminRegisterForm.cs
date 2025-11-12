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
    public partial class AdminRegisterForm : Form
    {
        public AdminRegisterForm()
        {
            InitializeComponent();
        }

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
                myConn.ConnectionString = "server=localhost;database=bicycle;uid=sa;pwd=123456;integrated security=yes";
                //构造SqlCommand对象
                string sql = "select password from bicycle_admin where aname='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, myConn);
                string sql1 = "select count(*) from bicycle_admin";
                SqlCommand sqlCommand = new SqlCommand(sql1, myConn);
                //打开连接
                myConn.Open();
                object res = cmd.ExecuteScalar();
                if (res != null && textBox1.Text == res.ToString())
                {
                    MessageBox.Show("管理员已存在！", "警告");
                    return;
                }
                //新增用户sql
                string uno = (Convert.ToInt32(sqlCommand.ExecuteScalar().ToString()) + 1).ToString("D" + 8);//自动填充uno
                string insertStr = "insert into bicycle_admin (ano,aname, password) values ('" + uno + "', '" + textBox1.Text + "', '" + textBox2.Text + "')";
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
