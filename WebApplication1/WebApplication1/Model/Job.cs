using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class Job
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string JobTitle { get; set; }
        [StringLength(200)]
        public string ProfileData { get; set; }
        public string CompanyInfo { get; set; }
        public string JobTask { get; set; }
        public string CandidateProfile { get; set; }
        public string ApplicationInfo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
    }
}
