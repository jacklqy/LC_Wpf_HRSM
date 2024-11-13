using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HRSM.DXHouseApp.Utils
{
    public static class WindowExt
    {
        public static void Register(this ThemedWindow win, string key)
        {
            WindowManager.Regiter(key, win.GetType());
        }

        public static void Register(this ThemedWindow win, string key, Type t)
        {
            WindowManager.Regiter(key, t);
        }

        public static void Register<T>(this ThemedWindow win, string key)
        {
            WindowManager.Regiter<T>(key);
        }

        public static void Register(this UserControl win, string key)
        {
            WindowManager.Regiter(key, win.GetType());
        }

        public static void Register(this UserControl win, string key, Type t)
        {
            WindowManager.Regiter(key, t);
        }

        public static void Register<T>(this UserControl win, string key)
        {
            WindowManager.Regiter<T>(key);
        }
    }
}
