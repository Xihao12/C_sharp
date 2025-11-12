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
    public partial class staffForm : Form
    {
        int id = -1;

        public staffForm()
        {
            InitializeComponent();
        }

        private void CarForm_Load(object sender, EventArgs e)
        {
            Bind();
        }
        /****** Script for SelectTopNRows command from SSMS  ******/
      //  SELECT TOP 1000 [id]
      //,[staffno]
      //,[phone]
      //,[uno]
      //,[uname]
      //  FROM[CompanyAttendance].[dbo].[staff]
        public void Bind()
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = DataBaseInfocs.URL;
            //构造SqlCommand对象
            string sql = "select * from staff";
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

        //搜索按钮
        private void button1_Click(object sender, EventArgs e)
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = DataBaseInfocs.URL;
            //构造SqlCommand对象
            string sql = "select * from staff where staffno like '%" + textBox1.Text + "%'  or  uname like '%" + textBox1.Text + "%'     ";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            myConn.Open();
            //离线模式，构造SqlDataAdapter和DataTable对象
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            myConn.Close();
            DataTable dt = new DataTable();
            sda.Fill(dt);//填充数据
            dataGridView1.DataSource = dt;

        }

        //新增按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //打开新增修改窗口 
            //传入 this 当前窗口对象 到 弹出子窗口 可在子窗口 调用 this 父窗口方法
            staffInfoForm info = new staffInfoForm(-1, this);
            info.Show();
        }
        //修改按钮
        private void button2_Click(object sender, EventArgs e)
        {
            //打开新增修改窗口
            //传入 this 当前窗口对象 到 弹出子窗口 可在子窗口 调用 this 父窗口方法
            staffInfoForm info = new staffInfoForm(id, this);
            info.Show();

        }
        //删除按钮
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
                    string sql = "delete from staff where id = '" + id + "'";
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
    }
}
