using DevExpress.Xpf.Editors;
using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.Models;
using HRSM.DXHouseApp.Utils;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HRSM.DXHouseApp.CRM
{
        /// <summary>
        /// Interaction logic for CustomerList.xaml
        /// </summary>
        public partial class CustomerList : UserControl
        {
                public CustomerList()
                {
                        InitializeComponent();
                }
                private void UcCustList_Loaded(object sender, RoutedEventArgs e)
                {
                        this.Register<CustomerRequestList>("custReqList");//意向客户需求列表页
                        this.Register<CustomerInfoView>("customerInfoView");//客户信息页面
                }


        }
}
