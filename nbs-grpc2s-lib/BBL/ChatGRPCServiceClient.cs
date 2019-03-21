using Grpc.Core;
using grpc2slib.common;
using Pb;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: grpc2slib.BBL
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/18 14:35:20													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace grpc2slib.BBL
{
    public class ChatGRPCServiceClient
    {
        const string host = "127.0.0.1";
        const int port = 10001;
        private static readonly Channel channel = new Channel(host,port,ChannelCredentials.Insecure);

        private readonly PubSubTask.PubSubTaskClient ps_client = new PubSubTask.PubSubTaskClient(channel);

        public PublishResponse SendMsg(string msg)
        {
            Console.WriteLine("ChatGRPCServiceClient============>" + msg);
            var result = ps_client.Publish(new PublishRequest { Topics =NBSTopic.NBSWorld.ToString(), Message = msg });
            return result;
        }

        public async Task send(string msg)
        {
            await ps_client.PublishAsync(new PublishRequest { Topics = NBSTopic.NBSWorld.ToString(), Message = msg });
        }

        public IObservable<SubscribeResponse> Receiving()
        {
            var call = ps_client.Subscribe(new SubscribeRequest { Topics = NBSTopic.NBSWorld.ToString() });
            Console.WriteLine("aaaaa");

            return call.ResponseStream
                .ToAsyncEnumerable()
                .ToObservable()
                .Finally(()=> {
                    SubscribeResponse response = call.ResponseStream.Current;
                    Console.WriteLine(response.From);
                    call.Dispose();
                });
        }

        public async Task StartRecOne()
        {
            SubscribeRequest request = new SubscribeRequest { Topics = NBSTopic.NBSWorld.ToString() };
            Console.WriteLine(">>>>订阅:" + NBSTopic.NBSWorld.ToString());
            try
            {
                using (var call = ps_client.Subscribe(request))
                {
                    while (await call.ResponseStream.MoveNext(CancellationToken.None))
                    {
                        SubscribeResponse response = call.ResponseStream.Current;
                        Console.WriteLine(">>>>>>>>>>>>>>>>");
                        Console.WriteLine(response.From);
                        Console.WriteLine("[msgType]", response.MsgType);
                        Console.WriteLine("[Msg]=" + response.MsgData.ToStringUtf8());
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message,e.StackTrace);
            }

        }
    }
}
