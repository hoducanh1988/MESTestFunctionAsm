using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW12CG.Function.Custom.Manual {

    public class ManualModelInfo : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ManualModelInfo() {
            initParams();
        }

        public void initParams() {
            LogSSH = "";
            ModelNumber = "-";
        }

        string _logssh;
        public string LogSSH {
            get { return _logssh; }
            set {
                _logssh = value;
                OnPropertyChanged(nameof(LogSSH));
            }
        }
        string _model_number;
        public string ModelNumber {
            get { return _model_number; }
            set {
                _model_number = value;
                OnPropertyChanged(nameof(ModelNumber));
            }
        }
    }
}
