using Quartz;
using Quartz.Impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JackTime2Run
{
    [DataContract]
    public class JackJob
    {
        [DataMember]
        public string Name { set; get; }

        [DataMember]
        public string Cron { set; get; }

        [DataMember]
        public string LogWhen { set; get; }

        [DataMember]
        public string JobType { set; get; }

        [DataMember]
        public string SearchPath { set; get; }

        [DataMember]
        public string AppConfig { set; get; }

        [DataMember]
        public string TypeName { set; get; }

        [DataMember]
        public string SrcCodeFilePath { set; get; }

        [DataMember]
        public string Method { set; get; }

        [DataMember]
        public string Enable { set; get; }

        [DataMember]
        public List<string> Paras = new List<string>();

        [DataMember]
        public string LastDate { set; get; }

        [DataMember]
        public string NextDate { set; get; }

        [DataMember]
        public string State { set; get; }
    }
}
