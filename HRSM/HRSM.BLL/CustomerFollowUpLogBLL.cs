using HRSM.DAL;
using HRSM.DAL.VDAL;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HRSM.DAL.CustomerFollowUpLogDAL;

namespace HRSM.BLL
{
        public class CustomerFollowUpLogBLL
        {
                private CustomerFollowUpLogDAL cfulDAL = new CustomerFollowUpLogDAL();
                private ViewCustomerFollowUpLogDAL vcfuLogDAL = new ViewCustomerFollowUpLogDAL();


                /// <summary>
                /// 添加客户日志信息
                /// </summary>
                /// <param name="custFLogInfo"></param>
                /// <returns></returns>
                public bool AddCustomerFLogInfo(CustomerFollowUpLogInfoModel custFLogInfo)
                {
                        return cfulDAL.AddCustomerFULogInfo(custFLogInfo);
                }

                /// <summary>
                /// 修改客户日志信息
                /// </summary>
                /// <param name="custFLogInfo"></param>
                /// <returns></returns>
                public bool UpdateCustomerFLogInfo(CustomerFollowUpLogInfoModel custFLogInfo)
                {
                        return cfulDAL.UpdateCustomerFULogInfo(custFLogInfo);
                }

                #region 删除与恢复
                /// <summary>
                /// 删除客户日志信息（假删除）
                /// </summary>
                /// <param name="fLogId"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool LogicDelCustomerFULog(int fLogId)
                {
                        return cfulDAL.UpdateCustFLogInfoState(fLogId, 0, 1);

                }

                /// <summary>
                /// 恢复客户日志信息
                /// </summary>
                /// <param name="custRequestId"></param>
                /// <returns></returns>
                public bool RecoverCustomerFULog(int fLogId)
                {
                        return cfulDAL.UpdateCustFLogInfoState(fLogId, 0, 0);
                }

                /// <summary>
                /// 删除客户日志信息（真删除）
                /// </summary>
                /// <param name="fLogId"></param>
                /// <returns></returns>
                public bool RemoveCustomerFULog(int fLogId)
                {
                        return cfulDAL.UpdateCustFLogInfoState(fLogId, 1, 2);
                }

                /// <summary>
                /// 批量删除客户日志信息（假删除）
                /// </summary>
                /// <param name="fLogIds"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool LogicDelCustomerFULogList(List<int> fLogIds)
                {
                        return cfulDAL.UpdateCustFLogInfosState(fLogIds, 0, 1);
                }

                /// <summary>
                /// 批量恢复客户日志信息
                /// </summary>
                /// <param name="fLogIds"></param>
                /// <returns></returns>
                public bool RecoverCustomerFULogList(List<int> fLogIds)
                {
                        return cfulDAL.UpdateCustFLogInfosState(fLogIds, 0, 0);
                }

                /// <summary>
                /// 批量删除客户日志信息（真删除）
                /// </summary>
                /// <param name="fLogIds"></param>
                /// <returns></returns>
                public bool RemoveCustomerFULogList(List<int> fLogIds)
                {
                        return cfulDAL.UpdateCustFLogInfosState(fLogIds, 1, 2);
                }

                #endregion

                /// <summary>
                /// 获取指定客户日志信息
                /// </summary>
                /// <param name="fLogId"></param>
                /// <returns></returns>
                public CustomerFollowUpLogInfoModel GetCustomeFULogInfo(int fLogId)
                {
                        return cfulDAL.GetCustomerFLogInfo(fLogId);
                }

                /// <summary>
                /// 获取客户日志列表
                /// </summary>
                /// <returns></returns>
                public List<ViewCustomerFollowUpLogInfoModel> GetCustFLogs(int requestId, string custName, string followUpUser, string requestContent, string fContent, int isDeleted)
                {
                        return vcfuLogDAL.GetCustFLogs(requestId, custName, followUpUser, requestContent, fContent, isDeleted);
                }

                /// <summary>
                /// 指定的需求列表中是否包含已成交的需求
                /// </summary>
                /// <param name="custRequestIds"></param>
                /// <returns></returns>
                public bool IsSuccessCustRequest(List<int> custRequestIds)
                {
                        return cfulDAL.GetFULogCountByCustIdAndFUState(custRequestIds, FUState.成交) > 0;
                }

                /// <summary>
                /// 指定的需求是否是已成交的需求
                /// </summary>
                /// <param name="custRequestId"></param>
                /// <returns></returns>
                public bool IsSuccessCustRequest(int custRequestId)
                {
                        List<int> custRequestIds = new List<int>();
                        custRequestIds.Add(custRequestId);
                        return cfulDAL.GetFULogCountByCustIdAndFUState(custRequestIds, FUState.成交) > 0;
                }

                /// <summary>
                /// 判断当前选择的日志是否存在跟进中或成交的日志
                /// </summary>
                /// <param name="selList"></param>
                /// <returns></returns>
                public bool IsUseOrSuccessLog(List<ViewCustomerFollowUpLogInfoModel> selList)
                {
                        if (selList != null && selList.Count > 0)
                        {
                                foreach (ViewCustomerFollowUpLogInfoModel flog in selList)
                                {
                                        if (flog.FollowUpState == FUState.跟进中.ToString() || flog.FollowUpState == FUState.成交.ToString())
                                                return true;
                                }
                        }
                        return false;
                }

                /// <summary>
                /// 获取所有的跟进状态集合
                /// </summary>
                /// <returns></returns>
                public List<string> GetFUStates()
                {
                        List<string> list = new List<string>();
                        foreach (string val in Enum.GetNames(typeof(FUState)))
                        {
                                list.Add(val);
                        }
                        return list;
                }
        }
}
