using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApplication44.GameClasses;
using WebApplication44.Models;

namespace WebApplication44.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private static GameAppPlatform gameAppPlatform = new GameAppPlatform();
        
        [HttpPost]
        [Route("SetPrice")]
        public void PostSetGamePrice([FromBody] Game currentGame)
        {
            gameAppPlatform.AddPriceForGame(currentGame);
        }

        [HttpPost]
        [Route("SetRegion")]
        public void PostSetGameRegion([FromBody] Game currentGame)
        {
            gameAppPlatform.AddRegionForGame(currentGame);
        }

        [HttpPost]
        [Route("create")]
        public void PostGameFromBody([FromBody] Game newGame)
        {
            gameAppPlatform.AddGameInPlatform(newGame);
        }

        public IList<Game> GetAllGames()
        {
            return gameAppPlatform.GetAllGames();
        }

        public Game GetGameDetails(int id)
        {
            return gameAppPlatform.GetGameById(id);
        }

    }


}
