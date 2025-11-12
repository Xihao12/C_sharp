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
    public partial class AttendanceFrom : Form
    {
        int id = -1;
        public AttendanceFrom()
        {
            InitializeComponent();
        }

        private void ParkingFrom_Load(object sender, EventArgs e)
        {
            Bind();
        }

        public void Bind()
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = DataBaseInfocs.URL;
            //构造SqlCommand对象
            string sql = "select a.id, b.staffno, b.uname,b.phone, c.id departmentid, c.dno, a.isok, a.isno from Attendance a left join staff b on a.staffid = b.id left join department c on a.did = c.id";
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
            id = (int)dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value;
            btnDelete.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AttendanceInfoForm parkingInfoForm = new AttendanceInfoForm(this);
            parkingInfoForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string VAL = textBox1.Text;
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = DataBaseInfocs.URL;
            //构造SqlCommand对象
            string sql = "select a.id, b.staffno, b.uname,b.phone, c.id departmentid, c.dno, a.isok, a.isno from Attendance a left join staff b on a.staffid = b.id left join department c on a.did = c.id where b.staffno like '%" + VAL + "%' or  b.uname like '%" + VAL + "%' ";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            myConn.Open();
            //离线模式，构造SqlDataAdapter和DataTable对象
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            myConn.Close();
            DataTable dt = new DataTable();
            sda.Fill(dt);//填充数据
            dataGridView1.DataSource = dt;

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
                    myConn.ConnectionString = DataBaseInfocs.URL;
                    string sql = "delete from Attendance where id = '" + id + "' ";
                    myConn.Open();
                    SqlCommand cmd = new SqlCommand(sql, myConn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    myConn.Close();
                    MessageBox.Show("删除成功");
                    //刷新表格
                    Bind();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
