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
using X.PagedList.Mvc;
using X.PagedList;

namespace PFAssistant.Controllers
{    
    public class SpellsController : Controller
    {
        public readonly PFAssistantContext db = new PFAssistantContext();

        // GET: Spells
        public ActionResult SpellList(int? page, int? pageSize)
        {
            var pageNumber = page ?? 1;

            var spells = db.Spells.FindAll()
                           .AsQueryable()
                           .OrderBy(t => t.Name);

            var model = spells.ToPagedList(pageNumber, 10);

            return View(model);
        }

        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IQueryable<Spell> spellQuery = db.Spells.AsQueryable(); 

            var query = spellQuery.Where(s => s.Id == id).FirstOrDefault();

            if (query != null && !String.IsNullOrEmpty(query.Id))
            {
                SpellDetails spellDetails = new SpellDetails
                {
                    Id = query.Id,
                    Name = query.Name,
                    School = query.School,
                    SubSchool = query.SubSchool,
                    Descriptor = query.Descriptor,
                    SpellLevel = query.SpellLevel,
                    CastingTime = query.CastingTime,
                    Components = query.Components,
                    Range = query.Range,
                    Area = query.Area,
                    Effect = query.Effect,
                    Duration = query.Duration,
                    SavingThrow = query.SavingThrow,
                    Description = query.Description
                };
                return View(spellDetails);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}