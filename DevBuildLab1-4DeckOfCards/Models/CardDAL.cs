using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DevBuildLab1_4DeckOfCards.Models
{
    public class CardDAL
    {
        public CardDeck GenerateNewDeck()
        {
            string url = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";
            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string result = rd.ReadToEnd();
            rd.Close();

            CardDeck d = JsonConvert.DeserializeObject<CardDeck>(result);

            return d;

        }
        public CardDeck DrawCards(CardDeck d, int numToDraw)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{d.deck_id}/draw/?count={numToDraw}";
            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string result = rd.ReadToEnd();
            rd.Close();

            CardDeck deck = JsonConvert.DeserializeObject<CardDeck>(result);

            return deck;
        }
    }
}
