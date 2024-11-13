using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL.VDAL
{
    public class ViewCustomerRequestDAL:BQuery<ViewCustomerRequestInfoModel>
    {
        /// <summary>
        /// 获取客户需求列表
        /// </summary>
        /// <returns></returns>
        public List<ViewCustomerRequestInfoModel> GetCustRequests(int custId,string custName,string custType, string followUpUser, string content,int isDeleted)
        {
            string cols = "CustRequestId,CustomerId,CustomerName,RequestContent,FollowUpUser,CreateTime,RequestState";
            string strWhere = $"IsDeleted={isDeleted}";
            List<SqlParameter> list = new List<SqlParameter>();
            if(custId>0)
            {
                strWhere += $" and CustomerId={custId}";
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
            if (!string.IsNullOrEmpty(custType))
            {
                strWhere += " and CustomerType = @custType";
                list.Add(new SqlParameter("@custType", followUpUser));
            }
            if (!string.IsNullOrEmpty(content))
            {
                strWhere += " and RequestContent like @content";
                list.Add(new SqlParameter("@content", $"%{content}%"));
            }
          
            return GetRowsModelList(strWhere,cols,list.ToArray());
        }
    }
}
