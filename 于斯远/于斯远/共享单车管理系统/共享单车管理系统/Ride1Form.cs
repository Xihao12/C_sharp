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
    public partial class Ride1Form : Form
    {
        public string bno;
        public string B_old_add;
        public string B_new_add;
        public string rno;
        public Ride1Form(string bno,string B_add)
        {
            InitializeComponent();
            this.bno = bno;
            B_old_add = B_add;
        }
        public Ride1Form(string bno, string B_add,string b="2")
        {
            InitializeComponent();
            this.bno = bno;
            B_old_add = B_add;
            button1.Text = "挪车";
        }

        private void Ride1Form_Load(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=bicycle;uid=sa;pwd=123456;integrated security=yes";
            string sql = "select count(*) from bicycle_ride";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            myConn.Open();
            rno = (Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1).ToString("D" + 8);
            //MessageBox.Show("rno:"+rno+"\r\n"+ "bno:" + bno + "\r\n" + "oldadd:" + B_old_add + "\r\n" + "newadd:" + B_new_add );
            myConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text=="挪车")
            {
                B_new_add = textBox1.Text;
                SqlConnection myConn = new SqlConnection();
                myConn.ConnectionString = "server=localhost;database=bicycle;uid=sa;pwd=123456;integrated security=yes";
                myConn.Open();
                string sql2 = string.Format("update bicycle set B_add='{0}'where bno='{1}'", B_new_add, bno);
                SqlCommand cmd2 = new SqlCommand(sql2, myConn);
                cmd2.ExecuteNonQuery();
                myConn.Close();
                MessageBox.Show("成功挪车", "提示");
                this.Close();
            }
            else 
            {
                B_new_add = textBox1.Text;
                //MessageBox.Show("rno:" + rno + "\r\n" + "bno:" + bno + "\r\n" + "oldadd:" + B_old_add + "\r\n" + "newadd:" + B_new_add);
                SqlConnection myConn = new SqlConnection();
                myConn.ConnectionString = "server=localhost;database=bicycle;uid=sa;pwd=123456;integrated security=yes";
                myConn.Open();
                string sql = string.Format("insert into bicycle_ride values('{0}','{1}','{2}','{3},')", rno, bno, B_old_add, B_new_add);
                SqlCommand cmd = new SqlCommand(sql, myConn);
                string sql2 = string.Format("update bicycle set B_add='{0}'where bno='{1}'", B_new_add, bno);
                SqlCommand cmd2 = new SqlCommand(sql2, myConn);

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                myConn.Close();
                MessageBox.Show("成功骑行", "提示");
                this.Close();
            }
            
            
            
        }
    }
}
