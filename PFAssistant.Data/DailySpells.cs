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

        [BsonElement("spellsLevel4")]
        public List<string> DailySpellsLevel4 { get; set; }

        [BsonElement("spellsLevel5")]
        public List<string> DailySpellsLevel5 { get; set; }

        [BsonElement("spellsLevel6")]
        public List<string> DailySpellsLevel6 { get; set; }

        [BsonElement("spellsLevel7")]
        public List<string> DailySpellsLevel7 { get; set; }

        [BsonElement("spellsLevel8")]
        public List<string> DailySpellsLevel8 { get; set; }

        [BsonElement("scrollsLevel2")]
        public List<string> ScrollsLevel2{ get; set; }
    }
}
