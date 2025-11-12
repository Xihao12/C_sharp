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
    public partial class Custom : Form
    {
        int id = -1;

        public Custom()
        {
            InitializeComponent();
        }

        private void Custom_Load(object sender, EventArgs e)
        {
            CustomBind();
        }

        public void CustomBind()
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";
            //构造SqlCommand对象
            string sql = "select * from custom";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            myConn.Open();
            //离线模式，构造SqlDataAdapter和DataTable对象
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            myConn.Close();
            DataTable dt = new DataTable();
            sda.Fill(dt);//填充数据
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value;
            btnDelete.Enabled = true;
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";
            //构造SqlCommand对象
            string sql = "select * from custom where sno like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            myConn.Open();
            //离线模式，构造SqlDataAdapter和DataTable对象
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            myConn.Close();
            DataTable dt = new DataTable();
            sda.Fill(dt);//填充数据
            dataGridView1.DataSource = dt;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomInfo customInfo = new CustomInfo(-1, this);
            customInfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomInfo customInfo = new CustomInfo(id, this);
            customInfo.Show();

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
                    string sql = "delete from custom where id = '" + id + "'";
                    myConn.Open();
                    SqlCommand cmd = new SqlCommand(sql, myConn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    myConn.Close();
                    MessageBox.Show("删除成功");
                    //刷新表格
                    CustomBind();
                }
            }

        }
    }
}
