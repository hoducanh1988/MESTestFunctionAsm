using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EW12C.Function.Global;

namespace EW12C.Function.Custom {

    public class SettingInformation : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //constructor
        public SettingInformation() {

            Factory = "1";
            LineCode = "1";
            StationName = "-";
            StationNumber = "1";
            WorkOrder = "#12345";
            Operator = "Nguyen Van A";

            IPAddress = "192.168.88.1";
            SshUser = "root";
            SshPassword = "vnpt";
            MacHeader = "A06518:A4F4C2:D49AA0";
            VnptMacCode = "A06518=2,A4F4C2=3,D49AA0=4";
            FirmwareVersion = "EW12_02RTM";
            HardwareVersion = "EW12HCv1.0";
            ModelNumber = "EW12C";
            SpeedEthernet = "100";

            FileProduct = "";
            ProductName = "";
            ProductNumber = "";
            ProductColor = "";

            IsLoginSSH = true;
            IsWriteAndValidateSerialNumber = true;
            IsValidateMacAddress = true;
            IsValidateFirmwareVersion = true;
            IsValidateHardwareVersion = true;
            IsValidateModelNumber = true;
            IsValidateWanPort = true;
            IsValidateLed = true;
            IsValidateButton = true;

            LogDirectory = "D:\\LOGDATA";
        }

        //property
        #region //CÀI ĐẶT TRẠM TEST ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

        string _factory;
        public string Factory {
            get { return _factory; }
            set {
                _factory = value;
                OnPropertyChanged(nameof(Factory));
            }
        }
        string _line_code;
        public string LineCode {
            get { return _line_code; }
            set {
                _line_code = value;
                OnPropertyChanged(nameof(LineCode));
            }
        }
        string _station_name;
        public string StationName {
            get { return _station_name; }
            set {
                _station_name = value;
                OnPropertyChanged(nameof(StationName));
            }
        }
        string _station_number;
        public string StationNumber {
            get { return _station_number; }
            set {
                _station_number = value;
                OnPropertyChanged(nameof(StationNumber));
            }
        }
        string _work_order;
        public string WorkOrder {
            get { return _work_order; }
            set {
                _work_order = value;
                OnPropertyChanged(nameof(WorkOrder));
            }
        }
        string _operator;
        public string Operator {
            get { return _operator; }
            set {
                _operator = value;
                OnPropertyChanged(nameof(Operator));
            }
        }
        #endregion

        #region //CÀI ĐẶT THÔNG TIN IMAP ~~~~~~~~~~~~~~~~~~~~~~~~~//

        string _ip_address;
        public string IPAddress {
            get { return _ip_address; }
            set {
                _ip_address = value;
                OnPropertyChanged(nameof(IPAddress));
            }
        }
        string _ssh_user;
        public string SshUser {
            get { return _ssh_user; }
            set {
                _ssh_user = value;
                OnPropertyChanged(nameof(SshUser));
            }
        }
        string _ssh_password;
        public string SshPassword {
            get { return _ssh_password; }
            set {
                _ssh_password = value;
                OnPropertyChanged(nameof(SshPassword));
            }
        }
        string _mac_header;
        public string MacHeader {
            get { return _mac_header; }
            set {
                _mac_header = value;
                OnPropertyChanged(nameof(MacHeader));
            }
        }
        string _vnpt_mac_code;
        public string VnptMacCode {
            get { return _vnpt_mac_code; }
            set {
                _vnpt_mac_code = value;
                OnPropertyChanged(nameof(VnptMacCode));
            }
        }
        string _firmware_version;
        public string FirmwareVersion {
            get { return _firmware_version; }
            set {
                _firmware_version = value;
                OnPropertyChanged(nameof(FirmwareVersion));
            }
        }
        string _hardware_version;
        public string HardwareVersion {
            get { return _hardware_version; }
            set {
                _hardware_version = value;
                OnPropertyChanged(nameof(HardwareVersion));
            }
        }
        string _model_number;
        public string ModelNumber {
            get { return _model_number; }
            set {
                _model_number = value;
                OnPropertyChanged(nameof(ModelNumber));
            }
        }
        string _speed_ethernet;
        public string SpeedEthernet {
            get { return _speed_ethernet; }
            set {
                _speed_ethernet = value;
                OnPropertyChanged(nameof(SpeedEthernet));
            }
        }
        #endregion

        #region //CÀI ĐẶT THAM SỐ VERIFY SERIAL NUMBER ~~~~~~~~~~~//

        string _file_product;
        public string FileProduct {
            get { return _file_product; }
            set {
                _file_product = value;
                OnPropertyChanged(nameof(FileProduct));
            }
        }
        string _product_name;
        public string ProductName {
            get { return _product_name; }
            set {
                _product_name = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }
        string _product_number;
        public string ProductNumber {
            get { return _product_number; }
            set {
                _product_number = value;
                OnPropertyChanged(nameof(ProductNumber));
            }
        }
        string _product_color;
        public string ProductColor {
            get { return _product_color; }
            set {
                _product_color = value;
                OnPropertyChanged(nameof(ProductColor));
            }
        }
        #endregion

        #region //CÀI ĐẶT BÀI TEST ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        bool _is_login_ssh;
        public bool IsLoginSSH {
            get { return _is_login_ssh; }
            set {
                _is_login_ssh = value;
                OnPropertyChanged(nameof(IsLoginSSH));
                //
                myGlobal.myTesting.IsLoginSSH = value;
            }
        }
        bool _is_write_and_validate_serial_number;
        public bool IsWriteAndValidateSerialNumber {
            get { return _is_write_and_validate_serial_number; }
            set {
                _is_write_and_validate_serial_number = value;
                OnPropertyChanged(nameof(IsWriteAndValidateSerialNumber));
                //
                myGlobal.myTesting.IsWriteAndValidateSerialNumber = value;
            }
        }
        bool _is_validate_mac;
        public bool IsValidateMacAddress {
            get { return _is_validate_mac; }
            set {
                _is_validate_mac = value;
                OnPropertyChanged(nameof(IsValidateMacAddress));
                //
                myGlobal.myTesting.IsValidateMacAddress = value;
            }
        }
        bool _is_validate_fw;
        public bool IsValidateFirmwareVersion {
            get { return _is_validate_fw; }
            set {
                _is_validate_fw = value;
                OnPropertyChanged(nameof(IsValidateFirmwareVersion));
                //
                myGlobal.myTesting.IsValidateFirmwareVersion = value;
            }
        }
        bool _is_validate_hw;
        public bool IsValidateHardwareVersion {
            get { return _is_validate_hw; }
            set {
                _is_validate_hw = value;
                OnPropertyChanged(nameof(IsValidateHardwareVersion));
                //
                myGlobal.myTesting.IsValidateHardwareVersion = value;
            }
        }
        bool _is_validate_model;
        public bool IsValidateModelNumber {
            get { return _is_validate_model; }
            set {
                _is_validate_model = value;
                OnPropertyChanged(nameof(IsValidateModelNumber));
                //
                myGlobal.myTesting.IsValidateModelNumber = value;
            }
        }
        bool _is_validate_wan;
        public bool IsValidateWanPort {
            get { return _is_validate_wan; }
            set {
                _is_validate_wan = value;
                OnPropertyChanged(nameof(IsValidateWanPort));
                //
                myGlobal.myTesting.IsValidateWanPort = value;
            }
        }
        bool _is_validate_led;
        public bool IsValidateLed {
            get { return _is_validate_led; }
            set {
                _is_validate_led = value;
                OnPropertyChanged(nameof(IsValidateLed));
                //
                myGlobal.myTesting.IsValidateLed = value;
            }
        }
        bool _is_validate_button;
        public bool IsValidateButton {
            get { return _is_validate_button; }
            set {
                _is_validate_button = value;
                OnPropertyChanged(nameof(IsValidateButton));
                //
                myGlobal.myTesting.IsValidateButton = value;
            }
        }
        #endregion

        #region //CÀI ĐẶT LƯU LOG ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

        string _log_dir;
        public string LogDirectory {
            get { return _log_dir; }
            set {
                _log_dir = value;
                OnPropertyChanged(nameof(LogDirectory));
            }
        }
        #endregion

    }
}
