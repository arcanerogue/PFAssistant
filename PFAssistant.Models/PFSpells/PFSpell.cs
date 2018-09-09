using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace PFAssistant.Models.PFSpells
{
    [BsonIgnoreExtraElements]
    public class PFSpell
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("school")]
        public string School { get; set; }

        [BsonElement("subschool")]
        public string SubSchool { get; set; }

        [BsonElement("descriptor")]
        public string Descriptor { get; set; }

        [BsonElement("spell_level")]
        public string SpellLevel { get; set; }

        [BsonElement("casting_time")]
        public string CastingTime { get; set; }

        [BsonElement("components")]
        public string Components { get; set; }

        [BsonElement("costly_components")]
        public int CostlyComponents { get; set; }

        [BsonElement("range")]
        public string Range { get; set; }

        [BsonElement("area")]
        public string Area { get; set; }

        [BsonElement("effect")]
        public string Effect { get; set; }

        [BsonElement("targets")]
        public string Targets { get; set; }

        [BsonElement("duration")]
        public string Duration { get; set; }

        [BsonElement("dismissable")]
        public int Dismissable { get; set; }

        [BsonElement("shapeable")]
        public int Shapeable { get; set; }

        [BsonElement("saving_throw")]
        public string SavingThrow { get; set; }

        [BsonElement("spell_resistance")]
        public string SpellResistance { get; set; }

        [BsonElement("short_description")]
        public string ShortDescription { get; set; }

        [BsonElement("source")]
        public string Source { get; set; }

        [BsonElement("domain")]
        public string Domain { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        // public List<PFSpellLevel> SpellLevels { get; set; }

        public PFSpell()
        {
            //castingClassFormatter(SpellLevel, SpellLevels);
        }

       /* public static void castingClassFormatter(string level, List<PFSpellLevel> spellLevels)
        {
            if (!String.IsNullOrEmpty(level))
            {
                char[] classDelimiter = { ',' };
                String[] splitClass = level.Split(classDelimiter);

                foreach (String s in splitClass)
                {
                    String trimString = s.Trim();
                    char[] delimiter = { '/', ' ' };
                    String[] splits = trimString.Split(delimiter);

                    //Console.WriteLine(splits[0] + " 6");
                    for (int i = 0; i < splits.Length - 1; i++)
                    {
                        Console.WriteLine("{0} {1}", splits[i], splits[splits.Length - 1]);
                        PFSpellLevel casterLevel = new PFSpellLevel
                        {
                            CastingClass = splits[i],
                            Level = splits[splits.Length - 1]
                        };
                        spellLevels.Add(casterLevel);
                    }
                }
            }
        } */
    }
}

