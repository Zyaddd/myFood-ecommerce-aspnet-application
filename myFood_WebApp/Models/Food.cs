using myFood_WebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string FoodPictureURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public FoodCategory FoodCategory { get; set; }

        //Relationships
        public int ResturantID { get; set; }
        [ForeignKey("ResturantID")]
        public Resturant Resturant { get; set; }




    }
}
