using System;
using System.Web.Mvc;
using System.Net;
using PFAssistant.Models;
using X.PagedList;
using PFAssistant.Models.PFSpells;
using PFAssistant.MongoContext.PFSpells;
using System.Threading.Tasks;
using PFAssistant.Models.Interfaces;

namespace PFAssistant.Controllers
{
    public class SpellsController : Controller
    {
        public PFSpellsRepository spellsRepo = new PFSpellsRepository();

        // Spells/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchSpells()
        {
            PFSpellsFilter model = new PFSpellsFilter();
            return PartialView("SpellSearchFormPartial", model);
        }

        /*public async Task<ActionResult> SearchSpellsForm(PFSpellsFilter search)
        {
            SpellSearchModel model = new SpellSearchModel();

            var pageNumber = 1;
            model.SearchValues = search;

            var results = await spellsRepo.GetSpellsByFilter(search);

            model.PagedSpellList = results.ToPagedList(pageNumber, 10);

            return PartialView("SpellSearchFormPartial", model);
        }*/

        
        public async Task<ActionResult> SearchSpellsResults(PFSpellsFilter search, string nameFilter, string schoolFilter, 
            string classFilter, int? page, int? pageSize)
        {
            SpellSearchModel model = new SpellSearchModel();

            int resultsSize = pageSize ?? 5;
            var pageNumber = page ?? 1;

            if (search.Name != null || search.School != null || search.CharacterClass != null)
                page = 1;
            else
            {                
                search.Name = nameFilter;
                search.School = schoolFilter;
                search.CharacterClass = classFilter;
            }

            /*model.SearchValues.Name = nameFilter;
            model.SearchValues.School = schoolFilter;
            model.SearchValues.CharacterClass = classFilter;*/
            model.SearchValues = search;
            var results = await spellsRepo.GetSpellsByFilter(search);

            model.PagedSpellList = results.ToPagedList(pageNumber, resultsSize);

            return PartialView("SpellSearchResultsPartial", model);
        }

        // GET:Spells/{id}
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