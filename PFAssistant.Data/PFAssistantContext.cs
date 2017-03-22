using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PFAssistant.Data.Entities;

namespace PFAssistant.Data
{
    public class PFAssistantContext : DbContext
    {
        public DbSet<Spell> Spells { get; set; }
    }
}
