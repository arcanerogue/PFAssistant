using PFAssistant.MongoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace PFAssistant.Models
{
    public class SpellSearchModel
    {
        public SearchCriteria SearchValues { get; set; }
        public IPagedList<Spell> PagedSpellList { get; set; }
    }
}