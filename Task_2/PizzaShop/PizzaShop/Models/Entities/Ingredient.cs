using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models.Entities
{
    public class Ingredient : EntityBase
    {
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "The field Name should only include letters and number.")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; } = new HashSet<PizzaIngredient>();

    }
}