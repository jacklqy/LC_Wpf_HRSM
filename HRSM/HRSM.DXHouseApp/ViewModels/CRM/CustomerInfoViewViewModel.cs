using HRSM.BLL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels.CRM
{
        /// <summary>
        /// 客户信息页面ViewModel
        /// </summary>
        public class CustomerInfoViewViewModel:InfoViewModelBase
        {
                private CustomerBLL customerBLL = new CustomerBLL();
                public CustomerInfoViewViewModel() { }
                public CustomerInfoViewViewModel(int actType,int custId)
                {
                        this.ActType = actType;
                        this.CustId = custId;
                        switch (this.ActType)
                        {
                                case 1:
                                        this.ConfirmBtnContent = "添加";
                                        this.IsPersonal = true;
                                        this.IsUnit = false;
                                        this.CustInfo.CreateTime = DateTime.Now;
                                        this.IsConfirmBtnEnabled = true;
                                        break;
                                case 2:
                                        this.ConfirmBtnContent = "修改";
                                        this.CustInfo = customerBLL.GetCustomerInfo(custId);
                                        this.IsConfirmBtnEnabled = true;
                                        this.oldCustName = this.CustInfo.CustomerName;
                                        break;
                                case 4:
                                        this.CustInfo = customerBLL.GetCustomerInfo(custId);
                                        this.IsConfirmBtnVisible = System.Windows.Visibility.Hidden;
                                        break;
                                default: break;
                        }
                }
                private string oldCustName = "";
                /// <summary>
                /// 客户编号
                /// </summary>
                private int custId;
                public int CustId
                {
                        get { return custId; }
                        set { custId = value;
                                OnPropertyChanged();
                        }
                }

                public string CustomerName
                {
                        get {
                                return CustInfo.CustomerName; }
                        set { CustInfo.CustomerName = value;
                                OnPropertyChanged();

                        }
                }


                /// <summary>
                /// 客户信息实体
                /// </summary>
                private CustomerInfoModel custInfo=new CustomerInfoModel();
                public CustomerInfoModel CustInfo
                {
                        get { return custInfo; }
                        set { custInfo = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 客户类型--个人是否勾选
                /// </summary>
                private bool  isPersonal=true;
                public bool  IsPersonal
                {
                        get {
                                if(!string.IsNullOrEmpty(CustInfo.CustomerType))
                                      isPersonal=  CustInfo.CustomerType == "个人"?true:false;
                                return isPersonal; }
                        set { isPersonal = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 客户类型--单位是否勾选
                /// </summary>
                private bool isUnit = false;
                public bool IsUnit
                {
                        get
                        {
                                if (!string.IsNullOrEmpty(CustInfo.CustomerType))
                                        isUnit = CustInfo.CustomerType == "单位" ? true : false;
                                return isUnit;
                        }
                        set
                        {
                                isUnit = value;
                                OnPropertyChanged();
                        }
                }


                /// <summary>
                /// 客户状态列表
                /// </summary>
                public List<string> CboCustStates
                {
                        get
                        {
                                return new List<string>() { "普通客户", "意向客户" };
                        }
                }

                /// <summary>
                /// 提交命令
                /// </summary>
                public ICommand ConfirmCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        this.CustInfo.CustomerType = this.IsPersonal ? "个人" : "单位";
                                        string actMsg = ActType == 2 ? "修改" : "添加";
                                        string msgTitle = $"客户{actMsg}";
                                        if (string.IsNullOrEmpty(this.CustInfo.CustomerName))
                                        {
                                                ShowErr("请输入客户名！", msgTitle);
                                                return;
                                        }
                                        if (string.IsNullOrEmpty(CustInfo.CustomerPhone))
                                        {
                                                ShowErr("请输入客户电话！", msgTitle);
                                                return;
                                        }
                                        if (custId == 0 || (oldCustName != "" && oldCustName != this.CustInfo.CustomerName))
                                        {
                                                if (customerBLL.Exists(this.CustInfo.CustomerName, this.CustInfo.CustomerPhone))
                                                {
                                                        ShowErr("该客户已存在！", msgTitle);
                                                        return;
                                                }
                                        }

                                        bool bl = ActType == 1 ? customerBLL.AddCustomerInfo(CustInfo) : customerBLL.UpdateCustomerInfo(CustInfo);
                                        string sucType = bl ? "成功" : "失败";
                                        string msgInfo = $"客户：{CustInfo.CustomerName} {actMsg}{sucType}!";
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


        }
}
