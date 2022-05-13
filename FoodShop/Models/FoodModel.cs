using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShop.Models
{
    public class FoodModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Vegetarian { get; set; }
        public bool Vegan { get; set; }
        public bool GlutenFree { get; set; }

        // Default constructor.
        public FoodModel()
        {
            Id = 1;
            Name = "Blank";
            Price = 1;
            Vegetarian = false;
            Vegan = false;
            GlutenFree = false;
        }

        // No parameter constructor
        public FoodModel(int id, string name, decimal price, bool vegetarian, bool vegan, bool glutenFree)
        {
            Id = id;
            Name = name;
            Price = price;
            Vegetarian = vegetarian;
            Vegan = vegan;
            GlutenFree = glutenFree;
        }

    }
}