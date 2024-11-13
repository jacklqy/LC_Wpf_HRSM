using DevExpress.Xpf.Core;
using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.Views;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using static HRSM.DXHouseApp.MsgBoxWindow;

namespace HRSM.DXHouseApp.ViewModels.SM
{
        public class MenuListViewModel : ListViewModelBase
        {
                MenuBLL menuBLL = new MenuBLL();
                public MenuListViewModel()
                {
                        this.MenuList = GetMenusList();
                        InitToolBars();
                }
               


                /// <summary>
                /// 查询关键词
                /// </summary>
                private string keywords = "";
                public string KeyWords
                {
                        get { return keywords; }
                        set
                        {
                                keywords = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 菜单列表
                /// </summary>
                private ObservableCollection<MenuInfoModel> menuList = new ObservableCollection<MenuInfoModel>();
                public ObservableCollection<MenuInfoModel> MenuList
                {
                        get
                        {
                                return menuList;
                        }
                        set
                        {
                                menuList = value;
                                OnPropertyChanged();
                        }
                }

                

                /// <summary>
                /// ShowDel复选框的Command
                /// </summary>
                public ICommand FindMenuListCmd
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(o =>
                                  {
                                          ReloadMenuList();
                                  });
                                return cmd;
                        }
                }



                /// <summary>
                /// 添加子项命令
                /// </summary>
                public ICommand AddChildMenuCmd
                {
                        get
                        {
                                return new RelayCommand(o => ShowMenuInfoPage(3,o));
                        }
                }

                /// <summary>
                /// 修改菜单命令
                /// </summary>
                public ICommand EditMenuCmd
                {
                        get
                        {
                                return new RelayCommand(o => ShowMenuInfoPage(2,o));
                        }
                }

                /// <summary>
                /// 删除菜单命令
                /// </summary>
                public ICommand DelMenuCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelMenu(o, 1));
                        }
                }

                /// <summary>
                /// 恢复菜单命令
                /// </summary>
                public ICommand RecoverMenuCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelMenu(o, 0));
                        }
                }

                /// <summary>
                /// 移除菜单命令
                /// </summary>
                public ICommand RemoveMenuCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelMenu(o, 2));
                        }
                }

                /// <summary>
                /// 单条菜单删除处理
                /// </summary>
                /// <param name="o"></param>
                /// <param name="isDeleted"></param>
                private void SingleDelMenu(object o, int isDeleted)
                {
                        if (o != null)
                        {
                                object[] paras = o as object[];
                                int mId = (int)paras[0];
                                MenuInfoModel menu = this.MenuList.Where(m => m.MenuId == mId).FirstOrDefault();
                                if (this.SelectedItems != null)
                                        this.SelectedItems.Clear();
                                else
                                        this.SelectedItems = new List<MenuInfoModel>();
                                this.SelectedItems.Add(menu);
                                DeleteMenu(isDeleted,paras[1]);
                        }
                }

                /// <summary>
                /// 查询菜单列表
                /// </summary>
                private ObservableCollection<MenuInfoModel> GetMenusList()
                {
                        ObservableCollection<MenuInfoModel> reList = new ObservableCollection<MenuInfoModel>();
                        int isDel = this.IsShowDel ? 1 : 0;
                        this.IsEdited = !IsShowDel;
                        List<MenuInfoModel> list = menuBLL.GetMenuList(this.KeyWords, -1, isDel);
                        list.ForEach(m => reList.Add(m));
                        return reList;
                }

                /// <summary>
                /// 初始化工具栏命令配置
                /// </summary>
                private void InitToolBars()
                {
                        this.ToolBarInfo = new ToolBarViewModel()
                        {
                                //新增
                                AddCommand = new RelayCommand(o => ShowMenuInfoPage(1, 0), b => IsEdited),
                                EditCommand = new RelayCommand(o => ShowMenuInfoPage(2,o), b => IsEditEnableToolItems()),
                                DeleteCommand = new RelayCommand(o => DeleteMenu(1,o), b => IsEditEnableToolItems()),
                                RecoverCommand = new RelayCommand(o => DeleteMenu(0,o), b => IsDeletedEnableToolItems()),
                                RemoveCommand = new RelayCommand(o => DeleteMenu(2,o), b => IsDeletedEnableToolItems()),
                                CloseCommand = this.CloseTabPage,
                                InfoCommand = new RelayCommand(o =>ShowMenuInfoPage(4,o),b=>this.MenuList.Count>0)
                        };
                }

                /// <summary>
                /// 刷新工具栏
                /// </summary>
                private void ReLoadToolBars()
                {
                        this.ToolBarInfo.AddCommand.OnCanExecuted();
                        this.ToolBarInfo.EditCommand.OnCanExecuted();
                        this.ToolBarInfo.DeleteCommand.OnCanExecuted();
                        this.ToolBarInfo.RecoverCommand.OnCanExecuted();
                        this.ToolBarInfo.RemoveCommand.OnCanExecuted();
                        this.ToolBarInfo.InfoCommand.OnCanExecuted();
                }

                /// <summary>
                /// 打开修改、查看、添加子项页面
                /// </summary>
                /// <param name="actType"></param>
                private void ShowMenuInfoPage(int actType,object oId)
                {
                        if (this.CurrentItem != null)
                        {
                                MenuInfoModel curMenu = this.CurrentItem as MenuInfoModel;
                                ShowMenuInfoPage(actType, curMenu.MenuId);
                        }
                        else
                        {
                                ShowErr("请选择要查看的菜单");
                                return;
                        }
                }

                /// <summary>
                /// 打开菜单信息页面
                /// </summary>
                private void ShowMenuInfoPage(int actType, int mId)
                {
                        MenuInfoViewModel menuVM = new MenuInfoViewModel(actType, mId);
                        menuVM.ReLoadHandler += ReloadMenuList;
                        ShowDialog("menuInfo", menuVM);//打开菜单信息页面
                }

                /// <summary>
                /// 刷新菜单列表
                /// </summary>
                private void ReloadMenuList()
                {
                        this.MenuList = GetMenusList();
                        ReLoadToolBars();
                }

                /// <summary>
                /// 删除/恢复/移除（彻底删除）
                /// </summary>
                /// <param name="isDeleted"></param>
                private void DeleteMenu(int isDeleted,object uc)
                {
                        string typeName = GetDelTypeName(isDeleted);
                        string msgTitle = $"菜单{typeName}";
                        List<int> delIds = new List<int>();
                        List<MenuInfoModel> list = this.SelectedItems as List<MenuInfoModel>;
                        delIds = list.Select(m => m.MenuId).ToList();
                        if (delIds.Count > 0)
                        {
                                if (isDeleted == 1)
                                {
                                        foreach (int id in delIds)
                                        {
                                                if (menuBLL.IsSystemMenu(id))
                                                {
                                                        ShowErr("系统管理菜单不能删除！", msgTitle);
                                                        return;
                                                }
                                        }
                                }
                                if (ShowQuestion($"您确定要{typeName}选择的菜单信息吗？", msgTitle) == CustomMessageBoxResult.OK)
                                {
                                        bool blDel = false;
                                        bool hasChild = menuBLL.HasChildMenus(delIds);
                                        switch (isDeleted)
                                        {
                                                case 1://假删除
                                                        if (!hasChild)
                                                                blDel = menuBLL.LogicDelMenuList(delIds, false);
                                                        else
                                                        {
                                                                ShowErr("包含有已添加的子菜单，不能直接删除！", msgTitle);
                                                                return;
                                                        }
                                                        break;
                                                case 0://恢复
                                                        blDel = menuBLL.RecoverMenuList(delIds, false);
                                                        break;
                                                case 2://移除
                                                        blDel = menuBLL.RemoveMenuList(delIds, false);
                                                        break;
                                        }
                                        string sucMsg = blDel ? "成功" : "失败";
                                        string msg = $"选择的菜单信息{typeName}{sucMsg}！";
                                        if (blDel)
                                        {
                                                ShowMsg(msg, msgTitle);
                                                ReloadMenuList();
                                                ReloadMainMenus(uc);
                                        }
                                        else
                                        {
                                                ShowError(msg, msgTitle);
                                                return;
                                        }
                                }
                        }
                        else
                        {
                                ShowError($"没有要{typeName}的菜单信息！", msgTitle);
                                return;
                        }
                }

                private void ReloadMainMenus(object uc)
                {
                        UserControl ucontrol = uc as UserControl;
                        var mainWin = ComUtility.GetAncestor<ThemedWindow>(ucontrol);
                        MainViewModel mainVM = mainWin.DataContext as MainViewModel;
                        mainVM.RefreshMenusAction();
                }

                /// <summary>
                /// 修改、删除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsEditEnableToolItems()
                {
                        bool bl = (this.MenuList.Count > 0 && !IsShowDel);
                        return bl;
                }

                /// <summary>
                /// 恢复、移除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsDeletedEnableToolItems()
                {
                        bool bl = (this.MenuList.Count > 0 && IsShowDel);
                        return bl;
                }
        }
}
