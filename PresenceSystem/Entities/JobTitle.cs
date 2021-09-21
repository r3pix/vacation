using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vacation.Entities
{
    public class JobTitle
    {
        public int Id { get; set; }
        public string JobTitleName { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
