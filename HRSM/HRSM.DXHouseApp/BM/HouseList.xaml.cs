using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.Models;
using HRSM.DXHouseApp.Utils;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HRSM.DXHouseApp.BM
{
        /// <summary>
        /// Interaction logic for HouseList.xaml
        /// </summary>
        public partial class HouseList : UserControl
        {
                public HouseList()
                {
                        InitializeComponent();
                }

                private void UcHouseList_Loaded(object sender, RoutedEventArgs e)
                {
                        //注册房屋信息页面
                        this.Register<HouseInfoView>("houseInfoView");
                        //注册房屋交易信息页面
                        this.Register<HouseTradeInfoWindow>("houseTradeInfoWindow");
                }




        }
}
