using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StolovkaWebAPI.Domain
{
    [Table("canteens")]
    public class Canteen
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Worktime { get; set; }

        public virtual ICollection<Cashiers> Cashiers { get; set; }
        public virtual ICollection<Dishes> Dishes { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
