using HRSM.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.Models.VModels
{
    /// <summary>
    /// 房屋数量统计实体
    /// </summary>
    [Table("ViewHouseCountSatistics")]
   
    public class ViewHouseCountSatisticsModel
    {
        public int TotalCount { get; set; }
        public int PublishedCount { get; set; }
        public int UnPublishedCount { get; set; }
        public int TRentCount { get; set; }
        public int TSaleCount { get; set; }
        public int HasRentCount { get; set; }
        public int UnRentCount { get; set; }
        public int HasSaleCount { get; set; }
        public int UnSaleCount { get; set; }
    }
}
