using System.ComponentModel;
using PizzaShop.Models.Entities;

namespace PizzaShop.Models.Entities
{
    public class PizzaIngredient : EntityBase
    {
        [DisplayName("Select Pizza")]
        public int PizzaId { get; set; }

        public virtual Pizza Pizza { get; set; }

        [DisplayName("Select Ingredient")]
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}