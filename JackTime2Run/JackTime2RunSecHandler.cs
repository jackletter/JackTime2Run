using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace JackTime2Run
{
    public class JackTime2RunSecHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            List<JackJob> jobs = new List<JackJob>();
            XmlNodeList list = section.SelectNodes("job");
            if (list != null)
            {
                foreach (XmlNode node in list)
                {
                    JackJob job = new JackJob();
                    XmlAttribute attr = node.Attributes["name"];
                    if (attr != null)
                    {
                        job.Name = attr.Value;
                    }
                    attr = node.Attributes["cron"];
                    if (attr != null)
                    {
                        job.Cron = attr.Value;
                    }
                    attr = node.Attributes["logwhen"];
                    if (attr != null)
                    {
                        job.LogWhen = attr.Value;
                    }
                    attr = node.Attributes["jobtype"];
                    if (attr != null)
                    {
                        job.JobType = attr.Value;
                    }
                    attr = node.Attributes["searchpath"];
                    if (attr != null)
                    {
                        job.SearchPath = attr.Value;
                    }
                    attr = node.Attributes["typename"];
                    if (attr != null)
                    {
                        job.TypeName = attr.Value;
                    }
                    attr = node.Attributes["srccodepath"];
                    if (attr != null)
                    {
                        job.SrcCodeFilePath = attr.Value;
                    }
                    attr = node.Attributes["method"];
                    if (attr != null)
                    {
                        job.Method = attr.Value;
                    }
                    attr = node.Attributes["enable"];
                    if (attr != null)
                    {
                        job.Enable = attr.Value;
                    }
                    if (node.HasChildNodes)
                    {
                        node.ChildNodes.OfType<XmlElement>().ToList<XmlElement>().ForEach(i =>
                        {
                            if (i.Name == "para")
                            {
                                XmlAttribute attr_tmp = i.Attributes["value"];
                                if (attr_tmp != null)
                                {
                                    job.Paras.Add(attr_tmp.Value);
                                }
                            }
                        });
                    }
                    jobs.Add(job);
                }
            }
            JobHelper.Jobs = jobs;
            return null;
        }
    }
}
