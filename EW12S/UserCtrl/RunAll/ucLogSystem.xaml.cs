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
using EW12S.Function.Global;

namespace EW12S.UserCtrl
{
    /// <summary>
    /// Interaction logic for ucLogSystem.xaml
    /// </summary>
    public partial class ucLogSystem : UserControl
    {
        public ucLogSystem()
        {
            InitializeComponent();
            this.DataContext = myGlobal.myTesting;

            //control scroll view to end
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += (sender, e) => {
                if (myGlobal.myTesting.TotalResult == "Waiting...") {
                    this.Scr_LogSystem.ScrollToEnd();
                }
            };
            timer.Start();
        }
    }
}
