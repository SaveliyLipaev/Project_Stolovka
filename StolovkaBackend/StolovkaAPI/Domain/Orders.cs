using System;
using System.Collections.Generic;

namespace StolovkaWebAPI.Domain
{
    public partial class Orders
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string CanteenId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public string Description { get; set; }

        public virtual Canteens Canteen { get; set; }
        public virtual Users User { get; set; }
    }
}
