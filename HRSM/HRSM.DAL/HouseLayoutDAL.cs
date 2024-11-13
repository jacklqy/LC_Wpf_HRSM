using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL
{
    public class HouseLayoutDAL:BQuery<HouseLayoutInfoModel>
    {
        /// <summary>
        /// 获取房屋户型列表
        /// </summary>
        /// <returns></returns>
        public List<HouseLayoutInfoModel> GetHouseLayouts()
        {
            return GetModelList("", "HLId,HLName");
        }
    }
}
