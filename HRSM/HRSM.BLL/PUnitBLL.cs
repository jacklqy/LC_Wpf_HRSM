using HRSM.DAL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.BLL
{
    public class PUnitBLL
    {
        private PUnitDAL puDAL = new PUnitDAL();
        /// <summary>
        /// 获取价格单位列表
        /// </summary>
        /// <returns></returns>
        public List<PriceUnitInfoModel> GetPUnits()
        {
            return puDAL.GetPUnits();
        }
    }
}
