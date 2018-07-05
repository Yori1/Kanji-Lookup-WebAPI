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
            string jpExampleSentence = "���{��̕��͂ł��B";
            string enExampleSentence = "This is an English sentence.";
            ExampleSentence sentence = new ExampleSentence(jpExampleSentence, enExampleSentence);
            Assert.IsTrue(sentence.JPKana == "�ɂق񂲂̂Ԃ񂵂傤�ł��B");
        }

        [TestMethod]
        public void TestKatakana()
        {
            string jpExampleSentenceKatakana = "�J�^�J�i�������Ă��镶�͂ł��B";
            string enExampleSentenceKatakana = "This is a sentence with katakana in it.";
            ExampleSentence sentenceKatakana = new ExampleSentence(jpExampleSentenceKatakana, enExampleSentenceKatakana);
            Assert.IsTrue(sentenceKatakana.JPKana == "�J�^�J�i���͂����Ă���Ԃ񂵂傤�ł��B");
        }

        [TestMethod]
        public void TestSymbols()
        {
            string jpExampleSentence = "!>@#:'�B�H�F";
            string enExampleSentence = "!>@#:'�B�H�F";
            ExampleSentence sentence = new ExampleSentence(jpExampleSentence, enExampleSentence);
            Assert.IsTrue(sentence.JPKana == "!>@#:'�B�H�F");
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
