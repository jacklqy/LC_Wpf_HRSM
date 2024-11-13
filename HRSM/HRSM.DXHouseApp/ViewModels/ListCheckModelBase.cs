using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DXHouseApp.ViewModels
{
        public class ListCheckModelBase:ViewModelBase
        {
                /// <summary>
                /// 是否勾选
                /// </summary>
                private bool isCheck;
                public bool IsCheck
                {
                        get { return isCheck; }
                        set
                        {
                                isCheck = value;
                                OnPropertyChanged();
                        }
                }
        }
}
