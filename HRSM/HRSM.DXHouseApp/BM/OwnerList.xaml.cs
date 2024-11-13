using DevExpress.Xpf.Core;
using HRSM.BLL;
using HRSM.DXHouseApp.Models;
using HRSM.DXHouseApp.Utils;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRSM.DXHouseApp.BM
{
        /// <summary>
        /// Interaction logic for OwnerList.xaml
        /// </summary>
        public partial class OwnerList : UserControl
        {
                public OwnerList()
                {
                        InitializeComponent();
                }

                /// <summary>
                /// 页面加载
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void UcOwnerList_Loaded(object sender, RoutedEventArgs e)
                {
                        this.Register<OwnInfoView>("ownerInfoView");
                }


        }
}
