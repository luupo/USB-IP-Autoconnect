namespace SmallUSBIPGui
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.freeDongle = new System.Windows.Forms.Button();
            this.dongleStatus = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // freeDongle
            // 
            this.freeDongle.Location = new System.Drawing.Point(54, 63);
            this.freeDongle.Name = "freeDongle";
            this.freeDongle.Size = new System.Drawing.Size(150, 23);
            this.freeDongle.TabIndex = 0;
            this.freeDongle.Text = "Dongle freigeben!";
            this.freeDongle.UseVisualStyleBackColor = true;
            this.freeDongle.Click += new System.EventHandler(this.freeDongle_Click);
            // 
            // dongleStatus
            // 
            this.dongleStatus.AutoSize = true;
            this.dongleStatus.Location = new System.Drawing.Point(67, 32);
            this.dongleStatus.Name = "dongleStatus";
            this.dongleStatus.Size = new System.Drawing.Size(128, 13);
            this.dongleStatus.TabIndex = 1;
            this.dongleStatus.Text = "Dongle Status unbekannt";
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "trayIcon";
            this.trayIcon.Visible = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 98);
            this.Controls.Add(this.dongleStatus);
            this.Controls.Add(this.freeDongle);
            this.Name = "MainWindow";
            this.Text = "USB/IP GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_Close);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button freeDongle;
        private System.Windows.Forms.Label dongleStatus;
        private System.Windows.Forms.NotifyIcon trayIcon;
    }
}

