using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PFAssistant.MongoContext;
using PFAssistant.Models.PFSpells;

namespace PFAssistant.Models
{
    public class SpellDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }        
        public string School { get; set; }

        [Display(Name = "Subschool")]
        public string SubSchool { get; set; }
        public string Descriptor { get; set; }

        [Display(Name = "Level")]
        public string SpellLevel { get; set; }

        [Display(Name = "Casting Time")]
        public string CastingTime { get; set; }
        public string Components { get; set; }
        public string Range { get; set; }
        public string Area { get; set; }
        public string Effect { get; set; }
        public string Duration { get; set; }

        [Display(Name = "Saving Throw")]
        public string SavingThrow { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }

        public SpellDetails(PFSpell spell)
        {
            Id = spell.Id;
            Name = spell.Name;
            School = spell.School;
            SubSchool = spell.SubSchool;
            Descriptor = spell.Descriptor;
            SpellLevel = spell.SpellLevel;
            CastingTime = spell.CastingTime;
            Components = spell.Components;
            Range = spell.Range;
            Area = spell.Area;
            Effect = spell.Effect;
            Duration = spell.Duration;
            SavingThrow = spell.SavingThrow;
            Description = spell.Description;
            Source = spell.Source;
        }
    }
}