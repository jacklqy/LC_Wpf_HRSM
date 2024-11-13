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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static HRSM.DXHouseApp.ComUtility;

namespace HRSM.DXHouseApp.HSat
{
    /// <summary>
    /// Interaction logic for HouseStatList.xaml
    /// </summary>
    public partial class HouseStatList : UserControl
    {
        public HouseStatList()
        {
            InitializeComponent();
        }

        public string StatCountName { get; set; }
        public int StatCount { get; set; }
        private QueryStatListModel model = null;
        private HouseBLL houseBLL = new HouseBLL();
        private void UcHouseStatList_Loaded(object sender, RoutedEventArgs e)
        {
            //if(this.Tag!=null)
            //{
            //    model = this.Tag as QueryStatListModel;
            //}
            //if(model!=null)
            //{
            //    StatCountName = model.StatCountName;
            //    StatCount = model.StatCount;
            //    if (model.StatType == StatType.HouseStat)
            //    {
            //        liUser.Visibility = Visibility.Collapsed;
            //        liStTime.Visibility = Visibility.Collapsed;
            //        liEtTime.Visibility = Visibility.Collapsed;
            //    }
            //    else if(model.StatType == StatType.SaleHouseStat)
            //    {
            //        txtSaleUser.Text = model.SaleUser;
            //        liStTime.Visibility = Visibility.Collapsed;
            //        liEtTime.Visibility = Visibility.Collapsed;
            //    }
            //    else
            //    {
            //        txtSaleUser.Text = model.SaleUser;
            //        txtStTime.Text = model.StTime;
            //        txtEtTime.Text = model.EtTime;
                    
            //    }

            //    //处理条件，加载房屋列表
            //    List<ViewHouseInfoModel> houseList = houseBLL.GetStatHouseList(model.SatCountProName,model.SaleUser);
            //    gridHouses.ItemsSource = houseList;
            //}
           
            //this.DataContext = this;
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOutPutExcel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx| Excel Files 2003 (*.xls)|*.xls";
            var dr = sfd.ShowDialog();
            if (dr == true)
            {
                string fileName = sfd.FileName;
                string extName = System.IO.Path.GetExtension(fileName);
                IWorkbook workbook = ExcelHelper.CreateWorkBook(extName);
                ISheet sheet = ExcelHelper.CreateSheet(workbook, "房屋统计明细列表");
                int count = 0;
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    IRow row = sheet.CreateRow(count);
                    ICell cell0 = row.CreateCell(0);

                    string strTitle = "";
                    if (model.SaleUser != null)
                        strTitle +="销售员：" +model.SaleUser+" ";
                    strTitle +=model.StatCountName+ ":"+model.StatCount+"---房屋明细列表";

                    cell0.SetCellValue(strTitle);
                    ICellStyle style = workbook.CreateCellStyle();
                    style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    IFont font = workbook.CreateFont();
                    font.FontHeight = 20 * 20;
                    style.SetFont(font);
                    cell0.CellStyle = style;
                    sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, gridHouses.Columns.Count));
                    ++count;

                    IRow tRow = sheet.CreateRow(count);
                    for (int j = 0; j < gridHouses.Columns.Count; j++)
                    {
                        ICell cellHeader = tRow.CreateCell(j);
                        cellHeader.SetCellValue(gridHouses.Columns[j].Header.ToString());
                        ICellStyle style1 = workbook.CreateCellStyle();
                        style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        IFont font1 = workbook.CreateFont();
                        font1.FontHeight = 20*10;
                        font1.IsBold = true;
                        style1.SetFont(font1);
                        cellHeader.CellStyle = style1;
                        sheet.AutoSizeColumn(j);
                    }
                    ++count;
                    int cellCount = tRow.LastCellNum;
                    Type type = typeof(ViewHouseInfoModel);
                    PropertyInfo[] props = type.GetProperties();
                    List<ViewHouseInfoModel> list = gridHouses.ItemsSource as List<ViewHouseInfoModel>;
                    for (int i = 0; i < list.Count; ++i)
                    {
                        IRow rowData = sheet.CreateRow(count);
                        for (int j = tRow.FirstCellNum; j < cellCount; ++j)
                        {
                            var p = type.GetProperty(gridHouses.Columns[j].FieldName);
                            object val = p.GetValue(list[i]);
                            if (val == null)
                                val = "";
                            rowData.CreateCell(j).SetCellValue(val.ToString());
                        }
                        
                        ++count;
                    }
                    
                    workbook.Write(fs); //写入到excel

                }
                MessageBox.Show("导出成功！");
            }
        }
    }
}
