using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Controls;
using EW12C.Function.Global;
using EW12C.Function.Custom;
using EW12C.Function.DUT;
using EW12C.Function.Protocol;
using EW12C.UserCtrl;
using EW12C.Function.IO;

namespace EW12C.Function.Excute {

    public class runAll {

        class validateinfo {
            public string resultVariable { get; set; }
            public string Title { get; set; }
            public string standardValue { get; set; }
            public string meshMethod { get; set; }
            public int retry { get; set; }
        }

        TestingInformation myTesting = myGlobal.myTesting;
        SettingInformation mySetting = myGlobal.mySetting;
        meshAP<TestingInformation> mesh = null;
        Grid grid_container = null;

        Dictionary<string, validateinfo> dictValidateItem = new Dictionary<string, validateinfo>() {
            { "serial", new validateinfo() { Title = "KIỂM TRA THÔNG TIN SERIAL NUMBER",
                                                      resultVariable = "WriteAndValidateSerialNumber",
                                                      standardValue = myGlobal.myTesting.SerialNumber,
                                                      meshMethod = "getSerialNumber",
                                                      retry = 3 }},
            { "maclan", new validateinfo() { Title = "KIỂM TRA THÔNG TIN MAC ETHERNET",
                                                      resultVariable = "ValidateMacAddress",
                                                      standardValue = myGlobal.myTesting.MacEthernet,
                                                      meshMethod = "getMacEthernet",
                                                      retry = 3 }},
            { "macwlan2g", new validateinfo() { Title = "KIỂM TRA THÔNG TIN MAC WLAN 2G",
                                                      resultVariable = "ValidateMacAddress",
                                                      standardValue = myGlobal.myTesting.MacWlan2G,
                                                      meshMethod = "getMacWlan2G",
                                                      retry = 3 }},
            { "macwlan5g", new validateinfo() { Title = "KIỂM TRA THÔNG TIN MAC WLAN 5G",
                                                      resultVariable = "ValidateMacAddress",
                                                      standardValue = myGlobal.myTesting.MacWlan5G,
                                                      meshMethod = "getMacWlan5G",
                                                      retry = 3 }},
            { "firmware", new validateinfo() { Title = "KIỂM TRA THÔNG TIN FIRMWARE VERSION",
                                                      resultVariable = "ValidateFirmwareVersion",
                                                      standardValue = myGlobal.mySetting.FirmwareVersion,
                                                      meshMethod = "getFirmwareVersion",
                                                      retry = 3 }},
            { "hardware", new validateinfo() { Title = "KIỂM TRA THÔNG TIN HARDWARE VERSION",
                                                      resultVariable = "ValidateHardwareVersion",
                                                      standardValue = myGlobal.mySetting.HardwareVersion,
                                                      meshMethod = "getHardwareVersion",
                                                      retry = 3 }},
            { "model", new validateinfo() { Title = "KIỂM TRA THÔNG TIN MODEL NUMBER",
                                                      resultVariable = "ValidateModelNumber",
                                                      standardValue = myGlobal.mySetting.ModelNumber,
                                                      meshMethod = "getModelNumber",
                                                      retry = 3 }},
            { "wanspeed", new validateinfo() { Title = "KIỂM TRA THÔNG TIN SPEED ETHERNET",
                                                      resultVariable = "ValidateWanPort",
                                                      standardValue = myGlobal.mySetting.SpeedEthernet,
                                                      meshMethod = "getWanSpeed",
                                                      retry = 3 }},
        };

        public runAll(Grid grid) {
            this.grid_container = grid;
        }

        public bool Excute() {
            var st = new Stopwatch();
            st.Start();
            bool r = true;
            myTesting.initWaiting();
            myGlobal.myLogTotal = new IO.VnptAsmTestFunctionLogInfo();
            var myLogTotal = myGlobal.myLogTotal;

            //---------------------------------------//
            //1. login to imap
            if (myTesting.IsLoginSSH) {
                r = pingToMesh();
                if (!r) {
                    myLogTotal.LoginSSH.Result = "Failed";
                    goto END;
                }

                r = loginSshToMesh();
                myLogTotal.LoginSSH.Result = r ? "Passed" : "Failed";
                if (!r) goto END;
            }

            //2. write and validate serial number
            //---------------------------------------//
            if (myTesting.IsWriteAndValidateSerialNumber) {
                r = setMeshSerialNumber();
                if (!r) {
                    myLogTotal.WriteSerial.Result = "Failed";
                    goto END;
                }
                r = validateItem(dictValidateItem["serial"]);
                myLogTotal.WriteSerial.Result = r ? "Passed" : "Failed";
                if (!r) goto END;
            }

            //3. validate mac lan, wlan 2g, wlan 5g
            //---------------------------------------//
            if (myTesting.IsValidateMacAddress) {
                r = validateItem(dictValidateItem["maclan"]);
                if (!r) {
                    myLogTotal.CheckMac.Result = "Failed";
                    goto END;
                }
                r = validateItem(dictValidateItem["macwlan2g"]);
                if (!r) {
                    myLogTotal.CheckMac.Result = "Failed";
                    goto END;
                }
                r = validateItem(dictValidateItem["macwlan5g"]);
                myLogTotal.CheckMac.Result = r ? "Passed" : "Failed";
                if (!r) goto END;
            }

            //4. validate firmware version
            //---------------------------------------//
            if (myTesting.IsValidateFirmwareVersion) {
                r = validateItem(dictValidateItem["firmware"]);
                myLogTotal.CheckFirmware.Result = r ? "Passed" : "Failed";
                if (!r) goto END;
            }

            //5. validate hardware version
            //---------------------------------------//
            if (myTesting.IsValidateHardwareVersion) {
                r = validateItem(dictValidateItem["hardware"]);
                myLogTotal.CheckHardware.Result = r ? "Passed" : "Failed";
                if (!r) goto END;
            }

            //6. validate model number
            //---------------------------------------//
            if (myTesting.IsValidateModelNumber) {
                r = validateItem(dictValidateItem["model"]);
                myLogTotal.CheckModel.Result = r ? "Passed" : "Failed";
                if (!r) goto END;
            }

            //7. validate wan port
            //---------------------------------------//
            if (myTesting.IsValidateWanPort) {
                r = validateItem(dictValidateItem["wanspeed"]);
                myLogTotal.CheckWan.Result = r ? "Passed" : "Failed";
                if (!r) goto END;
            }

            //8. validate led
            //---------------------------------------//
            if (myTesting.IsValidateLed) {
                r = validateLedWan();
                myLogTotal.CheckLed.Result = r ? "Passed" : "Failed";
                if (!r) goto END;
            }

            //9. validate button
            //---------------------------------------//
            if (myTesting.IsValidateButton) {
                r = validateButtonWps();
                if (!r) {
                    myLogTotal.CheckButton.Result = "Failed";
                    goto END;
                }
                r = validateButtonReset();
                myLogTotal.CheckButton.Result = r ? "Passed" : "Failed";
                if (!r) goto END;
            }

            END:

            bool ___ = r ? myTesting.initPassed() : myTesting.initFailed();
            myTesting.LogSystem += string.Format("\r\n### KẾT THÚC KIỂM TRA ###\r\n");
            myTesting.LogSystem += string.Format("{0} \r\n", conbineChars("-", 80));
            myTesting.LogSystem += string.Format("... kết quả kiểm tra sản phẩm là: {0}\r\n", r ? "Passed" : "Failed");
            if (!r) {
                myTesting.LogSystem += string.Format("... item lỗi: {0}\r\n", myTesting.ErrorCode);
                myTesting.LogSystem += string.Format("... thông tin lỗi: {0}\r\n", myTesting.ErrorMessage);
            }
            st.Stop();
            myTesting.LogSystem += string.Format("... tổng thời gian: {0} ms\r\n", st.ElapsedMilliseconds);
            if (mesh != null && mesh.IsConnected) { mesh.Close(); mesh = null; }

            //save log detail
            new LogDetailFile().createLog();

            //save log total
            new LogTotalFile().createLog(myGlobal.myLogTotal, new VnptLogMoreInfo());

            return r;
        }


        bool validateItem(validateinfo info) {
            Stopwatch st = new Stopwatch();
            st.Start();

            //
            setTestingPropertyValue(info.resultVariable, "Waiting...");

            //show standard value
            myTesting.LogSystem += string.Format("\r\n### {0} ###\r\n", info.Title);
            myTesting.LogSystem += string.Format("{0} \r\n", conbineChars("-", 80));
            myTesting.LogSystem += string.Format("... tiêu chuẩn: \"{0}\"\r\n", info.standardValue);
            myTesting.LogSystem += string.Format("... \r\n");
            bool r = false;
            int count = 0;
        RE:
            count++;
            //get actual value
            MethodInfo mesh_method = mesh.GetType().GetMethod(info.meshMethod);
            string act_value = (string)mesh_method.Invoke(mesh, null);

            //compare
            act_value = act_value == null ? "" : act_value;
            //r = act_value.ToLower().Contains(info.standardValue.ToLower());
            r = act_value.ToLower().Equals(info.standardValue.ToLower());
            myTesting.LogSystem += string.Format("... thực tế [lần {1}/{3}]: \"{0}\" => {2}\r\n", act_value, count, r ? "Passed" : "Failed", info.retry);
            if (!r) {
                if (count < info.retry) {
                    goto RE;
                }
            }

            //return result
            setTestingPropertyValue(info.resultVariable, r ? "Passed" : "Failed");
            myTesting.LogSystem += string.Format("... \r\n");
            myTesting.LogSystem += string.Format("... kết quả: {0}\r\n", r ? "Passed" : "Failed");
            if (!r) {
                myTesting.ErrorCode = info.Title;
                myTesting.ErrorMessage = string.Format("giá trị tiêu chuẩn \"{0}\" và giá trị thực tế \"{1}\" không giống nhau.", info.standardValue, act_value);
                myTesting.LogSystem += string.Format("... thông tin lỗi: {0}\r\n", myTesting.ErrorMessage);
            }
            st.Stop();
            myTesting.LogSystem += string.Format("... thời gian: {0} ms\r\n", st.ElapsedMilliseconds);
            return r;
        }

        void setTestingPropertyValue(string property_name, string data) {
            PropertyInfo property_info = myTesting.GetType().GetProperty(property_name);
            property_info.SetValue(myTesting, Convert.ChangeType(data, property_info.PropertyType), null);
        }

        public static string conbineChars(string _char, int length) {
            string data = "";
            for (int i = 0; i < length; i++) data += _char;
            return data;
        }

        bool loginSshToMesh() {
            Stopwatch st = new Stopwatch();
            st.Start();

            //show standard value
            myTesting.LoginSSH = "Waiting...";
            myTesting.LogSystem += string.Format("\r\n### ĐĂNG NHẬP SSH VÀO SẢN PHẨM ###\r\n");
            myTesting.LogSystem += string.Format("{0} \r\n", conbineChars("-", 80));
            myTesting.LogSystem += string.Format("... ip={0}, user={1}, password={2}\r\n", mySetting.IPAddress, mySetting.SshUser, mySetting.SshPassword);
            myTesting.LogSystem += string.Format("... tiêu chuẩn: true\r\n");
            myTesting.LogSystem += string.Format("... \r\n");

            bool r = false;
            int count = 0;
            RE:
            count++;
            //get actual value
            if (mesh != null && mesh.IsConnected) { mesh.Close(); mesh = null; }
            mesh = new meshAP<TestingInformation>(myTesting);

            //compare
            r = mesh.Login(mySetting.IPAddress, mySetting.SshUser, mySetting.SshPassword);
            myTesting.LogSystem += string.Format("... thực tế [lần {0}/3]: {1} => {2}\r\n", count, r, r ? "Passed" : "Failed");
            if (!r) {
                if (count < 3) {
                    goto RE;
                }
            }

            //return result
            myTesting.LoginSSH = r ? "Passed" : "Failed";
            myTesting.LogSystem += string.Format("... \r\n");
            myTesting.LogSystem += string.Format("... kết quả: {0}\r\n", r ? "Passed" : "Failed");
            if (!r) {
                myTesting.ErrorCode = "Đăng nhập SSH";
                myTesting.ErrorMessage = string.Format("không đăng nhập ssh được vào sản phẩm mesh.");
                myTesting.LogSystem += string.Format("... thông tin lỗi: {0}\r\n", myTesting.ErrorMessage);
            }
            st.Stop();
            myTesting.LogSystem += string.Format("... thời gian: {0} ms\r\n", st.ElapsedMilliseconds);
            return r;
        }

        bool setMeshSerialNumber() {
            Stopwatch st = new Stopwatch();
            st.Start();

            //show standard value
            myTesting.WriteAndValidateSerialNumber = "Waiting...";
            myTesting.LogSystem += string.Format("\r\n### GHI THÔNG TIN SERIAL NUMBER ###\r\n");
            myTesting.LogSystem += string.Format("{0} \r\n", conbineChars("-", 80));
            myTesting.LogSystem += string.Format("... serial number={0}\r\n", myTesting.SerialNumber);
            myTesting.LogSystem += string.Format("... tiêu chuẩn: true\r\n");
            myTesting.LogSystem += string.Format("... \r\n");

            bool r = false;
            int count = 0;
            RE:
            count++;
            //compare
            r = mesh.setSerialNumber(myTesting.SerialNumber);
            myTesting.LogSystem += string.Format("... thực tế [lần {1}/{3}]: {0} => {2}\r\n", r, count, r ? "Passed" : "Failed", 3);
            if (!r) {
                if (count < 3) {
                    goto RE;
                }
            }

            //return result
            myTesting.WriteAndValidateSerialNumber = r ? "Passed" : "Failed";
            myTesting.LogSystem += string.Format("... \r\n");
            myTesting.LogSystem += string.Format("... kết quả: {0}\r\n", r ? "Passed" : "Failed");
            if (!r) {
                myTesting.ErrorCode = "Ghi và kiểm tra serial number";
                myTesting.ErrorMessage = string.Format("không ghi được serial vào sản phẩm mesh.");
                myTesting.LogSystem += string.Format("... thông tin lỗi: {0}\r\n", myTesting.ErrorMessage);
            }
            st.Stop();
            myTesting.LogSystem += string.Format("... thời gian: {0} ms\r\n", st.ElapsedMilliseconds);
            return r;
        }

        bool pingToMesh() {
            Stopwatch st = new Stopwatch();
            st.Start();

            //show standard value
            myTesting.LoginSSH = "Waiting...";
            myTesting.LogSystem += string.Format("\r\n### KIỂM TRA PING MẠNG TỚI SẢN PHẨM ###\r\n");
            myTesting.LogSystem += string.Format("{0} \r\n", conbineChars("-", 80));
            myTesting.LogSystem += string.Format("... ip={0}\r\n", mySetting.IPAddress);
            myTesting.LogSystem += string.Format("... tiêu chuẩn: true\r\n");
            myTesting.LogSystem += string.Format("... \r\n");

            bool r = false;
            int count = 0;
            int retry_time = 20;
            RE:
            count++;
            //compare
            r = Network.pingNetwork(mySetting.IPAddress);
            myTesting.LogSystem += string.Format("... thực tế [lần {1}/{3}]: {0} => {2}\r\n", r, count, r ? "Passed" : "Failed", 3);
            if (!r) {
                if (count < retry_time) {
                    goto RE;
                }
            }

            //return result
            myTesting.LoginSSH = r ? "Passed" : "Failed";
            myTesting.LogSystem += string.Format("... \r\n");
            myTesting.LogSystem += string.Format("... kết quả: {0}\r\n", r ? "Passed" : "Failed");
            if (!r) {
                myTesting.ErrorCode = "Đăng nhập SSH";
                myTesting.ErrorMessage = string.Format("không ping được tới sản phẩm mesh.");
                myTesting.LogSystem += string.Format("... thông tin lỗi: {0}\r\n", myTesting.ErrorMessage);
            }
            st.Stop();
            myTesting.LogSystem += string.Format("... thời gian: {0} ms\r\n", st.ElapsedMilliseconds);
            return r;
        }

        bool validateLedWan() {
            App.Current.Dispatcher.Invoke(new Action(() => { this.grid_container.Children.Add(new ucLED(this.mesh)); }));

            Stopwatch st = new Stopwatch();
            st.Start();

            //show standard value
            myTesting.ValidateLed = "Waiting...";
            myTesting.LogSystem += string.Format("\r\n### KIỂM TRA LED WAN ###\r\n");
            myTesting.LogSystem += string.Format("{0} \r\n", conbineChars("-", 80));
            myTesting.LogSystem += string.Format("... tiêu chuẩn: true\r\n");
            myTesting.LogSystem += string.Format("... \r\n");

            bool r = false;
            int count = 0;
            int timeout = myTesting.TimeOutValidateLedWan * 2;
            myTesting.LogSystem += string.Format("... đang chờ max = {0}\r\n", timeout);
            RE:
            count++;
            myTesting.LogSystem += string.Format("..{0}", count);
            if (myTesting.TimeOutValidateLedWan > 0 && count % 2 == 0) myTesting.TimeOutValidateLedWan -= 1;
            //compare
            r = myTesting.ValidateLed == "Passed" || myTesting.ValidateLed == "Failed";
            if (!r) {
                if (count < timeout) {
                    Thread.Sleep(500);
                    goto RE;
                }
            }
            r = myTesting.ValidateLed == "Passed";
            myTesting.LogSystem += string.Format("\r\n... thực tế: {0}\r\n", r);
            myTesting.LogSystem += string.Format("... \r\n");
            myTesting.LogSystem += string.Format("... kết quả: {0}\r\n", r ? "Passed" : "Failed");
            if (!r) {
                myTesting.ErrorCode = "Kiểm tra led wan";
                myTesting.ErrorMessage = string.Format("1 trong 3 đèn (xanh, vàng, đỏ) của led wan không sáng.");
                myTesting.LogSystem += string.Format("... thông tin lỗi: {0}\r\n", myTesting.ErrorMessage);
            }
            st.Stop();
            myTesting.LogSystem += string.Format("... thời gian: {0} ms\r\n", st.ElapsedMilliseconds);

            App.Current.Dispatcher.Invoke(new Action(() => { this.grid_container.Children.Add(new ucLogSystem()); }));
            return r;
        }

        bool validateButtonWps() {
            App.Current.Dispatcher.Invoke(new Action(() => { this.grid_container.Children.Add(new ucButtonWps()); }));
            Stopwatch st = new Stopwatch();
            st.Start();

            //show standard value
            myTesting.ValidateButton = "Waiting...";
            myTesting.LogSystem += string.Format("\r\n### KIỂM TRA NÚT NHẤN WPS ###\r\n");
            myTesting.LogSystem += string.Format("{0} \r\n", conbineChars("-", 80));
            myTesting.LogSystem += string.Format("... tiêu chuẩn: true\r\n");
            myTesting.LogSystem += string.Format("... \r\n");

            bool r = false;
            int count = 0;
            int timeout = myTesting.TimeOutValidateButtonWps * 2;
            myTesting.LogSystem += string.Format("... đang chờ max = {0}\r\n", timeout);
            RE:
            count++;
            myTesting.LogSystem += string.Format("..{0}", count);
            if (myTesting.TimeOutValidateButtonWps > 0 && count % 2 == 0) myTesting.TimeOutValidateButtonWps -= 1;

            //compare
            r = myTesting.ButtonWps == "Passed" || myTesting.ButtonWps == "Failed";
            if (!r) {
                if (count < timeout) {
                    Thread.Sleep(500);
                    goto RE;
                }
            }

            //result
            r = myTesting.ButtonWps == "Passed";
            myTesting.LogSystem += string.Format("\r\n... thực tế: {0}\r\n", r);
            myTesting.LogSystem += string.Format("... \r\n");
            myTesting.LogSystem += string.Format("... kết quả: {0}\r\n", r ? "Passed" : "Failed");
            myTesting.ValidateButton = r ? "Passed" : "Failed";
            if (!r) {
                myTesting.ErrorCode = "Kiểm tra nút nhấn wps và reset";
                myTesting.ErrorMessage = string.Format("lỗi nút nhấn wps.");
                myTesting.LogSystem += string.Format("... thông tin lỗi: {0}\r\n", myTesting.ErrorMessage);
            }
            st.Stop();
            myTesting.LogSystem += string.Format("... thời gian: {0} ms\r\n", st.ElapsedMilliseconds);

            App.Current.Dispatcher.Invoke(new Action(() => { this.grid_container.Children.Add(new ucLogSystem()); }));
            return r;
        }

        bool validateButtonReset() {
            App.Current.Dispatcher.Invoke(new Action(() => { this.grid_container.Children.Add(new ucButtonReset()); }));
            Stopwatch st = new Stopwatch();
            st.Start();

            //show standard value
            myTesting.ValidateButton = "Waiting...";
            myTesting.LogSystem += string.Format("\r\n### KIỂM TRA NÚT NHẤN RESET ###\r\n");
            myTesting.LogSystem += string.Format("{0} \r\n", conbineChars("-", 80));
            myTesting.LogSystem += string.Format("... tiêu chuẩn: true\r\n");
            myTesting.LogSystem += string.Format("... \r\n");

            bool r = false;
            int count = 0;
            int timeout = myTesting.TimeOutValidateButtonReset * 2;
            myTesting.LogSystem += string.Format("... đang chờ max = {0}\r\n", timeout);
            RE:
            count++;
            myTesting.LogSystem += string.Format("..{0}", count);
            if (myTesting.TimeOutValidateButtonReset > 0 && count % 2 == 0) myTesting.TimeOutValidateButtonReset -= 1;

            //compare
            r = myTesting.ButtonReset == "Passed" || myTesting.ButtonReset == "Failed";
            if (!r) {
                if (count < timeout) {
                    Thread.Sleep(500);
                    goto RE;
                }
            }

            //result
            r = myTesting.ButtonReset == "Passed";
            myTesting.LogSystem += string.Format("\r\n... thực tế: {0}\r\n", r);
            myTesting.LogSystem += string.Format("... \r\n");
            myTesting.LogSystem += string.Format("... kết quả: {0}\r\n", r ? "Passed" : "Failed");
            myTesting.ValidateButton = r ? "Passed" : "Failed";
            if (!r) {
                myTesting.ErrorCode = "Kiểm tra nút nhấn wps và reset";
                myTesting.ErrorMessage = string.Format("lỗi nút nhấn reset.");
                myTesting.LogSystem += string.Format("... thông tin lỗi: {0}\r\n", myTesting.ErrorMessage);
            }
            st.Stop();
            myTesting.LogSystem += string.Format("... thời gian: {0} ms\r\n", st.ElapsedMilliseconds);

            App.Current.Dispatcher.Invoke(new Action(() => { this.grid_container.Children.Add(new ucLogSystem()); }));
            return r;
        }

    }
}
