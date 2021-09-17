using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenceSystem.Models
{
    public class UpdateUserModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int JobTitleId { get; set; }
        public int DepartmentId { get; set; }
    }
}
