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
    public partial class outbound : Form
    {
        int id = -1;
        string status = "";
        public outbound()
        {
            InitializeComponent();
        }

        private void outbound_Load(object sender, EventArgs e)
        {
            outboundBind();
        }

        public void outboundBind()
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";
            //构造SqlCommand对象
            string sql = "select a.id, isnull(c.status, '未发货') status, a.logno,a.number,a.weight,b.name,a.ischu,a.rdate,a.cdate from warehousing a left join custom b on a.custid = b.id left join outbound c on a.id = c.wid where a.ischu = '入库'";
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
            string sql = "select a.id, isnull(c.status, '未发货') status, a.logno,a.number,a.weight,b.name,a.ischu,a.rdate,a.cdate from warehousing a left join custom b on a.custid = b.id left join outbound c on a.id = c.wid where a.ischu = '入库' and a.logno like '" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            myConn.Open();
            //离线模式，构造SqlDataAdapter和DataTable对象
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            myConn.Close();
            DataTable dt = new DataTable();
            sda.Fill(dt);//填充数据
            dataGridView1.DataSource = dt;

        }

        private void btnfh_Click(object sender, EventArgs e)
        {
            if (status != "未发货")
            {
                MessageBox.Show("物流已发货！", "警告");
                return;
            }
            if (id > 0)
            {
                DialogResult result = MessageBox.Show("确定要发货选中数据吗?", "确定", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    SqlConnection myConn = new SqlConnection();
                    myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";
                    //打开连接
                    myConn.Open();
                    //新增
                    string updsql = "insert into outbound (wid, status, fdate) values ( @wid, @status, @fdate) ";
                    SqlCommand cmd = new SqlCommand(updsql, myConn);
                    cmd.Parameters.AddWithValue("@wid", id);
                    cmd.Parameters.AddWithValue("@status", "已发货");
                    cmd.Parameters.AddWithValue("@fdate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("发货成功！", "成功");

                    //刷新表格
                    outboundBind();
                }
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value;
            status = dataGridView1.Rows[e.RowIndex].Cells["Column9"].Value.ToString();
            btnfh.Enabled = true;

        }
    }
}
