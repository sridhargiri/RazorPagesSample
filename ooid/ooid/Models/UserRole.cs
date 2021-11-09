using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ooid.Models
{
    [Table(nameof(UserRole))]
    public class UserRole
    {
        [ForeignKey(nameof(Models.User.Id))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Models.Role.Id))]
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}

