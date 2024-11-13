using DevExpress.Data;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Grid;
using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.Models;
using HRSM.Models.VModels;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
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
using static HRSM.DXHouseApp.ComUtility;

namespace HRSM.DXHouseApp.HSat
{
        /// <summary>
        /// Interaction logic for HouseStatisticsView.xaml
        /// </summary>
        public partial class HouseStatisticsView : UserControl
        {
                public HouseStatisticsView()
                {
                        InitializeComponent();
                }
                private HouseBLL houseBLL = new HouseBLL();
                //Storyboard board = null;
                private void UserControl_Loaded(object sender, RoutedEventArgs e)
                {

                        //ViewHouseCountSatisticsModel houseStat = houseBLL.GetHouseStatistics();
                        //List<ViewHouseCountSatisticsModel> list = new List<ViewHouseCountSatisticsModel>()
                        //{
                        //    houseStat
                        //};
                        //gridHouseData.ItemsSource = list;


                        //gridHouseData.TotalSummary.Clear();
                        //gridHouseData.TotalSummary.Add(new GridSummaryItem()
                        //{
                        //    SummaryType = DevExpress.Data.SummaryItemType.Sum,
                        //    FieldName = "TotalCount",
                        //    DisplayFormat = "总数:{0}"
                        //});
                        //gridHouseData.TotalSummary.Add(new GridSummaryItem()
                        //{
                        //    SummaryType = DevExpress.Data.SummaryItemType.Sum,
                        //    FieldName = "HasRentCount",
                        //    DisplayFormat = "已出租:{0}"
                        //});
                        //gridHouseData.TotalSummary.Add(new GridSummaryItem()
                        //{
                        //    SummaryType = DevExpress.Data.SummaryItemType.Sum,
                        //    FieldName = "HasSaleCount",
                        //    DisplayFormat = "已出售:{0}"
                        //});

                        //List<HouseChartModel> totalList = new List<HouseChartModel>()
                        //    {
                        //        new HouseChartModel()
                        //        {
                        //            XName="总数",
                        //            HCount=houseStat.TotalCount
                        //        },
                        //        new HouseChartModel()
                        //        {
                        //            XName="出租",
                        //            HCount=houseStat.TRentCount
                        //        },
                        //        new HouseChartModel()
                        //        {
                        //            XName="出售",
                        //            HCount=houseStat.TSaleCount
                        //        }
                        //    };
                        //List<HouseChartModel> pubList = new List<HouseChartModel>()
                        //{
                        //     new HouseChartModel()
                        //        {
                        //            XName="已发布",
                        //            HCount=houseStat.PublishedCount
                        //        }
                        //};
                        //List<HouseChartModel> unPbList = new List<HouseChartModel>()
                        //{
                        //      new HouseChartModel()
                        //        {
                        //            XName="未发布",
                        //            HCount=houseStat.UnPublishedCount
                        //        }
                        //};
                        //List<HouseChartModel> hasList = new List<HouseChartModel>()
                        //{

                        //     new HouseChartModel()
                        //        {
                        //            XName="出租",
                        //            HCount=houseStat.HasRentCount
                        //        },
                        //      new HouseChartModel()
                        //        {
                        //            XName="出售",
                        //            HCount=houseStat.HasSaleCount
                        //        }
                        //};
                        //List<HouseChartModel> unList = new List<HouseChartModel>()
                        //{

                        //     new HouseChartModel()
                        //        {
                        //            XName="出租",
                        //            HCount=houseStat.UnRentCount
                        //        },
                        //     new HouseChartModel()
                        //        {
                        //            XName="出售",
                        //            HCount=houseStat.UnSaleCount
                        //        }
                        //};
                        //AddSeriesPonts(totalSeries, totalList);
                        //AddSeriesPonts(pubSeries, pubList);
                        //AddSeriesPonts(unPubSeries, unPbList);
                        //AddSeriesPonts(hasRSSeries, hasList);
                        //AddSeriesPonts(unRSSeries, unList);

                        ////board = new Storyboard();
                        ////List<Series> listSeries = new List<Series>();
                        ////listSeries.Add(CreateSeries("总数", totalList));
                        ////listSeries.Add(CreateSeries("已发布", pubList));
                        ////listSeries.Add(CreateSeries("未发布", unPbList));
                        ////listSeries.Add(CreateSeries("已租售", hasList));
                        ////listSeries.Add(CreateSeries("未租售", unList));
                        ////CreateChart(chartHouses, listSeries);




                        //foreach (Series s in chartHouses.Diagram.Series)
                        //{
                        //    //ChartAnimationRecord record = new ChartAnimationRecord();
                        //    //record.Progress = 0;
                        //    //SeriesAnimation ani = new SeriesAnimation();


                        //    //SeriesSeriesPointsAction action = new SeriesSeriesPointsAction();
                        //    //action.EqualSpeed = true;
                        //    //action.Sequential = true;
                        //    //action.DelayPercentage = 30;

                        //    //ani.Actions.Add(action);
                        //    //record.Animations.Add(ani);


                        //    DoubleAnimation dani2 = new DoubleAnimation();
                        //    dani2.From = 0;
                        //    dani2.To = 0.5;
                        //    dani2.Duration = new Duration(TimeSpan.FromSeconds(3));

                        //    Storyboard.SetTarget(dani2, s);
                        //    Storyboard.SetTargetProperty(dani2, new PropertyPath(BarSideBySideSeries2D.BarWidthProperty));
                        //    board.Children.Add(dani2);

                        //}
                        ////动画
                        //DoubleAnimation dani0 = new DoubleAnimation();
                        //dani0.From = 100;
                        //dani0.To = gridHouseData.ActualWidth;
                        //dani0.Duration = new Duration(TimeSpan.FromSeconds(2));
                        //Storyboard.SetTarget(dani0, gridHouseData);
                        //Storyboard.SetTargetProperty(dani0, new PropertyPath(GridControl.WidthProperty));
                        //board.Children.Add(dani0);


                        //DoubleAnimation dani1 = new DoubleAnimation();
                        //dani1.From = 0.5;
                        //dani1.To = 1.0;
                        //dani1.Duration = new Duration(TimeSpan.FromSeconds(1));
                        //Storyboard.SetTarget(dani1, gridHouseData);
                        //Storyboard.SetTargetProperty(dani1, new PropertyPath(ChartControl.OpacityProperty));
                        //board.Children.Add(dani1);



                        //EventTrigger trigger = new EventTrigger();
                        //trigger.RoutedEvent = UserControl.LoadedEvent;
                        //BeginStoryboard begin = new BeginStoryboard();
                        //begin.Storyboard = board;
                        //trigger.Actions.Add(begin);

                        //chartHouses.Triggers.Add(trigger);

                }
                Storyboard board = new Storyboard();


                /// <summary>
                /// 给指定的series添加点集合
                /// </summary>
                /// <param name="series"></param>
                /// <param name="list"></param>
                private void AddSeriesPonts(BarSideBySideSeries2D series, List<HouseChartModel> list)
                {
                        series.Points.Clear();
                        series.Points.AddRange(list.Select(h => new SeriesPoint(h.XName, h.HCount)));
                }

                /// <summary>
                /// 创建Series
                /// </summary>
                /// <param name="caption"></param>
                /// <param name="list"></param>
                /// <param name="index"></param>
                /// <returns></returns>
                private Series CreateSeries(string caption, List<HouseChartModel> list)
                {
                        Series series = new BarSideBySideSeries2D();

                        for (int i = 0; i < list.Count; i++)
                        {
                                string argument = list[i].XName;//参数名称
                                int value = list[i].HCount;//参数值
                                series.Points.Add(new SeriesPoint(argument, value));
                        }

                        //也就是说，显示字符串的参数，必须设置类型为ScaleType.Qualitative
                        series.ArgumentScaleType = ScaleType.Qualitative;
                        series.LabelsVisibility = false;//显示标注标签
                        series.DisplayName = caption;
                        // series.BarWidth = 0.5;


                        return series;
                }



                private void TvList_MouseDown(object sender, MouseButtonEventArgs e)
                {
                        //if (e.ClickCount == 2)
                        //{
                        //        TableView tableView = sender as TableView;
                        //        TableViewHitInfo hitInfo = tvList.CalcHitInfo(e.OriginalSource as DependencyObject);
                        //        if (hitInfo.InRowCell)
                        //        {
                        //                //gridHouseData.ce(hitInfo.RowHandle,hitInfo.Column);
                        //                int houseCount = gridHouseData.CurrentCellValue.GetInt();
                        //                string fieldName = hitInfo.Column.FieldName;
                        //                HouseStatList hStatList = new HouseStatList();
                        //                hStatList.Tag = new QueryStatListModel()
                        //                {
                        //                        StatCountName = hitInfo.Column.Header.ToString(),
                        //                        StatCount = houseCount,
                        //                        SatCountProName = fieldName,
                        //                        StatType = StatType.HouseStat
                        //                };

                        //                ComUtility.AddTabPage(this, hStatList, "房屋统计明细");
                        //        }
                        //}

                }

        }




}
