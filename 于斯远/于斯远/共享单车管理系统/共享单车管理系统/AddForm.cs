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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 共享单车管理系统
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=bicycle;uid=sa;pwd=123456;integrated security=yes";
            //构造SqlCommand对象
            
            string sql1 = "select count(*) from bicycle";
            SqlCommand sqlCommand = new SqlCommand(sql1, myConn);
            //打开连接
            myConn.Open();
            
            
            string bno = (Convert.ToInt32(sqlCommand.ExecuteScalar().ToString()) + 1).ToString("D" + 8);//自动填充bno
            string insertStr = "insert into bicycle (bno,B_add) values ('" + bno + "', '" + textBox1.Text + "')";
            SqlCommand cmd2 = new SqlCommand(insertStr, myConn);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("投放成功！", "成功");

            //关闭数据库连接
            myConn.Close();
        }
    }
}
