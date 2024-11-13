using HRSM.Common.CustomAttributes;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.Models.VModels
{
    [Table("ViewCustomerRequestInfos")]
    [PrimaryKey("CustRequestId", autoIncrement = true)]
    public class ViewCustomerRequestInfoModel:CustomerRequestInfoModel
    {
        public string CustomerName { get; set; }
    }
}
