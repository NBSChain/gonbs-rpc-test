using Grpc.Core;
using Pb;
using System;
using UrusTools.Config;
using grpc2slib;

/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: grpc2slib.BBL
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/13 15:01:49													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace grpc2slib.BBL
{
    
    public class BaseRPCService
    {
        const bool openConsole = true;
        //private 
        public BaseRPCService(string host,int port)
        {
            Host = String.IsNullOrEmpty(host) ? "127.0.0.1" : host;
            Port = (port <= 0 || port > 65535) ? 10001 : port;
        }

        public BaseRPCService()
        {
            GRPCConfSection gRPCConf = 
                ConfigManager.Instance.GetConfigSection<GRPCConfSection>(SectionType.gRPCServer);
            string h = "127.0.0.1";
            int p = 10001;
            if (gRPCConf != null)
            {
                h = gRPCConf.Host;
                p = gRPCConf.Port;
            }
            Host = h;
            Port = p;
        }

        private string Host
        {
            get;set;
        }

        private int Port { get; set; }


        public string GetVersion()
        {
            try
            {
                Channel channel = newChannel();
                Printf("version");
                var cli = new VersionTask.VersionTaskClient(channel);
                var version = cli.SystemVersion(new VersionRequest { CmdName = "version" });
                channel.ShutdownAsync().Wait();
                Printf();
                return version.Result;
            }
            catch(Exception e)
            {
                PrintError(e);
                throw new RemoteRPCUnabledException();
            }
        }

        public void CreateAccountOffline()
        {
            try
            {
                Channel channel = newChannel();
                Printf("Account");
                var cli = new AccountTask.AccountTaskClient(channel);
                var acc = cli.CreateAccount(new CreateAccountRequest { Password="123456"});
            }
            catch(RpcException re)
            {
                Console.WriteLine("" + re.Message);
                Console.WriteLine("" + re.StatusCode);
            }

        } 
        /// <summary>
        /// 发送群聊消息
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool SendText2World(string content)
        {
            if (String.IsNullOrEmpty(content)) return false;
            try
            {
                Channel channel = newChannel();
                Printf("Pubsub to World >>>"+content);
                var cli = new PubSubTask.PubSubTaskClient(channel);
                var acc = cli.Publish(new PublishRequest {
                    Topics = NBSTopic.NBSWorld.ToString(),
                    Message = content
                });
                channel.ShutdownAsync().Wait();
                Printf();
                return true;
            }
            catch (RpcException e)
            {
                PrintError(e);
                return false;
            }
            
        }

        public string GetAccount()
        {
            string cid;
            try
            {
                Channel channel = newChannel();
                Printf("Account");
                var cli = new AccountTask.AccountTaskClient(channel);
                var acc = cli.Account(new AccountRequest { });
                channel.ShutdownAsync().Wait();
                Printf();
                cid =  acc.Account;
            }
            catch (RpcException e)
            {
                PrintError(e);
                throw e;
            }

            if (cid == null || cid.Length == 0) throw new RpcResultException();
            return cid;
        }

        private Channel newChannel()
        {
            try
            {
                Channel channel = new Channel(Host, Port, ChannelCredentials.Insecure);
                return channel;
            }
            catch
            {
                throw;
            }           
        }

        private void Printf(string suffix)
        {
            if (openConsole)
            {
                Console.WriteLine("gRPC call " + suffix + ":");
                Console.WriteLine("------------------------->>");
            }
        }

        private void Printf()
        {
            if (openConsole)
            {
                Console.WriteLine("gRPC Callback at:{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine("<<-------------------------");
            }
        }

        private void PrintError(Exception e)
        {
            if (openConsole)
            {
                Console.WriteLine("gRPC Callback at:{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine(e.Message);
                Console.WriteLine("<<-------------------------");
            }
        }
    }
}
