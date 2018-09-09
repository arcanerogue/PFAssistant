using PFAssistant.MongoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PFAssistant.Models.PFSpells;

namespace PFAssistant.Models
{
    public class SearchCriteria
    {
        public string Name { get; set; }
        public string School { get; set; }
        public string Class { get; set; }
        // public readonly PFAssistantContext db = new PFAssistantContext();
        public SpellsRepository spellsRepo = new SpellsRepository();

        public IEnumerable<PFSpell> filterResults()
        {
            //var results = db.Spells.FindAll()
            //                     .AsQueryable();

            var results = spellsRepo.GetSpells();

            if (!String.IsNullOrEmpty(Name))
            {
                // Query the MongoDB collection while ignoring the case of the search string
                results = results.Where(s => s.Name.ToLower()
                                 .Contains(Name.ToLower()))
                                 .OrderBy(t => t.Name);
            }

            if (!String.IsNullOrEmpty(School))
            {
                results = results.Where(s => s.School.ToLower()
                                 .Contains(School.ToLower()))
                                 .OrderBy(t => t.Name);
            }

            if (!String.IsNullOrEmpty(Class))
            {
                results = results.Where(s => s.SpellLevel.ToLower()
                                 .Contains(Class.ToLower()))
                                 .OrderBy(t => t.Name);
            }
            return results;
        }
    }
}