using HRSM.Common;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL.VDAL
{
    public class ViewSaleHouseStatisticsDAL:BQuery<ViewSaleHouseStatisticsModel>
    {
        /// <summary>
        /// 获取所有销售员的销售房屋量统计数据
        /// </summary>
        /// <returns></returns>
        public List<ViewSaleHouseStatisticsModel> GetSaleHouseStatisticsData()
        {
            return GetModelList("", "DealUser,UserFName,TotalCount,RentCount,SaleCount");
        }

        /// <summary>
        /// 获取时间范围内的销售量
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<ViewSaleHouseStatisticsModel> GetSaleTimeHouseStatisticsData(string saleName,DateTime? startTime,DateTime? endTime)
        {
            string strStartTime = "", strEndTime="";
            if (startTime!=null)
                strStartTime = startTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (endTime != null)
                strEndTime = endTime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string sql = $"select * from [dbo].StatisticsSaleHouseByTime('{saleName}','{strStartTime}','{strEndTime}')  ";
            DataTable dt = GetList(sql, 1);
            string cols = "DealUser,UserFName,TotalCount,RentCount,SaleCount";
            List<ViewSaleHouseStatisticsModel> list = DbConvert.DataTableToList<ViewSaleHouseStatisticsModel>(dt,cols);
            return list;
        }
    }
}
