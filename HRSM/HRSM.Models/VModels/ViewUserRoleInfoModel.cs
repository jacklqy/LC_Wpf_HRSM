using HRSM.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.Models.VModels
{
        /// <summary>
        /// ViewUserRoleInfos 视图实体
        /// </summary>
        [Table("ViewUserRoleInfos")]
        public class ViewUserRoleInfoModel
        {
                public int UserId { get; set; }
                public int RoleId { get; set; }
                public string UserPwd { get; set; }
                public bool UserState { get; set; }
                public string UserFName { get; set; }
                public string UserName { get; set; }
                public bool IsAdmin { get; set; }
                public string UserPhone { get; set; }
                public int UserDeleted { get; set; }
                public string RoleName { get; set; }
        }
}
