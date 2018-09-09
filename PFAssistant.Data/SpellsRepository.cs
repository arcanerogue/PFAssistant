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

namespace PFAssistant.MongoContext
{
    public class SpellsRepository : ISpellsRepository
    {
        public readonly PFAssistantContext db = new PFAssistantContext();

        public IEnumerable<PFSpell> GetSpells()
        {
            //var results = db.Spells.FindAll().AsQueryable();
            var results = db.Spells
                .Find(Builders<PFSpell>.Filter.Empty)
                .SortBy(s => s.Name)
                .ToList();
            return results;
        }

        public PFSpell FindSpellById(string id)
        {
            //var spellQuery = db.Spells.AsQueryable();
            //var query = spellQuery.Where(s => s.Id == id).FirstOrDefault();
            var query = db.Spells
                .Find(s => s.Id == id)
                .FirstOrDefault();
            return query;
        }
    }
}
