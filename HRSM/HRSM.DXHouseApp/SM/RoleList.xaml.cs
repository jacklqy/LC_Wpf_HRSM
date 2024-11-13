using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using HRSM.BLL;
using HRSM.Common;
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
        /// Interaction logic for RoleList.xaml
        /// </summary>
        public partial class RoleList : UserControl
        {
                public RoleList()
                {
                        InitializeComponent();

                }

                private void UcRoleList_Loaded(object sender, RoutedEventArgs e)
                {
                        //注册角色信息页面
                        this.Register<RoleInfoWindow>("roleInfo");
                        //注册权限设置页面
                        this.Register<RightSet>("rightSet");
                }

              
        }
}
