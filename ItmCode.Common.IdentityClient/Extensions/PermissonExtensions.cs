using ItmCode.Common.Identity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;

namespace ItmCode.Common.Identity.Extensions
{
    public static class PermissionExtensions
    {
        public static AppPermission? ConvertFromString(string permission)
        {
            if (int.TryParse(permission, out var intValue))
            {
                return (AppPermission)intValue;
            }

            return null;
        }

        public static bool ThisPermissionIsAllowed(this List<Claim> packedPermissions, string permissionName)
        {
            var usersPermissions = packedPermissions.UnpackPermissionsFromClaims().ToArray();

            if (!Enum.TryParse(permissionName, true, out AppPermission permissionToCheck))
                throw new InvalidEnumArgumentException($"{permissionName} could not be converted to a {nameof(AppPermission)}.");

            return usersPermissions.UserHasThisPermission(permissionToCheck);
        }

        public static Claim ToClaim(this AppPermission enumPermission)
        {
            return new Claim(CustomPermissionTypes.EnumPermission, ((int)enumPermission).ToString());
        }

        public static AppPermission ToPermission(this Claim claimPermission)
        {
            if (claimPermission == null || claimPermission.Type != CustomPermissionTypes.EnumPermission)
                throw new ArgumentNullException(nameof(claimPermission));
            int numberValue;
            int.TryParse(claimPermission.Value, out numberValue);
            return (AppPermission)numberValue;
        }

        public static IEnumerable<AppPermission> UnpackPermissionsFromClaims(this List<Claim> packedPermissions)
        {
            if (packedPermissions == null)
                throw new ArgumentNullException(nameof(packedPermissions));
            foreach (var claim in packedPermissions)
            {
                var result = ConvertFromString(claim.Value);

                if (result.HasValue)
                {
                    yield return result.Value;
                }
            }
        }

        public static bool UserHasThisPermission(this AppPermission[] usersPermissions, AppPermission permissionToCheck)
        {
            return usersPermissions.Contains(permissionToCheck) || usersPermissions.Contains(AppPermission.AccessAll);
        }
    }
}