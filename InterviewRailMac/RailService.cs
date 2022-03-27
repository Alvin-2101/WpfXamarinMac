using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Flurl;
using Flurl.Http.Xml;
using Foundation;
using UI.Model;

namespace UI
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

    public interface IRailService
    {
        Task<IList<StationModel>> GetAllStationsAsync();
        Task<IList<StationData>> GetStationDetailsAsync(string stationCode);
    }
    
    namespace Model
    {
        [XmlRoot(ElementName="objStation", Namespace="http://api.irishrail.ie/realtime/")]
        public class StationModel : NSObject
        {
            [XmlElement(ElementName="StationDesc", Namespace="http://api.irishrail.ie/realtime/")]
            public string StationDesc { get; set; }
            [XmlElement(ElementName="StationAlias", Namespace="http://api.irishrail.ie/realtime/")]
            public string StationAlias { get; set; }
            [XmlElement(ElementName="StationLatitude", Namespace="http://api.irishrail.ie/realtime/")]
            public string StationLatitude { get; set; }
            [XmlElement(ElementName="StationLongitude", Namespace="http://api.irishrail.ie/realtime/")]
            public string StationLongitude { get; set; }
            [XmlElement(ElementName="StationCode", Namespace="http://api.irishrail.ie/realtime/")]
            public string StationCode { get; set; }
            [XmlElement(ElementName="StationId", Namespace="http://api.irishrail.ie/realtime/")]
            public string StationId { get; set; }
            public bool IsFavorite { get; set; }
        }
        
        [XmlRoot(ElementName="ArrayOfObjStation", Namespace="http://api.irishrail.ie/realtime/")]
        public class ArrayOfStationModel {
            [XmlElement(ElementName="objStation", Namespace="http://api.irishrail.ie/realtime/")]
            public List<StationModel> ObjStation { get; set; }
            [XmlAttribute(AttributeName="xsi", Namespace="http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
            [XmlAttribute(AttributeName="xsd", Namespace="http://www.w3.org/2000/xmlns/")]
            public string Xsd { get; set; }
            [XmlAttribute(AttributeName="xmlns")]
            public string Xmlns { get; set; }
        }

        [XmlRoot(ElementName = "objStationData")]
        public class StationData : NSObject
        {
            [XmlElement(ElementName = "Servertime")]
            public string Servertime { get; set; }
            [XmlElement(ElementName = "Traincode")]
            public string Traincode { get; set; }
            [XmlElement(ElementName = "Stationfullname")]
            public string Stationfullname { get; set; }
            [XmlElement(ElementName = "Stationcode")]
            public string Stationcode { get; set; }
            [XmlElement(ElementName = "Querytime")]
            public string Querytime { get; set; }
            [XmlElement(ElementName = "Traindate")]
            public string Traindate { get; set; }
            [XmlElement(ElementName = "Origin")]
            public string Origin { get; set; }
            [XmlElement(ElementName = "Destination")]
            public string Destination { get; set; }
            [XmlElement(ElementName = "Origintime")]
            public string Origintime { get; set; }
            [XmlElement(ElementName = "Destinationtime")]
            public string Destinationtime { get; set; }
            [XmlElement(ElementName = "Status")]
            public string Status { get; set; }
            [XmlElement(ElementName = "Lastlocation")]
            public string Lastlocation { get; set; }
            [XmlElement(ElementName = "Duein")]
            public string Duein { get; set; }
            [XmlElement(ElementName = "Late")]
            public string Late { get; set; }
            [XmlElement(ElementName = "Exparrival")]
            public string Exparrival { get; set; }
            [XmlElement(ElementName = "Expdepart")]
            public string Expdepart { get; set; }
            [XmlElement(ElementName = "Scharrival")]
            public string Scharrival { get; set; }
            [XmlElement(ElementName = "Schdepart")]
            public string Schdepart { get; set; }
            [XmlElement(ElementName = "Direction")]
            public string Direction { get; set; }
            [XmlElement(ElementName = "Traintype")]
            public string Traintype { get; set; }
            [XmlElement(ElementName = "Locationtype")]
            public string Locationtype { get; set; }
        }

        [XmlRoot(ElementName = "ArrayOfObjStationData", Namespace = "http://api.irishrail.ie/realtime/")]
        public class ArrayOfStationData
        {
            [XmlElement(ElementName = "objStationData", Namespace = "http://api.irishrail.ie/realtime/")]
            public List<StationData> ObjStationData { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
            [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsd { get; set; }
            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }
        }

        public class FavoriteStation : NSObject
        {
           public string StationCode { get; set; }

           public string Stationfullname { get; set; }

           public List<StationData> StationData { get; set; }
        }
    }
}