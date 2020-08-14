using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;

namespace SmallUSBIPGui
{
    public class Communication
    {
        private static System.Timers.Timer checkInterval;
        public List<String> getAllDevices(string applicationName, string serverIP)
        {
            var result = consoleExecute(applicationName + " list -r " + serverIP);
            //result = "Exportable USB devices\r\n ======================\r\n - 10.0.68.91\r\n        1-9.2: Kingston Technology : DataTraveler G4(0951:1666)\r\n: / sys / devices / pci0000:00 / 0000:00:06.0 /usb1/9.2\r\n: (Defined at Interface level) (00 / 00 / 00)\r\n: 0 - Mass Storage / SCSI / Bulk - Only(08 / 06 / 50)\r\n\r\n";
            if (result.Contains("no exportable devices found"))
            {
                Console.WriteLine("Keine Lizenz verfügbar.");
                MainWindow.dongleText = "Keine Lizenz gefunden.";
                writeLog(result);
                return null;
            } else if (result.Contains("unable to connect"))
            {
                Console.WriteLine("Server nicht verfügbar.");
                MainWindow.dongleText = "Server nicht erreichbar.";
                writeLog(result);
                return null;
            }
            else
            {
                writeLog(result);
                MatchCollection ndmatchList = Regex.Matches(result, @"(/usb[0-9])(.*?)(\r\n)"); //@"[0 - 9] -[0 - 9] + (\.[0 - 9]{ 1,2})");
                List<String> listUSB = ndmatchList.Cast<Match>().Select(match => match.Value.Replace("/usb1/", null).Replace("\r\n", null)).ToList();

                return listUSB;
            }
        }

        public bool doConnection(string serverIP, string device)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("SmallUSBIPGui.exe", null) + @"usbip\usbip.exe";
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.Arguments = "attach -r " + serverIP + " -b " + device;
            cmd.Start();
            return true;
        }

        public void startApplication(string name, string process)
        {
            Thread.Sleep(5000);
            Process.Start(name);
            aliveCheckerTimer(process);
        }

        private static void aliveCheckerTimer(string process)
        {
            checkInterval = new System.Timers.Timer(5000);
            checkInterval.Elapsed += (sender, e) => checkAlive(sender, e, process);
            checkInterval.AutoReset = true;
            checkInterval.Enabled = true;
        }

        private static void checkAlive(Object source, ElapsedEventArgs e, string process)
        {
            MainWindow mainWindow = new MainWindow();

            //Prüft ob der mit dem USB Stick verknüpfte Prozess noch läuft.
            if (!Process.GetProcessesByName(process).Any())
            {
                mainWindow.doEndSequenz();
            }
        }

        string consoleExecute(string parm)
        {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"powershell.exe";
                startInfo.Arguments = parm;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);

                string errors = process.StandardError.ReadToEnd();
                Console.WriteLine(errors);

                return output + errors;
        }

        void writeLog(string log)
        {
            if (!Directory.Exists("log"))
            {
                Directory.CreateDirectory("log");
            }
            using (FileStream fs = File.Create("log\\log_" + DateTime.Now.ToString("dd_MM_HH_mm_ss") + ".txt"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(log);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
