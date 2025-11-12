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
    public partial class departmentInfoForm : Form
    {
        departmentForm F_FROM;
        public departmentInfoForm(departmentForm from)
        {
            this.F_FROM = from;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string val = textBox1.Text;
            //新增
            string updsql = "insert into department (dno) values ( @val1) ";
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = DataBaseInfocs.URL;
            myConn.Open();
            SqlCommand cmd = new SqlCommand(updsql, myConn);
            cmd.Parameters.AddWithValue("@val1", val);
            cmd.ExecuteNonQuery();

            myConn.Close();
            MessageBox.Show("保存成功！", "成功");
            if (this.F_FROM != null)
            {
                //刷新表格数据
                this.F_FROM.Bind();
            }
            this.Close();
        }
    }
}
