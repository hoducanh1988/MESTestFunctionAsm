﻿using MeshTestFunctionAsm.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshTestFunctionAsm.Global {

    public class myGlobal {
        public static string settingFileFullName = string.Format("{0}setting.xml", AppDomain.CurrentDomain.BaseDirectory);
        public static SettingInformation mySetting = new SettingInformation();

    }
}
