using ItmCode.Common.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace ItmCode.Common.Identity.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false)]
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(AppPermission permission) : base(permission.ToString())
        { }
    }
}