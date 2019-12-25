using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StolovkaWebAPI.Domain
{
    public partial class Dish
    {
        [Key]
        public string DishId { get; set; }
        public string DishName { get; set; }
        public decimal DishPrice { get; set; }
        public string CanteenId { get; set; }

        public virtual Canteen Canteen { get; set; }
    }
}
