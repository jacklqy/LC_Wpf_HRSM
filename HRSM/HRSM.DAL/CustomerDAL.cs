using DBUtility;
using HRSM.Common;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL
{
        public class CustomerDAL : BaseDAL<CustomerInfoModel>
        {
                /// <summary>
                /// 添加客户信息
                /// </summary>
                /// <param name="houseInfo"></param>
                /// <returns></returns>
                public bool AddCustomerInfo(CustomerInfoModel custInfo)
                {
                        string cols = "CustomerName,CustomerType,Contactor,CustomerPhone,CustomerAddress,Remark,CustomerState";
                        return Add(custInfo, cols, 0) > 0;
                }


                /// <summary>
                /// 修改客户信息
                /// </summary>
                /// <param name="customerInfo"></param>
                /// <returns></returns>
                public bool UpdateCustomerInfo(CustomerInfoModel customerInfo)
                {
                        string cols = "CustomerId,CustomerName,CustomerType,Contactor,CustomerPhone,CustomerAddress,Remark,CustomerState";
                        return Update(customerInfo, cols, "");
                }

                /// <summary>
                /// 修改客户信息(并连同关系数据)的删除状态（真删除即为删除操作）
                /// </summary>
                /// <param name="custId"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool UpdateCustomerInfoState(int custId, int delType, int isDeleted)
                {
                        List<string> sqlList = new List<string>();
                        string[] tableNames = { "CustomerInfos" };
                        sqlList = GetDeleteSql(delType, custId, isDeleted, tableNames);
                        return SqlHelper.ExecuteTrans(sqlList);
                }

                /// <summary>
                /// 批量 修改客户信息(并连同关系数据)的删除状态（真删除即为删除操作）
                /// </summary>
                /// <param name="custIds"></param>
                /// <param name="delType"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public bool UpdateCustomersState(List<int> custIds, int delType, int isDeleted)
                {
                        List<string> sqlList = new List<string>();
                        string[] tableNames = { "CustomerInfos" };
                        sqlList = GetDeleteListSql(delType, custIds, isDeleted, tableNames);
                        return SqlHelper.ExecuteTrans(sqlList);
                }



                /// <summary>
                /// 获取指定客户信息
                /// </summary>
                /// <param name="custId"></param>
                /// <returns></returns>
                public CustomerInfoModel GetCustomerInfo(int custId)
                {
                        string cols = "CustomerId,CustomerName,CustomerType,Contactor,CustomerPhone,CustomerAddress,Remark,CustomerState,CreateTime";
                        return GetById(custId, cols);
                }

                /// <summary>
                /// 获取指定客户列表中的 指定状态的客户数
                /// </summary>
                /// <param name="custIds"></param>
                /// <param name="custState"></param>
                /// <returns></returns>
                public int GetCustCountByState(List<int> custIds, CustState custState)
                {
                        string strIds = string.Join(",", custIds);
                        string sql = $"select count(1) from CustomerInfos where CustomerState=@custState and CustomerId in ({strIds})";
                        SqlParameter paraState = new SqlParameter("@custState", custState.ToString());
                        object o = SqlHelper.ExecuteScalar(sql, 1, paraState);
                        return o.GetInt();

                }

                /// <summary>
                /// 判断客户是否已存在
                /// </summary>
                /// <param name="custName"></param>
                /// <param name="phone"></param>
                /// <returns></returns>
                public bool Exists(string custName, string phone)
                {
                        SqlParameter[] paras =
                        {
                                new SqlParameter("@custName",custName),
                                new SqlParameter("@phone",phone)
                         };
                        return Exists("CustomerName=@custName and CustomerPhone=@phone and IsDeleted=0", paras);
                }

                public bool Exists(string custName)
                {
                        SqlParameter[] paras =
                        {
                              new SqlParameter("@custName",custName)
                        };
                        return Exists("CustomerName=@custName and IsDeleted=0", paras);
                }
                /// <summary>
                /// 获取所有客户列表（未删除的），用于绑定下拉框
                /// </summary>
                /// <returns></returns>
                public List<CustomerInfoModel> GetAllCustomers(string custState)
                {
                        string cols = "CustomerId,CustomerName,CustomerPhone";
                        string strWhere = "IsDeleted=0";
                        if (!string.IsNullOrEmpty(custState))
                                strWhere += $" and CustomerState = '{custState}'";
                        return GetModelList(strWhere, cols);
                }


                /// <summary>
                /// 条件查询客户列表
                /// </summary>
                /// <param name="custName"></param>
                /// <param name="contactorName"></param>
                /// <param name="phone"></param>
                /// <param name="address"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<CustomerInfoModel> GetCustList(string keywords, string custType, string custState, int isDeleted)
                {
                        string cols = "CustomerId,CustomerName,CustomerType,Contactor,CustomerPhone,CustomerAddress,CreateTime,CustomerState";
                        string strWhere = $"IsDeleted={isDeleted}";
                        List<SqlParameter> listParas = new List<SqlParameter>();
                        if (!string.IsNullOrEmpty(keywords))
                        {
                                strWhere += " and (CustomerName like @keywords  or Contactor like @keywords or CustomerAddress  like @keywords or  CustomerPhone like @keywords)";
                                listParas.Add(new SqlParameter("@keywords", $"%{keywords}%"));
                        }
                        if (!string.IsNullOrEmpty(custType))
                        {
                                strWhere += " and CustomerType=@custType";
                                listParas.Add(new SqlParameter("@custType", custType));
                        }
                        if (!string.IsNullOrEmpty(custState))
                        {
                                strWhere += " and CustomerState=@custState";
                                listParas.Add(new SqlParameter("@custState", custState));
                        }
                        return GetRowsModelList(strWhere, cols, listParas.ToArray());
                }

                public enum CustState
                {
                        普通客户,
                        意向客户
                }
        }
}
