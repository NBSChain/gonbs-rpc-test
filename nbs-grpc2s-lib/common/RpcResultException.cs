using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: grpc2slib
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/13 18:34:05													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace grpc2slib
{
    public class RpcResultException : Exception
    {

        const int errorCode = 999 ;
        public int Error
        {
            get; set;
        }
        public RpcResultException() : base("result Incorrect") { Error = errorCode; }

        public RpcResultException(int code,string error) : base(error) { Error = code; }

        public RpcResultException(int code, string error,Exception innerEx) : base(error, innerEx) { Error = code; }
    }
}
