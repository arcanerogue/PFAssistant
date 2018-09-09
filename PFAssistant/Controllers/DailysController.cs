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

namespace PFAssistant.Controllers
{
    public class DailysController : Controller
    {
        public readonly PFAssistantContext db = new PFAssistantContext();

        // GET: Dailys
        public ActionResult Dailys()
        {
            //var result = db.DailyMemorizations.FindAll().AsQueryable().ToList();
            var result = db.DailyMemorizations
                .Find(Builders<DailySpells>.Filter.Empty)
                .ToList();

            var dailysModel = result.First();

            return View(dailysModel);
        }
    }
}