using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW12C.Function.Custom.Manual {

    public class ManualWanInfo : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ManualWanInfo() {
            initParams();
        }

        public void initParams() {
            LogSSH = "";
            EthernetSpeed = "-";
        }

        string _logssh;
        public string LogSSH {
            get { return _logssh; }
            set {
                _logssh = value;
                OnPropertyChanged(nameof(LogSSH));
            }
        }
        string _ethernet_speed;
        public string EthernetSpeed {
            get { return _ethernet_speed; }
            set {
                _ethernet_speed = value;
                OnPropertyChanged(nameof(EthernetSpeed));
            }
        }
    }
}
