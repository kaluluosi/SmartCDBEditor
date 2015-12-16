﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace YGOProDevelop {
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application {

        private void OnStartup(object sender, StartupEventArgs e) {
            if(e.Args.Length == 0 || File.Exists(e.Args[0]) == false)
                return;
            CDB.CDBManager.Instance.Open(e.Args[0]);
        }
    }
}
