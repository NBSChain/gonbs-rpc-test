using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;

using Demo;


/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: DemoServer
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/12 21:24:54													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace DemoServer
{


    public class DemoServerImpl : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            Console.WriteLine("Client request parameter: " + request.Name);
            return Task.FromResult(new HelloReply { Message = "你好 " + request.Name });
        }

        public override Task<PeerInof> GetCurrentAcc(HelloRequest request, ServerCallContext context)
        {
            Console.WriteLine("Client request parameter: " + request.Name);
            return Task.FromResult(new PeerInof { Nickname = request.Name ,AvatarName = "nbs.logo"});
        }
    }
}
