using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW12SG.Function.Custom.Manual {

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
            WanSpeed = "-";
        }

        string _logssh;
        public string LogSSH {
            get { return _logssh; }
            set {
                _logssh = value;
                OnPropertyChanged(nameof(LogSSH));
            }
        }
        string _wan_speed;
        public string WanSpeed {
            get { return _wan_speed; }
            set {
                _wan_speed = value;
                OnPropertyChanged(nameof(WanSpeed));
            }
        }
    }
}
