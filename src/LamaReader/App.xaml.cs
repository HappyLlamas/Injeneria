﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LamaReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
        : Application
    {
        public static string GetRootDirectory
        {
            get
            {
                return (System.AppDomain.CurrentDomain.BaseDirectory);
            }
        }
    }
}
