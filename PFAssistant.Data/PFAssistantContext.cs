using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using PFAssistant.MongoContext.Properties;
using PFAssistant.Models.PFSpells;
using PFAssistant.Models.PFDailys;

namespace PFAssistant.MongoContext
{
    public class PFAssistantContext
    {
        public IMongoDatabase _context;


        public PFAssistantContext()
        {
            var client = new MongoClient(Settings.Default.PFAssistantConnectionString);
            _context = client.GetDatabase(Settings.Default.PFAssistantDatabase);
        }

        public IMongoCollection<PFSpell> Spells
        {
            get
            {
                return _context.GetCollection<PFSpell>("spells");
            }
        }

        public IMongoCollection<PFDailySpells> DailyMemorizations
        {
            get
            {
                return _context.GetCollection<PFDailySpells>("dailys");
            }
        }
    }
}
