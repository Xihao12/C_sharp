using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 共享单车管理系统
{
    internal static class Program
    {
        public static string userName;//存储登录的用户名
        public static string adminName;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            //Application.Run(new SelectForm());
            //Application.Run(new AdminMainForm());
        }
    }
}
