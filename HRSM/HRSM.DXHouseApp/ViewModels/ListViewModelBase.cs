using DevExpress.Xpf.Core;
using HRSM.DXHouseApp.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels
{
        public class ListViewModelBase : ViewModelBase
        {

                /// <summary>
                /// ShowDel复选框的勾选状态
                /// </summary>
                private bool isShowDel = false;
                public bool IsShowDel
                {
                        get { return isShowDel; }
                        set
                        {
                                isShowDel = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 是否显示修改、删除列
                /// </summary>
                private bool isEdited = true;
                public bool IsEdited
                {
                        get
                        {
                                isEdited = !isShowDel;
                                return isEdited;
                        }
                        set
                        {
                                isEdited = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 是否全选
                /// </summary>
                private bool isCheckAll = false;
                public bool IsCheckAll
                {
                        get { return isCheckAll; }
                        set
                        {
                                isCheckAll = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 工具栏配置
                /// </summary>
                private ToolBarViewModel toolbarInfo;
                public ToolBarViewModel ToolBarInfo
                {
                        get
                        {
                                return toolbarInfo;
                        }
                        set
                        {
                                toolbarInfo = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 选择项集合
                /// </summary>
                private IList selectedItems ;
                public IList SelectedItems
                {
                        get { return selectedItems; }
                        set
                        {
                                selectedItems = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 当前项
                /// </summary>
                private object currentItem ;
                public object CurrentItem
                {
                        get { return currentItem; }
                        set
                        {
                                currentItem = value;
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
                                        UserControl uc = o as UserControl;
                                        var mainWin = ComUtility.GetAncestor<ThemedWindow>(uc);
                                        MainViewModel mainVM = mainWin.DataContext as MainViewModel;
                                        mainVM.PageList.Remove(mainVM.SelectedTab);
                                });
                        }
                }

                /// <summary>
                /// 获取信息页面类别名称
                /// </summary>
                /// <param name="actType"></param>
                /// <returns></returns>
                public string GetInfoTypeName(int actType)
                {
                        string typeName = "";
                       switch(actType)
                        {
                                case 1: typeName ="添加"; break;
                                case 2: typeName = "修改"; break;
                                case 3: typeName = "添加子项"; break;
                                case 4: typeName = "详情"; break;
                                default:break;
                        }
                        return typeName;
                }
                

                /// <summary>
                /// 获取删除类别名称
                /// </summary>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public string GetDelTypeName(int isDeleted)
                {
                        string typeName = "";
                        switch (isDeleted)
                        {
                                case 1:
                                        typeName = "删除";
                                        break;
                                case 0:
                                        typeName = "恢复";
                                        break;
                                case 2:
                                        typeName = "移除";
                                        break;
                        }
                        return typeName;
                }

             
                /// <summary>
                ///子页中 添加指定页面到Tab页面
                /// </summary>
                /// <param name="header"></param>
                /// <param name="url"></param>
                public void AddDxTabItem(object uc,string header, string key,object VM)
                {
                        UserControl ucontrol = uc as UserControl;
                        var mainWin = ComUtility.GetAncestor<ThemedWindow>(ucontrol);
                        MainViewModel mainVM = mainWin.DataContext as MainViewModel;
                        DXTabItem tabItem0 = mainVM.PageList.Where(p => p.Header.ToString() == header).FirstOrDefault();
                        Frame frame = new Frame();
                        if (tabItem0==null)
                        {
                                DXTabItem tabItem = new DXTabItem();
                                tabItem.Header = header;
                                tabItem.Name = "tab" + key;
                                object page = WindowManager.CreateUCInstance(key, VM);
                                frame.Content = page;
                                tabItem.Content = frame;
                                mainVM.PageList.Add(tabItem);
                                mainVM.SelectedTab = tabItem;
                        }
                        else
                        {
                                frame = tabItem0.Content as Frame;
                                UserControl instance = frame.Content as UserControl;
                                instance.DataContext = VM;
                                mainVM.SelectedTab = tabItem0;
                        }
                      
                       
                }
        }
}
