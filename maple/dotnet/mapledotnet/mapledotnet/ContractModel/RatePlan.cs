using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mapledotnet.ContractModel
{
    public partial class RatePlan
    {
        public int? PlanId { get; set; }
        [StringLength(1)]
        public string Gender { get; set; }
        public int CustomerMinAge { get; set; }
        public int CustomerMaxAge { get; set; }
        public int NetPrice { get; set; }

        [ForeignKey(nameof(PlanId))]
        public virtual CoveragePlan Plan { get; set; }
    }
}
