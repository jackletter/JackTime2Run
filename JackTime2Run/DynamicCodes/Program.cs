/*
 * 使用动态编译,除了注意引用dll的书写方法外代码和VS中的写法一致
 * "//#import System.dll":代表引用了系统动态库System.dll
 * "//#import E:\WebSite\bin\HanZi2PinYin.dll":代表引用了绝对路径下的dll
 * "//#import ~\bin\Demo.dll":代表引用了相对路径下的dll
 */

//#import System.dll
//#import System.Core.dll
//#import Microsoft.CSharp.dll
//#import System.Data.dll
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            lock (typeof(Program))
            {
                string para = "";
                if (args != null && args.Length > 0)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        para += args[i];
                    }
                }
                File.AppendAllText("d:\\demo2.exe.txt", "Demo2.exe" + DateTime.Now.ToString
                    ("yyyy-MM-dd HH:mm:ss.fff") + para + "\r\n");
            }
        }

        public void Show()
        {
            lock (typeof(Program))
            {
                File.AppendAllText("d:\\demo2.Show().txt", "demo2.Show()" + DateTime.Now.ToString
                    ("yyyy-MM-dd HH:mm:ss.fff") + "\r\n");
            }
        }

        public void Show(string[] args)
        {
            lock (typeof(Program))
            {
                string para = "";
                if (args != null && args.Length > 0)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        para += args[i];
                    }
                }
                File.AppendAllText("d:\\demo2.Show(string[] args).txt", "demo2.Show(string[] args)" + DateTime.Now.ToString
                    ("yyyy-MM-dd HH:mm:ss.fff") + para + "\r\n");
            }
        }
    }
}
