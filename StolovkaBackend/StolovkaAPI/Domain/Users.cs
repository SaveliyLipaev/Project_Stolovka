using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StolovkaWebAPI.Domain
{
    public partial class Users
    {
        [Key]
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Card { get; set; }

        public virtual Cards CardNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
