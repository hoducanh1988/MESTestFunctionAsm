using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EW30SX.UserCtrl;
using EW30SX.Function.Global;
using EW30SX.Function.Custom;
using System.Threading;

namespace EW30SX {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        List<Label> labels;
        Thread thrd_login = null;

        public MainWindow() {
            //init framework elements
            InitializeComponent();

            //
            labels = new List<Label>() { lblRunAll, lblManual, lblSetting, lblLog, lblHelp, lblAbout };

            //load run all tab
            grid_Content.Children.Clear();
            var _control = _load_User_Control("ucRunAll");
            if (_control != null) grid_Content.Children.Add(_control);

            //binding data
            this.DataContext = myGlobal.myWindowInfo;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e) {
            Label lb = sender as Label;

            //change label foreground --------------//
            foreach (var label in labels) label.Foreground = Brushes.Black;
            lb.Foreground = Brushes.Orange;

            //change under bar ---------------------//
            this.border_Underline.Margin = lb.Margin;
            this.border_Underline.Width = lb.Width - 10;

            //load control -------------------------//
            grid_Content.Children.Clear();
            string labelcontent = lb.Content.ToString();
            if (labelcontent.Equals("SETTING")) {
                myGlobal.myAuthorization = new AuthorizationInfo();
                var _control = _load_User_Control("ucLogin");
                if (_control != null) grid_Content.Children.Add(_control);

                thrd_login = new Thread(new ThreadStart(() => {
                    bool r = false;
                    while (true) {
                        if (myGlobal.myAuthorization.User == "admin" && myGlobal.myAuthorization.Password == "vnpt") {
                            r = true;
                            break;
                        }
                    }
                    App.Current.Dispatcher.Invoke(new Action(() => {
                        if (r) {
                            _control = _load_User_Control("ucSetting");
                            if (_control != null) grid_Content.Children.Add(_control);
                        }
                    }));
                }));
                thrd_login.IsBackground = true;
                thrd_login.Start();
            }
            else {
                if (thrd_login != null) thrd_login.Abort();
                var _control = _load_User_Control(convertText(lb.Content.ToString()));
                if (_control != null) grid_Content.Children.Add(_control);
            }
        }

        UserControl _load_User_Control(string classname) {
            UserControl myControl = null;
            try {
                switch (classname) {
                    case "ucRunAll": { myControl = new ucRunAll(); break; }
                    case "ucSetting": { myControl = new ucSetting(); break; }
                    case "ucManual": { myControl = new ucManual(); break; }
                    case "ucLog": { myControl = new ucLog(); break; }
                    case "ucHelp": { myControl = new ucHelp(); break; }
                    case "ucAbout": { myControl = new ucAbout(); break; }
                    case "ucLogin": { myControl = new ucLogin(); break; }
                }
            }
            catch { }
            return myControl;
        }

        string convertText(string text) {
            switch (text) {
                case "RUNALL": return "ucRunAll";
                case "MANUAL": return "ucManual";
                case "SETTING": return "ucSetting";
                case "LOG": return "ucLog";
                case "HELP": return "ucHelp";
                case "ABOUT": return "ucAbout";
                default: return null;
            }
        }


    }
}
