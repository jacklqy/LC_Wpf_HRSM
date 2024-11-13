using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRSM.DXHouseApp.ViewModels
{
    /// <summary>
    /// 导航菜单组实体
    /// </summary>

    public class MenuGroupItem:ViewModelBase
    {
        public string GroupName { get; set; }
        private bool isGroupExpand = true;
        public bool IsGroupExpand
        {
            get { return isGroupExpand; }
            set
            {
                isGroupExpand = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<MenuInfoModel> MenuItemList { get; set; } = new ObservableCollection<MenuInfoModel>();

    }

    

}
