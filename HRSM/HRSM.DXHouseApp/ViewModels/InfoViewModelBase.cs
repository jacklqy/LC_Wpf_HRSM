using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HRSM.DXHouseApp.ViewModels
{
        public class InfoViewModelBase:ViewModelBase
        {
                /// <summary>
                /// 刷新列表页事件
                /// </summary>
                public event Action ReLoadHandler;

                /// <summary>
                /// 调用事件
                /// </summary>
                public void InvokeReLoad()
                {
                        ReLoadHandler?.Invoke();
                }
                /// <summary>
                /// 页面的类别编号 1   2    3
                /// </summary>
                private int actType = 1;
                public int ActType
                {
                        get { return actType; }
                        set
                        {
                                actType = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 关闭TabItem页面（页面中的工具栏关闭按钮）
                /// </summary>
                public RelayCommand CloseTabPage
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        if(o is UserControl)
                                        {
                                                UserControl uc = o as UserControl;
                                                var mainWin = ComUtility.GetAncestor<ThemedWindow>(uc);
                                                MainViewModel mainVM = mainWin.DataContext as MainViewModel;
                                                mainVM.PageList.Remove(mainVM.SelectedTab);
                                        }
                                       
                                });
                        }
                }

                #region 提交按钮
                /// <summary>
                /// 提交按钮文本
                /// </summary>
                private string confirmBtnContent = "添加";
                public string ConfirmBtnContent
                {
                        get { return confirmBtnContent; }
                        set
                        {
                                confirmBtnContent = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 提交按钮的显示
                /// </summary>
                private Visibility isConfirmBtnVisible = Visibility.Visible;
                public Visibility IsConfirmBtnVisible
                {
                        get { return isConfirmBtnVisible; }
                        set
                        {
                                isConfirmBtnVisible = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 提交按钮是否可用
                /// </summary>
                private bool isConfirmBtnEnabled = false;
                public bool IsConfirmBtnEnabled
                {
                        get { return isConfirmBtnEnabled; }
                        set
                        {
                                isConfirmBtnEnabled = value;
                                OnPropertyChanged();
                        }
                }
                #endregion
        }
}
