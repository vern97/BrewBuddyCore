using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewBuddyCore.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public decimal Amount { get; set; }
        public string IngredientName { get; set; }
        public int BrewID { get; set; }
        public Brew Brew { get; set; }
    }
}
