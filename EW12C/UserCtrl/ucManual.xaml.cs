using System;
using System.Collections.Generic;
using System.IO;
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
using System.Reflection;
using EW12C.Function.Custom;
using EW12C.Function.Custom.Manual;
using EW12C.Function.Global;
using EW12C.Function.DUT;
using EW12C.Function.Protocol;
using UtilityPack.IO;

namespace EW12C.UserCtrl {
    /// <summary>
    /// Interaction logic for ucManual.xaml
    /// </summary>
    public partial class ucManual : UserControl {

        class readmeshinfo {
            public string ojbectVariable { get; set; }
            public string meshFunction { get; set; }
        }

        ManualHardwareInfo hardwareinfo = new ManualHardwareInfo();
        ManualModelInfo modelinfo = new ManualModelInfo();
        ManualMacInfo macinfo = new ManualMacInfo();
        ManualFirmwareInfo firmwareinfo = new ManualFirmwareInfo();
        ManualSerialInfo serialinfo = new ManualSerialInfo();
        ManualWanInfo waninfo = new ManualWanInfo();
        ManualLedInfo ledinfo = new ManualLedInfo();

        public ucManual() {
            //init control
            InitializeComponent();

            //load setting from file
            if (File.Exists(myGlobal.settingFileFullName)) myGlobal.mySetting = XmlHelper<SettingInformation>.FromXmlFile(myGlobal.settingFileFullName);

            //binding data
            this.tab_Hardware.DataContext = this.hardwareinfo;
            this.tab_ModelNumber.DataContext = this.modelinfo;
            this.tab_MacAddress.DataContext = this.macinfo;
            this.tab_Firmware.DataContext = this.firmwareinfo;
            this.tab_SerialNumber.DataContext = this.serialinfo;
            this.tab_Wan.DataContext = this.waninfo;
            this.tab_Led.DataContext = this.ledinfo;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;
            string btag = (string)b.Tag;
            string bcontent = (string)b.Content;
            List<readmeshinfo> infos = new List<readmeshinfo>();

            switch (btag) {
                //read hardware version
                case "read_hardware_version": {
                        infos.Add(new readmeshinfo() { ojbectVariable = "HardwareVersion", meshFunction = "getHardwareVersion" });
                        get_mesh<ManualHardwareInfo>(hardwareinfo, infos, b, bcontent);
                        break;
                    }
                //read model number
                case "read_model_number": {
                        infos.Add(new readmeshinfo() { ojbectVariable = "ModelNumber", meshFunction = "getModelNumber" });
                        get_mesh<ManualModelInfo>(modelinfo, infos, b, bcontent);
                        break;
                    }
                //read mac ethernet, mac wlan 2g, mac wlan 5g
                case "read_mac_address": {
                        infos.Add(new readmeshinfo() { ojbectVariable = "MacEthernet", meshFunction = "getMacEthernet" });
                        infos.Add(new readmeshinfo() { ojbectVariable = "MacWlan2G", meshFunction = "getMacWlan2G" });
                        infos.Add(new readmeshinfo() { ojbectVariable = "MacWlan5G", meshFunction = "getMacWlan5G" });
                        get_mesh<ManualMacInfo>(macinfo, infos, b, bcontent);
                        break;
                    }
                //read firmware version, firmware build time
                case "read_firmware_info": {
                        infos.Add(new readmeshinfo() { ojbectVariable = "FirmwareVersion", meshFunction = "getFirmwareVersion" });
                        infos.Add(new readmeshinfo() { ojbectVariable = "FirmwareBuildTime", meshFunction = "getFirmwareBuildTime" });
                        get_mesh<ManualFirmwareInfo>(firmwareinfo, infos, b, bcontent);
                        break;
                    }
                //read serial number
                case "read_serial_number": {
                        infos.Add(new readmeshinfo() { ojbectVariable = "MeshSerialNumber", meshFunction = "getSerialNumber" });
                        get_mesh<ManualSerialInfo>(serialinfo, infos, b, bcontent);
                        break;
                    }
                //write serial number
                case "write_serial_number": {
                        write_mesh_serial<ManualSerialInfo>(serialinfo, b, bcontent);
                        break;
                    }
                //read ethernet speed
                case "read_ethernet_speed": {
                        infos.Add(new readmeshinfo() { ojbectVariable = "EthernetSpeed", meshFunction = "getEthernetSpeed" });
                        get_mesh<ManualWanInfo>(waninfo, infos, b, bcontent);
                        break;
                    }
                //ping to imap
                case "ping_ethernet": {
                        ping_to_imap(b, bcontent);
                        break;
                    }
                //set led wan green bright
                case "wan_ledgreen_on": {
                        callback_mesh_method<ManualLedInfo>(ledinfo, "setLedWanBrightGreen", b, bcontent);
                        break;
                    }
                //set led wan yellow bright
                case "wan_ledyellow_on": {
                        callback_mesh_method<ManualLedInfo>(ledinfo, "setLedWanBrightYellow", b, bcontent);
                        break;
                    }
                //set led wan red bright
                case "wan_ledred_on": {
                        callback_mesh_method<ManualLedInfo>(ledinfo, "setLedWanBrightRed", b, bcontent);
                        break;
                    }
                //set led wan off
                case "wan_led_off": {
                        callback_mesh_method<ManualLedInfo>(ledinfo, "setLedWanBrightOff", b, bcontent);
                        break;
                    }
            }
        }

        private void get_mesh<T>(T obj, List<readmeshinfo> readmeshinfos, Button btn, string btn_default_content) where T : class, new() {
            Thread t = new Thread(new ThreadStart(() => {
                //change button background, content
                Dispatcher.Invoke(new Action(() => {
                    btn.Background = Brushes.Yellow;
                    btn.Content = "Wait...";
                }));

                //call method initParams
                MethodInfo method_initparam = obj.GetType().GetMethod("initParams");
                method_initparam.Invoke(obj, null);

                //init mesh
                meshAP<T> mesh = new meshAP<T>(obj);
                bool r = mesh.Login(myGlobal.mySetting.IPAddress, myGlobal.mySetting.SshUser, myGlobal.mySetting.SshPassword);

                //read mesh info and set to object variable
                if (r) {
                    foreach (var info in readmeshinfos) {
                        PropertyInfo property_info = obj.GetType().GetProperty(info.ojbectVariable);
                        MethodInfo method_getmeshinfo = mesh.GetType().GetMethod(info.meshFunction);
                        string data = (string)method_getmeshinfo.Invoke(mesh, null);
                        property_info.SetValue(obj, Convert.ChangeType(data, property_info.PropertyType), null);
                    }
                }
                mesh.Close();

                //return button background, content
                Dispatcher.Invoke(new Action(() => {
                    btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#cbd6d5");
                    btn.Content = btn_default_content;
                }));
            }));
            t.IsBackground = true;
            t.Start();
        }

        private void write_mesh_serial<T>(T obj, Button btn, string btn_default_content) where T : class, new() {
            Thread t = new Thread(new ThreadStart(() => {
                //change button background, content
                Dispatcher.Invoke(new Action(() => {
                    btn.Background = Brushes.Yellow;
                    btn.Content = "Wait...";
                }));

                //call method initParams
                MethodInfo method_initparam = obj.GetType().GetMethod("initParams");
                method_initparam.Invoke(obj, null);

                //init mesh
                meshAP<T> mesh = new meshAP<T>(obj);
                bool r = mesh.Login(myGlobal.mySetting.IPAddress, myGlobal.mySetting.SshUser, myGlobal.mySetting.SshPassword);

                //read mesh info and set to object variable
                if (r) {
                    PropertyInfo property_info = obj.GetType().GetProperty("StampSerialNumber");
                    string data = (string)property_info.GetValue(obj, null);
                    mesh.setSerialNumber(data);
                }
                mesh.Close();

                //return button background, content
                Dispatcher.Invoke(new Action(() => {
                    btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#cbd6d5");
                    btn.Content = btn_default_content;
                }));
            }));
            t.IsBackground = true;
            t.Start();
        }

        private void ping_to_imap(Button btn, string btn_default_content) {
            Thread t = new Thread(new ThreadStart(() => {
                //change button background, content
                Dispatcher.Invoke(new Action(() => {
                    btn.Background = Brushes.Yellow;
                    btn.Content = "Wait...";
                }));

                var mySetting = myGlobal.mySetting;
                waninfo.initParams();
                waninfo.LogSSH += string.Format("Pinging {0} with 32 bytes of data:\n", mySetting.IPAddress);
                bool r = false;
                for (int i = 0; i < 4; i++) {
                    r = Network.pingNetwork(mySetting.IPAddress);
                    waninfo.LogSSH += string.Format("{0}\n", r ? string.Format("Reply from {0}: bytes=32 time=1ms TTL=64", mySetting.IPAddress) : "Request timed out.");
                    if (r) Thread.Sleep(1000);
                }

                //return button background, content
                Dispatcher.Invoke(new Action(() => {
                    btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#cbd6d5");
                    btn.Content = btn_default_content;
                }));
            }));
            t.IsBackground = true;
            t.Start();
        }

        private void callback_mesh_method<T> (T obj, string mesh_function, Button btn, string btn_default_content) where T : class, new() {
            Thread t = new Thread(new ThreadStart(() => {
                //change button background, content
                Dispatcher.Invoke(new Action(() => {
                    btn.Background = Brushes.Yellow;
                    btn.Content = "Wait...";
                }));

                //call method initParams
                MethodInfo method_initparam = obj.GetType().GetMethod("initParams");
                method_initparam.Invoke(obj, null);

                //init mesh
                meshAP<T> mesh = new meshAP<T>(obj);
                bool r = mesh.Login(myGlobal.mySetting.IPAddress, myGlobal.mySetting.SshUser, myGlobal.mySetting.SshPassword);

                //callback mesh method
                if (r) {
                    MethodInfo method_mesh = mesh.GetType().GetMethod(mesh_function);
                    method_mesh.Invoke(mesh, null);
                }
                mesh.Close();

                //return button background, content
                Dispatcher.Invoke(new Action(() => {
                    btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#cbd6d5");
                    btn.Content = btn_default_content;
                }));
            }));
            t.IsBackground = true;
            t.Start();
        }


    }
}
