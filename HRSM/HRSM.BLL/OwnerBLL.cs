using HRSM.Common;
using HRSM.DAL;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.BLL
{
    public class OwnerBLL
    {
        private OwnerDAL ownerDAL = new OwnerDAL();
        /// <summary>
        /// 添加业主信息
        /// </summary>
        /// <param name="ownerInfo"></param>
        /// <returns></returns>
        public bool AddOwnerInfo(HouseOwnerInfoModel ownerInfo)
        {
            return ownerDAL.AddOwnerInfo(ownerInfo);
        }

        /// <summary>
        /// 修改业主信息
        /// </summary>
        /// <param name="ownerInfo"></param>
        /// <returns></returns>
        public bool UpdateOwnerInfo(HouseOwnerInfoModel ownerInfo)
        {
            return ownerDAL.UpdateOwnerInfo(ownerInfo);
        }

        /// <summary>
        /// 导入业主数据
        /// </summary>
        /// <param name="excelFile"></param>
        /// <param name="sheetName"></param>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        public int ImportOwnerData(string excelFile, string sheetName, bool isFirstRowColumn)
        {
            DataTable dt = ExcelHelper.ExcelToDataTable(excelFile, sheetName, isFirstRowColumn);
            if (dt.Rows.Count > 0)
            {
                bool bl= ownerDAL.AddOwnerInfos(dt);
                if (bl)
                    return 1;
                else
                    return 0;
            }
            else
                return -1;
        }

        #region 删除与恢复
        /// <summary>
        /// 删除业主信息（假删除）
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="delType">0-假删除 1-真删除 </param>
        /// <returns></returns>
        public bool LogicDelOwner(int ownerId)
        {
            return ownerDAL.UpdateOwnerInfoState(ownerId, 0, 1);

        }

        /// <summary>
        /// 恢复业主信息
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public bool RecoverOwner(int ownerId)
        {
            return ownerDAL.UpdateOwnerInfoState(ownerId, 0, 0);
        }

        /// <summary>
        /// 删除业主信息（真删除）
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public bool RemoveOwner(int ownerId)
        {
            return ownerDAL.UpdateOwnerInfoState(ownerId, 1, 2);
        }

        /// <summary>
        /// 批量删除业主信息（假删除）
        /// </summary>
        /// <param name="ownerIds"></param>
        /// <param name="delType">0-假删除 1-真删除 </param>
        /// <returns></returns>
        public bool LogicDelOwnerList(List<int> ownerIds)
        {
            return ownerDAL.UpdateOwnersState(ownerIds, 0, 1);
        }

        /// <summary>
        /// 批量恢复业主信息
        /// </summary>
        /// <param name="ownerIds"></param>
        /// <returns></returns>
        public bool RecoverOwnerList(List<int> ownerIds)
        {
            return ownerDAL.UpdateOwnersState(ownerIds, 0, 0);
        }

        /// <summary>
        /// 批量删除业主信息（真删除）
        /// </summary>
        /// <param name="ownerIds"></param>
        /// <returns></returns>
        public bool RemoveOwnerList(List<int> ownerIds)
        {
            return ownerDAL.UpdateOwnersState(ownerIds, 1, 2);
        }
        #endregion

        #region 业主信息查询
        /// <summary>
        /// 获取指定id的业主信息
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public HouseOwnerInfoModel GetOwnerInfo(int ownerId)
        {
            return ownerDAL.GetOwnerInfo(ownerId);
        }

        /// <summary>
        /// 判断业主是否已存在
        /// </summary>
        /// <param name="ownerName"></param>
        /// <param name="ownerPhone"></param>
        /// <returns></returns>
        public bool Exists(string ownerName,string ownerPhone)
        {
            return ownerDAL.Exists(ownerName,ownerPhone);
        }

        /// <summary>
        ///  获取所有业主列表（未删除的），用于绑定下拉框
        /// </summary>
        /// <returns></returns>
        public List<HouseOwnerInfoModel> GetAllOwners()
        {
            return ownerDAL.GetAllOwners();
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
            return ownerDAL.GetOwnerList(keywords, ownerType, isDeleted);
        }
        #endregion
    }
}
