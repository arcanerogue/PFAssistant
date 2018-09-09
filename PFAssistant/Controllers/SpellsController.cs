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
using PFAssistant.Models.PFSpells;

namespace PFAssistant.Controllers
{    
    public class SpellsController : Controller
    {
        // public readonly PFAssistantContext db = new PFAssistantContext();
        public SpellsRepository spellsRepo = new SpellsRepository();

        public ActionResult Index()
        {
            SearchCriteria model = new SearchCriteria();
            return View("Index", model);
        }

        // GET:Spells/
        [HttpGet]
        public ActionResult SpellList(SearchCriteria search, string nameFilter, string schoolFilter, 
            string classFilter, int? page, int? pageSize)
        {
            SpellSearchModel model = new SpellSearchModel();
            var pageNumber = page ?? 1;

            if (search.Name != null || search.School != null || search.Class != null)
                page = 1;
            else
            {                
                search.Name = nameFilter;
                search.School = schoolFilter;
                search.Class = classFilter;
            }             
       
            model.SearchValues = search;
            var results = search.filterResults();

            model.PagedSpellList = results.ToPagedList(pageNumber, 10);

            return View(model);
            //return PartialView("SpellSearchResultsPartial", model);
        }


        // GET:Spells/{id}
        [HttpGet]
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id)){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var query = spellsRepo.FindSpellById(id);

            if (query != null && !String.IsNullOrEmpty(query.Id))
            {
                SpellDetails spellDetails = new SpellDetails(query);               
                return View(spellDetails);
            }
            else {
                return HttpNotFound();
            }
        }
    }
}