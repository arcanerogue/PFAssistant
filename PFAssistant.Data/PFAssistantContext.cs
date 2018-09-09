using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using PFAssistant.MongoContext.Properties;
using PFAssistant.Models.PFSpells;

namespace PFAssistant.MongoContext
{
    public class PFAssistantContext
    {
        //public MongoDatabase _context;
        public IMongoDatabase _context;


        public PFAssistantContext()
        {
            /*var client = new MongoClient(Settings.Default.PFAssistantConnectionString);
            var server = client.GetServer();
            _context = server.GetDatabase(Settings.Default.PFAssistantDatabase);*/
            var client = new MongoClient(Settings.Default.PFAssistantConnectionString);
            _context = client.GetDatabase(Settings.Default.PFAssistantDatabase);
        }

        //public MongoCollection<PFSpell> Spells
        public IMongoCollection<PFSpell> Spells
        {
            get
            {
                return _context.GetCollection<PFSpell>("spells");
            }
        }

        //public MongoCollection<DailySpells> DailyMemorizations
        public IMongoCollection<DailySpells> DailyMemorizations
        {
            get
            {
                return _context.GetCollection<DailySpells>("dailys");
            }
        }
    }
}
