using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Quartz;
using Quartz.Impl.Matchers;
using System.Runtime.Serialization;
using System.Collections;
using System.Configuration;
using System.Xml;

namespace JackTime2Run
{
    [ServiceContract]
    public class NamePipeSrv
    {
        [OperationContract]
        public List<JackJob> GetAllJobs()
        {
            try
            {
                System.Configuration.ConfigurationManager.GetSection("JackTime2RunJobs");
                JackJob[] jobs = new JackJob[JobHelper.Jobs.Count];
                for (int i = 0; i < JobHelper.Jobs.Count; i++)
                {
                    jobs[i] = new JackJob()
                    {
                        Name = JobHelper.Jobs[i].Name,
                        Cron = JobHelper.Jobs[i].Cron,
                        LogWhen = JobHelper.Jobs[i].LogWhen,
                        JobType = JobHelper.Jobs[i].JobType,
                        SearchPath = JobHelper.Jobs[i].SearchPath,
                        TypeName = JobHelper.Jobs[i].TypeName,
                        SrcCodeFilePath = JobHelper.Jobs[i].SrcCodeFilePath,
                        Method = JobHelper.Jobs[i].Method,
                        Enable = JobHelper.Jobs[i].Enable,
                        LastDate = JobHelper.Jobs[i].LastDate,
                        NextDate = JobHelper.Jobs[i].NextDate,
                        State = JobHelper.Jobs[i].State
                    };
                    jobs[i].Paras = new List<string>();
                    for (int j = 0; j < JobHelper.Jobs[i].Paras.Count; j++)
                    {
                        jobs[i].Paras.Add(JobHelper.Jobs[i].Paras[j]);
                    }
                }
                for (int i = 0; i < jobs.Length; i++)
                {
                    //转化日志类型
                    if (jobs[i].LogWhen == "0")
                    {
                        jobs[i].LogWhen = "一定记录";
                    }
                    else if (jobs[i].LogWhen == "1")
                    {
                        jobs[i].LogWhen = "成功时记录";
                    }
                    else if (jobs[i].LogWhen == "2")
                    {
                        jobs[i].LogWhen = "失败时记录";
                    }
                    //转化任务类型
                    if (jobs[i].JobType == "0")
                    {
                        jobs[i].JobType = "动态库";
                    }
                    else if (jobs[i].JobType == "1")
                    {
                        jobs[i].JobType = "单个cs文件";
                    }
                    else if (jobs[i].JobType == "2")
                    {
                        jobs[i].JobType = "exe程序";
                    }
                    //转化使用标志
                    if (jobs[i].Enable == "0")
                    {
                        jobs[i].Enable = "禁用";
                    }
                    else if (jobs[i].Enable == "1")
                    {
                        jobs[i].Enable = "可用";
                    }

                    //获取上一次和下一次执行时间以及任务状态
                    JobKey key = new JobKey(jobs[i].Name, jobs[i].Name);
                    IJobDetail detail = JobHelper.sche.GetJobDetail(key);
                    IList<ITrigger> triggers = JobHelper.sche.GetTriggersOfJob(key);
                    if (triggers.Count > 0)
                    {
                        ICronTrigger croTri = triggers[0] as ICronTrigger;
                        DateTimeOffset? dtoff = croTri.GetPreviousFireTimeUtc();
                        if (dtoff != null && dtoff.ToString() != "")
                        {
                            jobs[i].LastDate = TimeZone.CurrentTimeZone.ToLocalTime(Convert.ToDateTime(dtoff.ToString())).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                        {
                            jobs[i].LastDate = "";
                        }
                        dtoff = croTri.GetNextFireTimeUtc();
                        if (dtoff != null && dtoff.ToString() != "")
                        {
                            jobs[i].NextDate = TimeZone.CurrentTimeZone.ToLocalTime(Convert.ToDateTime(dtoff.ToString())).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                        {
                            jobs[i].NextDate = "";
                        }
                        TriggerState state = JobHelper.sche.GetTriggerState(croTri.Key);

                        if (state == TriggerState.Complete)
                        {
                            jobs[i].State = "完成";
                        }
                        else if (state == TriggerState.Error)
                        {
                            jobs[i].State = "出错";
                        }
                        else if (state == TriggerState.None)
                        {
                            jobs[i].State = "无";
                        }
                        else if (state == TriggerState.Normal)
                        {
                            jobs[i].State = "正常";
                        }
                        else if (state == TriggerState.Paused)
                        {
                            jobs[i].State = "暂停";
                        }
                        else if (state == TriggerState.Blocked)
                        {
                            jobs[i].State = "锁定";
                        }
                    }
                }
                return jobs.ToList();
            }
            catch (Exception ex)
            {
                Time2RunSrv.WriteLog("管理端:【Manager】拉去任务失败:" + ex.ToString());
                return null;
            }
        }

        [OperationContract]
        public bool EnableJob(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    Time2RunSrv.WriteLog("管理端:【Manager】启用任务[" + name + "]失败:" + "未发现有效的任务名称！");
                    return false;
                }
                lock (typeof(Time2RunSrv))
                {
                    Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    ConfigurationSection sec = conf.GetSection("JackTime2RunJobs");
                    string str = sec.SectionInformation.GetRawXml();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(str);
                    List<XmlElement> jobs = doc.ChildNodes.OfType<XmlElement>().FirstOrDefault<XmlElement>().ChildNodes.OfType<XmlElement>().Where<XmlElement>((i) => i.Name == "job").ToList<XmlElement>();
                    for (int i = 0; i < jobs.Count; i++)
                    {
                        if (jobs[i].Attributes["name"].Value == name)
                        {
                            jobs[i].SetAttribute("enable", "1");
                            break;
                        }
                    }
                    sec.SectionInformation.SetRawXml(doc.InnerXml);
                    conf.Save(ConfigurationSaveMode.Modified);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Time2RunSrv.WriteLog("管理端:【Manager】启用任务[" + name + "]失败:" + ex.ToString());
                return false;
            }
        }

        [OperationContract]
        public bool DisableJob(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    Time2RunSrv.WriteLog("管理端:【Manager】禁用任务[" + name + "]失败:" + "未发现有效的任务名称！");
                    return false;
                }
                lock (typeof(Time2RunSrv))
                {
                    Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    ConfigurationSection sec = conf.GetSection("JackTime2RunJobs");
                    string str = sec.SectionInformation.GetRawXml();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(str);
                    List<XmlElement> jobs = doc.ChildNodes.OfType<XmlElement>().FirstOrDefault<XmlElement>().ChildNodes.OfType<XmlElement>().Where<XmlElement>((i) => i.Name == "job").ToList<XmlElement>();
                    for (int i = 0; i < jobs.Count; i++)
                    {
                        if (jobs[i].Attributes["name"].Value == name)
                        {
                            jobs[i].SetAttribute("enable", "0");
                            break;
                        }
                    }
                    sec.SectionInformation.SetRawXml(doc.InnerXml);
                    conf.Save(ConfigurationSaveMode.Modified);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Time2RunSrv.WriteLog("管理端:【Manager】禁用任务[" + name + "]失败:" + ex.ToString());
                return false;
            }
        }

        [OperationContract]
        public bool RemoveJob(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    Time2RunSrv.WriteLog("管理端:【Manager】移除任务[" + name + "]失败:" + "未发现有效的任务名称！");
                    return false;
                }
                lock (typeof(Time2RunSrv))
                {
                    Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    ConfigurationSection sec = conf.GetSection("JackTime2RunJobs");
                    string str = sec.SectionInformation.GetRawXml();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(str);
                    List<XmlElement> jobs = doc.ChildNodes.OfType<XmlElement>().FirstOrDefault<XmlElement>().ChildNodes.OfType<XmlElement>().Where<XmlElement>((i) => i.Name == "job").ToList<XmlElement>();
                    for (int i = 0; i < jobs.Count; i++)
                    {
                        if (jobs[i].Attributes["name"].Value == name)
                        {
                            jobs[i].ParentNode.RemoveChild(jobs[i]);
                            break;
                        }
                    }
                    sec.SectionInformation.SetRawXml(doc.InnerXml);
                    conf.Save(ConfigurationSaveMode.Modified);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Time2RunSrv.WriteLog("管理端:【Manager】移除任务[" + name + "]失败:" + ex.ToString());
                return false;
            }
        }

        [OperationContract]
        public bool AddJob(JackJob job)
        {
            try
            {
                if (job == null || string.IsNullOrWhiteSpace(job.Name))
                {
                    Time2RunSrv.WriteLog("管理端:【Manager】更新任务[" + job.Name + "]失败:" + "未发现有效的任务名称！");
                    return false;
                }
                lock (typeof(Time2RunSrv))
                {
                    Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    ConfigurationSection sec = conf.GetSection("JackTime2RunJobs");
                    string str = sec.SectionInformation.GetRawXml();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(str);
                    XmlElement ele = GeneJobEle(job, doc);
                    XmlNode jobs = doc.ChildNodes.OfType<XmlElement>().FirstOrDefault<XmlElement>();
                    jobs.AppendChild(ele);
                    sec.SectionInformation.SetRawXml(doc.InnerXml);
                    conf.Save(ConfigurationSaveMode.Modified);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Time2RunSrv.WriteLog("管理端:【Manager】添加任务[" + job.Name + "]失败:" + ex.ToString());
                return false;
            }
        }

        [OperationContract]
        public bool UpdateJob(JackJob job)
        {
            try
            {
                if (job == null || string.IsNullOrWhiteSpace(job.Name))
                {
                    Time2RunSrv.WriteLog("管理端:【Manager】更新任务[" + job.Name + "]失败:" + "未发现有效的任务名称！");
                    return false;
                }

                lock (typeof(Time2RunSrv))
                {
                    Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    ConfigurationSection sec = conf.GetSection("JackTime2RunJobs");
                    string str = sec.SectionInformation.GetRawXml();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(str);
                    XmlElement ele = GeneJobEle(job, doc);
                    List<XmlElement> jobs = doc.ChildNodes.OfType<XmlElement>().FirstOrDefault<XmlElement>().ChildNodes.OfType<XmlElement>().Where<XmlElement>((i) => i.Name == "job").ToList<XmlElement>();
                    for (int i = 0; i < jobs.Count; i++)
                    {
                        if (jobs[i].Attributes["name"].Value == job.Name)
                        {
                            XmlNode p = jobs[i].ParentNode;
                            p.ReplaceChild(ele, jobs[i]);
                            break;
                        }
                    }
                    sec.SectionInformation.SetRawXml(doc.InnerXml);
                    conf.Save(ConfigurationSaveMode.Modified);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Time2RunSrv.WriteLog("管理端:【Manager】更新任务[" + job.Name + "]失败:" + ex.ToString());
                return false;
            }
        }

        [OperationContract]
        public bool TriJob(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    Time2RunSrv.WriteLog("管理端:【Manager】临时执行任务[" + name + "]失败:" + "未发现有效的任务名称！");
                    return false;
                }
                JackJob job = JobHelper.Jobs.FirstOrDefault<JackJob>(i =>
                {
                    return i.Name == name;
                });
                if (job == null)
                {
                    Time2RunSrv.WriteLog("管理端:【Manager】临时执行任务[" + name + "]失败:" + "未发现有效的任务名称！");
                    return false;
                }
                new FullJob().ExeJob(job);
                return true;
            }
            catch (Exception ex)
            {
                Time2RunSrv.WriteLog("管理端:【Manager】移除任务[" + name + "]失败:" + ex.ToString());
                return false;
            }
        }

        [OperationContract]
        public bool TestConn()
        {
            return true;
        }

        private XmlElement GeneJobEle(JackJob job, XmlDocument doc)
        {
            XmlElement ele = doc.CreateElement("job");
            ele.Attributes.Append(CreateAttr(doc, "name", job.Name));
            ele.Attributes.Append(CreateAttr(doc, "cron", job.Cron));
            ele.Attributes.Append(CreateAttr(doc, "logwhen", job.LogWhen));
            ele.Attributes.Append(CreateAttr(doc, "jobtype", job.JobType));
            ele.Attributes.Append(CreateAttr(doc, "searchpath", job.SearchPath));
            ele.Attributes.Append(CreateAttr(doc, "srccodepath", job.SrcCodeFilePath));
            ele.Attributes.Append(CreateAttr(doc, "typename", job.TypeName));
            ele.Attributes.Append(CreateAttr(doc, "method", job.Method));
            ele.Attributes.Append(CreateAttr(doc, "enable", job.Enable));
            ele.Attributes.Append(CreateAttr(doc, "name", job.Name));
            if (job.Paras == null || job.Paras.Count == 0)
            { }
            else
            {
                for (int i = 0; i < job.Paras.Count; i++)
                {
                    XmlElement ele2 = doc.CreateElement("para");
                    XmlAttribute attr2 = doc.CreateAttribute("value");
                    attr2.Value = job.Paras[i];
                    ele2.Attributes.Append(attr2);
                    ele.AppendChild(ele2);
                }
            }
            return ele;
        }

        private XmlAttribute CreateAttr(XmlDocument doc, string name, string value)
        {
            XmlAttribute attr = doc.CreateAttribute(name);
            attr.Value = value;
            return attr;
        }
    }
}
