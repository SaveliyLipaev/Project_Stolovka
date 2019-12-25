using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StolovkaWebAPI.Domain
{
    public partial class User
    {
        [Key]
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
