using System.Collections.Generic;
using Foundation;

namespace UI.Model
{
    public class FavoriteStation : NSObject
    {
        public string StationCode { get; set; }

        public string Stationfullname { get; set; }

        public List<StationData> StationData { get; set; }
    }
}