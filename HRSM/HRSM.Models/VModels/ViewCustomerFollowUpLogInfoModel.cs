﻿using HRSM.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.Models.VModels
{
    [Table("ViewCustomerFollowUpLogInfos")]
    [PrimaryKey("FLogId", autoIncrement = true)]
    public class ViewCustomerFollowUpLogInfoModel
    {
        public int FLogId { get; set; }
        public int  CustRequestId { get; set; }
        public DateTime FollowUpTime { get; set; }
        public string   FollowUpContent { get; set; }
        public string FollowUpUser { get; set; }
        public string FollowUpState { get; set; }
        public int IsDeleted { get; set; }
        public string RequestContent { get; set; }
        public int CustomerId  { get; set; }
        public string CustomerName { get; set; }
    }
}
