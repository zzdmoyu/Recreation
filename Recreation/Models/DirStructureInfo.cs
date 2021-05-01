using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewDemo.Models
{
    public class DirStructureInfo
    {
        /// <summary>
        /// 存在子集
        /// </summary>
        public bool ExistSubSet { get; set; }

        /// <summary>
        /// 父集编号
        /// </summary>
        public int ParentSetNo { get; set; }

        /// <summary>
        /// 父集名称
        /// </summary>
        public string ParentSetName { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 完整路径
        /// </summary>
        public string AllPath { get; set; }
    }
}