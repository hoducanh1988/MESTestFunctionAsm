using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW12C.Function.Custom.Manual {

    public class ManualFirmwareInfo : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ManualFirmwareInfo() {
            initParams();
        }

        public void initParams() {
            LogSSH = "";
            FirmwareVersion = "-";
            FirmwareBuildTime = "-";
        }

        string _logssh;
        public string LogSSH {
            get { return _logssh; }
            set {
                _logssh = value;
                OnPropertyChanged(nameof(LogSSH));
            }
        }
        string _firmware_version;
        public string FirmwareVersion {
            get { return _firmware_version; }
            set {
                _firmware_version = value;
                OnPropertyChanged(nameof(FirmwareVersion));
            }
        }
        string _firmware_buildtime;
        public string FirmwareBuildTime {
            get { return _firmware_buildtime; }
            set {
                _firmware_buildtime = value;
                OnPropertyChanged(nameof(FirmwareBuildTime));
            }
        }
    }
}
