using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using HRSM.BLL;
using HRSM.DXHouseApp.Utils;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HRSM.DXHouseApp.HS
{
        /// <summary>
        /// Interaction logic for HouseShowList.xaml
        /// </summary>
        public partial class HouseShowList : UserControl
        {
                public HouseShowList()
                {
                        InitializeComponent();
                }

                private void UcHouseShow_Loaded(object sender, RoutedEventArgs e)
                {
                        this.Register<HouseInfo>("houseInfo");
                }
        }
}
