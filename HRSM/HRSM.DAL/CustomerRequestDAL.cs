using DBUtility;
using HRSM.Common;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL
{
        public class CustomerRequestDAL : BaseDAL<CustomerRequestInfoModel>
        {

                /// <summary>
                /// 添加需求客户信息
                /// </summary>
                /// <param name="custRequestInfo"></param>
                /// <returns></returns>
                public bool AddCustomerRequestInfo(CustomerRequestInfoModel custRequestInfo)
                {
                        string cols = "CustomerId,RequestContent,FollowUpUser";
                        //return Add(custRequestInfo, cols, 0) > 0;
                        List<CommandInfo> list = new List<CommandInfo>();
                        SqlModel inModel = CreateSql.GetInsertSqlAndParas(custRequestInfo, cols, 0);
                        list.Add(new CommandInfo()
                        {
                                CommandText = inModel.Sql,
                                IsProc = false,
                                Paras = inModel.Paras
                        });
                        string sql = $"update CustomerInfos set CustomerState='意向客户' where CustomerId={custRequestInfo.CustomerId}";
                        list.Add(new CommandInfo()
                        {
                                CommandText = sql,
                                IsProc = false
                        });
                        return SqlHelper.ExecuteTrans(list);
                }


                /// <summary>
                /// 修改需求客户信息
                /// </summary>
                /// <param name="custRequestInfo"></param>
                /// <returns></returns>
                public bool UpdateCustomerRequestInfo(CustomerRequestInfoModel custRequestInfo)
                {
                        string cols = "CustRequestId,CustomerId,RequestContent,FollowUpUser,RequestState";
                        return Update(custRequestInfo, cols, "");
                }

                /// <summary>
                /// 修改客户需求信息(并连同关系数据)的删除状态（真删除即为删除操作）
                /// </summary>
                /// <param name="custRequestId"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool UpdateCustomerRequestInfoState(int custRequestId, int delType, int isDeleted)
                {
                        List<string> sqlList = new List<string>();
                        string[] tableNames = { "CustomerRequestInfos", "CustomerFollowUpLogInfos" };
                        sqlList = GetDeleteSql(delType, custRequestId, isDeleted, tableNames);
                        return SqlHelper.ExecuteTrans(sqlList);
                }

                /// <summary>
                /// 批量 修改客户需求信息(并连同关系数据)的删除状态（真删除即为删除操作）
                /// </summary>
                /// <param name="custRequestIds"></param>
                /// <param name="delType"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public bool UpdateCustomerRequestsState(List<int> custRequestIds, int delType, int isDeleted)
                {
                        List<string> sqlList = new List<string>();
                        string[] tableNames = { "CustomerRequestInfos", "CustomerFollowUpLogInfos" };
                        sqlList = GetDeleteListSql(delType, custRequestIds, isDeleted, tableNames);
                        return SqlHelper.ExecuteTrans(sqlList);
                }





                /// <summary>
                /// 获取指定客户需求信息
                /// </summary>
                /// <param name="custId"></param>
                /// <returns></returns>
                public CustomerRequestInfoModel GetCustomerRequestInfo(int custRequestId)
                {
                        string cols = "CustRequestId,CustomerId,RequestContent,FollowUpUser,CreateTime,RequestState";
                        return GetById(custRequestId, cols);
                }

                /// <summary>
                /// 判断客户需求是否已存在
                /// </summary>
                /// <param name="custName"></param>
                /// <param name="phone"></param>
                /// <returns></returns>
                public bool Exists(string custId, string requestContent)
                {
                        SqlParameter[] paras =
                        {
                new SqlParameter("@custId",custId),
                new SqlParameter("@requestContent",requestContent)
            };
                        return Exists("CustomerId=@custId and RequestContent=@requestContent and IsDeleted=0", paras);
                }

                /// <summary>
                /// 获取意向需求列表
                /// </summary>
                /// <returns></returns>
                public List<CustomerRequestInfoModel> GetCustIntentedRequests(bool isIntented)
                {
                        string strWhere = "IsDeleted=0 and CustRequestId in (select CustRequestId from CustomerRequestInfos where 1=1";
                        if (isIntented)
                                strWhere += " and RequestState='跟进中'";
                        strWhere += ")";
                        return GetModelList(strWhere, "CustRequestId,RequestContent");
                }



        }
}
