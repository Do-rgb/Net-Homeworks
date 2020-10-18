using System.Xml.Serialization;

namespace CUITask2.Entities
{
    [XmlRoot(ElementName="AGENT_INFO")]
    public class AgentInfo {
        [XmlElement(ElementName="ISN")]
        public int Isn { get; set; }
        [XmlElement(ElementName="ShortName")]
        public string ShortName { get; set; }
        [XmlElement(ElementName="FullName")]
        public string FullName { get; set; }
        [XmlElement(ElementName="IsBank")]
        public bool IsBank { get; set; }
        [XmlElement(ElementName="ClassISN")]
        public int ClassIsn { get; set; }
    }
}