using GamePlatform.Models;

namespace GamePlatform.Repository
{
    public static class GamePlatformManager
    {
        private const string REGION_EUROPE = "Europe";
        private const string REGION_USA = "USA";

        public static bool CheckRegionIsNotValid(string region)
        {
            return !region.Equals(REGION_EUROPE) && 
                   !region.Equals(REGION_USA);
        }

        public static bool CheckCurrenyCodeIsNotValid(string code) 
        {
            return (!code.Equals(Currency.Code.USD.ToString()) &&
                    !code.Equals(Currency.Code.EUR.ToString()));
        }

        public static void ConvertIfNeeded(Game game)
        {
            if (IsPriceNotSet(game))
            {
                return;
            }

            if (game.Region.Equals(REGION_USA))
            {
                game.Price.ConvertTo(Currency.Code.USD);
                return;
            }
            game.Price.ConvertTo(Currency.Code.EUR);
        }

        public static void SetRegionByCurrencyCode(Game game)
        {
            if(IsRegionSet(game))
            {
                return;
            }

            if (game.Price.CurrencyCode.Equals(Currency.Code.USD.ToString()))
            {
                game.Region = REGION_USA;
                return;
            }
            game.Region = REGION_EUROPE;
        }

        private static bool IsPriceNotSet(Game game)
        {
            return game.Price == null;
        }

        private static bool IsRegionSet(Game game)
        {
            return game.Region != null;
        }
    }
}