using System;
using System.Collections.Generic;

namespace StolovkaWebAPI.Domain
{
    public partial class Canteens
    {
        public Canteens()
        {
            Cashiers = new HashSet<Cashiers>();
            Dishes = new HashSet<Dishes>();
            Orders = new HashSet<Orders>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Worktime { get; set; }

        public virtual ICollection<Cashiers> Cashiers { get; set; }
        public virtual ICollection<Dishes> Dishes { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
