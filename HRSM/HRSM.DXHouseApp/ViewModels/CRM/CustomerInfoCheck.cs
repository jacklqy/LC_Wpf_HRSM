using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DXHouseApp.ViewModels.CRM
{
        /// <summary>
        /// 客户列表中的实体模型
        /// </summary>
    public class CustomerInfoCheck:ViewModelBase
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
                /// 客户信息
                /// </summary>
                private CustomerInfoModel custInfo = new CustomerInfoModel();
                public CustomerInfoModel CustInfo
                {
                        get { return custInfo; }
                        set
                        {
                                custInfo = value;
                                OnPropertyChanged();
                        }
                }
        }
}
