using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StolovkaWebAPI.Domain
{
    public partial class Cards
    {
        [Key]
        public string CardNumberCrypted { get; set; }
        public string RecognizeableName { get; set; }
        public DateTime AddedAt { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
