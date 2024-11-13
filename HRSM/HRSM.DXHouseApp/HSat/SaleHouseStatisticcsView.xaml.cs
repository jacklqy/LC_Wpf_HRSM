using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Grid;
using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.HSat;
using HRSM.DXHouseApp.Models;
using HRSM.DXHouseApp.ViewModels.HSat;
using HRSM.Models.VModels;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace HRSM.DXHouseApp.HSat
{
        /// <summary>
        /// Interaction logic for SaleHouseStatisticcsView.xaml
        /// </summary>
        public partial class SaleHouseStatisticcsView : UserControl
        {
                public SaleHouseStatisticcsView()
                {
                        InitializeComponent();
                }

                private void UserControl_Loaded(object sender, RoutedEventArgs e)
                {

                }

                //行双击
                private void TvList_MouseDown(object sender, MouseButtonEventArgs e)
                {
                        if (e.ClickCount == 2)
                        {
                        //        TableView tableView = sender as TableView;
                        //        TableViewHitInfo hitInfo = tvList.CalcHitInfo(e.OriginalSource as DependencyObject);
                        //        if (hitInfo.InRowCell)
                        //        {
                        //                string fieldName = hitInfo.Column.FieldName;
                        //                if (fieldName != "DealUser")
                        //                {
                        //                        int houseCount = gridTotalData.CurrentCellValue.GetInt();
                        //                        string dealUser = (gridTotalData.CurrentItem as ViewSaleHouseStatisticsModel).DealUser;
                        //                        HouseStatList hStatList = new HouseStatList();
                        //                        hStatList.Tag = new QueryStatListModel()
                        //                        {
                        //                                StatCountName = hitInfo.Column.Header.ToString(),
                        //                                StatCount = houseCount,
                        //                                SatCountProName = fieldName,
                        //                                SaleUser = dealUser,
                        //                                StatType = ComUtility.StatType.SaleHouseStat
                        //                        };
                        //                        ComUtility.AddTabPage(this, hStatList, "房屋统计明细");
                        //                }

                        //        }
                        }

                }

                //鼠标移入显示对应的图表
                private void TvList_MouseMove(object sender, MouseEventArgs e)
                {
                        TableView tableView = sender as TableView;
                        TableViewHitInfo hitInfo = tvList.CalcHitInfo(e.OriginalSource as DependencyObject);
                        if (hitInfo.InRow)
                        {
                                gridTotalData.CurrentItem = ((List<ViewSaleHouseStatisticsModel>)gridTotalData.ItemsSource)[hitInfo.RowHandle];
                        }
                }


           

            

              

        }

}
