using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using PFAssistant.MongoContext;
using System.Net;
using PFAssistant.Models;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace PFAssistant.Controllers
{    
    public class SpellsController : Controller
    {
        public readonly PFAssistantContext db = new PFAssistantContext();

        // GET: Spells
        public ActionResult SpellList()
        {
            var spells = db.Spells.FindAll().AsQueryable();
            var model = spells.Take(10);

            return View(model);
        }

        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IQueryable<Spell> spellQuery = db.Spells.AsQueryable();

            var query = spellQuery.Where(s => s.Id == id).First();

            SpellDetails spellDetails = new SpellDetails
            {
                Id = query.Id,
                Name = query.Name,
                School = query.School,
                SubSchool = query.SubSchool,
                Components = query.Components,
                Description = query.Description
            };

            if(spellDetails == null)
            {
                return HttpNotFound();
            }

            return View(spellDetails);
        }
    }
}