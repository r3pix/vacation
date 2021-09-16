using ItmCode.Common.CurrentUser;
using ItmCode.Common.Identity.Enums;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ItmCode.Common.Identity.Extensions;

namespace ItmCode.Common.Identity.Services
{
    public class CurrentUserService : ICurrentUser
    {
        private string _email;
        private string _id;
        private string _lastName;
        private string _givenName;


        public string Email => GetEmail();
        public string Id => GetId();
        public string LastName { get { return _lastName; } }
        public string GivenName { get { return _givenName; } }

        public List<AppPermission> Permissions { get; private set; }

        public bool HasPermision(params AppPermission[] permissions) => Permissions.Any(permissions.Contains) || Permissions.Contains(AppPermission.AccessAll);

        //public AppRole? Role { get; private set; }
        public void SetCurrentUser(IEnumerable<Claim> claims)
        {
            SetUser(claims);
            //SetRole(claims);
            SetPermissions(claims);
        }

        public void SetCurrentUser(string email)
        {
            _email = email;
        }

        private string GetEmail()
        {
            if (_email == null)
            {
                throw new ArgumentNullException("Current user id is null or empty!");
            }

            return _email;
        }

        private string GetId()
        {
            if (_id == null)
            {
                throw new ArgumentNullException("Current user id is null or empty!");
            }

            return _id;
        }

        private void SetPermissions(IEnumerable<Claim> claims)
        {
            Permissions = claims.GetUserPermissions();
        }

        private void SetRole(IEnumerable<Claim> claims)
        {
            var role = claims.GetUserRole();
            if (role == null)
            {
                role = "None";
            }

            //Role = role.GetRole();
        }

        private void SetUser(IEnumerable<Claim> claims)
        {
            _email = claims.GetEmail();
            _givenName = claims.GetGivenName();
            _lastName = claims.GetLastName();
            _id = claims.GetUserId();
        }
    }
}