using HRSM.DAL;
using HRSM.Models.DModels;
using HRSM.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HRSM.DAL.CustomerDAL;

namespace HRSM.BLL
{
        public class CustomerBLL
        {
                private CustomerDAL customerDAL = new CustomerDAL();
                private HouseTradeDAL htDAL = new HouseTradeDAL();

                /// <summary>
                /// 添加客户信息
                /// </summary>
                /// <param name="custInfo"></param>
                /// <returns></returns>
                public bool AddCustomerInfo(CustomerInfoModel custInfo)
                {
                        return customerDAL.AddCustomerInfo(custInfo);
                }

                /// <summary>
                /// 修改客户信息
                /// </summary>
                /// <param name="custInfo"></param>
                /// <returns></returns>
                public bool UpdateCustomerInfo(CustomerInfoModel custInfo)
                {
                        return customerDAL.UpdateCustomerInfo(custInfo);
                }

                #region 删除与恢复
                /// <summary>
                /// 删除客户信息（假删除）
                /// </summary>
                /// <param name="custId"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool LogicDelCustomer(int custId)
                {
                        return customerDAL.UpdateCustomerInfoState(custId, 0, 1);

                }

                /// <summary>
                /// 恢复客户信息
                /// </summary>
                /// <param name="custId"></param>
                /// <returns></returns>
                public bool RecoverCustomer(int custId)
                {
                        return customerDAL.UpdateCustomerInfoState(custId, 0, 0);
                }

                /// <summary>
                /// 删除客户信息（真删除）
                /// </summary>
                /// <param name="custId"></param>
                /// <returns></returns>
                public bool RemoveCustomer(int custId)
                {
                        return customerDAL.UpdateCustomerInfoState(custId, 1, 2);
                }

                /// <summary>
                /// 批量删除客户信息（假删除）
                /// </summary>
                /// <param name="custIds"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool LogicDelCustomerList(List<int> custIds)
                {
                        return customerDAL.UpdateCustomersState(custIds, 0, 1);
                }

                /// <summary>
                /// 批量恢复客户信息
                /// </summary>
                /// <param name="custIds"></param>
                /// <returns></returns>
                public bool RecoverCustomerList(List<int> custIds)
                {
                        return customerDAL.UpdateCustomersState(custIds, 0, 0);
                }

                /// <summary>
                /// 批量删除客户信息（真删除）
                /// </summary>
                /// <param name="custIds"></param>
                /// <returns></returns>
                public bool RemoveCustomerList(List<int> custIds)
                {
                        return customerDAL.UpdateCustomersState(custIds, 1, 2);
                }


                #endregion


                /// <summary>
                /// 获取指定id的客户信息
                /// </summary>
                /// <param name="houseId"></param>
                /// <returns></returns>
                public CustomerInfoModel GetCustomerInfo(int custId)
                {
                        return customerDAL.GetCustomerInfo(custId);
                }

                /// <summary>
                /// 判断客户是否已存在
                /// </summary>
                /// <param name="custName"></param>
                /// <returns></returns>
                public bool Exists(string custName, string phone)
                {
                        return customerDAL.Exists(custName, phone);
                }
                public bool Exists(string custName)
                {
                        return customerDAL.Exists(custName);
                }

                /// <summary>
                /// 条件查询客户列表
                /// </summary>
                /// <param name="keywords"></param>
                /// <param name="custType"></param>
                /// <param name="custState"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<CustomerInfoModel> GetCustList(string keywords, string custType, string custState, int isDeleted)
                {
                        return customerDAL.GetCustList(keywords, custType, custState, isDeleted);
                }

                /// <summary>
                /// 获取所有的普通客户列表
                /// </summary>
                /// <returns></returns>
                public List<CboCustomerInfoModel> GetCustomers(int actType)
                {
                        List<CustomerInfoModel> list = new List<CustomerInfoModel>();
                        if (actType == 1)
                                list = customerDAL.GetAllCustomers(CustState.普通客户.ToString());
                        else
                                list = customerDAL.GetAllCustomers("");
                        IEnumerable<CboCustomerInfoModel> reList = list.Select(c => new CboCustomerInfoModel()
                        {
                                CustomerId = c.CustomerId,
                                CustomerName = c.CustomerName,
                                CustomerPhone = c.CustomerPhone
                        });

                        return reList.ToList();
                }

                /// <summary>
                /// 获取所有客户列表
                /// </summary>
                /// <returns></returns>
                public List<CustomerInfoModel> GetAllCustomers()
                {
                        return customerDAL.GetAllCustomers("");
                }

                /// <summary>
                /// 获取所有的意向客户
                /// </summary>
                /// <returns></returns>
                public List<CustomerInfoModel> GetIntentedCustomers()
                {
                        return customerDAL.GetAllCustomers(CustState.意向客户.ToString());
                }

                /// <summary>
                /// 指定客户是否是意向客户
                /// </summary>
                /// <param name="custId"></param>
                /// <returns></returns>
                public bool IsIntendedCustomer(int custId)
                {
                        List<int> custIds = new List<int>();
                        custIds.Add(custId);
                        return IsIntendedCustomer(custIds);
                }

                /// <summary>
                /// 指定客户列表中是否包含意向客户
                /// </summary>
                /// <param name="custIds"></param>
                /// <returns></returns>
                public bool IsIntendedCustomer(List<int> custIds)
                {
                        return customerDAL.GetCustCountByState(custIds, CustState.意向客户) > 0;
                }

                /// <summary>
                /// 判断指定客户是否是已交易客户
                /// </summary>
                /// <param name="custId"></param>
                /// <returns></returns>
                public bool IsTradeCustomer(int custId)
                {
                        List<int> custIds = new List<int>();
                        custIds.Add(custId);
                        return IsTradeCustomer(custIds);
                }

                /// <summary>
                /// 判断指定客户列表中是否包含已交易客户
                /// </summary>
                /// <param name="custIds"></param>
                /// <returns></returns>
                public bool IsTradeCustomer(List<int> custIds)
                {
                        return htDAL.GetTradeCustomerCount(custIds) > 0;
                }







        }
}
