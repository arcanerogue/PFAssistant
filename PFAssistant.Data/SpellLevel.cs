using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PFAssistant.MongoContext
{
    //[BsonIgnoreExtraElements]
    public class SpellLevel
    {
       // [BsonElement("class")]
        public string CastingClass { get; set; }

        //[BsonElement("level")]
        public string Level { get; set; }
    }
}