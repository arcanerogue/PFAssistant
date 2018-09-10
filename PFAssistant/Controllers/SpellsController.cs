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
using PFAssistant.MongoContext.PFSpells;
using System.Threading.Tasks;

namespace PFAssistant.Controllers
{    
    public class SpellsController : Controller
    {
        // public readonly PFAssistantContext db = new PFAssistantContext();
        public PFSpellsRepository spellsRepo = new PFSpellsRepository();

        public ActionResult Index()
        {
            //SearchCriteria model = new SearchCriteria();
            PFSpellsFilter model = new PFSpellsFilter();
            return View("Index", model);
        }

        // GET:Spells/
        [HttpGet]
        public async Task<ActionResult> SpellList(PFSpellsFilter search, string nameFilter, string schoolFilter, 
            string classFilter, int? page, int? pageSize)
        {
            SpellSearchModel model = new SpellSearchModel();
            var pageNumber = page ?? 1;

            if (search.Name != null || search.School != null || search.CharacterClass != null)
                page = 1;
            else
            {                
                search.Name = nameFilter;
                search.School = schoolFilter;
                //search.Class = classFilter;
                search.CharacterClass = classFilter;
            }             
       
            model.SearchValues = search;
            //var results = search.filterResults();
            var results = await spellsRepo.GetSpellsByFilter(search);

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

            var query = spellsRepo.GetSpellById(id);

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