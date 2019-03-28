using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using PFAssistant.MongoContext;
using PFAssistant.Models;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using PFAssistant.Models.PFDailys;
using PFAssistant.MongoContext.PFDailys;
using System.Threading.Tasks;

namespace PFAssistant.Controllers
{
    public class DailysController : Controller
    {
        public readonly PFDailysRepository dailysRepo = new PFDailysRepository();

        // GET: Dailys
        [HttpGet]
        public ActionResult Dailys()
        {
            var dailysModel = dailysRepo.GetDailys();
            return View(dailysModel.First());
        }
    }
}