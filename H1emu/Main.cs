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
using System.Collections.Generic;
using System.Security.Cryptography;

namespace H1Emu
{
    public sealed class Crc32 : HashAlgorithm
    {
        public const UInt32 DefaultPolynomial = 0xedb88320u;
        public const UInt32 DefaultSeed = 0xffffffffu;

        static UInt32[] defaultTable;

        readonly UInt32 seed;
        readonly UInt32[] table;
        UInt32 hash;

        public Crc32()
            : this(DefaultPolynomial, DefaultSeed)
        {
        }

        public Crc32(UInt32 polynomial, UInt32 seed)
        {
            if (!BitConverter.IsLittleEndian)
                throw new PlatformNotSupportedException("Not supported on Big Endian processors");

            table = InitializeTable(polynomial);
            this.seed = hash = seed;
        }

        public override void Initialize()
        {
            hash = seed;
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            hash = CalculateHash(table, hash, array, ibStart, cbSize);
        }

        protected override byte[] HashFinal()
        {
            var hashBuffer = UInt32ToBigEndianBytes(~hash);
            HashValue = hashBuffer;
            return hashBuffer;
        }

        public override int HashSize { get { return 32; } }

        public static UInt32 Compute(byte[] buffer)
        {
            return Compute(DefaultSeed, buffer);
        }

        public static UInt32 Compute(UInt32 seed, byte[] buffer)
        {
            return Compute(DefaultPolynomial, seed, buffer);
        }

        public static UInt32 Compute(UInt32 polynomial, UInt32 seed, byte[] buffer)
        {
            return ~CalculateHash(InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
        }

        static UInt32[] InitializeTable(UInt32 polynomial)
        {
            if (polynomial == DefaultPolynomial && defaultTable != null)
                return defaultTable;

            var createTable = new UInt32[256];
            for (var i = 0; i < 256; i++)
            {
                var entry = (UInt32)i;
                for (var j = 0; j < 8; j++)
                    if ((entry & 1) == 1)
                        entry = (entry >> 1) ^ polynomial;
                    else
                        entry >>= 1;
                createTable[i] = entry;
            }

            if (polynomial == DefaultPolynomial)
                defaultTable = createTable;

            return createTable;
        }

        static UInt32 CalculateHash(UInt32[] table, UInt32 seed, IList<byte> buffer, int start, int size)
        {
            var hash = seed;
            for (var i = start; i < start + size; i++)
                hash = (hash >> 8) ^ table[buffer[i] ^ hash & 0xff];
            return hash;
        }

        static byte[] UInt32ToBigEndianBytes(UInt32 uint32)
        {
            var result = BitConverter.GetBytes(uint32);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(result);

            return result;
        }
    }
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
            else
            {
                Crc32 crc32 = new Crc32();
                String hash = String.Empty;

                using (FileStream fs = File.Open("./h1z1.exe", FileMode.Open))
                    foreach (byte b in crc32.ComputeHash(fs)) hash += b.ToString("x2").ToLower();

                Console.WriteLine("CRC-32 is {0}", hash);
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