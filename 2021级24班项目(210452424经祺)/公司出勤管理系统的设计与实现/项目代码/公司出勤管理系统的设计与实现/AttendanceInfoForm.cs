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
    public partial class AttendanceInfoForm : Form
    {
        private AttendanceFrom F_FROM;
        private List<InfoEt> infoEt = new List<InfoEt>();
        private List<InfoEt> infoEt2 = new List<InfoEt>();

        public AttendanceInfoForm(AttendanceFrom FROM)
        { 
            this.F_FROM = FROM;
            InitializeComponent();
        }


        private void ParkingInfoForm_Load(object sender, EventArgs e)
        {
            ParkingInfoBind();
            ParkingInfo2Bind();

        }

        private void ParkingInfoBind()
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = DataBaseInfocs.URL;
            myConn.Open();
            // 创建查询语句
            string query = "SELECT id, staffno FROM staff";

            // 创建SqlDataReader对象
            SqlDataReader reader = new SqlCommand(query, myConn).ExecuteReader();
            if (infoEt.Count > 0)
            {
                infoEt.Clear();
            }
            // 循环读取查询结果并添加到ComboBox下拉框中
            while (reader.Read())
            {
                infoEt.Add(new InfoEt((int)reader[0], reader[1].ToString())); ;
                comboBox1.Items.Add(reader[1].ToString()); // 将第一列的值添加到下拉框中
            }

            // 关闭数据库连接
            reader.Close();
            myConn.Close();
        }

        private void ParkingInfo2Bind()
        {
            //构造SqlConnection对象
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = DataBaseInfocs.URL;
            myConn.Open();
            // 创建查询语句
            string query = "SELECT id, dno name FROM  department";

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


        private void button1_Click(object sender, EventArgs e)
        {
           

            string Isok = textBox1.Text.Trim();
            string Isno = textBox2.Text.Trim();

            try
            {
                int int_isok = int.Parse(Isok);
                 if (int_isok<=0)
                {
                    MessageBox.Show("【出勤次数】请输入正整数！", "警告");
                    return;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("【出勤次数】请输入正整数！", "警告");
                return;

            }
            try
            {
                int int_isno = int.Parse(Isno);
                if (int_isno <= 0)
                {
                    MessageBox.Show("【缺勤次数】请输入正整数！", "警告");
                    return;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("【缺勤次数】请输入正整数！", "警告");
                return;

            }



            int Index1 = comboBox1.SelectedIndex;
            if (Index1 < 0)
            {
                MessageBox.Show("请选择员工！", "警告");
                return;
            }
            int index2 = comboBox2.SelectedIndex;
            if (index2 < 0)
            {
                MessageBox.Show("请选择工作的部门！", "警告");
                return;
            }

            // 
            int staffid = infoEt[Index1].id;
            int did = infoEt2[index2].id;

            DialogResult result = MessageBox.Show("确定要添加当前内容吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SqlConnection myConn = new SqlConnection();
                myConn.ConnectionString = DataBaseInfocs.URL;
                myConn.Open();
                //新增
                string insql = "insert into  Attendance (staffid, did, isok, isno) values ( @staffid, @did, @isok, @isno ) ";
                SqlCommand cmd = new SqlCommand(insql, myConn);
                cmd.Parameters.AddWithValue("@staffid", staffid);
                cmd.Parameters.AddWithValue("@did", did);
                cmd.Parameters.AddWithValue("@isok", Isok);
                cmd.Parameters.AddWithValue("@isno", Isno);
                cmd.ExecuteNonQuery();
                myConn.Close();

                MessageBox.Show("添加成功");
                if (F_FROM != null)
                {
                    F_FROM.Bind();
                }
                this.Close();
            }

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

    }
}
