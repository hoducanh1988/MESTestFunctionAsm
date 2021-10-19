using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EW12S.Function.Global;

namespace EW12S.Function.IO {
    public class LogDetailFile {

        string logdir = myGlobal.dir_Path;
        string mac = myGlobal.myTesting.MacEthernet.Replace("\"", "");

        public LogDetailFile() {
            logdir = string.Format("{0}Logdetail", logdir);
            logdir = string.Format("{0}\\EW12S", logdir);
            logdir = string.Format("{0}\\{1}", logdir, DateTime.Now.ToString("yyyy-MM-dd"));
            logdir = string.Format("{0}\\{1}", logdir, string.Format("{0}_{1}_{2}", mac, DateTime.Now.ToString("HHmmss"), myGlobal.myTesting.TotalResult));
            createLogDirectory(logdir);

            myGlobal.detailDirectory = logdir;
        }

        private void createLogDirectory(string logdirectory) {
            if (!Directory.Exists(logdirectory)) {
                Directory.CreateDirectory(logdirectory);
                Thread.Sleep(100);
            }
        }

        public void createLog() {
            //create log system
            string file_log_system = string.Format("EW12S_{0}_{1}_{2}_system.txt", mac, DateTime.Now.ToString("HHmmss"), myGlobal.myTesting.TotalResult);
            File.WriteAllText(System.IO.Path.Combine(logdir, file_log_system), "Product: EW12S\r\n" + myGlobal.myTesting.LogSystem, Encoding.Unicode);

            //create log ssh
            string file_log_ssh = string.Format("EW12S_{0}_{1}_{2}_ssh.txt", mac, DateTime.Now.ToString("HHmmss"), myGlobal.myTesting.TotalResult);
            File.WriteAllText(System.IO.Path.Combine(logdir, file_log_ssh), "Product: EW12S\r\n" + myGlobal.myTesting.LogSSH, Encoding.Unicode);
        }

    }
}
