using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication44.Models;

namespace WebApplication44.GameClasses
{
    public static class Utility
    {
        private const string REGION_EUROPE = "Europe";
        private const string REGION_USA = "USA";

        public static void CheckToConvertIfNeeded
                    (List<Game> collectionOfGames, int gameIndexInColl)
        {
            if (collectionOfGames[gameIndexInColl].Price != null && 
                collectionOfGames[gameIndexInColl].Region.Equals(REGION_EUROPE))
            {
                collectionOfGames[gameIndexInColl].Price.ConvertToEURO();
                return;
            }
            if (collectionOfGames[gameIndexInColl].Price != null &&
                collectionOfGames[gameIndexInColl].Region.Equals(REGION_USA))
            {
                collectionOfGames[gameIndexInColl].Price.ConvertToUSD();
            }
        }
    }
}