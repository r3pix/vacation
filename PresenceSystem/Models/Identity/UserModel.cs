using ItmCode.Common.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vacation.Models.Identity
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DataKey { get; set; }

        public List<string> Roles { get; set; }

        public List<AppPermission> Permissions { get; set; }
    }
}
