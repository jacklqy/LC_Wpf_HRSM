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
        public class RightSetViewModel : ListViewModelBase
        {
                private RoleBLL roleBLL = new RoleBLL();
                private MenuBLL menuBLL = new MenuBLL();
                public RightSetViewModel()
                {
                        this.MenuList = GetMenuList();
                        this.CboRoleList = GetCboRoleList();
                }
                public RightSetViewModel(int roleId)
                {
                        this.RoleId = roleId;
                        this.MenuList = GetMenuList();
                        this.CboRoleList = GetCboRoleList();
                      
                        if(RoleId>0)
                        {
                                this.CboEnable = false;
                                LoadHasRightSet();
                        }
                               
                }

                /// <summary>
                /// 要设置权限的角色编号
                /// </summary>
                private int roleId = 0;
                public int RoleId
                {
                        get { return roleId; }
                        set
                        {
                                roleId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 菜单树数据列表
                /// </summary>
                private ObservableCollection<TreeMenuItem> menuList = new ObservableCollection<TreeMenuItem>();
                public ObservableCollection<TreeMenuItem> MenuList
                {
                        get { return menuList; }
                        set
                        {
                                menuList = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 角色列表
                /// </summary>
                public List<RoleInfoModel> CboRoleList { get; set; }

                /// <summary>
                /// Cbo下拉框的可用状态
                /// </summary>
                private bool cboEnable=true;
                public bool CboEnable
                {
                        get { return cboEnable; }
                        set
                        {
                                cboEnable = value;
                                OnPropertyChanged();
                        }
                }



                /// <summary>
                /// 是否可保存
                /// </summary>
                private bool  isSave=true;
                public bool  IsSave
                {
                        get { return isSave; }
                        set { isSave = value;
                                OnPropertyChanged();
                        }
                }


                #region 命令配置

                /// <summary>
                /// 保存设置命令
                /// </summary>
                public ICommand SaveRightCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        var checkedList = this.MenuList.Where(m => m.IsCheck != false).Select(m=>m.MenuId).ToList();
                                        string msgTitle = "权限设置";
                                        if (checkedList.Count == 0)
                                        {
                                               ShowErr("你没有进行权限设置，不能保存！", msgTitle);
                                                return;
                                        }
                                        else if(this.RoleId==0)
                                        {
                                                ShowErr("请选择要设置权限的角色！", msgTitle);
                                                return;
                                        }
                                        else
                                        {
                                                int roleId = this.RoleId;
                                                bool blSave = roleBLL.SaveRoleRightSet(checkedList, roleId);
                                                if (blSave)
                                                {
                                                        ShowMsg("权限设置保存成功！", msgTitle);
                                                }
                                                else
                                                {
                                                       ShowErr("权限设置保存失败！", msgTitle);
                                                        return;
                                                }
                                        }
                                });
                        }
                }

                /// <summary>
                /// 选择不同角色，加载已设置的权限
                /// </summary>
                public ICommand LoadRoleRightCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        LoadHasRightSet();
                                });
                        }
                }

                /// <summary>
                /// 全选或全不选
                /// </summary>
                public ICommand CheckAllCmd
                {
                        get
                        {
                                return new RelayCommand(o => CheckMenuListState(this.IsCheckAll));
                        }
                }

                #endregion

                /// <summary>
                /// 加载处理已设置的权限
                /// </summary>
                /// <param name="menuIds"></param>
                private void LoadHasRightSet()
                {
                        if(roleBLL.IsAdmin(this.RoleId))
                        {
                                CheckMenuListState(true);
                                this.IsSave = false;
                                return;
                        }
                        CheckMenuListState(false);//清空所有勾选
                        List<int> roleMenuIds = new List<int>();
                        if (this.RoleId > 0)
                        {
                                roleMenuIds = roleBLL.GetRoleMenuIds(this.RoleId);
                        }
                        foreach (var menu in this.MenuList)
                        {
                                if (roleMenuIds.Contains(menu.MenuId))
                                {
                                        menu.IsCheck = true;
                                }
                        }
                        IsSave = true;
                }

                /// <summary>
                /// 设置所有节点的勾选状态
                /// </summary>
                /// <param name="blCheck"></param>
                private void CheckMenuListState(bool blCheck)
                {
                        foreach (var menu in this.MenuList)
                        {
                                menu.IsCheck = blCheck;
                        }
                }

                /// <summary>
                /// 获取菜单列表
                /// </summary>
                /// <returns></returns>
                private ObservableCollection<TreeMenuItem> GetMenuList()
                {
                        ObservableCollection<TreeMenuItem> reList = new ObservableCollection<TreeMenuItem>();
                        List<MenuInfoModel> list = menuBLL.GetAllMenus();
                        list.ForEach(m => reList.Add(new TreeMenuItem()
                        {
                                IsCheck = false,
                                MenuId = m.MenuId,
                                MenuName = m.MenuName,
                                ParentId = m.ParentId
                        }));
                        return reList;
                }

              

                /// <summary>
                /// 获取角色列表
                /// </summary>
                /// <returns></returns>
                private List<RoleInfoModel> GetCboRoleList()
                {
                        List<RoleInfoModel> roles = roleBLL.GetAllRoles();
                        roles.Insert(0, new RoleInfoModel()
                        {
                                RoleId = 0,
                                RoleName = "请选择角色"
                        });
                        return roles;
                }
        }
}
