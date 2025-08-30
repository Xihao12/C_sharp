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
    public static class sell
    {
        public static DataTable GetSell()//获取销售表数据
        {
            return DAC.DA.GetDataTable("select sid,uname,iname,price,snum from items,sell,user_information where sell.uid=user_information.uid and sell.iid=items.iid", System.Data.CommandType.Text, null, null);
        }
        public static DataTable SearchSell(string search)//按商品名搜索
        {
            return DAC.DA.GetDataTable("select sid,uname,iname,price,snum from items,sell,user_information where sell.uid=user_information.uid and sell.iid=items.iid and iname like '%" + search + "%'", System.Data.CommandType.Text, null, null);
        }
        public static DataTable GetUserSell(string uid)
        {
            string sql = string.Format("select sid,iname,price,snum from items,sell where uid='{0}' and sell.iid=items.iid", uid);
            return DAC.DA.GetDataTable(sql, System.Data.CommandType.Text, null, null);
        }
        public static string GetSid()//自动获取销售表编号
        {
            int intsid = Convert.ToInt32(DAC.DA.GetOneData("select count(*) from sell", System.Data.CommandType.Text, null, null).ToString());
            return intsid.ToString("D" + 10);
        }
        public static object CheckSell(string check, string uid,string iid)//检查销售表有无该条数据,check为price或num
        { 
            string sql=string.Format("select {0} from sell where uid='{1}' and iid='{2}'",check,uid,iid);
            return DAC.DA.GetOneData(sql,System.Data.CommandType.Text,null,null);
        }
        public static object GetSellSid(string check, string sid)
        {
            string sql = string.Format("select {0} from sell where sid='{1}'", check, sid);
            return DAC.DA.GetOneData(sql, System.Data.CommandType.Text, null, null);
        }
        public static object CheckSidUid(string sid,string uid)
        {
            string sql = string.Format("select * from sell where sid='{0}' and uid ='{1}'",sid,uid);
            return DAC.DA.GetOneData(sql, System.Data.CommandType.Text, null, null);
        }
        public static int NewSell(string sid,string uid,string iid,double price,int snum)
        { 
            string sql=string.Format("insert into sell (sid,uid,iid,price,snum) values('{0}','{1}','{2}',{3},{4})",sid,uid,iid,price,snum);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
        public static int ChangeSell(string sid, double price, int snum)
        {
            string sql = string.Format("update sell set price={0},snum={1} where sid='{2}'", price, snum, sid);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
        public static int SellOut(string sid, int num)//出售
        {
            string sql = string.Format("update sell set snum=snum-{0} where sid='{1}'", num, sid);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
    }
}
