using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mapledotnet.ContractModel
{
    [Table("employee")]
    public partial class Employee
    {
        [Column("empid")]
        public int? Empid { get; set; }
        [Column("empname")]
        [StringLength(50)]
        public string Empname { get; set; }
        [Column("managerid")]
        public int? Managerid { get; set; }
        [Column("deptid")]
        public int? Deptid { get; set; }
        [Column("salary")]
        public int? Salary { get; set; }
        [Column("DOB", TypeName = "datetime")]
        public DateTime? Dob { get; set; }
    }
}
