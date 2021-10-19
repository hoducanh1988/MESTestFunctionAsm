using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW12C.Function.Custom {

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
        }

        double _opacity;
        public double WindowOpacity {
            get { return _opacity; }
            set {
                _opacity = value;
                OnPropertyChanged(nameof(WindowOpacity));
            }
        }
    }
}
