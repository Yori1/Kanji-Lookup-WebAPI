using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanjiRenshuuWebAPI.Model
{
    public class ExampleSentence: Sentence
    {
        public string EN { get; private set; }

        public ExampleSentence(string jpKanji, string enSentence):base(jpKanji)
        {
            EN = enSentence;
        }
    }
}
