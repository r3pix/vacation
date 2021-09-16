using ItmCode.Common.Identity.Enums;
using ItmCode.Common.Identity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ItmCode.Common.Identity.Extensions
{
    public static class ClaimExtension
    {
        public static Claim GetClaim(this IEnumerable<Claim> claims, string key) =>
            claims.FirstOrDefault(x => x.Type == key);

        public static string GetEmail(this IEnumerable<Claim> claims)
        {
            var claim = claims.GetClaim(ClaimTypes.Email);

            return claim?.Value;
        }

        public static string GetLastName(this IEnumerable<Claim> claims)
        {
            var claim = claims.GetClaim(ClaimTypes.Surname);

            return claim?.Value;
        }

        public static string GetGivenName(this IEnumerable<Claim> claims)
        {
            var claim = claims.GetClaim(ClaimTypes.GivenName);

            return claim?.Value;
        }

        public static string GetUserId(this IEnumerable<Claim> claims)
        {
            var claim = claims.GetClaim(ClaimTypes.NameIdentifier);

            return claim?.Value;
        }

        public static List<AppPermission> GetUserPermissions(this IEnumerable<Claim> claims)
        {
            var permissions = claims.Where(x => x.Type == CustomPermissionTypes.EnumPermission).Select(x => x.ToPermission()).ToList();
            return permissions;
        }

        public static string GetUserRole(this IEnumerable<Claim> claims)
        {
            var claim = claims.GetClaim(ClaimTypes.Role);

            return claim != null ? claim.Value : null;
        }
    }
}