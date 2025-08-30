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
    public static class balance
    {
        public static double GetBalance(string uid)
        {
            string sql = "select balance from balance where uid='" + uid + "'";
            return Convert.ToDouble(DAC.DA.GetOneData(sql, System.Data.CommandType.Text, null, null));
        }
        public static int NewUser_Balance(string uid)
        {
            string sql = string.Format("insert into balance (uid,balance) values('{0}',0)", uid);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
        public static object UidCheck(string uid)
        {
            string sql = string.Format("select balance from balance where uid='" + uid + "'");
            return DAC.DA.GetOneData(sql, System.Data.CommandType.Text, null, null);
        }
        public static int BalanceChange(string uid,double d)
        {
            string sql = string.Format("update balance set balance=balance+{0} where uid ='{1}'",d,uid);
            return DAC.DA.ExecuteSQL(sql,System.Data.CommandType.Text,null,null);
        }
    }
}
