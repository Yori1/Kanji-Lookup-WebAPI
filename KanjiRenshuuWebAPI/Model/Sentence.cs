using System;
using System.Collections.Generic;
using NMeCab;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.International.Converters;
using System.Globalization;

namespace KanjiRenshuuWebAPI.Model
{
    public class Sentence
    {
        public string JPKanji { get; private set; }
        public string EN { get; private set; }
        public string JPKana { get; private set; }
        public List<Tuple<string, string>> KanjiAndKanaReadingsWords { get; private set; }
        List<Word> ReadingsInSentence { get; set; }

        string[] meCabOutput;

        public Sentence(string jpKanji)
        {
            if(JPKanji!=null)
            {
                JPKanji = JPKanji;
                meCabOutput = getMeCabOutput();
                JPKana = convertToKanaSentence();
            }
        }

        public Sentence(string jpKanji, string english)
        {
            checkForReservedCharacters(jpKanji);
            JPKanji = jpKanji;
            EN = english;
            meCabOutput = getMeCabOutput();
            KanjiAndKanaReadingsWords = getReadingsInSentence();
            JPKana = convertToKanaSentence();
        }

        void checkForReservedCharacters(string sentence)
        {
            if (sentence.Contains("\r\n"))
            {
                throw new ArgumentException("Japanese sentence can't contain reserved characters \r\n");
            }
        }

        string[] getMeCabOutput()
        {
            MeCabTagger tagger = MeCabTagger.Create();
            string outputMeCab = tagger.Parse(JPKanji); // returns output with sentence words separated by "\r\n"
            return outputMeCab.Split("\r\n"); // returns array of sentence words with info that look like "日本語\t名詞,一般,*,*,*,*,日本語,ニホンゴ,ニホンゴ"
        }

        List<Tuple<string,string>> getReadingsInSentence()
        {
            List<Tuple<string, string>> readingsInSentence = new List<Tuple<string,string>>();
            for (int count = 0; count < meCabOutput.Length - 2; count++)
            {
                string wordInfo = meCabOutput[count];
                string[] wordInfoSplit = wordInfo.Split("\t");
                string originalWordReading = wordInfoSplit[0];

                if (!checkIfWordContainsKanji(originalWordReading))
                {
                    readingsInSentence.Add(new Tuple<string, string>(originalWordReading, originalWordReading)); //If the word doesn't contain kanji, it doesn't need to be converted
                }
                else
                {
                    string wordReadingInKatakana = getKanaReadingFromWordInfo(wordInfo);
                    string wordReadingInHiragana = KanaConverter.KatakanaToHiragana(wordReadingInKatakana);
                    readingsInSentence.Add(new Tuple<string, string>(originalWordReading,  wordReadingInHiragana));
                }
            }
            return readingsInSentence;
        }

        string getKanaReadingFromWordInfo(string wordInfo)
        {
            string wordReadingInKana;
            try
            {
                wordReadingInKana = wordInfo.Split(",")[7];
            }

            catch (IndexOutOfRangeException)
            {
                wordReadingInKana = wordInfo.Split("\t")[0];
                //When MeCab finds a punctuation mark, it causes an index out of range exception. The punctuation mark should be added to the sentence in kana as is.
            }
            return wordReadingInKana;
        }

        string convertToKanaSentence()
        {
            string kanaSentence = "";
            foreach(var word in KanjiAndKanaReadingsWords)
            {
                kanaSentence += word.Item2;
            }

            return kanaSentence;
        }


        private bool checkIfWordContainsKanji(string word)
        {
            foreach(char character in word.ToCharArray())
            {
                if(checkIfCharacterIsKanji(character))
                {
                    return true;
                }
            }
            return false;
        }


        bool checkIfCharacterIsKana(char character)
        {
            bool characterIsHiragana = character > 0x3040 && character < 0x309F;
            bool characterIsKatakana = character > 0x30A0 && character < 0x30FF;
            return characterIsHiragana || characterIsKatakana;
        }

        bool checkIfCharacterIsKanji(char character)
        {
            return character > 0x4E00 && character < 0x9FBF;
        }

    }
}
