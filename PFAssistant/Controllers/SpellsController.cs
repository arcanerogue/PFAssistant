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
        public ActionResult SpellList(string name, string filter, int? page, int? pageSize)
        {
            var pageNumber = page ?? 1;

            if (name != null)
                page = 1;
            else
                name = filter;

            //(name != null) ? page = 1 : name = filter;

            ViewBag.Filter = name;

            //var spells = db.Spells.FindAll()
            //                .AsQueryable()
            //                .OrderBy(t => t.Name);
                        
            if (!string.IsNullOrEmpty(name))
            {
                // Query the MongoDB collection while ignoring the case of the search string
                //var query = Query.Matches("name", new BsonRegularExpression(name, "i"));
                //var results = db.Spells.Find(query)
                //                    .AsQueryable()
                //                    .OrderBy(t => t.Name);

                var results = db.Spells.AsQueryable()
                                       .Where(s => s.Name.ToLower().Contains(name))
                                       .OrderBy(t => t.Name);


                //spells = results.OrderBy(t => t.Name);
                return View(results.ToPagedList(pageNumber, 10));
            }

            //var model = spells.ToPagedList(pageNumber, 10);
            else
            {
                return View(db.Spells.FindAll()
                        .AsQueryable()
                        .OrderBy(t => t.Name)
                        .ToPagedList(pageNumber, 10));
            }
        }

        //public ActionResult SpellList(SearchCriteria search, int? page, int? pageSize)
        //{
        //    SpellSearchModel model = new SpellSearchModel();
        //    var pageNumber = page ?? 1;

        //    var spells = db.Spells;
        //    IQueryable<Spell> results = spells.AsQueryable();
        //    //.FindAll();
        //    //.AsQueryable();
        //    //.OrderBy(t => t.Name);

        //    if (!string.IsNullOrEmpty(search.Name))
        //    {
        //        //var query = Query.Matches("name", new BsonRegularExpression(search.Name, "i"));
        //        //results = results.Find(query).AsQueryable();
        //        results = results.Where(t => t.Name.Contains(search.Name))
        //                         .OrderBy(t => t.Name);
        //    }

        //    model.PagedSpellList = results.ToPagedList(pageNumber, 10);
        //    model.SearchValues = search;

        //    return View(model);
        //}

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