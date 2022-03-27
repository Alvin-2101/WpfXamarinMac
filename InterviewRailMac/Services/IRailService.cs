using System.Collections.Generic;
using System.Threading.Tasks;
using UI.Model;

namespace UI.Services
{
    public interface IRailService
    {
        Task<IList<StationModel>> GetAllStationsAsync();
        Task<IList<StationData>> GetStationDetailsAsync(string stationCode);
    }
}