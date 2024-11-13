using DevExpress.Xpf.Core;
using HRSM.BLL;
using HRSM.DXHouseApp.Models;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Windows.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.NavBar;
using HRSM.Common;
using static HRSM.DXHouseApp.MsgBoxWindow;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Reflection;

namespace HRSM.DXHouseApp.ViewModels
{
        public class MainViewModel : ViewModelBase
        {
                UserBLL userBLL = new UserBLL();
                RoleBLL roleBLL = new RoleBLL();
                MenuBLL menuBLL = new MenuBLL();
                public  Action RefreshMenusAction;
                public MainViewModel()
                {
                        userRole = new UserRoleListModel();
                        if (UserId == 0)
                        {
                                if (!CheckHasPage("房屋列表"))
                                {
                                        AddDxTabItem("房屋列表", defaultUrl);
                                        SetShowTabAndClose();
                                }
                        }
                        //刷新菜单
                        RefreshMenusAction = ReloadMenus;
                }
                public MainViewModel(int userId)
                {
                        this.UserId = userId;
                        userRole = userBLL.GetUserRoleListInfo(userId);

                }
                //登录用户的信息（包括角色列表）
                UserRoleListModel userRole;



                /// <summary>
                /// 登录者账号
                /// </summary>
                public string LoginUser
                {
                        get { return userRole.UserName; }
                        set
                        {
                                userRole.UserName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 登录者的角色名
                /// </summary>
                private string roleName = "";
                public string UserRole
                {
                        get
                        {
                                if (userRole.RoleIds != null)
                                {
                                        roleName = roleBLL.GetRoleNames(userRole.RoleIds);
                                }
                                return roleName;
                        }
                        set
                        {
                                roleName = value;
                                OnPropertyChanged();
                        }
                }
                /// <summary>
                /// 登录时间
                /// </summary>
                public string LoginTime
                {
                        get
                        {
                                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                }

                /// <summary>
                /// 版权信息
                /// </summary>
                public string RightInfo
                {
                        get
                        {
                                return "朝夕教育所有";
                        }
                }


                /// <summary>
                /// 导航菜单列表
                /// </summary>
                private ObservableCollection<MenuGroupItem> menuList;
                public ObservableCollection<MenuGroupItem> MenuList
                {
                        get
                        {
                                ObservableCollection<MenuGroupItem> list = null;
                                if (userRole.RoleIds != null)
                                {
                                        list = GetMenuGroups();
                                }
                                else
                                {
                                        list = new ObservableCollection<MenuGroupItem>()
                                            {
                                                new MenuGroupItem(){
                                                     GroupName="房屋展示",
                                                     IsGroupExpand=true,
                                                     MenuItemList=new ObservableCollection<MenuInfoModel>()
                                                     {
                                                         new MenuInfoModel()
                                                         {
                                                             MenuName="房屋列表",
                                                             MenuUrl=defaultUrl
                                                         }
                                                     }
                                                }
                                            };
                                }
                                menuList = list;
                                return menuList;
                        }
                        set
                        {
                                menuList = value;
                                OnPropertyChanged();
                        }
                }





                private Visibility showLoginBtn = Visibility.Visible;
                /// <summary>
                /// 是否显示登录按钮
                /// </summary>
                public Visibility ShowLoginBtn
                {
                        get
                        {
                                if (UserId > 0)
                                        showLoginBtn = Visibility.Hidden;
                                else
                                        showLoginBtn = Visibility.Visible;
                                return showLoginBtn;
                        }
                        set
                        {
                                showLoginBtn = value;
                                OnPropertyChanged();
                        }
                }


                private WindowState mainState = WindowState.Maximized;
                /// <summary>
                /// 主页面窗口状态
                /// </summary>
                public WindowState MainState
                {
                        get { return mainState; }
                        set
                        {
                                mainState = value;
                                OnPropertyChanged();
                        }
                }
                /// <summary>
                /// 显示登录窗口
                /// </summary>
                public ICommand ShowLoginPage
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(win =>
                                {
                                        LoginViewModel loginVM = new LoginViewModel();

                                        ShowDialog("loginWindow", loginVM);
                                        if (loginVM.UserId > 0)
                                                this.UserId = loginVM.UserId;
                                        if (UserId > 0)
                                        {
                                                //登录成功后，重新加载菜单列表
                                                userRole = userBLL.GetUserRoleListInfo(UserId);
                                                this.LoginUser = userRole.UserName;
                                                this.UserRole = roleBLL.GetRoleNames(userRole.RoleIds);
                                                this.MenuList = GetMenuGroups();
                                                this.ShowLoginBtn = Visibility.Hidden;
                                        }
                                });
                                return cmd;
                        }
                }

                public ICommand ExitCommand
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(win =>
                                {
                                        if (win != null)
                                        {
                                                CustomMessageBoxResult result = ShowQuestion("您确定要退出房屋租售管理平台系统吗？", "系统退出");
                                                if (result == CustomMessageBoxResult.OK)
                                                {
                                                        Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                                                        Application.Current.Shutdown();
                                                }
                                        }

                                });
                                return cmd;
                        }
                }

                /// <summary>
                /// 双击主页面
                /// </summary>
                public ICommand DoubleWindow
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(win =>
                                {
                                        if (this.MainState == WindowState.Maximized)
                                                this.MainState = WindowState.Normal;
                                        else
                                                this.MainState = WindowState.Maximized;

                                });
                                return cmd;
                        }
                }

                /// <summary>
                /// 点击菜单组命令
                /// </summary>
                public ICommand ExpandGroup
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(o =>
                                {
                                        MenuGroupItem group = o as MenuGroupItem;
                                        group.IsGroupExpand = !group.IsGroupExpand;
                                });
                                return cmd;
                        }
                }


                /// <summary>
                /// 点击菜单项命令
                /// </summary>
                public ICommand OpenNavItem
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(o =>
                                {
                                        MenuInfoModel info = o as MenuInfoModel;
                                        if (CheckHasPage(info.MenuName))
                                        {
                                                DXTabItem tabItem0 = this.PageList.Where(p => p.Header.ToString() == info.MenuName).FirstOrDefault();
                                                this.SelectedTab = tabItem0;
                                                return;
                                        }
                                        AddDxTabItem(info.MenuName, info.MenuUrl);
                                });
                                return cmd;
                        }
                }




                /// <summary>
                /// 关闭页面命令
                /// </summary>
                private RelayCommand closeCmd;
                public RelayCommand CloseCmd
                {
                        get
                        {
                                closeCmd = new RelayCommand(o =>
                                {
                                        PageList.Remove(this.SelectedTab);
                                        SetShowTabAndClose();
                                });
                                return closeCmd;
                        }
                        set
                        {
                                closeCmd = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 当前选择的TabItem
                /// </summary>
                private DXTabItem selectedTab;
                public DXTabItem SelectedTab
                {
                        get { return selectedTab; }
                        set
                        {
                                selectedTab = value;
                                OnPropertyChanged();
                        }

                }

                private int userId;
                //登录用户编号
                public int UserId
                {
                        get { return userId; }
                        set { userId = value; }
                }

                private Visibility showCloseImg = Visibility.Hidden;
                /// <summary>
                /// 是否显示关闭按钮
                /// </summary>
                public Visibility ShowCloseImg
                {
                        get
                        {
                                return showCloseImg;
                        }
                        set
                        {
                                showCloseImg = value;
                                OnPropertyChanged();
                        }
                }


                private Visibility showTab = Visibility.Hidden;
                /// <summary>
                /// 是否显示TabControl
                /// </summary>
                public Visibility ShowTab
                {
                        get
                        {
                                return showTab;
                        }
                        set
                        {
                                showTab = value;
                                OnPropertyChanged();
                        }
                }
                public string defaultUrl = "HS/HouseShowList.xaml";
                private ObservableCollection<DXTabItem> pageList = new ObservableCollection<DXTabItem>();
                /// <summary>
                /// TabControl的数据源
                /// </summary>
                public ObservableCollection<DXTabItem> PageList
                {
                        get
                        {
                                return pageList;
                        }
                        set
                        {
                                pageList = value;
                                SetShowTabAndClose();
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 判断页面是否已打开
                /// </summary>
                /// <param name="pageName"></param>
                /// <returns></returns>
                public bool CheckHasPage(string pageName)
                {
                        foreach (DXTabItem tabItem in this.pageList)
                        {
                                if (tabItem.Header.ToString() == pageName)
                                        return true;
                        }
                        return false;
                }

                /// <summary>
                /// 添加指定页面
                /// </summary>
                /// <param name="header"></param>
                /// <param name="url"></param>
                public void AddDxTabItem(string header, string url)
                {
                        DXTabItem tabItem = new DXTabItem();
                        tabItem.Header = header;
                        tabItem.Name = "tab" + url.Split('/')[1].Split('.')[0];
                        Frame frame = new Frame();
                        //所引用的程序集的子文件夹中的资源文件
                         frame.Source = new Uri(url, UriKind.Relative);
                        tabItem.Content = frame;
                        this.pageList.Add(tabItem);
                        this.SelectedTab = tabItem;
                        this.ShowTab = Visibility.Visible;
                }

                public void SetShowTabAndClose()
                {
                        if (this.pageList.Count > 0)
                        {
                                this.ShowTab = Visibility.Visible;
                                this.ShowCloseImg = Visibility.Visible;
                        }
                        else
                        {
                                this.ShowTab = Visibility.Hidden;
                                this.ShowCloseImg = Visibility.Hidden;
                        }
                }




                /// <summary>
                /// 获取菜单列表转换成List<MenuGroup>
                /// </summary>
                /// <param name="menus"></param>
                /// <returns></returns>
                private ObservableCollection<MenuGroupItem> GetMenuGroups()
                {
                        ObservableCollection<MenuGroupItem> groups = new ObservableCollection<MenuGroupItem>();
                        if (userRole.RoleIds != null)
                        {
                                List<MenuInfoModel> menulist = menuBLL.GetRoleMenuList(userRole.RoleIds);
                                var firstMenus = menulist.Where(m => m.ParentId == 0).ToList();
                                foreach (var fMenu in firstMenus)
                                {
                                        var selMenus = menulist.Where(m => m.ParentId == fMenu.MenuId).ToList();
                                        MenuGroupItem group = new MenuGroupItem()
                                        {
                                                GroupName = fMenu.MenuName,
                                                IsGroupExpand = true
                                        };
                                        foreach (var item in selMenus)
                                        {
                                                MenuInfoModel menu = new MenuInfoModel();
                                                menu.MenuName = item.MenuName;
                                                menu.MenuUrl = item.MenuUrl;
                                                group.MenuItemList.Add(menu);
                                        }
                                        groups.Add(group);
                                }
                        }

                        return groups;
                }

                private void ReloadMenus()
                {
                        this.MenuList = GetMenuGroups();
                }
  
        }
}
