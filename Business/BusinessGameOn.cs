using System.Data;
using DataAccess;
using Model;
namespace Business;

public static class BusinessGameOn
{
    public static List<GameViewModel> GetTopPlayedGames(string gameType)
    {
        var gameList = new List<GameViewModel>();

        DataSet report = DAGameOn.GetTopGamesUsingDBWithOutConfig(gameType);
        //DataSet report = DAGameOn.GetTopPlayedWithOutDB();

        if (report.Tables.Count > 0)
        {
            gameList = report.Tables[0].AsEnumerable().Select(m => new GameViewModel
            {
                Title = Convert.ToString(m["Title"]),
                Platform = Convert.ToString(m["Platform"]),
                ImageUrl = Convert.ToString(m["ImageUrl"]),
                GameId = Convert.ToInt32(m["GameId"]),
            }).ToList();
        }

        return gameList;
    }
    
    public static List<AwardViewModel> GetGameAwardsList()
    {
        var gameList = new List<AwardViewModel>();

        DataSet report = DAGameOn.GetGameAwardsUsingDBWithOutConfig();
        //DataSet report = DAGameOn.GetGameAwardsWithOutDB();

        if (report.Tables.Count > 0)
        {
            gameList = report.Tables[0].AsEnumerable().Select(m => new AwardViewModel
            {
                Year = Convert.ToInt32(m["Year"]),
                Game = Convert.ToString(m["Game"]),
                Developer = Convert.ToString(m["Developer"]),
                Publisher = Convert.ToString(m["Publisher"]),
            }).ToList();
        }

        return gameList;
    }
}