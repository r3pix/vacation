using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenceSystem.Models
{
    public class ListOfPresenceTableModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeStop { get; set; }
        public string Place { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeModified { get; set; }
        public int CreatedById { get; set; }
        public int ModifiedById { get; set; }
    }
}
