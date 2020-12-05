using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace H1Z1_server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string ServerFilesPath = "./H1emuServersFiles/h1z1-server-QuickStart-master";
        private string ServerFilesRepo = "https://github.com/H1emu/h1z1-server-QuickStart/archive/master.zip";

        private void LaunchServer_OnClick(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;

            p.StartInfo = info;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd "+ServerFilesPath);
                    sw.WriteLine("npm start");
                }
            }
        }
        
        private void InstallNodejs_OnClick(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;

            p.StartInfo = info;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd /temp");
                    sw.WriteLine("curl -LJO https://nodejs.org/dist/v12.18.0/node-v12.18.0-x64.msi");
                    sw.WriteLine("node-v12.18.0-x64.msi");
                }
            }
        }

        private void ApplyPatch_OnClick(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;

            p.StartInfo = info;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("curl -LJO -H 'Cache-Control: no-cache' --output dinput8.dll https://h1emu.s3.eu-west-3.amazonaws.com/patch/dinput8.dll?"+ new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl -LJO -H 'Cache-Control: no-cache' --output msvcp140d.dll https://h1emu.s3.eu-west-3.amazonaws.com/patch/msvcp140d.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl -LJO -H 'Cache-Control: no-cache' --output ucrtbased.dll https://h1emu.s3.eu-west-3.amazonaws.com/patch/ucrtbased.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl -LJO -H 'Cache-Control: no-cache' --output vcruntime140_1d.dll https://h1emu.s3.eu-west-3.amazonaws.com/patch/vcruntime140_1d.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl -LJO -H 'Cache-Control: no-cache' --output vcruntime140d.dll https://h1emu.s3.eu-west-3.amazonaws.com/patch/vcruntime140d.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                }
            }
        }

        
        private void LaunchH1Z1_OnClick(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;

            p.StartInfo = info;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("H1Z1.exe sessionid=115 server=localhost:1115");
                }
            }
        }

        private void UpdtServer_OnClick(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;

            p.StartInfo = info;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd "+ServerFilesPath);
                    sw.WriteLine("npm update");
                }
            }
        }
        
        private void InstallServer_OnClick(object sender, RoutedEventArgs e)
        {
            Process p1 = new Process();
            Process p2 = new Process();
            
            ProcessStartInfo cmdShell = new ProcessStartInfo();
            cmdShell.FileName = "cmd.exe";
            cmdShell.RedirectStandardInput = true;
            cmdShell.UseShellExecute = false;
            
            ProcessStartInfo powershellShell = new ProcessStartInfo();
            powershellShell.FileName = "powershell.exe";
            powershellShell.RedirectStandardInput = true;
            powershellShell.UseShellExecute = false;

            p1.StartInfo = cmdShell;
            p1.Start();

            using (StreamWriter sw = p1.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("rd /s /q H1emuServersFiles");
                    sw.WriteLine("curl -LJO -H 'Cache-Control: no-cache' --output h1z1-server-QuickStart-master.zip " + ServerFilesRepo +"?"+ new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());


                }
            }
            p1.WaitForExit();
            p2.StartInfo = powershellShell;
            p2.Start();

            using (StreamWriter sw = p2.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("Expand-Archive h1z1-server-QuickStart-master.zip H1emuServersFiles");
                }
            }
            p2.WaitForExit();

            p1.Start();

            using (StreamWriter sw = p1.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd "+ServerFilesPath);
                    sw.WriteLine("npm ci");                   
                }
            }
        }
    }
}