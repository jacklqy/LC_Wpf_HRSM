using HRSM.BLL;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DXHouseApp.ViewModels
{
    public class HouseInfoViewModel : ViewModelBase
    {
        HouseBLL houseBLL = new HouseBLL();

        public HouseInfoViewModel(int houseId)
        {
            this.houseId = houseId;
        }
        private int houseId;
        /// <summary>
        /// 房屋编号
        /// </summary>
        public int HouseId
        {
            get { return houseId; }
            set { houseId = value; }
        }

        private ViewHouseInfoModel houseInfoModel;
        /// <summary>
        /// 指定的房屋信息实体
        /// </summary>
        public ViewHouseInfoModel HouseInfoModel
        {
            get
            {
                houseInfoModel = GetHouseInfo();
                return houseInfoModel;
            }
        }

        /// <summary>
        /// 获取指定的房屋信息
        /// </summary>
        /// <returns></returns>
        private ViewHouseInfoModel GetHouseInfo()
        {
            ViewHouseInfoModel houseInfo = new ViewHouseInfoModel();
            if(this.houseId>0)
            {
                houseInfo= houseBLL.GetViewHouseInfo(this.houseId);
                if(houseInfo!=null && !string.IsNullOrEmpty(houseInfo.HousePic))
                {
                    string pic = Path.Combine("pack://siteoforigin:,,,/" + houseInfo.HousePic);
                    houseInfo.HousePic = pic;
                }
            }
            return houseInfo;
        }
    }
}
