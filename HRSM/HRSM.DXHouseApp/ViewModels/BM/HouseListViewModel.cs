using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.Models;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels.BM
{
        public class HouseListViewModel : ListViewModelBase
        {
                HouseBLL houseBLL = new HouseBLL();
                HouseStateBLL hsBLL = new HouseStateBLL();
                HouseLayoutBLL hlBLL = new HouseLayoutBLL();
                public HouseListViewModel()
                {
                        this.HouseList = FindHouseList();
                        InitToolbars();
                }
                /// <summary>
                /// 关键词
                /// </summary>
                private string keyWords="";
                public string KeyWords
                {
                        get { return keyWords; }
                        set
                        {
                                keyWords = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 选择的租售类别
                /// </summary>
                private string rsName="全部";
                public string RSName
                {
                        get { return rsName; }
                        set
                        {
                                rsName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 选择的租售类别编号
                /// </summary>
                private int rsId=0;
                public int RSId
                {
                        get { return rsId; }
                        set
                        {
                                rsId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// cboRentSale绑定列表
                /// </summary>
                public List<RentSaleModel> CboRentSales
                {
                        get { return GetRentSales(); }
                }

                /// <summary>
                /// 选择的房屋状态
                /// </summary>
                private string stateName=null;
                public string StateName
                {
                        get { return stateName; }
                        set
                        {
                                stateName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 房屋状态绑定列表
                /// </summary>
                private List<HouseStateInfoModel> houseStates = new List<HouseStateInfoModel>();
                public List<HouseStateInfoModel> CboStates
                {
                        get {
                                houseStates = GetHouseStates();
                                return houseStates; }
                        set {
                                houseStates = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 选择的户型
                /// </summary>
                private string layoutName="全部";
                public string LayoutName
                {
                        get { return layoutName; }
                        set
                        {
                                layoutName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 房屋户型绑定列表
                /// </summary>
                public List<HouseLayoutInfoModel> CboLayouts
                {
                        get { return GetHouseLayouts(); }
                }

                /// <summary>
                /// 房屋朝向列表
                /// </summary>
                public List<string> CboDirections
                {
                        get
                        {
                                return new List<string>()
                                {
                                        "全部","坐南朝北","坐北朝南","坐东朝西","坐西朝东"
                                };
                        }
                }

                /// <summary>
                /// 选择的房屋朝向
                /// </summary>
                private string directionName="全部";
                public string DirectionName
                {
                        get { return directionName; }
                        set
                        {
                                directionName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 选择的发布状态
                /// </summary>
                private int isPublishedSel=-1;
                public int IsPublishedSel
                {
                        get { return isPublishedSel; }
                        set
                        {
                                isPublishedSel = value;
                                OnPropertyChanged();
                        }
                }



                /// <summary>
                /// 房屋列表
                /// </summary>
                private ObservableCollection<HouseInfoCheck> houseList;
                public ObservableCollection<HouseInfoCheck> HouseList
                {
                        get { return houseList; }
                        set
                        {
                                houseList = value;
                                OnPropertyChanged();
                        }
                }


                #region 命令配置
                /// <summary>
                /// 发布栏的Rbtn按钮的勾选命令
                /// </summary>
                public ICommand SelPublishedCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                               {
                                          if (o != null)
                                          {
                                               int intPubVal = o.GetInt() ;
                                               this.IsPublishedSel = intPubVal;
                                               ReloadHouseList();
                                          }
                                });
                        }
                }

                /// <summary>
                /// 查询房屋列表命令
                /// </summary>
                public ICommand FindHouseListCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        ReloadHouseList();
                                });
                        }
                }

                /// <summary>
                /// 选择租售类别，加载房屋状态列表
                /// </summary>
                public ICommand LoadHouseStatesCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        this.CboStates = GetHouseStates();
                                        this.StateName = "全部";
                                });
                        }
                }

                /// <summary>
                /// 全选或全不选
                /// </summary>
                public ICommand CheckAllCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        var list = this.HouseList;
                                        foreach (var house in list)
                                        {
                                                house.IsCheck = this.IsCheckAll;
                                        }
                                });
                        }
                }

                /// <summary>
                /// 单个选择或不选
                /// </summary>
                public ICommand CheckItemCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        if (o != null)
                                        {
                                                var obj = o as HouseInfoCheck;
                                                obj.IsCheck = !obj.IsCheck;
                                        }

                                });
                        }
                }

                public ICommand TradeHouseCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        if (o != null)
                                        {
                                                var obj = o as HouseInfoCheck;
                                                HouseTradeInfoViewModel houseTradeVM = new HouseTradeInfoViewModel(obj.ViewHouseInfo.HouseId);
                                                houseTradeVM.ReLoadHandler += ReloadHouseList;//刷新房屋列表
                                                ShowDialog("houseTradeInfoWindow", houseTradeVM);
                                        }
                                       
                                });
                        }
                }
                #endregion

                /// <summary>
                /// 初始化工具栏
                /// </summary>
                private void InitToolbars()
                {
                        this.ToolBarInfo = new ToolBarViewModel()
                        {
                                ShowFind = true,
                                ShowImport = true,
                                ShowPublish = true,
                                ShowUnPublish = true,
                                AddCommand = new RelayCommand(o => ShowHouseInfoPage(1, 0, o), b => IsEdited),
                                EditCommand = new RelayCommand(o => ShowHouseInfoPage(2, o), b => IsEditEnableToolItems()),
                                DeleteCommand = new RelayCommand(o => DeleteHouses(1, false), b => IsEditEnableToolItems()),
                                RecoverCommand = new RelayCommand(o => DeleteHouses(0, false), b => IsDeletedEnableToolItems()),
                                RemoveCommand = new RelayCommand(o => DeleteHouses(2, false), b => IsDeletedEnableToolItems()),
                                InfoCommand = new RelayCommand(o => ShowHouseInfoPage(4, o), b => this.HouseList.Count > 0),
                                CloseCommand = this.CloseTabPage,
                                FindCommand = new RelayCommand(o=>ReloadHouseList()),
                                ImportCommand = new RelayCommand(o => ImportHouseInfos()),
                                PublishCommand = new RelayCommand(o => PublishHouses(1,o), b => IsPublishedEnable()),
                                UnPublishCommand = new RelayCommand(o => PublishHouses(0,o), b => IsUnPublishedEnable())
                        };
                }

                /// <summary>
                /// 刷新工具项
                /// </summary>
                private void ReloadToolBars()
                {
                        this.ToolBarInfo.AddCommand.OnCanExecuted();
                        this.ToolBarInfo.EditCommand.OnCanExecuted();
                        this.ToolBarInfo.DeleteCommand.OnCanExecuted();
                        this.ToolBarInfo.RecoverCommand.OnCanExecuted();
                        this.ToolBarInfo.RemoveCommand.OnCanExecuted();
                        this.ToolBarInfo.InfoCommand.OnCanExecuted();
                        this.ToolBarInfo.PublishCommand.OnCanExecuted();
                        this.ToolBarInfo.UnPublishCommand.OnCanExecuted();
                }

                /// <summary>
                /// 条件查询房屋列表
                /// </summary>
                /// <returns></returns>
                private ObservableCollection<HouseInfoCheck> FindHouseList()
                {
                        ObservableCollection<HouseInfoCheck> reList = new ObservableCollection<HouseInfoCheck>();
                        string keywords = this.KeyWords;
                        string rsName = this.RSId == 0 ? "" : this.RSName;
                        string hsName =( this.StateName==null || this.StateName == "全部" )? "" : this.StateName.Trim();
                        string hlName = (this.LayoutName == null || this.LayoutName == "全部" )? "" : this.LayoutName.Trim();
                        string hdName = (this.DirectionName == null || this.DirectionName == "全部") ? "" : this.DirectionName.Trim();
                        int isDeleted = IsShowDel ? 1 : 0;

                        List<ViewHouseInfoModel> list = houseBLL.GetHouseList(keywords, rsName, hdName, hlName, hsName, IsPublishedSel, isDeleted);
                        list.ForEach(h => reList.Add(new HouseInfoCheck() {
                                IsCheck=false,
                                ViewHouseInfo=h,
                                IsPublish=h.IsPublish
                        }));
                        return reList;
                }

                /// <summary>
                /// 导入房屋信息
                /// </summary>
                private void ImportHouseInfos()
                {
                        var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "Excel Files (*.xlsx)|*.xlsx| Excel Files 2003 (*.xls)|*.xls" };
                        var result = ofd.ShowDialog();
                        if (result == false) return;
                        string fileName = ofd.FileName;
                        if (!string.IsNullOrEmpty(fileName))
                        {
                                string msgTitle = "导入房屋信息";
                                int re = houseBLL.ImportHouseData(fileName, "房屋数据", true);
                                if (re == 1)
                                {
                                        //导入成功
                                        ShowMsg("房屋信息导入成功！", msgTitle);
                                        ReloadHouseList();
                                }
                                else if (re == 0)
                                {
                                        //导入失败
                                        ShowErr("房屋信息导入失败，请检查导入格式！", msgTitle);
                                        return;
                                }
                                else
                                {
                                        //没有数据可导入
                                        ShowErr("导入文件中没有数据！", msgTitle);
                                        return;
                                }
                        }
                }

                /// <summary>
                /// 发布或取消发布 1-发布  0-取消发布
                /// </summary>
                /// <param name="isPublish"></param>
                public void PublishHouses(int isPublish, object uc)
                {
                        string typeName = isPublish == 1 ? "发布" : "取消发布";
                        string msgTitle = $"{typeName}房屋信息";
                        List<int> Ids = new List<int>();
                        //获取勾选的房屋列表
                        List<HouseInfoCheck> selList = this.HouseList.Where(h=>h.IsCheck==true).ToList();
                        Ids = selList.Select(h => h.ViewHouseInfo.HouseId).ToList();
                        if (Ids.Count > 0)
                        {
                                if (ShowQuestion($"您确定要{typeName}选择的房屋信息吗？", msgTitle) == MsgBoxWindow.CustomMessageBoxResult.OK)
                                {
                                        string userName = GetLoginUser(uc);
                                        bool bl = isPublish == 1 ? houseBLL.PublishHouse(Ids, userName) : houseBLL.UnPublishHouse(Ids);
                                        string suc = bl ? "成功" : "失败！";
                                        string msg = $"选择的房屋信息{typeName} {suc}！";
                                        if (bl)
                                        {
                                                ShowMsg(msg, msgTitle);
                                                ReloadHouseList();
                                        }
                                        else
                                        {
                                                ShowErr(msg, msgTitle);
                                                return;
                                        }
                                }
                        }
                }

                #region 房屋删除处理
                /// <summary>
                /// 单条删除处理
                /// </summary>
                /// <param name="o"></param>
                /// <param name="isDeleted"></param>
                private void SingleDelHouse(object o, int isDeleted)
                {

                        if (o != null)
                        {
                                int Id = (int)o;
                                HouseInfoCheck house = this.HouseList.Where(h => h.ViewHouseInfo.HouseId == Id).FirstOrDefault();
                                if (this.SelectedItems != null)
                                        this.SelectedItems.Clear();
                                else
                                        this.SelectedItems = new List<HouseInfoCheck>();
                                this.SelectedItems.Add(house);
                                DeleteHouses(isDeleted, true);
                        }
                }

                /// <summary>
                /// 删除用户处理
                /// </summary>
                /// <param name="isDeleted"></param>
                /// <param name="isSingle"></param>
                private void DeleteHouses(int isDeleted, bool isSingle)
                {
                        string typeName = GetDelTypeName(isDeleted);
                        string msgTitle = $"房屋{typeName}";
                        List<int> delIds = new List<int>();
                        if (!isSingle)
                        {
                                delIds = this.HouseList.Where(u => u.IsCheck == true).Select(h => h.ViewHouseInfo.HouseId).ToList();
                        }
                        else
                        {
                                List<HouseInfoCheck> selList = this.SelectedItems as List<HouseInfoCheck>;
                                delIds = selList.Select(h => h.ViewHouseInfo.HouseId).ToList();
                        }
                        if (delIds.Count > 0)
                        {
                                if (isDeleted == 1)
                                {
                                        if (houseBLL.IsPublishedHouse(delIds))
                                        {
                                                ShowErr("存在已发布的房屋信息，不能删除！");
                                                return;
                                        }
                                        else if (houseBLL.IsTradeHouse(delIds))
                                        {
                                                ShowErr("存在已交易的房屋，不能删除！");
                                                return;
                                        }
                                }
                                if (ShowQuestion($"您确定要{typeName}选择的房屋信息吗？", msgTitle) == MsgBoxWindow.CustomMessageBoxResult.OK)
                                {
                                        bool blDel = false;
                                        switch (isDeleted)
                                        {
                                                case 1:
                                                        blDel = houseBLL.LogicDelHouseList(delIds);
                                                        break;
                                                case 0:
                                                        blDel = houseBLL.RecoverHouseList(delIds);
                                                        break;
                                                case 2:
                                                        blDel = houseBLL.RemoveHouseList(delIds);
                                                        break;
                                        }
                                        string sucMsg = blDel ? "成功" : "失败";
                                        string msg = $"选择的房屋信息{typeName}{sucMsg}！";
                                        if (blDel)
                                        {
                                                ShowMsg(msg, msgTitle);
                                                ReloadHouseList();
                                        }
                                        else
                                        {
                                                ShowErr(msg, msgTitle);
                                                return;
                                        }
                                }
                        }
                        else
                        {
                                ShowErr($"没有要{typeName}的信息！", msgTitle);
                                return;
                        }
                }

                #endregion

                #region 工具项按钮的可用状态
                /// <summary>
                /// 修改、删除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsEditEnableToolItems()
                {
                        bool bl = this.HouseList.Count > 0 && !IsShowDel;
                        return bl;
                }

                /// <summary>
                /// 恢复、移除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsDeletedEnableToolItems()
                {
                        bool bl = (this.HouseList.Count > 0 && IsShowDel);
                        return bl;
                }

                /// <summary>
                /// 发布按钮可用
                /// </summary>
                /// <returns></returns>
                private bool IsPublishedEnable()
                {
                        bool bl = (this.HouseList.Count > 0 && !IsShowDel && (this.IsPublishedSel ==0));
                        return bl;
                }
                /// <summary>
                /// 取消发布可用
                /// </summary>
                /// <returns></returns>
                private bool IsUnPublishedEnable()
                {
                        bool bl = (this.HouseList.Count > 0 && !IsShowDel && (this.IsPublishedSel == 1));
                        return bl;
                }
                #endregion

                #region 打开房屋信息页面
                /// <summary>
                /// 打开修改、查看的信息页面
                /// </summary>
                /// <param name="actType"></param>
                /// <param name="uc"></param>
                private void ShowHouseInfoPage(int actType, object uc)
                {
                        if (this.CurrentItem != null)
                        {
                                HouseInfoCheck curHouse = this.CurrentItem as HouseInfoCheck;
                                ShowHouseInfoPage(actType, curHouse.ViewHouseInfo.HouseId,uc);
                        }
                }

                /// <summary>
                /// 显示房屋信息页面
                /// </summary>
                /// <param name="actType"></param>
                /// <param name="houseId"></param>
                /// <param name="uc"></param>
                private void ShowHouseInfoPage(int actType, int houseId, object uc)
                {
                        HouseInfoViewViewModel houseVM = new HouseInfoViewViewModel(actType, houseId);
                        houseVM.ReLoadHandler += ReloadHouseList;
                        string typeName = GetInfoTypeName(actType);
                        //打开信息页面，添加到Tab页中
                        AddDxTabItem(uc, $"房屋信息——{typeName} 页面", "houseInfoView", houseVM);//打开房屋信息页面
                }
                #endregion

                /// <summary>
                /// 刷新房屋列表
                /// </summary>
                private void ReloadHouseList()
                {
                       this.HouseList = FindHouseList();
                        ReloadToolBars();
                }

                /// <summary>
                /// 租售类别下拉框列表
                /// </summary>
                /// <returns></returns>
                private List<RentSaleModel> GetRentSales()
                {
                        List<RentSaleModel> list = new List<RentSaleModel>()
                        {
                               new RentSaleModel(){ RSId=0,RSName= "全部" },
                                new RentSaleModel(){RSId=1,RSName="出租" },
                                new RentSaleModel(){RSId=2,RSName="出售" }
                         };
                        return list;
                }

                /// <summary>
                /// 获取房屋状态列表
                /// </summary>
                /// <returns></returns>
                private List<HouseStateInfoModel> GetHouseStates()
                {
                        List<HouseStateInfoModel> list = hsBLL.GetHouseStates(this.RSId);
                        list.Insert(0, new HouseStateInfoModel()
                        {
                                StateId = 0,
                                StateName = "全部"
                        });
                        return list;
                }

                /// <summary>
                /// 获取房屋户型列表
                /// </summary>
                /// <returns></returns>
                private List<HouseLayoutInfoModel> GetHouseLayouts()
                {
                        List<HouseLayoutInfoModel> layoutList = hlBLL.GetHouseLayouts();
                        layoutList.Insert(0, new HouseLayoutInfoModel()
                        {
                                HLId = 0,
                                HLName = "全部"
                        });
                        return layoutList;
                }
        }
}
