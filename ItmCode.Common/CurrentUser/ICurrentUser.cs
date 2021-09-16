using ItmCode.Common.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ItmCode.Common.CurrentUser
{
    public interface ICurrentUser
    {
        string Email { get; }
        string LastName { get; }
        string GivenName { get; }
        string Id { get; }

        void SetCurrentUser(IEnumerable<Claim> claims);

        void SetCurrentUser(string id);

        bool HasPermision(params AppPermission[] permissions);
    }
}