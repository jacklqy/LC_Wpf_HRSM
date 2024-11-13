using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HRSM.Common.CustomAttributes;

namespace HRSM.Models.DModels
{
    /// <summary>
    /// 价格单位
    /// </summary>
    [Table("PriceUnitInfos")]
    [PrimaryKey("PUnitId", autoIncrement = true)]
    public class PriceUnitInfoModel
    {

        /// <summary>
        /// 编号
        /// </summary>		
        public int PUnitId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>		
        public string PUnitName { get; set; }

    }
}

