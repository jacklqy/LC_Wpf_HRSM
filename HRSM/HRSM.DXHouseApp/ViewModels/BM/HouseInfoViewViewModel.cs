using HRSM.BLL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels.BM
{
        public class HouseInfoViewViewModel : InfoViewModelBase
        {
                HouseBLL houseBLL = new HouseBLL();
                PUnitBLL punitBLL = new PUnitBLL();
                HouseLayoutBLL hlBLL = new HouseLayoutBLL();
                OwnerBLL ownerBLL = new OwnerBLL();
                HouseStateBLL hsBLL = new HouseStateBLL();
                public HouseInfoViewViewModel() { }
                public HouseInfoViewViewModel(int actType, int houseId)
                {
                        this.ActType = actType;
                        this.HouseId = houseId;
                        this.IsRent = true;
                        this.HouseDirection = "请选择房屋朝向";
                        this.HouseLayout = "请选择户型";
                        this.PriceUnit = "元/平方";
                        this.HouseState = "未出租";
                        switch (this.ActType)
                        {
                                case 1:
                                        this.ConfirmBtnContent = "添加";
                                        this.IsConfirmBtnEnabled = true;
                                        break;
                                case 2:
                                        this.ConfirmBtnContent = "修改";
                                        this.HouseInfo = GetHouseInfo();
                                        this.IsRent = HouseInfo.RentSale == "出租" ? true : false;
                                        this.isSale = HouseInfo.RentSale == "出售" ? true : false;
                                        this.oldHouseName = this.HouseInfo.HouseName;
                                        this.IsConfirmBtnEnabled = true;
                                        this.oldPic = this.HousePic;
                                        break;
                                case 4:
                                        this.HouseInfo = GetHouseInfo();
                                        this.IsRent = HouseInfo.RentSale == "出租" ? true : false;
                                        this.isSale = HouseInfo.RentSale == "出售" ? true : false;
                                        this.IsConfirmBtnVisible = System.Windows.Visibility.Hidden;
                                        break;
                                default: break;
                        }
                }
                private string oldHouseName = "";
                /// <summary>
                /// 房屋编号
                /// </summary>
                private int houseId;
                public int HouseId
                {
                        get { return houseId; }
                        set
                        {
                                houseId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 房屋信息实体
                /// </summary>
                private HouseInfoModel houseInfo = new HouseInfoModel();
                public HouseInfoModel HouseInfo
                {
                        get { return houseInfo; }
                        set
                        {
                                houseInfo = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 选择的单位
                /// </summary>
                public string PriceUnit
                {
                        get { return HouseInfo.PriceUnit; }
                        set
                        {
                                HouseInfo.PriceUnit = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 单位下拉框绑定列表
                /// </summary>
                public List<PriceUnitInfoModel> CboUnits
                {
                        get { return GetPriceUnits(); }
                }

                /// <summary>
                /// 是否出租
                /// </summary>
                private bool isRent = true;
                public bool IsRent
                {
                        get
                        {
                                return isRent;
                        }
                        set
                        {
                                isRent = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 是否出售
                /// </summary>
                private bool isSale = false;
                public bool IsSale
                {
                        get
                        {
                                return isSale;
                        }
                        set
                        {
                                isSale = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 选择的房屋朝向
                /// </summary>
                public string HouseDirection
                {
                        get { return HouseInfo.HouseDirection; }
                        set
                        {
                                HouseInfo.HouseDirection = value;
                                OnPropertyChanged();
                        }
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
                                       "请选择房屋朝向","坐南朝北","坐北朝南","坐东朝西","坐西朝东"
                                };
                        }
                }

                /// <summary>
                /// 选择的房屋户型
                /// </summary>
                public string HouseLayout
                {
                        get { return HouseInfo.HouseLayout; }
                        set
                        {
                                HouseInfo.HouseLayout = value;
                                OnPropertyChanged();
                        }
                }
                /// <summary>
                /// Cbo房屋户型列表
                /// </summary>
                public List<HouseLayoutInfoModel> CboLayouts
                {
                        get { return GetHouseLayouts(); }
                }

                /// <summary>
                /// 选择的业主编号
                /// </summary>
                public int OwnerId
                {
                        get { return HouseInfo.OwnerId; }
                        set
                        {
                                HouseInfo.OwnerId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// Cbo房屋业主列表
                /// </summary>
                public List<HouseOwnerInfoModel> CboOwners
                {
                        get { return GetHouseOwners(); }
                }

                /// <summary>
                /// 选择的房屋状态
                /// </summary>
                public string HouseState
                {
                        get { return HouseInfo.HouseState; }
                        set
                        {
                                HouseInfo.HouseState = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 房屋状态列表
                /// </summary>
                private List<HouseStateInfoModel> cboStates = new List<HouseStateInfoModel>();
                public List<HouseStateInfoModel> CboStates
                {
                        get { return GetHouseStates(); }
                        set
                        {
                                cboStates = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 房屋图片
                /// </summary>
                public string HousePic
                {
                        get { return HouseInfo.HousePic; }
                        set
                        {
                                HouseInfo.HousePic = value;
                                OnPropertyChanged();
                        }
                }


                /// <summary>
                /// 取消发布
                /// </summary>
                private bool unPublish = false;
                public bool UnPublish
                {
                        get
                        {
                                unPublish = HouseInfo.IsPublish ? false : true;
                                return unPublish;
                        }
                        set
                        {
                                unPublish = value;
                                OnPropertyChanged();
                        }
                }
                private bool blUpdatePic = false;
                private string oldPic = "";
                /// <summary>
                /// 提交命令
                /// </summary>
                public ICommand ConfirmCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        var info = this.HouseInfo;
                                        this.HouseInfo.RentSale = this.IsRent ? "出租" : "出售";
                                        SetUpdatePic();
                                        string houseName = this.HouseInfo.HouseName;
                                        string actMsg = this.ActType == 2 ? "修改" : "添加";
                                        string msgTitle = $"房屋{actMsg}";
                                        if (string.IsNullOrEmpty(this.HouseInfo.HouseName))
                                        {
                                                ShowErr("请输入房屋名！", msgTitle);
                                                return;
                                        }
                                        if (this.OwnerId == 0)
                                        {
                                                ShowErr("请选择业主！", msgTitle);
                                                return;
                                        }
                                        if (this.HouseId == 0 || (oldHouseName != "" && oldHouseName != houseName))
                                        {
                                                if (houseBLL.Exists(houseName))
                                                {
                                                        ShowErr("该房屋已存在！", msgTitle);
                                                        return;
                                                }
                                        }

                                        if (ActType == 2 && this.HouseInfo.IsPublish&&string.IsNullOrEmpty(this.HouseInfo.PublishUser))
                                        {
                                                this.HouseInfo.PublishUser = GetLoginUser(o);
                                                this.HouseInfo.PublishTime = DateTime.Now;
                                        }
                                        bool bl = ActType == 1 ? houseBLL.AddHouseInfo(this.HouseInfo) : houseBLL.UpdateHouseInfo(this.HouseInfo);
                                        string sucType = bl ? "成功" : "失败";
                                        string msgInfo = $"房屋：{houseName} {actMsg}{sucType}!";
                                        if (bl)
                                        {
                                                ShowMsg(msgInfo, msgTitle);
                                                InvokeReLoad();
                                        }
                                        else
                                        {
                                                ShowErr(msgInfo, msgTitle);
                                                return;
                                        }
                                });
                        }
                }

                /// <summary>
                /// 选择租售类别，重新加载房屋状态下拉框
                /// </summary>
                public ICommand CheckRentSaleCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        this.CboStates = GetHouseStates();
                                        this.HouseState = this.IsRent ? "未出租" : "未出售";
                                       
                                });
                        }
                }

                /// <summary>
                /// 设置房屋图片
                /// </summary>
                public ICommand ChoosePicCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "png Files (*.png)|*.png| jpg Files  (*.jpg)|*.jpg|bmp Files  (*.bmp)|*.bmp" };
                                        var result = ofd.ShowDialog();
                                        if (result == false) return;
                                        string fileName = ofd.FileName;
                                        if (!string.IsNullOrEmpty(fileName))
                                        {
                                                this.HousePic = fileName;
                                        }
                                });
                        }
                }

                /// <summary>
                /// 获取房屋信息
                /// </summary>
                /// <returns></returns>
                private HouseInfoModel GetHouseInfo()
                {
                        HouseInfoModel houseinfo = houseBLL.GetHouseInfo(this.HouseId);
                        if (houseinfo != null)
                        {
                                if (!string.IsNullOrEmpty(houseinfo.HousePic))
                                {
                                        houseinfo.HousePic = new Uri("pack://siteoforigin:,,,/" + houseinfo.HousePic, UriKind.Absolute).AbsolutePath;
                                }
                                else
                                        houseinfo.HousePic = "../imgs/house.jpg";

                        }
                        return houseinfo;
                }

                /// <summary>
                /// 设置修改房屋图片后的图片地址
                /// </summary>
                private void SetUpdatePic()
                {
                        if (oldPic != this.HousePic && !string.IsNullOrEmpty(this.HousePic))
                                blUpdatePic = true;
                        if (blUpdatePic)
                        {
                                string fileName = Path.GetFileNameWithoutExtension(this.HousePic);
                                fileName += DateTime.Now.ToString("yyyyMMddhhMMss") + Path.GetExtension(this.HousePic);
                                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"..\..\imgs\house"))
                                {
                                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"..\..\imgs\house");
                                }
                                string url = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\imgs\house\") + fileName;
                                if (!File.Exists(url))
                                {
                                        File.Copy(this.HousePic, url);
                                }
                                this.HousePic = null;
                                this.HousePic = "imgs/house/" + fileName;
                        }
                        else if (oldPic == this.HousePic)
                        {
                                string fileName = Path.GetFileName(this.HousePic);
                                this.HousePic = "imgs/house/" + fileName;
                        }
                        else
                                this.HousePic = null;
                }


                /// <summary>
                /// 获取房屋状态列表
                /// </summary>
                /// <returns></returns>
                private List<HouseStateInfoModel> GetHouseStates()
                {
                        int rsId = this.IsRent ? 1 : 2;
                        List<HouseStateInfoModel> list = hsBLL.GetHouseStates(rsId);
                        return list;
                }

                /// <summary>
                /// 获取所有的业主列表
                /// </summary>
                /// <returns></returns>
                private List<HouseOwnerInfoModel> GetHouseOwners()
                {
                        List<HouseOwnerInfoModel> list = ownerBLL.GetAllOwners();
                        list.Insert(0, new HouseOwnerInfoModel()
                        {
                                OwnerId = 0,
                                OwnerName = "请选择业主"
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
                                HLName = "请选择户型"
                        });
                        return layoutList;
                }

                /// <summary>
                /// 获取单位列表
                /// </summary>
                /// <returns></returns>
                private List<PriceUnitInfoModel> GetPriceUnits()
                {
                        List<PriceUnitInfoModel> list = punitBLL.GetPUnits();
                        return list;
                }
        }
}
