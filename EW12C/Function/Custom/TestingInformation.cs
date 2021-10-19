using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW12C.Function.Custom {

    public class TestingInformation : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //constructor
        public TestingInformation() {
            initParameter();
        }

        //method
        public void initParameter() {
            MacEthernet = "";
            MacWlan2G = "";
            MacWlan5G = "";
            SerialNumber = "";

            LogSystem = "";
            LogSSH = "";
            ErrorCode = "";
            ErrorMessage = "";

            LoginSSH = "-";
            WriteAndValidateSerialNumber = "-";
            ValidateMacAddress = "-";
            ValidateFirmwareVersion = "-";
            ValidateHardwareVersion = "-";
            ValidateModelNumber = "-";
            ValidateWanPort = "-";
            ValidateLed = "-";
            ValidateButton = "-";
            ButtonWps = "-";
            ButtonReset = "-";
            TotalResult = "-";


            TimeOutValidateLedWan = 90;
            TimeOutValidateButtonWps = 30;
            TimeOutValidateButtonReset = 30;
            
            StartButtonContent = "START";
            StartButtonEnable = true;
        }

        public void initWaiting() {
            LogSSH = "";
            ErrorCode = "";
            ErrorMessage = "";

            LoginSSH = "-";
            WriteAndValidateSerialNumber = "-";
            ValidateMacAddress = "-";
            ValidateFirmwareVersion = "-";
            ValidateHardwareVersion = "-";
            ValidateModelNumber = "-";
            ValidateWanPort = "-";
            ValidateLed = "-";
            ValidateButton = "-";
            ButtonWps = "-";
            ButtonReset = "-";
            TotalResult = "Waiting...";

            TimeOutValidateLedWan = 90;
            TimeOutValidateButtonWps = 30;
            TimeOutValidateButtonReset = 30;

            StartButtonContent = "STOP";
            StartButtonEnable = false;
        }

        public bool initPassed() {
            TotalResult = "Passed";

            StartButtonContent = "START";
            StartButtonEnable = true;
            return true;
        }

        public bool initFailed() {
            TotalResult = "Failed";

            StartButtonContent = "START";
            StartButtonEnable = true;
            return true;
        }

        //property

        #region //CÀI ĐẶT CHUNG ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

        string _mac_ethernet;
        public string MacEthernet {
            get { return _mac_ethernet; }
            set {
                _mac_ethernet = value;
                OnPropertyChanged(nameof(MacEthernet));
            }
        }
        string _mac_2g;
        public string MacWlan2G {
            get { return _mac_2g; }
            set {
                _mac_2g = value;
                OnPropertyChanged(nameof(MacWlan2G));
            }
        }
        string _mac_5g;
        public string MacWlan5G {
            get { return _mac_5g; }
            set {
                _mac_5g = value;
                OnPropertyChanged(nameof(MacWlan5G));
            }
        }
        string _sn;
        public string SerialNumber {
            get { return _sn; }
            set {
                _sn = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }

        #endregion

        #region //CÀI ĐẶT LƯU LOG ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

        string _logsystem;
        public string LogSystem {
            get { return _logsystem; }
            set {
                _logsystem = value;
                OnPropertyChanged(nameof(LogSystem));
            }
        }
        string _logssh;
        public string LogSSH {
            get { return _logssh; }
            set {
                _logssh = value;
                OnPropertyChanged(nameof(LogSSH));
            }
        }
        string _errorcode;
        public string ErrorCode {
            get { return _errorcode; }
            set {
                _errorcode = value;
                OnPropertyChanged(nameof(ErrorCode));
            }
        }
        string _errormessage;
        public string ErrorMessage {
            get { return _errormessage; }
            set {
                _errormessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        #endregion

        #region //CÀI ĐẶT KẾT QUẢ KIỂM TRA ~~~~~~~~~~~~~~~~~~~~~~~//

        string _login_ssh;
        public string LoginSSH {
            get { return _login_ssh; }
            set {
                _login_ssh = value;
                OnPropertyChanged(nameof(LoginSSH));
            }
        }
        string _write_and_validate_sn;
        public string WriteAndValidateSerialNumber {
            get { return _write_and_validate_sn; }
            set {
                _write_and_validate_sn = value;
                OnPropertyChanged(nameof(WriteAndValidateSerialNumber));
            }
        }
        string _validate_mac;
        public string ValidateMacAddress {
            get { return _validate_mac; }
            set {
                _validate_mac = value;
                OnPropertyChanged(nameof(ValidateMacAddress));
            }
        }
        string _validate_fw;
        public string ValidateFirmwareVersion {
            get { return _validate_fw; }
            set {
                _validate_fw = value;
                OnPropertyChanged(nameof(ValidateFirmwareVersion));
            }
        }
        string _validate_hw;
        public string ValidateHardwareVersion {
            get { return _validate_hw; }
            set {
                _validate_hw = value;
                OnPropertyChanged(nameof(ValidateHardwareVersion));
            }
        }
        string _validate_model;
        public string ValidateModelNumber {
            get { return _validate_model; }
            set {
                _validate_model = value;
                OnPropertyChanged(nameof(ValidateModelNumber));
            }
        }
        string _validate_wan;
        public string ValidateWanPort {
            get { return _validate_wan; }
            set {
                _validate_wan = value;
                OnPropertyChanged(nameof(ValidateWanPort));
            }
        }
        string _validate_led;
        public string ValidateLed {
            get { return _validate_led; }
            set {
                _validate_led = value;
                OnPropertyChanged(nameof(ValidateLed));
            }
        }
        string _validate_button;
        public string ValidateButton {
            get { return _validate_button; }
            set {
                _validate_button = value;
                OnPropertyChanged(nameof(ValidateButton));
            }
        }
        string _button_wps;
        public string ButtonWps {
            get { return _button_wps; }
            set {
                _button_wps = value;
                OnPropertyChanged(nameof(ButtonWps));
            }
        }
        string _button_reset;
        public string ButtonReset {
            get { return _button_reset; }
            set {
                _button_reset = value;
                OnPropertyChanged(nameof(ButtonReset));
            }
        }
        string _totalresult;
        public string TotalResult {
            get { return _totalresult; }
            set {
                _totalresult = value;
                OnPropertyChanged(nameof(TotalResult));
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
            }
        }
        bool _is_write_and_validate_serial_number;
        public bool IsWriteAndValidateSerialNumber {
            get { return _is_write_and_validate_serial_number; }
            set {
                _is_write_and_validate_serial_number = value;
                OnPropertyChanged(nameof(IsWriteAndValidateSerialNumber));
            }
        }
        bool _is_validate_mac;
        public bool IsValidateMacAddress {
            get { return _is_validate_mac; }
            set {
                _is_validate_mac = value;
                OnPropertyChanged(nameof(IsValidateMacAddress));
            }
        }
        bool _is_validate_fw;
        public bool IsValidateFirmwareVersion {
            get { return _is_validate_fw; }
            set {
                _is_validate_fw = value;
                OnPropertyChanged(nameof(IsValidateFirmwareVersion));
            }
        }
        bool _is_validate_hw;
        public bool IsValidateHardwareVersion {
            get { return _is_validate_hw; }
            set {
                _is_validate_hw = value;
                OnPropertyChanged(nameof(IsValidateHardwareVersion));
            }
        }
        bool _is_validate_model;
        public bool IsValidateModelNumber {
            get { return _is_validate_model; }
            set {
                _is_validate_model = value;
                OnPropertyChanged(nameof(IsValidateModelNumber));
            }
        }
        bool _is_validate_wan;
        public bool IsValidateWanPort {
            get { return _is_validate_wan; }
            set {
                _is_validate_wan = value;
                OnPropertyChanged(nameof(IsValidateWanPort));
            }
        }
        bool _is_validate_led;
        public bool IsValidateLed {
            get { return _is_validate_led; }
            set {
                _is_validate_led = value;
                OnPropertyChanged(nameof(IsValidateLed));
            }
        }
        bool _is_validate_button;
        public bool IsValidateButton {
            get { return _is_validate_button; }
            set {
                _is_validate_button = value;
                OnPropertyChanged(nameof(IsValidateButton));
            }
        }
        #endregion

        #region //BUTTON START ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

        string _startbuttoncontent;
        public string StartButtonContent {
            get { return _startbuttoncontent; }
            set {
                _startbuttoncontent = value;
                OnPropertyChanged(nameof(StartButtonContent));
            }
        }
        bool _startbuttonenable;
        public bool StartButtonEnable {
            get { return _startbuttonenable; }
            set {
                _startbuttonenable = value;
                OnPropertyChanged(nameof(StartButtonEnable));
            }
        }

        #endregion

        #region //TIMEOUT ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

        int _timeout_led;
        public int TimeOutValidateLedWan {
            get { return _timeout_led; }
            set {
                _timeout_led = value;
                OnPropertyChanged(nameof(TimeOutValidateLedWan));
            }
        }
        int _timeout_button_wps;
        public int TimeOutValidateButtonWps {
            get { return _timeout_button_wps; }
            set {
                _timeout_button_wps = value;
                OnPropertyChanged(nameof(TimeOutValidateButtonWps));
            }
        }
        int _timeout_button_reset;
        public int TimeOutValidateButtonReset {
            get { return _timeout_button_reset; }
            set {
                _timeout_button_reset = value;
                OnPropertyChanged(nameof(TimeOutValidateButtonReset));
            }
        }



        #endregion
    }
}
