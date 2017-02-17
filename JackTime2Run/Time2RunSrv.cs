using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.ServiceModel;

namespace JackTime2Run
{
    public class Time2RunSrv
    {
        private static Hashtable ht = new Hashtable();
        FileSystemWatcher watch = new FileSystemWatcher();
        string srvName;
        string srvDesc;
        public Time2RunSrv(string srvName, string srvDesc)
        {
            this.srvName = srvName;
            this.srvDesc = srvDesc;
            watch.BeginInit();
            watch.Path = AppDomain.CurrentDomain.BaseDirectory;
            watch.NotifyFilter = NotifyFilters.LastWrite;
            watch.EnableRaisingEvents = true;
            string fileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            watch.Filter = fileName.Substring(fileName.LastIndexOf('\\') + 1);
            watch.IncludeSubdirectories = false;
            watch.Changed += watch_Changed;
            watch.EndInit();
        }

        void watch_Changed(object sender, FileSystemEventArgs e)
        {
            lock (typeof(Time2RunSrv))
            {
                if (ht[e.FullPath] == null)
                {
                    LoadJob(e.FullPath);
                    ht[e.FullPath] = File.GetLastWriteTime(e.FullPath);
                    return;
                }
                DateTime dt = (DateTime)ht[e.FullPath];
                if (dt != File.GetLastWriteTime(e.FullPath))
                {
                    LoadJob(e.FullPath);
                    ht[e.FullPath] = File.GetLastWriteTime(e.FullPath);
                    return;
                }
            }
        }
        public void Start()
        {
            try
            {
                //服务启动
                WriteLog("服务:【" + srvName + "】将要启动了...");
                string fileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                WriteLog("服务:【" + srvName + "】读取配置文件:" + fileName);
                LoadJob(fileName);
                WriteLog("服务:【" + srvName + "】启动成功!");
            }
            catch (Exception ex)
            {
                WriteLog("服务:【" + srvName + "】启动失败:" + ex.ToString());
                throw ex;
            }
        }

        public void Stop()
        {
            //服务停止
            WriteLog("服务:【" + srvName + "】停止了!");
        }

        public void Shutdown()
        {
            //服务关闭
            WriteLog("服务:【" + srvName + "】关闭了!");
        }

        public void Continue()
        {
            //服务继续
            WriteLog("服务:【" + srvName + "】继续了!");
        }

        public void Pause()
        {
            //服务暂停
            WriteLog("服务:【" + srvName + "】暂停了!");
        }

        private void LoadJob(string jobpath)
        {
            lock (typeof(Time2RunSrv))
            {
                System.Configuration.ConfigurationManager.RefreshSection("JackTime2RunJobs");
                System.Configuration.ConfigurationManager.GetSection("JackTime2RunJobs");
            }
            JobHelper.Sche();
        }

        public static void WriteLog(string msg)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory.Trim('\\').Trim('/') + "\\log";

            lock (typeof(Time2RunSrv))
            {
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                path += "\\SrvManage" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                System.IO.File.AppendAllText(path, "【日志信息: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "】" + msg + "\r\n");
            }
        }
    }
}
