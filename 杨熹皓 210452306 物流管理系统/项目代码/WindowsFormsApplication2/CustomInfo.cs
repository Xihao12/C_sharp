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
    public partial class CustomInfo : Form
    {
        int id;
        private Custom custom;

        public CustomInfo(int id, Custom custom)
        {
            this.id = id;
            this.custom = custom;
            InitializeComponent();
        }

        private void CustomInfo_Load(object sender, EventArgs e)
        {
            CustomInfoBind();
        }

        private void CustomInfoBind()
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";
            //构造SqlCommand对象
            string sql = "select * from custom where id = '" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            //离线模式，构造SqlDataAdapter和DataTable对象
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                string name = row.Field<string>(1);
                string phone = row.Field<string>(2);
                string sno = row.Field<string>(3);
                string addr = row.Field<string>(4);

                textBox1.Text = name;
                textBox4.Text = phone;
                textBox3.Text = sno;
                textBox2.Text = addr;
            }


        }

        //保存按钮
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";

            string name = textBox1.Text;
            string phone = textBox4.Text;
            string sno = textBox3.Text;
            string addr = textBox2.Text;

            if (sno == "" || sno == null)
            {
                MessageBox.Show("身份证号不能为空！", "警告");
                return;
            }
            if (name == "" || name == null)
            {
                MessageBox.Show("姓名不能为空！", "警告");
                return;
            }
            if (phone == "" || phone == null)
            {
                MessageBox.Show("手机号不能为空！", "警告");
                return;
            }
            if (addr == "" || addr == null)
            {
                MessageBox.Show("地址不能为空！", "警告");
                return;
            }
       

            //身份证号不能重复
            string usersql = "select count(1) from custom where sno = '" + sno + "' and id <> '" + id + "'";
            myConn.Open();
            SqlCommand cmd = new SqlCommand(usersql, myConn);
            int res = (int)cmd.ExecuteScalar();
            if (res > 0)
            {
                MessageBox.Show("身份证号已存在！", "警告");
                return;
            }

            if (id != -1)
            {
                //修改 
                string updsql = "update custom set name = @name, phone = @phone, sno = @sno, addr = @addr where id = @id";
                cmd = new SqlCommand(updsql, myConn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@sno", sno);
                cmd.Parameters.AddWithValue("@addr", addr);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            else
            {
                //新增
                string updsql = "insert into custom (name, phone, sno, addr) values ( @name, @phone, @sno, @addr) ";
                cmd = new SqlCommand(updsql, myConn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@sno", sno);
                cmd.Parameters.AddWithValue("@addr", addr);
                cmd.ExecuteNonQuery();
            }

            myConn.Close();
            MessageBox.Show("保存成功！", "成功");
            if (this.custom != null)
            {
                //刷新表格数据
                this.custom.CustomBind();
            }
            this.Close();
        }
    }
}
