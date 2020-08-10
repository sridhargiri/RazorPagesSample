using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mapledotnet.ContractModel
{
    public partial class Contracts
    {
        [Key]
        public int ContractId { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(50)]
        public string CustomerAddress { get; set; }
        [StringLength(1)]
        public string CustomerGender { get; set; }
        [StringLength(50)]
        public string CustomerCountry { get; set; }
        [Column("CustomerDOB", TypeName = "datetime")]
        public DateTime CustomerDob { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SaleDate { get; set; }
        [StringLength(50)]
        public string CoveragePlan { get; set; }
        public int NetPrice { get; set; }
    }
}
