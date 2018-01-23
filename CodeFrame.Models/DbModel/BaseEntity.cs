using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace CodeFrame.Models.DbModel
{
    /// <summary>
    /// DB表基础属性
    /// </summary>
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Key]
        public T Id { get; set; }

        /// <summary>
        /// DB版号,Mysql详情参考;http://www.cnblogs.com/shanyou/p/6241612.html
        /// </summary>
        //[Timestamp]//Mysql不允许byte[]类型上标记TimeStamp/RowVersion，这里使用DateTime类型配合标记ConcurrencyCheck达到并发控制
        [ConcurrencyCheck]
        public DateTime RowVersion { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreteTime { get; set; }=DateTime.Now;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public DateTime CreteUser { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public DateTime? UpdateUser { get; set; }
    }
}
