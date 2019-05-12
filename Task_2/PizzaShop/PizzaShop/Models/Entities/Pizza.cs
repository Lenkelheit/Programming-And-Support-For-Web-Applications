using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models.Entities
{
    public class Pizza : EntityBase
    {
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "The field Name should only include letters and number.")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [Range(0, 1000)]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }

        [StringLength(255, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public bool IsPizzaOfTheWeek { get; set; }

        [DisplayName("Select Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; } = new HashSet<PizzaIngredient>();
        public virtual ICollection<Reviews> Reviews { get; set; } = new HashSet<Reviews>();
    }
}
