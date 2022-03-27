using System.Collections.Generic;
using System.Xml.Serialization;

namespace UI.Model
{
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
}