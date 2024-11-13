using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using HRSM.BLL;
using HRSM.Common;
using HRSM.DXHouseApp.Models;
using HRSM.Models.DModels;

namespace HRSM.DXHouseApp.SM
{
        /// <summary>
        /// Interaction logic for MenuInfoWindow.xaml
        /// </summary>
        public partial class MenuInfoWindow : ThemedWindow
        {
                public MenuInfoWindow()
                {
                        InitializeComponent();
                }

                /// <summary>
                /// 页面加载
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void MenuInfoWindow_Loaded(object sender, RoutedEventArgs e)
                {

                }

                /// <summary>
                /// 加载所有页面
                /// </summary>
                public List<PageInfoModel> CboPages
                {
                        get
                        {
                                Assembly ass = Application.ResourceAssembly;
                                int length = ass.GetName().Name.Length;
                                List<PageInfoModel> types = ass.GetTypes().Where(t => t.BaseType == typeof(UserControl) && !t.FullName.Contains("Views")).Select(t => new PageInfoModel()
                                {
                                        Name = t.Name,
                                        FullName = t.FullName.Substring(length + 1).Replace('.', '/') + ".xaml"
                                }).ToList();
                                types.Insert(0, new PageInfoModel()
                                {
                                        Name = "请选择",
                                        FullName = ""
                                });
                                return types;
                        }

                }





                ///// <summary>
                ///// 提交菜单信息（新增或修改）
                ///// </summary>
                ///// <param name="obj"></param>
                //private void ConfirmMenuInfo(object obj)
                //{
                //    string menuName = txtMenuName.Text.Trim();
                //    string menuCode = string.IsNullOrEmpty(txtMenuCode.Text) ? null : txtMenuCode.Text.Trim();
                //    int parentId = cboParents.EditValue.GetInt();
                //    string menuUrl = cboPages.EditValue.ToString();
                //    bool isTop = chkIsTop.IsChecked.Value ;
                //    int order = txtMOrder.EditValue.GetInt() == 0 ? 1 : txtMOrder.EditValue.GetInt();

                //    string actMsg = actType == 2 ? "修改" : "添加";

                //    string msgTitle = $"菜单{actMsg}页面";
                //    if (string.IsNullOrEmpty(menuName))
                //    {
                //        MsgBoxHelper.ShowError("请输入菜单名！", msgTitle);
                //        txtMenuName.Focus();
                //        return;
                //    }
                //    if (menuId == 0 || (oldName != "" && oldName != menuName))
                //    {
                //        if (menuBLL.Exists(menuName))
                //        {
                //            MsgBoxHelper.ShowError("该菜单名已存在！", msgTitle);
                //            txtMenuName.Focus();
                //            return;
                //        }
                //    }

                //    MenuInfoModel menuInfo = new MenuInfoModel()
                //    {
                //        MenuName =menuName,
                //        ParentId=parentId,
                //        MenuUrl=menuUrl,
                //        IsTop=isTop,
                //        MOrder=order,
                //        MCode=menuCode
                //    };
                //    if (actType == 2)
                //        menuInfo.MenuId = menuId;
                //    bool bl = actType == 2 ? menuBLL.UpdateMenuInfo(menuInfo) : menuBLL.AddMenuInfo(menuInfo);

                //    string sucType = bl ? "成功" : "失败";
                //    string msgInfo = $"菜单：{menuName} {actMsg}{sucType}!";
                //    if (bl)
                //    {
                //        MsgBoxHelper.ShowInfo(msgInfo, msgTitle);
                //        if (this.ReLoad != null)
                //            this.ReLoad(obj, new EventArgs());
                //    }
                //    else
                //    {
                //        MsgBoxHelper.ShowError(msgInfo, msgTitle);
                //        return;
                //    }
                //}

                //private void ClosePage(object obj)
                //{
                //    this.Close();
                //}
        }


}
