﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using myFood_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Resturant
                if (!context.Resturants.Any())
                {
                    context.Resturants.AddRange(new List<Resturant>()
                    {
                        new Resturant()
                        {
                            Name = "Resturant 11",
                            Address = "Address 1",
                            LogoPicture = "https://thumbs.dreamstime.com/z/restaurant-logo-design-idea-chef-hat-fork-graphic-leaf-shape-food-drinks-symbol-concept-cooking-eating-vector-template-173237325.jpg",
                        },

                        new Resturant()
                        {
                            Name = "Resturant 2",
                            Address = "Address 2",
                            LogoPicture = "https://png.pngtree.com/png-clipart/20200727/original/pngtree-restaurant-logo-design-vector-template-png-image_5441058.jpg"
                        },

                        new Resturant()
                        {
                            Name = "Resturant 3",
                            Address = "Address 3",
                            LogoPicture = "https://png.pngtree.com/png-vector/20190512/ourlarge/pngtree-elegant-restaurant-food-and-drink-logo-design-png-image_1033624.jpg"
                        },



                    });
                    context.SaveChanges();
                }

                //Food
                if (!context.Foods.Any())
                {
                    context.Foods.AddRange(new List<Food>()
                    {
                        new Food()
                        {
                            Name = "Food 1",
                            Price = 12.24,
                            Description = "Description 1",
                            FoodCategory = FoodCategory.Burger,
                            FoodPictureURL = "https://athensstreetfoodfestival.gr/wp-content/uploads/2022/05/BURGER-JOINT-ASFF.jpg",
                            ResturantID = 1,
                        },

                        new Food()
                        {
                            Name = "Food 2",
                            Price = 23.2,
                            Description = "Description 2",
                            FoodCategory = FoodCategory.Pizza,
                            FoodPictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg/390px-Eq_it-na_pizza-margherita_sep2005_sml.jpg",
                            ResturantID = 2,
                        },

                        new Food()
                        {
                            Name = "Food 3",
                            Price = 34.0,
                            Description = "Description 3",
                            FoodCategory = FoodCategory.Beverage,
                            FoodPictureURL = "https://cdnprod.mafretailproxy.com/sys-master-root/hc9/he7/14149307760670/557037_main.jpg_480Wx480H",
                            ResturantID = 3,
                        },


                    });
                    context.SaveChanges();
                }
            }
        }
    }
}