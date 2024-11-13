using DBUtility;
using HRSM.Common;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL
{
    public class HouseTradeDAL:BaseDAL<HouseTradeInfoModel>
    {
        /// <summary>
        /// 添加交易记录(并修改房屋的状态)
        /// </summary>
        /// <param name="houseTradeInfo"></param>
        /// <returns></returns>
        public bool AddHouseTradeInfo(HouseTradeInfoModel houseTradeInfo)
        {
            string cols = "HouseId,OwnerId,CustomerId,RentSale,TradeAmount,PriceUnit,TradeTime,TradeWay,DealUser";
            //return Add(houseTradeInfo, cols, 0)>0;
            List<CommandInfo> list = new List<CommandInfo>();
            SqlModel inModel = CreateSql.GetInsertSqlAndParas(houseTradeInfo, cols, 0);
            list.Add(new CommandInfo()
            {
                CommandText = inModel.Sql,
                IsProc = false,
                Paras = inModel.Paras
            });
            string houseState = "";
            houseState = houseTradeInfo.RentSale == "出售" ? "已出售" : "已出租";
            string sql = $"update HouseInfos set HouseState='{houseState}' where HouseId={houseTradeInfo.HouseId}";
            list.Add(new CommandInfo()
            {
                CommandText = sql,
                IsProc = false
            });
            return SqlHelper.ExecuteTrans(list);
        }

        /// <summary>
        /// 获取指定交易号的信息
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        public HouseTradeInfoModel GetTradeInfo(int tradeId)
        {
            string cols = "HouseId,OwnerId,CustomerId,RentSale,TradeAmount,PriceUnit,TradeTime,TradeWay,DealUser";
            return GetById(tradeId, cols);
        }

        /// <summary>
        /// 获取已交易的房屋数
        /// </summary>
        /// <param name="rsName">租售类型</param>
        /// <returns></returns>
        public int GetHasTradeHouseCount(string rsName)
        {
            string sql = "select count(1) from HouseTradeInfos where RentSale=@rsName";
            SqlParameter paraName = new SqlParameter("@rsName", rsName);
            object o = SqlHelper.ExecuteScalar(sql, 1, paraName);
            if (o != null && o.ToString() != "")
                return o.GetInt();
            else
                return 0;
        }
        /// <summary>
        /// 判断指定房屋集合中是否存在已交易的房屋数
        /// </summary>
        /// <param name="houseIds"></param>
        /// <returns></returns>
        public int GetTradeHouseCount(List<int> houseIds)
        {
            string strIds = string.Join(",", houseIds);
            string sql = $"select count(1) from HouseTradeInfos where HouseId in ({strIds})";
            object o = SqlHelper.ExecuteScalar(sql, 1);
            if (o != null && o.ToString() != "")
                return o.GetInt();
            else
                return 0;
        }

        public int GetTradeCustomerCount(List<int> custIds)
        {
            string strIds = string.Join(",", custIds);
            string sql = $"select count(1) from HouseTradeInfos where CustomerId in ({strIds}) and IsDeleted=0";
            object o = SqlHelper.ExecuteScalar(sql, 1);
            if (o != null && o.ToString() != "")
                return o.GetInt();
            else
                return 0;
        }
    }
}
