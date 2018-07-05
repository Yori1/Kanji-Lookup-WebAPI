using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KanjiRenshuuWebAPI.Model;

namespace KanjiRenshuuAPITests
{
    [TestClass]
    public class ExampleSentenceClassTest
    {
        [TestMethod]
        public void TestBasicExampleSentence()
        {
            string jpExampleSentence = "日本語の文章です。";
            string enExampleSentence = "This is an English sentence.";
            ExampleSentence sentence = new ExampleSentence(jpExampleSentence, enExampleSentence);
            Assert.IsTrue(sentence.JPKana == "にほんごのぶんしょうです。");
        }

        [TestMethod]
        public void TestKatakana()
        {
            string jpExampleSentenceKatakana = "カタカナが入っている文章です。";
            string enExampleSentenceKatakana = "This is a sentence with katakana in it.";
            ExampleSentence sentenceKatakana = new ExampleSentence(jpExampleSentenceKatakana, enExampleSentenceKatakana);
            Assert.IsTrue(sentenceKatakana.JPKana == "カタカナがはいっているぶんしょうです。");
        }

        [TestMethod]
        public void TestSymbols()
        {
            string jpExampleSentence = "!>@#:'。？：";
            string enExampleSentence = "!>@#:'。？：";
            ExampleSentence sentence = new ExampleSentence(jpExampleSentence, enExampleSentence);
            Assert.IsTrue(sentence.JPKana == "!>@#:'。？：");
        }

        [TestMethod]
        public void TestReservedCharacterErrorHandling()
        {
            string jpExampleSentence = "?!\r\n:'";
            string enExampleSentence = "?!\r\n:'";
            try
            {
                ExampleSentence sentence = new ExampleSentence(jpExampleSentence, enExampleSentence);
            }
            catch (ArgumentException exc)
            {
                Assert.IsTrue(exc.Message == "Japanese sentence can't contain reserved characters \r\n");
            }
        }
    }
}
