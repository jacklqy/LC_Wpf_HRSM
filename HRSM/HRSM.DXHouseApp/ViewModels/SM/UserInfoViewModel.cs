using HRSM.BLL;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HRSM.DXHouseApp.ViewModels.SM
{
       public class UserInfoViewModel:InfoViewModelBase
        {
                UserBLL userBLL = new UserBLL();
                RoleBLL roleBLL = new RoleBLL();
                public UserInfoViewModel() { }
                public UserInfoViewModel(int actType,  int userId)
                {
                        this.ActType = actType;
                        this.UserId = userId;
                        this.RoleList = GetRoleList();
                        switch (this.ActType)
                        {
                                case 1:
                                        this.ConfirmBtnContent = "添加";
                                        break;
                                case 2:
                                        LoadUserRoleList();
                                        this.ConfirmBtnContent = "修改";
                                        this.IsConfirmBtnEnabled = true;
                                        break;
                                case 4:
                                        LoadUserRoleList();
                                        this.IsConfirmBtnVisible = Visibility.Hidden;
                                        break;
                        }
                }
                private UserRoleListModel userRoleInfo = new UserRoleListModel();
                private UserInfoModel userInfo = new UserInfoModel();
                /// <summary>
                /// 用户编号
                /// </summary>
                private int userId;
                public int UserId
                {
                        get { return userId; }
                        set { userId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 用户名
                /// </summary>
                public string UserName
                {
                        get { return userInfo.UserName; }
                        set {
                                userInfo.UserName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 密码
                /// </summary>
                public string UserPwd
                {
                        get { return userInfo.UserPwd; }
                        set
                        {
                                userInfo.UserPwd= value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 用户姓名
                /// </summary>
                public string UserFName
                {
                        get { return userInfo.UserFName; }
                        set {
                                userInfo.UserFName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 用户电话
                /// </summary>
                public string UserPhone
                {
                        get { return userInfo.UserPhone; }
                        set {
                                userInfo.UserPhone = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 用户角色编号集合
                /// </summary>
                public List<int> RoleIds
                {
                        get {
                                if (userRoleInfo.RoleIds != null)
                                        return userRoleInfo.RoleIds;
                                else
                                        return new List<int>();
                        }
                        set { userRoleInfo.RoleIds = value;
                        }
                }

                /// <summary>
                /// 是否正常
                /// </summary>
                public bool IsNormal
                {
                        get { return userInfo.UserState; }
                        set {
                                userInfo.UserState = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 是否冻结
                /// </summary>
                public bool IsFrozen
                {
                        get { return userInfo.UserState ? false : true; }
                }

                /// <summary>
                /// ListBox角色列表
                /// </summary>
                private ObservableCollection<RoleInfoCheck> roleList=new ObservableCollection<RoleInfoCheck>();
                public ObservableCollection<RoleInfoCheck> RoleList
                {
                        get { return roleList; }
                        set { roleList = value;
                                OnPropertyChanged();
                        }
                }

                private Brush uNameFColor=new SolidColorBrush(Colors.LightGray);
                public Brush UNameFColor
                {
                        get { return uNameFColor; }
                        set { uNameFColor = value;
                                OnPropertyChanged();
                        }
                }

                private Brush uPwdFColor=new SolidColorBrush(Colors.LightGray);
                public Brush UPwdFColor
                {
                        get { return uPwdFColor; }
                        set { uPwdFColor = value;
                                OnPropertyChanged();
                        }
                }
                

                /// <summary>
                /// 检查输入
                /// </summary>
                public ICommand CheckInfoCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        if (!string.IsNullOrEmpty(this.UserPwd) && !string.IsNullOrEmpty(this.UserPwd))
                                        {
                                                this.IsConfirmBtnEnabled = true;
                                        }
                                        else
                                        {
                                                if (string.IsNullOrEmpty(this.UserName))
                                                {
                                                        this.IsConfirmBtnEnabled = false;
                                                        this.UNameFColor = new SolidColorBrush(Colors.Red);
                                                        return;
                                                }
                                                else if (!string.IsNullOrEmpty(this.UserName))
                                                {
                                                        if (((this.UserId == 0) || (this.UserId > 0 && this.UserName != this.userRoleInfo.UserName)) && userBLL.Exists(this.UserName))
                                                        {
                                                                ShowErr("该用户名已存在！");
                                                                this.IsConfirmBtnEnabled = false;
                                                                return;
                                                        }
                                                }
                                                if (string.IsNullOrEmpty(this.UserPwd))
                                                {
                                                        this.IsConfirmBtnEnabled = false;
                                                        this.UPwdFColor = new SolidColorBrush(Colors.Red);
                                                        return;
                                                }
                                        }
                                        
                                       
                                });
                        }
                }

                /// <summary>
                /// 提交命令
                /// </summary>
                public ICommand  ConfirmCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        bool bl = false;
                                        //当前设置的角色编号
                                        List<UserRoleInfoModel> rolesNew = new List<UserRoleInfoModel>();
                                       foreach(var role in this.RoleList)
                                        {
                                                if(role.IsCheck==true)
                                                {
                                                        rolesNew.Add(new UserRoleInfoModel()
                                                        {
                                                                RoleId=role.RoleInfo.RoleId,
                                                                UserId=this.UserId
                                                        });
                                                }
                                        }
                                        List<UserRoleInfoModel> addRoles = rolesNew.Where(r => !this.RoleIds.Contains(r.RoleId)).ToList();
                                        if (this.ActType == 2)
                                                bl = userBLL.UpdateUserInfo(this.userInfo,rolesNew,addRoles);
                                        else
                                                bl = userBLL.AddUserInfo(this.userInfo, rolesNew);
                                        string actMsg = ActType == 2 ? "修改" : "添加";
                                        string msgTitle = $"用户{actMsg}页面";
                                        string sucType = bl ? "成功" : "失败";
                                        string msgInfo = $"用户：{this.UserName} {actMsg}{sucType}!";
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
                                        CloseWindow("userInfo", o);
                                });
                        }
                }
                #endregion

                /// <summary>
                /// 获取角色列表
                /// </summary>
                /// <returns></returns>
                private ObservableCollection<RoleInfoCheck> GetRoleList()
                {
                        ObservableCollection<RoleInfoCheck> reList = new ObservableCollection<RoleInfoCheck>();
                        List<RoleInfoModel> rolelist = roleBLL.GetAllRoles();
                        rolelist.ForEach(r => reList.Add(new RoleInfoCheck()
                        {
                                IsCheck = false,
                                RoleInfo = r
                        }));
                        return reList;
                }

                /// <summary>
                /// 加载用户已设置的角色
                /// </summary>
                private void LoadUserRoleList()
                {
                        this.userRoleInfo = userBLL.GetUserRoleListInfo(this.UserId);
                        this.userInfo = new UserInfoModel()
                        {
                                UserId = this.userRoleInfo.UserId,
                                UserName = this.userRoleInfo.UserName,
                                UserPwd = this.userRoleInfo.UserPwd,
                                UserFName = this.userRoleInfo.UserFName,
                                UserPhone = this.userRoleInfo.UserPhone,
                                UserState = this.userRoleInfo.UserState
                        };
                        var roleIds = this.RoleIds;
                        if (roleIds != null&& roleIds.Count>0)
                        {
                                if(this.RoleList!=null&&this.RoleList.Count >0)
                                {
                                        CheckRoleList(false);
                                        foreach(var role in this.RoleList)
                                        {
                                                if(roleIds.Contains(role.RoleInfo.RoleId))
                                                {
                                                        role.IsCheck = true;
                                                }
                                        }
                                }
                        }
                }

                /// <summary>
                /// 全选或清空所有角色列表
                /// </summary>
                /// <param name="bl"></param>
                private void CheckRoleList(bool bl)
                {
                        foreach (var role in this.RoleList)
                        {
                                role.IsCheck = false;
                        }
                }

              
        }
}
