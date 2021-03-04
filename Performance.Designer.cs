
namespace NetluxUI
{
    partial class Performance
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
            this.panel_performance = new System.Windows.Forms.FlowLayoutPanel();
            this.button_autosilentmode = new System.Windows.Forms.Button();
            this.button_trackcleaner = new System.Windows.Forms.Button();
            this.button_hijackrestore = new System.Windows.Forms.Button();
            this.button_systemexplorer = new System.Windows.Forms.Button();
            this.button_gamebooster = new System.Windows.Forms.Button();
            this.panel_performance.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_performance
            // 
            this.panel_performance.Controls.Add(this.button_autosilentmode);
            this.panel_performance.Controls.Add(this.button_trackcleaner);
            this.panel_performance.Controls.Add(this.button_hijackrestore);
            this.panel_performance.Controls.Add(this.button_systemexplorer);
            this.panel_performance.Controls.Add(this.button_gamebooster);
            this.panel_performance.Location = new System.Drawing.Point(-1, 0);
            this.panel_performance.Margin = new System.Windows.Forms.Padding(20);
            this.panel_performance.Name = "panel_performance";
            this.panel_performance.Size = new System.Drawing.Size(1027, 486);
            this.panel_performance.TabIndex = 9;
            // 
            // button_autosilentmode
            // 
            this.button_autosilentmode.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_autosilentmode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_autosilentmode.ForeColor = System.Drawing.Color.Transparent;
            this.button_autosilentmode.Location = new System.Drawing.Point(60, 40);
            this.button_autosilentmode.Margin = new System.Windows.Forms.Padding(60, 40, 20, 20);
            this.button_autosilentmode.Name = "button_autosilentmode";
            this.button_autosilentmode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_autosilentmode.Size = new System.Drawing.Size(195, 122);
            this.button_autosilentmode.TabIndex = 0;
            this.button_autosilentmode.Text = "Auto Silent Mode";
            this.button_autosilentmode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_autosilentmode.UseVisualStyleBackColor = true;
            // 
            // button_trackcleaner
            // 
            this.button_trackcleaner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_trackcleaner.ForeColor = System.Drawing.Color.White;
            this.button_trackcleaner.Location = new System.Drawing.Point(295, 40);
            this.button_trackcleaner.Margin = new System.Windows.Forms.Padding(20, 40, 20, 20);
            this.button_trackcleaner.Name = "button_trackcleaner";
            this.button_trackcleaner.Size = new System.Drawing.Size(195, 122);
            this.button_trackcleaner.TabIndex = 5;
            this.button_trackcleaner.Text = "Track Cleaner";
            this.button_trackcleaner.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_trackcleaner.UseVisualStyleBackColor = true;
            // 
            // button_hijackrestore
            // 
            this.button_hijackrestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_hijackrestore.ForeColor = System.Drawing.Color.White;
            this.button_hijackrestore.Location = new System.Drawing.Point(530, 40);
            this.button_hijackrestore.Margin = new System.Windows.Forms.Padding(20, 40, 20, 20);
            this.button_hijackrestore.Name = "button_hijackrestore";
            this.button_hijackrestore.Size = new System.Drawing.Size(195, 122);
            this.button_hijackrestore.TabIndex = 7;
            this.button_hijackrestore.Text = "Hijack Restore";
            this.button_hijackrestore.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_hijackrestore.UseVisualStyleBackColor = true;
            // 
            // button_systemexplorer
            // 
            this.button_systemexplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_systemexplorer.ForeColor = System.Drawing.Color.White;
            this.button_systemexplorer.Location = new System.Drawing.Point(765, 40);
            this.button_systemexplorer.Margin = new System.Windows.Forms.Padding(20, 40, 20, 20);
            this.button_systemexplorer.Name = "button_systemexplorer";
            this.button_systemexplorer.Size = new System.Drawing.Size(195, 122);
            this.button_systemexplorer.TabIndex = 1;
            this.button_systemexplorer.Text = "System Explorer";
            this.button_systemexplorer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_systemexplorer.UseVisualStyleBackColor = true;
            // 
            // button_gamebooster
            // 
            this.button_gamebooster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_gamebooster.ForeColor = System.Drawing.Color.White;
            this.button_gamebooster.Location = new System.Drawing.Point(60, 202);
            this.button_gamebooster.Margin = new System.Windows.Forms.Padding(60, 20, 20, 20);
            this.button_gamebooster.Name = "button_gamebooster";
            this.button_gamebooster.Size = new System.Drawing.Size(195, 122);
            this.button_gamebooster.TabIndex = 6;
            this.button_gamebooster.Text = "Game Booster";
            this.button_gamebooster.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_gamebooster.UseVisualStyleBackColor = true;
            // 
            // Performance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 486);
            this.Controls.Add(this.panel_performance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Performance";
            this.Text = "Performance";
            this.Load += new System.EventHandler(this.Performance_Load);
            this.panel_performance.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel_performance;
        private System.Windows.Forms.Button button_autosilentmode;
        private System.Windows.Forms.Button button_trackcleaner;
        private System.Windows.Forms.Button button_hijackrestore;
        private System.Windows.Forms.Button button_systemexplorer;
        private System.Windows.Forms.Button button_gamebooster;
    }
}