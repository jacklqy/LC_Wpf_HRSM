using HRSM.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.Models.VModels
{
    /// <summary>
    /// 业务员销售量统计实体
    /// </summary>
    [Table("ViewSaleHouseStatistics")]
    public class ViewSaleHouseStatisticsModel
    {
        public string DealUser { get; set; }
        public string UserFName { get; set; }
        public string StatTime { get; set; }
        public int TotalCount { get; set; }
        public int RentCount { get; set; }
        public int SaleCount { get; set; }
    }
}
