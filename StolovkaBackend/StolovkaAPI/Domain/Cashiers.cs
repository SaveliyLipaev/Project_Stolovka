using System;
using System.Collections.Generic;

namespace StolovkaWebAPI.Domain
{
    public partial class Cashiers
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string PasswordCrypted { get; set; }
        public string CanteenId { get; set; }
        public string Role { get; set; }

        public virtual Canteens Canteen { get; set; }
    }
}
