using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateMyPokemon.Models;

namespace RateMyPokemon.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public String Index(int number)
        {
            return $"Hello World, your number is {number}";
        }

        public ActionResult GetInput()
        {
            return View();
        }

        public JsonResult AfterInput(Pokemon pokes)
        {
            PokemonDbContext database = new PokemonDbContext();
            database.Pokemans.Add(pokes);
            database.SaveChanges();
            return Json(pokes);
        }

        public JsonResult AllPokemon()
        {
            PokemonDbContext database = new PokemonDbContext();
            return Json(database.Pokemans.OrderBy(x => x.Name).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}