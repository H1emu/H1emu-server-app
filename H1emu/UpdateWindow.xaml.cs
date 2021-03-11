using System.Windows;

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
