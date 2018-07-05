using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using KanjiRenshuuWebAPI.Model;

namespace KanjiRenshuuWebAPI.Handlers
{
    public class DatabaseHandler
    {
        string connectionString;

        public DatabaseHandler()
        {
            connectionString = "Filename=./ExampleSentences.sqlite;";
        }

        public string getstring()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

       public List<ExampleSentence> GetSentences(string word)
        {
            string str = getstring();

            int maxAmount = 20;
            SqliteConnection conn = new SqliteConnection(connectionString);
            conn.Open();
            SqliteCommand comm = new SqliteCommand($"select * from sentence where sentence.japanese like  '%{word}%'", conn);

            List<ExampleSentence> sentences = new List<ExampleSentence>();

            var reader = comm.ExecuteReader();
            using (reader)
            {
                for(int sentenceCount = 0; reader.Read() && sentenceCount<maxAmount; sentenceCount++)
                {
                    string japaneseSentence = reader[1].ToString();
                    string englishSentence = reader[3].ToString();
                    if (!japaneseSentence.Contains("\r\n"))
                    {
                        sentences.Add(new ExampleSentence(japaneseSentence, englishSentence));
                    }
                }
            }

            return sentences;
        }

    }
}
