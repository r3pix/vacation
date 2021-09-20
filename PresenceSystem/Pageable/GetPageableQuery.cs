using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenceSystem.Pageable
{
    namespace PresenceSystem.Pageable
    {
        public class GetPageableQuery
        {
            public bool Desc { get; set; }
            public string OrderBy { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public string SearchTerm { get; set; }
        }
    }
}
