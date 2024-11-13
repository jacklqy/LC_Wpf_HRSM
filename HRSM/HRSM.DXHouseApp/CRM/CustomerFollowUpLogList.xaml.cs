using HRSM.DXHouseApp.Utils;
using System.Windows;
using System.Windows.Controls;

namespace HRSM.DXHouseApp.CRM
{
        /// <summary>
        /// Interaction logic for CustomerFollowUpLogList.xaml
        /// </summary>
        public partial class CustomerFollowUpLogList : UserControl
        {
                public CustomerFollowUpLogList()
                {
                        InitializeComponent();
                }
                private void UcCustFULogList_Loaded(object sender, RoutedEventArgs e)
                {
                        this.Register<CustomerFollowUpLogInfoWindow>("custFollowUpLogInfoWindow");//注册客户跟进日志信息页面
                }
        }
}
