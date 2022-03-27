using System.Collections.Generic;
using System.Xml.Serialization;

namespace UI.Model
{
    [XmlRoot(ElementName = "ArrayOfObjStation", Namespace = "http://api.irishrail.ie/realtime/")]
    public class ArrayOfStationModel
    {
        [XmlElement(ElementName = "objStation", Namespace = "http://api.irishrail.ie/realtime/")]
        public List<StationModel> ObjStation { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}