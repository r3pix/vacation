using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PresenceSystem.Entities;
using Vacation.Enums;

namespace Vacation.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int JobTitleId { get; set; }
        public int DepartmentId { get; set; }
        //public int VacationDays { get; set; }
        public string Email { get; set; }
        
        public int EmploymentTypeId { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedById { get; set; }
        public int ModifiedById { get; set; }
        //public int IdentityId { get; set; }
       // public virtual Identity Identity { get; set; }

        public virtual JobTitle JobTitle { get; set; }
        public virtual Department Department { get; set; }
        public virtual EmploymentType EmploymentType { get; set; }
        public virtual List<ListOfPresence> ListOfPresences { get; set; }


    }
}
