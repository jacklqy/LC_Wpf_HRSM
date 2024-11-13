using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.NavBar;
using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.Models;
using HRSM.DXHouseApp.Utils;
using HRSM.DXHouseApp.ViewModels;
using HRSM.Models.DModels;
using HRSM.Models.VModels;

namespace HRSM.DXHouseApp
{
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class HouseMain : ThemedWindow
        {
                public HouseMain()
                {
                        InitializeComponent();
                }

                /// <summary>
                /// 页面加载
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
                {
                        MainViewModel mainVM = new MainViewModel();
                        this.DataContext = mainVM;
                        this.Register<LoginWindow>("loginWindow");
                }


        }
}
