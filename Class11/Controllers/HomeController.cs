﻿using Class11.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Class11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string testAjax(string id)
        {
            #region
            // This section replaces a hypothetical access to a data repository
            // (eg. database) for consulting the information
            Dictionary<string, List<string>> allCities = new Dictionary<string, List<string>>();
            allCities.Add("PT", new List<string>() { "Oporto", "Lisbon", "Coimbra" });
            allCities.Add("ES", new List<string>() { "Madrid", "Valencia", "Seville" });
            allCities.Add("FR", new List<string>() { "Paris", "Lille", "Marseille" });
            #endregion

            List<string> items = new List<string>();
            if (id != null && allCities.ContainsKey(id))
                items = allCities[id];

            return JsonConvert.SerializeObject(items);

        }
        public IActionResult Privacy()
        {
            List<string> allTags = new List<string>();
            allTags.Add("Porto");
            allTags.Add("Lisboa");
            allTags.Add("Coimbra");
            allTags.Add("Madrid");
            allTags.Add("Valencia");
            allTags.Add("Sevilla");
            allTags.Add("Paris");
            allTags.Add("Lile");
            allTags.Add("Marseile");

            ViewBag.tags = new HtmlString(JsonConvert.SerializeObject(allTags.ToArray()));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
