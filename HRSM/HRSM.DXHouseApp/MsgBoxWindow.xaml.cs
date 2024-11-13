using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HRSM.DXHouseApp
{
    /// <summary>
    /// MsgBoxWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MsgBoxWindow : Window
    {
        public MsgBoxWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            OkButtonVisibility = Visibility.Collapsed;
            CancelButtonVisibility = Visibility.Collapsed;
            YesButtonVisibility = Visibility.Collapsed;
            NoButtonVisibility = Visibility.Collapsed;

            Result = CustomMessageBoxResult.None;
        }

        /// <summary>
        /// 显示按钮类型
        /// </summary>
        public enum CustomMessageBoxButton
        {
            OK = 0,
            OKCancel = 1,
            YesNo = 2,
            YesNoCancel = 3
        }
        /// <summary>
        /// 消息框的返回值
        /// </summary>
        public enum CustomMessageBoxResult
        {
            //用户直接关闭了消息窗口
            None = 0,
            //用户点击确定按钮
            OK = 1,
            //用户点击取消按钮
            Cancel = 2,
            //用户点击是按钮
            Yes = 3,
            //用户点击否按钮
            No = 4
        }
        /// <summary>
        /// 图标类型
        /// </summary>
        public enum CustomMessageBoxIcon
        {
            None = 0,
            Error = 1,
            Question = 2,
            Information=3
        }

        #region Filed
        /// <summary>
        /// 显示的内容
        /// </summary>
        public string MessageBoxText { get; set; }
        /// <summary>
        /// 显示的图片
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 控制显示 OK 按钮
        /// </summary>
        public Visibility OkButtonVisibility { get; set; }
        /// <summary>
        /// 控制显示 Cacncel 按钮
        /// </summary>
        public Visibility CancelButtonVisibility { get; set; }
        /// <summary>
        /// 控制显示 Yes 按钮
        /// </summary>
        public Visibility YesButtonVisibility { get; set; }
        /// <summary>
        /// 控制显示 No 按钮
        /// </summary>
        public Visibility NoButtonVisibility { get; set; }
        /// <summary>
        /// 消息框的返回值
        /// </summary>
        public CustomMessageBoxResult Result { get; set; }

        #endregion

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Result = CustomMessageBoxResult.OK;
            this.Close();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Result = CustomMessageBoxResult.Yes;
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Result = CustomMessageBoxResult.No;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Result = CustomMessageBoxResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="messageBoxButton"></param>
        /// <param name="messageBoxImage"></param>
        /// <returns></returns>
        public static CustomMessageBoxResult Show(string messageBoxText, string title, CustomMessageBoxButton messageBoxButton, CustomMessageBoxIcon messageBoxImage)
        {
            MsgBoxWindow window = new MsgBoxWindow();
            window.Owner = Application.Current.MainWindow;
            window.Topmost = true;
            window.MessageBoxText = messageBoxText;
            window.Title = title;
            switch (messageBoxImage)
            {
                case CustomMessageBoxIcon.Information:
                    window.ImagePath = @"imgs/success.jpg";
                    break;
                case CustomMessageBoxIcon.Question:
                    window.ImagePath = @"imgs/question.jpg";
                    break;
                case CustomMessageBoxIcon.Error:
                    window.ImagePath = @"imgs/error.jpg";
                    break;
            }
            switch (messageBoxButton)
            {
                case CustomMessageBoxButton.OK:
                    window.OkButtonVisibility = Visibility.Visible;
                    break;
                case CustomMessageBoxButton.OKCancel:
                    window.OkButtonVisibility = Visibility.Visible;
                    window.CancelButtonVisibility = Visibility.Visible;
                    break;
                case CustomMessageBoxButton.YesNo:
                    window.YesButtonVisibility = Visibility.Visible;
                    window.NoButtonVisibility = Visibility.Visible;
                    break;
                case CustomMessageBoxButton.YesNoCancel:
                    window.YesButtonVisibility = Visibility.Visible;
                    window.NoButtonVisibility = Visibility.Visible;
                    window.CancelButtonVisibility = Visibility.Visible;
                    break;
                default:
                    window.OkButtonVisibility = Visibility.Visible;
                    break;
            }

            window.ShowDialog();
            return window.Result;
        }


        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
