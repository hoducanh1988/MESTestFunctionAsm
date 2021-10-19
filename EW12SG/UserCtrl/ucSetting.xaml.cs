using System;
using System.Collections.Generic;
using System.IO;
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
using EW12SG.Function.Custom;
using EW12SG.Function.Global;
using UtilityPack.IO;

namespace EW12SG.UserCtrl {
    /// <summary>
    /// Interaction logic for ucSetting.xaml
    /// </summary>
    public partial class ucSetting : UserControl {

        //new 8.8.2019
        List<ProductInformation> myProducts = new List<ProductInformation>();

        public ucSetting() {
            //init control
            InitializeComponent();

            //load setting from file
            if (File.Exists(myGlobal.settingFileFullName)) myGlobal.mySetting = XmlHelper<SettingInformation>.FromXmlFile(myGlobal.settingFileFullName);

            //binding data
            this.DataContext = myGlobal.mySetting;

            //new 8.8.2019
            var Indexers = new List<string>();
            var Stations = new List<string>();
            List<SuggestionText> suggestiontexts = GetSuggestionTexts();
            if (suggestiontexts != null) {
                foreach (var x in suggestiontexts) {
                    if (string.IsNullOrEmpty(x.index) == false && string.IsNullOrWhiteSpace(x.index) == false) {
                        Indexers.Add(x.index);
                    }
                    if (string.IsNullOrEmpty(x.station) == false && string.IsNullOrWhiteSpace(x.station) == false) {
                        Stations.Add(x.station);
                    }
                }
            }
            cbbFactory.ItemsSource = cbbLine.ItemsSource = cbbStationNumber.ItemsSource =  Indexers;
            cbbStationName.ItemsSource = Stations;
        }


        private void ComboBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e) {
            e.Handled = !((ComboBox)sender).IsDropDownOpen;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;
            string _tag = b.Tag.ToString();

            switch (_tag) {
                //new 8.8.2019
                case "select_file_product": {
                        System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
                        fileDialog.InitialDirectory = string.Format("{0}conf_", myGlobal.dir_Path);
                        fileDialog.Filter = "*.csv|*.csv";
                        if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                            //get csv file
                            myGlobal.mySetting.FileProduct = fileDialog.SafeFileName;
                        }
                        break;
                    }
                case "save_setting": {
                        XmlHelper<SettingInformation>.ToXmlFile(myGlobal.mySetting, myGlobal.settingFileFullName); //save setting to xml file
                        MessageBox.Show("Success.", "Save Setting", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }
                case "change_mac_code": {
                        rtb_maccode.IsEnabled = true;
                        break;
                    }
            }
        }


        //new 8.8.2019
        private void Cbb_product_name_DropDownOpened(object sender, EventArgs e) {

            if (myGlobal.mySetting == null) return;
            if (string.IsNullOrEmpty(myGlobal.mySetting.FileProduct)) return;

            myProducts = getProducts(myGlobal.mySetting.FileProduct);
            if (myProducts != null) {
                this.cbb_product_name.ItemsSource = myProducts.Select(x => x.name).ToList();
            }
        }

        //new 8.8.2019
        private void Cbb_product_name_DropDownClosed(object sender, EventArgs e) {
            if (myProducts == null) return;
            if (this.cbb_product_name.SelectedItem == null) return;

            string _item_name = this.cbb_product_name.SelectedItem.ToString();
            myGlobal.mySetting.ProductName = _item_name;
            foreach (var item in myProducts) {
                if (item.name.ToLower().Equals(_item_name.ToLower())) {
                    myGlobal.mySetting.ProductNumber = item.number;
                    myGlobal.mySetting.ProductColor = item.color;
                }
            }
        }

        //new 8.8.2019
        List<ProductInformation> getProducts(string file_name) {
            try {
                return CsvHelper<ProductInformation>.FromCsvFile(string.Format("{0}conf_\\{1}", myGlobal.dir_Path, file_name), Encoding.Unicode, ",");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //new 8.8.2019
        List<SuggestionText> GetSuggestionTexts() {
            try {
                return CsvHelper<SuggestionText>.FromCsvFile(string.Format("{0}ref_\\SuggestionText.csv", myGlobal.dir_Path), Encoding.Unicode, ",");
            }
            catch {
                return null;
            }
        }
    }
}
