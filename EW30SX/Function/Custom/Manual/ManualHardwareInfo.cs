using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW30SX.Function.Custom.Manual {

    public class ManualHardwareInfo : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ManualHardwareInfo() {
            initParams();
        }

        public void initParams() {
            LogSSH = "";
            HardwareVersion = "-";
        }

        string _logssh;
        public string LogSSH {
            get { return _logssh; }
            set {
                _logssh = value;
                OnPropertyChanged(nameof(LogSSH));
            }
        }
        string _hardware_version;
        public string HardwareVersion {
            get { return _hardware_version; }
            set {
                _hardware_version = value;
                OnPropertyChanged(nameof(HardwareVersion));
            }
        }
    }
}
