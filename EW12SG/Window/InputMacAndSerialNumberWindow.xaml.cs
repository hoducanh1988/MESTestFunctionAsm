using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UtilityPack.Validation;
using EW12SG.Function.Global;
using System.Text.RegularExpressions;


namespace EW12SG {
    /// <summary>
    /// Interaction logic for InputMacAndSerialNumberWindow.xaml
    /// </summary>
    public partial class InputMacAndSerialNumberWindow : Window {

        public string stampMac = "";
        public string stampSerial = "";
        StampInformation stamp = new StampInformation();
        string factory = "";
        string product_number = "";
        string hardware_version = "";
        string mac_code = "";

        public InputMacAndSerialNumberWindow(string fac, string p_number, string hw_ver, string m_code) {
            InitializeComponent();
            this.DataContext = this.stamp;

            this.factory = fac;
            this.product_number = p_number;
            this.hardware_version = hw_ver;
            this.mac_code = m_code;

            this.txtID.Focus();
        }


        private void TextBox_KeyDown(object sender, KeyEventArgs e) {
            TextBox tb = sender as TextBox;
            if (e.Key == Key.Enter) {
                bool isMac = false, isSN = false;
                string mac_pattern = "^[0-9,A-F]{12}$";
                isMac = Regex.IsMatch(stamp.MacEthernet, mac_pattern, RegexOptions.IgnoreCase);
                if (!isMac) goto RE;
                isSN = stamp.MacEthernet.Length == 12 && stamp.SerialNumber.Length == 15 ? UtilityPack.Validation.Parse.IsVnptProductSerialNumber(stamp.SerialNumber.ToUpper(), stamp.MacEthernet.ToUpper(), 12) : false;

            RE:
                bool r = isMac && isSN;
                if (r) {
                    //validate serial number
                    bool v = validateProductSerialNumber(stamp.SerialNumber.ToUpper(), stamp.MacEthernet.ToUpper(), this.factory, this.product_number, this.hardware_version, this.mac_code);
                    if (v) {
                        this.stampMac = stamp.MacEthernet;
                        this.stampSerial = stamp.SerialNumber;
                        this.Close();
                    }
                    else {
                        string mc = "";
                        string[] buffer = mac_code.Split(',');
                        foreach (var b in buffer) {
                            if (b.ToUpper().Contains(stamp.MacEthernet.Substring(0, 6).ToUpper())) {
                                mc = b.Split('=')[1].ToUpper();
                                break;
                            }
                        }

                        string sn = string.Format("{0}{1}{2}{3}{4}{5}", this.product_number, this.factory, stamp.SerialNumber.Substring(4, 3), this.hardware_version, mc, stamp.SerialNumber.Substring(9, 6));
                        stamp.Error = "Serial number \"" + stamp.SerialNumber + "\" sai thông tin product number//factory//mac code//hardware version!\n Serial đúng phải là: \"" + sn + "\"";
                        this.txtSN.Clear(); this.txtSN.Focus(); return;
                    }

                }
                else {
                    if (!isMac) {
                        if (stamp.MacEthernet.Length > 0) stamp.Error = "Mac address \"" + stamp.MacEthernet + "\" không đúng 12 kí tự hoặc kí tự không phải [0-9,A-F] hoặc 6 kí tự đầu tiên khác A4F4C2.";
                        this.txtID.Clear();
                        this.txtID.Focus();
                        return;
                    }
                    if (!isSN) {
                        if (stamp.SerialNumber.Length > 0) stamp.Error = "Serial number \"" + stamp.SerialNumber + "\" không đúng 15 kí tự hoặc 6 kí tự cuối sai khác với địa chỉ mac.";
                        this.txtSN.Clear();
                        this.txtSN.Focus();
                        return;
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            TextBox tb = sender as TextBox;
            if (tb.Text.Length > 0) stamp.Error = "";
        }

        bool validateProductSerialNumber(string serial, string mac, string fac, string p_number, string hw_ver, string m_code) {
            try {
                if (string.IsNullOrEmpty(serial)) return false;
                if (string.IsNullOrWhiteSpace(serial)) return false;
                if (serial.Length != 15) return false;

                string pn = serial.Substring(0, 3);
                string fc = serial.Substring(3, 1);
                string hv = serial.Substring(7, 1);

                if (!pn.Equals(p_number)) return false;
                if (!fc.Equals(fac)) return false;
                if (!hv.Equals(hw_ver)) return false;
                if (!Parse.IsMatchingMacCode(serial, mac, m_code)) return false;

                return true;
            }
            catch {
                return false;
            }
        }


        class StampInformation : INotifyPropertyChanged {

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name) {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }

            public StampInformation() {
                MacEthernet = "";
                SerialNumber = "";
                Error = "";
            }

            string _mac;
            public string MacEthernet {
                get { return _mac; }
                set {
                    _mac = value;
                    OnPropertyChanged(nameof(MacEthernet));
                }
            }
            string _sn;
            public string SerialNumber {
                get { return _sn; }
                set {
                    _sn = value;
                    OnPropertyChanged(nameof(SerialNumber));
                }
            }
            string _error;
            public string Error {
                get { return _error; }
                set {
                    _error = value;
                    OnPropertyChanged(nameof(Error));
                }
            }
        }

    }
}
