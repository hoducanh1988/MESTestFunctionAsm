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
using System.Windows.Threading;
using EW30SX.Function.Global;

namespace EW30SX.UserCtrl
{
    /// <summary>
    /// Interaction logic for ucLogSSH.xaml
    /// </summary>
    public partial class ucLogSSH : UserControl
    {
        public ucLogSSH()
        {
            InitializeComponent();
            this.DataContext = myGlobal.myTesting;

            //control scroll view to end
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += (sender, e) => {
                if (myGlobal.myTesting.TotalResult == "Waiting...") {
                    this.Scr_LogSsh.ScrollToEnd();
                }
            };
            timer.Start();
        }
    }
}
