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
        public class RoleListViewModel:ListViewModelBase
        {
                RoleBLL roleBLL = new RoleBLL();
                public RoleListViewModel()
                {
                        this.RoleList = GetRoleList();
                        InitToolBars();
                }
             

                /// <summary>
                /// 角色列表
                /// </summary>
                private ObservableCollection<RoleInfoCheck> roleList=new ObservableCollection<RoleInfoCheck>();
                public ObservableCollection<RoleInfoCheck> RoleList
                {
                        get {
                                return roleList;
                        }
                        set {
                                roleList = value;
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
                                        var list = this.RoleList;
                                        foreach(var role in list)
                                        {
                                                role.IsCheck = this.IsCheckAll;
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
                                        if(o!=null)
                                        {
                                                var obj = o as RoleInfoCheck;
                                                obj.IsCheck = !obj.IsCheck;
                                        }
                                      
                                });
                        }
                }

                /// <summary>
                /// 查询角色列表
                /// </summary>
                public RelayCommand FindRoleListCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        ReloadRoleList();
                                });
                        }
                }

                /// <summary>
                /// 单条修改命令
                /// </summary>
                public ICommand EditRoleCmd
                {
                        get
                        {
                                return new RelayCommand(o => ShowRoleInfoPage(2));
                        }
                }

                public ICommand DelRoleCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelRole(o,1));
                        }
                }

                /// <summary>
                /// 恢复角色命令
                /// </summary>
                public ICommand RecoverRoleCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelRole(o, 0));
                        }
                }

                /// <summary>
                /// 移除角色命令
                /// </summary>
                public ICommand RemoveRoleCmd
                {
                        get
                        {
                                return new RelayCommand(o => SingleDelRole(o, 2));
                        }
                }

                /// <summary>
                /// 刷新角色列表
                /// </summary>
                private void ReloadRoleList()
                {
                        this.RoleList = GetRoleList();
                        ReLoadToolBars();
                }

                /// <summary>
                /// 条件获取角色列表
                /// </summary>
                /// <returns></returns>
                private ObservableCollection<RoleInfoCheck> GetRoleList()
                {
                        ObservableCollection<RoleInfoCheck> reList = new ObservableCollection<RoleInfoCheck>();
                        int isDel = this.IsShowDel ? 1 : 0;
                        this.IsEdited = !IsShowDel;
                        List<RoleInfoModel> list = roleBLL.GetRoleList(isDel);
                        list.ForEach(m => reList.Add(new RoleInfoCheck() {
                                IsCheck=false,
                                RoleInfo=m
                        }));
                        return reList;
                }

                private void ShowRoleInfoPage(int actType)
                {
                        if(this.CurrentItem!=null)
                        {
                                RoleInfoCheck curRole = this.CurrentItem as RoleInfoCheck;
                                ShowRoleInfoPage(actType, curRole.RoleInfo.RoleId);
                        }
                }

                /// <summary>
                /// 打开角色信息页面
                /// </summary>
                /// <param name="actType"></param>
                /// <param name="rId"></param>
                private void ShowRoleInfoPage(int actType,int rId)
                {
                        RoleInfoViewModel roleVM = new RoleInfoViewModel(actType, rId);
                        roleVM.ReLoadHandler += ReloadRoleList;//注册跨页面刷新事件
                        ShowDialog("roleInfo", roleVM);//打开角色信息页面
                }

                private void InitToolBars()
                {
                        this.ToolBarInfo = new ToolBarViewModel()
                        {
                                ShowRight =true,//显示权限分配
                                ShowFind = true,//显示查询按钮
                                //新增
                                AddCommand = new RelayCommand(o => ShowRoleInfoPage(1, 0), b =>IsEdited),
                                EditCommand = new RelayCommand(o => ShowRoleInfoPage(2)
                                , b => IsEditEnableToolItems()),
                                DeleteCommand = new RelayCommand(o => DeleteRoles(1, false), b => IsEditEnableToolItems()),
                                RecoverCommand = new RelayCommand(o => DeleteRoles(0, false), b => IsDeletedEnableToolItems()),
                                RemoveCommand = new RelayCommand(o => DeleteRoles(2, false), b => IsDeletedEnableToolItems()),
                                CloseCommand = this.CloseTabPage,
                                InfoCommand = new RelayCommand(o =>ShowRoleInfoPage(4),b=>this.RoleList.Count >0),
                                RightCommand = new RelayCommand(o => ShowRightPage(o), b => IsEditEnableToolItems()),
                                FindCommand = FindRoleListCmd
                        };
                }

                /// <summary>
                /// 刷新工具栏
                /// </summary>
               private void ReLoadToolBars()
                {
                        this.ToolBarInfo.AddCommand.OnCanExecuted();
                        this.ToolBarInfo.EditCommand.OnCanExecuted();
                        this.ToolBarInfo.DeleteCommand.OnCanExecuted();
                        this.ToolBarInfo.RecoverCommand.OnCanExecuted();
                        this.ToolBarInfo.RemoveCommand.OnCanExecuted();
                        this.ToolBarInfo.RightCommand.OnCanExecuted();
                        this.ToolBarInfo.InfoCommand.OnCanExecuted();
                }
               

                /// <summary>
                /// 显示权限设置页面
                /// </summary>
                private void ShowRightPage(object uc)
                {
                        int roleId = 0;
                        if (this.CurrentItem!=null)
                        {
                                RoleInfoCheck curRole = this.CurrentItem as RoleInfoCheck;
                                roleId = curRole.RoleInfo.RoleId;   
                        }
                        RightSetViewModel rightSetVM = new RightSetViewModel(roleId);
                        AddDxTabItem(uc, "权限设置", "rightSet", rightSetVM);
                }

                /// <summary>
                /// 单条删除处理(删除、恢复、移除)
                /// </summary>
                /// <param name="o"></param>
                /// <param name="isDeleted">1 logicdelete  0 recover   2 delete</param>
                private void SingleDelRole(object o, int isDeleted)
                {

                        if (o != null)
                        {
                                int Id = (int)o;
                                RoleInfoCheck role = this.RoleList.Where(r => r.RoleInfo.RoleId == Id).FirstOrDefault();
                                if (this.SelectedItems != null)
                                        this.SelectedItems.Clear();
                                else
                                        this.SelectedItems = new List<RoleInfoCheck>();
                                this.SelectedItems.Add(role);
                                DeleteRoles(isDeleted,true);
                        }
                }

                /// <summary>
                /// 删除角色处理(删除、恢复、移除)
                /// </summary>
                /// <param name="isDeleted"></param>
                private void DeleteRoles(int isDeleted,bool isSingle)
                {
                        string typeName = GetDelTypeName(isDeleted);
                        string msgTitle = $"角色{typeName}";
                        List<int> delIds = new List<int>();
                        if (!isSingle)
                        {
                                delIds = this.RoleList.Where(r => r.IsCheck == true).Select(r => r.RoleInfo.RoleId).ToList();
                        }
                        else
                        {
                                List<RoleInfoCheck> selList = this.SelectedItems as List<RoleInfoCheck>;
                                delIds = selList.Select(r => r.RoleInfo.RoleId).ToList();
                        }
                            
                        if (delIds.Count > 0)
                        {
                                if (isDeleted == 1)
                                {
                                        if (roleBLL.IsAdmin(delIds))
                                        {
                                                ShowErr("不能删除管理员角色！", msgTitle);
                                                return;
                                        }
                                }
                                if (ShowQuestion($"您确定要{typeName}选择的角色信息吗？", msgTitle) == MsgBoxWindow.CustomMessageBoxResult.OK)
                                {
                                        bool blDel = false;
                                        switch (isDeleted)
                                        {
                                                case 1:
                                                        blDel = roleBLL.LogicDeleteList(delIds);
                                                        break;
                                                case 0:
                                                        blDel = roleBLL.RecoverList(delIds);
                                                        break;
                                                case 2:
                                                        blDel = roleBLL.RecoverList(delIds);
                                                        break;
                                        }
                                        string sucMsg = blDel ? "成功" : "失败";
                                        string msg = $"选择的角色信息{typeName}{sucMsg}！";
                                        if (blDel)
                                        {
                                                ShowMsg(msg, msgTitle);
                                                ReloadRoleList();
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

                /// <summary>
                /// 修改、删除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsEditEnableToolItems()
                {
                        bool bl = (this.RoleList.Count > 0 && !IsShowDel);
                        return bl;
                }

                /// <summary>
                /// 恢复、移除工具项可用
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                private bool IsDeletedEnableToolItems()
                {
                        bool bl = (this.RoleList.Count > 0 && IsShowDel);
                        return bl;
                }
        }
}
