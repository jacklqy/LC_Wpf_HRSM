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

namespace HRSM.ViewModels
{
    public class LoginViewModel:ViewModelBase
    {
        UserBLL userBLL = new UserBLL();
        UserInfoModel _user;
        public LoginViewModel()
        {
            _user = new UserInfoModel();

        }
      
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _user.UserName; }
            set {
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
            set {
                _user.UserPwd = value;
                OnPropertyChanged();
            }
        }

        private string mainPageName= "HouseMain";
        /// <summary>
        /// 主页面名称
        /// </summary>
        public string MainPageName
        {
            get { return mainPageName; }
            set { mainPageName = value;
                OnPropertyChanged();
            }
        }

        private bool isLogin=true;
        /// <summary>
        /// Login按钮是否可用
        /// </summary>
        public bool IsLogin
        {
            get { return isLogin; }
            set { isLogin = value;
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
                RelayCmmand cmd = new RelayCmmand(loginWin =>
                  {
                      Login(loginWin);
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
                RelayCmmand cmd = new RelayCmmand(o => {
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
                RelayCmmand cmd = new RelayCmmand(o => {
                    if ((!string.IsNullOrEmpty(this.UserName) && string.IsNullOrEmpty(this.UserPwd))||(string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.UserPwd)))
                    {
                        //MsgBoxHelper.ShowError("请输入密码！", "登录系统");
                        IsLogin = false;
                    }
                    else if ((!string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.UserPwd))|| (string.IsNullOrEmpty(this.UserName) && string.IsNullOrEmpty(this.UserPwd)))
                        IsLogin = true;
                });
                return cmd;
            }
        }
        /// <summary>
        /// 登录系统过程
        /// </summary>
        /// <param name="loginWin"></param>
        private void Login(object loginWin)
        {

            if (!string.IsNullOrEmpty(this.UserName) && string.IsNullOrEmpty(this.UserPwd))
            {
                MsgBoxHelper.ShowError("请输入密码！", "登录系统");
                return;
            }
            UserInfoModel userInfo = new UserInfoModel()
            {
                UserName = this.UserName,
                UserPwd = this.UserPwd
            };
            Type loginType = loginWin.GetType();
            if (!string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.UserPwd))
            {
                int id = userBLL.UserLogin(userInfo);
                if (id == -1)//状态为冻结
                {
                    MsgBoxHelper.ShowError("该账号已被冻结，不能使用系统！", "登录系统");
                    return;
                }
                else if (id == 0)//登录失败
                {
                    MsgBoxHelper.ShowError("用户名或密码输入有误！", "登录系统");
                    return;
                }
                else//登录成功
                {
                    //MsgBoxHelper.ShowInfo("登录成功！", "登录系统");

                    if (!string.IsNullOrEmpty(this.MainPageName))
                    {
                        Type mainType = GetUITypeByName(assName + "." + this.MainPageName);
                        object oMain = GetPropertyVal(loginType, loginWin, "Tag");
                        //设置HouseMain的Tag属性值为UserId
                        SetPropertyVal(mainType, oMain, "Tag", id);
                        //动态调用
                        {
                            MethodInfo miInitNavMenus = GetMethod(mainType, "LoadMain", false);
                            miInitNavMenus.Invoke(oMain, null);

                            //var hander = Delegate.CreateDelegate(InitNavMenus.EventHandlerType, oMain, miInitNavMenus);
                            //InitNavMenus.AddEventHandler(loginWin, hander);
                            //miInitNavMenus.Invoke(oMain, new object[] { oMain, new EventArgs() });

                        }
                       
                    }
                   
                }
            }
            //Close()
            GetMethod(loginType, "Close", true).Invoke(loginWin, null);

        }
       

    }
}
