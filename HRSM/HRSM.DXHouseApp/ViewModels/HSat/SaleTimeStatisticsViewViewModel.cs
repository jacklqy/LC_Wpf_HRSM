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
        public  class SaleTimeStatisticsViewViewModel:ViewModelBase
        {
                private HouseTradeBLL htBLL = new HouseTradeBLL();
                public SaleTimeStatisticsViewViewModel()
                {
                        this.SaleList = GetSaleList();
                }
                /// <summary>
                /// 销售员关键词
                /// </summary>
                private string saleUser = "";
                public string SaleUser
                {
                        get { return saleUser; }
                        set { saleUser = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 开始时间
                /// </summary>
                private DateTime? stTime = null;
                public DateTime? StTime
                {
                        get { return stTime; }
                        set
                        {
                                stTime = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 结束时间
                /// </summary>
                private DateTime? etTime = null;
                public DateTime? EtTime
                {
                        get { return etTime; }
                        set
                        {
                                etTime = value;
                                OnPropertyChanged();
                        }
                }
                /// <summary>
                /// 销售员统计列表
                /// </summary>
                private List<ViewSaleHouseStatisticsModel> saleList = new List<ViewSaleHouseStatisticsModel>();
                public List<ViewSaleHouseStatisticsModel> SaleList
                {
                        get
                        {
                                return saleList;
                        }
                        set
                        {
                                saleList = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 统计
                /// </summary>
                private List<GridSummaryItem> totalSummaries = new List<GridSummaryItem>();
              public List<GridSummaryItem> TotalSummaries
                {
                        get { return totalSummaries; }
                        set { totalSummaries = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 查询命令
                /// </summary>
                public ICommand FindSaleListCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        this.SaleList = GetSaleList();
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
                                                ISheet sheet = ExcelHelper.CreateSheet(workbook, "业务员销售数据");
                                                int count = 0;
                                                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                                                {

                                                        IRow row = sheet.CreateRow(count);
                                                        ICell cell0 = row.CreateCell(0);

                                                        string strTitle = "";
                                                        if (this.StTime==null&& this.EtTime==null)
                                                                strTitle = "所有业务员销售量统计数据";
                                                        else
                                                        {
                                                                if (!string.IsNullOrEmpty(this.StTime.ToString()))
                                                                        strTitle += "统计时间：" + this.StTime.Value.ToString("yyyy-MM-dd");
                                                                if (!string.IsNullOrEmpty(this.EtTime.ToString()))
                                                                        strTitle += " 至 " + this.EtTime.Value.ToString("yyyy-MM-dd");
                                                                strTitle += "  业务员销售量统计数据";
                                                        }

                                                        cell0.SetCellValue(strTitle);
                                                        ICellStyle style = workbook.CreateCellStyle();
                                                        style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                                                        IFont font = workbook.CreateFont();
                                                        font.FontHeight = 20 * 20;
                                                        style.SetFont(font);
                                                        cell0.CellStyle = style;
                                                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 4));
                                                        ++count;
                                                        IRow sRow = sheet.CreateRow(count);
                                                        sRow.CreateCell(0).SetCellValue("销售员信息");
                                                        //合并单元格
                                                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 1));
                                                        sRow.CreateCell(2).SetCellValue("租售");
                                                        //合并单元格
                                                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 2, 3));
                                                        sRow.CreateCell(4).SetCellValue("总计");
                                                        ++count;
                                                        IRow tRow = sheet.CreateRow(count);
                                                        for (int j = 0; j < cols.Count; j++)
                                                        {
                                                                tRow.CreateCell(j).SetCellValue(cols[j].Header.ToString());
                                                        }
                                                        ++count;
                                                        int cellCount = tRow.LastCellNum;
                                                        Type type = typeof(ViewSaleHouseStatisticsModel);
                                                        PropertyInfo[] props = type.GetProperties();
                                                        for (int i = 0; i < this.SaleList.Count; ++i)
                                                        {
                                                                IRow rowData = sheet.CreateRow(count);
                                                                for (int j = tRow.FirstCellNum; j < cellCount; ++j)
                                                                {
                                                                        var p = type.GetProperty(cols[j].FieldName);
                                                                        object val = p.GetValue(this.SaleList[i]);
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
                /// 条件获取销售统计列表
                /// </summary>
                /// <returns></returns>
                private List<ViewSaleHouseStatisticsModel> GetSaleList()
                {
                        string sttime = null, ettime = null;
                        if (this.StTime.HasValue)
                                sttime = this.StTime.Value.ToString("yyyy-MM-dd");
                        if (this.EtTime.HasValue)
                                ettime = this.EtTime.Value.ToString("yyyy-MM-dd");
                        return htBLL.GetSaleTimeHouseStatisticsData(this.SaleUser, sttime, ettime);
                }
        }
}
