using HRSM.BLL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels.BM
{
        public class OwnerInfoViewModel:InfoViewModelBase
        {
                OwnerBLL ownerBLL = new OwnerBLL();
                public OwnerInfoViewModel()
                {

                }

                public OwnerInfoViewModel(int actType,int ownerId)
                {
                        this.ActType = actType;
                        this.OwnerId = ownerId;
                        switch (this.ActType)
                        {
                                case 1:
                                        this.ConfirmBtnContent = "添加";
                                        this.OwnerType = "个人";
                                        this.IsConfirmBtnEnabled = true;
                                        break;
                                case 2:
                                        this.ConfirmBtnContent = "修改";
                                        this.ownerInfo = ownerBLL.GetOwnerInfo(ownerId);
                                        this.IsConfirmBtnEnabled = true;
                                        this.oldOwnerName = this.ownerInfo.OwnerName;
                                        break;
                                case 4:
                                        this.ownerInfo = ownerBLL.GetOwnerInfo(ownerId);
                                        this.IsConfirmBtnVisible = System.Windows.Visibility.Hidden;
                                        break;
                                default: break;
                        }
                }
                private HouseOwnerInfoModel ownerInfo = new HouseOwnerInfoModel();
                private string oldOwnerName = "";

                /// <summary>
                /// 业主类型列表
                /// </summary>
                public List<string> CboOwnerTypes
                {
                        get
                        {
                                return new List<string>() { "个人", "单位" };
                        }
                }
                #region 业主信息
                /// <summary>
                /// 业主编号
                /// </summary>
                private int ownerId;
                public int OwnerId
                {
                        get { return ownerId; }
                        set
                        {
                                ownerId = value;
                                OnPropertyChanged();
                        }
                }
                /// <summary>
                /// 选择的业主类型
                /// </summary>
                public string OwnerType
                {
                        get { return ownerInfo.OwnerType; }
                        set { ownerInfo.OwnerType = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 业主的名称
                /// </summary>
                public string OwnerName
                {
                        get { return ownerInfo.OwnerName; }
                        set
                        {
                                ownerInfo.OwnerName = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 联系人
                /// </summary>
                public string Contactor
                {
                        get { return ownerInfo.Contactor; }
                        set
                        {
                                ownerInfo.Contactor = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 业主电话
                /// </summary>
                public string OwnerPhone
                {
                        get { return ownerInfo.OwnerPhone; }
                        set
                        {
                                ownerInfo.OwnerPhone = value;
                                OnPropertyChanged();
                        }
                }
                /// <summary>
                /// 业主地址
                /// </summary>
                public string OwnerAddress
                {
                        get { return ownerInfo.OwnerAddress; }
                        set
                        {
                                ownerInfo.OwnerAddress = value;
                                OnPropertyChanged();
                        }
                }

               /// <summary>
               /// 业主描述 
               /// </summary>
                public string Remark
                {
                        get { return ownerInfo.Remark; }
                        set
                        {
                                ownerInfo.Remark = value;
                                OnPropertyChanged();
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
                                        string actMsg = ActType == 2 ? "修改" : "添加";
                                        string msgTitle = $"业主{actMsg}";
                                        if (string.IsNullOrEmpty(this.OwnerName))
                                        {
                                                ShowErr("请输入业主名！", msgTitle);
                                                return;
                                        }
                                        if (string.IsNullOrEmpty(OwnerPhone))
                                        {
                                                ShowErr("请输入业主电话！", msgTitle);
                                                return;
                                        }
                                        if (ownerId == 0 || (oldOwnerName != "" && oldOwnerName != this.OwnerName))
                                        {
                                                if (ownerBLL.Exists(OwnerName, OwnerPhone))
                                                {
                                                        ShowErr("该业主已存在！", msgTitle);
                                                        return;
                                                }
                                        }
                                        bool bl = ActType == 1 ? ownerBLL.AddOwnerInfo(ownerInfo) : ownerBLL.UpdateOwnerInfo(ownerInfo);
                                        string sucType = bl ? "成功" : "失败";
                                        string msgInfo = $"业主：{OwnerName} {actMsg}{sucType}!";
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
        }
}
