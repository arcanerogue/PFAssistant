using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFAssistant.Models;
using PFAssistant.Models.PFSpells;

namespace PFAssistant.Models.Interfaces
{
    public interface IPFSpellsRepository
    {
        IEnumerable<PFSpell> GetSpells();
        PFSpell GetSpellById(string id);
    }
}
