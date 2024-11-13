using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSM.Models.VModels;

namespace HRSM.DXHouseApp.ViewModels.CRM
{
    public  class CustomerFollowUpLogInfoCheck:ViewModelBase
    {
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
                /// 跟进日志信息
                /// </summary>
                private ViewCustomerFollowUpLogInfoModel followUpLogInfo = new ViewCustomerFollowUpLogInfoModel();
                public ViewCustomerFollowUpLogInfoModel FollowUpLogInfo
                {
                        get { return followUpLogInfo; }
                        set { followUpLogInfo = value;
                                OnPropertyChanged();
                        }
                }
        }
}
