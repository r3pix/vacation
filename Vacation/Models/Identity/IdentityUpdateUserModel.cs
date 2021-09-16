using ItmCode.Common.Identity.Enums;
using System;
using System.Collections.Generic;

namespace Vacation.Models.Identity
{
    public class IdentityUpdateUserModel
    {
        public IdentityUpdateUserModel()
        {
            Roles = new List<string>();
            Permissions = new List<AppPermission>();
        }

        public string DataKey { get; set; }
        public string Email { get; set; }
        public IEnumerable<AppPermission> Permissions { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public Guid? UserId { get; set; }
    }
}