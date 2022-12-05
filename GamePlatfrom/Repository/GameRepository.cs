using System.Collections.Generic;
using System.Linq;
using GamePlatform.Models;

namespace GamePlatform.Repository
{
    public class GameRepository : IGameRepository
    {
        private static List<Game> collectionOfGames;
        private static int currentGameID;

        public GameRepository()
        {
            collectionOfGames = new List<Game>();
            currentGameID = 1;
        }
        public List<Game> GetAllGames()
        {
            return collectionOfGames;
        }

        public Game GetGameById(int id)
        {
            return collectionOfGames.FirstOrDefault(g => g.ID == id);
        }
        
        public void Create(Game game)
        {
            Game existingGame = collectionOfGames
                                .FirstOrDefault(g => g.Name.Equals(game.Name));

            if (existingGame == null)
            {
                game.ID = currentGameID++;
                GamePlatformManager.SetRegionByCurrencyCode(game);
                collectionOfGames.Add(game);
            }
        }

        public void UpdateGameRegion(int id, string region)
        {
            Game existingGame = collectionOfGames.FirstOrDefault(g => g.ID == id);
            
            if (GamePlatformManager.CheckRegionIsNotValid(region))
            {
                throw new System.Exception("The Region Is Not Valid !");
            }

            if (existingGame != null)
            {
                int gameIndexInColl = collectionOfGames.IndexOf(existingGame);
                collectionOfGames[gameIndexInColl].Region = region;
                GamePlatformManager.ConvertIfNeeded(collectionOfGames[gameIndexInColl]);
            }
        }

        public void UpdateGamePrice(int id, Currency currency)
        {
            Game existingGame = collectionOfGames.FirstOrDefault(g => g.ID == id);

            if (GamePlatformManager.CheckCurrenyCodeIsNotValid(currency.CurrencyCode))
            {
                throw new System.Exception("The Curreny Code Is Not Valid !");
            }

            if (existingGame != null)
            {
                int gameIndex = collectionOfGames.IndexOf(existingGame);
                collectionOfGames[gameIndex].Price = currency;
                GamePlatformManager.SetRegionByCurrencyCode(existingGame);
            }
        }

        public void Delete(int id)
        {
            Game game = GetGameById(id);
            if(game != null)
            {
                collectionOfGames.Remove(game);
            }
        }
    }
}