using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL.VDAL
{
    public class ViewHouseStatisticsDAL:BQuery<ViewHouseCountSatisticsModel>
    {
        /// <summary>
        /// 获取房屋数量统计信息
        /// </summary>
        /// <returns></returns>
        public ViewHouseCountSatisticsModel GetHouseStatistics()
        {
           return GetModel("", "");
        }
    }
}
