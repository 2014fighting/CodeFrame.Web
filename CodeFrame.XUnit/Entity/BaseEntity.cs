using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFrame.XUnit.Entity
{
    /// <summary>
    /// DB表基础属性
    /// </summary>
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public T Id { get; set; }
 
        public DateTime RowVersion { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreteTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}