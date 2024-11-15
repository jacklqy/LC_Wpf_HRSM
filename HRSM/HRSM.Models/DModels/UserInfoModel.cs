﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HRSM.Common.CustomAttributes;

namespace HRSM.Models.DModels
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Table("UserInfos")]
    [PrimaryKey("UserId", autoIncrement = true)]
    public class UserInfoModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>		
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>		
        public string UserName { get; set; }
        /// <summary>
        /// 密码
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
        /// 创建时间
        /// </summary>		
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>		
        public int IsDeleted { get; set; }

    }
}

