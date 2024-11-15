﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HRSM.Common.CustomAttributes;

namespace HRSM.Models.DModels
{
    /// <summary>
    /// 菜单信息表
    /// </summary>
    [Table("MenuInfos")]
    [PrimaryKey("MenuId", autoIncrement = true)]
    public class MenuInfoModel
    {

        /// <summary>
        /// 菜单编号
        /// </summary>		
        public int MenuId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>		
        public string MenuName { get; set; }
        /// <summary>
        /// 父编号
        /// </summary>		
        public int ParentId { get; set; }
        /// <summary>
        /// 关联页面
        /// </summary>		
        public string MenuUrl { get; set; }
        /// <summary>
        /// 快捷键
        /// </summary>		
        public string MKey { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>		
        public int MOrder { get; set; }
        /// <summary>
        /// 是否顶级页面
        /// </summary>		
        public bool IsTop { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>		
        public string MCode { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>		
        public int IsDeleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreateTime { get; set; }

    }
}

