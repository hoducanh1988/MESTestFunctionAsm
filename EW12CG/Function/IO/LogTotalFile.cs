using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EW12CG.Function.Global;

namespace EW12CG.Function.IO {

    public class LogTotalFile {

        string log_dir = myGlobal.dir_Path;
        string log_file = "";

        public LogTotalFile() {
            log_dir = string.Format("{0}\\Logtotal", log_dir);
            log_dir = string.Format("{0}\\EW12CG", log_dir);
            createLogDirectory(log_dir);
            log_file = string.Format("EW12CG_{0}.CSV", DateTime.Now.ToString("yyyyMMdd"));

            myGlobal.totalDirectory = log_dir;
        }

        private void createLogDirectory(string logdirectory) {
            if (!Directory.Exists(logdirectory)) {
                Directory.CreateDirectory(logdirectory);
                Thread.Sleep(100);
            }
        }

        public void createLog(VnptAsmTestFunctionLogInfo logInfo, VnptLogMoreInfo moreInfo) {
            string title = "DATE_TIME,WORK_ORDER,OPERATOR,PN,UID1,UID2,TESTNAME,L_LIMIT,U_LIMIT,MEASURE_VAL,RESULT,INFO1,INFO2,INFO3,INFO4,INFO5,INFO6,INFO7,INFO8,INFO9,INFO10";
            string fileFullName = System.IO.Path.Combine(log_dir, log_file);
            bool IsCreateTitle = !File.Exists(fileFullName);

            //write data to file
            using (StreamWriter sw = new StreamWriter(fileFullName, true, Encoding.Unicode)) {
                //write title
                if (IsCreateTitle == true) sw.WriteLine(title);

                foreach (PropertyInfo propertyInfo in logInfo.GetType().GetProperties()) {
                    if (propertyInfo.PropertyType == typeof(VnptTestItemInfo)) {
                        VnptTestItemInfo itemInfo = (VnptTestItemInfo)propertyInfo.GetValue(logInfo, null);

                        //no save log none
                        if (itemInfo.Result.ToLower().Contains("none") == true) continue;

                        //save log
                        string content = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}",
                                                       DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ffff"),
                                                       logInfo.Work_Order,
                                                       logInfo.Operator,
                                                       logInfo.Product_Code,
                                                       logInfo.Mac_Address.Replace("\"", ""),
                                                       logInfo.Product_Serial,
                                                       propertyInfo.Name,
                                                       itemInfo.Lower_Limit,
                                                       itemInfo.Upper_Limit,
                                                       itemInfo.Actual_Value,
                                                       itemInfo.Result,
                                                       moreInfo.Info1,
                                                       moreInfo.Info2,
                                                       moreInfo.Info3,
                                                       moreInfo.Info4,
                                                       moreInfo.Info5,
                                                       moreInfo.Info6,
                                                       moreInfo.Info7,
                                                       moreInfo.Info8,
                                                       moreInfo.Info9,
                                                       moreInfo.Info10
                                                       );

                        //write content
                        sw.WriteLine(content);
                    }
                }
            }

        }

    }


    public class VnptAsmTestFunctionLogInfo {

        public VnptAsmTestFunctionLogInfo() {
            Operator = myGlobal.mySetting.Operator;
            Date_Time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            Work_Order = myGlobal.mySetting.WorkOrder;
            Product_Code = "";
            Mac_Address = myGlobal.myTesting.MacEthernet;
            Product_Serial = "";
            Error_Message = myGlobal.myTesting.ErrorMessage;

            LoginSSH = new VnptTestItemInfo(); 
            WriteSerial = new VnptTestItemInfo(); 
            CheckMac = new VnptTestItemInfo(); 
            CheckFirmware = new VnptTestItemInfo(); 
            CheckHardware = new VnptTestItemInfo();
            CheckModel = new VnptTestItemInfo(); 
            CheckWan = new VnptTestItemInfo(); 
            CheckLed = new VnptTestItemInfo(); 
            CheckButton = new VnptTestItemInfo();
        }

        public string Date_Time { get; set; }
        public string Work_Order { get; set; }
        public string Operator { get; set; }
        public string Product_Code { get; set; }
        public string Mac_Address { get; set; }
        public string Product_Serial { get; set; }
        public string Error_Message { get; set; }

        public VnptTestItemInfo LoginSSH { get; set; }
        public VnptTestItemInfo WriteSerial { get; set; }
        public VnptTestItemInfo CheckMac { get; set; }
        public VnptTestItemInfo CheckFirmware { get; set; }
        public VnptTestItemInfo CheckHardware { get; set; }
        public VnptTestItemInfo CheckModel { get; set; }
        public VnptTestItemInfo CheckWan { get; set; }
        public VnptTestItemInfo CheckLed { get; set; }
        public VnptTestItemInfo CheckButton { get; set; }
    }

    public class VnptTestItemInfo {
        public VnptTestItemInfo() {
            Lower_Limit = Upper_Limit = Actual_Value = Result = "NONE";
        }

        public string Lower_Limit { get; set; }
        public string Upper_Limit { get; set; }
        public string Actual_Value { get; set; }
        public string Result { get; set; }
    }

    public class VnptLogMoreInfo {

        public VnptLogMoreInfo() {
            Info1 = Info2 = Info3 = Info4 = Info5 = Info6 = Info7 = Info8 = Info9 = Info10 = "";
        }

        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
        public string Info5 { get; set; }
        public string Info6 { get; set; }
        public string Info7 { get; set; }
        public string Info8 { get; set; }
        public string Info9 { get; set; }
        public string Info10 { get; set; }
    }
}
