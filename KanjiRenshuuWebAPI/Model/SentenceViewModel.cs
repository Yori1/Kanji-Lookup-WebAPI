using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanjiRenshuuWebAPI.Model
{
    public class SentenceViewModel
    {
        public string Kanji { get; private set; }
        public string Kana { get; private set; }
        public string[] SeperatedByWordsOriginal { get; private set; }
        public string[] SeperatedByWordsKana { get; private set; }

        public SentenceViewModel(Sentence sentence)
        {
            Kanji = sentence.JPKanji;
            Kana = sentence.JPKana;
            List<Tuple<string, string>> readings = sentence.KanjiAndKanaReadingsWords;
            SeperatedByWordsKana = new string[sentence.KanjiAndKanaReadingsWords.Count];
            SeperatedByWordsOriginal = new string[sentence.KanjiAndKanaReadingsWords.Count];
            for(int x=0; x<readings.Count; x++) 
            {
                var tuple = readings[x];
                SeperatedByWordsOriginal[x] = tuple.Item1;
                SeperatedByWordsKana[x] = tuple.Item2;
            }
        }
    }
}
