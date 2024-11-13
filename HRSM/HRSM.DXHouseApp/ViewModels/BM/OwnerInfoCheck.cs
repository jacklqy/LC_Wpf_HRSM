using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DXHouseApp.ViewModels.BM
{
        /// <summary>
        /// 业主列表信息模型
        /// </summary>
        public class OwnerInfoCheck:ViewModelBase
        {
                /// <summary>
                /// 是否勾选
                /// </summary>
                private bool isCheck = false;
                public bool IsCheck
                {
                        get { return isCheck; }
                        set
                        {
                                isCheck = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 业主信息
                /// </summary>
                private HouseOwnerInfoModel ownerInfo;
                public HouseOwnerInfoModel OwnerInfo
                {
                        get { return ownerInfo; }
                        set
                        {
                                ownerInfo = value;
                                OnPropertyChanged();
                        }
                }
        }
}
