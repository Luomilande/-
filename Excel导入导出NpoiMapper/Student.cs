using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Excel导入导出NpoiMapper
{
    public class Student
    {
        [Column("学号")]
        public int Id { get; set; }
        [Column("名字")]
        public string Name { get; set; }
        [Column("性别")]
        public string Sex { get; set; }
        [Column("生日",CustomFormat ="yyyy-mm-dd")]
        public DateTime BirthDay { get; set; }
    }
}
