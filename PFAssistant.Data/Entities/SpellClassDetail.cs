using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFAssistant.Data.Entities
{
    public class SpellClassDetail
    {
        public int SpellClassId { get; set; }
        public int SpellId { get; set; }
        public int CastingClassId { get; set; }
        public int CastingClassLevel { get; set; }
    }
}
