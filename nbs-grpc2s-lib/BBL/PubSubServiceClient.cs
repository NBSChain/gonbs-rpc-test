using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Pb;
using System.Threading.Tasks;
using System.Threading;

/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: grpc2slib.BBL
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/21 22:15:22													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace grpc2slib.BBL
{
    public class PubSubServiceClient<T>
    {
        readonly PubSubTask.PubSubTaskClient pubsubClient;
        private bool DEBUG = false;
        private ObservableCollection<T> collection;
        private T Self;

        public PubSubServiceClient(
            PubSubTask.PubSubTaskClient client, 
            ObservableCollection<T> collection,
            T self,
            bool debug)
        {
            this.pubsubClient = client;
            this.collection = collection;
            this.Self = self;
            DEBUG = debug;
        }

        public bool SendMessage(NBSTopic topic,string msg,Func<T,string,bool,T> func)
        {
            if (String.IsNullOrEmpty(msg)) return false;
            try
            {
                PublishRequest request = new PublishRequest { Topics = topic.ToString(), Message = msg };
                var back = pubsubClient.Publish(request);
                Logged(back.Result);
                T t = func(Self,msg,true);
                collection.Add(t);
                return true;
            }
            catch(Exception e)
            {
                Logged(e, "Send [" + msg + "] failure.");
                T t = func(Self,msg, false);
                collection.Add(t);
            }
            return false;
        }


        public async Task StartRecvListener(NBSTopic topic,Func<SubscribeResponse,T> func)
        {            
            SubscribeRequest request = new SubscribeRequest { Topics = topic.ToString() };
            Logged("Topic ["+topic.ToString()+"] starting ....");

            try {
                using(var call = pubsubClient.Subscribe(request))
                {
                    while(await call.ResponseStream.MoveNext(CancellationToken.None))
                    {
                        SubscribeResponse response = call.ResponseStream.Current;
                        Console.WriteLine(">>>Recv Message:" + response.From);
                        T t = func(response);
                        collection.Add(t);

                    }
                    
                }
            } catch(Exception e){
                Logged(e, "subscribe failure.");
            }
            
        }


        private void Logged(string msg)
        {
            if (DEBUG) Console.WriteLine(msg);
        }

        private void Logged(Exception exception, string msg)
        {
            if (DEBUG) Console.WriteLine(msg, exception.StackTrace);
        }
    }
}
