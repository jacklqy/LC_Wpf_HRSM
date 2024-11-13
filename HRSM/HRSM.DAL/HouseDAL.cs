using DBUtility;
using HRSM.Common;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL
{
        public class HouseDAL : BaseDAL<HouseInfoModel>
        {
                /// <summary>
                /// 添加房屋信息
                /// </summary>
                /// <param name="houseInfo"></param>
                /// <returns></returns>
                public bool AddHouseInfo(HouseInfoModel houseInfo)
                {
                        string cols = "HouseName,Building,HouseAddress,RentSale,HousePrice,PriceUnit,HouseDirection,HouseLayout,OwnerId,HouseFloor,HouseArea,HouseState,Remark,IsPublish";
                        if (houseInfo.PublishTime != null)
                                cols += ",PublishTime";
                        if (!string.IsNullOrEmpty(houseInfo.PublishUser))
                                cols += ",PublishUser";
                        if (!string.IsNullOrEmpty(houseInfo.HousePic))
                                cols += ",HousePic";
                        return Add(houseInfo, cols, 0) > 0;
                }

                /// <summary>
                /// 批量导入房屋数据
                /// </summary>
                /// <param name="dtInfos"></param>
                /// <returns></returns>
                public bool AddHouseInfos(DataTable dt)
                {
                        string cols = "HouseName,Building,HouseAddress,RentSale,HousePrice,PriceUnit,HouseDirection,HouseLayout,OwnerId,HouseFloor,HouseArea,HouseState,Remark";
                        foreach (DataColumn dc in dt.Columns)
                        {
                                dc.ColumnName = GetDtColumnName(dc.ColumnName);
                        }
                        dt.Columns.Add("OwnerId", typeof(int));
                        dt.Columns.Add("HouseState", typeof(string));
                        OwnerDAL ownerDAL = new OwnerDAL();
                        foreach (DataRow dr in dt.Rows)
                        {
                                SqlParameter[] paras0 =
                                   {
                        new SqlParameter("@ownerName",dr["OwnerName"].ToString()),
                        new SqlParameter("@ownerPhone",dr["OwnerPhone"].ToString())
                    };
                                int ownerId = 0;
                                HouseOwnerInfoModel owner = ownerDAL.GetModel("OwnerName=@ownerName and OwnerPhone=@ownerPhone", "OwnerId", paras0);
                                if (owner != null)
                                        ownerId = owner.OwnerId;
                                dr["OwnerId"] = ownerId;
                                if (dr["RentSale"].ToString() == "出租")
                                        dr["HouseState"] = "未出租";
                                else
                                        dr["HouseState"] = "未出售";
                        }
                        List<HouseInfoModel> houseList = DbConvert.DataTableToList<HouseInfoModel>(dt, cols);
                        if (houseList.Count > 0)
                        {
                                List<CommandInfo> list = new List<CommandInfo>();
                                foreach (HouseInfoModel house in houseList)
                                {
                                        if (!Exists(house.HouseName))
                                        {
                                                SqlModel insert = CreateSql.GetInsertSqlAndParas(house, cols, 0);
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
                                case "房屋名称": reName = "HouseName"; break;
                                case "所属楼宇": reName = "Building"; break;
                                case "房屋地址": reName = "HouseAddress"; break;
                                case "租售类别": reName = "RentSale"; break;
                                case "价格": reName = "HousePrice"; break;
                                case "单位": reName = "PriceUnit"; break;
                                case "朝向": reName = "HouseDirection"; break;
                                case "户型": reName = "HouseLayout"; break;
                                case "业主": reName = "OwnerName"; break;
                                case "电话": reName = "OwnerPhone"; break;
                                case "楼层": reName = "HouseFloor"; break;
                                case "面积": reName = "HouseArea"; break;
                                case "备注": reName = "Remark"; break;
                        }
                        return reName;
                }
                /// <summary>
                /// 修改房屋信息
                /// </summary>
                /// <param name="houseInfo"></param>
                /// <returns></returns>
                public bool UpdateHouseInfo(HouseInfoModel houseInfo)
                {
                        string cols = "HouseId,HouseName,Building,HouseAddress,RentSale,HousePrice,PriceUnit,HouseDirection,HouseLayout,OwnerId,HouseFloor,HouseArea,HouseState,Remark,IsPublish";
                        if (houseInfo.PublishTime != null)
                                cols += ",PublishTime";
                        if (!string.IsNullOrEmpty(houseInfo.PublishUser))
                                cols += ",PublishUser";
                        if (!string.IsNullOrEmpty(houseInfo.HousePic))
                                cols += ",HousePic";
                        return Update(houseInfo, cols, "");
                }

                /// <summary>
                /// 修改房屋信息(并连同关系数据)的删除状态（真删除即为删除操作）
                /// </summary>
                /// <param name="houseId"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool UpdateHouseInfoState(int houseId, int delType, int isDeleted)
                {
                        List<string> sqlList = new List<string>();
                        string[] tableNames = { "HouseInfos" };
                        sqlList = GetDeleteSql(delType, houseId, isDeleted, tableNames);
                        return SqlHelper.ExecuteTrans(sqlList);
                }

                /// <summary>
                /// 批量 修改房屋信息(并连同关系数据)的删除状态（真删除即为删除操作）
                /// </summary>
                /// <param name="houseIds"></param>
                /// <param name="delType"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public bool UpdateHousesState(List<int> houseIds, int delType, int isDeleted)
                {
                        List<string> sqlList = new List<string>();
                        string[] tableNames = { "HouseInfos" };
                        sqlList = GetDeleteListSql(delType, houseIds, isDeleted, tableNames);
                        return SqlHelper.ExecuteTrans(sqlList);
                }

                /// <summary>
                /// 修改房屋发布状态
                /// </summary>
                /// <param name="houseIds"></param>
                /// <param name="isPublish"></param>
                /// <param name="loginUser"></param>
                /// <returns></returns>
                public bool UpdateHousePublishState(List<int> houseIds, int isPublish, string loginUser)
                {
                        string strIds = string.Join(",", houseIds);
                        string sql = $"update HouseInfos set IsPublish={isPublish},PublishTime=@publishTime,PublishUser=@publishUser where HouseId in ({strIds})";
                        SqlParameter[] paras = {
                new SqlParameter("@publishTime",DateTime.Now),
                new SqlParameter("@publishUser",loginUser)
            };
                        if (isPublish == 0)
                        {
                                paras[0].Value = DBNull.Value;
                                paras[1].Value = DBNull.Value;
                        }

                        List<CommandInfo> sqlList = new List<CommandInfo>();
                        sqlList.Add(new CommandInfo()
                        {
                                CommandText = sql,
                                IsProc = false,
                                Paras = paras
                        });
                        return SqlHelper.ExecuteTrans(sqlList);
                }



                /// <summary>
                /// 获取指定房屋信息
                /// </summary>
                /// <param name="houseId"></param>
                /// <returns></returns>
                public HouseInfoModel GetHouseInfo(int houseId)
                {
                        string cols = "HouseId,HouseName,Building,HouseAddress,RentSale,HousePrice,PriceUnit,HouseDirection,HouseLayout,OwnerId,HouseFloor,HouseArea,HouseState,Remark,HousePic,IsPublish,PublishTime,PublishUser,CreateTime";
                        return GetById(houseId, cols);
                }

                /// <summary>
                /// 判断房屋是否已存在
                /// </summary>
                /// <param name="houseName"></param>
                /// <returns></returns>
                public bool Exists(string houseName)
                {
                        SqlParameter[] paras =
                        {
                new SqlParameter("@houseName",houseName)
            };
                        return Exists("HouseName=@houseName and IsDeleted=0", paras);
                }


                /// <summary>
                /// 获取所有房屋列表（未删除的），用于绑定下拉框
                /// </summary>
                /// <returns></returns>
                public List<HouseInfoModel> GetAllHouses()
                {
                        string cols = "HouseId,HouseName";
                        return GetModelList(cols, 0);
                }

                /// <summary>
                /// 获取已发布的房屋数
                /// </summary>
                /// <returns></returns>
                public int GetPublishHouses()
                {
                        string sql = "select count(1) from HouseInfos where IsPublish=1";
                        object o = SqlHelper.ExecuteScalar(sql, 1);
                        if (o != null && o.ToString() != "")
                                return o.GetInt();
                        else
                                return 0;
                }

                /// <summary>
                /// 获取指定的房屋编号集合中的已发布房屋数
                /// </summary>
                /// <param name="houseIds"></param>
                /// <returns></returns>
                public int GetHousePublished(List<int> houseIds)
                {
                        string strIds = string.Join(",", houseIds);
                        string sql = $"select count(1) from HouseInfos where IsPublish=1 and HouseId in ({strIds})";
                        object o = SqlHelper.ExecuteScalar(sql, 1);
                        if (o != null && o.ToString() != "")
                                return o.GetInt();
                        else
                                return 0;
                }

        }
}
