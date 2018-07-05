using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KanjiRenshuuWebAPI.Controllers;
using KanjiRenshuuWebAPI.Model;
using KanjiRenshuuWebAPI.Handlers;


namespace KanjiRenshuuWebAPI.Controllers
{
    public class ToKanaController : Controller
    {
        DatabaseHandler databaseHandler = new DatabaseHandler();


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{word}")]
        public Sentence GetSentences(string word)
        {
            return new Sentence(word);
        }
    }
}