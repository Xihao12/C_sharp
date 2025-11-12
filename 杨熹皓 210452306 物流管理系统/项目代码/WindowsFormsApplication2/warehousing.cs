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
    public partial class warehousing : Form
    {
        int id = -1;
        public warehousing()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            warehousingInfo wareh = new warehousingInfo(this);
            wareh.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                // 弹出一个确认删除的对话框  
                DialogResult result = MessageBox.Show("确定要删除选中数据吗?", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // 删除操作
                    SqlConnection myConn = new SqlConnection();
                    myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";
                    string sql = "delete from warehousing where id = '" + id + "' ";
                    myConn.Open();
                    SqlCommand cmd = new SqlCommand(sql, myConn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    myConn.Close();
                    MessageBox.Show("删除成功");
                    //刷新表格
                    warehousingBind();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value;
            btnDelete.Enabled = true;
            button2.Enabled = true;
        }


        private void warehousing_Load(object sender, EventArgs e)
        {
            warehousingBind();
        }

        public void warehousingBind()
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";
            //构造SqlCommand对象
            string sql = "select a.id,a.logno,a.number,a.weight,b.name,a.ischu,a.rdate,a.cdate from warehousing a left join custom b on a.custid = b.id";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            myConn.Open();
            //离线模式，构造SqlDataAdapter和DataTable对象
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            myConn.Close();
            DataTable dt = new DataTable();
            sda.Fill(dt);//填充数据
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";
            //构造SqlCommand对象
            string sql = "select a.id,a.logno,a.number,a.weight,b.name,a.ischu,a.rdate,a.cdate from warehousing a left join custom b on a.custid = b.id where a.logno like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            myConn.Open();
            //离线模式，构造SqlDataAdapter和DataTable对象
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            myConn.Close();
            DataTable dt = new DataTable();
            sda.Fill(dt);//填充数据
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                // 弹出一个确认删除的对话框  
                DialogResult result = MessageBox.Show("确定要出库选中数据吗?", "确定", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SqlConnection myConn = new SqlConnection();
                    myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";
                    myConn.Open();
                    //修改 
                    string updsql = "update warehousing set ischu = @ischu, cdate = @cdate where id = @id";
                    SqlCommand cmd = new SqlCommand(updsql, myConn);
                    cmd.Parameters.AddWithValue("@ischu", "出库");
                    cmd.Parameters.AddWithValue("@cdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    myConn.Close();
                    warehousingBind();
                }
            }
        }
    }
}
