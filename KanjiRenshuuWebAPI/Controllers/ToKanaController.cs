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
    [Route("api/[controller]")]
    public class ToKanaController : Controller
    {
        DatabaseHandler databaseHandler = new DatabaseHandler();

        [HttpGet("{word}")]
        public SentenceViewModel GetSentences(string word)
        {
            if (word == null)
                return null;

            Sentence sentence = new Sentence(word);
            SentenceViewModel sentenceViewModel = new SentenceViewModel(sentence);
            return sentenceViewModel;
        }
    }
}