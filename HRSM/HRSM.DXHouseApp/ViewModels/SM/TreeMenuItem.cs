using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DXHouseApp.ViewModels.SM
{
        public class TreeMenuItem : ViewModelBase
        {
                private MenuInfoModel menuInfo = new MenuInfoModel();
                /// <summary>
                /// 勾选状态
                /// </summary>
                private bool? isCheck = false;
                public bool? IsCheck
                {
                        get { return isCheck; }
                        set
                        {
                                isCheck = value;
                                OnPropertyChanged();
                        }
                }


                public int MenuId
                {
                        get { return menuInfo.MenuId; }
                        set { menuInfo.MenuId = value; }
                }

                public string MenuName
                {
                        get { return menuInfo.MenuName; }
                        set { menuInfo.MenuName = value; }
                }

                public int ParentId
                {
                        get { return menuInfo.ParentId; }
                        set { menuInfo.ParentId = value; }
                }

               
        }
}
