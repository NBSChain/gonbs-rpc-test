using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfGRPCChatDemo.ViewModel;

namespace WpfGRPCChatDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ChatViewModel();
        }

        private void BodyInput_Loaded(object sender, RoutedEventArgs e)
        {
            SendInput.Focus();
        }

        private void BodyInput_Keydown(object sender, KeyEventArgs e)
        {
            string content = SendInput.Text;
            if (e.Key == Key.Return && !String.IsNullOrEmpty(content))
            {
                (DataContext as ChatViewModel).SendCommand.Execute(content);
                SendInput.Text = "";
            }
        }
    }
}
