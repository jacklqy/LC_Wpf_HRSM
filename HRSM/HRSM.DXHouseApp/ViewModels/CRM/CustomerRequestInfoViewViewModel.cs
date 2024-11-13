using HRSM.BLL;
using HRSM.Models.DModels;
using HRSM.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels.CRM
{
        public  class CustomerRequestInfoViewViewModel:InfoViewModelBase
        {
                private CustomerRequestBLL custRequestBLL = new CustomerRequestBLL();
                private CustomerBLL customerBLL = new CustomerBLL();
                public CustomerRequestInfoViewViewModel() { }
                public CustomerRequestInfoViewViewModel(int actType,int custRequestId)
                {
                        this.ActType = actType;
                        this.CustRequestId = CustRequestId;
                        switch (ActType)
                        {
                                case 1:
                                        this.ConfirmBtnContent = "添加";
                                        this.CustomerId = 0;
                                        this.IsConfirmBtnEnabled = true;
                                        break;
                                case 2:
                                        this.ConfirmBtnContent = "修改";
                                        this.custRequestInfo = custRequestBLL.GetCustomerRequestInfo(custRequestId);
                                        this.IsConfirmBtnEnabled = true;
                                        this.oldRequestContent = this.custRequestInfo.RequestContent;
                                        break;
                                case 4:
                                        this.custRequestInfo = custRequestBLL.GetCustomerRequestInfo(custRequestId);
                                        this.IsConfirmBtnVisible = System.Windows.Visibility.Hidden;
                                        break;
                                default:break;
                        }
                }
                private CustomerRequestInfoModel custRequestInfo = new CustomerRequestInfoModel();
                private string oldRequestContent = "";
                /// <summary>
                /// 客户需求编号
                /// </summary>
                public int CustRequestId
                {
                        get { return custRequestInfo.CustRequestId; }
                        set {
                                custRequestInfo.CustRequestId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 选择的客户编号
                /// </summary>
                public int  CustomerId
                {
                        get { return custRequestInfo.CustomerId; }
                        set {
                                custRequestInfo.CustomerId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 跟进人
                /// </summary>
                public string FollowUpUser
                {
                        get { return custRequestInfo.FollowUpUser; }
                        set { custRequestInfo.FollowUpUser = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 需求内容
                /// </summary>
                public string RequestContent
                {
                        get { return custRequestInfo.RequestContent; }
                        set { custRequestInfo.RequestContent = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 客户列表
                /// </summary>
                public List<CboCustomerInfoModel> LuCustomers
                {
                        get
                        {
                                List<CboCustomerInfoModel> list = customerBLL.GetCustomers(ActType);
                                list.Insert(0, new CboCustomerInfoModel()
                                {
                                        CustomerId = 0,
                                        CustomerName = "请选择客户"
                                });
                                return list;
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
                                        string actMsg = ActType == 2 ? "修改" : "添加";
                                        string msgTitle = $"客户需求{actMsg}页面";
                                        if (this.CustomerId == 0)
                                        {
                                                ShowErr("请选择客户！", msgTitle);
                                                return;
                                        }
                                        if (string.IsNullOrEmpty(this.RequestContent))
                                        {
                                                ShowErr("请输入客户需求！", msgTitle);
                                                return;
                                        }
                                        bool bl = false;
                                        if (this.ActType == 2)
                                                bl = custRequestBLL.UpdateCustomerRequestInfo(this.custRequestInfo);
                                        else
                                                bl = custRequestBLL.AddCustomerRequestInfo(this.custRequestInfo);
                                       
                                      
                                        string sucType = bl ? "成功" : "失败";
                                        string msgInfo = $"客户需求 {actMsg}{sucType}!";
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

                #region 关闭窗口命令
                public ICommand CloseWindowCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        CloseWindow("customerRequestInfoWindow", o);
                                });
                        }
                }
                #endregion
        }
}
