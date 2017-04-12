/*********************************************
 * 功能描述:自动定时服务
 * 创 建 人:胡庆杰
 * 日    期:2017-2-8
 * github:https://github.com/jackletter/JackTime2Run
 * 说明:
 * 安装：JackTime2Run.exe install
 * 启动：JackTime2Run.exe start
 * 卸载：JackTime2Run.exe uninstall
 * 
 ********************************************/
using Quartz;
using Quartz.Impl;
using ServiceModelEx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace JackTime2Run
{
    public class Program
    {
        static void Main(string[] args)
        {
            string srvName = System.Configuration.ConfigurationManager.AppSettings["srvname"];
            if (string.IsNullOrEmpty(srvName))
            {
                srvName = "JackTime2Run";
            }
            string srvDesc = System.Configuration.ConfigurationManager.AppSettings["srvdesc"];
            if (string.IsNullOrEmpty(srvDesc))
            {
                srvDesc = "JackTime2Run的定时服务,使用Quartz.net,可定时调用.dll|.exe(c#代码)|.cs文件";
            }
            var host = HostFactory.New(configuration =>
            {
                configuration.Service<Host>(callback =>
                {
                    callback.ConstructUsing(s => new Host(srvName, srvDesc));
                    callback.WhenStarted(service => service.Start());
                    callback.WhenStopped(service => service.Stop());
                });
                configuration.SetDisplayName(srvName);
                configuration.SetServiceName(srvName);
                configuration.SetDescription(srvDesc);
                configuration.RunAsLocalSystem();
            });
            host.Run();
        }
    }

    internal class Host
    {
        //wcf服务
        private ServiceHost<NamePipeSrv> _service;
        //定时调度服务
        private Time2RunSrv _srv;

        internal Host(string srvName, string srvDesc)
        {
            _service = new ServiceHost<NamePipeSrv>(new Uri[] { });
            _srv = new Time2RunSrv(srvName, srvDesc);
        }

        public void Start()
        {
            //#if DEBUG
            //            Debugger.Launch();
            //#endif
            _service.Open();
            _srv.Start();
        }

        public void Stop()
        {
            try
            {
                if (_service != null)
                {
                    if (_service.State == CommunicationState.Opened)
                    {
                        _service.Close();
                    }
                }
            }
            catch { };
            try
            {
                _srv.Stop();
            }
            catch { };
        }
    }
}