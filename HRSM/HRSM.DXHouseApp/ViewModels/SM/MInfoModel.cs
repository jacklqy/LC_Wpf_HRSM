using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DXHouseApp.ViewModels.SM
{
   /// <summary>
   /// 用于显示于列表中的菜单信息实体
   /// </summary>
	public class MInfoModel:ViewModelBase
	{
		private MenuInfoModel menuInfo = new MenuInfoModel();
		 public MenuInfoModel MenuInfo
		{
			get { return menuInfo; }
			set
			{
				menuInfo = value;
				OnPropertyChanged();
			}
		}
		private bool isChecked = false;
		 public bool IsChecked{
		     get { return isChecked; }
			 set {
				isChecked = value;
				OnPropertyChanged();
			 }
		 }
	}
}
