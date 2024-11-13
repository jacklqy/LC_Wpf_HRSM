using DevExpress.Xpf.Grid;
using HRSM.BLL;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels.CRM
{
        public class CustomerRequestListViewModel : ListViewModelBase
        {
                private CustomerRequestBLL crBLL = new CustomerRequestBLL();
                private CustomerBLL customerBLL = new CustomerBLL();
                private CustomerFollowUpLogBLL cfulBLL = new CustomerFollowUpLogBLL();
                public CustomerRequestListViewModel() {
                        InitPageList(0);
                }
                public CustomerRequestListViewModel(int custId)
                {
                        InitPageList(custId);
                }

                /// <summary>
                /// 页面初始化
                /// </summary>
                /// <param name="custId"></param>
                private void InitPageList(int custId)
                {
                        this.CustId = custId;
                        this.CustRequestList = FindCustRequestList();
                        InitToolBars();
                }
                /// <summary>
                /// 客户编号
                /// </summary>
                private int custId;
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
                /// 客户姓名关键词
                /// </summary>
                private string custName;
                public string CustName
                {
                        get { return custName; }
                        set
                        {
                                custName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 跟进人关键词
                /// </summary>
                private string followUpUser;
                public string FollowUpUser
                {
                        get { return followUpUser; }
                        set
                        {
                                followUpUser = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 客户类别
                /// </summary>
                private string customerType = "全部";
                public string CustomerType
                {
                        get { return customerType; }
                        set
                        {
                                customerType = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 需求内容关键词
                /// </summary>
                private string requestContent;
                public string RequestContent
                {
                        get { return requestContent; }
                        set
                        {
                                requestContent = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 客户类别
                /// </summary>
                public List<string> CboCustomerTypes
                {
                        get
                        {
                                return new List<string>() { "全部", "个人", "单位" };
                        }
                }



                /// <summary>
                /// 意向客户需求列表
                /// </summary>
                private ObservableCollection<CustomerRequstInfoCheck> custRequestList;
                public ObservableCollection<CustomerRequstInfoCheck> CustRequestList
                {
                        get { return custRequestList; }
                        set
                        {
                                custRequestList = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 查询命令
                /// </summary>
                public ICommand FindCustRequestListCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        ReloadCustRequestList();
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
                                        var list = this.CustRequestList;
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
                                                var obj = o as CustomerRequstInfoCheck;
                                                obj.IsCheck =!obj.IsCheck;
                                        }
                                });
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
                                ShowAllRequestList = true,
                                ShowCustFULog = true,
                                AddCommand = new RelayCommand(o => ShowCustomerRequestPage(1, 0, o), b => IsEdited),
                                EditCommand = new RelayCommand(o => ShowCustomerRequestPage(2, o), b => IsEditEnableToolItems()),
                                DeleteCommand = new RelayCommand(o => DeleteCustomerRequests(1), b => IsEditEnableToolItems()),
                                RecoverCommand = new RelayCommand(o => DeleteCustomerRequests(0), b => IsDeletedEnableToolItems()),
                                RemoveCommand = new RelayCommand(o => DeleteCustomerRequests(2), b => IsDeletedEnableToolItems()),
                                InfoCommand = new RelayCommand(o => ShowCustomerRequestPage(4, o), b => this.CustRequestList.Count > 0),
                                CloseCommand = this.CloseTabPage,
                                FindCommand = new RelayCommand(o => ReloadCustRequestList()),
                                AllRequestListCommand = new RelayCommand(o => {
                                        this.CustId = 0;
                                        ReloadCustRequestList();
                                }),
                                CustFULogCommand = new RelayCommand(o => ShowCustFollowUpLogPage(o),b=>this.CustRequestList.Count>0)
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
                        this.ToolBarInfo.RemoveCommand.OnCanExecuted();
                        this.ToolBarInfo.InfoCommand.OnCanExecuted();
                        this.ToolBarInfo.CustFULogCommand.OnCanExecuted();
                }

                /// <summary>
                /// 重新加载客户需求列表和工具栏
                /// </summary>
                private void ReloadCustRequestList()
                {
                        this.CustRequestList = FindCustRequestList();
                        ReloadToolBars();
                }

                /// <summary>
                /// 条件查询客户需求列表
                /// </summary>
                /// <returns></returns>
                private ObservableCollection<CustomerRequstInfoCheck> FindCustRequestList()
                {
                        ObservableCollection<CustomerRequstInfoCheck> reList = new ObservableCollection<CustomerRequstInfoCheck>();
                        int isDeleted = this.IsShowDel ? 1 : 0;
                        string custType = this.CustomerType == "全部" ? "" : this.CustomerType;
                        List<ViewCustomerRequestInfoModel> list = crBLL.GetCustRequests(this.CustId, this.CustName, this.FollowUpUser, custType, this.RequestContent, isDeleted);
                        list.ForEach(c => reList.Add(new CustomerRequstInfoCheck()
                        {
                                IsCheck = false,
                                CustRequestInfo = c
                        }));
                        return reList;
                }

                /// <summary>
                /// 打开客户需求信息页面
                /// </summary>
                /// <param name="actType"></param>
                /// <param name="custRequestId"></param>
                /// <param name="uc"></param>
                private void ShowCustomerRequestPage(int actType, int custRequestId, object uc)
                {
                        CustomerRequestInfoViewViewModel custRequestVM = new CustomerRequestInfoViewViewModel(actType, custRequestId);
                        custRequestVM.ReLoadHandler += ReloadCustRequestList;
                        string typeName = GetInfoTypeName(actType);
                        //打开信息页面，添加到Tab页中
                       // AddDxTabItem(uc, $"客户需求信息——{typeName} 页面", "customerRequestInfoWindow", custRequestVM);
                        ShowDialog("customerRequestInfoWindow", custRequestVM);//打开客户需求信息页面
                }

                /// <summary>
                /// 打开修改、查看页面
                /// </summary>
                /// <param name="actType"></param>
                /// <param name="uc"></param>
                private void ShowCustomerRequestPage(int actType, object uc)
                {
                        if (this.CurrentItem != null)
                        {
                                CustomerRequstInfoCheck curRequest = this.CurrentItem as CustomerRequstInfoCheck;
                                ShowCustomerRequestPage(actType, curRequest.CustRequestInfo.CustRequestId, uc);
                        }
                }

                /// <summary>
                /// 显示选择的客户跟进日志列表
                /// </summary>
                private void ShowCustFollowUpLogPage(object uc)
                {
                        int requestId = 0;
                        if (this.CurrentItem!= null)
                                requestId = (this.CurrentItem as CustomerRequstInfoCheck).CustRequestInfo.CustRequestId;
                        CustomerFollowUpLogListViewModel custFULogListVM = new CustomerFollowUpLogListViewModel(requestId);
                        AddDxTabItem(uc, "当前客户跟进日志列表", "custFollowUpLogList", custFULogListVM);
                }


                /// <summary>
                /// 修改、删除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsEditEnableToolItems()
                {
                        bool bl = this.CustRequestList.Count > 0 && !IsShowDel;
                        return bl;
                }

                /// <summary>
                /// 恢复、移除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsDeletedEnableToolItems()
                {
                        bool bl = (this.CustRequestList.Count > 0 && IsShowDel);
                        return bl;
                }

                /// <summary>
                /// 删除处理
                /// </summary>
                /// <param name="isDeleted"></param>
                private void DeleteCustomerRequests(int isDeleted)
                {
                        string typeName = GetDelTypeName(isDeleted);
                        string msgTitle = $"客户需求{typeName}";
                        List<int> delIds = this.CustRequestList.Where(c => c.IsCheck == true).Select(c => c.CustRequestInfo.CustRequestId).ToList();
                        if (delIds.Count > 0)
                        {
                                if (ShowQuestion($"您确定要{typeName}选择的客户需求信息吗？", msgTitle) == MsgBoxWindow.CustomMessageBoxResult.OK)
                                {
                                        bool blDel = false;
                                        switch (isDeleted)
                                        {
                                                case 1:
                                                        bool blSucRequest = cfulBLL.IsSuccessCustRequest(delIds);
                                                        if (!blSucRequest)
                                                        {
                                                                blDel = crBLL.LogicDelCustomerRequestList(delIds);
                                                        }
                                                        else
                                                        {
                                                                MsgBoxHelper.ShowInfo("已包含成功需求，不能删除！", msgTitle);
                                                                return;
                                                        }
                                                        break;
                                                case 0:
                                                        blDel = crBLL.RecoverCustomerRequestList(delIds);
                                                        break;
                                                case 2:
                                                        blDel = crBLL.RemoveCustomerRequestList(delIds);
                                                        break;
                                        }
                                        string sucMsg = blDel ? "成功" : "失败";
                                        string msg = $"选择的客户需求信息{typeName}{sucMsg}！";
                                        if (blDel)
                                        {
                                                ShowMsg(msg, msgTitle);
                                                ReloadCustRequestList();
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
