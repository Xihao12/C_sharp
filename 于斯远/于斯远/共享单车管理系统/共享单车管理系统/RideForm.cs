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

namespace 共享单车管理系统
{
    public partial class RideForm : Form
    {
        string bno;//存自行车编号
        string B_add;
        public RideForm()
        {
            InitializeComponent();
        }
        public RideForm(string a="1") 
        {
            InitializeComponent();
            btnAdd.Text = "挪动";
        }
        private void bicycleBind()
        {
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=bicycle;uid=sa;pwd=123456;integrated security=yes";
            string sql = "select * from bicycle";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RideForm_Activated(object sender, EventArgs e)
        {
            bicycleBind();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bno = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            B_add = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            btnAdd.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            btnCancel.Enabled = false;
            btnAdd.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=bicycle;uid=sa;pwd=123456;integrated security=yes";
            string sql = "select * from bicycle where B_add like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(btnAdd.Text=="挪动")
            {
                string b = "2";
                Ride1Form ride1Form1=new Ride1Form(bno, B_add,b);
                ride1Form1.ShowDialog();
            }
            else
            {
                Ride1Form ride1Form = new Ride1Form(bno,B_add);
                ride1Form.ShowDialog();
            }
            
        }
    }
}
