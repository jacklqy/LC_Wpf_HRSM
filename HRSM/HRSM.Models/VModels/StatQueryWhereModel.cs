using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.Models.VModels
{
    /// <summary>
    /// 查询统计房屋明细条件实体
    /// </summary>
    public class StatQueryWhereModel
    {
        public int IsPublish { get; set; }
        public string RSName { get; set; }
        public string HouseState { get; set; }
    }
}
