using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW12SG.Function.Custom.Manual
{

    public class ManualLanInfo : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ManualLanInfo() {
            initParams();
        }

        public void initParams() {
            LogSSH = "";
            LanSpeed = "-";
        }

        string _logssh;
        public string LogSSH {
            get { return _logssh; }
            set {
                _logssh = value;
                OnPropertyChanged(nameof(LogSSH));
            }
        }
        string _lan_speed;
        public string LanSpeed {
            get { return _lan_speed; }
            set {
                _lan_speed = value;
                OnPropertyChanged(nameof(LanSpeed));
            }
        }
    }

}
