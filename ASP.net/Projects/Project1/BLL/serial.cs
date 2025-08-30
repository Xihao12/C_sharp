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
    public static class serial
    {
        public static DataTable GetSerial()
        { 
            return DAC.DA.GetDataTable("select * from serial",System.Data.CommandType.Text,null,null);
        }
        public static DataTable GetSerial(string iid)
        {
            string sql = string.Format("select * from serial where iid='{0}'",iid);
            return DAC.DA.GetDataTable(sql, System.Data.CommandType.Text, null, null);
        }
        public static string GetSeid()
        {
            int intsid = Convert.ToInt32(DAC.DA.GetOneData("select count(*) from serial", System.Data.CommandType.Text, null, null).ToString());
            return intsid.ToString("D" + 10);
        }
        public static int NewSerial(string seid,string inuid,string outuid,string iid,string date,double price)
        {
            string sql=string.Format("insert into serial(seid,inuid,outuid,iid,date,price) values('{0}','{1}','{2}','{3}','{4}',{5})",seid,inuid,outuid,iid,date,price);
            return DAC.DA.ExecuteSQL(sql, System.Data.CommandType.Text, null, null);

        }
    }
}
