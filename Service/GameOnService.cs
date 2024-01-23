using System.Data;
using DataAccess;

namespace GameOnService;

public class GameOnService : IGameOnService
{
    public DataSet GetTopPlayedGames(string gameType)
    {
        return DAGameOn.GetTopGamesUsingDBWithOutConfig(gameType);
    }
    
    public DataSet GetGameAwards()
    {
        return DAGameOn.GetGameAwardsUsingDBWithOutConfig();
    }
}