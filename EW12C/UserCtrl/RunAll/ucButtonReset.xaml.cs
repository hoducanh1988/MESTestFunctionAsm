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
using EW12C.Function.Global;

namespace EW12C.UserCtrl
{
    /// <summary>
    /// Interaction logic for ucButtonReset.xaml
    /// </summary>
    public partial class ucButtonReset : UserControl
    {
        public ucButtonReset()
        {
            InitializeComponent();
            this.DataContext = myGlobal.myTesting;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            RadioButton radio = sender as RadioButton;
            string rtag = (string)radio.Tag;

            switch (rtag) {
                case "buttonreset_passed": {
                        myGlobal.myTesting.ButtonReset = "Passed";
                        break;
                    }
                case "buttonreset_failed": {
                        myGlobal.myTesting.ButtonReset = "Failed";
                        break;
                    }
            }
        }
    }
}
