using HRSM.BLL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HRSM.DXHouseApp.ViewModels.SM
{
        public class RoleInfoViewModel:InfoViewModelBase
        {
                RoleBLL roleBLL = new RoleBLL();
                private RoleInfoModel roleInfo = new RoleInfoModel();

                #region RoleInfoViewModel构造函数
                /// <summary>
                /// 构造函数
                /// </summary>
                public RoleInfoViewModel()
                {
                }
                public RoleInfoViewModel(int acttype,int roleId)
                {
                        this.RoleId = roleId;
                        this.ActType = acttype;
                        switch (this.ActType)
                        {
                                case 1:
                                        this.ConfirmBtnContent = "添加";
                                        break;
                                case 2:
                                        this.roleInfo = roleBLL.GetRoleInfo(this.RoleId);
                                        this.oldRoleName = this.roleInfo.RoleName;
                                        this.ConfirmBtnContent = "修改";
                                        break;
                                case 4:
                                        this.roleInfo = roleBLL.GetRoleInfo(this.RoleId);
                                        this.IsConfirmBtnVisible = Visibility.Hidden;
                                        break;
                        }
                }
                #endregion

                #region 角色信息
                /// <summary>
                /// 角色编号
                /// </summary>
                private int roleId;
                public int RoleId
                {
                        get
                        {
                                return roleId;
                        }
                        set
                        {
                                roleId = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 角色名称
                /// </summary>
                public string RoleName
                {
                        get { return roleInfo.RoleName; }
                        set
                        {
                                roleInfo.RoleName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 角色描述
                /// </summary>
                public string Remark
                {
                        get { return roleInfo.Remark; }
                        set { roleInfo.Remark = value;
                                OnPropertyChanged();
                        }
                }
                #endregion

                /// <summary>
                /// 角色名称未输入时显示的文本的颜色
                /// </summary>
                private Brush nRoleNameFColor=new SolidColorBrush(Colors.Gray);
                public Brush NRoleNameFColor
                {
                        get { return nRoleNameFColor; }
                        set { nRoleNameFColor = value;
                                OnPropertyChanged();
                        }
                }
                //修改前的角色名称
                private string oldRoleName = "";

                /// <summary>
                /// 检查输入
                /// </summary>
                public ICommand CheckInfoCmd
                {
                        get
                        {
                                return new RelayCommand(o =>
                                {
                                        if (string.IsNullOrEmpty(this.RoleName))
                                        {
                                                this.IsConfirmBtnEnabled = false;
                                                this.NRoleNameFColor = new SolidColorBrush(Colors.Red);
                                                return;
                                        }
                                        else if(this.RoleId==0||(this.RoleId>0&&this.oldRoleName!=this.RoleName))
                                        {
                                                if(roleBLL.Exists(this.RoleName))
                                                {
                                                        ShowErr("该角色名称已存在！");
                                                        this.IsConfirmBtnEnabled = false;
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
                                                bl = roleBLL.UpdateRoleInfo(this.roleInfo);
                                        else
                                                bl = roleBLL.AddRoleInfo(this.roleInfo);
                                        string actMsg = ActType == 2 ? "修改" : "添加";
                                        string msgTitle = $"角色{actMsg}页面";
                                        string sucType = bl ? "成功" : "失败";
                                        string msgInfo = $"角色：{this.RoleName} {actMsg}{sucType}!";
                                        if (bl)
                                        {
                                                ShowMsg(msgInfo, msgTitle);
                                                InvokeReLoad();//刷新列表页数据
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
                                        CloseWindow("roleInfo", o);
                                });
                        }
                }
                #endregion
        }
}
