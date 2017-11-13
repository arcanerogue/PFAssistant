using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PFAssistant.MongoContext
{
    [BsonIgnoreExtraElements]
    public class DailySpells
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string CharacterName { get; set; }

        [BsonElement("spellsLevel0")]
        public List<string> DailySpellsLevel0 { get; set; }

        [BsonElement("spellsLevel1")]
        public List<string> DailySpellsLevel1 { get; set; }

        [BsonElement("spellsLevel2")]
        public List<string> DailySpellsLevel2 { get; set; }

        [BsonElement("spellsLevel3")]
        public List<string> DailySpellsLevel3 { get; set; }

        [BsonElement("scrollsLevel2")]
        public List<string> ScrollsLevel2{ get; set; }
    }
}
