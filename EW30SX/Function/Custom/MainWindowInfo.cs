using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW30SX.Function.Custom {

    public class MainWindowInfo : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowInfo() {
            WindowOpacity = 1;
            appInfo = "Version EW30SXVN0U0001 - Build date 30/09/2021 15:45 - Copyright of VNPT Technology 2021";
        }

        double _opacity;
        public double WindowOpacity {
            get { return _opacity; }
            set {
                _opacity = value;
                OnPropertyChanged(nameof(WindowOpacity));
            }
        }
        string _app_info;
        public string appInfo {
            get { return _app_info; }
            set {
                _app_info = value;
                OnPropertyChanged(nameof(appInfo));
            }
        }
    }
}
