using System.Data;
using DataAccess;

namespace GameOnService;

public class GameOnService : IGameOnService
{
    public DataSet GetTopPlayedGames()
    {
        return DAGameOn.GetTopGamesUsingDBWithOutConfig("");
    }
}