using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenceSystem.Models
{
    public class UserTableModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string EmploymentType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int CreatedById { get; set; }
        public int ModifiedById { get; set; }

    }
}
