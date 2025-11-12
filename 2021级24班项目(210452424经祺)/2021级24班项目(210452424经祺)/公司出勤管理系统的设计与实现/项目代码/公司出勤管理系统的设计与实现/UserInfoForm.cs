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
    public partial class UserInfoForm : Form
    {
        int id;
        private UserForm user;

        public UserInfoForm(int id, UserForm user)
        {
            this.id = id;
            this.user = user;
            InitializeComponent();
        }

        private void UserInfoBind()
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = DataBaseInfocs.URL;
            //构造SqlCommand对象
            string sql = "select * from tb_user where userid = '" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            //离线模式，构造SqlDataAdapter和DataTable对象
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                int userId = row.Field<int>(0);
                string username = row.Field<string>(1);
                string password = row.Field<string>(2);

                textBox2.Text = username;
                textBox3.Text = password;
            }


        }

        //保存按钮
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = DataBaseInfocs.URL;

            string username = textBox2.Text;
            string password = textBox3.Text;

            if (username == "" || username == null)
            {
                MessageBox.Show("账号不能为空！", "警告");
                return;
            }
            if (password == "" || password == null)
            {
                MessageBox.Show("密码不能为空！", "警告");
                return;
            }

            //身份证号不能重复
            string usersql = "select count(1) from tb_user where username = '" + username + "' and userid <> '" + id + "'";
            myConn.Open();
            SqlCommand cmd = new SqlCommand(usersql, myConn);
            int res = (int)cmd.ExecuteScalar();
            if (res > 0)
            {
                MessageBox.Show("账号已存在！", "警告");
                return;
            }

            if (id != -1)
            {
                //修改 
                string updsql = "update tb_user set username = @username, password = @password where userid = @id";
                cmd = new SqlCommand(updsql, myConn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            else
            {
                //新增
                string updsql = "insert into tb_user (username, password) values ( @username, @password) ";
                cmd = new SqlCommand(updsql, myConn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();
            }

            myConn.Close();
            MessageBox.Show("保存成功！", "成功");
            if (this.user != null)
            {
                //刷新表格数据
                this.user.UserBind();
            }
            this.Close();


        }

        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            UserInfoBind();
        }
    }
}
