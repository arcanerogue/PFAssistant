using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFAssistant.Data.Entities
{
    public class Spell
    {
        public string Name { get; set; }
        public string School { get; set; }
        public string SubSchool { get; set; }
        public string Descriptor { get; set; }
        public string SpellLevel { get; set; }
        public string CastingTime { get; set; }
        public string Components { get; set; }

        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
}
