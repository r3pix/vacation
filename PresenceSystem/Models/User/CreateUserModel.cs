using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public class CreateUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string DisplayName { get; set; }
        public int JobTitleId { get; set; }
        public int EmploymentTypeId { get; set; }
        public int DepartmentId { get; set; }


    }
}
