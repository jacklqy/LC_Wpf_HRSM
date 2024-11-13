using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DXHouseApp.ViewModels.CRM
{
       public  class CustomerRequstInfoCheck:ViewModelBase
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
                /// 客户需求信息实体
                /// </summary>
                private ViewCustomerRequestInfoModel custRequestInfo;
                public ViewCustomerRequestInfoModel CustRequestInfo
                {
                        get { return custRequestInfo; }
                        set { custRequestInfo = value;
                                OnPropertyChanged();
                        }
                }

        }
}
