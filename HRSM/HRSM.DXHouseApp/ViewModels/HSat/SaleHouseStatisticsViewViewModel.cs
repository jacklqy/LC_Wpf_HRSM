using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Grid;
using HRSM.BLL;
using HRSM.Common;
using HRSM.Models.VModels;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels.HSat
{
        public class SaleHouseStatisticsViewViewModel:ListViewModelBase
        {
                private HouseTradeBLL htBLL = new HouseTradeBLL();
                public SaleHouseStatisticsViewViewModel()
                {
                        this.TotalCount = SalesList.Sum(s => s.TotalCount);
                        this.TotalRent = SalesList.Sum(s => s.RentCount);
                        this.TotalSale = SalesList.Sum(s => s.SaleCount);
                        this.PointsList = SetPointsList();
                }
                /// <summary>
                /// 销售统计数据
                /// </summary>
                public List<ViewSaleHouseStatisticsModel> SalesList
                {
                        get
                        {
                              return  htBLL.GetSaleHouseStatisticsData();
                        }
                }

                private int totalCount = 0;
                /// <summary>
                /// 总量
                /// </summary>
                public int TotalCount
                {
                        get {
                                return totalCount;
                        }
                        set
                        {
                                totalCount = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 总出租数
                /// </summary>
                private int totalRent=0;
                public int TotalRent
                {
                        get { return totalRent; }
                        set { totalRent = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 总出售数
                /// </summary>
                private int totalSale=0;
                public int TotalSale
                {
                        get { return totalSale; }
                        set { totalSale = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 图表源（点集合）
                /// </summary>
                private SeriesPoint3DStorage pointsList=new SeriesPoint3DStorage();
                public SeriesPoint3DStorage PointsList
                {
                        get
                        {
                                return pointsList;
                        }
                        set
                        {
                                pointsList = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 显示当前行的图表
                /// </summary>
                public ICommand ShowRowChartCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        this.PointsList = SetPointsList();
                                });
                        }
                }

                /// <summary>
                /// 显示总计图表
                /// </summary>
                public ICommand ShowAllChartCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        this.CurrentItem = null;
                                        this.PointsList = SetPointsList();
                                });
                        }
                }

                /// <summary>
                /// 导出数据
                /// </summary>
                public ICommand ExportDataCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        GridColumnCollection cols = o as GridColumnCollection;
                                        Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                                        sfd.Filter = "Excel Files (*.xlsx)|*.xlsx| Excel Files 2003 (*.xls)|*.xls";
                                        var dr = sfd.ShowDialog();
                                        if (dr == true)
                                        {
                                                string fileName = sfd.FileName;
                                                string extName = System.IO.Path.GetExtension(fileName);
                                                IWorkbook workbook = ExcelHelper.CreateWorkBook(extName);
                                                ISheet sheet = ExcelHelper.CreateSheet(workbook, "业务员总销售量统计");
                                                int count = 0;
                                                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                                                {

                                                        IRow row = sheet.CreateRow(count);
                                                        ICell cell0 = row.CreateCell(0);

                                                        string strTitle = "";
                                                        strTitle = "业务员总销售量统计";


                                                        cell0.SetCellValue(strTitle);
                                                        ICellStyle style = workbook.CreateCellStyle();
                                                        style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                                                        IFont font = workbook.CreateFont();
                                                        font.FontHeight = 20 * 20;
                                                        style.SetFont(font);
                                                        cell0.CellStyle = style;
                                                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 4));
                                                        ++count;

                                                        IRow tRow = sheet.CreateRow(count);
                                                        for (int j = 0; j <cols.Count; j++)
                                                        {
                                                                tRow.CreateCell(j).SetCellValue(cols[j].Header.ToString());
                                                        }
                                                        ++count;
                                                        int cellCount = tRow.LastCellNum;
                                                        Type type = typeof(ViewSaleHouseStatisticsModel);
                                                        PropertyInfo[] props = type.GetProperties();
                                                        for (int i = 0; i < this.SalesList.Count; ++i)
                                                        {
                                                                IRow rowData = sheet.CreateRow(count);
                                                                for (int j = tRow.FirstCellNum; j < cellCount; ++j)
                                                                {
                                                                        var p = type.GetProperty(cols[j].FieldName);
                                                                        object val = p.GetValue(this.SalesList[i]);
                                                                        if (val == null)
                                                                                val = "";
                                                                        rowData.CreateCell(j).SetCellValue(val.ToString());
                                                                }
                                                                ++count;
                                                        }
                                                        workbook.Write(fs); //写入到excel

                                                }
                                                ShowMsg("导出成功！");
                                        }
                                });
                        }
                }

                /// <summary>
                /// 生成图表源
                /// </summary>
                /// <returns></returns>
                private SeriesPoint3DStorage SetPointsList()
                {
                        pointsList.Points.Clear();
                        ViewSaleHouseStatisticsModel item = null;
                        if (this.CurrentItem != null)
                        {
                                item = this.CurrentItem as ViewSaleHouseStatisticsModel;
                                pointsList.Points.Add(new SeriesPoint3D("全部", "销售总量", item.TotalCount));
                                pointsList.Points.Add(new SeriesPoint3D("出租", "已出租数", item.RentCount));
                                pointsList.Points.Add(new SeriesPoint3D("出售", "已出售数", item.SaleCount));
                        }
                        else
                        {
                                pointsList.Points.Add(new SeriesPoint3D("全部", "销售总量", this.TotalCount));
                                pointsList.Points.Add(new SeriesPoint3D("出租", "已出租数", this.TotalRent));
                                pointsList.Points.Add(new SeriesPoint3D("出售", "已出售数", this.TotalSale));
                        }
                       
                        return pointsList;
                }
        }
}
