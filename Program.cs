using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaverAlarm
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        /// 


        public static string ID;
        public static string PW;
        public static mainForm main;
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*
            Properties.Settings.Default.ID = "";
            Properties.Settings.Default.PassWord = "";
            Properties.Settings.Default.SaveID = true;
            Properties.Settings.Default.SavePassword = false;
            Properties.Settings.Default.AutoLogin = false;
            Properties.Settings.Default.Save();
            */

            main = new mainForm();
            Application.Run(main);
            
        }
    }
}