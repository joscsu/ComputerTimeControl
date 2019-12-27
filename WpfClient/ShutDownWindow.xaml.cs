using Google.Protobuf;
using Shared;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for ShutDownWindow.xaml
    /// </summary>
    public partial class ShutDownWindow : Window
    {
        public ShutDownWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var pipeClient = new NamedPipeClientStream(".", "shutdowninfopipe",
                        PipeDirection.In, PipeOptions.None, TokenImpersonationLevel.Impersonation))
            {
                pipeClient.Connect();
                using (var googleStream = new CodedInputStream(pipeClient))
                {
                    var info = new ShutDownInfo();
                    info.MergeFrom(googleStream);
                    MessageBox.Show(info.Duration.ToTimeSpan().ToString());
                }
            }
        }
    }
}
