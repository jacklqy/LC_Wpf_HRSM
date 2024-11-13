using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.Models;
using HRSM.DXHouseApp.Utils;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRSM.DXHouseApp.CRM
{
        /// <summary>
        /// Interaction logic for IntentedCustomerList.xaml
        /// </summary>
        public partial class CustomerRequestList : UserControl
        {
                public CustomerRequestList()
                {
                        InitializeComponent();
                }

                private void UcCustomerRequestList_Loaded(object sender, RoutedEventArgs e)
                {
                        this.Register<CustomerFollowUpLogList>("custFollowUpLogList");//客户跟进日志列表
                        this.Register<CustomerRequestInfoWindow>("customerRequestInfoWindow");//客户需求信息页面
                }
        }
}
