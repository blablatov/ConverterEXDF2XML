using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Text;

namespace LoadXMLToMUTdBase
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public static ConvEXDFtoXML SendConvData { get; set; }
    }

    static class Data
    {
        public static string SendConvData { get; set; }
        public static string SendXMLData { get; set; }

        public static string stringFrom { get; set; }
        public static string stringIn { get; set; }
        public static string stringWhere { get; set; }
        public static string stringBool { get; set; }
        public static string stringOrderby { get; set; }
        public static string stringSelect { get; set; }
    }
}
