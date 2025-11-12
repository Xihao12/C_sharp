using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        //登录按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                //构造SqlConnection对象
                SqlConnection myConn = new SqlConnection();
                myConn.ConnectionString = DataBaseInfocs.URL;
                //构造SqlCommand对象
                string sql = "select password from tb_user where username='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sql,myConn);
                //打开连接
                myConn.Open();
                //执行sql
                object res= cmd.ExecuteScalar();
                myConn.Close();
                if(res==null)
                {
                     MessageBox.Show("用户名输入错误！", "警告");
                     return ;
                }
                string password =res.ToString();
                if (textBox2.Text == password)
                {
                    //密码正确开始登录
                    Program.userName = textBox1.Text;//存用户名
                    //MessageBox.Show("登录成功！", "提示");
                    //跳转到首页
                    MainForm main = new MainForm();
                    main.Show();
                    this.Hide();//隐藏登录窗体
                }
                else
                    MessageBox.Show("密码输入错误！", "警告");


            }
            else
                MessageBox.Show("用户名和密码不能为空！","警告");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("你真的要退出吗？","提示",MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
                Application.Exit();//退出当前应用
        }

        //注册按钮点击事件
        private void button3_Click(object sender, EventArgs e)
        {
            //打开注册窗口
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
