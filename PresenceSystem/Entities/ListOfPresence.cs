﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation.Entities;

namespace PresenceSystem.Entities
{
    public class ListOfPresence
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeStop { get; set; }
        public int PlaceId { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeModified { get; set; }
        public int CreatedById { get; set; }
        public int ModifiedById { get; set; }

        public virtual Place Place { get;  set; }
        public virtual User User { get; set; }

    }
}
