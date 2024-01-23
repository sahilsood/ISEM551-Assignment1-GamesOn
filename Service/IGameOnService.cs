using System.ServiceModel;
using System.Data;

namespace GameOnService;

[ServiceContract]
public interface IGameOnService
{
    [OperationContract]
    DataSet GetTopPlayedGames(string gameType);
    
    [OperationContract]
    DataSet GetGameAwards();
}