using myFood_WebApp.Data;
using myFood_WebApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Models
{
    public class NewFoodVM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Image")]
        public string FoodPictureURL { get; set; }

        [Display(Description = "Food name")]
        [Required (ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Description = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Description = "Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Description = "Select Food Category")]
        [Required(ErrorMessage = "Food category is required")]
        public FoodCategory FoodCategory { get; set; }

        //Relationships
        [Display(Description = "Select Resutant")]
        [Required(ErrorMessage = "Food resturant is required")]
        public int ResturantID { get; set; }



    }
}
