using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DXHouseApp.ViewModels.SM
{
        public class RoleInfoCheck:ListCheckModelBase
        {
                private RoleInfoModel roleInfo;
                public RoleInfoModel RoleInfo
                {
                        get { return roleInfo; }
                        set { roleInfo = value;
                                OnPropertyChanged();
                        }
                }


        }
}
