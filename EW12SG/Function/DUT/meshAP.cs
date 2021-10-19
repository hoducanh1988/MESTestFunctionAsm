using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EW12SG.Function.Protocol;

namespace EW12SG.Function.DUT {

    public class meshAP<T> : SSH<T> where T : class, new() {

        public meshAP(T t) : base(t) { }

        public string getMacEthernet() {
            if (!IsConnected) return null;

            //get data
            string data_out = this.Query("cat /sys/class/net/eth0/address", 100);
            string[] buffer = data_out.Split('\n');
            if (buffer.Length < 2) return null;

            //split mac
            string mac_ethernet = buffer[1].Replace("\r", "").Replace("\n", "").Replace(":", "").ToUpper().Trim();

            //return value
            return mac_ethernet;
        }

        public string getMacWlan2G() {
            if (!IsConnected) return null;

            int count = 0;
            int retry_time = 3;
            bool r = false;
            RE:
            count++;

            //get data
            string data_out = "";
            r = this.Query("hexdump /dev/mtd5 | grep 0001000", "root@VNPT:~#", 3000, out data_out);
            if (!r) { if (count < retry_time) goto RE; }
            string[] buffer = data_out.Split('\n');
            if (buffer.Length < 3) {
                if (count < retry_time) goto RE;
                else return null;
            }

            //split mac
            string s = buffer[1].Replace("\r", "").Replace("\n", "").Trim().ToUpper().Substring(13, 14).Replace(" ", "");
            string mac_wlan_2g = string.Format("{0}{1}{2}{3}{4}{5}", s.Substring(0, 2), s.Substring(2, 2), s.Substring(4, 2), s.Substring(6, 2), s.Substring(8, 2), s.Substring(10, 2));

            //return value
            return mac_wlan_2g.Length == 12 ? mac_wlan_2g : null;
        }

        public string getMacWlan5G() {
            if (!IsConnected) return null;

            int count = 0;
            int retry_time = 3;
            bool r = false;
            RE:
            count++;

            //get data
            string data_out = "";
            r = this.Query("hexdump /dev/mtd5 | grep 0005000", "root@VNPT:~#", 3000, out data_out);
            if (!r) { if (count < retry_time) goto RE; }
            string[] buffer = data_out.Split('\n');
            if (buffer.Length < 3) {
                if (count < retry_time) goto RE;
                else return null;
            }

            //split mac
            string s = buffer[1].Replace("\r", "").Replace("\n", "").Trim().ToUpper().Substring(23, 14).Replace(" ", "");
            string mac_wlan_5g = string.Format("{0}{1}{2}{3}{4}{5}", s.Substring(0, 2), s.Substring(2, 2), s.Substring(4, 2), s.Substring(6, 2), s.Substring(8, 2), s.Substring(10, 2));

            //return value
            return mac_wlan_5g.Length == 12 ? mac_wlan_5g : null;
        }

        public bool setSerialNumber(string serial) {
            if (!IsConnected) return false;
            string data_out = "";
            bool r = this.Query(string.Format("fw_setenv serialnumber {0}", serial.ToUpper()), "root@VNPT:~#", 1000, 3, out data_out);
            return r;
        }

        public string getSerialNumber() {
            if (!IsConnected) return null;

            //get data
            string data_out = this.Query("fw_printenv serialnumber | cut -d= -f2", 100);
            string[] buffer = data_out.Split('\n');
            if (buffer.Length < 2) return null;

            //split data
            string serial = buffer[1].Replace("\r", "").Replace("\n", "").ToUpper().Trim();

            //return value
            return serial;
        }

        public string getFirmwareVersion() {
            if (!IsConnected) return null;

            //get data
            string data_out = this.Query("cat /etc/fw_info", 100);
            string[] buffer = data_out.Split('\n');
            if (buffer.Length < 2) return null;

            //split data
            string version = buffer[1].Replace("\r", "").Replace("\n", "").ToUpper().Trim();
            version = version.Split(':')[1].Trim();

            //return value
            return version;
        }

        public string getFirmwareBuildTime() {
            if (!IsConnected) return null;

            //get data
            string data_out = this.Query("cat /proc/version", 100);
            string[] buffer = data_out.Split('\n');
            if (buffer.Length < 2) return null;

            //split data
            string build_time = buffer[1].Replace("\r", "").Replace("\n", "").ToUpper().Trim();

            //return value
            return build_time;
        }

        public string getHardwareVersion() {
            if (!IsConnected) return null;

            //get data
            string data = "";
            bool r = this.Query("fw_printenv", "hardwareversion=", 1000, 3, out data);
            if (!r) return null;

            //split hardware version
            string hardware_version = "";
            string[] buffer = data.Split('\n');
            int max = buffer.Length - 1;
            for (int i = max; i >= 0; i--) {
                string s = buffer[i];
                if (s.Contains("hardwareversion=")) {
                    hardware_version = s.Replace("hardwareversion=", "")
                                        .Replace("\r", "")
                                        .Replace("\n", "")
                                        .Replace(":", "")
                                        .Replace(",", "")
                                        .Replace(";", "")
                                        .Trim();
                    break;
                }
            }

            //return value
            return hardware_version == "" ? null : hardware_version;
        }

        public string getModelNumber() {
            if (!IsConnected) return null;

            //get data
            string data = "";
            bool r = this.Query("fw_printenv", "modelnumber=", 1000, 3, out data);
            if (!r) return null;

            //split hardware version
            string model_number = "";
            string[] buffer = data.Split('\n');
            int max = buffer.Length - 1;
            for (int i = max; i >= 0; i--) {
                string s = buffer[i];
                if (s.Contains("modelnumber=")) {
                    model_number = s.Replace("modelnumber=", "")
                                    .Replace("\r", "")
                                    .Replace("\n", "")
                                    .Replace(":", "")
                                    .Replace(",", "")
                                    .Replace(";", "")
                                    .Trim();
                    break;
                }
            }

            //return value
            return model_number == "" ? null : model_number;
        }

        public string getWanSpeed() {
            try {
                if (!IsConnected) return null;

                //get data
                string data_out = "";
                this.Query("swconfig dev switch0 show | grep \"link: port:3\"", "root@VNPT:~#", 3000, out data_out);

                string[] buffer = data_out.Split('\n');
                if (buffer.Length < 2) return null;

                //split data
                string speed = buffer[1].Replace("\r", "")
                                        .Replace("\n", "")
                                        .ToLower()
                                        .Split(new string[] { "speed:" }, StringSplitOptions.None)[1]
                                        .Split(new string[] { "baset" }, StringSplitOptions.None)[0]
                                        .Trim();

                //return value
                return speed;
            } catch { return ""; }
        }

        public string getLanSpeed() {
            try {
                if (!IsConnected) return null;

                //get data
                string data_out = "";
                this.Query("swconfig dev switch0 show | grep \"link: port:2\"", "root@VNPT:~#", 3000, out data_out);
                string[] buffer = data_out.Split('\n');
                if (buffer.Length < 2) return null;

                //split data
                string speed = buffer[1].Replace("\r", "")
                                        .Replace("\n", "")
                                        .ToLower()
                                        .Split(new string[] { "speed:" }, StringSplitOptions.None)[1]
                                        .Split(new string[] { "baset" }, StringSplitOptions.None)[0]
                                        .Trim();

                //return value
                return speed;

            } catch { return ""; }
        }

        public bool setLedWanBrightGreen() {
            if (!IsConnected) return false;

            string data_out = "";
            bool r = false;
            r = this.Query("killall led-state-run.sh", "root@VNPT:~#", 1000, 3, out data_out);
            r = this.Query("echo 1 > /sys/class/leds/led_green/brightness", "root@VNPT:~#", 1000, 3, out data_out);
            r = this.Query("echo 0 > /sys/class/leds/led_red/brightness", "root@VNPT:~#", 1000, 3, out data_out);
            return r;
        }

        public bool setLedWanBrightRed() {
            if (!IsConnected) return false;

            string data_out = "";
            bool r = false;
            r = this.Query("killall led-state-run.sh", "root@VNPT:~#", 1000, 3, out data_out);
            r = this.Query("echo 0 > /sys/class/leds/led_green/brightness", "root@VNPT:~#", 1000, 3, out data_out);
            r = this.Query("echo 1 > /sys/class/leds/led_red/brightness", "root@VNPT:~#", 1000, 3, out data_out);
            return r;
        }

        public bool setLedWanBrightOff() {
            if (!IsConnected) return false;

            string data_out = "";
            bool r = false;
            r = this.Query("killall led-state-run.sh", "root@VNPT:~#", 1000, 3, out data_out);
            r = this.Query("echo 0 > /sys/class/leds/led_green/brightness", "root@VNPT:~#", 1000, 3, out data_out);
            r = this.Query("echo 0 > /sys/class/leds/led_red/brightness", "root@VNPT:~#", 1000, 3, out data_out);
            return r;
        }

    }
}
