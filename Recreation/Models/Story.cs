using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recreation.Models
{
    public class Story
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string StoryId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int IndexSort { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 0:短篇 1：长篇
        /// </summary>
        public int  StoryType { get; set; }
        /// <summary>
        /// 0:no;1:删除
        /// </summary>
        public int IsDelete { get; set; }
    }
}
