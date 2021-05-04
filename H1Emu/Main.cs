using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using Newtonsoft.Json;
using System.Net;

namespace H1Emu
{
    public partial class Main : MaterialForm
    {
        ProcessStartInfo cmdShell;
        string currentDirectory;
        string localVersion;

        public Main()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.BlueGrey500, Accent.Red100, TextShade.WHITE);
            materialSkinManager.AddFormToManage(this);

            this.cmdShell = new ProcessStartInfo();
            cmdShell.FileName = "cmd.exe";
            cmdShell.RedirectStandardInput = true;
            cmdShell.UseShellExecute = false;

            this.currentDirectory = Directory.GetCurrentDirectory();
        }

        private string ServerFilesPath = "./H1emuServersFiles/h1z1-server-QuickStart-master";
        private string ServerFilesRepo = "https://github.com/H1emu/h1z1-server-QuickStart/archive/master.zip";

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("h1z1.exe"))
            {
                MessageBox.Show("Please put H1Emu app inside of the H1Z1 Directory.", "H1Emu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }

            localVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString().TrimEnd('0').TrimEnd('.');
            this.Text = $"H1Emu - {localVersion}";

            checkVersion();

            joinCommunityLabel.Font = new Font("Carrinady", 22);
            copyrightLabel.Font = new Font("Carrinady", 12);
            filler.BackColor = Color.FromArgb(66, 66, 66);
        }

        private void applyPatch_Click(object sender, EventArgs e)
        {
            Process p = new Process();

            p.StartInfo = cmdShell;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("curl --output dinput8.dll https://h1emu.s3.eu-west-3.amazonaws.com/patches/15jan2015/dinput8.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl --output msvcp140d.dll https://h1emu.s3.eu-west-3.amazonaws.com/patches/15jan2015/msvcp140d.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl --output ucrtbased.dll https://h1emu.s3.eu-west-3.amazonaws.com/patches/15jan2015/ucrtbased.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl --output vcruntime140_1d.dll https://h1emu.s3.eu-west-3.amazonaws.com/patches/15jan2015/vcruntime140_1d.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    sw.WriteLine("curl --output vcruntime140d.dll https://h1emu.s3.eu-west-3.amazonaws.com/patches/15jan2015/vcruntime140d.dll?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                }
            }
        }

        private void InstallLatest_Click(object sender, EventArgs e)
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

        private void installStable_Click(object sender, EventArgs e)
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
                    sw.WriteLine("npm i");
                }
            }
        }

        private void launchServers_Click(object sender, EventArgs e)
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

        private void launchH1z1_Click(object sender, EventArgs e)
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

        private void InstallServer()
        {
            Process p1 = new Process();

            p1.StartInfo = cmdShell;
            p1.Start();

            using (StreamWriter sw = p1.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("del /f h1z1-server-QuickStart-master.zip"); // Just in case of corrupted archive
                    sw.WriteLine("rd /s /q H1emuServersFiles");
                    sw.WriteLine("curl -LJO --output h1z1-server-QuickStart-master.zip " + ServerFilesRepo + "?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());


                }
            }

            p1.WaitForExit();

            ZipFile.ExtractToDirectory($"{this.currentDirectory}/h1z1-server-QuickStart-master.zip", $"{this.currentDirectory}/H1emuServersFiles");

            installNodejsStandalone();
        }

        private void installNodejsStandalone()
        {
            Process p1 = new Process();

            p1.StartInfo = cmdShell;
            p1.Start();

            using (StreamWriter sw = p1.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd ./H1emuServersFiles/h1z1-server-QuickStart-master");
                    sw.WriteLine("curl --output node.zip https://h1emu.s3.eu-west-3.amazonaws.com/patches/15jan2015/node.zip?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                }
            }

            p1.WaitForExit();

            ZipFile.ExtractToDirectory($"{this.currentDirectory}/H1emuServersFiles/h1z1-server-QuickStart-master/node.zip", $"{this.currentDirectory}/H1emuServersFiles/h1z1-server-QuickStart-master");

            File.Delete("./H1emuServersFiles/h1z1-server-QuickStart-master/node.zip");
            File.Delete("h1z1-server-QuickStart-master.zip");
        }

        public void checkVersion()
        {
            WebClient wc = new WebClient();
            string str = "d-fens HttpClient";
            wc.Headers.Add("User-Agent", str);
            string jsonRaw = wc.DownloadString("https://api.github.com/repos/H1emu/H1emu-server-app/releases/latest");

            var jsonDes = JsonConvert.DeserializeObject<dynamic>(jsonRaw);
            string raw = jsonDes.tag_name;
            string version = raw.Substring(1);

            if (version != localVersion)
            {
                VersionCheck vc = new VersionCheck();
                vc.ShowDialog();
            }
        }

        private void joinCommunityLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.h1emu.com/");
        }
    }
}