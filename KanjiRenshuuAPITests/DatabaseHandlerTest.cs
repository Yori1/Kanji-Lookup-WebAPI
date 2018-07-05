using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KanjiRenshuuWebAPI.Model;
using KanjiRenshuuWebAPI.Handlers;


namespace KanjiRenshuuAPITests
{
    [TestClass]
    public class DatabaseHandlerTest
    {
        [TestMethod]
        public void TestGetSentences()
        {
            DatabaseHandler handler = new DatabaseHandler();
            string word = "鉄";
            var sentences = handler.GetSentences(word);
            Assert.IsTrue(sentences.Count > 0);
        }
    }
}
