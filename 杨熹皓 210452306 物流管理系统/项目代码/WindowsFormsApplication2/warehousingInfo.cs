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
    public partial class warehousingInfo : Form
    {
        int id = -1;
        warehousing ware;
        private List<InfoEt> infoEt2 = new List<InfoEt>();

        public warehousingInfo(warehousing ware)
        {
            this.ware = ware;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //生成订单编号
            DateTime now = DateTime.Now;
            DateTime startTime = new DateTime(1970, 1, 1);
            long logno = (long)(now - startTime).TotalSeconds;
            int custid = infoEt2[comboBox2.SelectedIndex].id;
            int number = int.Parse(numericUpDown2.Value.ToString());
            int weight = int.Parse(textBox3.Text);

            if (comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("请选择客户！", "警告");
                return;
            }
            if (number <= 0)
            {
                MessageBox.Show("请选择件数！", "警告");
                return;
            }
            if (weight <= 0)
            {
                MessageBox.Show("请填写重量！", "警告");
                return;
            }
          

            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";

            //打开连接
            myConn.Open();

         
            //新增
            string updsql = "insert into warehousing (logno, number, weight, custid, rdate) values ( @logno, @number, @weight, @custid, @rdate) ";
            SqlCommand cmd = new SqlCommand(updsql, myConn);
            cmd.Parameters.AddWithValue("@logno", logno);
            cmd.Parameters.AddWithValue("@number", number);
            cmd.Parameters.AddWithValue("@weight", weight);
            cmd.Parameters.AddWithValue("@custid", custid);
            cmd.Parameters.AddWithValue("@rdate", now);
            cmd.ExecuteNonQuery();
            

            myConn.Close();
            MessageBox.Show("保存成功！", "成功");
            if (this.ware != null)
            {
                //刷新表格数据
                this.ware.warehousingBind();
            }
            this.Close();
        }

        private void warehousingInfo_Load(object sender, EventArgs e)
        {
            boxLoad();
        }



        private void boxLoad()
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "server=localhost;database=logistics;uid=sa;pwd=123456;integrated security=yes";
            myConn.Open();
            // 创建查询语句
            string query = "SELECT id, name FROM custom";

            // 创建SqlDataReader对象
            SqlDataReader reader = new SqlCommand(query, myConn).ExecuteReader();
            if (infoEt2.Count > 0)
            {
                infoEt2.Clear();
            }
            // 循环读取查询结果并添加到ComboBox下拉框中
            while (reader.Read())
            {
                infoEt2.Add(new InfoEt((int)reader[0], reader[1].ToString())); ;
                comboBox2.Items.Add(reader[1].ToString()); // 将第一列的值添加到下拉框中
            }

            // 关闭数据库连接
            reader.Close();
            myConn.Close();
        }

        public class InfoEt
        {
            public InfoEt(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
            public string name { get; set; }
            public int id { get; set; }
        }


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

    }
}
