using System;
using Prism.Mvvm;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Data;

using System.Text;
using System.Threading.Tasks;
using grpc2slib.BBL;
using grpc2slib;
using Pb;


/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: WpfGRPCChatDemo.ViewModel
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/18 16:44:33													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace WpfGRPCChatDemo.ViewModel
{
    public class ChatViewModel : BindableBase
    {
        private ObservableCollection<string> _records = new ObservableCollection<string>();
        private readonly object lockObj = new object();
        private readonly ChatGRPCServiceClient client = new ChatGRPCServiceClient();

        public ChatViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(RecordList, lockObj);
            SendCommand = new DelegateCommand<string>(SendMessage);
         
            Console.WriteLine("=>>>Start recv。。。。");
            StartRecieving();
            Console.WriteLine("=>>>Start recv complete ....");
        }

        public ObservableCollection<string> RecordList
        {
            get { return _records; }
        }

        private void initail()
        {
            _records.Add("initial");
        }

        private string _name = "CLient";
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public DelegateCommand<string> SendCommand { get; }

        private void SendMessage(string content)
        {
            Console.WriteLine(content);
            try
            {
                PublishResponse response = client.SendMsg(content);
                Console.WriteLine(response.Result);
                RecordList.Add("["+content+" ] send ."+response.Result);
            }
            catch
            {
                Console.WriteLine("Error");
            }
           
        }

        private void StartRecieving()
        {
            client.StartRecOne().ConfigureAwait(true);
        }


  
    }
}
