using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Quartz;
using Quartz.Impl;

namespace JackTime2Run
{
    public class FullJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                JackJob job = context.JobDetail.JobDataMap.Get("jobname") as JackJob;
                ExeJob(job);
            }
            catch (Exception ex)
            {
                WriteLog("【日志信息: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "】[任务执行失败]:" + ex.ToString() + "\r\n");
            }

        }

        public void ExeJob(JackJob job)
        {
            string Info = "";
            string jobtype = "未知类型";
            switch (job.JobType)
            {
                case "0":
                    {
                        jobtype = "dll调用";
                        break;
                    }
                case "1":
                    {
                        jobtype = "编译CS文件";
                        break;
                    }
                case "2":
                    {
                        jobtype = "exe调用";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            Info += "[任务名:" + job.Name + "][任务类型:" + jobtype + "]";

            //处理调用时的参数,默认没有参数
            Type[] types = new Type[] { };
            object[] paras = new object[] { };
            if (job.Paras.Count > 0)
            {
                //有参数情况,参数默认是一个字符串数组
                types = new Type[] { typeof(string[]) };
                paras = new object[1];
                paras[0] = new string[job.Paras.Count];
                for (int i = 0; i < job.Paras.Count; i++)
                {
                    (paras[0] as string[])[i] = job.Paras[i];
                }
            }

            if (job.JobType == "0")
            {
                Info += "[程序集搜索路径:" + job.SearchPath + "][执行类:" + job.TypeName + "][执行方法:" + job.Method + "]";
                try
                {
                    Hashtable ht = DynamicUtil.MainlUtil.InvokeDll(job.SearchPath, job.TypeName, job.Method, types, paras);
                    if (!(bool)ht["Success"])
                    {
                        Info += "[出错]\r\n" + (ht["Data"] ?? "").ToString();
                        if (job.LogWhen == "0" || job.LogWhen == "2")
                        {
                            //失败或一定记录时
                            WriteLog(Info);
                        }
                        return;
                    }
                    else
                    {
                        Info += "[成功]\r\n";
                        if (job.LogWhen == "1" || job.LogWhen == "0")
                        {
                            //成功时记录
                            WriteLog(Info);
                        }

                    }
                }
                catch (Exception ex)
                {
                    if (job.LogWhen == "0" || job.LogWhen == "2")
                    {
                        //失败或一定记录时
                        WriteLog(Info + "\r\n" + ex.ToString());
                    }
                    return;
                }
            }
            else if (job.JobType == "1")
            {
                Info += "[程序集搜索路径:" + job.SearchPath + "][编译文件:" + job.SrcCodeFilePath + "][执行类:" + job.TypeName + "][执行方法:" + job.Method + "]";
                try
                {
                    Hashtable ht = DynamicUtil.MainlUtil.InvokeSrc(job.SearchPath, job.SrcCodeFilePath, job.TypeName, job.Method, types, paras);
                    if (!(bool)ht["Success"])
                    {
                        Info += "[出错]\r\n" + (ht["Data"] ?? "").ToString();
                        if (job.LogWhen == "0" || job.LogWhen == "2")
                        {
                            //失败或一定记录时
                            WriteLog(Info);
                        }
                        return;
                    }
                    else
                    {
                        Info += "[成功]\r\n";
                        if (job.LogWhen == "1" || job.LogWhen == "0")
                        {
                            //成功时记录
                            WriteLog(Info);
                        }

                    }
                }
                catch (Exception ex)
                {
                    if (job.LogWhen == "0" || job.LogWhen == "2")
                    {
                        //失败或一定记录时
                        WriteLog(Info + "\r\n" + ex.ToString());
                    }
                    return;
                }
            }
            else if (job.JobType == "2")
            {
                Info += "[程序集搜索路径:" + job.SearchPath + "][加载exe:" + job.TypeName + "]";
                try
                {
                    Hashtable ht = DynamicUtil.MainlUtil.InvokeExe(job.SearchPath, job.TypeName, job.Paras.ToArray<string>());
                    if (!(bool)ht["Success"])
                    {
                        Info += "[出错]\r\n" + (ht["Data"] ?? "").ToString();
                        if (job.LogWhen == "0" || job.LogWhen == "2")
                        {
                            //失败或一定记录时
                            WriteLog(Info);
                        }
                        return;
                    }
                    else
                    {
                        Info += "[成功]\r\n";
                        if (job.LogWhen == "1" || job.LogWhen == "0")
                        {
                            //成功时记录
                            WriteLog(Info);
                        }

                    }
                }
                catch (Exception ex)
                {
                    if (job.LogWhen == "0" || job.LogWhen == "2")
                    {
                        //失败或一定记录时
                        WriteLog(Info + "\r\n" + ex.ToString());
                    }
                    return;
                }
            }
        }

        public void WriteLog(string msg)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory.Trim('\\').Trim('/') + "\\log";

            lock (typeof(FullJob))
            {
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                path += "\\TaskLog" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                System.IO.File.AppendAllText(path, "【日志信息: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "】" + msg + "\r\n");
            }
        }
    }
}
