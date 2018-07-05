using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KanjiRenshuuAPI.Handlers;
using KanjiRenshuuAPI.Model;

namespace KanjiRenshuuAPI.Controllers
{
    [Route("api/[controller]")]
    public class SentencesController : Controller
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