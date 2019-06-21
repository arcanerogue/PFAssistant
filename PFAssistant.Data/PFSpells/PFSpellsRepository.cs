using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFAssistant.Models.Interfaces;
using PFAssistant.Models.PFSpells;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace PFAssistant.MongoContext.PFSpells
{
    public class PFSpellsRepository : IPFSpellsRepository
    {
        public readonly PFAssistantContext db = new PFAssistantContext();

        public IEnumerable<PFSpell> GetSpells()
        {
            var results = db.Spells
                .Find(Builders<PFSpell>.Filter.Empty)
                .SortBy(s => s.Name)
                .ToList();
            return results;
        }

        public async Task<IEnumerable<PFSpell>> GetSpellsByFilter(PFSpellsFilter filter)
        {
            var results = db.Spells.AsQueryable();

            if (!String.IsNullOrEmpty(filter.Name))
            {
                // Query the MongoDB collection while ignoring the case of the search string
                results = results.Where(s => s.Name.ToLower()
                                 .Contains(filter.Name.ToLower()))
                                 .OrderBy(t => t.Name);                                 
            }

            if (!String.IsNullOrEmpty(filter.School))
            {
                results = results.Where(s => s.School.ToLower()
                                 .Contains(filter.School.ToLower()))
                                 .OrderBy(t => t.Name);
            }

            if (!String.IsNullOrEmpty(filter.CharacterClass))
            {
                results = results.Where(s => s.SpellLevel.ToLower()
                                 .Contains(filter.CharacterClass.ToLower()))
                                 .OrderBy(t => t.Name);
            }
            return await results.ToListAsync();
        }

        public PFSpell GetSpellById(string id)
        {
            var query = db.Spells
                .Find(s => s.Id == id)
                .FirstOrDefault();
            return query;
        }
    }
}
