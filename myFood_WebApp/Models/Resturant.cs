using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Models
{
    public class Resturant
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Resturant Logo")]
        [Required(ErrorMessage = "Logo is required")]
        public string LogoPicture { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        //Relationships
        public List<Food> Food { get; set; }

    }
}
