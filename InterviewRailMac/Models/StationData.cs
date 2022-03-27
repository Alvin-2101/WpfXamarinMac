using System.Xml.Serialization;
using Foundation;

namespace UI.Model
{
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
}