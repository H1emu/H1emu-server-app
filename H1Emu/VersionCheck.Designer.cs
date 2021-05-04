
namespace H1Emu
{
    partial class VersionCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionCheck));
            this.noButton = new MaterialSkin.Controls.MaterialButton();
            this.yesButton = new MaterialSkin.Controls.MaterialButton();
            this.top = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.Panel();
            this.update = new System.Windows.Forms.Label();
            this.updateLabel = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // noButton
            // 
            this.noButton.AutoSize = false;
            this.noButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.noButton.Depth = 0;
            this.noButton.DrawShadows = true;
            this.noButton.HighEmphasis = true;
            this.noButton.Icon = null;
            this.noButton.Location = new System.Drawing.Point(48, 200);
            this.noButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.noButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(83, 42);
            this.noButton.TabIndex = 0;
            this.noButton.Text = "No";
            this.noButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.noButton.UseAccentColor = false;
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // yesButton
            // 
            this.yesButton.AutoSize = false;
            this.yesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.yesButton.Depth = 0;
            this.yesButton.DrawShadows = true;
            this.yesButton.HighEmphasis = true;
            this.yesButton.Icon = null;
            this.yesButton.Location = new System.Drawing.Point(191, 200);
            this.yesButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.yesButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(83, 42);
            this.yesButton.TabIndex = 1;
            this.yesButton.Text = "Yes";
            this.yesButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.yesButton.UseAccentColor = false;
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // top
            // 
            this.top.Location = new System.Drawing.Point(-6, -6);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(344, 26);
            this.top.TabIndex = 3;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.update);
            this.panel.Location = new System.Drawing.Point(-6, 18);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(344, 50);
            this.panel.TabIndex = 5;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(14, 3);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(268, 45);
            this.update.TabIndex = 6;
            this.update.Text = "Update Available";
            this.update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateLabel
            // 
            this.updateLabel.Location = new System.Drawing.Point(25, 82);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(282, 94);
            this.updateLabel.TabIndex = 6;
            this.updateLabel.Text = "There is a new update available, would you like to download it now?";
            this.updateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VersionCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 261);
            this.ControlBox = false;
            this.Controls.Add(this.updateLabel);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.top);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.noButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionCheck";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VersionCheck";
            this.Load += new System.EventHandler(this.VersionCheck_Load);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton noButton;
        private MaterialSkin.Controls.MaterialButton yesButton;
        private System.Windows.Forms.Panel top;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label update;
        private System.Windows.Forms.Label updateLabel;
    }
}