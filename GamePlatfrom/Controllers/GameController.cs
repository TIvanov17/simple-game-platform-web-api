using System.Collections.Generic;
using System.Web.Http;
using GamePlatform.Repository;
using GamePlatform.Models;

namespace GamePlatform.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private static GameRepository gameAppPlatform = new GameRepository();

        public IList<Game> GetAllGames()
        {
            return gameAppPlatform.GetAllGames();
        }

        public Game GetGameDetails(int id)
        {
            return gameAppPlatform.GetGameById(id);
        }

        [HttpPost]
        [Route("create")]
        public void PostGameFromBody([FromBody] Game newGame)
        {
            if (ModelState.IsValid)
            {
                gameAppPlatform.Create(newGame);
            }
        }

        [HttpPut]
        [Route("SetPrice")]
        public void PostSetGamePrice(int id, [FromBody] Currency currency)
        {
            if (ModelState.IsValid)
            {
                gameAppPlatform.UpdateGamePrice(id, currency);
            }
        }

        [HttpPut]
        [Route("SetRegion")]
        public void PostSetGameRegion(int id, [FromBody] string region)
        {
            gameAppPlatform.UpdateGameRegion(id, region);
        }


        [HttpDelete]
        [Route("delete")]
        public void DeleteGame(int id)
        {
            gameAppPlatform.Delete(id);
        }
    }
}
