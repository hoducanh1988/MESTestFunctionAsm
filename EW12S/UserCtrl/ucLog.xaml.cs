using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using EW12S.Function.Global;

namespace EW12S.UserCtrl {
    /// <summary>
    /// Interaction logic for ucLog.xaml
    /// </summary>
    public partial class ucLog : UserControl {
        public ucLog() {
            InitializeComponent();

            this.cbb_logtype.ItemsSource = new List<string>() { "LogDetail", "LogTotal" };
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;
            string btag = (string)b.Tag;
            string logtype = (string)cbb_logtype.SelectedValue;
            if (logtype == null) return;

            switch (btag) {
                case "go": {
                        logtype = logtype.ToLower();
                        if (logtype.Equals("logdetail")) {
                            try {
                                Process.Start(myGlobal.detailDirectory);
                            }
                            catch {
                                Process.Start(myGlobal.dir_Path);
                            }

                        }
                        if (logtype.Equals("logtotal")) {
                            try {
                                Process.Start(myGlobal.totalDirectory);
                            }
                            catch {
                                Process.Start(myGlobal.dir_Path);
                            }
                        }
                        break;
                    }
            }

        }
    }
}
