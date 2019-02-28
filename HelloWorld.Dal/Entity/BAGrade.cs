using System;
using System.Data;
using XFramework.Dal.Orm;

namespace HelloWorld.Dal.Entity
{
    [Table(Name ="ba_grade")]
    [Database(Name ="EZLearnDB")]
    public class BAGrade
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Column(Name ="ID", PrimaryKey = true, ColumnType = DbType.AnsiString)]
        public string ID { get; set; }

        /// <summary>
        /// 年级名称
        /// </summary>
        [Column(Name = "Name", ColumnType = DbType.AnsiString)]
        public string Name { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        [Column(Name = "SortCode", ColumnType = DbType.Int32)]
        public int? ShortCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column(Name = "Remark", ColumnType = DbType.AnsiString)]
        public string Remark { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column(Name = "Enabled", ColumnType = DbType.Int32)]
        public int? Enabled { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Column(Name = "CreateStaff", ColumnType = DbType.AnsiString)]
        public string CreateStuff { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Name = "CreateDate", ColumnType = DbType.DateTime)]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [Column(Name = "ModifyStaff", ColumnType = DbType.AnsiString)]
        public string ModifyStuff { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Column(Name = "ModifyDate", ColumnType = DbType.DateTime)]
        public DateTime? ModifyDate { get; set; }
    }
}
