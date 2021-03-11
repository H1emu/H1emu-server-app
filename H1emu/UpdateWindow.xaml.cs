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
using System.Windows.Shapes;

namespace H1emu
{
    /// <summary>
    /// Logique d'interaction pour UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();
        }
        public void DownloadUpdate(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/H1emu/H1emu-server-app/releases/latest/download/H1emu.exe";

            System.Diagnostics.Process.Start(url);
        }
    }
}
