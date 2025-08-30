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
    public static class user_information
    {
        public static string GetUserName(string uid)
        {
            string sql="select uname from user_information where uid='"+uid+"'";
            return DAC.DA.GetOneData(sql,System.Data.CommandType.Text,null,null).ToString();

        }
        public static string GetInformation(string uid,string s)
        { 
            string sql=string.Format("select {0} from user_information where uid='{1}'",s,uid);
            return DAC.DA.GetOneData(sql, System.Data.CommandType.Text, null, null).ToString();
        }
        public static int NewUser_Information(string uid, string uname)
        {
            string sql = string.Format("insert into user_information (uid,uname) values('{0}','{1}')", uid, uname);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
        public static int ChangeInformation(string uid, string uname, string tel, string address, string bi)
        {
            string sql = string.Format("update user_information set uname='{0}',tel='{1}',address='{2}',bi='{3}' where uid='{4}'",uname,tel,address,bi,uid);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
    }
}
