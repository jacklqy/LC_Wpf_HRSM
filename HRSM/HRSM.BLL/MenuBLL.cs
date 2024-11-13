using HRSM.DAL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.BLL
{
    public class MenuBLL:BaseBLL<MenuInfoModel>
    {
        private MenuDAL menuDAL = new MenuDAL();
        private RoleDAL roleDAL = new RoleDAL();
        /// <summary>
        /// 添加菜单信息
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public bool AddMenuInfo(MenuInfoModel menuInfo)
        {
            return menuDAL.AddMenuInfo(menuInfo);
        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public bool UpdateMenuInfo(MenuInfoModel menuInfo)
        {
            return menuDAL.UpdateMenuInfo(menuInfo);
        }

        #region 删除与恢复
        /// <summary>
        /// 删除菜单信息（假删除）
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="delType">0-假删除 1-真删除 </param>
        /// <returns></returns>
        public bool LogicDelMenu(int menuId, bool hasChild)
        {
            return menuDAL.UpdateMenuInfoState(menuId, 0, 1,hasChild);

        }

        /// <summary>
        /// 恢复菜单信息
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool RecoverMenu(int menuId, bool hasChild)
        {
            return menuDAL.UpdateMenuInfoState(menuId, 0, 0,hasChild);
        }

        /// <summary>
        /// 删除菜单信息（真删除）
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool RemoveMenu(int menuId, bool hasChild)
        {
            return menuDAL.UpdateMenuInfoState(menuId, 1, 2,hasChild);
        }

        /// <summary>
        /// 删除菜单信息（假删除）
        /// </summary>
        /// <param name="menuIds"></param>
        /// <param name="delType">0-假删除 1-真删除 </param>
        /// <returns></returns>
        public bool LogicDelMenuList(List<int> menuIds,bool hasChild)
        {
            return menuDAL.UpdateMenusState(menuIds, 0, 1,hasChild);
        }

        /// <summary>
        /// 恢复菜单信息
        /// </summary>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public bool RecoverMenuList(List<int> menuIds, bool hasChild)
        {
            return menuDAL.UpdateMenusState(menuIds, 0, 0,hasChild);
        }

        /// <summary>
        /// 删除菜单信息（真删除）
        /// </summary>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public bool RemoveMenuList(List<int> menuIds, bool hasChild)
        {
            return menuDAL.UpdateMenusState(menuIds, 1, 2,hasChild);
        }
        #endregion

        #region 菜单信息查询
        /// <summary>
        /// 获取指定id的菜单信息
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public MenuInfoModel GetMenuInfo(int menuId)
        {
            return menuDAL.GetMenuInfo(menuId);
        }

        /// <summary>
        /// 判断菜单名称是否已存在
        /// </summary>
        /// <param name="menuName"></param>
        /// <returns></returns>
        public bool Exists(string menuName)
        {
            return menuDAL.Exists(menuName);
        }

        /// <summary>
        ///  获取所有菜单列表（未删除的菜单），用于绑定下拉框或TreeList
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoModel> GetAllMenus()
        {
            return menuDAL.GetAllMenus();
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
            return menuDAL.GetMenuList(keywords, parentId, isDeleted);
        }

        /// <summary>
        /// 指定菜单是否已添加子菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool HasChildMenus(int menuId)
        {
            return menuDAL.GetSubMenus(menuId) > 0;
        }

        /// <summary>
        /// 指定的菜单集合中是否包含有子菜单
        /// </summary>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public bool HasChildMenus(List<int> menuIds)
        {
            foreach (int id in menuIds)
            {
                if (HasChildMenus(id))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 判断指定菜单是否是系统管理菜单，系统管理不能删除
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool IsSystemMenu(int menuId)
        {
            MenuInfoModel menu = GetMenuInfo(menuId);
            if (menu != null && menu.MCode == MCode.SM.ToString())
                return true;
            return false;
        }

        /// <summary>
        /// 获取登录用户的菜单列表
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public List<MenuInfoModel> GetRoleMenuList(List<int> roleIds)
        {
            if(roleIds.Count >0)
            {
                bool isAdmin = false;
                foreach (int roleId in roleIds)
                {
                    isAdmin = roleDAL.GetRoleIsAdmin(roleId);
                    if (isAdmin)
                        break;
                }
                if(isAdmin)//只要拥有的角色有一个是管理员，就加载所有菜单
                {
                    return menuDAL.GetAllMenuList();
                }
                else
                {
                    return menuDAL.GetRoleMenuList(roleIds);
                }
            }
            return null;
        }


        public enum MCode
        {
            SM
        }

        #endregion

    }
}
