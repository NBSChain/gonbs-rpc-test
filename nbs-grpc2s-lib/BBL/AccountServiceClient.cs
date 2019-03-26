
using Pb;
using Grpc.Core;
using System;

/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: grpc2slib.BBL
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/21 15:21:42													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace grpc2slib.BBL
{
    public class AccountServiceClient
    {
        readonly VersionTask.VersionTaskClient verTaskClient;
        readonly AccountTask.AccountTaskClient accTaskClient;
        private bool DEBUG = false;

        public AccountServiceClient(
            VersionTask.VersionTaskClient verClient,
            AccountTask.AccountTaskClient accClient)
        {
            this.verTaskClient = verClient;
            this.accTaskClient = accClient;
        }

        public AccountServiceClient(
            VersionTask.VersionTaskClient verClient,
            AccountTask.AccountTaskClient accClient,
            bool debug)
        {
            this.verTaskClient = verClient;
            this.accTaskClient = accClient;
            this.DEBUG = debug;
        }

        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <returns></returns>
        public string GetCurrentVersion()
        {
            VersionResponse response;
            try
            {
                response = verTaskClient.SystemVersion(new VersionRequest { CmdName = "version"});
                return response.Result;
            }catch(RpcException re)
            {
                Logged(re, "version RPC remote failure.");
                throw re;
            }
            catch(Exception e)
            {
                Logged(e, "unknow");
                throw e;
            }   
        }
        /// <summary>
        /// 获取Accout HID
        /// </summary>
        /// <returns></returns>
        public string GetAccountHID()
        {
            try
            {
                return this.accTaskClient.Account(new AccountRequest { }).Account;
            }catch(RpcException re)
            {
                Logged(re, "Get Account RPC remote failure.");
                throw re;
            }
            catch(Exception e)
            {
                Logged(e, "unknow");
                throw e;
            }
        }

        
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="pw"></param>
        /// <returns></returns>
        public bool CreateAccount(string pw)
        {
            try
            {
                CreateAccountRequest request = new CreateAccountRequest { Password = pw };
                CreateAccountResponse response = this.accTaskClient.CreateAccount(request);
                Logged(response.Message);
                return true;
            }
            catch (RpcException re)
            {
                Logged(re, "create Account RPC remote failure.");
                throw re;
            }
            catch (Exception e)
            {
                Logged(e, "create Account error: unknow");
                throw e;
            }
        } 

        private void Logged(string msg)
        {
            if(DEBUG)Console.WriteLine(msg);
        }

        private void Logged(Exception exception, string msg)
        {
            if(DEBUG)Console.WriteLine(msg, exception.StackTrace);
        }
    }
}
