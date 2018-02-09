using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime CreateTime { get; set; }=DateTime.Now;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateUser { get; set; }


        public int? CreateUserId { get; set; }
        [ForeignKey("CreateUserId")]
        [NotMapped] //如果映射会与用户表中的部门外键形成循环??还没找到好的解决方法
        public UserInfo CreateUserInfo { get; set; }

        public int? UpdateUserId { get; set; }
        [ForeignKey("UpdateUserId")]
        [NotMapped]
        public UserInfo UpdateUserInfo { get; set; }
    }
}
