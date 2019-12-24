using System;
using System.Collections.Generic;

namespace StolovkaWebAPI.Domain
{
    public partial class Cards
    {
        public Cards()
        {
            Users = new HashSet<Users>();
        }

        public string CardNumberCrypted { get; set; }
        public string RecognizeableName { get; set; }
        public DateTime AddedAt { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
