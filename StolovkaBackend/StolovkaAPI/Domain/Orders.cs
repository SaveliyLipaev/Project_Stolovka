using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StolovkaWebAPI.Domain
{
    public partial class Orders
    {
        [Key]
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string CanteenId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public string Description { get; set; }

        public virtual Canteen Canteen { get; set; }
        public virtual Users User { get; set; }
    }
}
