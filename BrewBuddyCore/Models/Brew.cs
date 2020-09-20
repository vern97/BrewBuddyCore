using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BrewBuddyCore.Models
{
    public class Brew
    {
        public int BrewID { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Name of Brew")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }
        [Display(Name = "Style")]
        public string Style { get; set; }
        [Display(Name = "Yield")]
        public decimal Yield { get; set; }
        [Display(Name = "Original Gravity")]
        public decimal OriginalGravity { get; set; }
        [Display(Name = "Final Gravity")]
        public decimal FinalGravity { get; set; }
        [Display(Name = "ABV")]
        public decimal ABV { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Note> Notes { get; set; }
        public List<Step> Steps { get; set; }
    }
}
