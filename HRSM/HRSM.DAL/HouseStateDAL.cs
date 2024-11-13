using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL
{
    public class HouseStateDAL:BQuery<HouseStateInfoModel>
    {
        /// <summary>
        /// 获取指定类型的房屋状态列表
        /// </summary>
        /// <param name="rsId"></param>
        /// <returns></returns>
        public List<HouseStateInfoModel> GetHouseStates(int rsId)
        {
            string strWhere = "1=1";
            if (rsId > 0)
                strWhere += $" and RSId={rsId}";
            return GetModelList(strWhere,"StateId,StateName");
        }
    }
}
