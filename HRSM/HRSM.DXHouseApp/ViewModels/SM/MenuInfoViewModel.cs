using HRSM.BLL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels.SM
{
        public class MenuInfoViewModel : InfoViewModelBase
        {
                MenuBLL menuBLL = new MenuBLL();
                ///// <summary>
                ///// 菜单信息实体
                ///// </summary>
                private MenuInfoModel menuInfo = new MenuInfoModel();
                private string oldMenuName = "";
                /// <summary>
                /// 当前的菜单编号
                /// </summary>
                private int menuId;
                public int MenuId
                {
                        get
                        {
                                return menuId;
                        }
                        set
                        {
                                menuId = value;
                                OnPropertyChanged();
                        }
                }

                #region 菜单信息
                /// <summary>
                /// 菜单名称
                /// </summary>
                public string MenuName
                {
                        get { return menuInfo.MenuName; }
                        set
                        {
                                menuInfo.MenuName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 父菜单编号
                /// </summary>
                public int ParentId
                {
                        get { return menuInfo.ParentId; }
                        set
                        {
                                menuInfo.ParentId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 排序号
                /// </summary>
                public int MOrder
                {
                        get
                        {
                                return menuInfo.MOrder;
                        }
                        set
                        {
                                menuInfo.MOrder = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 菜单关联地址
                /// </summary>
                public string MenuUrl
                {
                        get { return menuInfo.MenuUrl; }
                        set
                        {
                                menuInfo.MenuUrl = value;
                                OnPropertyChanged();
                        }
                }

                public string MCode
                {
                        get { return menuInfo.MCode; }
                        set { menuInfo.MCode = value; }
                }
                #endregion

               

                #region 父菜单
                /// <summary>
                /// 父级菜单下拉框列表
                /// </summary>
                private List<MenuInfoModel> parentList = new List<MenuInfoModel>();
                public List<MenuInfoModel> ParentList
                {
                        get
                        {
                                parentList = menuBLL.GetAllMenus();
                                parentList.Insert(0, new MenuInfoModel()
                                {
                                        MenuId = 0,
                                        MenuName = "请选择父菜单"
                                });
                                return parentList;
                        }
                        set
                        {
                                parentList = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 父菜单下拉框的可用状态
                /// </summary>
                private bool isParentEnabled = true;
                public bool IsParentEnabled
                {
                        get { return isParentEnabled; }
                        set
                        {
                                isParentEnabled = value;
                                OnPropertyChanged();
                        }
                }


                /// <summary>
                /// 菜单名未输入时显示的文本
                /// </summary>
                private string mNameNullMsg;
                public string MNameNullMsg
                {
                        get { return mNameNullMsg; }
                        set
                        {
                                mNameNullMsg = value;
                                OnPropertyChanged();
                        }
                }


                #endregion

                #region 关闭窗口命令
                public ICommand CloseWindowCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        CloseWindow("menuInfo", o);
                                });
                        }
                }
                #endregion

                /// <summary>
                /// 提交命令
                /// </summary>
                public ICommand ConfirmCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                               {
                                       bool bl = false;
                                       if (this.ActType == 2)
                                               bl = menuBLL.UpdateMenuInfo(this.menuInfo);
                                       else
                                               bl = menuBLL.AddMenuInfo(this.menuInfo);
                                       string actMsg = ActType == 2 ? "修改" : "添加";
                                       string msgTitle = $"菜单{actMsg}页面";
                                       string sucType = bl ? "成功" : "失败";
                                       string msgInfo = $"菜单：{this.MenuName} {actMsg}{sucType}!";
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

                public ICommand CheckInfoCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        if (string.IsNullOrEmpty(this.MenuName) || this.ParentId == 0)
                                        {
                                                this.IsConfirmBtnEnabled = false;
                                                if (string.IsNullOrEmpty(this.MenuName))
                                                {
                                                        MNameNullMsg = "请输入菜单名！";
                                                        return;
                                                }
                                                else if(this.MenuId==0||(this.MenuId>0 && this.MenuName!=this.oldMenuName))
                                                {
                                                        if(menuBLL.Exists(this.MenuName))
                                                        {
                                                                ShowErr("该菜单名已存在！");
                                                                return;
                                                        }
                                                }
                                               if (this.ParentId == 0)
                                                {
                                                        ShowErr("请设置父菜单");
                                                        return;
                                                }
                                        }
                                        else
                                        {
                                                this.IsConfirmBtnEnabled = true;
                                        }
                                });
                        }
                }
              

                /// <summary>
                /// 构造函数
                /// </summary>
		public MenuInfoViewModel()
                {

                }

                public MenuInfoViewModel(int actType, int menuId)
                {
                        this.ActType = actType;
                        this.MenuId = menuId;
                        switch (actType)
                        {
                                case 1:
                                        this.MOrder = 1;
                                        this.ConfirmBtnContent = "添加";
                                        break;
                                case 2:
                                        this.menuInfo = menuBLL.GetMenuInfo(this.MenuId);
                                        this.ConfirmBtnContent = "修改";
                                        this.oldMenuName = menuInfo.MenuName;
                                        this.IsConfirmBtnEnabled = true;
                                        break;
                                case 3:
                                        this.MOrder = 1;
                                        this.ParentId = this.MenuId;
                                        this.MenuId = 0;
                                        this.oldMenuName = menuInfo.MenuName;
                                        this.IsParentEnabled = false;
                                        this.ConfirmBtnContent = "添加";
                                        break;
                                case 4:
                                        this.menuInfo = menuBLL.GetMenuInfo(this.MenuId);
                                        this.IsConfirmBtnVisible = Visibility.Hidden;
                                        break;
                        }
                }
        }
}
