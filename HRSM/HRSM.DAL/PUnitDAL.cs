using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL
{
    public class PUnitDAL:BQuery<PriceUnitInfoModel>
    {
        /// <summary>
        /// 获取价格单位列表
        /// </summary>
        /// <param name="rsId"></param>
        /// <returns></returns>
        public List<PriceUnitInfoModel> GetPUnits()
        {
            return GetModelList("1=1","PUnitId,PUnitName");
        }
    }
}
