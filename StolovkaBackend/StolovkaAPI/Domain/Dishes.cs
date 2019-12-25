using System;
using System.Collections.Generic;

namespace StolovkaWebAPI.Domain
{
    public partial class Dishes
    {
        public string DishId { get; set; }
        public string DishName { get; set; }
        public decimal DishPrice { get; set; }
        public string CanteenId { get; set; }

        public virtual Canteens Canteen { get; set; }
    }
}
