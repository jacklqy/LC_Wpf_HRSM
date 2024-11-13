using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors;
using HRSM.BLL;
using HRSM.DXHouseApp.Models;
using HRSM.DXHouseApp.Utils;
using HRSM.Models.DModels;
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

namespace HRSM.DXHouseApp.SM
{
        /// <summary>
        /// Interaction logic for UserList.xaml
        /// </summary>
        public partial class UserList : UserControl
        {
                public UserList()
                {
                        InitializeComponent();
                }


                private void UcUserList_Loaded(object sender, RoutedEventArgs e)
                {
                        //注册用户信息页面
                        this.Register<UserInfoWindow>("userInfo");
                }


            

        }
}
