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
    public static class items
    {
        public static DataTable GetItems()
        {
            return DAC.DA.GetDataTable("select * from items", System.Data.CommandType.Text, null, null);
        }
        
        public static DataTable SearchItems(string search)
        {
            return DAC.DA.GetDataTable("select * from items where iname like '%" + search + "%'", System.Data.CommandType.Text, null, null);
        }
        public static object GetLtp(string iid)
        {
            string sql = string.Format("select ltp from items where iid='{0}'", iid);
            return DAC.DA.GetOneData(sql, System.Data.CommandType.Text, null, null);
        }
        public static object GetIname(string iid)
        {
            string sql = string.Format("select iname from items where iid='{0}'", iid);
            return DAC.DA.GetOneData(sql, System.Data.CommandType.Text, null, null);
        }
        public static string GetNewIid()
        {
            int intiid = Convert.ToInt32(DAC.DA.GetOneData("select count(*) from items", System.Data.CommandType.Text, null, null).ToString());
            return intiid.ToString("D"+8);//查询iid已有数据条数,并转化为string型，不满8位用0补位
        }
        public static object CheckIname(string iname)
        {
            return DAC.DA.GetOneData("select * from items where iname ='"+iname+"'", System.Data.CommandType.Text, null, null);
        }
        public static int NewItem(string iname,double ltp)
        {
            string striid = GetNewIid();
            string sql = string.Format("insert into items (iid,iname,ltp) values('{0}','{1}',{2})",striid,iname,ltp);
            return DAC.DA.ExecuteSQL(sql,System.Data.CommandType.Text,null,null);
        }
        public static int UpdateLtp(string iid, double ltp)
        {
            string sql = string.Format("update items set ltp={0} where iid='{1}'", ltp, iid);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
    }
}
