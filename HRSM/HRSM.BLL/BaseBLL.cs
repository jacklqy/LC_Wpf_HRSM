using HRSM.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.BLL
{
    public class BaseBLL<T> where T : class
    {
        private BaseDAL<T> dal = new BaseDAL<T>();

        
        #region 删除
        /// <summary>
        /// 根据Id删除  这里id是主键  假删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool LogicDelete(int id)
        {
            return dal.Delete(id, 0,1);
        }

        /// <summary>
        /// 根据Id真删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="delType"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return dal.Delete(id,1, 2);
        }

        /// <summary>
        /// 批量删除(真删除)
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public bool DeleteList(List<int> idList)
        {
            return dal.DeleteList(idList,1,2);
        }

        public bool LogicDeleteList(List<int> idList)
        {
            return dal.DeleteList(idList, 0, 1);
        }




        #endregion

        #region 恢复
        /// <summary>
        /// 根据Id恢复  这里id是主键 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Recover(int id)
        {
            return dal.Delete(id, 0, 0);
        }

        /// <summary>
        /// 批量恢复  这里id是主键 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool RecoverList(List<int> ids)
        {
            return dal.DeleteList(ids, 0, 0);
        }
        #endregion

       
    }
}