using DBUtility;
using HRSM.Common;
using HRSM.DAL.VDAL;
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
        public class UserDAL : BaseDAL<UserInfoModel>
        {
                ViewUserRoleInfoDAL vurDAL = new ViewUserRoleInfoDAL();
                /// <summary>
                /// 添加用户信息(没有设置角色时)
                /// </summary>
                /// <param name="userInfo"></param>
                /// <returns></returns>
                public bool AddUserInfo(UserInfoModel userInfo)
                {
                        string cols = "UserName,UserPwd,UserState,UserFName,UserPhone";
                        return Add(userInfo, cols, 0) > 0;
                }
                /// <summary>
                /// 添加用户信息,并设置用户角色
                /// </summary>
                /// <param name="userInfo"></param>
                /// <param name="urList">角色设置列表</param>
                /// <returns></returns>
                public bool AddUserInfo(UserInfoModel userInfo, List<UserRoleInfoModel> urList)
                {
                        string cols = "UserName,UserPwd,UserState,UserFName,UserPhone";
                        return SqlHelper.ExecuteTrans<bool>(cmd =>
                        {
                                try
                                {
                            //添加用户信息
                            SqlModel insert = CreateSql.GetInsertSqlAndParas(userInfo, cols, 1);
                                        SqlHelper.InitIdbCommand(cmd, insert.Sql, 1, insert.Paras);
                                        object oId = cmd.ExecuteScalar();
                                        cmd.Parameters.Clear();
                                        int userId = oId.GetInt();
                                        if (userId > 0)//如果添加用户成功,则添加用户角色设置
                            {
                                                string urCols = "UserId,RoleId";
                                                foreach (var ur in urList)
                                                {
                                                        ur.UserId = userId;
                                                        SqlModel inUR = CreateSql.GetInsertSqlAndParas<UserRoleInfoModel>(ur, urCols, 0);
                                                        SqlHelper.InitIdbCommand(cmd, inUR.Sql, 1, inUR.Paras);
                                                        cmd.ExecuteNonQuery();
                                                }
                                        }
                                        cmd.Transaction.Commit();
                                        return true;
                                }
                                catch (Exception ex)
                                {
                                        cmd.Transaction.Rollback();
                                        throw new Exception("添加用户信息执行事务异常！", ex);
                                }
                                finally
                                {
                                        cmd.Connection.Close();
                                }
                        });

                }

                /// <summary>
                /// 修改用户信息(没有修改角色设置时)
                /// </summary>
                /// <param name="userInfo"></param>
                /// <returns></returns>
                public bool UpdateUserInfo(UserInfoModel userInfo)
                {
                        string cols = "UserId,UserName";
                        if (!string.IsNullOrEmpty(userInfo.UserPwd))
                                cols += ",UserPwd";
                        cols += ",UserState,UserFName,UserPhone";
                        return Update(userInfo, cols, "");
                }

                /// <summary>
                /// 修改用户信息和用户角色关系
                /// </summary>
                /// <param name="userInfo"></param>
                /// <param name="urList">当前的角色设置列表</param>
                /// <param name="urListNew">相对角色设置列表</param>
                /// <returns></returns>
                public bool UpdateUserInfo(UserInfoModel userInfo, List<UserRoleInfoModel> urList, List<UserRoleInfoModel> urListNew)
                {
                        string cols = "UserId,UserName";
                        if (!string.IsNullOrEmpty(userInfo.UserPwd))
                                cols += ",UserPwd";
                        cols += ",UserState,UserFName,UserPhone";
                        List<CommandInfo> comList = new List<CommandInfo>();
                        SqlModel upUser = CreateSql.GetUpdateSqlAndParas(userInfo, cols, "");
                        //修改用户信息
                        comList.Add(new CommandInfo()
                        {
                                CommandText = upUser.Sql,
                                IsProc = false,
                                Paras = upUser.Paras
                        });
                        if (urList != null && urList.Count > 0)//当前的角色列表
                        {
                                //删除取消的角色关系数据
                                string roleIds = string.Join(",", urList.Select(ur => ur.RoleId));
                                comList.Add(new CommandInfo()
                                {
                                        CommandText = $"delete from UserRoleInfos where RoleId not in ({roleIds}) and UserId={userInfo.UserId}",
                                        IsProc = false
                                });
                        }
                        if (urListNew.Count > 0)//如果存在新加的角色
                        {
                                //新增新设置的角色关系  
                                string colsUserRole = "UserId,RoleId";
                                foreach (var ur in urListNew)
                                {
                                        SqlModel inUserRole = CreateSql.GetInsertSqlAndParas<UserRoleInfoModel>(ur, colsUserRole, 0);
                                        comList.Add(new CommandInfo()
                                        {
                                                CommandText = inUserRole.Sql,
                                                IsProc = false,
                                                Paras = inUserRole.Paras
                                        });
                                }
                        }
                        return SqlHelper.ExecuteTrans(comList);
                }

                /// <summary>
                /// 修改用户信息(并连同关系数据)的删除状态（真删除即为删除操作）
                /// </summary>
                /// <param name="userId"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool UpdateUserInfoState(int userId, int delType, int isDeleted)
                {
                        string[] tableNames = { "UserInfos", "UserRoleInfos" };
                        List<string> sqlList = GetDeleteSql(delType, userId, isDeleted, tableNames);
                        return SqlHelper.ExecuteTrans(sqlList);
                }

                /// <summary>
                /// 批量 修改用户信息(并连同关系数据)的删除状态（真删除即为删除操作）
                /// </summary>
                /// <param name="userIds"></param>
                /// <param name="delType"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public bool UpdateUsersState(List<int> userIds, int delType, int isDeleted)
                {
                        List<string> sqlList = new List<string>();
                        string[] tableNames = { "UserInfos", "UserRoleInfos" };
                        sqlList = GetDeleteListSql(delType, userIds, isDeleted, tableNames);
                        return SqlHelper.ExecuteTrans(sqlList);
                }

                /// <summary>
                /// 获取指定 用户信息
                /// </summary>
                /// <param name="userId"></param>
                /// <returns></returns>
                public UserInfoModel GetUserInfo(int userId)
                {
                        string cols = "UserId,UserName,UserState,UserPhone,UserFName";
                        return GetById(userId, cols);
                }

                /// <summary>
                /// 判断用户名是否已存在
                /// </summary>
                /// <param name="userName"></param>
                /// <returns></returns>
                public bool Exists(string userName)
                {
                        return ExistsByName("UserName", userName);
                }



                /// <summary>
                /// 获取用户列表信息
                /// </summary>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<UserInfoModel> GetUserList(string keywords, int userState, int isDeleted)
                {
                        string cols = "UserId,UserName,UserState,UserFName,UserPhone";
                        string strWhere = $"IsDeleted={isDeleted} and UserState={userState}";
                        if (!string.IsNullOrEmpty(keywords))
                        {
                                strWhere += " and (UserName like @keywords or UserFName like @keywords)";
                                SqlParameter paraKeywords = new SqlParameter("keywords", $"%{keywords}%");
                                return GetRowsModelList(strWhere, cols, paraKeywords);
                        }
                        return GetRowsModelList(strWhere, cols);
                }

                /// <summary>
                /// 用户登录
                /// </summary>
                /// <param name="userInfo"></param>
                /// <returns>用户实体信息: 用户编号和状态</returns>
                public UserInfoModel UserLogin(UserInfoModel userInfo)
                {
                        string strWhere = "UserName=@userName and UserPwd=@userPwd and IsDeleted=0";
                        SqlParameter[] paras =
                        {
                                new SqlParameter("@userName",userInfo.UserName),
                                new SqlParameter("@userPwd",userInfo.UserPwd)
                        };
                        UserInfoModel user = GetModel(strWhere, "UserId,UserState", paras);
                        return user;
                }
        }
}
