using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http.Xml;
using UI.Model;

namespace UI.Services
{
    public class RailService : IRailService
    {
        private static string ApiRoot = @"http://api.irishrail.ie/realtime/realtime.asmx/";
        
        public async Task<IList<StationModel>> GetAllStationsAsync()
        {
            return (await ApiRoot
                .AppendPathSegment("getAllStationsXML")
                .GetXmlAsync<ArrayOfStationModel>()).ObjStation;
        }

        public async Task<IList<StationData>> GetStationDetailsAsync(string stationCode)
        {
            return (await ApiRoot
                .AppendPathSegment("getStationDataByCodeXML")
                .SetQueryParam("StationCode", stationCode)
                .GetXmlAsync<ArrayOfStationData>()).ObjStationData;
        }
    }
}