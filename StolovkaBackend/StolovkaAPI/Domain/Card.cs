using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StolovkaWebAPI.Domain
{
    public partial class Card
    {
        [Key]
        public string CardNumberCrypted { get; set; }
        public string RecognizeableName { get; set; }
        public DateTime AddedAt { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
