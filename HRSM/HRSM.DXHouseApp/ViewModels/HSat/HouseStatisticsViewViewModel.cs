using DevExpress.Xpf.Grid;
using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.Models;
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
        public class HouseStatisticsViewViewModel:ViewModelBase
        {
                private HouseBLL houseBLL = new HouseBLL();
                public HouseStatisticsViewViewModel()
                {
                        houseStat = houseBLL.GetHouseStatistics();
                }
                private ViewHouseCountSatisticsModel houseStat = new ViewHouseCountSatisticsModel();
                /// <summary>
                /// 房屋统计数据
                /// </summary>
                public List<ViewHouseCountSatisticsModel> HouseStatData
                {
                        get
                        {
                                List<ViewHouseCountSatisticsModel> list = new List<ViewHouseCountSatisticsModel>()
                                    {
                                        houseStat
                                    };
                                return list;
                        }
                }

                /// <summary>
                /// 房屋总数
                /// </summary>
                public int TotalCount
                {
                        get { return houseStat.TotalCount; }
                }
                /// <summary>
                /// 总出租数
                /// </summary>
                public int TRentCount
                {
                        get { return houseStat.TRentCount; }
                }
                /// <summary>
                /// 总出售数
                /// </summary>
                public int TSaleCount
                {
                        get { return houseStat.TSaleCount; }
                }
                /// <summary>
                /// 总量一栏数据源
                /// </summary>
                public List<HouseChartModel> TotalList
                {
                        get
                        {
                                return new List<HouseChartModel>()
                                {
                                          new HouseChartModel()
                                          {
                                                   XName="总数",
                                                   HCount=houseStat.TotalCount
                                          },
                                            new HouseChartModel()
                                            {
                                                XName="出租",
                                                HCount=houseStat.TRentCount
                                            },
                                            new HouseChartModel()
                                            {
                                                XName="出售",
                                                HCount=houseStat.TSaleCount
                                            }
                                };
                        }
                }

                /// <summary>
                /// 已发布
                /// </summary>
                public List<HouseChartModel> PubList
                {
                        get
                        {
                                return new List<HouseChartModel>()
                                {
                                          new HouseChartModel()
                                          {
                                                 XName="已发布",
                                                 HCount=houseStat.PublishedCount
                                          }
                                };
                        }
                }
                /// <summary>
                /// 未发布
                /// </summary>
                public List<HouseChartModel> UnpubList
                {
                        get
                        {
                                return new List<HouseChartModel>()
                                {
                                          new HouseChartModel()
                                          {
                                                 XName="未发布",
                                                 HCount=houseStat.UnPublishedCount
                                          }
                                };
                        }
                }

                /// <summary>
                /// 已租售
                /// </summary>
                public List<HouseChartModel> HasRentSale
                {
                        get
                        {
                                return new List<HouseChartModel>()
                                {
                                             new HouseChartModel()
                                                {
                                                    XName="出租",
                                                    HCount=houseStat.HasRentCount
                                                },
                                              new HouseChartModel()
                                                {
                                                    XName="出售",
                                                    HCount=houseStat.HasSaleCount
                                                }
                                };
                        }
                }

                /// <summary>
                /// 未租售
                /// </summary>
                public List<HouseChartModel> UnhasRentSale
                {
                        get
                        {
                                return new List<HouseChartModel>()
                                {
                                             new HouseChartModel()
                                                {
                                                    XName="出租",
                                                    HCount=houseStat.UnRentCount
                                                },
                                             new HouseChartModel()
                                                {
                                                    XName="出售",
                                                    HCount=houseStat.UnSaleCount
                                                }
                                };
                        }
                }

                /// <summary>
                /// 导出
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
                                                ISheet sheet = ExcelHelper.CreateSheet(workbook, "房屋数量统计");
                                                int count = 0;
                                                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                                                {
                                                        IRow row = sheet.CreateRow(count);
                                                        ICell cell0 = row.CreateCell(0);
                                                        string strTitle = "房屋数量统计";
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
                                                        sRow.CreateCell(0).SetCellValue($"房屋总计({TotalCount})");
                                                        //合并单元格
                                                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 1));
                                                        sRow.CreateCell(2).SetCellValue($"出租({TRentCount})");
                                                        //合并单元格
                                                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 2, 3));
                                                        sRow.CreateCell(4).SetCellValue($"出售({TSaleCount})");
                                                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 4, 5));
                                                        ++count;
                                                        IRow tRow = sheet.CreateRow(count);
                                                        for (int j = 0; j < cols.Count; j++)
                                                        {
                                                                tRow.CreateCell(j).SetCellValue(cols[j].Header.ToString());
                                                        }
                                                        ++count;
                                                        int cellCount = tRow.LastCellNum;
                                                        Type type = typeof(ViewHouseCountSatisticsModel);
                                                        PropertyInfo[] props = type.GetProperties();
                                                        for (int i = 0; i < this.HouseStatData.Count; ++i)
                                                        {
                                                                IRow rowData = sheet.CreateRow(count);
                                                                for (int j = tRow.FirstCellNum; j < cellCount; ++j)
                                                                {
                                                                        var p = type.GetProperty(cols[j].FieldName);
                                                                        object val = p.GetValue(this.HouseStatData[i]);
                                                                        if (val == null)
                                                                                val = "";
                                                                        rowData.CreateCell(j).SetCellValue(val.ToString());
                                                                }
                                                                ++count;
                                                        }
                                                        workbook.Write(fs); //写入到excel
                                                        ShowMsg("导出成功！");
                                                }
                                               
                                        }

                                });
                        }
                }
        }
}
