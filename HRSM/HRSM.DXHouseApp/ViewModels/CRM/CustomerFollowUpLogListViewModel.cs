using DevExpress.Xpf.Grid;
using HRSM.BLL;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels.CRM
{
       public  class CustomerFollowUpLogListViewModel:ListViewModelBase
        {
                private CustomerFollowUpLogBLL cfulogBLL = new CustomerFollowUpLogBLL();
                public CustomerFollowUpLogListViewModel() {
                        InitPageList(0);
                }
                public CustomerFollowUpLogListViewModel(int custRequestId)
                {
                        InitPageList(custRequestId);
                }

                /// <summary>
                /// 初始化页面信息
                /// </summary>
                /// <param name="requestId"></param>
                private void InitPageList(int requestId)
                {
                        this.CustRequestId = requestId;
                        this.FollowUpLogList = FindCustFollowUpLogList();
                        InitToolBars();
                }

                /// <summary>
                /// 客户需求编号
                /// </summary>
                private int custRequestId;
                public int  CustRequestId
                {
                        get { return custRequestId; }
                        set {
                                custRequestId = value;
                                OnPropertyChanged();
                        }   
                }

                #region 查询条件
                /// <summary>
                /// 客户名（关键词）
                /// </summary>
                private string custName;
                public string CustName
                {
                        get { return custName; }
                        set { custName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 跟进人（关键词）
                /// </summary>
                private string followUpUser;
                public string FollowUpUser
                {
                        get { return followUpUser; }
                        set { followUpUser = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 需求内容（关键词）
                /// </summary>
                private string requestContent;
                public string RequestContent
                {
                        get { return requestContent; }
                        set { requestContent = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 跟进内容（关键词）
                /// </summary>
                private string followUpContent;
                public string FollowUpContent
                {
                        get { return followUpContent; }
                        set { followUpContent = value;
                                OnPropertyChanged();
                        }
                }
                #endregion

                /// <summary>
                /// 跟进日志列表
                /// </summary>
                private ObservableCollection<CustomerFollowUpLogInfoCheck> followUpLogList;
                public ObservableCollection<CustomerFollowUpLogInfoCheck> FollowUpLogList
                {
                        get { return followUpLogList; }
                        set
                        {
                                followUpLogList = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 初始化工具栏
                /// </summary>
                private void InitToolBars()
                {
                        this.ToolBarInfo = new ToolBarViewModel()
                        {
                                ShowFind = true,
                                ShowAllCustFULog = true,
                                AddCommand = new RelayCommand(o => ShowFULogInfoPage(1, 0,o), b => IsEdited),
                                EditCommand = new RelayCommand(o => ShowFULogInfoPage(2,o), b => IsEditEnableToolItems()),
                                DeleteCommand = new RelayCommand(o => DeleteCustomerFULogs(1), b => IsEditEnableToolItems()),
                                RecoverCommand = new RelayCommand(o => DeleteCustomerFULogs(0), b => IsDeletedEnableToolItems()),
                                RemoveCommand = new RelayCommand(o => DeleteCustomerFULogs(2), b => IsDeletedEnableToolItems()),
                                InfoCommand = new RelayCommand(o => ShowFULogInfoPage(4,o), b => this.FollowUpLogList.Count > 0),
                                CloseCommand = this.CloseTabPage,
                                FindCommand = new RelayCommand(o => ReloadFollowUpLogList()),
                                CustAllFULogCommand = new RelayCommand(o => {
                                        this.CustRequestId = 0;
                                        ReloadFollowUpLogList();
                                })
                        };
                }

                /// <summary>
                /// 刷新工具栏
                /// </summary>
               private void ReloadToolBars()
                {
                        this.ToolBarInfo.AddCommand.OnCanExecuted();
                        this.ToolBarInfo.EditCommand.OnCanExecuted();
                        this.ToolBarInfo.DeleteCommand.OnCanExecuted();
                        this.ToolBarInfo.RecoverCommand.OnCanExecuted();
                        this.ToolBarInfo.InfoCommand.OnCanExecuted();
                        this.ToolBarInfo.CustAllFULogCommand.OnCanExecuted();
                }

                /// <summary>
                /// 查询跟进日志列表
                /// </summary>
                public ICommand FindCustFollowUpLogListCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        ReloadFollowUpLogList();
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
                                        var list = this.FollowUpLogList;
                                        foreach (var cust in list)
                                        {
                                                cust.IsCheck = this.IsCheckAll;
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
                                                var obj = o as CustomerFollowUpLogInfoCheck;
                                                obj.IsCheck = !obj.IsCheck;
                                        }
                                });
                        }
                }

                /// <summary>
                /// 重新加载跟进日志列表
                /// </summary>
                private void ReloadFollowUpLogList()
                {
                        this.FollowUpLogList = FindCustFollowUpLogList();
                        ReloadToolBars();
                }

                /// <summary>
                ///按条件获取客户跟进日志列表
                /// </summary>
                /// <returns></returns>
                private ObservableCollection<CustomerFollowUpLogInfoCheck> FindCustFollowUpLogList()
                {
                        ObservableCollection<CustomerFollowUpLogInfoCheck> reList = new ObservableCollection<CustomerFollowUpLogInfoCheck>();
                        int isDeleted =IsShowDel ? 1 : 0;
                        List<ViewCustomerFollowUpLogInfoModel> fLogList = cfulogBLL.GetCustFLogs(this.CustRequestId, this.CustName, this.FollowUpUser, this.RequestContent, this.FollowUpContent, isDeleted);
                        fLogList.ForEach(fl => reList.Add(new CustomerFollowUpLogInfoCheck()
                        {
                                IsCheck = false,
                                FollowUpLogInfo = fl
                        }));
                        return reList;
                }

                /// <summary>
                /// 打开客户跟进日志信息页面
                /// </summary>
                /// <param name="actType"></param>
                /// <param name="logId"></param>
                private void ShowFULogInfoPage(int actType,int logId,object uc)
                {
                        CustomerFollowUpLogInfoViewModel custFULogInfoVM = new CustomerFollowUpLogInfoViewModel(actType, logId,this.CustRequestId);
                        custFULogInfoVM.LoginUser = GetLoginUser(uc);
                        custFULogInfoVM.ReLoadHandler += ReloadFollowUpLogList;
                        string typeName = GetInfoTypeName(actType);
                        ShowDialog("custFollowUpLogInfoWindow", custFULogInfoVM);//打开客户跟进日志信息页面
                }

                /// <summary>
                /// 打开修改、查看页面
                /// </summary>
                /// <param name="actType"></param>
                private void ShowFULogInfoPage(int actType,object uc)
                {
                        if(this.CurrentItem!=null)
                        {
                                CustomerFollowUpLogInfoCheck curFULog = this.CurrentItem as CustomerFollowUpLogInfoCheck;
                                ShowFULogInfoPage(actType, curFULog.FollowUpLogInfo.FLogId,uc);
                        }
                }

                /// <summary>
                /// 修改、删除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsEditEnableToolItems()
                {
                        bool bl = this.FollowUpLogList.Count > 0 && !IsShowDel;
                        return bl;
                }

                /// <summary>
                /// 恢复、移除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsDeletedEnableToolItems()
                {
                        bool bl = (this.FollowUpLogList.Count > 0 && IsShowDel);
                        return bl;
                }

                /// <summary>
                /// 删除客户日志处理
                /// </summary>
                /// <param name="isDeleted"></param>
                private void DeleteCustomerFULogs(int isDeleted)
                {
                        string typeName = GetDelTypeName(isDeleted);
                        string msgTitle = $"客户日志{typeName}";
                        List<int> delIds = this.FollowUpLogList.Where(fl => fl.IsCheck == true).Select(fl => fl.FollowUpLogInfo.FLogId).ToList();
                        if (delIds.Count > 0)
                        {
                                if (ShowQuestion($"您确定要{typeName}选择的客户日志信息吗？", msgTitle) == MsgBoxWindow.CustomMessageBoxResult.OK)
                                {
                                        bool blDel = false;
                                        switch (isDeleted)
                                        {
                                                case 1:
                                                        var SelflogList = this.FollowUpLogList.Where(fl => fl.IsCheck == true).Select(fl=>fl.FollowUpLogInfo).ToList();
                                                        if(cfulogBLL.IsUseOrSuccessLog(SelflogList))
                                                        {
                                                                ShowErr("选择的日志中存在已成交或跟进中的日志，不能删除！");
                                                                return;
                                                        }
                                                        blDel = cfulogBLL.LogicDelCustomerFULogList(delIds);
                                                        break;
                                                case 0:
                                                        blDel = cfulogBLL.RecoverCustomerFULogList(delIds);
                                                        break;
                                                case 2:
                                                        blDel = cfulogBLL.RemoveCustomerFULogList(delIds);
                                                        break;
                                        }
                                        string sucMsg = blDel ? "成功" : "失败";
                                        string msg = $"选择的客户日志信息{typeName}{sucMsg}！";
                                        if (blDel)
                                        {
                                                ShowMsg(msg, msgTitle);
                                                ReloadFollowUpLogList();
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

             
        }
}
