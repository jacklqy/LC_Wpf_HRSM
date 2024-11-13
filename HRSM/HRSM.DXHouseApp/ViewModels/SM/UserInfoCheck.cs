using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DXHouseApp.ViewModels.SM
{
        /// <summary>
        /// 用户列表中的实体类
        /// </summary>
       public  class UserInfoCheck:ListCheckModelBase
        {

                private UserInfoModel userInfo;

                public UserInfoModel UserInfo
                {
                        get { return userInfo; }
                        set { userInfo = value;
                                OnPropertyChanged();
                        }
                }

        }
}
