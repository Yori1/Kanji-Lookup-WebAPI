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
        public List<ExampleSentenceViewModel> GetSentences(string word)
        {
            if (word == null)
                return null;
            List<ExampleSentence> sentences = databaseHandler.GetSentences(word);
            List<ExampleSentenceViewModel> viewModels = new List<ExampleSentenceViewModel>();
            foreach(ExampleSentence sentence in sentences)
            {
                viewModels.Add(new ExampleSentenceViewModel(sentence));
            }
            return viewModels;
        }
    }
}