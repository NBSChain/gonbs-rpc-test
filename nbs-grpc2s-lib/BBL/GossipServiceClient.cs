using Grpc.Core;
using System;
using System.Threading;
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

        public string RestartGossip() {
            string res = "重启成功";
            Channel channel = helper.NewChannel();
            try
            {
                
                GossipTask.GossipTaskClient gClient = new GossipTask.GossipTaskClient(channel);
                DateTime opTime = DateTime.Now;
                string name = LocalInfoUtil.GetLocalUsername();
                StringBuilder sb = new StringBuilder();
                string content = "-----{0}-----{1} at {2} gossip restarting ... ";
                WriteLog(String.Format(content,
                    opTime.ToLongTimeString(),
                    name,
                    opTime.ToString("yyyy-MM-dd HH:mm:ss")),
                    "restart Gossip");
                gClient.stopService(new StopRequest { });
                
                Thread.Sleep(500);
                gClient.startServiceAsync(new StartRequest { });

            }
            catch(Exception e)
            {
                WriteLog(String.Format("重启Gossip发生错误，请重试！\r\n 可能原因:{0}", e.Message), "");
                return String.Format("重启Gossip发生错误，请重试！\r\n 可能原因:{0}", e.Message);
            }
            finally
            {
                channel.ShutdownAsync().Wait();
            }
            WriteLog(String.Format("############ {0} ############\r\n", res), "");
            return res;
        }

        public string FormatResult(DebugResult result)
        {
            var now = DateTime.Now;
            StringBuilder builder = new StringBuilder();
            string ipv4 = LocalInfoUtil.GetLocalIPv4();
            string pcName = LocalInfoUtil.GetLocalUsername();
            builder.Append("\r\n");
            builder.Append("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n");
            builder.Append("┃******************* Gossip Debug Info *********************\r\n");
            builder.AppendFormat("┃ Operator	:{0}	\r\n", pcName);
            builder.AppendFormat("┃ LocalIP	:{0}	\r\n", ipv4);
            builder.Append("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n");
            //builder.AppendFormat("{0} :\r\n", result.Result);
            try
            {
                viewInfos infos = result.InputViews;
                int len = result.InputViews.Views.Count;
                builder.AppendFormat("#####>>>{0}:{1}>>>Begin:\r\n", "IN", result.InputViews.Views.Count);

                for (int i = 0; i < len; i++)
                {
                    string s = result.InputViews.Views[i];
                    builder.Append(s);
                    builder.AppendLine();
                }
                viewInfos outviews = result.OutputViews;
                builder.AppendFormat("#####>>>{0}:{1}>>>Begin:\r\n", "OUT", outviews.Views.Count);
                for (int j = 0; j < outviews.Views.Count; j++)
                {
                    string s = outviews.Views[j];                    
                    builder.Append(s);
                    builder.AppendLine();
                }
                builder.AppendFormat("############## {0} #############\r\n", now.ToString("yyyy-MM-dd HH:mm:ss"));
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

        public void WriteLog(string content,string title)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("\r\n");
            if (!String.IsNullOrEmpty(title))
            {
                builder.Append(buildHeader(title));
            }
            builder.Append(content);
            try
            {
                var logBinaray = Encoding.Default.GetBytes(builder.ToString());
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

        private string buildHeader(string arg)
        {
            string header = "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                "┃******************* {0} *********************\r\n" +
                "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n";
            return String.Format(header,arg);
        }
    }
}
