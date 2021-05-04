using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H1Emu
{
    public partial class VersionCheck : MaterialForm
    {
        public VersionCheck()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.BlueGrey500, Accent.Red100, TextShade.WHITE);
            materialSkinManager.AddFormToManage(this);
        }

        private void VersionCheck_Load(object sender, EventArgs e)
        {
            updateLabel.Font = new Font("Roboto", 12f);
            update.Font = new Font("Roboto", 16f);
            panel.BackColor = Color.FromArgb(68, 68, 68);
            update.BackColor = Color.FromArgb(68, 68, 68);
            top.BackColor = Color.FromArgb(33, 33, 33);
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/H1emu/H1emu-server-app/releases/latest/download/H1emu.exe");
            Application.Exit();
        }
    }
}
