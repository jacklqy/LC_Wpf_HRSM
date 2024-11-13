using DevExpress.Xpf.Core;
using HRSM.DXHouseApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static HRSM.DXHouseApp.MsgBoxWindow;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace HRSM.DXHouseApp.ViewModels
{
        public class ViewModelBase : INotifyPropertyChanged
        {
                public event PropertyChangedEventHandler PropertyChanged;
                //1.
                //protected void OnPropertyChanged(string propertyName)
                //{
                //    if (PropertyChanged != null)
                //    {
                //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                //    }
                //}

                //3.

                protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
                {
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }

                //2.

                //protected void OnPropertyChanged<T>(Expression<Func<T>> action)
                //{
                //    string proName = GetPropertyName(action);
                //    OnPropertyChangedEvent(proName);
                //}



                //protected void OnPropertyChangedEvent(string proName)
                //{
                //    if(PropertyChanged!=null)
                //    {
                //        PropertyChangedEventArgs e = new PropertyChangedEventArgs(proName);
                //        PropertyChanged(this, e);
                //    }
                //}


                ///// <summary>
                ///// 获取属性名
                ///// </summary>
                ///// <typeparam name="T"></typeparam>
                ///// <param name="action"></param>
                ///// <returns></returns>
                //private static string GetPropertyName<T>(Expression<Func<T>> action)
                //{
                //    var expression = (MemberExpression)action.Body;
                //    string proName = expression.Member.Name;
                //    return proName;
                //}



                #region MessageBox
                /// <summary>
                /// 模式化打开窗口
                /// </summary>
                /// <param name="key"></param>
                /// <param name="vm"></param>
                public void ShowDialog(string key, object VM)
                {
                        WindowManager.ShowDialog(key, VM);
                }


                public void CloseWindow(string key, object win)
                {
                        WindowManager.CloseWindow(key, win);
                }

                /// <summary>
                /// 操作成功消息框
                /// </summary>
                /// <param name="mes"></param>
                /// <param name="title"></param>
                /// <param name="buttons"></param>
                public void ShowMessage(string mes, string title = "", MessageBoxButton buttons = MessageBoxButton.OK)
                {
                        MessageBox.Show(mes, title, buttons, MessageBoxImage.Information);
                }
                /// <summary>
                /// 错误消息框
                /// </summary>
                /// <param name="mes"></param>
                /// <param name="title"></param>
                /// <param name="buttons"></param>
                public void ShowError(string mes, string title = "", MessageBoxButton buttons = MessageBoxButton.OK)
                {
                        MessageBox.Show(mes, title, buttons, MessageBoxImage.Error);
                }

                /// <summary>
                /// 询问消息框
                /// </summary>
                /// <param name="mes"></param>
                /// <param name="title"></param>
                /// <param name="buttons"></param>
                /// <returns></returns>
                public MessageBoxResult ShowConfirm(string mes, string title = "", MessageBoxButton buttons = MessageBoxButton.OKCancel)
                {
                        return MessageBox.Show(mes, title, buttons, MessageBoxImage.Question);
                }
                #endregion


                #region 自定义消息框



                /// <summary>
                /// 成功消息框
                /// </summary>
                /// <param name="mes"></param>
                /// <param name="title"></param>
                /// <param name="buttons"></param>
                public void ShowMsg(string mes, string title = "提示", CustomMessageBoxButton buttons = CustomMessageBoxButton.OK)
                {
                        MsgBoxWindow.Show(mes, title, buttons, CustomMessageBoxIcon.Information);
                }
                /// <summary>
                /// 错误消息框
                /// </summary>
                /// <param name="mes"></param>
                /// <param name="title"></param>
                /// <param name="buttons"></param>
                public void ShowErr(string mes, string title = "错误", CustomMessageBoxButton buttons = CustomMessageBoxButton.OK)
                {
                        MsgBoxWindow.Show(mes, title, buttons, CustomMessageBoxIcon.Error);
                }

                /// <summary>
                /// 询问消息框
                /// </summary>
                /// <param name="mes"></param>
                /// <param name="title"></param>
                /// <param name="buttons"></param>
                /// <returns></returns>
                public CustomMessageBoxResult ShowQuestion(string mes, string title = "", CustomMessageBoxButton buttons = CustomMessageBoxButton.OKCancel)
                {
                        return MsgBoxWindow.Show(mes, title, buttons, CustomMessageBoxIcon.Question);
                }
                #endregion

                /// <summary>
                /// 获取登录名
                /// </summary>
                /// <param name="uc"></param>
                /// <returns></returns>
                public string GetLoginUser(object uc)
                {
                        UserControl ucontrol = uc as UserControl;
                        var mainWin = ComUtility.GetAncestor<ThemedWindow>(ucontrol);
                        MainViewModel mainVM = mainWin.DataContext as MainViewModel;
                        string userName = mainVM.LoginUser;
                        return userName;
                }

                #region 

           

               
                #endregion


        }
}
