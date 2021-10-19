using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;

namespace EW30SX.Function.Protocol {

    public class SSH<T> where T : class, new() {

        private ShellStream shellStreamSSH;
        private SshClient sshClient;
        protected T obj = null;
        public bool IsConnected = false;

        public SSH(T t) {
            this.obj = t;
        }

        public bool Login(string ip, string user, string password) {
            try {
                this.sshClient = new SshClient(ip, 22, user, password);

                //Thực hiện kết nối
                this.sshClient.ConnectionInfo.Timeout = TimeSpan.FromSeconds(3);
                this.sshClient.Connect();

                // tạo shell stream để điều khiển command ssh
                this.shellStreamSSH = this.sshClient.CreateShellStream("vt100", 80, 60, 800, 600, 65535);

                //write dummy data
                string data = this.Query("", 100); //delay 500 ms
                string pattern = "root@VNPT:~#";

                IsConnected = data.ToLower().Contains(pattern.ToLower());
            } catch {
                IsConnected = false;
            }
            return IsConnected;
        }

        public void Write(string cmd) {
            this.shellStreamSSH.Write(cmd);
            this.shellStreamSSH.Flush();
        }

        public void WriteLine(string cmd) {
            this.Write(cmd + "\n");
        }

        public string Read() {
            string value = "NULL";
            try {
                value = shellStreamSSH.Read();

                PropertyInfo logssh = this.obj.GetType().GetProperty("LogSSH");
                string data = (string)logssh.GetValue(this.obj, null);
                data += value;
                logssh.SetValue(this.obj, Convert.ChangeType(data, logssh.PropertyType), null);

                return value;
            } catch {
                return value;
            };
        }

        public string Query(string cmd, int delay_time) {
            this.WriteLine(cmd);
            Thread.Sleep(delay_time);
            return this.Read();
        }

        public bool Query(string cmd, string pattern, int timeout_ms, out string data_feedback) {
            this.WriteLine(cmd);

            bool r = false;
            int count = 0;
            int max_count = timeout_ms / 100;
            string data = "";
            data_feedback = "";

            RE:
            count++;
            data += this.Read();
            r = data.ToLower().Contains(pattern.ToLower());
            if (!r) {
                if (count < max_count) {
                    Thread.Sleep(100);
                    goto RE;
                }
            }
            data_feedback = data;
            return r;
        }

        public bool Query(string cmd, string pattern, int timeout_ms, int retry_time, out string data_feedback) {
            data_feedback = "";

            string data_out = "";
            bool r = false;
            int count = 0;

            RE:
            count++;
            r = this.Query(cmd, pattern, timeout_ms, out data_out);
            data_feedback += data_out;
            if (!r) {
                if (count < retry_time) {
                    goto RE;
                }
            }
            return r;
        }

        public void Disconnect() {
            if (this.sshClient != null) this.sshClient.Disconnect();
        }

        public void Close() {
            if (this.sshClient != null) this.sshClient.Dispose();
        }

        public void CloseShellStream() {
            if (this.shellStreamSSH != null) this.shellStreamSSH.Close();
        }

    }
}
