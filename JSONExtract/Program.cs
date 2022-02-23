using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace JSONExtract
{
    class Program
    {
        class Pagination
        {
            public int Page { get; set; }
            public string PageNext { get; set; }
            public string PagePrev { get; set; }
            public int PageTotal { get; set; }
            public int Results { get; set; }
            public int ResultsPerPage { get; set; }
            public int ResultsTotal { get; set; }
        }

        class PackedJSON
        {
            public Pagination Pagination { get; set; }
            public Character[] Results { get; set; }
        }

        class Character
        {
            public string Avatar { get; set; }
            public int FeastMatches { get; set; }
            public int ID { get; set; }
            public string Lang { get; set; }
            public string Rank { get; set; }
            public string RankIcon { get; set; }
            public string Server { get; set; }
        }

        static void Main(string[] args)
        {
            string url = "https://xivapi.com/character/search?name=Astar+Moonseeker&server=Phoenix";

            string json;

            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }

            PackedJSON data = JsonConvert.DeserializeObject<PackedJSON>(json);
            Character character = data.Results[0];

            Console.WriteLine(character.ID);
            // wait before closing console
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}

