
namespace H1Emu
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.mainTabs = new MaterialSkin.Controls.MaterialTabSelector();
            this.mainTabsControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.InstallLatest = new MaterialSkin.Controls.MaterialButton();
            this.installStable = new MaterialSkin.Controls.MaterialButton();
            this.applyPatch = new MaterialSkin.Controls.MaterialButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.launchH1z1 = new MaterialSkin.Controls.MaterialButton();
            this.launchServers = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.joinCommunityLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.filler = new System.Windows.Forms.Panel();
            this.mainTabsControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabs
            // 
            this.mainTabs.BaseTabControl = this.mainTabsControl;
            this.mainTabs.Depth = 0;
            this.mainTabs.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mainTabs.Location = new System.Drawing.Point(20, 60);
            this.mainTabs.MouseState = MaterialSkin.MouseState.HOVER;
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.Size = new System.Drawing.Size(495, 62);
            this.mainTabs.TabIndex = 0;
            this.mainTabs.Text = "yes";
            // 
            // mainTabsControl
            // 
            this.mainTabsControl.Controls.Add(this.tabPage1);
            this.mainTabsControl.Controls.Add(this.tabPage2);
            this.mainTabsControl.Depth = 0;
            this.mainTabsControl.Location = new System.Drawing.Point(6, 277);
            this.mainTabsControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.mainTabsControl.Multiline = true;
            this.mainTabsControl.Name = "mainTabsControl";
            this.mainTabsControl.SelectedIndex = 0;
            this.mainTabsControl.Size = new System.Drawing.Size(464, 311);
            this.mainTabsControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.InstallLatest);
            this.tabPage1.Controls.Add(this.installStable);
            this.tabPage1.Controls.Add(this.applyPatch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 285);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Installation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // InstallLatest
            // 
            this.InstallLatest.AutoSize = false;
            this.InstallLatest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InstallLatest.Depth = 0;
            this.InstallLatest.DrawShadows = true;
            this.InstallLatest.HighEmphasis = true;
            this.InstallLatest.Icon = null;
            this.InstallLatest.Location = new System.Drawing.Point(72, 220);
            this.InstallLatest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.InstallLatest.MouseState = MaterialSkin.MouseState.HOVER;
            this.InstallLatest.Name = "InstallLatest";
            this.InstallLatest.Size = new System.Drawing.Size(315, 56);
            this.InstallLatest.TabIndex = 2;
            this.InstallLatest.Text = "Install Servers (Latest)";
            this.InstallLatest.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.InstallLatest.UseAccentColor = false;
            this.InstallLatest.UseVisualStyleBackColor = true;
            this.InstallLatest.Click += new System.EventHandler(this.InstallLatest_Click);
            // 
            // installStable
            // 
            this.installStable.AutoSize = false;
            this.installStable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.installStable.Depth = 0;
            this.installStable.DrawShadows = true;
            this.installStable.HighEmphasis = true;
            this.installStable.Icon = null;
            this.installStable.Location = new System.Drawing.Point(72, 122);
            this.installStable.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.installStable.MouseState = MaterialSkin.MouseState.HOVER;
            this.installStable.Name = "installStable";
            this.installStable.Size = new System.Drawing.Size(315, 56);
            this.installStable.TabIndex = 1;
            this.installStable.Text = "Install Servers (Stable)";
            this.installStable.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.installStable.UseAccentColor = false;
            this.installStable.UseVisualStyleBackColor = true;
            this.installStable.Click += new System.EventHandler(this.installStable_Click);
            // 
            // applyPatch
            // 
            this.applyPatch.AutoSize = false;
            this.applyPatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.applyPatch.Depth = 0;
            this.applyPatch.DrawShadows = true;
            this.applyPatch.HighEmphasis = true;
            this.applyPatch.Icon = null;
            this.applyPatch.Location = new System.Drawing.Point(72, 23);
            this.applyPatch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.applyPatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.applyPatch.Name = "applyPatch";
            this.applyPatch.Size = new System.Drawing.Size(315, 56);
            this.applyPatch.TabIndex = 0;
            this.applyPatch.Text = "Apply Patch";
            this.applyPatch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.applyPatch.UseAccentColor = false;
            this.applyPatch.UseVisualStyleBackColor = true;
            this.applyPatch.Click += new System.EventHandler(this.applyPatch_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.launchH1z1);
            this.tabPage2.Controls.Add(this.launchServers);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(456, 285);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Play";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // launchH1z1
            // 
            this.launchH1z1.AutoSize = false;
            this.launchH1z1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.launchH1z1.Depth = 0;
            this.launchH1z1.DrawShadows = true;
            this.launchH1z1.HighEmphasis = true;
            this.launchH1z1.Icon = null;
            this.launchH1z1.Location = new System.Drawing.Point(72, 171);
            this.launchH1z1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.launchH1z1.MouseState = MaterialSkin.MouseState.HOVER;
            this.launchH1z1.Name = "launchH1z1";
            this.launchH1z1.Size = new System.Drawing.Size(315, 56);
            this.launchH1z1.TabIndex = 2;
            this.launchH1z1.Text = "Launch H1Z1";
            this.launchH1z1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.launchH1z1.UseAccentColor = false;
            this.launchH1z1.UseVisualStyleBackColor = true;
            this.launchH1z1.Click += new System.EventHandler(this.launchH1z1_Click);
            // 
            // launchServers
            // 
            this.launchServers.AutoSize = false;
            this.launchServers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.launchServers.Depth = 0;
            this.launchServers.DrawShadows = true;
            this.launchServers.HighEmphasis = true;
            this.launchServers.Icon = null;
            this.launchServers.Location = new System.Drawing.Point(72, 60);
            this.launchServers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.launchServers.MouseState = MaterialSkin.MouseState.HOVER;
            this.launchServers.Name = "launchServers";
            this.launchServers.Size = new System.Drawing.Size(315, 56);
            this.launchServers.TabIndex = 1;
            this.launchServers.Text = "Launch Solo Server";
            this.launchServers.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.launchServers.UseAccentColor = false;
            this.launchServers.UseVisualStyleBackColor = true;
            this.launchServers.Click += new System.EventHandler(this.launchServers_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(79, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // joinCommunityLabel
            // 
            this.joinCommunityLabel.BackColor = System.Drawing.SystemColors.Control;
            this.joinCommunityLabel.Font = new System.Drawing.Font("Carrinady", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinCommunityLabel.ForeColor = System.Drawing.Color.Black;
            this.joinCommunityLabel.Location = new System.Drawing.Point(6, 606);
            this.joinCommunityLabel.Name = "joinCommunityLabel";
            this.joinCommunityLabel.Size = new System.Drawing.Size(464, 35);
            this.joinCommunityLabel.TabIndex = 3;
            this.joinCommunityLabel.Text = "Join the community at H1emu.com";
            this.joinCommunityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.joinCommunityLabel.UseCompatibleTextRendering = true;
            this.joinCommunityLabel.Click += new System.EventHandler(this.joinCommunityLabel_Click);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.Font = new System.Drawing.Font("Carrinady", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyrightLabel.ForeColor = System.Drawing.Color.Black;
            this.copyrightLabel.Location = new System.Drawing.Point(79, 637);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(318, 23);
            this.copyrightLabel.TabIndex = 4;
            this.copyrightLabel.Text = "Copyright © 2021 H1emu Community";
            this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.copyrightLabel.UseCompatibleTextRendering = true;
            // 
            // filler
            // 
            this.filler.Location = new System.Drawing.Point(-6, 60);
            this.filler.Name = "filler";
            this.filler.Size = new System.Drawing.Size(36, 62);
            this.filler.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(474, 685);
            this.Controls.Add(this.filler);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.joinCommunityLabel);
            this.Controls.Add(this.mainTabsControl);
            this.Controls.Add(this.mainTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H1Emu - v1.6.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainTabsControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector mainTabs;
        private MaterialSkin.Controls.MaterialTabControl mainTabsControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialButton applyPatch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialButton InstallLatest;
        private MaterialSkin.Controls.MaterialButton installStable;
        private MaterialSkin.Controls.MaterialButton launchH1z1;
        private MaterialSkin.Controls.MaterialButton launchServers;
        public System.Windows.Forms.Label joinCommunityLabel;
        public System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Panel filler;
    }
}

