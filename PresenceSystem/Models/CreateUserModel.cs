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
        public string JobTitle { get; set; }
        public string EmploymentType { get; set; }
        public string Department { get; set; }


    }
}
