using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HRSM.Common.CustomAttributes;

namespace HRSM.Models.DModels
{
    /// <summary>
    /// 房屋户型信息表
    /// </summary>
    [Table("HouseLayoutInfos")]
    [PrimaryKey("HLId", autoIncrement = true)]
    public class HouseLayoutInfoModel
    {

        /// <summary>
        /// 编号
        /// </summary>		
        public int HLId { get; set; }
        /// <summary>
        /// 户型名称
        /// </summary>		
        public string HLName { get; set; }

    }
}

