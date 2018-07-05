using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KanjiRenshuuWebAPI.Model;
using KanjiRenshuuWebAPI.Handlers;

namespace KanjiRenshuuWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ExampleController : Controller
    {
         DatabaseHandler databaseHandler = new DatabaseHandler();

        [HttpGet("{word}")]
        public List<Sentence> GetSentences(string word)
        {
            List<Sentence> sentences = databaseHandler.GetSentences(word);
            return sentences;
        }
    }
}