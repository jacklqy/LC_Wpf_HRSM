using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.Models.VModels
{
    public class HouseOwnerModel
    {
        /// <summary>
        /// 房屋名称
        /// </summary>		
        public string HouseName { get; set; }
        /// <summary>
        /// 所属楼宇
        /// </summary>		
        public string Building { get; set; }
        /// <summary>
        /// 房屋地址
        /// </summary>		
        public string HouseAddress { get; set; }
        /// <summary>
        /// 租售类型
        /// </summary>		
        public string RentSale { get; set; }
        /// <summary>
        /// 房屋价格
        /// </summary>		
        public decimal? HousePrice { get; set; }
        /// <summary>
        /// 单位
        /// </summary>		
        public string PriceUnit { get; set; }
        /// <summary>
        /// 朝向
        /// </summary>		
        public string HouseDirection { get; set; }
        /// <summary>
        /// 户型
        /// </summary>		
        public string HouseLayout { get; set; }
        /// <summary>
        /// 业主
        /// </summary>		
        public int OwnerName { get; set; }
        /// <summary>
        /// 业主电话
        /// </summary>		
        public int OwnerPhone { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>		
        public int HouseFloor { get; set; }
        /// <summary>
        /// 面积
        /// </summary>		
        public decimal HouseArea { get; set; }
        /// <summary>
        /// 状态
        /// </summary>		
        public string HouseState { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
       
    }
}
