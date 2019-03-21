using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Prism.Commands;
using Prism.Mvvm;
using grpc2slib.BBL;
using Pb;



/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: RecievedDemoCli.ViewModel
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/18 15:57:23													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace RecievedDemoCli.ViewModel
{
    public class ChatViewModel : BindableBase
    {
        private readonly ChatGRPCServiceClient serviceClient = new ChatGRPCServiceClient();
        private ObservableCollection<string> History = new ObservableCollection<string>();
        private readonly object lock_recordObj = new object();

        public ChatViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(History, lock_recordObj);
            SendCommand = new DelegateCommand<string>(SendMsg);

        }

        public DelegateCommand<string> SendCommand { get; }


        public void SendMsg(string content)
        {
            try
            {
                var response = serviceClient.SendMsg(new PublishRequest { Topics = "NBSWorld", Message = content });
                Console.WriteLine(response.Result);
                Console.WriteLine("Success.");
            }
            catch
            {
                Console.WriteLine("Failure.");
            }

        }
    }
}
