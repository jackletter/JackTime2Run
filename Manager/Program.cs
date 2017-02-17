/*********************************************
 * 功能描述:自动定时服务管理端
 * 创 建 人:胡庆杰
 * 日    期:2017-2-8
 * github:https://github.com/jackletter/JackTime2Run
 * 说明:提供可视化管理支持
 * 
 ********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
