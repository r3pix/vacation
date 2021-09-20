using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenceSystem.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public virtual List<ListOfPresence> ListOfPresences { get; set; }
    }
}
