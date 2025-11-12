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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 共享单车管理系统
{
    public partial class UserLoginForm : Form
    {
        public UserLoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtuname.Text != "" && txtupassword.Text != "")
            {
                //构造SqlConnection对象
                SqlConnection myConn = new SqlConnection();
                myConn.ConnectionString = "server=localhost;database=bicycle;uid=sa;pwd=123456;integrated security=yes";
                //构造SqlCommand对象
                string sql = "select password from bicycle_users where uname='" + txtuname.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, myConn);
                //打开连接
                myConn.Open();
                //执行sql
                object res = cmd.ExecuteScalar();
                myConn.Close();
                if (res == null)
                {
                    MessageBox.Show("用户名输入错误！", "警告");
                    return;
                }
                string password = res.ToString();
                if (txtupassword.Text == password)
                {
                    //密码正确开始登录
                    Program.userName = txtuname.Text;//存用户名
                    MessageBox.Show("登录成功！", "提示");
                    //跳转到首页
                    MainForm main = new MainForm();
                    main.Show();
                    this.Hide();//隐藏登录窗体
                }
                else
                    MessageBox.Show("密码输入错误！", "警告");


            }
            else
                MessageBox.Show("用户名和密码不能为空！", "警告");
        }

        private void txtupassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtuname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
