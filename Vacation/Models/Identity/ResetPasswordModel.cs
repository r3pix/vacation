using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.Models.Identity
{
    public class ResetPasswordModel
    {
        public string Email { get; set; }

        public string NewPassword { get; set; }

        public string Token { get; set; }
    }
}
