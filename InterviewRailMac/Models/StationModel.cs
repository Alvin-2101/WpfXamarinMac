using System.Xml.Serialization;
using Foundation;

namespace UI.Model
{
    [XmlRoot(ElementName = "objStation", Namespace = "http://api.irishrail.ie/realtime/")]
    public class StationModel : NSObject
    {
        [XmlElement(ElementName = "StationDesc", Namespace = "http://api.irishrail.ie/realtime/")]
        public string StationDesc { get; set; }
        [XmlElement(ElementName = "StationAlias", Namespace = "http://api.irishrail.ie/realtime/")]
        public string StationAlias { get; set; }
        [XmlElement(ElementName = "StationLatitude", Namespace = "http://api.irishrail.ie/realtime/")]
        public string StationLatitude { get; set; }
        [XmlElement(ElementName = "StationLongitude", Namespace = "http://api.irishrail.ie/realtime/")]
        public string StationLongitude { get; set; }
        [XmlElement(ElementName = "StationCode", Namespace = "http://api.irishrail.ie/realtime/")]
        public string StationCode { get; set; }
        [XmlElement(ElementName = "StationId", Namespace = "http://api.irishrail.ie/realtime/")]
        public string StationId { get; set; }
        public bool IsFavorite { get; set; }
    }
}