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

namespace HRSM.DXHouseApp.ViewModels.BM
{
        public class OwnerListViewModel : ListViewModelBase
        {
                private OwnerBLL ownerBLL = new OwnerBLL();
                public OwnerListViewModel()
                {
                        this.OwnerList = FindOwnerList();
                        InitToolbars();
                }

                private string keyWords;
                /// <summary>
                /// 关键词
                /// </summary>
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
                /// 选择的业主类型
                /// </summary>
                private string ownerType = "全部";
                public string OwnerType
                {
                        get { return ownerType; }
                        set
                        {
                                ownerType = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 业主类型列表
                /// </summary>
                public List<string> CboOwnerTypes
                {
                        get
                        {
                                return new List<string>() { "全部", "个人", "单位" };
                        }
                }

                /// <summary>
                /// 业主列表
                /// </summary>
                private ObservableCollection<OwnerInfoCheck> ownerList = new ObservableCollection<OwnerInfoCheck>();
                public ObservableCollection<OwnerInfoCheck> OwnerList
                {
                        get { return ownerList; }
                        set
                        {
                                ownerList = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 条件查询业主列表
                /// </summary>
                public ICommand FindOwnerListCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        ReloadOwnerList();
                                });
                        }
                }


                /// <summary>
                /// 重新加载列表与刷新工具栏
                /// </summary>
                private void ReloadOwnerList()
                {
                        this.OwnerList = FindOwnerList();
                        ReloadToolBars();
                }

                /// <summary>
                /// 条件查询业主列表
                /// </summary>
                /// <returns></returns>
                private ObservableCollection<OwnerInfoCheck> FindOwnerList()
                {
                        ObservableCollection<OwnerInfoCheck> reList = new ObservableCollection<OwnerInfoCheck>();
                        string keywords = this.KeyWords;
                        string ownertype = this.OwnerType == "全部" ? "" : this.OwnerType; ;
                        int isDeleted = IsShowDel ? 1 : 0;
                        this.IsEdited = !IsShowDel;

                        List<HouseOwnerInfoModel> list = ownerBLL.GetOwnerList(keywords, ownertype, isDeleted);
                        list.ForEach(h => reList.Add(new OwnerInfoCheck()
                        {
                                IsCheck = false,
                                OwnerInfo = h
                        }));
                        return reList;
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
                                        var list = this.OwnerList;
                                        foreach (var owner in list)
                                        {
                                                owner.IsCheck = this.IsCheckAll;
                                        }
                                });
                        }
                }

                public ICommand CheckItemCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        if (o != null)
                                        {
                                                var obj = o as OwnerInfoCheck;
                                                obj.IsCheck =!obj.IsCheck;
                                        }
                                });
                        }
                }

                /// <summary>
                /// 单条修改命令
                /// </summary>
                public ICommand EditOwnerCmd
                {
                        get
                        {
                                return new RelayCommand(o => ShowOwnerInfoPage(2,o));
                        }
                }

                public ICommand DelOwnerCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelOwner(o, 1));
                        }
                }

                /// <summary>
                /// 恢复业主命令
                /// </summary>
                public ICommand RecoverOwnerCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelOwner(o, 0));
                        }
                }

                /// <summary>
                /// 移除业主命令
                /// </summary>
                public ICommand RemoveOwnerCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelOwner(o, 2));
                        }
                }

                /// <summary>
                /// 初始化工具栏
                /// </summary>
                private void InitToolbars()
                {
                        this.ToolBarInfo = new ToolBarViewModel()
                        {
                                ShowFind = true,
                                ShowImport = true,
                                AddCommand = new RelayCommand(o => ShowOwnerInfoPage(1, 0, o), b => IsEdited),
                                EditCommand = new RelayCommand(o => ShowOwnerInfoPage(2, o), b => IsEditEnableToolItems()),
                                DeleteCommand = new RelayCommand(o => DeleteOwners(1, false), b => IsEditEnableToolItems()),
                                RecoverCommand = new RelayCommand(o => DeleteOwners(0, false), b => IsDeletedEnableToolItems()),
                                RemoveCommand = new RelayCommand(o => DeleteOwners(2, false), b => IsDeletedEnableToolItems()),
                                InfoCommand = new RelayCommand(o => ShowOwnerInfoPage(4, o), b => this.OwnerList.Count > 0),
                                CloseCommand = this.CloseTabPage,
                                FindCommand = new RelayCommand(o => ReloadOwnerList()),
                                ImportCommand = new RelayCommand(o => ImportOwnerInfos()),
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
                }


                /// <summary>
                /// 单条删除处理
                /// </summary>
                /// <param name="o"></param>
                /// <param name="isDeleted"></param>
                private void SingleDelOwner(object o, int isDeleted)
                {
                        if (o != null)
                        {
                                int Id = (int)o;
                                OwnerInfoCheck ownerInfo = this.OwnerList.Where(h => h.OwnerInfo.OwnerId == Id).FirstOrDefault();
                                if (this.SelectedItems != null)
                                        this.SelectedItems.Clear();
                                else
                                        this.SelectedItems = new List<OwnerInfoCheck>();
                                this.SelectedItems.Add(ownerInfo);
                                DeleteOwners(isDeleted, true);
                        }
                }

                /// <summary>
                /// 删除业主处理
                /// </summary>
                /// <param name="isDeleted"></param>
                /// <param name="isSingle"></param>
                private void DeleteOwners(int isDeleted, bool isSingle)
                {
                        string typeName = GetDelTypeName(isDeleted);
                        string msgTitle = $"业主{typeName}";
                        List<int> delIds = new List<int>();
                        if (!isSingle)
                        {
                                delIds = this.OwnerList.Where(u => u.IsCheck == true).Select(h => h.OwnerInfo.OwnerId).ToList();
                        }
                        else
                        {
                                List<OwnerInfoCheck> selList = this.SelectedItems as List<OwnerInfoCheck>;
                                delIds = selList.Select(h => h.OwnerInfo.OwnerId).ToList();
                        }
                        if (delIds.Count > 0)
                        {
                                if (ShowQuestion($"您确定要{typeName}选择的业主信息吗？", msgTitle) == MsgBoxWindow.CustomMessageBoxResult.OK)
                                {
                                        bool blDel = false;
                                        switch (isDeleted)
                                        {
                                                case 1:
                                                        blDel = ownerBLL.LogicDelOwnerList(delIds);
                                                        break;
                                                case 0:
                                                        blDel = ownerBLL.RecoverOwnerList(delIds);
                                                        break;
                                                case 2:
                                                        blDel = ownerBLL.RemoveOwnerList(delIds);
                                                        break;
                                        }
                                        string sucMsg = blDel ? "成功" : "失败";
                                        string msg = $"选择的业主信息{typeName}{sucMsg}！";
                                        if (blDel)
                                        {
                                                ShowMsg(msg, msgTitle);
                                                ReloadOwnerList();
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
                /// 导入业主信息
                /// </summary>
                private void ImportOwnerInfos()
                {
                        var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "Excel Files (*.xlsx)|*.xlsx| Excel Files 2003 (*.xls)|*.xls" };
                        var result = ofd.ShowDialog();
                        if (result == false) return;
                        string fileName = ofd.FileName;
                        if (!string.IsNullOrEmpty(fileName))
                        {
                                string msgTitle = "导入业主信息";
                                int re = ownerBLL.ImportOwnerData(fileName, "业主数据", true);
                                if (re == 1)
                                {
                                        //导入成功
                                        ShowMsg("业主信息导入成功！", msgTitle);
                                        ReloadOwnerList();
                                }
                                else if (re == 0)
                                {
                                        //导入失败
                                        ShowErr("业主信息导入失败，请检查导入格式！", msgTitle);
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
                /// 显示业主信息页面
                /// </summary>
                /// <param name="actType"></param>
                /// <param name="ownerId"></param>
                /// <param name="uc"></param>
                private void ShowOwnerInfoPage(int actType, int ownerId, object uc)
                {
                        OwnerInfoViewModel ownerInfoVM = new OwnerInfoViewModel(actType, ownerId);
                        ownerInfoVM.ReLoadHandler += ReloadOwnerList;
                        string typeName = GetInfoTypeName(actType);
                        //打开信息页面，添加到Tab页中
                        AddDxTabItem(uc, $"业主信息——{typeName} 页面", "ownerInfoView", ownerInfoVM);//打开业主信息页面
                }

                /// <summary>
                /// 显示修改、查看页面
                /// </summary>
                /// <param name="actType"></param>
                /// <param name="uc"></param>
                private void ShowOwnerInfoPage(int actType, object uc)
                {
                        if (this.CurrentItem != null)
                        {
                                OwnerInfoCheck curOwner = this.CurrentItem as OwnerInfoCheck;
                                ShowOwnerInfoPage(actType, curOwner.OwnerInfo.OwnerId, uc);
                        }
                }

                #region 工具项按钮的可用状态
                /// <summary>
                /// 修改、删除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsEditEnableToolItems()
                {
                        bool bl = (this.OwnerList.Count > 0 && !IsShowDel);
                        return bl;
                }

                /// <summary>
                /// 恢复、移除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsDeletedEnableToolItems()
                {
                        bool bl = (this.OwnerList.Count > 0 && IsShowDel);
                        return bl;
                }


                #endregion
        }
}
