using System;
using System.Text;
using Pb;
using System.IO;
using System.Text.RegularExpressions;
using UrusTools.Utils;


/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: grpc2slib.BBL
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/26 12:50:55													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace grpc2slib.BBL
{
    public class GossipServiceClient
    {
        private readonly string logPathName;
        private readonly string logPath;
        private GrpcBaseHelper helper;

        readonly GossipTask.GossipTaskClient gossipClient;

        public GossipServiceClient(GrpcBaseHelper h,string logRootPath,string logName)
        {
            this.gossipClient = new GossipTask.GossipTaskClient(h.NewChannel());
            this.helper = h;
            this.logPath = logRootPath;
            if (String.IsNullOrEmpty(logName))
            {
                this.logPathName = logRootPath + System.IO.Path.DirectorySeparatorChar + "gossip.log";
            }
            else
            {
                this.logPathName = logRootPath + System.IO.Path.DirectorySeparatorChar + logName;
            } 
        }

        public DebugResult GossipDebug(DebugCmd cmd)
        {
            return gossipClient.debug(cmd);
        }

        public string FormatResult(DebugResult result)
        {
            var now = DateTime.Now;
            StringBuilder builder = new StringBuilder();
            string ipv4 = LocalInfoUtil.GetLocalIPv4();
            string pcName = LocalInfoUtil.GetLocalUsername();
            builder.Append("\r\n");
            builder.Append("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n");
            builder.Append("┃************************* Gossip Debug Info *************************┃\r\n");
            builder.AppendFormat("┃ Operator	:{0}	\r\n", pcName);
            builder.AppendFormat("┃ LocalIP	:{0}	\r\n", ipv4);
            builder.Append("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n");
            //builder.AppendFormat("{0} :\r\n", result.Result);
            try
            {
                viewInfos infos = result.InputViews;
                int len = result.InputViews.Views.Count;
                builder.AppendFormat("#####>>>{0}:{1}>>>Begin:\r\n", "IN", result.InputViews.Views.Count);
                string pattern = @"\|";
                
                
                for (int i = 0; i < len; i++)
                {
                    string s = result.InputViews.Views[i];
                    string[] vs = s.Split('|');
                    StringBuilder isb = new StringBuilder();
                    if (vs.Length > 0)
                    {
                        for(int m=0;m<vs.Length;m++)
                        {
                            if (m > 1)
                            {
                                isb.Append("|");
                                isb.Append(vs[m]);
                                isb.Append("|");
                            }
                            else
                            {
                                isb.Append(vs[m]);
                            }
                            isb.Append("\r\n");
                        }
                        builder.Append(vs.ToString());
                    }
                    else
                    {
                        builder.Append(s);
                    }

                    builder.AppendLine();
                }
                viewInfos outviews = result.OutputViews;
                builder.AppendFormat("#####>>>{0}:{1}>>>Begin:\r\n", "OUT", outviews.Views.Count);
                for (int j = 0; j < outviews.Views.Count; j++)
                {
                    string s = outviews.Views[j];
                    string[] vs = s.Split('|');
                    StringBuilder isb = new StringBuilder();
                    if (vs.Length > 0)
                    {
                        for (int m = 0; m < vs.Length; m++)
                        {
                            if (m > 1)
                            {
                                isb.Append("|");
                                isb.Append(vs[m]);
                                isb.Append("|");
                            }
                            else
                            {
                                isb.Append(vs[m]);
                            }
                            isb.Append("\r\n");
                        }
                        builder.Append(vs.ToString());
                    }
                    else
                    {
                        builder.Append(s);
                    }
                    builder.AppendLine();
                }
                builder.AppendFormat("############ {0} ###########\r\n", now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception e)
            {
                builder.AppendFormat("Error:{0} \r\n {1}", now.ToString("yyyy-MM-dd HH:mm:ss"), e.Message);
            }

            return builder.ToString();
        }

        public void WriteLog(DebugResult result)
        {   
            try {
                string logContent = FormatResult(result);
                var logBinaray = Encoding.Default.GetBytes(logContent);
                using (FileStream logFile = new FileStream(logPathName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    logFile.Seek(0, SeekOrigin.End);
                    logFile.Write(logBinaray, 0, logBinaray.Length);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }
}
