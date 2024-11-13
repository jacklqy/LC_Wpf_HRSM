using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.HS;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static HRSM.DXHouseApp.ComUtility;

namespace HRSM.DXHouseApp.ViewModels
{
        public class HouseListViewModel : ListViewModelBase
        {
                HouseBLL houseBLL = new HouseBLL();
                public HouseListViewModel()
                {

                }
                private string houseName;
                /// <summary>
                /// 条件：房屋名称关键字
                /// </summary>
                public string HouseName
                {
                        get { return houseName; }
                        set { houseName = value; }
                }

                private string rentSale;
                /// <summary>
                /// 条件：租售类型
                /// </summary>
                public string RentSale
                {
                        get
                        {
                                rentSale = rentSale == "请选择" ? null : rentSale;
                                return rentSale;
                        }
                        set { rentSale = value; }
                }

                private string houseDirection;
                /// <summary>
                /// 条件：房屋朝向
                /// </summary>
                public string HouseDirection
                {
                        get
                        {
                                houseDirection = houseDirection == "请选择" ? null : houseDirection;
                                return houseDirection;
                        }
                        set { houseDirection = value; }
                }

                private string houseLayout;
                /// <summary>
                /// 条件：房屋户型
                /// </summary>
                public string HouseLayout
                {
                        get { return houseLayout; }
                        set { houseLayout = value; }
                }

                /// <summary>
                /// 租售类别列表
                /// </summary>
                public List<string> RSList
                {
                        get
                        {
                                return ComUtility.GetRSTypes(true);
                        }
                }

                /// <summary>
                /// 房屋朝向列表
                /// </summary>
                public List<string> DirectionList
                {
                        get
                        {
                                return ComUtility.GetHouseDirections(true);
                        }
                }

                private bool showQueryBtn;
                /// <summary>
                /// 查询按钮是否显示
                /// </summary>
                public bool ShowQueryBtn
                {
                        get { return showQueryBtn; }
                        set
                        {
                                showQueryBtn = value;
                                OnPropertyChanged();
                        }
                }

                private List<ViewHouseInfoModel> houseList;
                /// <summary>
                /// 房屋列表
                /// </summary>
                public List<ViewHouseInfoModel> HouseList
                {
                        get
                        {
                                houseList = GetHouseList();
                                return houseList;
                        }
                        set
                        {
                                houseList = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 查询房屋列表信息
                /// </summary>
                public ICommand LoadAllHouses
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(o =>
                                {
                                        this.HouseList = GetHouseList();
                                        if (this.HouseList.Count == 0)
                                                this.ShowQueryBtn = false;
                                        else
                                                this.ShowQueryBtn = true;
                                });
                                return cmd;
                        }
                }

                /// <summary>
                /// 查询房屋详情
                /// </summary>
                public ICommand CheckHouseInfo
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(o =>
                                {
                                        if (o != null)
                                        {
                                                object[] paras = o as object[];
                                                int houseId = paras[1].GetInt();
                                                UserControl ucHouseList = paras[0] as UserControl;
                                                HouseInfoViewModel houseVM = new HouseInfoViewModel(houseId);
                                                AddDxTabItem(ucHouseList, "查看房屋详情", "houseInfo", houseVM);
                                        }
                                });
                                return cmd;
                        }
                }

                /// <summary>
                /// 获取所有已发布房屋列表
                /// </summary>
                /// <returns></returns>
                private List<ViewHouseInfoModel> GetHouseList()
                {
                        List<ViewHouseInfoModel> houselist = houseBLL.GetShowHouseList(this.HouseName, this.RentSale, this.houseDirection, this.HouseLayout);
                        return houselist;
                }


        }
}
