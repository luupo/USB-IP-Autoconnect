using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmallUSBIPGui.Communication;

namespace SmallUSBIPGui
{
    public partial class MainWindow : Form
    {
        public static string dongleText { get; set; }
        string[] configFile = System.IO.File.ReadAllText(@"config\config.txt").Split(';');

        public MainWindow()
        {
            InitializeComponent();
            TrayMenuContext();


            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            trayIcon.Visible = true;
            trayIcon.Text = "Verbindung wird hergestellt ...";
        }

        #region Tray 

        private void TrayMenuContext()
        {
            this.trayIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.trayIcon.ContextMenuStrip.Items.Add("Version 0.1");
            this.trayIcon.ContextMenuStrip.Items.Add("Beenden", null, TrayMenuExit_Click);
            this.trayIcon.ContextMenuStrip.Items[0].Enabled = false;
        }

        void TrayMenuExit_Click(object sender, EventArgs e)
        {
            doEndSequenz();
        }

        #endregion

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Communication communication = new Communication();
            List<String> devices = communication.getAllDevices(configFile[0], configFile[1]);

            if (devices == null)
            {
                trayIcon.Icon = Properties.Resources.red;
                trayIcon.Text = dongleText;
            } else
            {
                dongleText = "Verbunden (USB-ID: " + devices[0] + ")";
                communication.doConnection(configFile[1], devices[0]);
                communication.startApplication(configFile[2], configFile[3]);
                trayIcon.Icon = Properties.Resources.green;
                trayIcon.Text = dongleText;
            }

        }

        private void freeDongle_Click(object sender, EventArgs e)
        {
            doEndSequenz();
        }

        private void MainWindow_Close(object sender, FormClosingEventArgs e)
        {
            Process.Start("taskkill", "/F /IM usbip.exe");
        }

        public void doEndSequenz()
        {
            Process.Start("taskkill", "/F /IM usbip.exe");
            Process.Start("taskkill", "/F /IM SmallUSBIPGui.exe");
        }
    }
}
