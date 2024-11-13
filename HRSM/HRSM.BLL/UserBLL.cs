using HRSM.DAL;
using HRSM.DAL.VDAL;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.BLL
{
        /// <summary>
        /// 用户业务逻辑类
        /// </summary>
        public class UserBLL : BaseBLL<UserInfoModel>
        {
                ViewUserRoleInfoDAL vurDAL = new ViewUserRoleInfoDAL();
                UserDAL userDAL = new UserDAL();
                /// <summary>
                /// 添加用户信息
                /// </summary>
                /// <param name="userInfo"></param>
                /// <param name="urList">角色设置列表</param>
                /// <returns></returns>
                public bool AddUserInfo(UserInfoModel userInfo, List<UserRoleInfoModel> urList)
                {
                        if (urList != null && urList.Count > 0)
                                return userDAL.AddUserInfo(userInfo, urList);
                        else
                                return userDAL.AddUserInfo(userInfo);
                }

                /// <summary>
                /// 修改用户信息和用户角色关系
                /// </summary>
                /// <param name="userInfo"></param>
                /// <param name="urList">当前的角色设置列表</param>
                /// <param name="urListNew">新增角色设置列表</param>
                /// <returns></returns>
                public bool UpdateUserInfo(UserInfoModel userInfo, List<UserRoleInfoModel> urList, List<UserRoleInfoModel> urListNew)
                {
                        if (urList != null && urList.Count > 0)
                                return userDAL.UpdateUserInfo(userInfo, urList, urListNew);
                        else
                                return userDAL.UpdateUserInfo(userInfo);

                }

                #region 删除与恢复
                /// <summary>
                /// 删除用户信息（假删除）
                /// </summary>
                /// <param name="userId"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool LogicDelUser(int userId)
                {
                        return userDAL.UpdateUserInfoState(userId, 0, 1);
                }

                /// <summary>
                /// 恢复用户信息
                /// </summary>
                /// <param name="userId"></param>
                /// <returns></returns>
                public bool RecoverUser(int userId)
                {
                        return userDAL.UpdateUserInfoState(userId, 0, 0);
                }

                /// <summary>
                /// 删除用户信息（真删除）
                /// </summary>
                /// <param name="userId"></param>
                /// <returns></returns>
                public bool RemoveUser(int userId)
                {
                        return userDAL.UpdateUserInfoState(userId, 1, 2);
                }

                /// <summary>
                /// 删除多个用户信息（假删除）
                /// </summary>
                /// <param name="userId"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool LogicDelUserList(List<int> userIds)
                {
                        return userDAL.UpdateUsersState(userIds, 0, 1);
                }

                /// <summary>
                /// 恢复多个用户信息
                /// </summary>
                /// <param name="userId"></param>
                /// <returns></returns>
                public bool RecoverUserList(List<int> userIds)
                {
                        return userDAL.UpdateUsersState(userIds, 0, 0);
                }

                /// <summary>
                /// 删除多个用户信息（真删除）
                /// </summary>
                /// <param name="userId"></param>
                /// <returns></returns>
                public bool RemoveUserList(List<int> userIds)
                {
                        return userDAL.UpdateUsersState(userIds, 1, 2);
                }
                #endregion

                /// <summary>
                /// 获取指定id的用户信息(基本信息和角色设置)
                /// </summary>
                /// <param name="roleId"></param>
                /// <returns></returns>
                public UserRoleListModel GetUserRoleListInfo(int userId)
                {
                        UserRoleListModel userInfo = default(UserRoleListModel);
                        List<ViewUserRoleInfoModel> urList = vurDAL.GetUserRoleList(userId);
                        dynamic uInfo = null;
                        if (urList.Count > 0)
                        {
                                userInfo = new UserRoleListModel();
                                userInfo.RoleIds = urList.Select(ur => ur.RoleId).ToList();
                                userInfo.UserId = userId;
                                uInfo = urList[0];
                        }
                        else
                        {
                                userInfo = new UserRoleListModel();
                                userInfo.RoleIds = null;
                                userInfo.UserId = userId;
                                uInfo = userDAL.GetUserInfo(userId);

                        }
                        if (uInfo != null)
                        {
                                userInfo.UserName = uInfo.UserName;
                                userInfo.UserFName = uInfo.UserFName;
                                userInfo.UserState = uInfo.UserState;
                                userInfo.UserPhone = uInfo.UserPhone;
                                userInfo.UserPwd = uInfo.UserPwd;
                        }


                        return userInfo;
                }

                /// <summary>
                /// 判断用户名称是否已存在
                /// </summary>
                /// <param name="userName"></param>
                /// <returns></returns>
                public bool Exists(string userName)
                {
                        return userDAL.Exists(userName);
                }

                /// <summary>
                /// 获取用户列表信息
                /// </summary>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<UserInfoModel> GetUserList(string keywords, int userState, int isDeleted)
                {
                        return userDAL.GetUserList(keywords, userState, isDeleted);
                }

                /// <summary>
                /// 获取指定用户的角色编号集合
                /// </summary>
                /// <param name="userId"></param>
                /// <returns></returns>
                public List<int> GetUserRoleIds(int userId)
                {
                        return vurDAL.GetUserRoleIds(userId);
                }

                /// <summary>
                /// 用户登录
                /// </summary>
                /// <param name="userInfo"></param>
                /// <returns>状态正常返回Id  冻结 -1  用户名密码错误 0</returns>
                public int UserLogin(UserInfoModel userInfo)
                {

                        UserInfoModel user = userDAL.UserLogin(userInfo);
                        if (user != null && user.UserId > 0)
                        {
                                if (user.UserState)
                                        return user.UserId;
                                else
                                        return -1;
                        }
                        else
                                return 0;
                }
        }
}
