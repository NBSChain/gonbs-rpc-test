using System;
using Pb;
using Grpc.Core;
using UrusTools.Config;


/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: grpc2slib.BBL
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/14 16:14:52													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace grpc2slib.BBL
{
    
    public class GrpcBaseHelper
    {

        private string Host;
        private int Port;

        private static GrpcBaseHelper _helper;

        private Channel _channel;

        public static GrpcBaseHelper Instance()
        {
            if (_helper == null) _helper = NestedHepler.Instace;
            return _helper;
        }

        private GrpcBaseHelper()
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

        public Channel Channel
        {
            get
            {
                if (_channel == null) _channel = new Channel(Host, Port, ChannelCredentials.Insecure);
                return _channel;
            }
        }

        private Channel NewChannel(string host,int port)
        {
            return new Channel(host, port, ChannelCredentials.Insecure);
        }

        public Channel NewChannel()
        {
            return NewChannel(Host, Port);
        }
        /// <summary>
        /// 程序退出时调用
        /// </summary>
        public void CloseChannel()
        {
            if (_channel != null)
            {
                try
                {
                    _channel.ShutdownAsync().Wait();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        class NestedHepler
        {
            NestedHepler() { }

            internal static readonly GrpcBaseHelper Instace = new GrpcBaseHelper();
        }

        public void ShutdownAsync(Channel channel)
        {
            if(channel != null)
            {
                try
                {
                    channel.ShutdownAsync().Wait();
                }
                catch(RpcException rpcEx)
                {
                    Console.WriteLine(rpcEx.Message);
                }
            }
        }
    }
}
