using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models.Entities
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        public List<OrderDetail> OrderLines { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(100)]
        [Display(Name = "Address 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your zip code")]
        [Display(Name = "Zip code")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(50)]
        public string City { get; set; }

        [StringLength(10)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        [StringLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress,
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [DisplayName("Order Total")]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [DisplayName("Order Date")]
        public DateTime OrderPlaced { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }
        
    }
}
