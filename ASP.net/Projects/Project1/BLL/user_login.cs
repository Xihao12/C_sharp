using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;
using DAC;

namespace BLL
{
    public static class user_login
    {
        public static object UtypeCheck(Entity.userlog ulg)//存储过程名spr_UtypeCheck
        {
            string[] names = new string[] { "uid", "upassword" };
            object[] values = new object[] { ulg.Uid, ulg.Upassword };

            return DAC.DA.GetOneData("dbo.spr_UtypeCheck", System.Data.CommandType.StoredProcedure, names, values);
        }
        
        public static string GetNewUid()
        {
            int intuid = Convert.ToInt32(DAC.DA.GetOneData("select count(*) from user_login", System.Data.CommandType.Text, null, null).ToString());
            return intuid.ToString("D" + 8);//查询uid已有数据条数,并转化为string型，不满8位用0补位
        }
        public static int NewUser_Login(string uid,string upassword)
        {
            string sql = string.Format("insert into user_login (uid,upassword,utype) values('{0}','{1}','user')", uid, upassword);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
        //public static int NewUser_Information(string uid, string uname)
        //{
        //    string sql = string.Format("insert into user_information (uid,uname) values('{0}','{1}')", uid, uname);
        //    return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        //}

        public static int NewUser(string struid,string uname,string upassword)
        {
            //string struid = GetNewUid();
            int a = NewUser_Login(struid,upassword);
            int b = BLL.user_information.NewUser_Information(struid, uname);
            int c = BLL.balance.NewUser_Balance(struid);
            return (a == 1 && b == 1&&c==1 ? 1 : 0);
        }
        public static int ChangePassword(string uid, string newpwd)
        {
            string sql = string.Format("update user_login set upassword='{0}' where uid='{1}'",newpwd,uid);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
        public static int ChangeUtype(string uid, string utype)
        { 
            string sql=string.Format("update user_login set utype='{0}' where uid='{1}'",utype,uid);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
    }
}
