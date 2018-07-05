using System;
using System.Collections.Generic;
using System.Text;

namespace KanjiRenshuuWebAPI.Model
{
   public class Word
    {
        public string OriginalReading { get; private set; }
        public string KanaReading { get; private set; }

        public Word(string originalWord, string wordKana)
        {
            OriginalReading = originalWord;
            KanaReading = wordKana;
        }
    }
}
