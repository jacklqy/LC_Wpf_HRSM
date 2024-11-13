using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.Models.VModels
{
        public class UserRoleListModel
        {
                /// <summary>
                /// 用户编号
                /// </summary>		
                public int UserId { get; set; }
                /// <summary>
                /// 用户名
                /// </summary>		
                public string UserName { get; set; }
                /// <summary>
                /// 用户密码
                /// </summary>
                public string UserPwd { get; set; }
                /// <summary>
                /// 状态
                /// </summary>		
                public bool UserState { get; set; }
                /// <summary>
                /// 姓名
                /// </summary>		
                public string UserFName { get; set; }
                /// <summary>
                /// 电话
                /// </summary>		
                public string UserPhone { get; set; }
                /// <summary>
                /// 用户拥有的角色
                /// </summary>
                public List<int> RoleIds { get; set; }
        }
}
