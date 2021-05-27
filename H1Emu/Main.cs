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
using System.Drawing.Text;

namespace H1Emu
{
    public partial class Main : MaterialForm
    {
        PrivateFontCollection pfc = new PrivateFontCollection();
        ProcessStartInfo cmdShell;
        string currentDirectory;
        string localVersion;
        string nodeVersion;

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
            this.nodeVersion = "16.2.0";

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

            Stream fontStream = this.GetType().Assembly.GetManifestResourceStream("H1Emu.Carrinady.ttf");
            byte[] fontData = new byte[fontStream.Length];
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            fontStream.Close();

            unsafe
            {
                fixed (byte* pFontData = fontData)
                {
                    pfc.AddMemoryFont((System.IntPtr)pFontData, fontData.Length);
                }
            }

            localVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString().TrimEnd('0').TrimEnd('.');
            this.Text = $"H1Emu - {localVersion}";

            checkVersion();

            joinCommunityLabel.Font = new Font(pfc.Families[0], 22);
            copyrightLabel.Font = new Font(pfc.Families[0], 15);
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
                    sw.WriteLine("del dinput8.dll msvcp140d.dll ucrtbased.dll vcruntime140_1d.dll vcruntime140d.dll"); 
                    sw.WriteLine("curl -L --output H1emu_patch.zip https://github.com/H1emu/h1emu-patch/releases/latest/download/H1emu_patch.zip? " + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                }
            }
            p.WaitForExit();
            ZipFile.ExtractToDirectory($"{this.currentDirectory}/H1emu_patch.zip", $"{this.currentDirectory}");
            File.Delete($"{ this.currentDirectory}/H1emu_patch.zip");
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
                    sw.WriteLine($"SET PATH={this.currentDirectory}/H1emuServersFiles/h1z1-server-QuickStart-master/node-v{this.nodeVersion}-win-x64");
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
                    sw.WriteLine($"SET PATH={this.currentDirectory}/H1emuServersFiles/h1z1-server-QuickStart-master/node-v{this.nodeVersion}-win-x64");
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
                    sw.WriteLine($"SET PATH={this.currentDirectory}/H1emuServersFiles/h1z1-server-QuickStart-master/node-v{this.nodeVersion}-win-x64");
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
                    sw.WriteLine($"curl --output node-v{this.nodeVersion}-win-x64.zip https://nodejs.org/dist/v{nodeVersion}/node-v{nodeVersion}-win-x64.zip?" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                }
            }

            p1.WaitForExit();

            ZipFile.ExtractToDirectory($"{this.currentDirectory}/H1emuServersFiles/h1z1-server-QuickStart-master/node-v{this.nodeVersion}-win-x64.zip", $"{this.currentDirectory}/H1emuServersFiles/h1z1-server-QuickStart-master");
            File.Delete($"./H1emuServersFiles/h1z1-server-QuickStart-master/node-v{this.nodeVersion}-win-x64.zip");
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