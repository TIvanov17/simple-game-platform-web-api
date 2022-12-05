using GamePlatform.Models;
using System.Collections.Generic;


namespace GamePlatform.Repository
{
    interface IGameRepository
    {
        List<Game> GetAllGames();
        Game GetGameById(int gameId);
        void Create(Game game);
        void UpdateGameRegion(int id, string region);
        void UpdateGamePrice(int id, Currency currency);
    }
}
