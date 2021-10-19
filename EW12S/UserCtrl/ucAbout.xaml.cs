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

namespace EW12S.UserCtrl {
    /// <summary>
    /// Interaction logic for ucAbout.xaml
    /// </summary>
    public partial class ucAbout : UserControl {

        private class history {
            public string ID { get; set; }
            public string VERSION { get; set; }
            public string CONTENT { get; set; }
            public string DATE { get; set; }
            public string CHANGETYPE { get; set; }
            public string PERSON { get; set; }
        }
        List<history> listHist = new List<history>();

        public ucAbout() {
            InitializeComponent();

            listHist.Add(new history() {
                ID = "1",
                VERSION = "2.0.0.0",
                CONTENT = "- Chuyển giao diện từ winform sang wpf.\n" +
                          "- Lưu log theo định dạng BCN\n" +
                          "- Chỉnh sửa tool test theo firmware basic mới\n" +
                          "- Thêm chức năng ghi và check số serial number",
                DATE = "2019/08/21",
                CHANGETYPE = "Chỉnh sửa",
                PERSON = "Hồ Đức Anh"
            });

            listHist.Add(new history() {
                ID = "2",
                VERSION = "2.0.0.1",
                CONTENT = "- Thay đổi thời gian timeout khi check ping mạng tới IMAP (192.168.88.1) từ 3s => 20s.\n" +
                          "- Thay đổi lệnh đọc mac wlan 2g từ grep 1000 => grep 0001000 để tránh đọc nhầm.\n" +
                          "- Thay đổi lệnh đọc mac wlan 5g từ grep 5000 => grep 0005000 để tránh đọc nhầm.",
                DATE = "2019/08/28",
                CHANGETYPE = "Chỉnh sửa",
                PERSON = "Hồ Đức Anh"
            });
            listHist.Add(new history() {
                ID = "3",
                VERSION = "2.0.0.2",
                CONTENT = "- Cập nhật tool cho dải địa chỉ mac mới D49AA0.",
                DATE = "2019/10/25",
                CHANGETYPE = "Chỉnh sửa",
                PERSON = "Hồ Đức Anh"
            });
            listHist.Add(new history() {
                ID = "4",
                VERSION = "2.0.0.3",
                CONTENT = "- Cập nhật tool cho định dạng số serial number mới thay đổi mã màu sang mã phân biệt dải mac.",
                DATE = "2019/12/25",
                CHANGETYPE = "Chỉnh sửa",
                PERSON = "Hồ Đức Anh"
            });
            listHist.Add(new history() {
                ID = "4",
                VERSION = "2.0.0.4",
                CONTENT = "- Tối ưu thời gian test led từ click từng nút chuyển trạng thái sang tự động.",
                DATE = "2020/09/03",
                CHANGETYPE = "Chỉnh sửa",
                PERSON = "Hồ Đức Anh"
            });
            listHist.Add(new history() {
                ID = "4",
                VERSION = "2.0.0.5",
                CONTENT = "- Update tool bỏ test led vàng.",
                DATE = "2021/01/29",
                CHANGETYPE = "Chỉnh sửa",
                PERSON = "Hồ Đức Anh"
            });

            this.GridAbout.ItemsSource = listHist;
        }
    }
}
