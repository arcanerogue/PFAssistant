using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFAssistant.Models;
using PFAssistant.Models.PFSpells;

namespace PFAssistant.Models.Interfaces
{
    public interface ISpellsRepository
    {
        IEnumerable<PFSpell> GetSpells();
        PFSpell FindSpellById(string id);
    }
}
