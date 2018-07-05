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
            string jpSentence = "���{��̕��͂ł��B";
            string enSentence = "This is an English sentence.";
            Sentence sentence = new Sentence(jpSentence, enSentence);
            Assert.IsTrue(sentence.JPKana == "�ɂق񂲂̂Ԃ񂵂傤�ł��B");
        }

        [TestMethod]
        public void TestKatakana()
        {
            string jpSentenceKatakana = "�J�^�J�i�������Ă��镶�͂ł��B";
            string enSentenceKatakana = "This is a sentence with katakana in it.";
            Sentence sentenceKatakana = new Sentence(jpSentenceKatakana, enSentenceKatakana);
            Assert.IsTrue(sentenceKatakana.JPKana == "�J�^�J�i���͂����Ă���Ԃ񂵂傤�ł��B");
        }

        [TestMethod]
        public void TestSymbols()
        {
            string jpSentence = "!>@#:'�B�H�F";
            string enSentence = "!>@#:'�B�H�F";
            Sentence sentence = new Sentence(jpSentence, enSentence);
            Assert.IsTrue(sentence.JPKana == "!>@#:'�B�H�F");
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
