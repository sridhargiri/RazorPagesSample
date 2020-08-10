using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mapledotnet.ContractModel
{
    public partial class CoveragePlan
    {
        [Key]
        public int PlanId { get; set; }
        [StringLength(10)]
        public string PlanName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateFrom { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTo { get; set; }
        [StringLength(10)]
        public string Country { get; set; }
    }
}
