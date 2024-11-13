using DBUtility;
using HRSM.Common;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL
{
    public class CustomerFollowUpLogDAL:BaseDAL<CustomerFollowUpLogInfoModel>
    {

        /// <summary>
        /// 添加客户日志信息
        /// </summary>
        /// <param name="custLogInfo"></param>
        /// <returns></returns>
        public bool AddCustomerFULogInfo(CustomerFollowUpLogInfoModel custLogInfo)
        {
            string cols = "CustRequestId,FollowUpTime,FollowUpContent,FollowUpUser,FollowUpState";
            return AddOrUpdateLogAndCustState(custLogInfo, cols, 1);
          
        }


        /// <summary>
        /// 修改客户日志信息
        /// </summary>
        /// <param name="custLogInfo"></param>
        /// <returns></returns>
        public bool UpdateCustomerFULogInfo(CustomerFollowUpLogInfoModel custLogInfo)
        {
            string cols = "FLogId,CustRequestId,FollowUpTime,FollowUpContent,FollowUpUser,FollowUpState";
            return AddOrUpdateLogAndCustState(custLogInfo, cols, 2);
        }

        /// <summary>
        /// 新增或修改日志信息，并修改客户的状态
        /// </summary>
        /// <param name="custLogInfo"></param>
        /// <param name="cols"></param>
        /// <param name="actType"></param>
        /// <returns></returns>
        private bool AddOrUpdateLogAndCustState(CustomerFollowUpLogInfoModel custLogInfo,string cols,int actType)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            SqlModel inModel = null;
            if(actType==2)
                inModel = CreateSql.GetUpdateSqlAndParas(custLogInfo, cols, "");
            else
                inModel = CreateSql.GetInsertSqlAndParas(custLogInfo, cols, 0);
            list.Add(new CommandInfo()
            {
                CommandText = inModel.Sql,
                IsProc = false,
                Paras = inModel.Paras
            });
            list.Add(new CommandInfo()
            {
                CommandText = $"update CustomerRequestInfos set RequestState='{custLogInfo.FollowUpState}' where CustRequestId={custLogInfo.CustRequestId}",
                IsProc = false
            });
            if (custLogInfo.FollowUpState == FUState.成交.ToString() || custLogInfo.FollowUpState == FUState.放弃.ToString())
            {
                CustomerRequestDAL crDAL = new CustomerRequestDAL();
                CustomerRequestInfoModel requestInfo = crDAL.GetCustomerRequestInfo(custLogInfo.CustRequestId);
                if (requestInfo != null)
                {
                    string sql = $"update CustomerInfos set CustomerState='普通客户' where CustomerId={requestInfo.CustomerId}";
                    list.Add(new CommandInfo()
                    {
                        CommandText = sql,
                        IsProc = false
                    });
                }
            }
            return SqlHelper.ExecuteTrans(list);
        }

        /// <summary>
        /// 修改客户日志信息的删除状态（真删除即为删除操作）
        /// </summary>
        /// <param name="fLogId"></param>
        /// <param name="delType">0-假删除 1-真删除 </param>
        /// <returns></returns>
        public bool UpdateCustFLogInfoState(int fLogId, int delType, int isDeleted)
        {
            List<string> sqlList = new List<string>();
            string[] tableNames = {"CustomerFollowUpLogInfos" };
            sqlList = GetDeleteSql(delType, fLogId, isDeleted, tableNames);
            return SqlHelper.ExecuteTrans(sqlList);
        }

        /// <summary>
        /// 批量 修改客户日志信息的删除状态（真删除即为删除操作）
        /// </summary>
        /// <param name="fLogIds"></param>
        /// <param name="delType"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public bool UpdateCustFLogInfosState(List<int> fLogIds, int delType, int isDeleted)
        {
            List<string> sqlList = new List<string>();
            string[] tableNames = {"CustomerFollowUpLogInfos" };
            sqlList = GetDeleteListSql(delType, fLogIds, isDeleted, tableNames);
            return SqlHelper.ExecuteTrans(sqlList);
        }


        /// <summary>
        /// 获取指定客户日志信息
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public CustomerFollowUpLogInfoModel GetCustomerFLogInfo(int fLogId)
        {
            string cols = "CustRequestId,FollowUpTime,FollowUpContent,FollowUpUser,FollowUpState";
            return GetById(fLogId, cols);
        }

        /// <summary>
        /// 获取指定客户需求列表中的指定状态的日志记录数
        /// </summary>
        /// <param name="custRequestIds"></param>
        /// <param name="fuState"></param>
        /// <returns></returns>
        public int GetFULogCountByCustIdAndFUState(List<int> custRequestIds,FUState fuState)
        {
            string strIds = string.Join(",", custRequestIds);
            string sql = $"select count(1) from CustomerFollowUpLogInfos where CustRequestId in ({strIds}) and FollowUpState='{fuState}'";
            object o = SqlHelper.ExecuteScalar(sql, 1);
            return o.GetInt();
        }

       

        public enum FUState
        {
            跟进中,
            成交,
            放弃
        }
    }
}
