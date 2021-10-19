using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW12SG.Function.Custom.Manual {

    public class ManualMacInfo : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ManualMacInfo() {
            initParams();
        }

        public void initParams() {
            LogSSH = "";
            MacEthernet = "-";
            MacWlan2G = "-";
            MacWlan5G = "-";
        }

        string _logssh;
        public string LogSSH {
            get { return _logssh; }
            set {
                _logssh = value;
                OnPropertyChanged(nameof(LogSSH));
            }
        }
        string _mac_ethernet;
        public string MacEthernet {
            get { return _mac_ethernet; }
            set {
                _mac_ethernet = value;
                OnPropertyChanged(nameof(MacEthernet));
            }
        }
        string _mac_wlan_2g;
        public string MacWlan2G {
            get { return _mac_wlan_2g; }
            set {
                _mac_wlan_2g = value;
                OnPropertyChanged(nameof(MacWlan2G));
            }
        }
        string _mac_wlan_5g;
        public string MacWlan5G {
            get { return _mac_wlan_5g; }
            set {
                _mac_wlan_5g = value;
                OnPropertyChanged(nameof(MacWlan5G));
            }
        }
    }
}
