using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Vacation.Entities
{
    public class EmploymentType
    {
        public int Id { get; set; }
        public string EmploymentTypeName { get; set; }
        public virtual List<User> Users { get; set; }

    }
}
