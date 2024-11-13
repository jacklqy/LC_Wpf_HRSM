using DBUtility;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL
{
    public class MenuDAL:BaseDAL<MenuInfoModel>
    {
        /// <summary>
        /// 添加菜单信息
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public bool AddMenuInfo(MenuInfoModel menuInfo)
        {
            string cols = "MenuName,ParentId,MenuUrl,MKey,MOrder,IsTop,MCode";
            return Add(menuInfo, cols, 0) > 0;
        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public bool UpdateMenuInfo(MenuInfoModel menuInfo)
        {
            string cols = "MenuId,MenuName,ParentId,MenuUrl,MKey,MOrder,IsTop,MCode";
            return Update(menuInfo, cols, "");
        }

        /// <summary>
        /// 修改菜单信息(并连同关系数据)的删除状态（真删除即为删除操作）
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="delType">0-假删除 1-真删除 </param>
        /// <returns></returns>
        public bool UpdateMenuInfoState(int menuId, int delType, int isDeleted,bool hasChild)
        {
           
            List<string> sqlList = new List<string>();
            if (hasChild)
            {
                string strWhere = $"MenuId={menuId} or ParentId={menuId}";
                string[] tableNames = { "RoleMenuInfos" };
                sqlList = GetDeleteSqlHasChild(delType, menuId, isDeleted, tableNames, "MenuInfos", "MenuId", "ParentId");
            }
            else
            {
                string[] tableNames = { "MenuInfos","RoleMenuInfos" };
                sqlList = GetDeleteSql(delType, menuId, isDeleted, tableNames);
            }
            //if(delType==0)
            //{
            //    sqlList.Add($"update MenuInfos set IsDeleted={isDeleted} where {strWhere}");
            //    sqlList.Add($"update RoleMenuInfos set IsDeleted={isDeleted} where MenuId in (select MenuId from MenuInfos where {strWhere}) ");
            //}
            //else
            //{
            //    sqlList.Add($"delete from  MenuInfos where {strWhere}");
            //    sqlList.Add($"delete from RoleMenuInfos  where MenuId in (select MenuId from MenuInfos where {strWhere}) ");
            //}
            return SqlHelper.ExecuteTrans(sqlList);
        }

        /// <summary>
        /// 批量 修改菜单信息(并连同关系数据)的删除状态（真删除即为删除操作）
        /// </summary>
        /// <param name="menuIds"></param>
        /// <param name="delType"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public bool UpdateMenusState(List<int> menuIds, int delType, int isDeleted,bool hasChild)
        {
            List<string> sqlList = new List<string>();
            if(hasChild)
            {
                string[] tableNames = { "RoleMenuInfos" };
                sqlList = GetDeleteListSqlHasChild(delType, menuIds, isDeleted, tableNames, "MenuInfos", "MenuId", "ParentId");
            }
            else
            {
                string[] tableNames = { "MenuInfos", "RoleMenuInfos" };
                sqlList = GetDeleteListSql(delType, menuIds, isDeleted, tableNames);
            }
            //foreach(int menuId in menuIds)
            //{
            //    string strWhere = $"MenuId={menuId} or ParentId={menuId}";
            //    if (delType == 0)
            //    {
            //        sqlList.Add($"update MenuInfos set IsDeleted={isDeleted} where {strWhere}");
            //        sqlList.Add($"update RoleMenuInfos set IsDeleted={isDeleted} where MenuId in (select MenuId from MenuInfos where {strWhere}) ");
            //    }
            //    else
            //    {
            //        sqlList.Add($"delete from  MenuInfos where {strWhere}");
            //        sqlList.Add($"delete from RoleMenuInfos  where MenuId in (select MenuId from MenuInfos where {strWhere}) ");
            //    }
            //}
            
            return SqlHelper.ExecuteTrans(sqlList);
        }



        /// <summary>
        /// 获取指定 菜单信息
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public MenuInfoModel GetMenuInfo(int menuId)
        {
            string cols = "MenuId,MenuName,ParentId,MenuUrl,MKey,MOrder,IsTop,MCode";
            return GetById(menuId, cols);
        }

        /// <summary>
        /// 判断菜单名是否已存在
        /// </summary>
        /// <param name="menuName"></param>
        /// <returns></returns>
        public bool Exists(string menuName)
        {
            return ExistsByName("MenuName", menuName);
        }

        /// <summary>
        /// 条件查询菜单列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="parentId"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public List<MenuInfoModel> GetMenuList(string keywords, int parentId, int isDeleted)
        {
            string cols = "MenuId,MenuName,ParentId,MenuUrl,MKey,MOrder,IsTop";
            string strWhere = $"IsDeleted={isDeleted}";
            string strOrder = " order by ParentId,MOrder";
            if(parentId>=0)
                strWhere += $" and ParentId={parentId}";
            if (!string.IsNullOrEmpty(keywords))
            {
                strWhere += " and MenuName like @keywords";
                strWhere += strOrder;
                SqlParameter paraKeywords = new SqlParameter("@keywords", $"%{keywords}%");
                return GetRowsModelList(strWhere, cols, paraKeywords);
            }
            strWhere += strOrder;
            return GetRowsModelList(strWhere, cols);
        }

        /// <summary>
        /// 获取指定菜单的子菜单数
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public int GetSubMenus(int menuId)
        {
            List<MenuInfoModel> list = GetModelList($"ParentId={menuId} and IsDeleted=0","Menuid");
            if (list != null && list.Count > 0)
                return list.Count;
            else
                return 0;
        }

        /// <summary>
        /// 获取所有菜单列表（未删除的菜单），用于绑定下拉框或TreeList
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoModel> GetAllMenus()
        {
            string cols = "MenuId,MenuName,ParentId";
            return GetModelList(cols, 0);
        }

        /// <summary>
        /// 获取所有的未删除菜单列表（用于管理员登录，加载所有菜单）
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoModel> GetAllMenuList()
        {
            string cols = "MenuId,MenuName,ParentId,MenuUrl,IsTop";
            return GetModelList(cols, 0);
        }

        /// <summary>
        /// 获取指定角色的菜单列表
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public List<MenuInfoModel> GetRoleMenuList(List<int> roleIds)
        {
            string cols = "MenuId,MenuName,ParentId,MenuUrl,IsTop";
            string strIds = string.Join(",", roleIds);
            string strWhere = $"IsDeleted=0 and MenuId in (select MenuId from RoleMenuInfos where  RoleId in ({strIds}))";
            return GetModelList(strWhere,cols);
        }

       
    }
}
