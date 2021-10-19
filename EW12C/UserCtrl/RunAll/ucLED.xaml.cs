using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EW12C.Function.Custom;
using EW12C.Function.DUT;
using EW12C.Function.Global;


namespace EW12C.UserCtrl {
    /// <summary>
    /// Interaction logic for ucLED.xaml
    /// </summary>
    public partial class ucLED : UserControl {

        meshAP<TestingInformation> mesh = null;
        volatile bool flag_thread = false;

        public ucLED(meshAP<TestingInformation> _mesh) {
            InitializeComponent();
            this.mesh = _mesh;

            this.DataContext = myGlobal.myTesting;

            Thread t = new Thread(new ThreadStart(() => {
                while (!flag_thread) {
                    mesh.setLedWanBrightOff();
                    Thread.Sleep(500);
                    mesh.setLedWanBrightGreen();
                    Thread.Sleep(500);
                    mesh.setLedWanBrightRed();
                    Thread.Sleep(500);
                    //mesh.setLedWanBrightYellow();
                    //Thread.Sleep(500);
                }
            }));
            t.IsBackground = true;
            t.Start();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            RadioButton radio = sender as RadioButton;
            string rtag = (string)radio.Tag;

            switch (rtag) {
                case "ledwan_passed": {
                        myGlobal.myTesting.ValidateLed = "Passed";
                        flag_thread = true;
                        break;
                    }
                case "ledwan_failed": {
                        myGlobal.myTesting.ValidateLed = "Failed";
                        flag_thread = true;
                        break;
                    }
            }
        }

    }
}
