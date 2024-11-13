using HRSM.DAL;
using HRSM.DAL.VDAL;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.BLL
{
        public class HouseTradeBLL
        {
                private HouseTradeDAL houseTradeDAL = new HouseTradeDAL();
                private ViewSaleHouseStatisticsDAL vshstatDAL = new ViewSaleHouseStatisticsDAL();
                /// <summary>
                /// 添加交易记录
                /// </summary>
                /// <param name="houseTradeInfo"></param>
                /// <returns></returns>
                public bool AddHouseTradeInfo(HouseTradeInfoModel houseTradeInfo)
                {
                        return houseTradeDAL.AddHouseTradeInfo(houseTradeInfo);
                }

                /// <summary>
                /// 获取指定交易号的信息
                /// </summary>
                /// <param name="tradeId"></param>
                /// <returns></returns>
                public HouseTradeInfoModel GetTradeInfo(int tradeId)
                {
                        return houseTradeDAL.GetTradeInfo(tradeId);
                }

                /// <summary>
                /// 获取所有销售员的销售房屋量统计数据
                /// </summary>
                /// <returns></returns>
                public List<ViewSaleHouseStatisticsModel> GetSaleHouseStatisticsData()
                {
                        return vshstatDAL.GetSaleHouseStatisticsData();
                }

                /// <summary>
                /// 获取时间范围内的销售量
                /// </summary>
                /// <param name="startTime"></param>
                /// <param name="endTime"></param>
                /// <returns></returns>
                public List<ViewSaleHouseStatisticsModel> GetSaleTimeHouseStatisticsData(string saleUser, string stTime, string etTime)
                {
                        DateTime? startTime = null;
                        DateTime? endTime = null;
                        if (!string.IsNullOrEmpty(stTime))
                                startTime = DateTime.Parse(stTime + " 00:00:00");
                        if (!string.IsNullOrEmpty(etTime))
                                endTime = DateTime.Parse(etTime + " 23:59:59");

                        List<ViewSaleHouseStatisticsModel> list = vshstatDAL.GetSaleTimeHouseStatisticsData(saleUser, startTime, endTime);

                        return list;
                }
        }
}
