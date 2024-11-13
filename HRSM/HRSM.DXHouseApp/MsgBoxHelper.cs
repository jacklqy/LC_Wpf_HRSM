using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HRSM.DXHouseApp
{
    public class MsgBoxHelper
    {
        /// <summary>
        /// 成功消息框
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        public static void ShowInfo(string msg,string title)
        {
            MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// 错误消息框
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        public static void ShowError(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// 询问消息框
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        public static MessageBoxResult ShowQuestion(string msg, string title)
        {
           return MessageBox.Show(msg, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        /// <summary>
        /// 警告消息框
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        public static void ShowWarning(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

       
    }
}
