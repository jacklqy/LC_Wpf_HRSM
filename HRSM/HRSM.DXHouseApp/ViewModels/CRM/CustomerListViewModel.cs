using DevExpress.Xpf.Grid;
using HRSM.BLL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels.CRM
{
    public class CustomerListViewModel:ListViewModelBase
    {
                CustomerBLL customerBLL = new CustomerBLL();
                CustomerRequestBLL crBLL = new CustomerRequestBLL();
                public CustomerListViewModel()
                {
                        this.CustomerList = FindCustomerList();
                        InitToolbars();
                }

                /// <summary>
                /// 关键词
                /// </summary>
                private string keyWords = "";
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
                /// 选择的客户类别
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
                /// 选择的客户状态
                /// </summary>
                private string customerState = "全部";
                public string CustomerState
                {
                        get { return customerState; }
                        set
                        {
                                customerState = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 客户类别列表
                /// </summary>
                public List<string> CboCustTypes
                {
                        get
                        {
                                return new List<string>() { "全部", "个人", "单位" };
                        }
                }

                /// <summary>
                /// 客户状态列表
                /// </summary>
                public List<string> CboCustStates
                {
                        get
                        {
                                return new List<string>() { "全部", "普通客户", "意向客户" };
                        }
                }

                /// <summary>
                /// 客户列表
                /// </summary>
                private ObservableCollection<CustomerInfoCheck> customerList;
                public ObservableCollection<CustomerInfoCheck> CustomerList
                {
                        get { return customerList; }
                        set
                        {
                                customerList = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 查询客户列表命令
                /// </summary>
                public ICommand FindCustomersCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        ReloadCustomerList();
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
                                        var list = this.CustomerList;
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
                                                var obj = o as CustomerInfoCheck;
                                                obj.IsCheck = !obj.IsCheck;
                                        }

                                });
                        }
                }

                /// <summary>
                /// 重新加载客户列表
                /// </summary>
                private void ReloadCustomerList()
                {
                        this.CustomerList = FindCustomerList();
                        ReloadToolBars();
                }

                /// <summary>
                /// 条件查询客户列表
                /// </summary>
                /// <returns></returns>
                private ObservableCollection<CustomerInfoCheck> FindCustomerList()
                {
                        ObservableCollection<CustomerInfoCheck> reList = new ObservableCollection<CustomerInfoCheck>();
                        string keywords = this.KeyWords;
                        int isDeleted = IsShowDel ? 1 : 0;
                        string custType = this.CustomerType == "全部" ? "" : this.CustomerType;
                        string custState = this.CustomerState == "全部" ? "" : this.CustomerState;
                        List<CustomerInfoModel> list = customerBLL.GetCustList(keywords, custType,custState, isDeleted);
                        list.ForEach(c=> reList.Add(new CustomerInfoCheck()
                        {
                                IsCheck = false,
                                CustInfo = c,
                        }));
                        return reList;
                }

                /// <summary>
                /// 初始化工具箱
                /// </summary>
                private void InitToolbars()
                {
                        this.ToolBarInfo = new ToolBarViewModel()
                        {
                                ShowFind = true,
                                ShowCustRequestList=true,
                                AddCommand = new RelayCommand(o => ShowCustomerInfoPage(1, 0, o), b => IsEdited),
                                EditCommand = new RelayCommand(o => ShowCustomerInfoPage(2, o), b => IsEditEnableToolItems()),
                                DeleteCommand = new RelayCommand(o => DeleteCustomerInfos(1), b => IsEditEnableToolItems()),
                                RecoverCommand = new RelayCommand(o => DeleteCustomerInfos(0), b => IsDeletedEnableToolItems()),
                                RemoveCommand = new RelayCommand(o => DeleteCustomerInfos(2), b => IsDeletedEnableToolItems()),
                                InfoCommand = new RelayCommand(o => ShowCustomerInfoPage(4, o), b => this.CustomerList.Count > 0),
                                CloseCommand = this.CloseTabPage,
                                FindCommand = new RelayCommand(o => ReloadCustomerList()),
                                CustRequestListCommand=new RelayCommand(o=>ShowCustRequestList(o),b=>this.CustomerList.Count >0)
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
                        this.ToolBarInfo.CustRequestListCommand.OnCanExecuted();
                }

                /// <summary>
                /// 显示客户信息页面
                /// </summary>
                /// <param name="actType"></param>
                /// <param name="custId"></param>
                /// <param name="uc"></param>
                private void ShowCustomerInfoPage(int actType,int custId,object uc)
                {
                        CustomerInfoViewViewModel custVM = new CustomerInfoViewViewModel(actType, custId);
                        custVM.ReLoadHandler += ReloadCustomerList;
                        string typeName = GetInfoTypeName(actType);
                        //打开信息页面，添加到Tab页中
                        AddDxTabItem(uc, $"客户信息——{typeName} 页面", "customerInfoView", custVM);//打开客户信息页面
                }

                /// <summary>
                /// 打开 修改、查看页面
                /// </summary>
                /// <param name="actType"></param>
                /// <param name="uc"></param>
                public void ShowCustomerInfoPage(int actType,object uc)
                {
                        if (this.CurrentItem != null)
                        {
                                CustomerInfoCheck curCust = this.CurrentItem as CustomerInfoCheck;
                                ShowCustomerInfoPage(actType, curCust.CustInfo.CustomerId, uc);
                        }
                }

                /// <summary>
                /// 删除客户信息处理
                /// </summary>
                /// <param name="isDeleted"></param>
                private void DeleteCustomerInfos(int isDeleted)
                {
                        string typeName = GetDelTypeName(isDeleted);
                        string msgTitle = $"客户{typeName}";
                        List<int> delIds = this.CustomerList.Where(c => c.IsCheck == true).Select(c=> c.CustInfo.CustomerId).ToList(); 
                        if (delIds.Count > 0)
                        {
                                if (ShowQuestion($"您确定要{typeName}选择的客户信息吗？", msgTitle) == MsgBoxWindow.CustomMessageBoxResult.OK)
                                {
                                        bool blDel = false;
                                        switch (isDeleted)
                                        {
                                                case 1:
                                                        bool blHasIntented = customerBLL.IsIntendedCustomer(delIds);
                                                        bool blHasTrade = customerBLL.IsTradeCustomer(delIds);
                                                        if (!blHasIntented && !blHasTrade)
                                                        {
                                                                blDel = customerBLL.LogicDelCustomerList(delIds);
                                                        }
                                                        else if (blHasIntented)
                                                        {
                                                                ShowErr("已包含意向客户，不能删除！", msgTitle);
                                                                return;
                                                        }
                                                        else
                                                        {
                                                                ShowErr("已包含交易客户，不能删除！", msgTitle);
                                                                return;
                                                        }
                                                        break;
                                                case 0:
                                                        blDel = customerBLL.RecoverCustomerList(delIds);
                                                        break;
                                                case 2:
                                                        blDel = customerBLL.RemoveCustomerList(delIds);
                                                        break;
                                        }
                                        string sucMsg = blDel ? "成功" : "失败";
                                        string msg = $"选择的客户信息{typeName}{sucMsg}！";
                                        if (blDel)
                                        {
                                                ShowMsg(msg, msgTitle);
                                                ReloadCustomerList();
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


                /// <summary>
                /// 修改、删除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsEditEnableToolItems()
                {
                        bool bl = this.CustomerList.Count > 0 && !IsShowDel;
                        return bl;
                }

                /// <summary>
                /// 恢复、移除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsDeletedEnableToolItems()
                {
                        bool bl = (this.CustomerList.Count > 0 && IsShowDel);
                        return bl;
                }

                /// <summary>
                /// 显示意向客户需求列表页面
                /// </summary>
                private void ShowCustRequestList(object uc)
                {
                        if (this.CurrentItem != null)
                        {
                                CustomerInfoCheck custInfo = this.CurrentItem as CustomerInfoCheck;
                                CustomerRequestListViewModel custReqVM = new CustomerRequestListViewModel(custInfo.CustInfo.CustomerId);
                                //打开页面，添加到Tab页中
                                AddDxTabItem(uc, "意向客户需求列表", "custReqList", custReqVM);//打开意向客户需求列表页面
                        }

                }
        }
}
