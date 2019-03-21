using System;


/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: grpc2slib.common
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/13 15:42:57													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace grpc2slib
{
    public class RemoteRPCUnabledException : Exception
    {
        const int errorCode = 404;

        public int Error
        {
            get;set;
        }

        public RemoteRPCUnabledException() : base("RPC cant't connected."){ Error = errorCode; }

        public RemoteRPCUnabledException(string message) : base(message) { Error = errorCode; }

        public RemoteRPCUnabledException(int error,string message) : base(message)
        {
            Error = error;
        }
    }
}
