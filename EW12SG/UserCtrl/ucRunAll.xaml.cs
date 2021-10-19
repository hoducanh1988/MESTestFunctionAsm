using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using EW12SG.Function.Custom;
using EW12SG.Function.Global;
using EW12SG.Function.Excute;
using UtilityPack.IO;

namespace EW12SG.UserCtrl {
    /// <summary>
    /// Interaction logic for ucRunAll.xaml
    /// </summary>
    public partial class ucRunAll : UserControl {

        public ucRunAll() {
            //init control
            InitializeComponent();

            //load setting from file
            if (File.Exists(myGlobal.settingFileFullName)) myGlobal.mySetting = XmlHelper<SettingInformation>.FromXmlFile(myGlobal.settingFileFullName);

            //binding data
            this.DataContext = myGlobal.myTesting;

            //add child control
            this.grid_logsystem.Children.Add(new ucLogSystem());
            this.grid_logssh.Children.Add(new ucLogSSH());
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;
            string btag = (string)b.Tag;

            switch (btag) {
                case "runall": {

                        InputMacAndSerialNumberWindow window = new InputMacAndSerialNumberWindow(myGlobal.mySetting.Factory,
                                                                                                 myGlobal.mySetting.ProductNumber,
                                                                                                 int.Parse(myGlobal.mySetting.HardwareVersion.ToLower().Split('h')[1]).ToString(),
                                                                                                 myGlobal.mySetting.VnptMacCode);
                        myGlobal.myWindowInfo.WindowOpacity = 0.3;
                        window.ShowDialog();
                        myGlobal.myWindowInfo.WindowOpacity = 1;

                        string _mac = window.stampMac.ToUpper();
                        string _sn = window.stampSerial.ToUpper();
                        if (string.IsNullOrEmpty(_mac) || string.IsNullOrEmpty(_sn)) return;

                        initMacAndSerial(_mac, _sn);
                        showMacAndSerial();

                        Thread t = new Thread(new ThreadStart(() => {
                            var test = new runAll(this.grid_logsystem);
                            bool r = test.Excute();
                        }));
                        t.IsBackground = true;
                        t.Start();

                        break;
                    }
            }
        }

        private void initMacAndSerial(string mac, string sn) {
            myGlobal.myTesting.MacEthernet = mac;
            myGlobal.myTesting.MacWlan2G = mac.Substring(0, 6) + getMAC2G(mac.Substring(6, 6));
            myGlobal.myTesting.MacWlan5G = mac.Substring(0, 6) + getMAC5G(mac.Substring(6, 6));
            myGlobal.myTesting.SerialNumber = sn;
        }

        private void showMacAndSerial() {
            myGlobal.myTesting.LogSystem = "";
            myGlobal.myTesting.LogSystem += "### THÔNG TIN SẢN PHẨM ###\r\n";
            myGlobal.myTesting.LogSystem += string.Format("{0} \r\n", runAll.conbineChars("-", 80));
            myGlobal.myTesting.LogSystem += string.Format("... mac nhập từ tem là: {0}\r\n", myGlobal.myTesting.MacEthernet);
            myGlobal.myTesting.LogSystem += string.Format("... serial nhập từ tem là: {0}\r\n", myGlobal.myTesting.SerialNumber);
            myGlobal.myTesting.LogSystem += string.Format("... \r\n");
            myGlobal.myTesting.LogSystem += string.Format("... gen ra mac wlan 2g: {0}\r\n", myGlobal.myTesting.MacWlan2G);
            myGlobal.myTesting.LogSystem += string.Format("... gen ra mac wlan 5g: {0}\r\n", myGlobal.myTesting.MacWlan5G);

        }

        private string getMAC2G(string mac) {
            string hexMAC = "FAIL";
            try {
                int num = Int32.Parse(mac, System.Globalization.NumberStyles.HexNumber);
                num = num + 1;
                hexMAC = num.ToString("X").Trim();
                int hexMAC_len = hexMAC.Length;
                if (hexMAC_len < 6) {
                    for (int i = 0; i < 6 - hexMAC_len; i++) {
                        hexMAC = "0" + hexMAC;
                    }
                } else
                    if (hexMAC_len == 7) {
                    hexMAC = hexMAC.Substring(0, 6);
                }
            } catch { }

            return hexMAC;
        }

        private string getMAC5G(string mac) {
            string hexMAC = "FAIL";
            try {
                int num = Int32.Parse(mac, System.Globalization.NumberStyles.HexNumber);
                num = num + 2;
                hexMAC = num.ToString("X").Trim();
                int hexMAC_len = hexMAC.Length;
                if (hexMAC_len < 6) {
                    for (int i = 0; i < 6 - hexMAC_len; i++) {
                        hexMAC = "0" + hexMAC;
                    }
                } else
                    if (hexMAC_len == 7) {
                    hexMAC = hexMAC.Substring(0, 6);
                }
            } catch { }

            return hexMAC;
        }

    }
}
