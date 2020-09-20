using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrewBuddyCore.Models;

namespace BrewBuddyCore.Data
{
    public class BrewBuddyCoreContext : DbContext
    {
        public BrewBuddyCoreContext (DbContextOptions<BrewBuddyCoreContext> options)
            : base(options)
        {
        }

        public DbSet<BrewBuddyCore.Models.Brew> Brew { get; set; }

        public DbSet<BrewBuddyCore.Models.Ingredient> Ingredient { get; set; }

        public DbSet<BrewBuddyCore.Models.Note> Note { get; set; }

        public DbSet<BrewBuddyCore.Models.Step> Step { get; set; }
    }
}
