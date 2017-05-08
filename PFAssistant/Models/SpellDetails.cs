﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFAssistant.Models
{
    public class SpellDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }        
        public string School { get; set; }        
        public string SubSchool { get; set; }
        public string SpellLevel { get; set; }
        public string Components { get; set; }
        public string Description { get; set; }
    }
}