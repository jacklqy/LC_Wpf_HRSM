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

namespace HRSM.DXHouseApp.ViewModels.SM
{
        public  class UserListViewModel:ListViewModelBase
        {
                UserBLL userBLL = new UserBLL();
                RoleBLL roleBLL = new RoleBLL();
                public UserListViewModel()
                {
                        this.UserList = GetUserList();
                        InitToolbars();
                }
                /// <summary>
                /// 查询关键词
                /// </summary>
                private string keyWords;
                public string KeyWords
                {
                        get { return keyWords; }
                        set { keyWords = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 是否冻结
                /// </summary>
                private bool isFrozen=false;
                public bool IsFrozen
                {
                        get { return isFrozen; }
                        set { isFrozen = value;
                                OnPropertyChanged();
                        }
                }


                /// <summary>
                /// 用户列表
                /// </summary>
                private ObservableCollection<UserInfoCheck> userList = new ObservableCollection<UserInfoCheck>();
                public ObservableCollection<UserInfoCheck> UserList
                {
                        get
                        {
                                return userList;
                        }
                        set
                        {
                                userList = value;
                                OnPropertyChanged();
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
                                        var list = this.UserList;
                                        foreach (var user in list)
                                        {
                                                user.IsCheck = this.IsCheckAll;
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
                                                var obj = o as UserInfoCheck;               
                                                obj.IsCheck = !obj.IsCheck;
                                        }
                                });
                        }
                }

                /// <summary>
                /// 单条修改命令
                /// </summary>
                public ICommand EditUserCmd
                {
                        get
                        {
                                return new RelayCommand(o => ShowUserInfoPage(2));
                        }
                }

                public ICommand DelUserCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelUser(o, 1));
                        }
                }

                /// <summary>
                /// 恢复用户命令
                /// </summary>
                public ICommand RecoverUserCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelUser(o, 0));
                        }
                }

                /// <summary>
                /// 移除用户命令
                /// </summary>
                public ICommand RemoveUserCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelUser(o, 2));
                        }
                }


                /// <summary>
                /// 查询用户列表
                /// </summary>
                public RelayCommand FindUserListCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        ReloadUserList();
                                });
                        }
                }

                /// <summary>
                /// 刷新用户列表
                /// </summary>
                private void ReloadUserList()
                {
                        this.UserList = GetUserList();
                        ReLoadToolbars();
                }

                /// <summary>
                /// 初始化工具栏
                /// </summary>
                private void InitToolbars()
                {
                        this.ToolBarInfo = new ToolBarViewModel()
                        {
                                AddCommand = new RelayCommand(o => ShowUserInfoPage(1, 0),b=>IsEdited),
                                EditCommand = new RelayCommand(o => ShowUserInfoPage(2), b => IsEditEnableToolItems()),
                                DeleteCommand = new RelayCommand(o =>DeleteUsers(1,false), b => IsEditEnableToolItems()),
                                RecoverCommand = new RelayCommand(o => DeleteUsers(0, false), b => IsDeletedEnableToolItems()),
                                RemoveCommand = new RelayCommand(o => DeleteUsers(2, false), b => IsDeletedEnableToolItems()),
                                InfoCommand= new RelayCommand(o => ShowUserInfoPage(4),b=>this.UserList.Count >0),
                                CloseCommand=this.CloseTabPage
                        };
                }

                /// <summary>
                /// 刷新工具栏
                /// </summary>
                private void ReLoadToolbars()
                {
                        this.ToolBarInfo.AddCommand.OnCanExecuted();
                        this.ToolBarInfo.EditCommand.OnCanExecuted();
                        this.ToolBarInfo.DeleteCommand.OnCanExecuted();
                        this.ToolBarInfo.RecoverCommand.OnCanExecuted();
                        this.ToolBarInfo.RemoveCommand.OnCanExecuted();
                        this.ToolBarInfo.InfoCommand.OnCanExecuted();
                }

                /// <summary>
                /// 打开用户信息页面
                /// </summary>
                /// <param name="actType"></param>
                /// <param name="userId"></param>
                private void ShowUserInfoPage(int actType, int userId)
                {
                        UserInfoViewModel userVM = new UserInfoViewModel(actType, userId);
                        userVM.ReLoadHandler += ReloadUserList;
                        ShowDialog("userInfo", userVM);//打开用户信息页面
                }

                /// <summary>
                /// 修改、查看页面打开
                /// </summary>
                /// <param name="actType"></param>
                private void ShowUserInfoPage(int actType)
                {
                        if(this.CurrentItem !=null)
                        {
                                UserInfoCheck curUser = this.CurrentItem as UserInfoCheck;
                                ShowUserInfoPage(actType, curUser.UserInfo.UserId);
                        }
                }

                /// <summary>
                /// 条件查询用户列表
                /// </summary>
                /// <returns></returns>
                private ObservableCollection<UserInfoCheck> GetUserList()
                {
                        ObservableCollection<UserInfoCheck> reList = new ObservableCollection<UserInfoCheck>();
                        int isDel = this.IsShowDel ? 1 : 0;
                        this.IsEdited = !IsShowDel;
                        int userState = this.IsFrozen ? 0 : 1;
                        List<UserInfoModel> list = userBLL.GetUserList(this.KeyWords,userState,isDel);
                        list.ForEach(u => reList.Add(new UserInfoCheck()
                        {
                                IsCheck = false,
                                UserInfo = u
                        }));
                        return reList;
                }

                /// <summary>
                /// 修改、删除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsEditEnableToolItems()
                {
                        bool bl = (this.UserList.Count > 0 && !IsShowDel);
                        return bl;
                }

                /// <summary>
                /// 恢复、移除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsDeletedEnableToolItems()
                {
                        bool bl = (this.UserList.Count > 0 && IsShowDel);
                        return bl;
                }

                /// <summary>
                /// 单条删除处理
                /// </summary>
                /// <param name="o"></param>
                /// <param name="isDeleted"></param>
                private void SingleDelUser(object o, int isDeleted)
                {

                        if (o != null)
                        {
                                int Id = (int)o;
                                UserInfoCheck user = this.UserList.Where(r => r.UserInfo.UserId == Id).FirstOrDefault();
                                if (this.SelectedItems != null)
                                        this.SelectedItems.Clear();
                                else
                                        this.SelectedItems = new List<UserInfoCheck>();
                                this.SelectedItems.Add(user);
                                DeleteUsers(isDeleted, true);
                        }
                }

                /// <summary>
                /// 删除用户处理
                /// </summary>
                /// <param name="isDeleted"></param>
                /// <param name="isSingle"></param>
                private void DeleteUsers(int isDeleted,bool isSingle)
                {
                        string typeName = GetDelTypeName(isDeleted);
                        string msgTitle = $"用户{typeName}";
                        List<int> delIds = new List<int>();
                        if (!isSingle)
                        {
                                delIds = this.UserList.Where(u=> u.IsCheck == true).Select(u => u.UserInfo.UserId).ToList();
                        }
                        else
                        {
                                List<UserInfoCheck> selList = this.SelectedItems as List<UserInfoCheck>;
                                delIds = selList.Select(u => u.UserInfo.UserId).ToList();
                        }
                        if (delIds.Count > 0)
                        {
                                if (isDeleted == 1)
                                {
                                        foreach (int id in delIds)
                                        {
                                                List<int> roleIds = userBLL.GetUserRoleIds(id);
                                                if (roleBLL.IsAdmin(roleIds))
                                                {
                                                        ShowErr("管理员账号不能删除！", msgTitle);
                                                        return;
                                                }
                                        }
                                }
                                if (ShowQuestion($"您确定要{typeName}选择的用户信息吗？", msgTitle) == MsgBoxWindow.CustomMessageBoxResult.OK)
                                {
                                        bool blDel = false;
                                        switch (isDeleted)
                                        {
                                                case 1:
                                                        blDel = userBLL.LogicDelUserList(delIds);
                                                        break;
                                                case 0:
                                                        blDel = userBLL.RecoverUserList(delIds);
                                                        break;
                                                case 2:
                                                        blDel = userBLL.RemoveUserList(delIds);
                                                        break;
                                        }
                                        string sucMsg = blDel ? "成功" : "失败";
                                        string msg = $"选择的用户信息{typeName}{sucMsg}！";
                                        if (blDel)
                                        {
                                                ShowMsg(msg, msgTitle);
                                                ReloadUserList();
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
