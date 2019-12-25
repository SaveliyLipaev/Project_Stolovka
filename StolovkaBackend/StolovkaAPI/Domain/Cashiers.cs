using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StolovkaWebAPI.Domain
{
    public partial class Cashiers
    {
        [Key]
        public string Id { get; set; }
        public string Login { get; set; }
        public string PasswordCrypted { get; set; }
        public string CanteenId { get; set; }
        public string Role { get; set; }

        public virtual Canteen Canteen { get; set; }
    }
}
