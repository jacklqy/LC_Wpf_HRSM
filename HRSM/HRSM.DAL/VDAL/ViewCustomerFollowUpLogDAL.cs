﻿using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL.VDAL
{
    public class ViewCustomerFollowUpLogDAL:BQuery<ViewCustomerFollowUpLogInfoModel>
    {
        /// <summary>
        /// 获取客户日志列表
        /// </summary>
        /// <returns></returns>
        public List<ViewCustomerFollowUpLogInfoModel> GetCustFLogs(int requestId,string custName,string followUpUser, string requestContent,string fContent, int isDeleted)
        {
            string cols = "FLogId,CustRequestId,CustomerId,CustomerName,RequestContent,FollowUpTime,FollowUpContent,FollowUpUser,FollowUpState";
            string strWhere = $"IsDeleted={isDeleted}";
            List<SqlParameter> list = new List<SqlParameter>();
            if(requestId > 0)
            {
                strWhere += " and CustRequestId=@requestId";
                list.Add(new SqlParameter("@requestId", requestId));
            }
            if (!string.IsNullOrEmpty(custName))
            {
                strWhere += " and CustomerName like @custName";
                list.Add(new SqlParameter("@custName", $"%{custName}%"));
            }
            if (!string.IsNullOrEmpty(followUpUser))
            {
                strWhere += " and FollowUpUser like @followUpUser";
                list.Add(new SqlParameter("@followUpUser", $"%{followUpUser}%"));
            }
            if (!string.IsNullOrEmpty(requestContent))
            {
                strWhere += " and RequestContent like @requestContent";
                list.Add(new SqlParameter("@requestContent", $"%{requestContent}%"));
            }
            if (!string.IsNullOrEmpty(fContent))
            {
                strWhere += " and FollowUpContent like @fContent";
                list.Add(new SqlParameter("@fContent", $"%{fContent}%"));
            }

            return GetRowsModelList(strWhere, cols, list.ToArray());
        }
    }
}
