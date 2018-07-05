using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KanjiRenshuuAPI.Model;

namespace KanjiRenshuuAPITests
{
    [TestClass]
    public class SentenceClassTest
    {
        [TestMethod]
        public void TestBasicSentence()
        {
            string jpSentence = "日本語の文章です。";
            string enSentence = "This is an English sentence.";
            Sentence sentence = new Sentence(jpSentence, enSentence);
            Assert.IsTrue(sentence.JPKana == "にほんごのぶんしょうです。");
        }

        [TestMethod]
        public void TestKatakana()
        {
            string jpSentenceKatakana = "カタカナが入っている文章です。";
            string enSentenceKatakana = "This is a sentence with katakana in it.";
            Sentence sentenceKatakana = new Sentence(jpSentenceKatakana, enSentenceKatakana);
            Assert.IsTrue(sentenceKatakana.JPKana == "カタカナがはいっているぶんしょうです。");
        }

        [TestMethod]
        public void TestSymbols()
        {
            string jpSentence = "!>@#:'。？：";
            string enSentence = "!>@#:'。？：";
            Sentence sentence = new Sentence(jpSentence, enSentence);
            Assert.IsTrue(sentence.JPKana == "!>@#:'。？：");
        }

        [TestMethod]
        public void TestReservedCharacterErrorHandling()
        {
            string jpSentence = "?!\r\n:'";
            string enSentence = "?!\r\n:'";
            try
            {
                Sentence sentence = new Sentence(jpSentence, enSentence);
            }
            catch (ArgumentException exc)
            {
                Assert.IsTrue(exc.Message == "Japanese sentence can't contain reserved characters \r\n");
            }
        }
    }
}
