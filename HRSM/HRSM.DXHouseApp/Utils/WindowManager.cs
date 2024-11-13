using DevExpress.Xpf.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HRSM.DXHouseApp.Utils
{
    /// <summary>
    /// 窗口管理器
    /// </summary>
    public static class WindowManager
    {
        private static Hashtable _RegisterWindow = new Hashtable();

        public static void Regiter<T>(string key)
        {
            if (!_RegisterWindow.ContainsKey(key))
                _RegisterWindow.Add(key, typeof(T));
        }
        public static void Regiter(string key, Type t)
        {
            if (!_RegisterWindow.ContainsKey(key))
                _RegisterWindow.Add(key, t);
        }

        public static void Remove(string key)
        {
            if (_RegisterWindow.ContainsKey(key))
                _RegisterWindow.Remove(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj">DataContext</param>
        public static void ShowDialog(string key, object obj)
        {
            if (!_RegisterWindow.ContainsKey(key))
            {
                throw (new Exception("没有注册此键！"));
            }

            var win = (ThemedWindow)Activator.CreateInstance((Type)_RegisterWindow[key]);
            win.DataContext = obj;
            win.ShowDialog();
        }

       

        public static void ShowDialog(string key, object VM,object para)
        {
            if (!_RegisterWindow.ContainsKey(key))
            {
                throw (new Exception("没有注册此键！"));
            }

            var win = (ThemedWindow)Activator.CreateInstance((Type)_RegisterWindow[key]);
            win.DataContext = VM;
            if (para != null)
                win.Tag = para;
            win.ShowDialog();
        }

        /// <summary>
        /// 关闭Window
        /// </summary>
        /// <param name="key"></param>
        /// <param name="win"></param>
        public static void CloseWindow(string key, object win)
        {
            if (!_RegisterWindow.ContainsKey(key))
            {
                throw (new Exception("没有注册此键！"));
            }

            if (win != null)
            {
                Window window = win as Window;
                window.Close();
            }

        }

        /// <summary>
        /// 创建用户控件的实例
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object CreateUCInstance(string key, object obj)
        {
            if (!_RegisterWindow.ContainsKey(key))
            {
                throw (new Exception("没有注册此键！"));
            }
            Type type = (Type)_RegisterWindow[key];
            var instance = (UserControl)Activator.CreateInstance(type);
            instance.DataContext = obj;
            //PropertyInfo dataPro = type.GetProperty("DataContext");
            //dataPro.SetValue(instance, obj);
            return instance;
        }
    }
}
