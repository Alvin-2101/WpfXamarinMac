using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Flurl;
using Flurl.Http.Xml;
using UI.Model;

namespace UI
{
    public class RailService : IRailService
    {
        private static string ApiRoot = @"http://api.irishrail.ie/realtime/realtime.asmx/";
        
        public static async IList<StationModel> GetAllStationsAsync()
        {
            return (await ApiRoot
                .AppendPathSegment("getAllStationsXML")
                .GetXmlAsync<ArrayOfStationModel>()).ObjStation;
        }
    }

    public interface IRailService
    {
        protected IList<StationData> GetStationDetailsAsync();
        Task<IList<StationModel>> GetAllStationsAsync();
    }
    
    namespace Model
    {
        [XmlRoot(ElementName="objStation", Namespace="http://api.irishrail.ie/realtime/")]
        public class StationModel 
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
    }

}