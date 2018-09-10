using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFAssistant.Models.PFDailys;

namespace PFAssistant.Models.Interfaces
{
    public interface IPFDailysRepository
    {
        IEnumerable<PFDailySpells> GetDailys();
    }
}
