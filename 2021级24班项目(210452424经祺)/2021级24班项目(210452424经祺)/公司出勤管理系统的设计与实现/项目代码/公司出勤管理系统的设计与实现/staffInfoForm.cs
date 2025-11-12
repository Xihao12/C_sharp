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
    public partial class staffInfoForm : Form
    {
        int id;
        private staffForm F_From;

        public staffInfoForm(int id, staffForm F_From)
        {
            this.id = id;
            this.F_From = F_From;
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            InfoBind();
        }

        private void InfoBind()
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = DataBaseInfocs.URL;
            //构造SqlCommand对象
            string sql = "select * from staff where id = '" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            //离线模式，构造SqlDataAdapter和DataTable对象
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                //int carid = row.Field<int>(0);
                string staffno = row.Field<string>(1);
                string phone = row.Field<string>(2);
                string uno = row.Field<string>(3);
                string uname = row.Field<string>(4);

                textBox2.Text = staffno;
                textBox4.Text = phone;
                textBox3.Text = uno;
                textBox1.Text = uname;
            }


        }

        //保存按钮
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = DataBaseInfocs.URL;

            string staffno = textBox2.Text;
            string phone = textBox4.Text;
            string uno = textBox3.Text;
            string uname = textBox1.Text;

            if (staffno == "" || staffno == null)
            {
                MessageBox.Show("员工号不能为空！", "警告");
                return;
            }
       

            //车牌号不能重复
            string usersql = "select count(1) from staff where staffno = '" + staffno + "' and id <> '" + id + "'";
            myConn.Open();
            SqlCommand cmd = new SqlCommand(usersql, myConn);
            int res = (int)cmd.ExecuteScalar();
            if (res > 0)
            {
                MessageBox.Show("员工已存在！", "警告");
                return;
            }

            if (id != -1)
            {
                //修改 
                string updsql = "update staff set staffno = @staffno, phone = @phone, uno = @uno, uname = @uname where id = @id";
                cmd = new SqlCommand(updsql, myConn);
                cmd.Parameters.AddWithValue("@staffno", staffno);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@uno", uno);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            else
            {
                //新增
                string updsql = "insert into staff (staffno, phone, uno, uname) values ( @staffno, @phone, @uno, @uname) ";
                cmd = new SqlCommand(updsql, myConn);
                cmd.Parameters.AddWithValue("@staffno", staffno);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@uno", uno);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.ExecuteNonQuery();
            }

            myConn.Close();
            MessageBox.Show("保存成功！", "成功");
            if (this.F_From != null)
            {
                //刷新表格数据
                this.F_From.Bind();
            }
            this.Close();
        }
    }
}
