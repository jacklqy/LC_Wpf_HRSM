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
    public class RoleDAL : BaseDAL<RoleInfoModel>
    {
        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool AddRoleInfo(RoleInfoModel roleInfo)
        {
            string cols = "RoleName,Remark";
            return Add(roleInfo, cols, 0) > 0;
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool UpdateRoleInfo(RoleInfoModel roleInfo)
        {
            string cols = "RoleId,RoleName,Remark";
            return Update(roleInfo, cols, "");
        }

        /// <summary>
        /// 修改角色信息(并连同关系数据)的删除状态（真删除即为删除操作）
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="delType">0-假删除 1-真删除 </param>
        /// <returns></returns>
        public bool UpdateRoleInfoState(int roleId, int delType, int isDeleted)
        {
            string[] tableNames = { "RoleInfos", "RoleMenuInfos", "UserRoleInfos" };
            List<string> sqlList = GetDeleteSql(delType, roleId, isDeleted, tableNames);
            return SqlHelper.ExecuteTrans(sqlList);
        }

        /// <summary>
        /// 批量 修改角色信息(并连同关系数据)的删除状态（真删除即为删除操作）
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="delType"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public bool UpdateRolesState(List<int> roleIds,int delType,int isDeleted)
        {
            List<string> sqlList = new List<string>();
            string[] tableNames = { "RoleInfos", "RoleMenuInfos", "UserRoleInfos" };
            sqlList = GetDeleteListSql(delType, roleIds, isDeleted, tableNames);
            return SqlHelper.ExecuteTrans(sqlList);
        }

        /// <summary>
        /// 获取指定id的角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleInfoModel GetRoleInfo(int roleId)
        {
            return GetById(roleId, "RoleId,RoleName,IsAdmin,Remark,CreateTime");
        }

        /// <summary>
        /// 判断角色名称是否已存在
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool Exists(string roleName)
        {
            return ExistsByName("RoleName", roleName);
        }

        /// <summary>
        /// 获取指定角色的IsAdmin的值
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool GetRoleIsAdmin(int roleId)
        {
            RoleInfoModel role = GetById(roleId, "IsAdmin");
            if (role != null)
                return role.IsAdmin;
            return false;
        }

        /// <summary>
        /// 获取所有角色列表（绑定下拉框或列表框）
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetAllRoles()
        {
            string cols = "RoleId,RoleName";
            return GetModelList(cols, 0);
        }

        /// <summary>
        /// 获取角色列表信息（数据列表）
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public List<RoleInfoModel> GetRoleList(int isDeleted)
        {
            string cols = "RoleId,RoleName,IsAdmin,Remark";
            return GetRowsModelList(cols, isDeleted);
        }

        /// <summary>
        /// 获取拥有指定角色的用户数(有效用户)
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
       public int GetRoleUsers(int roleId)
        {
            string sql = $"select count(1) from ViewUserRoleInfos where RoleId={roleId} and UserDeleted=0";
            object oCount = SqlHelper.ExecuteScalar(sql, 1);
            if (oCount != null && oCount.ToString() != "")
                return oCount.GetInt();
            else
                return 0;
        }
    }
}
