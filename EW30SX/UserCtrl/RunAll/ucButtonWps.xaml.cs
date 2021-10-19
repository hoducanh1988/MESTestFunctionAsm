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
using EW30SX.Function.Global;

namespace EW30SX.UserCtrl
{
    /// <summary>
    /// Interaction logic for ucButtonWps.xaml
    /// </summary>
    public partial class ucButtonWps : UserControl
    {
        public ucButtonWps()
        {
            InitializeComponent();
            this.DataContext = myGlobal.myTesting;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            RadioButton radio = sender as RadioButton;
            string rtag = (string)radio.Tag;

            switch (rtag) {
                case "buttonwps_passed": {
                        myGlobal.myTesting.ButtonWps = "Passed";
                        break;
                    }
                case "buttonwps_failed": {
                        myGlobal.myTesting.ButtonWps = "Failed";
                        break;
                    }
            }
        }
    }
}
