using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Editors.DateNavigator;
using DevExpress.Xpf.Grid;
using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.Models;
using HRSM.Models.VModels;
using Microsoft.Win32;
using NPOI.HSSF.UserModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRSM.DXHouseApp.HSat
{
    /// <summary>
    /// Interaction logic for SaleTimeStatisticsView.xaml
    /// </summary>
    public partial class SaleTimeStatisticsView : UserControl
    {
        public SaleTimeStatisticsView()
        {
            InitializeComponent();

        }
 
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
                        LoadStatData();
        }

       

        private void LoadStatData()
        {
            gridTotalData.TotalSummary.Clear();
            gridTotalData.TotalSummary.Add(new GridSummaryItem()
            {
                SummaryType = DevExpress.Data.SummaryItemType.Sum,
                FieldName = "TotalCount",
                DisplayFormat = "总销售量:{0}"
            });
            gridTotalData.TotalSummary.Add(new GridSummaryItem()
            {
                SummaryType = DevExpress.Data.SummaryItemType.Sum,
                FieldName = "SaleCount",
                DisplayFormat = "总出售量:{0}"
            });
            gridTotalData.TotalSummary.Add(new GridSummaryItem()
            {
                SummaryType = DevExpress.Data.SummaryItemType.Sum,
                FieldName = "RentCount",
                DisplayFormat = "总出租量:{0}"
            });
            gridTotalData.TotalSummary.Add(new GridSummaryItem()
            {
                SummaryType = DevExpress.Data.SummaryItemType.Max,
                FieldName = "TotalCount",
                DisplayFormat = "销售第一的销售量:{0}"
            });

            Storyboard st = new Storyboard();

            DoubleAnimation dani = new DoubleAnimation();
            dani.From = 0;
            dani.To = series.HoleRadiusPercent;
            dani.Duration = new Duration(TimeSpan.FromSeconds(3));
            Storyboard.SetTarget(dani, series);
            Storyboard.SetTargetProperty(dani, new PropertyPath(PieSeries3D.HoleRadiusPercentProperty));
            st.Children.Add(dani);

            series.BeginStoryboard(st);
        }

        
       
    

 

    }
}

