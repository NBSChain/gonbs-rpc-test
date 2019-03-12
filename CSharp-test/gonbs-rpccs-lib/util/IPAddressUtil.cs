using System;
using System.Diagnostics;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: gonbs_rpccs_lib.util
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/12 21:08:02													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace grpc2slib.util
{
    class IPAddressUtil
    {
        const bool defaultLogged = false;
        const string conndomain = "www.baidu.com";

        public static string GetLocalIP()
        {
            string result = RunApp("route", "print", true);
            System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(result, @"0.0.0.0\s+0.0.0.0\s+(\d+.\d+.\d+.\d+)\s+(\d+.\d+.\d+.\d+)");

            if (match.Success)
            {
                return match.Groups[2].Value;
            }
            else
            {
                try
                {
                    System.Net.Sockets.TcpClient cli = new System.Net.Sockets.TcpClient();
                    cli.Connect(conndomain, 80);
                    string ip = ((System.Net.IPEndPoint)cli.Client.LocalEndPoint).Address.ToString();
                    cli.Close();
                    return ip;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static string GetPrimaryDNS()
        {
            string result = RunApp("nslookup", "", true);

            System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(result, @"\d+\.\d+\.\d+\.\d+");
            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                return null;
            }
        }

        public static string RunApp(string filename, string arg, bool logged)
        {
            try
            {
                if (logged)
                {
                    Trace.WriteLine(filename + " " + arg);
                }

                Process proc = new Process();
                proc.StartInfo.FileName = filename;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = arg;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();

                using (System.IO.StreamReader sr = new System.IO.StreamReader(proc.StandardOutput.BaseStream, Encoding.Default))
                {
                    System.Threading.Thread.Sleep(100);
                    if (!proc.HasExited)
                    {
                        proc.Kill();
                    }
                    string txt = sr.ReadToEnd();
                    sr.Close();

                    if (logged)
                        Trace.WriteLine(txt);
                    return txt;
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return ex.Message;
            }
        }
    }
 
}
