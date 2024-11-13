using HRSM.DAL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.BLL
{
    public class RoleBLL:BaseBLL<RoleInfoModel>
    {
        private RoleDAL roleDAL = new RoleDAL();
        private RoleMenuDAL rmDAL = new RoleMenuDAL();
        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool AddRoleInfo(RoleInfoModel roleInfo)
        {
            return roleDAL.AddRoleInfo(roleInfo);
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool UpdateRoleInfo(RoleInfoModel roleInfo)
        {
            return roleDAL.UpdateRoleInfo(roleInfo);
        }

        #region 删除与恢复
        /// <summary>
        /// 删除角色信息（假删除）
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="delType">0-假删除 1-真删除 </param>
        /// <returns></returns>
        public bool LogicDelRole(int roleId)
        {
            return roleDAL.UpdateRoleInfoState(roleId, 0, 1);
        }

        /// <summary>
        /// 恢复角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool RecoverRole(int roleId)
        {
            return roleDAL.UpdateRoleInfoState(roleId, 0, 0);
        }

        /// <summary>
        /// 删除角色信息（真删除）
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool RemoveRole(int roleId)
        {
            return roleDAL.UpdateRoleInfoState(roleId, 1, 2);
        }

        /// <summary>
        /// 删除多个角色信息（假删除）
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="delType">0-假删除 1-真删除 </param>
        /// <returns></returns>
        public bool LogicDelRoles(List<int> roleIds)
        {
            return roleDAL.UpdateRolesState(roleIds, 0, 1);
        }

        /// <summary>
        /// 恢复多个角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool RecoverRoleList(List<int> roleIds)
        {
            return roleDAL.UpdateRolesState(roleIds, 0, 0);
        }

        /// <summary>
        /// 删除多个角色信息（真删除）
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool RemoveRoleList(List<int> roleIds)
        {
            return roleDAL.UpdateRolesState(roleIds, 1, 2);
        }
        #endregion

        /// <summary>
        /// 获取指定id的角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleInfoModel GetRoleInfo(int roleId)
        {
            return roleDAL.GetRoleInfo(roleId);
        }

        /// <summary>
        /// 判断角色名称是否已存在
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool Exists(string roleName)
        {
            return roleDAL.Exists(roleName);
        }

        /// <summary>
        /// 获取所有角色列表（绑定下拉框或列表框）
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetAllRoles()
        {
            return roleDAL.GetAllRoles();
        }

        /// <summary>
        /// 获取角色列表信息（数据列表）
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public List<RoleInfoModel> GetRoleList(int isDeleted)
        {
            return roleDAL.GetRoleList(isDeleted);
        }

        /// <summary>
        /// 判断是否已有用户拥有该角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool  CheckRoleUse(int roleId)
        {
            int userCount = roleDAL.GetRoleUsers(roleId);
            if (userCount > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取指定角色已设置的菜单编号集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<int> GetRoleMenuIds(int roleId)
        {
            return rmDAL.GetRoleMenuIds(roleId);
        }

        /// <summary>
        /// 判断指定角色编号集合中，是否有管理员角色（某个用户所拥有的角色列表）
        /// </summary>
        /// <param name="RoleIds"></param>
        /// <returns></returns>
        public bool IsAdmin(List<int> RoleIds)
        {
            foreach (int roleId in RoleIds)
            {
                if (IsAdmin(roleId))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 判断指定角色是否是管理员
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool IsAdmin(int roleId)
        {
            return roleDAL.GetRoleIsAdmin(roleId);
        }

        /// <summary>
        /// 获取登录者的角色名称
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public string GetRoleNames(List<int> roleIds)
        {
            if(IsAdmin(roleIds))
            {
                return "管理员";
            }
            else
            {
                string names = "";
                foreach(int id in roleIds)
                {
                    if (names != "")
                        names += ",";
                    names += GetRoleInfo(id).RoleName;
                }
                return names;
            }
        }

        /// <summary>
        /// 角色权限设置
        /// </summary>
        /// <param name="rmInfos"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool SaveRoleRightSet(List<int> menuIds, int roleId)
        {
            if(menuIds.Count >0&& roleId>0)
            {
                List<RoleMenuInfoModel> rmList = new List<RoleMenuInfoModel>();
                foreach (var menuId in menuIds)
                {
                    rmList.Add(new RoleMenuInfoModel()
                    {
                        RoleId = roleId,
                        MenuId = menuId
                    });
                }
                return rmDAL.SaveRoleMenuRelations(rmList, roleId);
            }
            return false;
        }
    }
}
