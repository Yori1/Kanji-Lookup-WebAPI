using System;
using System.Collections.Generic;
using NMeCab;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.International.Converters;
using System.Globalization;

namespace KanjiRenshuuAPI.Model
{
    public class Sentence
    {
        public int ID { get; private set; }
        public string JPKanji { get; private set; }
        public string JPKana { get; private set; }
        public string EN { get; private set; }
        public List<Word> ReadingsInSentence { get; private set; }

        string[] meCabOutput;

        public Sentence(string jpKanji, string english)
        {
            checkForReservedCharacters(jpKanji);
            JPKanji = jpKanji;
            EN = english;
            meCabOutput = getMeCabOutput();
            ReadingsInSentence = getReadingsInSentence();
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

        List<Word> getReadingsInSentence()
        {
            List<Word> readingsInSentence = new List<Word>();
            for (int count = 0; count < meCabOutput.Length - 2; count++)
            {
                string wordInfo = meCabOutput[count];
                string[] wordInfoSplit = wordInfo.Split("\t");
                string originalWordReading = wordInfoSplit[0];

                if (!checkIfWordContainsKanji(originalWordReading))
                {
                    readingsInSentence.Add(new Word(originalWordReading, originalWordReading)); //If the word doesn't contain kanji, it doesn't need to be converted
                }
                else
                {
                    string wordReadingInKatakana = getKanaReadingFromWordInfo(wordInfo);
                    string wordReadingInHiragana = KanaConverter.KatakanaToHiragana(wordReadingInKatakana);
                    readingsInSentence.Add(new Word(originalWordReading,  wordReadingInHiragana));
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
            foreach(Word word in ReadingsInSentence)
            {
                kanaSentence += word.KanaReading;
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
