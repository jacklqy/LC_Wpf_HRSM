using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL.VDAL
{
    public class ViewUserRoleInfoDAL:BaseDAL<ViewUserRoleInfoModel>
    {
        /// <summary>
        /// 获取指定用户的角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ViewUserRoleInfoModel> GetUserRoleList(int userId)
        {
            string cols = "UserId,UserName,UserPwd,UserState,UserFName,UserPhone,RoleId,RoleName,IsAdmin";
            List<ViewUserRoleInfoModel> urList = GetModelList($"UserId={userId}", cols);
            return urList;
        }
       
        /// <summary>
        /// 获取指定用户的角色编号集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<int> GetUserRoleIds(int userId)
        {
            List<ViewUserRoleInfoModel> urList = GetModelList($"UserId ={ userId}", "RoleId");
            if (urList != null && urList.Count > 0)
                return urList.Select(ur => ur.RoleId).ToList();
            else
                return null;
        }
    }
}
