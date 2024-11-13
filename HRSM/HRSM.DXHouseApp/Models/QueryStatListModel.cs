using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HRSM.DXHouseApp.ComUtility;

namespace HRSM.DXHouseApp.Models
{
    public class QueryStatListModel
    {
        /// <summary>
        /// 统计数量名称
        /// </summary>
        public string StatCountName { get; set; }
        public int StatCount { get; set; }
        /// <summary>
        ///统计数量属性名
        /// </summary>
        public string SatCountProName { get; set; }
        /// <summary>
        /// 统计类型
        /// </summary>
        public StatType StatType { get; set; }
        public string SaleUser { get; set; }
        public string StTime { get; set; }
        public string EtTime { get; set; }
    }
}
