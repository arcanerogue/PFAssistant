using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
    }
}