using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW12CG.Function.Custom.Manual {

    public class ManualSerialInfo : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ManualSerialInfo() {
            initParams();
        }

        public void initParams() {
            LogSSH = "";
            MeshSerialNumber = "-";

        }

        string _logssh;
        public string LogSSH {
            get { return _logssh; }
            set {
                _logssh = value;
                OnPropertyChanged(nameof(LogSSH));
            }
        }
        string _mesh_serial;
        public string MeshSerialNumber {
            get { return _mesh_serial; }
            set {
                _mesh_serial = value;
                OnPropertyChanged(nameof(MeshSerialNumber));
            }
        }
        string _stamp_serial;
        public string StampSerialNumber {
            get { return _stamp_serial; }
            set {
                _stamp_serial = value;
                OnPropertyChanged(nameof(StampSerialNumber));
            }
        }

    }
}
