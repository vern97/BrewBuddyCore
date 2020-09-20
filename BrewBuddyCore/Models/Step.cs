using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewBuddyCore.Models
{
    public class Step
    {
        public int StepID { get; set; }
        public string StepNote { get; set; }
        public int BrewID { get; set; }
        public Brew Brew { get; set; }
    }
}
