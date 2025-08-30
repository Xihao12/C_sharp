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
    public static class inventory
    {
        public static object CheckInventory(string uid,string iid)//查询某一数据，或检查有无数据
        { 
            string sql=string.Format("select inventory from inventory where uid='{0}'and iid='{1}'",uid,iid);
            return DAC.DA.GetOneData(sql, System.Data.CommandType.Text, null, null);
        }
        public static DataTable GetUserInventory(string uid)//获取某一用户的所有库存
        {
            string sql = string.Format("select inventory.iid,iname,inventory from items,inventory where items.iid=inventory.iid and uid='{0}'",uid);
            return DAC.DA.GetDataTable(sql, System.Data.CommandType.Text, null, null);
        }
        public static int AddUserInventory(string uid, string iid, int num)//增加已有数据数量
        {
            string sql = string.Format("update inventory set inventory=inventory+{0} where uid='{1}'and iid='{2}'",num,uid,iid);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
        public static int NewUserInventory(string uid,string iid,int num)//新增库存表数据
        {
            string sql = string.Format("insert into inventory (uid,iid,inventory) values('{0}','{1}',{2})",uid,iid,num);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
        public static int OutInventory(string uid,string iid,int num)//出库,库存减少
        {
            string sql = string.Format("update inventory set inventory=inventory-{0} where uid='{1}'and iid='{2}'", num, uid, iid);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);
        }
    }
}
