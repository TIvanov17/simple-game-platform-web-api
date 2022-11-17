using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication44.Models;

namespace WebApplication44.GameClasses
{
    public class GameAppPlatform
    {
        private static List<Game> collectionOfGames;

        public GameAppPlatform()
        {
            collectionOfGames = new List<Game>();
        }

        public void AddRegionForGame(Game currentGame)
        {
            if (currentGame == null)
            {
                return;
            }

            Game existingGame = collectionOfGames.FirstOrDefault
                                (g => g.Name.Equals(currentGame.Name));

            if (existingGame != null)
            {
                int gameIndexInColl = collectionOfGames.IndexOf(existingGame);
                collectionOfGames[gameIndexInColl].Region = currentGame.Region;
                Utility.CheckToConvertIfNeeded(collectionOfGames, gameIndexInColl);
            }
        }

        public void AddPriceForGame(Game currentGame)
        {
            if (currentGame == null)
            {
                return;
            }

            Game existingGame = collectionOfGames.FirstOrDefault
                                (g => g.Name.Equals(currentGame.Name));

            if (existingGame != null)
            {
                int gameCollIndex = collectionOfGames.IndexOf(existingGame);
                collectionOfGames[gameCollIndex].Price = currentGame.Price;
            }
        }

        public void AddGameInPlatform(Game newGame)
        {
            if (newGame == null)
            {
                return;
            }
                
            Game existingGame = collectionOfGames.FirstOrDefault
                                (g => g.Name.Equals(newGame.Name));

            if (existingGame == null)
            {
                Game game = new Game(newGame.Name);
                collectionOfGames.Add(game);
            }
        }

        public List<Game> GetAllGames()
        {
            return collectionOfGames;
        }

        public Game GetGameById(int gameId)
        {
            return collectionOfGames.Find(g => g.ID == gameId);
        }
    }
}