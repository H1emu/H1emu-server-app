using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace H1emu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        ProcessStartInfo cmdShell;
        ProcessStartInfo powershellShell;
        public MainWindow()
        {
            InitializeComponent();
            this.cmdShell = new ProcessStartInfo();
            cmdShell.FileName = "cmd.exe";
            cmdShell.RedirectStandardInput = true;
            cmdShell.UseShellExecute = false;

            this.powershellShell = new ProcessStartInfo();
            powershellShell.FileName = "powershell.exe";
            powershellShell.RedirectStandardInput = true;
            powershellShell.UseShellExecute = false;
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            String localVersion = version.TrimEnd('0').TrimEnd('.');
            GetLatestOnlineVersion(localVersion);
        }

        static readonly HttpClient client = new HttpClient();

        static async Task GetLatestOnlineVersion(String localeVersion)
        {
            var _UserAgent = "d-fens HttpClient";
            client.DefaultRequestHeaders.Add("User-Agent", _UserAgent);
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.github.com/repos/H1emu/H1emu-server-app/releases/latest");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                String LatestOnlineVersion = JObject.Parse(responseBody).SelectToken("tag_name").ToString().TrimStart('v');
                if (localeVersion != LatestOnlineVersion)
                {
                    new UpdateWindow().Show();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }


        private string ServerFilesPath = "./H1emuServersFiles/h1z1-server-QuickStart-master";
        private string ServerFilesRepo = "https://github.com/H1emu/h1z1-server-QuickStart/archive/master.zip";

        private void LaunchServer_OnClick(object sender, RoutedEventArgs e)
        {
            Process p = new Process();

            p.StartInfo = cmdShell;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd " + ServerFilesPath);
                    sw.WriteLine("npm start");
                }
            }
        }

        private void InstallNodejs_OnClick(object sender, RoutedEventArgs e)
        {
            Process p = new Process();

            p.StartInfo = cmdShell;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd /temp");
                    sw.WriteLine("curl -LJO https://nodejs.org/dist/v14.15.4/node-v14.15.4-x64.msi");
                    sw.WriteLine("node-v14.15.4-x64.msi");
                }
            }
        }

        private void ApplyPatch_OnClick(object sender, RoutedEventArgs e)
        {
            Process p = new Process();

            p.StartInfo = cmdShell;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("curl --output dinput8.dll https://h1emu.s3.eu-west-3.amazonaws.com/patch/dinput8.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl --output msvcp140d.dll https://h1emu.s3.eu-west-3.amazonaws.com/patch/msvcp140d.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl --output ucrtbased.dll https://h1emu.s3.eu-west-3.amazonaws.com/patch/ucrtbased.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl --output vcruntime140_1d.dll https://h1emu.s3.eu-west-3.amazonaws.com/patch/vcruntime140_1d.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl --output vcruntime140d.dll https://h1emu.s3.eu-west-3.amazonaws.com/patch/vcruntime140d.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                }
            }
        }


        private void LaunchH1Z1_OnClick(object sender, RoutedEventArgs e)
        {
            Process p = new Process();

            p.StartInfo = cmdShell;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("H1Z1.exe sessionid=115 server=localhost:1115");
                }
            }
        }

        private void InstallLatest_OnClick(object sender, RoutedEventArgs e)
        {
            InstallServer();

            Process p = new Process();

            p.StartInfo = cmdShell;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd " + ServerFilesPath);
                    sw.WriteLine("npm i h1z1-server@latest");
                }
            }
        }

        private void InstallServer()
        {
            Process p1 = new Process();

            p1.StartInfo = cmdShell;
            p1.Start();

            using (StreamWriter sw = p1.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("del /f h1z1-server-QuickStart-master.zip"); // just in case of corrupted archive
                    sw.WriteLine("rd /s /q H1emuServersFiles");
                    sw.WriteLine("curl -LJO --output h1z1-server-QuickStart-master.zip " + ServerFilesRepo + "?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());


                }
            }
            p1.WaitForExit();

            Process p2 = new Process();

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
        }
        private void InstallStable_OnClick(object sender, RoutedEventArgs e)
        {

            InstallServer();

            Process p1 = new Process();

            p1.StartInfo = cmdShell;
            p1.Start();

            using (StreamWriter sw = p1.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd " + ServerFilesPath);
                    sw.WriteLine("npm ci");
                }
            }
        }
    }
}