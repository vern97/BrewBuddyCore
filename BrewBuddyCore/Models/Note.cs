using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BrewBuddyCore.Models
{
    public class Note
    {
        public int NoteID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateLogged { get; set; }
        public string NoteDescription { get; set; }
        public int BrewID { get; set; }
        public Brew Brew { get; set; }
    }
}
