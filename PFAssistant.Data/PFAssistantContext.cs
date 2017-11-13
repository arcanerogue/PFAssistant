using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using PFAssistant.MongoContext.Properties;

namespace PFAssistant.MongoContext
{
    public class PFAssistantContext
    {
        public MongoDatabase _context;

        public PFAssistantContext()
        {
            var client = new MongoClient(Settings.Default.PFAssistantConnectionString);
            var server = client.GetServer();
            _context = server.GetDatabase(Settings.Default.PFAssistantDatabase);
        }

        public MongoCollection<Spell> Spells
        {
            get
            {
                return _context.GetCollection<Spell>("spells");
            }
        }

        public MongoCollection<DailySpells> DailyMemorizations
        {
            get
            {
                return _context.GetCollection<DailySpells>("dailys");
            }
        }
    }
}
