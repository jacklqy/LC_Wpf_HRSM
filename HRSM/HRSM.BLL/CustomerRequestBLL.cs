using HRSM.DAL;
using HRSM.DAL.VDAL;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HRSM.DAL.CustomerRequestDAL;

namespace HRSM.BLL
{
        public class CustomerRequestBLL
        {
                private CustomerRequestDAL custRequestDAL = new CustomerRequestDAL();
                private ViewCustomerRequestDAL vcrDAL = new ViewCustomerRequestDAL();

                /// <summary>
                /// 添加客户需求信息
                /// </summary>
                /// <param name="custRequestInfo"></param>
                /// <returns></returns>
                public bool AddCustomerRequestInfo(CustomerRequestInfoModel custRequestInfo)
                {
                        return custRequestDAL.AddCustomerRequestInfo(custRequestInfo);
                }

                /// <summary>
                /// 修改客户需求信息
                /// </summary>
                /// <param name="custRequestInfo"></param>
                /// <returns></returns>
                public bool UpdateCustomerRequestInfo(CustomerRequestInfoModel custRequestInfo)
                {
                        return custRequestDAL.UpdateCustomerRequestInfo(custRequestInfo);
                }

                #region 删除与恢复
                /// <summary>
                /// 删除客户需求信息（假删除）
                /// </summary>
                /// <param name="custRequestId"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool LogicDelCustomerRequest(int custRequestId)
                {
                        return custRequestDAL.UpdateCustomerRequestInfoState(custRequestId, 0, 1);

                }

                /// <summary>
                /// 恢复客户需求信息
                /// </summary>
                /// <param name="custRequestId"></param>
                /// <returns></returns>
                public bool RecoverCustomerRequest(int custRequestId)
                {
                        return custRequestDAL.UpdateCustomerRequestInfoState(custRequestId, 0, 0);
                }

                /// <summary>
                /// 删除客户需求信息（真删除）
                /// </summary>
                /// <param name="custRequestId"></param>
                /// <returns></returns>
                public bool RemoveCustomerRequest(int custRequestId)
                {
                        return custRequestDAL.UpdateCustomerRequestInfoState(custRequestId, 1, 2);
                }

                /// <summary>
                /// 批量删除客户需求信息（假删除）
                /// </summary>
                /// <param name="custRequestIds"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool LogicDelCustomerRequestList(List<int> custRequestIds)
                {
                        return custRequestDAL.UpdateCustomerRequestsState(custRequestIds, 0, 1);
                }

                /// <summary>
                /// 批量恢复客户需求信息
                /// </summary>
                /// <param name="custRequestIds"></param>
                /// <returns></returns>
                public bool RecoverCustomerRequestList(List<int> custRequestIds)
                {
                        return custRequestDAL.UpdateCustomerRequestsState(custRequestIds, 0, 0);
                }

                /// <summary>
                /// 批量删除客户需求信息（真删除）
                /// </summary>
                /// <param name="custRequestIds"></param>
                /// <returns></returns>
                public bool RemoveCustomerRequestList(List<int> custRequestIds)
                {
                        return custRequestDAL.UpdateCustomerRequestsState(custRequestIds, 1, 2);
                }

                #endregion

                /// <summary>
                /// 获取指定客户需求信息
                /// </summary>
                /// <param name="custId"></param>
                /// <returns></returns>
                public CustomerRequestInfoModel GetCustomerRequestInfo(int custRequestId)
                {
                        return custRequestDAL.GetCustomerRequestInfo(custRequestId);
                }

                /// <summary>
                /// 判断客户需求是否已存在
                /// </summary>
                /// <param name="custName"></param>
                /// <param name="phone"></param>
                /// <returns></returns>
                public bool Exists(string custId, string requestType, string requestContent)
                {
                        return custRequestDAL.Exists(custId, requestContent);
                }

                /// <summary>
                /// 获取客户需求列表
                /// </summary>
                /// <returns></returns>
                public List<ViewCustomerRequestInfoModel> GetCustRequests(int custId, string custName, string followUpUser, string custType, string content, int isDeleted)
                {
                        return vcrDAL.GetCustRequests(custId, custName, custType, followUpUser, content, isDeleted);
                }

                /// <summary>
                /// 获取意向需求列表（用于绑定下拉框）
                /// </summary>
                /// <returns></returns>
                public List<CustomerRequestInfoModel> GetIntentedCustRequests(bool isIntented)
                {
                        return custRequestDAL.GetCustIntentedRequests(isIntented);
                }

                /// <summary>
                /// 指定的需求是否已成交
                /// </summary>
                /// <param name="custRequestId"></param>
                /// <returns></returns>
                public bool IsSuccessRequest(int custRequestId)
                {
                        CustomerRequestInfoModel request = custRequestDAL.GetCustomerRequestInfo(custRequestId);
                        if(request!=null)
                        {
                                if (request.RequestState == "成交")
                                        return true;
                        }
                        return false;
                }
        }
}
