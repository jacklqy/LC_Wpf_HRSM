using DevExpress.Xpf.Editors;
using HRSM.BLL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels
{
        public class LoginViewModel : ViewModelBase
        {
                UserBLL userBLL = new UserBLL();
                UserInfoModel _user;
                public LoginViewModel()
                {
                        _user = new UserInfoModel();

                }

                private int userId = 0;
                public int UserId
                {
                        get { return userId; }
                        set
                        {
                                userId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 用户名
                /// </summary>
                public string UserName
                {
                        get { return _user.UserName; }
                        set
                        {
                                _user.UserName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 用户密码
                /// </summary>
                public string UserPwd
                {
                        get { return _user.UserPwd; }
                        set
                        {
                                _user.UserPwd = value;
                                OnPropertyChanged();
                        }
                }

                private string mainPageName = "HouseMain";
                /// <summary>
                /// 主页面名称
                /// </summary>
                public string MainPageName
                {
                        get { return mainPageName; }
                        set
                        {
                                mainPageName = value;
                                OnPropertyChanged();
                        }
                }

                private bool isLogin = true;
                /// <summary>
                /// Login按钮是否可用
                /// </summary>
                public bool IsLogin
                {
                        get { return isLogin; }
                        set
                        {
                                isLogin = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// UserName文本框是否获取焦点
                /// </summary>
                private bool userNameFocused = true;
                public bool UserNameFocused
                {
                        get { return userNameFocused; }
                        set
                        {
                                userNameFocused = value;
                                OnPropertyChanged();
                        }
                }


                /// <summary>
                /// UserPwd文本框是否获取焦点
                /// </summary>
                private bool userPwdFocused=false;
                public bool UserPwdFocused
                {
                        get { return userPwdFocused; }
                        set
                        {
                                userPwdFocused = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 登录命令
                /// </summary>
                public ICommand LoginCommand
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(o =>
                                  {
                                          Login(o);
                                  });
                                return cmd;
                        }
                }

                /// <summary>
                /// 退出命令
                /// </summary>
                public ICommand ExitCommand
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(o =>
                                {
                                        Application.Current.Shutdown();
                                });
                                return cmd;
                        }
                }

                /// <summary>
                /// 检查输入，更改登录按钮的可用状态
                /// </summary>
                public ICommand CheckIsLogin
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(o =>
                                {
                                        if ((!string.IsNullOrEmpty(this.UserName) && string.IsNullOrEmpty(this.UserPwd)) || (string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.UserPwd)))
                                        {
                                                //MsgBoxHelper.ShowError("请输入密码！", "登录系统");
                                                IsLogin = false;
                                        }
                                        else if ((!string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.UserPwd)) || (string.IsNullOrEmpty(this.UserName) && string.IsNullOrEmpty(this.UserPwd)))
                                                IsLogin = true;
                                });
                                return cmd;
                        }
                }

                /// <summary>
                /// 切换焦点
                /// </summary>
                public ICommand CheckIsFocused
                {
                        get
                        {
                                RelayCommand cmd = new RelayCommand(o =>
                                {
                                        if (o != null)
                                        {
                                                string p = o.ToString();
                                                if (p == "T")
                                                {
                                                        SetFocused(true);
                                                }
                                                else
                                                {
                                                        SetFocused(false);
                                                }
                                        }
                                });
                                return cmd;
                        }
                }
                /// <summary>
                /// 登录系统过程
                /// </summary>
                /// <param name="loginWin"></param>
                private void Login(object win)
                {

                        if (!string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.UserPwd))
                        {
                                int id = userBLL.UserLogin(this._user);
                                if (id == -1)//状态为冻结
                                {
                                        ShowErr("该账号已被冻结，不能使用系统！", "登录系统");
                                        SetFocused(true);
                                        return;
                                }
                                else if (id == 0)//登录失败
                                {
                                        ShowErr("用户名或密码输入有误！", "登录系统");
                                        SetFocused(true);
                                        return;
                                }
                                else//登录成功
                                {
                                        if (!string.IsNullOrEmpty(this.MainPageName))
                                        {
                                                this.UserId = id;
                                        }
                                        CloseWindow("loginWindow", win);
                                }
                        }


                }

                /// <summary>
                /// 设置Focus
                /// </summary>
                /// <param name="isName"></param>
                private void SetFocused(bool isName)
                {
                        this.UserNameFocused = true;
                        this.UserPwdFocused = !isName;
                }
        }
}
