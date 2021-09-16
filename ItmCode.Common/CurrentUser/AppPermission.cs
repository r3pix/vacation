using System;

namespace ItmCode.Common.Identity.Enums
{
    public enum AppPermission : short
    {
        NotSet = 0, //error condition

        UserRead = 40,
        UserChange = 41,

        RoleRead = 50,
        RoleChange = 51,

        ClientRead = 60,
        ClientChange = 61,

        ResourceRead = 70,
        ResourceChange = 71,

        AccessToOrders = 80,
        CanPlaceOrders = 81,
        CanAcceptRejectOrders = 82,

        AccessToSimCards = 90,
        CanAddSimCards = 91,
        CanDeleteSimCards = 92,

        AccessToDevices = 100,
        CanAddDevices = 101,
        CanDeleteDevices = 102,

        AccessToUsers = 110,
        CanDeleteUsers = 111,

        AccessToAdministrativeTools = 200,


        //BugReporting
        ReadOwnReports = 2201,
        ReadAllReports = 2202,
        ReportsEdit = 2203,
        ModulesChange = 2204,

        [Obsolete]
        OldPermissionNotUsed = 1000,

        AccessAll = short.MaxValue,
    }
}