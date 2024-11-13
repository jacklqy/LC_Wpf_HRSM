using HRSM.BLL;
using HRSM.DXHouseApp.Models;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static HRSM.DXHouseApp.ComUtility;

namespace HRSM.DXHouseApp.ViewModels.BM
{
       public  class HouseTradeInfoViewModel:InfoViewModelBase
        {
                CustomerBLL customerBLL = new CustomerBLL();
                HouseTradeBLL houseTradeBLL = new HouseTradeBLL();
                HouseBLL houseBLL = new HouseBLL();
                public HouseTradeInfoViewModel()
                {

                }

                public HouseTradeInfoViewModel(int id)
                {
                        this.Id = id;
                        this.HouseInfo = houseBLL.GetViewHouseInfo(id);
                        this.RSName = HouseInfo.RentSale;
                        this.CustId = 0;
                        this.TradeWay = "请选择";
                        if (this.HouseInfo.RentSale == RSType.出售.ToString() && houseInfo.PriceUnit == "元/平方")
                        {
                                this.TradeAmount = decimal.Parse(decimal.Multiply(this.HouseInfo.HousePrice, this.HouseInfo.HouseArea).ToString("0.00"));
                        }
                        else
                                this.TradeAmount = houseInfo.HousePrice;
                        this.ConfirmBtnContent = "提交";
                }

                /// <summary>
                /// 房屋编号或交易编号
                /// </summary>
                private int id;
                public int Id
                {
                        get { return id; }
                        set { id = value;
                                OnPropertyChanged();
                        }
                }

               

                private ViewHouseInfoModel houseInfo = new ViewHouseInfoModel();
                /// <summary>
                /// 房屋信息
                /// </summary>
                public ViewHouseInfoModel HouseInfo
                {
                        get { return houseInfo; }
                        set
                        {
                                houseInfo = value;
                        }
                }

                /// <summary>
                /// 选择的租售类别
                /// </summary>
                private string rsName = "请选择";
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
                /// cboRentSale绑定列表
                /// </summary>
                public List<RentSaleModel> CboRentSales
                {
                        get { return GetRentSales(); }
                }

                /// <summary>
                /// 选择的客户编号
                /// </summary>
                private int custId = 0;
                public int CustId
                {
                        get { return custId; }
                        set
                        {
                                custId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// cboCustomer绑定列表
                /// </summary>
                public List<CustomerInfoModel> CboCustomers
                {
                        get { return GetCustomers(); }
                }

                /// <summary>
                /// 选择的交易方式
                /// </summary>
                private string tradeWay="现金";
                public string TradeWay
                {
                        get { return tradeWay; }
                        set { tradeWay = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                ///CboTradeWays绑定列表
                /// </summary>
                public List<string> CboTradeWays
                {
                        get
                        {
                                return GetTradeWays();
                        }
                }

                /// <summary>
                /// 交易总价
                /// </summary>
                private decimal tradeAmount;
                public decimal TradeAmount
                {
                        get { return tradeAmount; }
                        set { tradeAmount = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 办理人
                /// </summary>
                private string dealUser="";
                public string DealUser
                {
                        get { return dealUser; }
                        set { dealUser = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 交易时间
                /// </summary>
                private DateTime tradeTime=DateTime.Now;
                public DateTime TradeTime
                {
                        get { return tradeTime; }
                        set { tradeTime = value;
                                OnPropertyChanged();
                        }
                }

                public ICommand ConfirmCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        int ownerId = houseInfo.OwnerId;
                                        string rentSale = this.RSName == "请选择" ? "" : this.RSName;
                                        string msgTitle = "房屋交易";
                                        if (this.CustId == 0)
                                        {
                                              ShowErr("请选择客户！", msgTitle);
                                                return;
                                        }
                                        if (string.IsNullOrEmpty(dealUser))
                                        {
                                               ShowErr("请填写办理人！", msgTitle);
                                                return;
                                        }
                                        if (tradeAmount <= 0)
                                        {
                                               ShowErr("请填写交易总价！", msgTitle);
                                                return;
                                        }
                                        //提交交易信息
                                        HouseTradeInfoModel tradeInfo = new HouseTradeInfoModel()
                                        {
                                                HouseId = this.Id,
                                                OwnerId = ownerId,
                                                CustomerId = this.CustId,
                                                RentSale = rentSale,
                                                TradeAmount = this.TradeAmount,
                                                TradeTime = this.TradeTime,
                                                TradeWay = this.TradeWay,
                                                DealUser = this.DealUser,
                                                PriceUnit = this.HouseInfo.PriceUnit
                                        };
                                        bool blAdd = houseTradeBLL.AddHouseTradeInfo(tradeInfo);
                                        string suc = blAdd ? "成功" : "失败";
                                        string msg = $"房屋:{houseInfo.HouseName} 交易提交{suc}";
                                        if (blAdd)
                                        {
                                               ShowMsg(msg, msgTitle);
                                                InvokeReLoad();
                                        }
                                        else
                                        {
                                                ShowErr(msg, msgTitle);
                                                return;
                                        }
                                });
                        }
                }

                #region 关闭窗口命令
                public ICommand CloseWindowCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        CloseWindow("houseTradeInfoWindow", o);
                                });
                        }
                }
                #endregion



                /// <summary>
                /// 租售类别下拉框列表
                /// </summary>
                /// <returns></returns>
                private List<RentSaleModel> GetRentSales()
                {
                        List<RentSaleModel> list = new List<RentSaleModel>()
                        {
                               new RentSaleModel(){ RSId=0,RSName= "请选择" },
                                new RentSaleModel(){RSId=1,RSName="出租" },
                                new RentSaleModel(){RSId=2,RSName="出售" }
                         };
                        return list;
                }

                /// <summary>
                /// 加载客户列表
                /// </summary>
                private List<CustomerInfoModel> GetCustomers()
                {
                        List<CustomerInfoModel> customers = customerBLL.GetIntentedCustomers();
                        customers.Insert(0, new CustomerInfoModel()
                        {
                                CustomerId = 0,
                                CustomerName = "请选择客户！"
                        });
                        return customers;
                }

                /// <summary>
                /// 获取付款方式
                /// </summary>
                /// <returns></returns>
                public List<string> GetTradeWays()
                {
                        return new List<string>()
                        {
                                "现金","分期","按揭"
                        };
                }


        }
}
