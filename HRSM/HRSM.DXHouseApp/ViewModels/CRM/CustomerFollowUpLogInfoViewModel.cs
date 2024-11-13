using HRSM.BLL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels.CRM
{
        /// <summary>
        /// 客户跟进日志信息ViewModel
        /// </summary>
        public class CustomerFollowUpLogInfoViewModel : InfoViewModelBase
        {
                private CustomerFollowUpLogBLL custFULogBLL = new CustomerFollowUpLogBLL();
                private CustomerRequestBLL custRequestBLL = new CustomerRequestBLL();
                private CustomerBLL customerBLL = new CustomerBLL();
                public CustomerFollowUpLogInfoViewModel() { }
                public CustomerFollowUpLogInfoViewModel(int actType, int logId,int custRequestId)
                {
                        this.ActType = actType;
                        this.FLogId = logId;
                        this.CustRequestId = custRequestId;
                        switch(ActType)
                        {
                                case 1:
                                        this.ConfirmBtnContent = "添加";
                                        this.FollowUpTime = DateTime.Now;
                                        this.IsConfirmBtnEnabled = true;
                                        this.FollowUpState = "跟进中";
                                        break;
                                case 2:
                                        this.ConfirmBtnContent = "修改";
                                        this.isIntented = false;
                                        this.custFollowUpLogInfo = custFULogBLL.GetCustomeFULogInfo(FLogId);
                                        this.IsCboRequestEnable = false;
                                        if(custRequestBLL.IsSuccessRequest(this.CustRequestId))
                                        {
                                                this.IsConfirmBtnVisible = System.Windows.Visibility.Hidden;
                                        }
                                        else
                                                this.IsConfirmBtnVisible = System.Windows.Visibility.Visible;
                                        this.oldFollowUpContent = this.custFollowUpLogInfo.FollowUpContent;
                                        break;
                                case 4:
                                        this.isIntented = false;
                                        this.custFollowUpLogInfo = custFULogBLL.GetCustomeFULogInfo(FLogId);
                                        this.IsCboRequestEnable = false;
                                        this.IsConfirmBtnVisible = System.Windows.Visibility.Hidden;
                                        break;
                                default: break;
                        }
                }
                private CustomerFollowUpLogInfoModel custFollowUpLogInfo = new CustomerFollowUpLogInfoModel();
                private bool isIntented = true;//当前是否是日志新增页面
                //原始跟进内容
                private string oldFollowUpContent = "";
                public string LoginUser { get; set; }
                /// <summary>
                /// 要修改的日志编号
                /// </summary>
                public int FLogId
                {
                        get { return custFollowUpLogInfo.FLogId; }
                        set { custFollowUpLogInfo.FLogId = value;
                                OnPropertyChanged();
                        }
                }
                /// <summary>
                /// 客户需求编号
                /// </summary>
                public int CustRequestId
                {
                        get { return custFollowUpLogInfo.CustRequestId; }
                        set { custFollowUpLogInfo.CustRequestId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 跟进时间
                /// </summary>
                public DateTime FollowUpTime
                {
                        get { return custFollowUpLogInfo.FollowUpTime; }
                        set { custFollowUpLogInfo.FollowUpTime = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 跟进人
                /// </summary>
                public string FollowUpUser
                {
                        get { return custFollowUpLogInfo.FollowUpUser; }
                        set { custFollowUpLogInfo.FollowUpUser = value;
                                OnPropertyChanged();
                        }
                }
                /// <summary>
                /// 跟进内容
                /// </summary>
                public string FollowUpContent
                {
                        get { return custFollowUpLogInfo.FollowUpContent; }
                        set { custFollowUpLogInfo.FollowUpContent = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 跟进状态
                /// </summary>
                public string FollowUpState
                {
                        get { return custFollowUpLogInfo.FollowUpState; }
                        set { custFollowUpLogInfo.FollowUpState = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 客户需求下拉框是否可用
                /// </summary>
                private bool isCboRequestEnable = true;
               public bool   IsCboRequestEnable
                {
                        get { return isCboRequestEnable; }
                        set { isCboRequestEnable = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 所有意向需求列表
                /// </summary>
                public List<CustomerRequestInfoModel> CboCustRequests
                {
                        get
                        {
                                List<CustomerRequestInfoModel> requests = custRequestBLL.GetIntentedCustRequests(isIntented);
                                requests.Insert(0, new CustomerRequestInfoModel()
                                {
                                        CustRequestId = 0,
                                        RequestContent = "请选择意向需求！"
                                });
                                return requests;
                        }
                }

                /// <summary>
                /// 跟进状态列表
                /// </summary>
                public List<string> CboFUStates
                {
                        get
                        {
                                List<string> list = custFULogBLL.GetFUStates();
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
                                        string msgTitle = $"客户日志{actMsg}";
                                        if (this.custFollowUpLogInfo.CustRequestId == 0)
                                        {
                                                ShowErr("请选择客户需求！", msgTitle);
                                                return;
                                        }
                                        if (string.IsNullOrEmpty(this.FollowUpContent))
                                        {
                                                ShowErr("请输入日志跟进内容！", msgTitle);
                                                return;
                                        }
                                        if(string.IsNullOrEmpty(FollowUpUser))
                                        {
                                                FollowUpUser = LoginUser;
                                        }
                                        bool bl = ActType == 1 ? custFULogBLL.AddCustomerFLogInfo(this.custFollowUpLogInfo) : custFULogBLL.UpdateCustomerFLogInfo(this.custFollowUpLogInfo);
                                        string sucType = bl ? "成功" : "失败";
                                        string msgInfo = $"客户日志{actMsg}{sucType}!";
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
                                        CloseWindow("custFollowUpLogInfoWindow", o);
                                });
                        }
                }
                #endregion
        }
}
