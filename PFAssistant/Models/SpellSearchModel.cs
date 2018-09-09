using PFAssistant.MongoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;
using PFAssistant.Models.PFSpells;

namespace PFAssistant.Models
{
    public class SpellSearchModel
    {
        public SearchCriteria SearchValues { get; set; }
        public IPagedList<PFAssistant.Models.PFSpells.PFSpell> PagedSpellList { get; set; }
    }
}