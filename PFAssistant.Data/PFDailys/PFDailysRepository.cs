using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFAssistant.Models.Interfaces;
using PFAssistant.Models.PFDailys;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace PFAssistant.MongoContext.PFDailys
{
    public class PFDailysRepository : IPFDailysRepository
    {
        public readonly PFAssistantContext db = new PFAssistantContext();

        public IEnumerable<PFDailySpells> GetDailys()
        {
            var result = db.DailyMemorizations
                .Find(Builders<PFDailySpells>.Filter.Empty)
                .ToList();

            return result;
        }
    }
}
