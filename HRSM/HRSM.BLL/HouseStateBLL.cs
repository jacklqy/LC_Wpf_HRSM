using HRSM.DAL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.BLL
{
    public class HouseStateBLL
    {
        private HouseStateDAL hsDAL = new HouseStateDAL();
        /// <summary>
        /// 获取指定租售类型的房屋状态列表
        /// </summary>
        /// <param name="rsId"></param>
        /// <returns></returns>
        public List<HouseStateInfoModel> GetHouseStates(int rsId)
        {
            return hsDAL.GetHouseStates(rsId);
        }
    }
}
