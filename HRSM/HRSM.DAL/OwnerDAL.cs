using DBUtility;
using HRSM.Common;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL
{
        public class OwnerDAL : BaseDAL<HouseOwnerInfoModel>
        {
                /// <summary>
                /// 添加业主信息
                /// </summary>
                /// <param name="ownerInfo"></param>
                /// <returns></returns>
                public bool AddOwnerInfo(HouseOwnerInfoModel ownerInfo)
                {
                        string cols = "OwnerName,OwnerType,Contactor,OwnerPhone,OwnerPhone,OwnerAddress,Remark";
                        return Add(ownerInfo, cols, 0) > 0;
                }

                /// <summary>
                /// 批量导入业主数据
                /// </summary>
                /// <param name="dtInfos"></param>
                /// <returns></returns>
                public bool AddOwnerInfos(DataTable dt)
                {
                        string cols = "OwnerName,OwnerType,Contactor,OwnerPhone,OwnerAddress,Remark";
                        foreach (DataColumn dc in dt.Columns)
                        {
                                dc.ColumnName = GetDtColumnName(dc.ColumnName);
                        }
                        List<HouseOwnerInfoModel> ownerList = DbConvert.DataTableToList<HouseOwnerInfoModel>(dt, cols);
                        if (ownerList.Count > 0)
                        {
                                List<CommandInfo> list = new List<CommandInfo>();
                                foreach (HouseOwnerInfoModel owner in ownerList)
                                {
                                        if(!Exists(owner.OwnerName,owner.OwnerPhone))
                                        {
                                                SqlModel insert = CreateSql.GetInsertSqlAndParas(owner, cols, 0);
                                                list.Add(new CommandInfo()
                                                {
                                                        CommandText = insert.Sql,
                                                        IsProc = false,
                                                        Paras = insert.Paras
                                                });
                                        }
                                       
                                }
                                return SqlHelper.ExecuteTrans(list);
                        }
                        return false;
                }
                /// <summary>
                /// 获取对应的列名
                /// </summary>
                /// <param name="zwStr"></param>
                /// <returns></returns>
                private string GetDtColumnName(string zwStr)
                {
                        string reName = "";
                        switch (zwStr)
                        {
                                case "业主名": reName = "OwnerName"; break;
                                case "类型": reName = "OwnerType"; break;
                                case "联系人": reName = "Contactor"; break;
                                case "联系电话": reName = "OwnerPhone"; break;
                                case "业主地址": reName = "OwnerAddress"; break;
                                case "备注": reName = "Remark"; break;
                        }
                        return reName;
                }
                /// <summary>
                /// 修改业主信息
                /// </summary>
                /// <param name="ownerInfo"></param>
                /// <returns></returns>
                public bool UpdateOwnerInfo(HouseOwnerInfoModel ownerInfo)
                {
                        string cols = "OwnerId,OwnerName,OwnerType,Contactor,OwnerPhone,OwnerAddress,Remark";
                        return Update(ownerInfo, cols, "");
                }

                /// <summary>
                /// 修改业主信息(并连同关系数据)的删除状态（真删除即为删除操作）
                /// </summary>
                /// <param name="ownerId"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool UpdateOwnerInfoState(int ownerId, int delType, int isDeleted)
                {
                        List<string> sqlList = new List<string>();
                        string[] tableNames = { "HouseOwnerInfos", "HouseInfos", "HouseTradeInfos" };
                        sqlList = GetDeleteSql(delType, ownerId, isDeleted, tableNames);
                        return SqlHelper.ExecuteTrans(sqlList);
                }

                /// <summary>
                /// 批量 修改业主信息(并连同关系数据)的删除状态（真删除即为删除操作）
                /// </summary>
                /// <param name="ownerIds"></param>
                /// <param name="delType"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public bool UpdateOwnersState(List<int> ownerIds, int delType, int isDeleted)
                {
                        List<string> sqlList = new List<string>();
                        string[] tableNames = { "HouseOwnerInfos", "HouseInfos", "HouseTradeInfos" };
                        sqlList = GetDeleteListSql(delType, ownerIds, isDeleted, tableNames);
                        return SqlHelper.ExecuteTrans(sqlList);
                }



                /// <summary>
                /// 获取指定业主信息
                /// </summary>
                /// <param name="ownerId"></param>
                /// <returns></returns>
                public HouseOwnerInfoModel GetOwnerInfo(int ownerId)
                {
                        string cols = "OwnerId,OwnerName,OwnerType,Contactor,OwnerPhone,OwnerAddress,Remark";
                        return GetById(ownerId, cols);
                }

                /// <summary>
                /// 判断业主是否已存在
                /// </summary>
                /// <param name="ownerName"></param>
                /// <param name="ownerPhone"></param>
                /// <returns></returns>
                public bool Exists(string ownerName, string ownerPhone)
                {
                        SqlParameter[] paras =
                        {
                new SqlParameter("@ownerName",ownerName),
                new SqlParameter("@ownerPhone",ownerPhone)
            };
                        return Exists("OwnerName=@ownerName and OwnerPhone=@ownerPhone and IsDeleted=0", paras);
                }

                /// <summary>
                /// 条件查询业主信息列表
                /// </summary>
                /// <param name="keywords"></param>
                /// <param name="ownerType"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<HouseOwnerInfoModel> GetOwnerList(string keywords, string ownerType, int isDeleted)
                {
                        string cols = "OwnerId,OwnerName,OwnerType,Contactor,OwnerPhone,OwnerAddress,CreateTime";
                        string strWhere = $"IsDeleted={isDeleted}";
                        List<SqlParameter> listParas = new List<SqlParameter>();
                        if (!string.IsNullOrEmpty(keywords))
                        {
                                strWhere += " and (OwnerName like @keywords or Contactor like @keywords or OwnerPhone like @keywords or OwnerAddress like @keywords)";
                                listParas.Add(new SqlParameter("@keywords", $"%{keywords}%"));
                        }
                        if (!string.IsNullOrEmpty(ownerType))
                        {
                                strWhere += " and OwnerType=@ownerType";
                                listParas.Add(new SqlParameter("@ownerType", ownerType));
                        }
                        return GetRowsModelList(strWhere, cols, listParas.ToArray());
                }



                /// <summary>
                /// 获取所有业主列表（未删除的），用于绑定下拉框
                /// </summary>
                /// <returns></returns>
                public List<HouseOwnerInfoModel> GetAllOwners()
                {
                        string cols = "OwnerId,OwnerName";
                        return GetModelList(cols, 0);
                }




        }
}
