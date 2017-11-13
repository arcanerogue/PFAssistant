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

        public ActionResult Index()
        {
            return View();
        }

        // GET:Spells/
        public ActionResult SpellList(SearchCriteria search, string nameFilter, string schoolFilter, string Classfilter, int? page, int? pageSize)
        {
            SpellSearchModel model = new SpellSearchModel();
            var pageNumber = page ?? 1;

            if (search.Name != null || search.School != null || search.Class != null)
                page = 1;
            else
            {                
                search.Name = nameFilter;
                search.School = schoolFilter;
                search.Class = Classfilter;
            }             
       
            model.SearchValues = search;
            var results = db.Spells.FindAll()
                                   .AsQueryable();

            if (!String.IsNullOrEmpty(model.SearchValues.Name))
            {
                // Query the MongoDB collection while ignoring the case of the search string
                results = results.Where(s => s.Name.ToLower()
                                 .Contains(search.Name.ToLower()))
                                 .OrderBy(t => t.Name);
            }

            if (!String.IsNullOrEmpty(model.SearchValues.School))
            {
                results = results.Where(s => s.School.ToLower()
                                 .Contains(search.School.ToLower()))
                                 .OrderBy(t => t.Name);
            }

            if (!String.IsNullOrEmpty(model.SearchValues.Class))
            {
                results = results.Where(s => s.SpellLevel.ToLower()
                                 .Contains(search.Class.ToLower()))
                                 .OrderBy(t => t.Name);
            }
            model.PagedSpellList = results.ToPagedList(pageNumber, 10);

            return View(model);
        }


        // GET:Spells/{id}
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
                    Description = query.Description,
                    Source = query.Source
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