using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanjiRenshuuWebAPI.Model
{
    public class ExampleSentenceViewModel: SentenceViewModel
    {
        public string English { get; set; }

        public ExampleSentenceViewModel(ExampleSentence sentence):base (sentence)
        {
            English = sentence.EN;
        }
    }
}
